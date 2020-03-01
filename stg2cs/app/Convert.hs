{-# LANGUAGE ScopedTypeVariables, RankNTypes, FlexibleContexts #-}
module Convert (stg2cs) where

import Data.Char
import Data.List
import Control.Monad.Trans
import Control.Monad.State
import DynFlags
import Outputable
import HscTypes
import SimplStg
import SimplCore
import CoreSyn (AltCon(..))
import StgSyn
import TyCon
import TyCoRep
import DataCon
import Var
import Literal
import Name (nameStableString, nameOccName)
import OccName (occNameFS)
import FastString (unpackFS)
import Kind
import IdInfo
import GHC hiding (Name)
import qualified GHC
import StgCmmClosure (idPrimRep)
import Type
import PrimOp

{-
######################################
       C# representation of STG
######################################
-}
type Arity = Int
type Index = Int
type Name = String
type Arg = Id

data CSType = Closure | Int32 | Int64 | Char | Boolean | Float | Double | String | Class Name [CSType]
    deriving (Eq)
data CSValue = CSCon Name [CSValue] | CSRef Id | CSLit Literal

data CSEntity =
    CSTDataType Id [CSType]
    | CSTFunction Id Arity CSMethod
    | CSTThunk Id CSMethod
    | CSTConst Id CSValue
{-
    CSEntity is either a type, a closure instance or a data constant,
    that is available on the top level in a module.
    
    Data types are pretty generic in that they follow the template
        public sealed class <Id> : Data {
            public <CSType> x0;
            ...
            public <CSType> xN;
            public <Id>(<CSType> a0, ..., aN) {
                ∀i xi = ai;
            }
        }
    
    Closures are parameterless instances of either Function or Thunk. <CSMethod> is the entry point.
-}

data CSMethod = Method Name CSType [Arg] CSExpr
data CSExpr =
    CSELit Literal -- unboxed literal
    | CSEVar Id    -- variable
    | CSECon Name [CSValue]  -- saturated constructor
    | CSEApp Id [CSValue]  -- assisted application
    | CSECall Name [CSValue]    -- continue with another method
                               -- or call a foreign/system function
    | CSEEval Id CSExpr -- evaluate <Id> on the stack and continue with <CSExpr>
    | CSEEvalThen Id Name [Id] -- evaluate <Id> then proceed to method <Name> with live parameters <[Id]>
    | CSELet Id CSExpr CSExpr  -- non-rec assign <Id> := <CSExpr> and continue to evaluate <CSExpr₂>
    | CSECase Id [CSAlt]  -- unpack an evaluated value
    | CSELetRec [(Id,CSExpr,[Id])] CSExpr
        -- recursive assign <Id> := <CSExpr'>
        -- where CSExpr' is CSExpr with <[Id]> replaced by null
        -- after all let assignments we need to feed them created values
        -- to do that when emitting nulls we need to remember their position
        -- because parameters are called xN
    | CSEPrimOp PrimOp [CSValue]  -- a primitive operation
        -- Note: it seems there's a lot of those
    | CSECreateFun Name Arity [CSValue]
        -- create a generic FunctionN object (N is <Arity>)
        -- new FunctionN(ldftn <Name>, <[CSExpr]>)
        --
        -- if [CSExpr] is [] the bound object should be marked
        -- as a direct call to <Name> and the method called directly
        -- when bound object appears in a CSEApp <Id> position
    | CSECreateThunk Name [CSValue]
        -- creates a generic UpdatableK object (K is len [CSExpr])
        -- new UpdatableK(ldftn <Name>, <[CSExpr]>)
    | CSECreateClosure Name [CSValue]
        -- creates a generic SingleEntryK object (K is len [CSExpr])
        -- new SingleEntryK(ldftn <Name>, <[CSExpr]>)
    | CSEUnpack Name Index  -- access data field <Name>.x<Index>
    | CSECastAs Id Name     -- cast expression onto type
        -- (<CSExpr> as <Name>)
    | CSEThrow Id  -- throw new Exception(<Id>) where Id points to a constant string
    | CSENotImplemented -- throw new NotImplementedException()
    | CSEImpossible -- throw new ImpossibleException()

data CSAlt = 
    CSADefault CSExpr  -- default: {<CSExpr>}
    | CSALit Literal CSExpr -- e.g. case 1: {<CSExpr>}
    | CSACon Name Name CSExpr
        -- e.g. case Int a_Int: {
        --     var aa = a_Int.x0;
        --     <CSExpr w/ aa>   
        -- }

{-
######################################
       State monad definition
######################################
-}

data CSState = ST {
    entities :: [CSEntity],
    code :: [CSMethod],
    exports :: [CSEntity], -- only CSTConst emitted as prop

    callables :: [(GHC.Name, Name)], -- constant <Id> points to static function <Name>
    globals :: [GHC.Name], -- global identifiers

    lifted :: Maybe Bool,
    -- during case expression evaluation
    -- if we're supposed to return a lifted value
    -- we can use the trampoline properly with StgEval.EvalThen
    -- otherwise use StgEval.Eval

    dynFlags :: DynFlags
}

initState df = ST {
    entities = [],
    code = [],
    exports = [],

    callables = [],
    globals = [],

    lifted = Nothing,

    dynFlags = df
}

type CSST a = State CSState a 

{-
######################################
       Module entry point
######################################
-}

stg2cs :: DynFlags -> [StgTopBinding] -> String
stg2cs df stg = evalState (go >> prettyPrint) $ initState df
    where
        go = do
            mapM_ gatherGlobals stg
            mapM_ processTop stg

prettyPrint = do
    st <- get
    showWithFlags st

gatherGlobals :: StgTopBinding -> CSST ()
gatherGlobals (StgTopStringLit id _) = addGlobal id
gatherGlobals (StgTopLifted (StgNonRec id (StgRhsCon _ _ _))) = addGlobal id
gatherGlobals (StgTopLifted (StgNonRec id (StgRhsClosure _ _ _ flag _ _))) = do
    addGlobal id
    case flag of
        ReEntrant -> do
            name <- toName id
            addCallable id (name ++ "_Entry")
        _ -> return ()
gatherGlobals (StgTopLifted (StgRec bndrs)) = mapM_ processAsNonRec bndrs
    where
        processAsNonRec (id, rhs) = gatherGlobals (StgTopLifted (StgNonRec id rhs))

processTop :: StgTopBinding -> CSST ()
processTop (StgTopStringLit id bstr) = do
    addConst id $ CSLit (MachStr bstr)
processTop (StgTopLifted (StgNonRec id (StgRhsCon _ dataCon args))) = do
    let conArgs = map convertArg args
    conName <- getConName dataCon
    addConst id $ CSCon conName conArgs
processTop (StgTopLifted (StgNonRec id (StgRhsClosure _ _ occ flag args expr))) = do
    if occ /= [] then error "top level entities can't have params"
                else return ()
    methods <- makeMethods id args expr
    addMethods methods
    case flag of
        ReEntrant -> do -- it's a function
            addFunc id (length args) (head methods)
        Updatable -> do -- it's a thunk
            addThunk id (head methods)
        _ -> error "top level single entry closure"
processTop (StgTopLifted (StgRec bndrs)) = mapM_ processAsNonRec bndrs
    where
        processAsNonRec (id, rhs) = processTop (StgTopLifted (StgNonRec id rhs))

makeMethods :: Id -> [Arg] -> GenStgExpr Id Id -> CSST [CSMethod]
makeMethods id args expr = do
    let retType = funRetType id args
    setLiftedFlag retType
    (e, ms) <- convertExpr id args expr
    name <- toName id
    return $ Method (name ++ "_Entry") retType args e : ms

{-
######################################
    STG Expression -> C# Expression
######################################
-}

convertExpr :: Id -> [Arg] -> GenStgExpr Id Id -> CSST (CSExpr, [CSMethod])
convertExpr _ _ (StgLit l) = return (CSELit l, [])
convertExpr _ _ (StgApp fid args) = do
    if length args == 0 then
        return (CSEVar fid, [])
    else do
        let as = map convertArg args
        callableVars <- callables <$> get
        case lookup (varName fid) callableVars of
            Just methodName -> return (CSECall methodName as, [])
            Nothing -> return (CSEApp fid as, [])
convertExpr _ _ (StgConApp con args _) = do
    let as = map convertArg args
    name <- getConName con
    return (CSECon name as, [])
convertExpr _ _ (StgOpApp (StgPrimOp op) args _) = do
    let as = map convertArg args
    return (CSEPrimOp op as, [])
convertExpr _ _ (StgOpApp (StgPrimCallOp (PrimCall label _)) args _) = do
    name <- showWithFlags label
    let as = map convertArg args
    return (CSECall name as, [])

convertExpr id args (StgCase (StgApp v []) _ _ alts) 
    | isVoidRep (idPrimRep v) -- state void# token
    , [(DEFAULT, _, rhs)] <- alts 
    = convertExpr id args rhs 
convertExpr id args (StgCase e alias _ alts) = do
    (csalts, free, ms) <- convertAlts alias id args alts
    name <- toName id
    aliasName <- toName alias
    (caseExpr, _) <- convertExpr id args e -- asumes simple expr
    let vt = idType alias
    case isUnliftedType vt of
        True -> do
            case caseExpr of 
                CSEApp id' args' -> do
                    n <- toName id'
                    let n' = n++"_Entry"
                    return (CSELet alias (CSECall n' args') (CSECase alias csalts), ms)
                _ ->
                    return (CSELet alias caseExpr (CSECase alias csalts), ms)
        False -> do
            isLifted <- liftedContext
            case isLifted of
                True -> do
                    let caseMethodName = name ++ "_Case_" ++ aliasName
                    let caseMethod = Method caseMethodName Closure (alias : free) (CSECase alias csalts)
                    let evalExpr = CSEEvalThen alias caseMethodName free
                    return (CSELet alias caseExpr evalExpr, caseMethod : ms)
                False -> do
                    let evalExpr = CSEEval alias (CSECase alias csalts)
                    return (CSELet alias caseExpr evalExpr, ms)
                    
{-
    case e of alias {
        alts...
    }

    =>

    var alias = e;
    eval alias then m

    m(alias) {
        switch (alias)
            alts...
    }
-}
convertExpr id' args' (StgLet (StgNonRec id (StgRhsCon _ dataCon args)) e) = do
    let as = map convertArg args
    name <- getConName dataCon
    let conExpr = CSECon name as
    (ex, ms) <- convertExpr id' args' e
    return (CSELet id conExpr ex, ms)
convertExpr id' args' (StgLet (StgNonRec id (StgRhsClosure _ _ occs flag bndrs e1)) ec) = do
    let t = typeToCSType (idType id)
    (e1x, ms2) <- withLifted (t == Closure) $ convertExpr id (occs++bndrs) e1
    name <- toName id
    let methodName = name++"_Entry"
    let method = Method methodName Closure (occs++bndrs) e1x
    let assExpr = case flag of
                    ReEntrant -> CSECreateFun methodName (length bndrs) (map CSRef occs)
                    Updatable -> CSECreateThunk methodName (map CSRef occs)
                    SingleEntry -> CSECreateClosure methodName (map CSRef occs)
    (ecx, ms) <- case flag of
                    ReEntrant -> 
                        case occs of
                            [] -> withCallable id methodName (convertExpr id' args' ec)
                            _ -> convertExpr id' args' ec
                    _ -> convertExpr id' args' ec
    return (CSELet id assExpr ecx, method : ms2 ++ ms)
-- TODO
-- convertExpr (StgLet (StgRec rhss) ec) = do
--     ecx <- convertExpr ec
--     bs <- mapM convertRhs rhss
--     return (LetRec bs ecx)
convertExpr id args (StgLetNoEscape binding ec) = convertExpr id args (StgLet binding ec)
convertExpr _ _ _ = return (CSENotImplemented, [])

withCallable :: Id -> Name -> CSST a -> CSST a
withCallable id name m = do
    addCallable id name
    x <- m
    popCallable
    return x

convertAlts :: Id -> Id -> [Arg] -> [GenStgAlt Id Id] -> CSST ([CSAlt], [Id], [CSMethod])
convertAlts alias id args alts = do
    (csalts, free, ms) <- convertAlts' alias id args alts
    globalVars <- globals <$> get
    let freeWithoutGlobals = filter (\i -> notElem (varName i) globalVars) free
    case head csalts of
        CSADefault _ -> return (csalts, freeWithoutGlobals, ms)
        _ -> return (CSADefault CSEImpossible : csalts, freeWithoutGlobals, ms)
    where
        convertAlts' alias id args [a] = do
            (a', f', m') <- convertAlt alias id args a
            return ([a'], nubFreeVars f', m')
        convertAlts' alias id args (a:as) = do
            (a', free, ms) <- convertAlt alias id args a
            (as', free', ms') <- convertAlts' alias id args as
            return (a':as', nubFreeVars (free ++ free'), ms ++ ms')

convertAlt :: Id -> Id -> [Arg] -> GenStgAlt Id Id -> CSST (CSAlt, [Id], [CSMethod])
convertAlt _ id args (DEFAULT, _, e) = do
    let free = exprFreeVars e
    (ex, ms) <- convertExpr id args e
    return (CSADefault ex, free, ms)
convertAlt _ id args (LitAlt l, _, e) = do
    let free = exprFreeVars e
    (ex, ms) <- convertExpr id args e
    return (CSALit l ex, free, ms)
convertAlt alias id args (DataAlt con, bndrs, e) = do
    let free = exprFreeVars e
    let boundUniques = map varName bndrs
    let nonBoundFree = filter (\i -> notElem (varName i) boundUniques) free
    (ex, ms) <- convertExpr id args e
    conName <- getConName con
    aliasName <- toName alias
    let varName = aliasName ++ "_" ++ conName
    let boundExpr = makeBoundExpr varName ex 0 bndrs
    return (CSACon conName varName boundExpr, nonBoundFree, ms) 
    where
        makeBoundExpr b e _ [] = e
        makeBoundExpr b e i (id:ids) =
            CSELet id (CSEUnpack b i) $ makeBoundExpr b e (i+1) ids

{-
######################################
    STG Expression free variables
######################################
-}

exprFreeVars :: GenStgExpr Id Id -> [Id]
exprFreeVars (StgApp id args) = id : argFreeVars args
exprFreeVars (StgLit _) = []
exprFreeVars (StgConApp _ args _) = argFreeVars args
exprFreeVars (StgOpApp _ args _) = argFreeVars args
exprFreeVars (StgCase e alias _ alts) = exprFreeVars e ++ (filter (\i -> varName i /= varName alias) $ altsFreeVars alts)
exprFreeVars (StgLet bind e) = 
    let boundUniques = map varName $ bindBoundVars bind in 
    bindFreeVars bind ++ (filter (\i -> notElem (varName i) boundUniques) $ exprFreeVars e)
exprFreeVars (StgLetNoEscape bind e) = 
    let boundUniques = map varName $ bindBoundVars bind in 
    bindFreeVars bind ++ (filter (\i -> notElem (varName i) boundUniques) $ exprFreeVars e)

altsFreeVars alts = concat $ map altFreeVars alts
altFreeVars (DEFAULT, _, e) = exprFreeVars e
altFreeVars (LitAlt _, _, e) = exprFreeVars e
altFreeVars (DataAlt _, bndrs, e) =
    let boundUniques = map varName bndrs in
    filter (\i -> notElem (varName i) boundUniques) $ exprFreeVars e

bindFreeVars (StgNonRec _ rhs) = rhsFreeVars rhs
bindFreeVars (StgRec l) =
    let bndrs = map (\(b,_) -> b) l in
    let boundUniques = map varName bndrs in
    let free = concat $ map (\(_,r) -> rhsFreeVars r) l in
    filter (\i -> notElem (varName i) boundUniques) free
rhsFreeVars (StgRhsClosure _ _ occ _ _ _) = occ
rhsFreeVars (StgRhsCon _ _ args) = argFreeVars args

bindBoundVars (StgNonRec b _) = [b]
bindBoundVars (StgRec l) = map (\(b,_) -> b) l

argFreeVars [] = []
argFreeVars ((StgVarArg id):args) = id : argFreeVars args
argFreeVars ((StgLitArg _):args) = argFreeVars args

nubFreeVars [] = []
nubFreeVars (v:vs) =
    v : filter (\i -> varName i /= varName v) (nubFreeVars vs)

{-
######################################
Helper conversion and monad functions
######################################
-}

convertArg :: GenStgArg Id -> CSValue
convertArg (StgVarArg id) = CSRef id
convertArg (StgLitArg lit) = CSLit lit

getFlags = dynFlags <$> get
addConst id value = modify (\s -> s { entities = (CSTConst id value) : entities s})
addFunc id args ms = modify (\s -> s { entities = (CSTFunction id args ms) : entities s})
addThunk id ms = modify (\s -> s { entities = (CSTThunk id ms) : entities s})
addMethods ms = modify (\s -> s { code = ms ++ code s})
addGlobal id = modify (\s -> s { globals = varName id : globals s})
addCallable id name = modify (\s -> s { callables = (varName id,name) : callables s})
popCallable = modify (\s -> s { callables = tail $ callables s})

getConName :: DataCon -> CSST Name
getConName dataCon = showWithFlags $ dataConName dataCon

toName :: Id -> CSST Name
toName id = do
    name <- showWithFlags id
    case head name of
        '$' -> let u = varUnique id in return (name ++ show u)
        _ -> case name of
                ('i':'p':'v':_) -> let u = varUnique id in return (name ++ show u)
                _ -> return name

setLiftedFlag :: CSType -> CSST ()
setLiftedFlag Closure = modify (\s -> s { lifted = Just True})
setLiftedFlag _ = modify (\s -> s { lifted = Just False})

liftedContext :: CSST Bool
liftedContext = do
    l <- lifted <$> get
    case l of
        Just b -> return b
        Nothing -> error "liftedContext: Nothing"

withLifted b m = do
    l <- lifted <$> get
    modify (\s -> s { lifted = Just b})
    x <- m
    modify (\s -> s { lifted = l})
    return x

showWithFlags x = do
    df <- getFlags
    return $ showPpr df x

litType (MachChar _) = Char
litType (LitNumber LitNumInt64 _ _) = Int64
litType (LitNumber LitNumWord64 _ _) = Int64
litType (LitNumber LitNumWord i _) = Int64
litType (LitNumber _ _ _) = Int32
litType (MachStr bs) = String
litType (MachFloat r) = Float
litType (MachDouble r) = Double
litType _ = error "unsupported literal"

valueType (CSCon name _ ) = Class name []
valueType (CSRef _) = Closure
valueType (CSLit l) = litType l

funRetType id args = funRetType' (length args) (idType id)
    where
        funRetType' 0 t = typeToCSType t
        funRetType' n (FunTy t1 t2) = funRetType' (n-1) t2
        funRetType' n (AppTy (AppTy ft t1) t2) = funRetType' (n-1) t2
        funRetType' _ _ = Closure

typeToCSType t =
    case isUnliftedType t of
        False -> Closure
        True -> unliftedTypeToCSType t
unliftedTypeToCSType t =
            case t of
                TyConApp tc tyArgs -> 
                    let name = tyConName tc in
                    case nameToStr name of
                        "Int#" -> Int32
                        "Char#" -> Char
                        "Double#" -> Double
                        "Int64#" -> Int64
                        "(#,#)" -> Class "RawTuple" (map typeToCSType (tail $ tail tyArgs))
                            -- skip the first two arguments which describe layout
                            -- of the unlifted tuple (eg. TupleRep, UnliftedRep)
                        "State#" -> Class "State" (map typeToCSType tyArgs)
                        strName -> Class (strName ++ "_UnImplemented") []

nameToStr name =
    let occ = nameOccName name
        fs = occNameFS occ
        strName = unpackFS fs in
    strName

{-
######################################
          C# pretty printing
######################################
-}

instance Outputable CSState where
    ppr s =
        hsep [hang (text "public static class Module {")
                  4 
                  (sep [pprMultiline (entities s), text "}"])]
        $$
        hsep [hang (text "public static class Code {")
                  4 
                  (sep [pprMultiline (code s), text "}"])]
instance Outputable CSEntity where
    ppr (CSTConst id val) =
        hsep [text "public static", ppr (valueType val), pprWithUnique id, text "=", ppr val, text ";"]
    ppr (CSTFunction id arity (Method n _ _ _)) =
        hsep [text "public static Function", pprWithUnique id , text $ "= new Function"++show arity++"(CLR.LoadFunctionPointer(Code."++n++"));"]
    ppr (CSTThunk id (Method n _ _ _)) =
        hsep [text "public static Thunk", pprWithUnique id, text $ "= new Updatable0(CLR.LoadFunctionPointer(Code."++n++"));"]

pprWithUnique id = 
    let name = nameToStr (varName id) in
    case head name of
        '$' -> hcat [ppr id, text (show $ varUnique id)]
        _ -> case name of
                ('i':'p':'v':_) -> hcat [ppr id, text (show $ varUnique id)]
                _ -> ppr id

instance Outputable CSType where
    ppr Closure = text "Closure"
    ppr Int32 = text "int"
    ppr Int64 = text "long"
    ppr Float = text "float"
    ppr Double = text "double"
    ppr Char = text "char"
    ppr String = text "string"
    ppr (Class n []) = text n
    ppr (Class n args) = hcat $ [text n, text "<", pprArgs args, text ">"]

instance Outputable CSValue where
    ppr (CSCon name args) =
        hsep [text $ "new "++name++"(", pprArgs args, text ")"]
    ppr (CSRef id) = pprWithUnique id
    ppr (CSLit l) = ppr l

instance Outputable CSMethod where
    ppr (Method name typ args ex) =
        hsep [hang 
                (hsep [text "public static", ppr typ, text $ name ++ "(StgContext ctx" ++
                                                        (case args of [] -> ""; _ -> ","), pprArguments args, text ") {"])
                4
                (sep [ppr ex, text "}"])]

pprArguments :: [Id] -> SDoc
pprArguments [] = text ""
pprArguments [a] = hsep [pprVarType a, pprWithUnique a]
pprArguments (a:as) = hsep [pprVarType a, pprWithUnique a, text ",", pprArguments as]

pprVarType a =
    let t = idType a in
    case isUnliftedType t of
        False -> ppr Closure
        True -> 
            case t of
                TyConApp tc _ -> 
                    let name = tyConName tc 
                        occ = nameOccName name
                        fs = occNameFS occ
                        strName = unpackFS fs in
                    case strName of
                        "Int#" -> ppr Int32
                        "Char#" -> ppr Char
                        "Double#" -> ppr Double
                        _ -> text strName -- TODO

pprArgs [] = text ""
pprArgs [a] = ppr a
pprArgs (a:as) = hsep [ppr a, text ",", pprArgs as]

pprMultiline [a] = ppr a
pprMultiline (a:as) = ppr a $$ pprMultiline as

instance Outputable CSExpr where
    ppr (CSELit l) = hsep [text "return", ppr l, text ";"]
    ppr (CSEVar id) = hsep [text "return", pprWithUnique id, text ";"]
    ppr (CSECon name args) =
        hsep [text $ "return new "++name++"(", pprArgs args, text ");"]
    ppr (CSEApp id args) = 
        hsep [text "return StgApply.Apply(ctx,", pprWithUnique id, text ",", pprArgs args, text ");"]
    ppr (CSECall name []) = 
        hsep [text $ "return "++name++"(ctx);"]
    ppr (CSECall name args) = 
        hsep [text $ "return "++name++"(ctx,", pprArgs args, text ");"]
    ppr (CSEEval id ex) = 
        sep [
            hsep [ppr id, text "= StgEval.Eval(ctx, ", pprWithUnique id, text ");"],
            ppr ex
        ]
    ppr (CSEEvalThen id name []) =
        hsep [text "return StgEval.EvalThen(ctx,", pprWithUnique id, text $ ", StgCont.Make("++name++"));"] 
    ppr (CSEEvalThen id name free) =
        hsep [text "return StgEval.EvalThen(ctx,", pprWithUnique id, text $ ", StgCont.Make("++name++",", pprArgs (map CSRef free), text "));"] 
    ppr (CSELet id (CSELit l) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", ppr l, text ";"],
            ppr ex
        ]
    ppr (CSELet id (CSEVar id') ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", pprWithUnique id', text ";"],
            ppr ex
        ]
    ppr (CSELet id (CSECon name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= new "++name++"(", pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSEApp id' args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "= StgApply.Make(", pprWithUnique id', text ",", pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECall name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= "++name++"(", pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSEPrimOp op args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", ppr op, text "(", pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateFun name arity args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= Function"++(show arity)++".Make("++name++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateThunk name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= Updatable.Make("++name++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateClosure name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= SingleEntry.Make("++name++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSEUnpack name idx) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= "++name++".x"++show idx++";"],
            ppr ex
        ]
    ppr (CSELet id (CSECastAs id' name) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", pprWithUnique id', text $ "as "++name++";"],
            ppr ex
        ]
    --ppr (CSELetRec [(Id,CSExpr,[Id])] CSExpr) = 
    ppr (CSECase id alts) = 
        hsep [hang 
                (sep [text "switch (", pprWithUnique id, text ") {"])
                4
                (sep [pprMultiline alts, text "}"])]
    ppr (CSEPrimOp op args) = hsep [text "return", ppr op, text "(", pprArgs args, text ");"]
    ppr (CSEThrow id) = hsep [text "throw new Exception(",pprWithUnique id,text ");"]
    ppr (CSENotImplemented) = text "throw new NotImplementedException();"
    ppr (CSEImpossible) = text "throw new ImpossibleException();"

instance Outputable CSAlt where
    ppr (CSALit l ex) =
        hsep [hang 
                (sep [text "case", ppr l, text ": {"])
                4
                (sep [ppr ex, text "}"])]
    ppr (CSADefault ex) =
        hsep [hang 
                (text "default: {")
                4
                (sep [ppr ex, text "}"])]
    ppr (CSACon name varName ex) =
        hsep [hang 
                (text $ "case "++name++" "++varName++": {")
                4
                (sep [ppr ex, text "}"])]
