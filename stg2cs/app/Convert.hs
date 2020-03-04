{-# LANGUAGE ScopedTypeVariables, RankNTypes, FlexibleContexts #-}
module Convert (stg2cs) where

import Data.Char
import Data.List
import Control.Monad.Trans
import Control.Monad.State
import Control.Monad.Reader
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
import Unique
import Var
import Literal
import Name (nameStableString, nameOccName, mkInternalName, nameUnique)
import OccName (occNameFS, mkVarOcc)
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
data CSValue = CSCon Name [CSValue] | CSRef Id | CSLit Literal | CSNull

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
    -- | CSELetRec [(Id,CSExpr,[Id])] CSExpr !! Deprecated by CSEAssign
        -- recursive assign <Id> := <CSExpr'>
        -- where CSExpr' is CSExpr with <[Id]> replaced by null
        -- after all let assignments we need to feed them created values
        -- to do that when emitting nulls we need to remember their position
        -- because parameters are called xN
    | CSEAssign Id Index Id CSExpr 
        -- assign <Id₁>.x<Index> = <Id₂>; <CSExpr>
        -- used in conjecture with CSELet for recursive declarations
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
    | CSECastAs Name Id Name CSExpr -- cast expression onto type
        -- (var <Name> := <Id> as <Name>; <CSExpr>)
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

    uniqueSeed :: Int,

    dynFlags :: DynFlags
}

initState df = ST {
    entities = [],
    code = [],
    exports = [],

    callables = [],
    globals = [],

    lifted = Nothing,

    uniqueSeed = 0,

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
            modify (\s -> s { code = map (\(Method n t a e) -> Method n t a (simplify e)) (code s) })

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

makeMethods :: Id -> [Arg] -> StgExpr -> CSST [CSMethod]
makeMethods id args expr = do
    let retType = funRetType id args
    setLiftedFlag retType
    expr' <- renameLocalsM expr
    (e, ms) <- convertExpr id expr'
    name <- toName id
    return $ Method (name ++ "_Entry") retType args e : ms

{-
######################################
    STG Expression -> C# Expression
######################################
-}

convertExpr :: Id -> StgExpr -> CSST (CSExpr, [CSMethod])
convertExpr _ (StgLit l) = return (CSELit l, [])
convertExpr _ (StgApp fid args) = do
    if length args == 0 then
        return (CSEVar fid, [])
    else do
        let as = map convertArg args
        callableVars <- callables <$> get
        case lookup (varName fid) callableVars of
            Just methodName -> return (CSECall methodName as, [])
            Nothing -> return (CSEApp fid as, [])
convertExpr _ (StgConApp con args _) = do
    let as = map convertArg args
    name <- getConName con
    return (CSECon name as, [])
convertExpr _ (StgOpApp (StgPrimOp op) args _) = do
    let as = map convertArg args
    return (CSEPrimOp op as, [])
convertExpr _ (StgOpApp (StgPrimCallOp (PrimCall label _)) args _) = do
    name <- showWithFlags label
    let as = map convertArg args
    return (CSECall name as, [])

convertExpr id (StgCase (StgApp v []) _ _ alts) 
    | isVoidRep (idPrimRep v) -- state void# token
    , [(DEFAULT, _, rhs)] <- alts 
    = convertExpr id rhs 
convertExpr id (StgCase e alias _ alts) = do
    (csalts, free, ms) <- convertAlts alias id alts
    name <- toName id
    aliasName <- toName alias
    (caseExpr, _) <- convertExpr id e -- asumes simple expr
    let vt = idType alias
    case isUnliftedType vt of
        True -> do -- unlifted expressions are scrutinized on stack
                   -- rather than on the trampoline
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
                True -> do -- the function returns a lifted type (Closure)
                           -- we create a continuation for switch-expression
                           -- and bounce on the trampoline to evaluate
                           -- the scrutinee
                    let caseMethodName = name ++ "_Case_" ++ aliasName
                    let caseMethod = Method caseMethodName Closure (alias : free) (CSECase alias csalts)
                    let evalExpr = CSEEvalThen alias caseMethodName free
                    return (CSELet alias caseExpr evalExpr, caseMethod : ms)
                False -> do -- the function returns an unlifted value
                            -- so we cannot use the trampoline
                            -- instead we create a new trampoline on the stack
                            -- with StgEval.Eval(ctx, closure)
                    let evalExpr = CSEEval alias (CSECase alias csalts)
                    return (CSELet alias caseExpr evalExpr, ms)
convertExpr id' (StgLet (StgNonRec id (StgRhsCon _ dataCon args)) e) = do
    let as = map convertArg args
    name <- getConName dataCon
    let conExpr = CSECon name as
    (ex, ms) <- convertExpr id' e
    return (CSELet id conExpr ex, ms)
convertExpr id' (StgLet (StgNonRec id (StgRhsClosure _ _ occs flag bndrs e1)) ec) = do
    let t = typeToCSType (idType id)
    (e1x, ms2) <- withLifted (t == Closure) $ convertExpr id e1
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
                            [] -> withCallable id methodName (convertExpr id' ec)
                            _ -> convertExpr id' ec
                    _ -> convertExpr id' ec
    return (CSELet id assExpr ecx, method : ms2 ++ ms)
convertExpr id' (StgLet (StgRec bndrs) ec) = convertBndrs id' bndrs ec
convertExpr id (StgLetNoEscape binding ec) = convertExpr id (StgLet binding ec)
convertExpr _ _ = return (CSENotImplemented, [])

convertBndrs :: Id -> [(Id, StgRhs)] -> StgExpr -> CSST (CSExpr, [CSMethod])
convertBndrs id' bndrs ec = do
    let boundIds = map fst bndrs
        boundIdNames = map varName boundIds
        boundInOccs = map (findBound boundIdNames . snd) bndrs
        mappedBoundInOccs = zip boundIds boundInOccs
        callableLocals = concat $ map findCallable bndrs
    st <- get
    (idexs,ms) <- foldM (\(iexs,ms') rhs -> do {
          (id, ex, ms) <- convertRhs id' boundIdNames rhs
        ; return ((id, ex):iexs, ms++ms') }) ([],[]) bndrs
    mkAssignments id' ec callableLocals ms idexs mappedBoundInOccs
    where
        findBound :: [GHC.Name] -> StgRhs -> [(Id, Index)]
        findBound boundIds (StgRhsCon _ _ args) =
            let zipped = zip args [0..]
                refs = filter (\(a,_) -> isRefArg a) zipped
                named = map (\(StgVarArg id,idx) -> (id, idx)) refs
            in
            filter (\(id,idx) -> elem (varName id) boundIds) named
            where
                isRefArg (StgVarArg _) = True
                isRefArg             _ = False
        findBound boundIds (StgRhsClosure _ _ occs _ _ _) =
            filter (\(id,idx) -> elem (varName id) boundIds) $ zip occs [0..]
        
        findCallable :: (Id, StgRhs) -> [Id]
        findCallable (id, StgRhsClosure _ _ [] ReEntrant _ _) = [id]
        findCallable _ = []

        mkAssignments :: Id -> StgExpr -> [Id] -> [CSMethod] -> [(Id, CSExpr)] -> 
                        [(Id, [(Id, Index)])] -> CSST (CSExpr, [CSMethod])
        mkAssignments id_e ec callableLocals ms idexs mappedBoundInOccs = do
            (ecx, ms') <- foldr (\id -> withCallable id ((nameToStr $ varName id)++"_Entry"))
                            (convertExpr id_e ec) callableLocals
            let assExpr = foldr (\(id, l) e -> foldr (\(id',i) -> CSEAssign id i id') e l) ecx mappedBoundInOccs
            let letExpr = foldr (\(id,cse) -> CSELet id cse) assExpr idexs
            return (letExpr, ms'++ms)
convertRhs id' boundIds (id, StgRhsCon _ dataCon args) = do
    let as = map convertArg args
        as' = map (\a -> case a of {CSRef x -> if elem (varName x) boundIds then CSNull else a; _ -> a}) as
    name <- getConName dataCon
    let conExpr = CSECon name as'
    return (id, conExpr, [])
convertRhs id' boundIds (id, StgRhsClosure _ _ occs flag bndrs e1) = do
    let t = typeToCSType (idType id)
    (e1x, ms2) <- withLifted (t == Closure) $ convertExpr id e1
    name <- toName id
    let methodName = name++"_Entry"
    let retType = funRetType id bndrs -- TODO if fun is unlifted and has occs we would
                                      -- have to call it with occs and args - currently impossible
    let method = Method methodName retType (occs++bndrs) e1x
    let params = map (\i -> if elem (varName i) boundIds then CSNull else CSRef i) occs
    let assExpr = case flag of
                    ReEntrant -> CSECreateFun methodName (length bndrs) params
                    Updatable -> CSECreateThunk methodName params
                    SingleEntry -> CSECreateClosure methodName params
    return (id, assExpr, method : ms2)

withCallable :: Id -> Name -> CSST a -> CSST a
withCallable id name m = do
    addCallable id name
    x <- m
    popCallable
    return x

convertAlts :: Id -> Id -> [StgAlt] -> CSST ([CSAlt], [Id], [CSMethod])
convertAlts alias id alts = do
    (csalts, free, ms) <- convertAlts' alias id alts
    globalVars <- globals <$> get
    let freeWithoutGlobals = filter (\i -> notElem (varName i) globalVars) free
    case head csalts of
        CSADefault _ -> return (csalts, freeWithoutGlobals, ms)
        _ -> return (CSADefault CSEImpossible : csalts, freeWithoutGlobals, ms)
    where
        convertAlts' alias id [a] = do
            (a', f', m') <- convertAlt alias id a
            return ([a'], nubFreeVars f', m')
        convertAlts' alias id (a:as) = do
            (a', free, ms) <- convertAlt alias id a
            (as', free', ms') <- convertAlts' alias id as
            return (a':as', nubFreeVars (free ++ free'), ms ++ ms')

convertAlt :: Id -> Id -> StgAlt -> CSST (CSAlt, [Id], [CSMethod])
convertAlt _ id (DEFAULT, _, e) = do
    let free = exprFreeVars e
    (ex, ms) <- convertExpr id e
    return (CSADefault ex, free, ms)
convertAlt _ id (LitAlt l, _, e) = do
    let free = exprFreeVars e
    (ex, ms) <- convertExpr id e
    return (CSALit l ex, free, ms)
convertAlt alias id (DataAlt con, bndrs, e) = do
    let free = exprFreeVars e
    let boundUniques = map varName bndrs
    let nonBoundFree = filter (\i -> notElem (varName i) boundUniques) free
    (ex, ms) <- convertExpr id e
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
        CSExpr Simplifier
######################################
-}

simplify (CSECase id [CSADefault e]) = simplify e
simplify (CSECase id [CSADefault CSEImpossible, CSACon conName varName e]) =
    CSECastAs varName id conName (simplify e)
simplify (CSECase id alts) = CSECase id (map simplifyAlt alts)
    where
        simplifyAlt (CSADefault e) = CSADefault (simplify e)
        simplifyAlt (CSALit l e) = CSALit l (simplify e)
        simplifyAlt (CSACon n1 n2 e) = CSACon n1 n2 (simplify e)
simplify (CSEEval id e) = CSEEval id (simplify e)
simplify (CSELet id e1 ec) = CSELet id e1 (simplify ec) -- e1 is a simple expr
simplify (CSEAssign id idx id' e) = CSEAssign id idx id' (simplify e)
simplify e = e 

{-
######################################
  STG Expression local var renaming
######################################
-}

renameLocalsM e = do
    seed <- uniqueSeed <$> get
    let (e', seed') = renameLocals seed e
    modify (\s -> s { uniqueSeed = seed' })
    return e'

renameLocals :: Int -> StgExpr -> (StgExpr, Int)
renameLocals i e = runReader (runStateT (renameExpr e) i) []

renameExpr :: StgExpr -> StateT Int (Reader [(GHC.Name, Id)]) StgExpr
renameExpr (StgLit l) = return $ StgLit l
renameExpr (StgApp id args) = do
    id' <- renameId id
    args' <- renameArgs args
    return $ StgApp id' args'
renameExpr (StgConApp dataCon args type') = do
    args' <- renameArgs args
    return $ StgConApp dataCon args' type'
renameExpr (StgOpApp op args type') = do
    args' <- renameArgs args
    return $ StgOpApp op args' type'
renameExpr (StgCase e alias at alts) = do
    e' <- renameExpr e
    (alias', f) <- renamerAddId alias
    alts' <- local f $ mapM renameAlt alts
    return $ StgCase e' alias' at alts'
renameExpr (StgLet bnd expr) = do
    (bnd', f) <- renameBndr bnd
    expr' <- local f $ renameExpr expr
    return $ StgLet bnd' expr'
renameExpr (StgLetNoEscape bnd expr) = do
    (bnd', f) <- renameBndr bnd
    expr' <- local f $ renameExpr expr
    return $ StgLetNoEscape bnd' expr'

renameAlt (DEFAULT, bndrs, e) = do
    e' <- renameExpr e
    return (DEFAULT, bndrs, e')
renameAlt (LitAlt l, bndrs, e) = do
    e' <- renameExpr e
    return (LitAlt l, bndrs, e')
renameAlt (DataAlt con, bndrs, e) = do
    (bndrs', f) <- renamerAddIds bndrs
    e' <- local f $ renameExpr e
    return (DataAlt con, bndrs', e')

renameBndr (StgNonRec id rhs) = do
    (id', f) <- renamerAddId id
    rhs' <- renameRhs rhs
    return (StgNonRec id' rhs', f)
renameBndr (StgRec idrhss) = do
    let ids = map fst idrhss
    (ids', f) <- renamerAddIds ids
    idrhss' <- local f $ mapM renamePair idrhss
    return $ (StgRec idrhss', f)
    where
        renamePair :: (Id, StgRhs) -> StateT Int (Reader [(GHC.Name, Id)]) (Id, StgRhs)
        renamePair (id, rhs) = do
            id' <- renameId id
            rhs' <- renameRhs rhs
            return (id', rhs')

renameRhs (StgRhsCon cc con args) = do
    args' <- renameArgs args
    return $ StgRhsCon cc con args'
renameRhs (StgRhsClosure cc info occ flag args e) = do
    occ' <- mapM renameId occ
    (args', f) <- renamerAddIds args
    e' <- local f $ renameExpr e
    return $ StgRhsClosure cc info occ' flag args' e'

renameArgs args = mapM renameArg args
renameArg (StgLitArg l) = return $ StgLitArg l
renameArg (StgVarArg id) = do
    id' <- renameId id
    return $ StgVarArg id'

renameId id = do
    dict <- ask
    case lookup (varName id) dict of
        Nothing -> return id
        Just id' -> return id'

renamerAddIds ids = do
    newIdFs <- mapM renamerAddId ids
    let (ids', fs) = unzip newIdFs
    return (ids', foldl (.) id fs)

renamerAddId id = do
    i <- get
    let prevname = varName id
    let name = uniqueNameFromInteger i
    let unique = nameUnique prevname
    let occName = mkVarOcc name
    let ghcName = mkInternalName unique occName (nameSrcSpan prevname)
    let newVar = mkLocalVar (idDetails id) ghcName (varType id) (idInfo id)
    put (i+1)
    return (newVar, \dict -> (prevname, newVar) : dict)

uniqueNameFromInteger i =
    if i <= 25 then [chr (i+97), '_']
    else chr (97 + (i `mod` 25)) : uniqueNameFromInteger (i `div` 25)

{-
######################################
    STG Expression free variables
######################################
-}

exprFreeVars :: StgExpr -> [Id]
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

convertArg :: StgArg -> CSValue
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
    ppr (CSLit l) = pprLit l
    ppr CSNull = text "null"

pprLit (MachChar c) = text $ showLitChar c ""
pprLit (LitNumber LitNumInt64 i _) = text $ show i ++ "L"
pprLit (LitNumber LitNumWord64 i _) = text $ show i ++ "L"
pprLit (LitNumber LitNumWord i _) = text $ show i ++ "L"
pprLit (LitNumber _ i _) = text $ show i
pprLit (MachStr bs) = text $ show bs
pprLit MachNullAddr = text "null"
pprLit (MachFloat r) = text $ show r ++ "f"
pprLit (MachDouble r) = text $ show r
pprLit (MachLabel l _ _) = error $ "Can't emit label: "++show l

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

pprVarType a = ppr $ typeToCSType $ idType a

pprArgs [] = text ""
pprArgs [a] = ppr a
pprArgs (a:as) = hsep [ppr a, text ",", pprArgs as]

pprMultiline [a] = ppr a
pprMultiline (a:as) = ppr a $$ pprMultiline as

instance Outputable CSExpr where
    ppr (CSELit l) = hsep [text "return", pprLit l, text ";"]
    ppr (CSEVar id) = hsep [text "return", hcat [pprWithUnique id, text ".Eval(ctx)"], text ";"]
    ppr (CSECon name args) =
        hsep [text $ "return new "++name++"(", pprArgs args, text ").Eval(ctx);"]
    ppr (CSEApp id args) = 
        hsep [text "return StgApply.Apply(ctx,", pprWithUnique id, text ",", pprArgs args, text ");"]
    ppr (CSECall name []) = 
        hsep [text $ "return "++name++"(ctx);"]
    ppr (CSECall name args) = 
        hsep [text $ "return "++name++"(ctx,", pprArgs args, text ");"]
    ppr (CSEEval id ex) = 
        sep [
            hsep [pprWithUnique id, text "= ctx.Eval(", pprWithUnique id, text ");"],
            ppr ex
        ]
    ppr (CSEEvalThen id name []) =
        hsep [text "return ctx.Eval(", pprWithUnique id, text $ ", StgCont.Make(CLR.LoadFunctionPointer("++name++")));"] 
    ppr (CSEEvalThen id name free) =
        hsep [text "return ctx.Eval(", pprWithUnique id, text $ ", StgCont.Make(CLR.LoadFunctionPointer("++name++"),", pprArgs (map CSRef free), text "));"] 
    ppr (CSEAssign id idx id' ex) =
        sep [
            hsep [
                hcat [pprWithUnique id, text $".x" ++ show idx],
                text "=", pprWithUnique id', text ";"
            ],
            ppr ex
        ]
    ppr (CSELet id (CSELit l) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", pprLit l, text ";"],
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
            hsep [text "var", pprWithUnique id, text $ "= "++name++"(ctx,", pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSEPrimOp op args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text "=", pprOp op args, text ";"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateFun name arity args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= Function"++(show arity)++".Make(CLR.LoadFunctionPointer("++name++")"++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateThunk name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= Updatable.Make(CLR.LoadFunctionPointer("++name++")"++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSECreateClosure name args) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= SingleEntry.Make(CLR.LoadFunctionPointer("++name++")"++
                                                (case args of [] -> ""; _ -> ","), pprArgs args, text ");"],
            ppr ex
        ]
    ppr (CSELet id (CSEUnpack name idx) ex) =
        sep [
            hsep [text "var", pprWithUnique id, text $ "= "++name++".x"++show idx++";"],
            ppr ex
        ]
    ppr (CSECastAs varName id conName ex) =
        sep [
            hsep [text $ "var " ++ varName ++ " =", pprWithUnique id, text $ "as "++conName++";"],
            ppr ex
        ]
    ppr (CSECase id alts) = 
        hsep [hang 
                (sep [text "switch (", pprWithUnique id, text ") {"])
                4
                (sep [pprMultiline alts, text "}"])]
    ppr (CSEPrimOp op args) = hsep [text "return", pprOp op args, text ";"]
    ppr (CSEThrow id) = hsep [text "throw new Exception(",pprWithUnique id,text ");"]
    ppr (CSENotImplemented) = text "throw new NotImplementedException();"
    ppr (CSEImpossible) = text "throw new ImpossibleException();"

pprOp IntAddOp [a1, a2] = hsep [ppr a1, text "+", ppr a2]
pprOp IntSubOp [a1, a2] = hsep [ppr a1, text "-", ppr a2]
pprOp IntMulOp [a1, a2] = hsep [ppr a1, text "*", ppr a2]
pprOp IntLeOp [a1, a2] = hsep [text "(",ppr a1, text "<=", ppr a2, text ") ? 1 : 0"]
pprOp IntLtOp [a1, a2] = hsep [text "(",ppr a1, text "<", ppr a2, text ") ? 1 : 0"]
pprOp IntGeOp [a1, a2] = hsep [text "(",ppr a1, text ">=", ppr a2, text ") ? 1 : 0"]
pprOp IntGtOp [a1, a2] = hsep [text "(",ppr a1, text ">", ppr a2, text ") ? 1 : 0"]
pprOp op args = hsep [ppr op, text "(", pprArgs args, text ")"]

instance Outputable CSAlt where
    ppr (CSALit l ex) =
        hsep [hang 
                (sep [text "case", pprLit l, text ": {"])
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
