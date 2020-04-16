{-# LANGUAGE ScopedTypeVariables, RankNTypes, FlexibleContexts, BangPatterns #-}
module Convert (stg2cs) where

import Data.Char
import Data.List
import Data.List.Utils (replace)
import Data.Maybe (fromJust, isJust)
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
import Class (classMethods, classTyCon, classSCSelIds)
import Var
import Id
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
type Tag = Int
type Name = String
type Arg = Id

data CSType = Closure | Int32 | Int64 | Char | Boolean | Float | Double | String 
            | Class Name [CSType] | Tuple [CSType] | Generic
    deriving (Eq, Show)
data CSValue = CSCon Name [CSValue] | CSRef Id | CSLit Literal | CSNull

data CSDataCon = CSDataCon Name Tag [CSType]

data CSEntity = 
    CSTClosure [Id] CSExpr --TODO add proper types to ids, otherise they cannot get assigned || hack it
    | CSTConst Id CSValue
{-
    TODO rewrite all comments in this file to make it more readable (and correct)
    CSEntity is either a a closure instance or a data constant,
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
    | CSEApp Id [CSValue] CSType  -- assisted application
    | CSECall Name [CSValue] (Maybe CSType)    -- continue with another method
                               -- or call a foreign/system function
    | CSEAppAfterCall Name Id [CSValue] [CSValue] CSType
        -- call <Name> with first <[CSValue]> arguments and then apply
        -- result to the rest <[CSValue]>
        -- <Id> is closure id of <Name>, kept for type reasons
    | CSEEval Id CSExpr -- evaluate <Id> on the stack and continue with <CSExpr>
    | CSELet Id CSExpr CSExpr  -- assign <Id> := <CSExpr> and continue to evaluate <CSExpr₂>
    | CSELetByName Name CSExpr CSExpr  -- assign <Name> := <CSExpr> and continue to evaluate <CSExpr₂>
    | CSELetAssign Id CSExpr CSExpr  -- assign existing <Id> := <CSExpr> and continue to evaluate <CSExpr₂>
    | CSECase Id [CSAlt]  -- unpack an evaluated value
    | CSEAssign Id Index Id CSExpr 
        -- assign <Id₁>.x<Index> = <Id₂>; <CSExpr>
        -- used in conjecture with CSELet for recursive declarations
    | CSEPrimOp PrimOp [CSValue]  -- a primitive operation
        -- Note: it seems there's a lot of those
    | CSECreateFun CSMethod Arity [CSValue]
        -- create a generic Fun object 
        -- new Fun(N, ldftn <Name>, <[CSExpr]>)
        --
        -- if [CSValue] is [] the bound object should be marked
        -- as a direct call to <Name> and the method called directly
        -- when bound object appears in a CSEApp <Id> position
    | CSECreateThunk CSMethod [CSValue]
        -- creates a generic UpdatableK object (K is len [CSExpr])
        -- new UpdatableK(ldftn <Name>, <[CSExpr]>)
    | CSECreateClosure CSMethod [CSValue]
        -- creates a generic SingleEntryK object (K is len [CSExpr])
        -- new SingleEntryK(ldftn <Name>, <[CSExpr]>)
    | CSEUnpack Name Index  -- access data field <Name>.x<Index>
    | CSECastAs Name Id Name CSExpr -- cast expression onto type
        -- (var <Name> := <Id> as <Name>; <CSExpr>)
    | CSETag Id Id CSExpr -- get tag from <Id2>
        -- (var <Id> := <Id>.Tag; <CSExpr>)
    | CSEThrow Id  -- throw new Exception(<Id>) where Id points to a constant string
    | CSENotImplemented -- throw new NotImplementedException()
    | CSEImpossible -- throw new ImpossibleException()
    | CSENop -- don't do anything (used for the static constructor)

data CSAlt = 
    CSADefault CSExpr  -- default: {<CSExpr>}
    | CSALit Literal CSExpr -- e.g. case 1: {<CSExpr>}
    | CSACon Name Name CSExpr
        -- e.g. case Int a_Int: {
        --     var aa = a_Int.x0;
        --     <CSExpr w/ aa>   
        -- }

data SwitchType = Type | Tag -- case expressions with 5 or more alternatives
                             -- are converted to switches based on data constructor
                             -- integer tag value

{-
######################################
       State monad definition
######################################
-}

data CSState = ST {
    entities :: [CSEntity],
    code :: [CSMethod],
    namespace :: Maybe Name,
    className :: Maybe Name,
    types :: [CSDataCon],

    callables :: [(Name, (Arity, Name))], -- constant <Id> points to static function <Name>

    currentReturnType :: CSType,
    currentAssignType :: Maybe CSType,

    uniqueSeed :: Int,

    dynFlags :: DynFlags
}

initState df = ST {
    entities = [],
    code = [],
    namespace = Nothing,
    className = Nothing,
    types = [],

    callables = [],

    currentReturnType = Closure,
    currentAssignType = Nothing,

    uniqueSeed = 0,

    dynFlags = df
}

type CSST a = State CSState a 

{-
######################################
       Module entry point
######################################
-}

stg2cs :: DynFlags -> Name -> [StgTopBinding] -> [TyCon] -> String
stg2cs df modName stg tyCons = evalState (go >> prettyPrint) $ initState df
    where
        go = do
            setupNamespaceAndClassName modName
            mapM_ processTyCon tyCons
            mapM_ gatherCallables stg
            mapM_ processTop stg --TODO sort bindings to first handle closures and thunks (static init order)
            convertStaticLetExpressions
            simplifyExpressions
        simplifyExpressions = modify (\s -> s { code = map (\(Method n t a e) -> Method n t a (simplify e)) (code s) })
        convertStaticLetExpressions = modify (\s -> s { entities = map convLetToLetAssign (entities s) })
            where
                convLetToLetAssign (CSTClosure ids expr) = CSTClosure ids $ convlla expr
                convLetToLetAssign c = c
                convlla (CSELet id e1 e2) = CSELetAssign id e1 (convlla e2)
                convlla (CSEAssign id1 idx id2 e) = CSEAssign id1 idx id2 (convlla e)
                convlla CSENop = CSENop
                -- ^ there should not be anything else


prettyPrint = do
    st <- get
    showWithFlags st

setupNamespaceAndClassName modName = do
    let nameParts = splitList '.' modName
        m_namespace = if length nameParts == 1 then Nothing else Just $ intercalate "." (init nameParts)
        m_className = Just $ last nameParts
    modify (\s -> s { namespace = m_namespace, className = m_className})

gatherCallables :: StgTopBinding -> CSST ()
gatherCallables (StgTopLifted (StgNonRec id (StgRhsClosure _ _ _ flag bndrs _))) = do
    case flag of
        ReEntrant -> do
            addCallable (safeVarName WithModule id) (length bndrs) (safeVarName WithoutModule id ++ "_Entry")
        _ -> return ()
gatherCallables (StgTopLifted (StgRec bndrs)) = mapM_ processAsNonRec bndrs
    where
        processAsNonRec (id, rhs) = gatherCallables (StgTopLifted (StgNonRec id rhs))
gatherCallables _ = return ()

processTop :: StgTopBinding -> CSST ()
processTop (StgTopStringLit id bstr) = do
    addConst id $ CSLit (MachStr bstr)
processTop (StgTopLifted (StgNonRec id rhs)) =
    processTop (StgTopLifted (StgRec [(id,rhs)]))
processTop (StgTopLifted (StgRec bndrs)) = do
    let bndrs' = filterUnwantedDecls bndrs
    case bndrs' of
        [] -> return ()
        _ -> do
            let ids = map fst bndrs'
            (ex, ms) <- convertBndrs bndrs' (StgApp (copyNameToNewVar (head ids) "_$nop$_") [])
            addMethods ms
            if isGenericMethod bndrs then
                return () -- don't instantiate levity polymorphic functions
            else
                addEntities [CSTClosure ids ex]
    where
        filterUnwantedDecls = filter (not . isUnwanted)
        isUnwanted (id, StgRhsCon _ dataCon args) = 
            let conType = dataConOrigResTy dataCon
                typeName = debugPrintType conType
                argTypeNames = map (debugPrintType . idType) $ mapf isArgId extrArgId args
            in any (`elem` ghcInformationTypes) (typeName : argTypeNames)
        isUnwanted _ = False
        extrArgId (StgVarArg id) = id
        isArgId (StgVarArg id) = True
        isArgId _ = False
        isGenericMethod [(id,StgRhsClosure _ _ _ _ bndrs _)] = funRetType id bndrs == Generic
        isGenericMethod _ = False

mapf p f [] = []
mapf p f (x:xs) = if p x then f x : mapf p f xs else mapf p f xs

ghcInformationTypes = [
    "GHC.Types.TrName",
    "GHC.Types.KindRep",
    "GHC.Types.TyCon",
    "GHC.Types.TypeLitSort",
    "GHC.Types.VecElem",
    "GHC.Types.VecCount",
    "GHC.Types.Module"
    ]

processTyCon tyCon = do
    if isDataTyCon tyCon then
        mapM_ processDataCon (tyConDataCons tyCon)
    else return ()
    case tyConClass_maybe tyCon of
        Just cls -> processClass cls
        Nothing -> return ()
processDataCon dataCon =
    let (_,_,args,_) = dataConSig dataCon 
        repArgs = filter isRepresentable args
    in modify (\s -> s { types = (CSDataCon (safeConName WithoutModule dataCon) (dataConTag dataCon) (map typeToCSType repArgs)) : types s})
    where
        isRepresentable = not . isState -- a hack for now

processClass cls = do
    let superSelectors = classSCSelIds cls :: [Id]
        methods = classMethods cls :: [Id]
    -- we get a list of ids
    -- each id has a type -> we need arity information
    -- from the index in the list we'll know wich
    -- dictionary entry to extract
        indexedMethods = zipWith makeMethodInfo [0..] (superSelectors ++ methods)
        (ents, ms) = unzip indexedMethods
    -- mapM_ (\id -> do {w <- showWithFlags (idType id); n <- showWithFlags id; trace (n++" "++w) return ()}) methods
    -- ^ print method types
    addMethods ms
    addEntities ents
    where
        makeMethodInfo :: Index -> Id -> (CSEntity, CSMethod)
        -- creates a selector function that retrieves a concrete function from a dict
        makeMethodInfo idx id =
            let arity  = funArity id
                name   = safeVarName WithoutModule id
                ty     = idType id
                did    = copyNameToNewVar id "a0"
                fid    = copyNameToNewVar id "dictItem"
                        -- we don't really care about their types, it's all closures
                expr   = CSECastAs "dict" did dictDataConName 
                            (CSELet fid (CSEUnpack "dict" idx)
                                (CSEVar fid))
                method = Method (name++"_Entry") (funRetType' 1 ty) [did] expr
                staticLet = CSELet id (CSECreateFun method arity []) CSENop
            in (CSTClosure [id] staticLet, method)
        [dictDataCon] = tyConDataCons $ classTyCon cls
        dictDataConName = safeConName WithModule dictDataCon
{-
######################################
    STG Expression -> C# Expression
######################################
-}

convertExpr :: StgExpr -> CSST (CSExpr, [CSMethod])
convertExpr (StgLit l) = return (CSELit l, [])
convertExpr (StgApp id []) -- special case representing nop for top level binding expressions
    | "_$nop$_" == nameToStr (varName id) = 
        return (CSENop, [])
convertExpr (StgApp fid args) = do
    let arglen = length args
    if arglen == 0 then
        return (CSEVar fid, [])
    else do
        let as = map convertArg args
        rt <- currentReturnType <$> get
        at <- currentAssignType <$> get
        let applicationResultType =
                case at of
                    Nothing -> rt
                    Just t -> t
        m_method <- isCallable fid
        case m_method of
            Just (arity, methodName) ->
                if arity == arglen then
                    let frt = funRetType' arity (idType fid)
                        genParam = if frt == Generic then Just applicationResultType else Nothing
                    in return (CSECall methodName as genParam, [])
                else if arity > arglen then
                    return (CSEApp fid as applicationResultType, [])
                else -- arity < arglen --TODO verify this is correct
                    return (CSEAppAfterCall methodName fid (take arity as) (drop arity as) applicationResultType, [])
            Nothing -> return (CSEApp fid as applicationResultType, [])
convertExpr (StgConApp con args _) = do
    let as = map convertArg args
    let name = safeConName WithModule con
    case args of
        [] -> return (CSEVar (dataConWrapId con), [])
        _ -> return (CSECon name as, [])
convertExpr (StgOpApp (StgPrimOp op) args _) = do
    let as = map convertArg args
    return (CSEPrimOp op as, [])
convertExpr (StgOpApp (StgPrimCallOp (PrimCall label _)) args _) = do
    name <- showWithFlags label
    let as = map convertArg args
    return (CSECall name as Nothing, [])

convertExpr (StgCase (StgApp v []) _ _ alts) 
    | isVoidRep (idPrimRep v) -- state void# token
    , [(DEFAULT, _, rhs)] <- alts 
    = convertExpr rhs 
convertExpr (StgCase e alias _ alts) = do
    (csalts, st, ms) <- convertAlts alias alts
    let aliasName = safeVarName WithoutModule alias
    let vt = idType alias
    (caseExpr, _) <- withAssignType (typeToCSType vt) $ convertExpr e -- asumes simple expr
    let actualType = if isUnitHash vt then innerUnitHashType vt else vt
    case isUnliftedTypeSafe actualType of
        Unlifted -> do
            return (CSELet alias caseExpr (CSECase alias csalts), ms)
        Lifted -> do
            case st of
                Type -> do
                    let evalExpr = CSEEval alias (CSECase alias csalts)
                    return (CSELet alias caseExpr evalExpr, ms)
                Tag -> do
                    let aliasTag = copyNameToNewVar alias (aliasName ++ "Tag")
                    let tagExpr = CSETag aliasTag alias (CSECase aliasTag csalts)
                    let evalExpr = CSEEval alias tagExpr
                    return (CSELet alias caseExpr evalExpr, ms)
convertExpr (StgLet (StgNonRec id rhs) ec) = convertExpr (StgLet (StgRec [(id,rhs)]) ec)
convertExpr (StgLet (StgRec bndrs) ec)  = convertBndrs bndrs ec
convertExpr (StgLetNoEscape binding ec) = convertExpr (StgLet binding ec) -- should I try to optimize this?
convertExpr _ = return (CSENotImplemented, [])

convertBndrs :: [(Id, StgRhs)] -> StgExpr -> CSST (CSExpr, [CSMethod])
convertBndrs bndrs ec = do
    let boundIds = map fst bndrs
        boundIdNames = map varName boundIds
        boundInOccs = map (findBound boundIdNames . snd) bndrs
        mappedBoundInOccs = zip boundIds boundInOccs
        callableLocals = concat $ map findCallable bndrs
    st <- get
    (idexs,ms) <- foldM (\(iexs,ms') rhs -> do {
          (id, ex, ms) <- convertRhs boundIdNames rhs
        ; return ((id, ex):iexs, ms++ms') }) ([],[]) bndrs
    mkAssignments ec callableLocals ms idexs mappedBoundInOccs
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
        
        findCallable :: (Id, StgRhs) -> [(Id,Arity)]
        findCallable (id, StgRhsClosure _ _ [] ReEntrant bndrs _) = [(id, length bndrs)]
        findCallable _ = []

        mkAssignments :: StgExpr -> [(Id,Arity)] -> [CSMethod] -> [(Id, CSExpr)] -> 
                        [(Id, [(Id, Index)])] -> CSST (CSExpr, [CSMethod])
        mkAssignments ec callableLocals ms idexs mappedBoundInOccs = do
            (ecx, ms') <- foldr (\(id,ar) -> withCallable id ar ((safeVarName WithModule id)++"_Entry"))
                            (convertExpr ec) callableLocals
            let assExpr = foldr (\(id, l) e -> foldr (\(id',i) -> CSEAssign id i id') e l) ecx mappedBoundInOccs
            let letExpr = foldr (\(id,cse) -> CSELet id cse) assExpr idexs
            return (letExpr, ms'++ms)
convertRhs boundIds (id, StgRhsCon _ dataCon args) = do
    let as = map convertArg args
        as' = map (\a -> case a of {CSRef x -> if elem (varName x) boundIds then CSNull else a; _ -> a}) as
    let name = safeConName WithModule dataCon
    let conExpr = CSECon name as'
    return (id, conExpr, [])
convertRhs boundIds (id, StgRhsClosure _ _ occs flag bndrs e1) = do
    let retType = funRetType id bndrs
    (e1x, ms2) <- withRetType retType $ convertExpr e1
    let name = safeVarName WithoutModule id
    let methodName = name++"_Entry"
    let method = Method methodName retType (occs++bndrs) e1x
    let params = map (\i -> if elem (varName i) boundIds then CSNull else CSRef i) occs 
    let assExpr = case flag of
                    ReEntrant -> CSECreateFun method (length bndrs) params
                    Updatable -> CSECreateThunk method params
                    SingleEntry -> CSECreateClosure method params
    return (id, assExpr, method : ms2)

withCallable :: Id -> Arity -> Name -> CSST a -> CSST a
withCallable id arity name m = do
    addCallable (safeVarName WithModule id) arity name
    x <- m
    popCallable
    return x

convertAlts :: Id -> [StgAlt] -> CSST ([CSAlt], SwitchType, [CSMethod])
convertAlts alias alts = do
    (csalts, ms) <- convertAlts' alias alts
    case head csalts of
        CSADefault _ -> return (csalts, st, ms)
        _ -> return (CSADefault CSEImpossible : csalts, st, ms)
    where
        convertAlts' alias [a] = do
            (a', m') <- convertAlt alias st a
            return ([a'], m')
        convertAlts' alias (a:as) = do
            (a', ms) <- convertAlt alias st a
            (as', ms') <- convertAlts' alias as
            return (a':as', ms ++ ms')
        st = if length alts >= 5 || isEnumType (idType alias) then Tag else Type

convertAlt :: Id -> SwitchType -> StgAlt -> CSST (CSAlt, [CSMethod])
convertAlt _ _ (DEFAULT, _, e) = do
    (ex, ms) <- convertExpr e
    return (CSADefault ex, ms)
convertAlt _ _ (LitAlt l, _, e) = do
    (ex, ms) <- convertExpr e
    return (CSALit l ex, ms)
convertAlt alias st (DataAlt con, bndrs, e) = do
    (ex, ms) <- convertExpr e
    let conName = safeConName WithoutModule con
    let qualifiedConName = safeConName WithModule con
    let aliasName = safeVarName WithoutModule alias
    let varName = aliasName ++ "_" ++ conName
    let boundExpr = makeBoundExpr varName ex 0 bndrs
    case st of
        Type ->
            if isUnitHash (idType alias) then do
                let [inside] = bndrs
                return (CSADefault (CSELet inside (CSEVar alias) ex), ms)
            else
                return (CSACon qualifiedConName varName boundExpr, ms) 
        Tag -> do
            tagLit <- mkInt (fromIntegral $ dataConTag con)
            let castBoundExpr = CSECastAs varName alias qualifiedConName boundExpr
            return (CSALit tagLit castBoundExpr, ms)
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
simplify (CSECase id [CSADefault CSEImpossible, CSACon conName varName e]) 
    | typeToCSType (idType id) /= Closure = -- this is for unboxed tuples
    CSELetByName varName (CSEVar id) (simplify e)
simplify (CSECase id [CSADefault CSEImpossible, CSACon conName varName e]) =
    CSECastAs varName id conName (simplify e)
simplify (CSECase id alts) = CSECase id (map simplifyAlt alts)
    where
        simplifyAlt (CSADefault e) = CSADefault (simplify e)
        simplifyAlt (CSALit l e) = CSALit l (simplify e)
        simplifyAlt (CSACon n1 n2 e) = CSACon n1 n2 (simplify e)
simplify (CSEEval id e) = CSEEval id (simplify e)
simplify (CSELet id (CSEApp m args rt) (CSEEval id' e)) | id == id' = CSELet id (CSEApp m args rt) (simplify e)
simplify (CSELet id (CSECall m args mrt) (CSEEval id' e)) | id == id' = CSELet id (CSECall m args mrt) (simplify e)
simplify (CSELet id e1 ec) = CSELet id e1 (simplify ec) -- e1 is a simple expr
simplify (CSELetByName name e1 ec) = CSELetByName name e1 (simplify ec) -- e1 is a simple expr
simplify (CSEAssign id idx id' e) = CSEAssign id idx id' (simplify e)
simplify (CSECastAs name id name' e) = CSECastAs name id name' (simplify e)
simplify (CSETag id id' e) = CSETag id id' (simplify e)
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
    let name = uniqueNameFromInteger i
    let prevname = varName id
    let newVar = copyNameToNewVar id name
    put (i+1)
    return (newVar, \dict -> (prevname, newVar) : dict)

copyNameToNewVar id name =
    let prevname = varName id
        unique = nameUnique prevname
        occName = mkVarOcc name
        ghcName = mkInternalName unique occName (nameSrcSpan prevname)
        newVar = mkLocalVar (idDetails id) ghcName (varType id) (idInfo id)
    in newVar

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
addEntities es = modify (\s -> s { entities = es ++ entities s})
addMethods ms = modify (\s -> s { code = ms ++ code s})
addCallable n arity name = modify (\s -> s { callables = (n,(arity,name)) : callables s})
popCallable = modify (\s -> s { callables = tail $ callables s})

withRetType t m = do
    rt <- currentReturnType <$> get
    modify (\s -> s { currentReturnType = t})
    x <- m
    modify (\s -> s { currentReturnType = rt})
    return x

withAssignType t m = do
    rt <- currentAssignType <$> get
    modify (\s -> s { currentAssignType = Just t})
    x <- m
    modify (\s -> s { currentAssignType = rt})
    return x

isCallable id = do
    callableVars <- callables <$> get
    case lookup (safeVarName WithModule id) callableVars of
        Nothing -> do
            let classOp = (isJust $ isClassOpId_maybe id)
            if isGlobalId id || isExportedId id || isImplicitId id ||
                classOp then
                let arity = if classOp || isRecordSelector id then
                                1 -- call do select function from dict
                                  -- and use polimorphic Apply on that to deal with levity
                            else funArity id in
                return $ Just (arity, safeVarName WithModule id ++ "_Entry")
            else return Nothing
        just -> return just

data ConOrVar = SNCon | SNVar
data WithModule = WithModule | WithoutModule

safeVarName w id = safeName SNVar w (varName id) (Just id)
safeConName w dataCon = safeName SNCon w (dataConName dataCon) Nothing

safeName :: ConOrVar -> WithModule -> GHC.Name -> Maybe Id -> String
safeName c w idName mId =
    let modName =
            if isExternalName idName then
                (moduleNameString $ moduleName $ nameModule $ idName) ++ "."
            else ""
        n = nameToStr idName
        isSpecialName = n /= "$" && head n == '$' && (isAlpha (head (tail n)) || head (tail n) == '_')
        name = 
            if justTrue (isDFunId <$> mId) || justTrue (isRecordSelector <$> mId) ||
                (isJust $ isClassOpId_maybe =<< mId) then
                if isSpecialName then tail n else n
            else if isSpecialName then
                tail n ++ (show $ varUnique $ fromJust mId)
            else if not (isExternalName idName) then
                n ++ (show $ varUnique $ fromJust mId)
            else n
        safeOpName = 
            case name of
                "(#,#)" -> "RawTuple"
                "(#,,#)" -> "RawTuple"
                "(#,,,#)" -> "RawTuple"
                "(#,,,,#)" -> "RawTuple"
                "(,)" -> "Tuple2"
                "(,,)" -> "Tuple3"
                "(,,,)" -> "Tuple4"
                "(,,,,)" -> "Tuple5"
                ":" -> "Cons"
                "[]" -> "Nil"
                "()" -> "Unit"
                _ -> escapeCSKeywords $ translateOpString name
        safeOpNameWithConInfo = 
            if isJust (mId >>= isDataConId_maybe) then
                safeOpName ++ "_DataCon"
            else safeOpName
        (nameHead : nameTail) = safeOpNameWithConInfo
        casedSafeName = case c of
                            SNVar -> (toLower nameHead) : nameTail
                            SNCon -> (toUpper nameHead) : nameTail
    in case w of
        WithModule -> modName ++ casedSafeName
        WithoutModule -> casedSafeName

translateOpString n = (n >>= trOp)
    where
        trOp ':' = "Col"
        trOp '<' = "Lt"
        trOp '>' = "Gt"
        trOp '=' = "Eq"
        trOp '~' = "Tild"
        trOp '!' = "Bang"
        trOp '[' = "BrO"
        trOp ']' = "BrC"
        trOp '(' = "PrO"
        trOp ')' = "PrC"
        trOp '?' = "QMark"
        trOp '.' = "Dot"
        trOp ',' = "Com"
        trOp '$' = "Doll"
        trOp '*' = "Astr"
        trOp '#' = "Hash"
        trOp '+' = "Plus"
        trOp '-' = "Dash"
        trOp '/' = "Slsh"
        trOp '\\' = "Blsh"
        trOp '&' = "Amp"
        trOp '|' = "Pipe"
        trOp '_' = "_"
        trOp '\'' = "_"
        trOp x | isAlphaNum x  = [x]
        trOp x = error $ "trOp unmatched '"++[x]++"' in string '"++n++"'"

escapeCSKeywords n = if n `elem` keywords then '@' : n else n
    where
        keywords = ["abstract", "as", "base", "bool", 
            "break", "byte", "case", "catch", 
            "char", "checked", "class", "const", 
            "continue", "decimal", "default", "delegate", 
            "do", "double", "else", "enum", 
            "event", "explicit", "extern", "false", 
            "finally", "fixed", "float", "for", 
            "foreach", "goto", "if", "implicit", 
            "in", "int", "interface", "internal", 
            "is", "lock", "long", "namespace", 
            "new", "null", "object", "operator", 
            "out", "override", "params", "private", 
            "protected", "public", "readonly", "ref", 
            "return", "sbyte", "sealed", "short", 
            "sizeof", "stackalloc", "static", "string", 
            "struct", "switch", "this", "throw", 
            "true", "try", "typeof", "uint", 
            "ulong", "unchecked", "unsafe", "ushort", 
            "using", "using", "static", "virtual", "void",
            "volatile", "while"
            ]

justTrue (Just True) = True
justTrue _ = False

showWithFlags x = do
    df <- getFlags
    return $ showPpr df x

mkInt i = do
    df <- getFlags
    return $ mkMachInt df i

litType (MachChar _) = Char
litType (LitNumber _ _ _) = Int64
litType (MachStr bs) = String
litType (MachFloat r) = Float
litType (MachDouble r) = Double
litType _ = error "unsupported literal"

valueType (CSCon name _ ) = Class name []
valueType (CSRef i) = typeToCSType (idType i)
valueType (CSLit l) = litType l
valueType CSNull = Closure

funRetType id args = funRetType' (length args) (idType id)
funRetType' 0 t = typeToCSType t
funRetType' n (FunTy t1 t2) = funRetType' (n-1) t2
funRetType' n (AppTy (AppTy ft t1) t2) = funRetType' (n-1) t2
funRetType' n (ForAllTy _ t) = funRetType' n t
funRetType' _ _ = Closure

funArity id = funArity' (idType id) 0
    where
        funArity' (FunTy t1 t2) !n = funArity' t2 (n+1)
        funArity' (AppTy (AppTy ft t1) t2) !n = funArity' t2 (n+1)
        funArity' (ForAllTy _ (FunTy _ t)) !n = funArity' t n
        funArity' (CastTy t _) !n = funArity' t n
        funArity' _ !n = n --TODO check if something's missing here

isEnumType t =
    case tyConAppTyCon_maybe t of
        Nothing -> False
        Just tc ->
            let dataCons = tyConDataCons tc
                isEnum = all hasNoParams dataCons
            in isEnum
            where
                hasNoParams dc =
                    let (_,_,args,_) = dataConSig dc in
                    case args of
                        [] -> True
                        _  -> False

isUnitHash (TyConApp tc [r1,r2,st,_]) = 
    let tcName = nameToStr $ tyConName tc
        stName = debugPrintType st
    in (tcName == "(#,#)" && stName == "GHC.Prim.StateHash")
isUnitHash _ = False
innerUnitHashType (TyConApp _ [_,_,_,t]) = t

debugPrintType (FunTy t1 t2) = "("++debugPrintType t1++" -> "++debugPrintType t2++")"
debugPrintType (AppTy t1 t2) = "(AppTy "++debugPrintType t1++" "++debugPrintType t2++")"
debugPrintType (ForAllTy b t) = "(forall "++nameToStr (varName $ binderVar b)++". "++debugPrintType t++")"
debugPrintType (TyConApp tc _) = safeName SNCon WithModule (tyConName tc) Nothing
debugPrintType (TyVarTy v) = nameToStr (varName v)
debugPrintType (LitTy (NumTyLit i)) = show i
debugPrintType (LitTy (StrTyLit fs)) = show $ unpackFS fs
debugPrintType (CastTy t _) = "(Cast "++debugPrintType t++")"
debugPrintType _ = "τ" -- Coercion

data Levity = Lifted | Unlifted | LevityPolimorphic

isUnliftedTypeSafe t =
    case isLiftedType_maybe t of
        Just True -> Lifted
        Just False -> Unlifted
        Nothing -> LevityPolimorphic

typeToCSType t =
    case isUnliftedTypeSafe t of
        Unlifted -> unliftedTypeToCSType t
        Lifted -> Closure
        LevityPolimorphic -> Generic
unliftedTypeToCSType t =
            case t of
                TyConApp tc tyArgs -> 
                    let name = tyConName tc in
                    case nameToStr name of
                        "Int#" -> Int64
                        "Word#" -> Int64
                        "Char#" -> Char
                        "Double#" -> Double
                        "Int64#" -> Int64
                        "(#,#)" -> tup 2 tyArgs
                        "(#,,#)" -> tup 3 tyArgs
                        "(#,,,#)" -> tup 4 tyArgs
                        "(#,,,,#)" -> tup 5 tyArgs
                        "Void#" -> Class "GHC.Prim.Void" []
                        "State#" -> Class "GHC.Prim.StateHash" []
                        "Addr#" -> Class "System.IntPtr" []
                        strName -> Class (strName ++ "_UnImplemented") []
    where
        tup n tyArgs = 
            let tupParams = drop n tyArgs
                -- skip the first n arguments which describe layout
                -- of the unlifted tuple (eg. TupleRep, UnliftedRep)
                withoutState = if isState (head tupParams) then
                                    tail tupParams
                               else tupParams
                                -- ^ skip State# as it has no representation
            in if length withoutState > 1 then
                Tuple (map typeToCSType withoutState)
               else typeToCSType $ head withoutState
isState t = case t of
                TyConApp tc tyArgs -> 
                    let name = tyConName tc in
                    case nameToStr name of
                        "State#" -> True
                        _ -> False
                _ -> False

nameToStr name =
    let occ = nameOccName name
        fs = occNameFS occ
        strName = unpackFS fs in
    strName

split :: (a -> Bool) -> [a] -> ([a], [a])
split f s = (left,right)
        where
        (left,right')=break f s
        right = if null right' then [] else tail right'

splitList :: Eq a => a -> [a] -> [[a]]
splitList _   [] = []
splitList sep list = h:splitList sep t
        where (h,t)=split (==sep) list

{-
######################################
          C# pretty printing
######################################
-}

instance Outputable CSState where
    ppr (ST { entities = es, code = cs, namespace = m_ns, className = (Just name), types = tds}) =
        sep [text "using Lazer.Runtime;\n",
            (case m_ns of
                Just namespace -> hang (text $ "namespace " ++ namespace ++ " {") 4 (sep [pprMod, text "}"])
                Nothing -> pprMod
            )]
        where
            pprMod = 
                hang (text $ "public unsafe static class "++name++" {") 4 
                  (sep [pprMultiline es, pprStatic, pprMultiline cs, pprMultiline tds, text "}"])
            pprStatic =
                hang (text $ "static "++name++"() {") 4
                    (sep [pprMultiline (mapf isCstClosure extClosureExpr es), text "}"])
            extClosureExpr (CSTClosure _ e) = e
            isCstClosure (CSTClosure _ _) = True
            isCstClosure _ = False

instance Outputable CSDataCon where
    ppr (CSDataCon name tag ts) =
        hang (text $ "public sealed class "++name++" : Data {") 4
            (sep [pprFieldDecls 0 ts, pprCtor name ts, pprTagProp tag, text "}"])
        where
            pprFieldDecls _ [] = text ""
            pprFieldDecls i (t:ts) = sep [ hsep [text "public", ppr t, text $ "x"++(show i)++";"], pprFieldDecls (i+1) ts]

            pprCtor name ts = hang (hsep [text $ "public "++name++"(", pprCtorArgs 0 ts, text ") {"]) 4
                                (sep [pprCtorBody 0 ts, text "}"])
            pprCtorArgs _ [] = text ""
            pprCtorArgs i [t] = hsep [ppr t, text $ "x"++(show i)]
            pprCtorArgs i (t:ts) = hsep [ppr t, text $ "x"++(show i)++", ", pprCtorArgs (i+1) ts]
            pprCtorBody _ [] = text ""
            pprCtorBody i (_:ts) = sep [text $ "this.x"++(show i)++" = x"++(show i)++";", pprCtorBody (i+1) ts]

            pprTagProp tag = text $ "public override int Tag => "++(show tag) ++";"


instance Outputable CSEntity where
    ppr (CSTConst id val) =
        hsep [visibilityModifier id, text "static", ppr (valueType val), pprSafeName id, text "=", ppr val, text ";"]
    ppr (CSTClosure ids _) = pprDecl ids
        where
            pprDeclSingle id =
                hsep [visibilityModifier id, text "static Closure", pprSafeName id ,text ";"]
            pprDecl [] = text ""
            pprDecl (id:ids) = pprDeclSingle id $$ pprDecl ids

pprSafeName id = text $ safeVarName WithoutModule id
pprSafeQualifiedName id = text $ safeVarName WithModule id

visibilityModifier id = if isExternalName (varName id) then text "public" else text "internal"

instance Outputable CSType where
    ppr Closure = text "Closure"
    ppr Int32 = text "int"
    ppr Int64 = text "long"
    ppr Float = text "float"
    ppr Double = text "double"
    ppr Char = text "char"
    ppr String = text "string"
    ppr Generic = text "GenericR"
    ppr (Class n []) = text n
    ppr (Class n args) = hcat $ [text n, text "<", pprArgs args, text ">"]
    ppr (Tuple args) = hcat [text "(", pprTupleArgs 0 args, text ")"]
        where
            pprTupleArgs i [a] = hsep [ppr a, text $ "x"++(show i)]
            pprTupleArgs i (a:as) = hsep [ppr a, text $ "x"++(show i), text ",", pprTupleArgs (i+1) as]

instance Outputable CSValue where
    ppr (CSCon name args) =
        hsep [text $ "new "++name++"(", pprArgs args, text ")"]
    ppr (CSRef id) = pprSafeQualifiedName id
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
                (hsep [text "public static", ppr typ, text $ name ++ genericDecl ++ "(", pprArguments args, text ") {"])
                4
                (sep [ppr ex, text "}"])]
        where
            genericDecl = if typ == Generic then "<GenericR>" else ""

pprArguments :: [Id] -> SDoc
pprArguments [] = text ""
pprArguments [a] = hsep [pprVarType a, pprSafeName a]
pprArguments (a:as) = hsep [pprVarType a, pprSafeName a, text ",", pprArguments as]

pprVarType a = ppr $ typeToCSType $ idType a

pprArgs [] = text ""
pprArgs [a] = ppr a
pprArgs (a:as) = hsep [ppr a, text ",", pprArgs as]

pprMultiline [a] = ppr a
pprMultiline (a:as) = ppr a $$ pprMultiline as

appGenArgs rt args =
    let types = map valueType args in
    hsep [text "<", pprArgs types, text ",", ppr rt, text ">"]

callAppGenArgs rt cargs appargs =
    let types = map valueType appargs in
    hsep [text "<", pprArgs types, text ",", ppr rt, text ">"]    

pprGenArgs []   = text ""
pprGenArgs args =
    let types = map valueType args in
    hsep [text "<", pprArgs types, text ">"]

pprGenIdsWithRet ret args =
    let types = map (typeToCSType . idType) args ++ [ret] in
    hsep [text "<", pprArgs types, text ">"]

instance Outputable CSExpr where
    ppr (CSENop) = text ""
    ppr (CSELit l) = hsep [text "return", pprLit l, text ";"]
    ppr (CSEVar id)
        | (typeToCSType (idType id)) /= Closure 
            = hsep [text "return", pprSafeQualifiedName id, text ";"]
        | otherwise
            = hcat [text "return ", pprSafeQualifiedName id, text ".Eval();"]
    ppr (CSECon "GHC.Prim.RawTuple" args) =
        hsep [text "return (", pprArgs args, text ");"]
    ppr (CSECon "GHC.Prim.UnitHash" [arg]) =
        hsep [text "return", ppr arg, text ";"]
    ppr (CSECon name args) =
        hsep [text $ "return new "++name++"(", pprArgs args, text ");"]
    ppr (CSEApp id args rt) = 
        hsep [hcat [text "return ", pprSafeQualifiedName id, text ".Apply", appGenArgs rt args, text "("], pprArgs args, text ");"]
    ppr (CSECall name args Nothing) = 
        hsep [text $ "return "++name++"(", pprArgs args, text ");"]
    ppr (CSECall name args (Just rt)) = 
        hsep [text $ "return "++name++"<",ppr rt, text ">(", pprArgs args, text ");"]
    ppr (CSEAppAfterCall name id cargs appargs rt) = 
        hsep [text $ "return "++name++"(", pprArgs cargs, text ").Apply",
              callAppGenArgs rt cargs appargs, text "(", pprArgs appargs ,text ");"]
    ppr (CSEEval id ex) = 
        sep [
            hsep [pprSafeName id, text "=", hcat[pprSafeName id, text ".Eval();"]],
            ppr ex
        ]
    ppr (CSEAssign id idx id' ex) =
        sep [
            hsep [
                hcat [pprSafeName id, text $".x" ++ show idx],
                text "=", pprSafeQualifiedName id', text ";"
            ],
            ppr ex
        ]
    ppr (CSELet id e ex) =
        sep [
            hsep [text "var", pprSafeName id, text "=", pprLetExpr e, text ";"],
            ppr ex
        ]
    ppr (CSELetByName n e ex) =
        sep [
            hsep [text $ "var " ++ n ++ " =", pprLetExpr e, text ";"],
            ppr ex
        ]
    ppr (CSELetAssign id e ex) =
        sep [
            hsep [pprSafeName id, text "=", pprLetExpr e, text ";"],
            ppr ex
        ]
    ppr (CSECastAs varName id conName ex) =
        sep [
            hsep [text $ "var " ++ varName ++ " =", pprSafeQualifiedName id, text $ "as "++conName++";"],
            ppr ex
        ]
    ppr (CSETag idTag id ex) =
        sep [
            hsep [text "var ",pprSafeName idTag, text "=", hcat [pprSafeQualifiedName id, text $ ".Tag;"]],
            ppr ex
        ]
    ppr (CSECase id alts) = 
        hsep [hang 
                (sep [text "switch (", pprSafeQualifiedName id, text ") {"])
                4
                (sep [pprMultiline alts, text "}"])]
    ppr (CSEPrimOp op args) = hsep [text "return", pprOp op args, text ";"]
    ppr (CSEThrow id) = hsep [text "throw new Exception(",pprSafeName id,text ");"]
    ppr (CSENotImplemented) = text "throw new NotImplementedException();"
    ppr (CSEImpossible) = text "throw new ImpossibleException();"

pprLetExpr (CSELit l) = pprLit l
pprLetExpr (CSEVar id) = pprSafeQualifiedName id
pprLetExpr (CSECon name args) = hsep [text $ "new "++name++"(", pprArgs args, text ")"]
pprLetExpr (CSEApp id' args rt) = hsep [hcat [pprSafeQualifiedName id', text ".Apply", appGenArgs rt args, text "("], pprArgs args, text ")"]
pprLetExpr (CSECall name args Nothing) = hsep [text $ name++"(", pprArgs args, text ")"]
pprLetExpr (CSECall name args (Just rt)) = hsep [text $ name++"<",ppr rt, text ">(", pprArgs args, text ")"]
pprLetExpr (CSEAppAfterCall name id cargs appargs rt) = 
        hsep [text $ name++"(", pprArgs cargs, text ").Apply",
              callAppGenArgs rt cargs appargs, text "(", pprArgs appargs ,text ")"]
pprLetExpr (CSEPrimOp op args) = pprOp op args
pprLetExpr (CSECreateFun m arity args) = hsep [
    text "new Fun", pprGenArgs args, text $"("++(show arity)++",", pprLdftn m,
                            text (case args of [] -> ""; _ -> ","), pprArgs args, text ")"]
pprLetExpr (CSECreateThunk m args) = hsep [
    text "new Updatable", pprGenArgs args, text "(", pprLdftn m,
                            text (case args of [] -> ""; _ -> ","), pprArgs args, text ")"]
pprLetExpr (CSECreateClosure m args) = hsep [
    text "new SingleEntry", pprGenArgs args, text "(", pprLdftn m,
                            text (case args of [] -> ""; _ -> ","), pprArgs args, text ")"]
pprLetExpr (CSEUnpack name idx) = text $ name++".x"++show idx

pprLdftn (Method name retType args _) = hcat [text "CLR.LoadFunctionPointer", pprGenIdsWithRet retType args, text $"("++name++")"]

pprOp IntAddOp [a1, a2] = hsep [ppr a1, text "+", ppr a2]
pprOp IntSubOp [a1, a2] = hsep [ppr a1, text "-", ppr a2]
pprOp IntMulOp [a1, a2] = hsep [ppr a1, text "*", ppr a2]
pprOp IntLeOp [a1, a2] = hsep [text "(",ppr a1, text "<=", ppr a2, text ") ? 1 : 0"]
pprOp IntLtOp [a1, a2] = hsep [text "(",ppr a1, text "<", ppr a2, text ") ? 1 : 0"]
pprOp IntGeOp [a1, a2] = hsep [text "(",ppr a1, text ">=", ppr a2, text ") ? 1 : 0"]
pprOp IntGtOp [a1, a2] = hsep [text "(",ppr a1, text ">", ppr a2, text ") ? 1 : 0"]
pprOp IntEqOp [a1, a2] = hsep [text "(",ppr a1, text "==", ppr a2, text ") ? 1 : 0"]
pprOp IntNeOp [a1, a2] = hsep [text "(",ppr a1, text "!=", ppr a2, text ") ? 1 : 0"]
pprOp IntRemOp [a1, a2] = hsep [ppr a1, text "%", ppr a2]
pprOp IntQuotOp [a1, a2] = hsep [ppr a1, text "/", ppr a2]
pprOp IntQuotRemOp [a1, a2] = hsep [text "(x0:",ppr a1, text "/", ppr a2, text ", x1:", ppr a1, text "%", ppr a2, text ")"]
pprOp IntNegOp [a1] = hsep [text "-", ppr a1]
pprOp SllOp [a1, a2] = hsep [ppr a1, text "<<", text "(int)", ppr a2]
pprOp SrlOp [a1, a2] = hsep [text "(long)(((ulong)",ppr a1, text ")", text ">>", text "(int)", ppr a2, text ")"]
pprOp ISllOp [a1, a2] = hsep [ppr a1, text "<<", text "(int)", ppr a2]
pprOp ISraOp [a1, a2] = hsep [ppr a1, text ">>", text "(int)", ppr a2]
pprOp ISrlOp [a1, a2] = hsep [text "(long)(((ulong)",ppr a1, text ")", text ">>", text "(int)", ppr a2, text ")"]
pprOp FloatAddOp [a1, a2] = hsep [ppr a1, text "+", ppr a2]
pprOp FloatSubOp [a1, a2] = hsep [ppr a1, text "-", ppr a2]
pprOp FloatMulOp [a1, a2] = hsep [ppr a1, text "*", ppr a2]
pprOp FloatLeOp [a1, a2] = hsep [text "(",ppr a1, text "<=", ppr a2, text ") ? 1 : 0"]
pprOp FloatLtOp [a1, a2] = hsep [text "(",ppr a1, text "<", ppr a2, text ") ? 1 : 0"]
pprOp FloatGeOp [a1, a2] = hsep [text "(",ppr a1, text ">=", ppr a2, text ") ? 1 : 0"]
pprOp FloatGtOp [a1, a2] = hsep [text "(",ppr a1, text ">", ppr a2, text ") ? 1 : 0"]
pprOp FloatEqOp [a1, a2] = hsep [text "(",ppr a1, text "==", ppr a2, text ") ? 1 : 0"]
pprOp FloatNeOp [a1, a2] = hsep [text "(",ppr a1, text "!=", ppr a2, text ") ? 1 : 0"]
pprOp DoubleAddOp [a1, a2] = hsep [ppr a1, text "+", ppr a2]
pprOp DoubleSubOp [a1, a2] = hsep [ppr a1, text "-", ppr a2]
pprOp DoubleMulOp [a1, a2] = hsep [ppr a1, text "*", ppr a2]
pprOp DoubleLeOp [a1, a2] = hsep [text "(",ppr a1, text "<=", ppr a2, text ") ? 1 : 0"]
pprOp DoubleLtOp [a1, a2] = hsep [text "(",ppr a1, text "<", ppr a2, text ") ? 1 : 0"]
pprOp DoubleGeOp [a1, a2] = hsep [text "(",ppr a1, text ">=", ppr a2, text ") ? 1 : 0"]
pprOp DoubleGtOp [a1, a2] = hsep [text "(",ppr a1, text ">", ppr a2, text ") ? 1 : 0"]
pprOp DoubleEqOp [a1, a2] = hsep [text "(",ppr a1, text "==", ppr a2, text ") ? 1 : 0"]
pprOp DoubleNeOp [a1, a2] = hsep [text "(",ppr a1, text "!=", ppr a2, text ") ? 1 : 0"]
pprOp CharLeOp [a1, a2] = hsep [text "(",ppr a1, text "<=", ppr a2, text ") ? 1 : 0"]
pprOp CharLtOp [a1, a2] = hsep [text "(",ppr a1, text "<", ppr a2, text ") ? 1 : 0"]
pprOp CharGeOp [a1, a2] = hsep [text "(",ppr a1, text ">=", ppr a2, text ") ? 1 : 0"]
pprOp CharGtOp [a1, a2] = hsep [text "(",ppr a1, text ">", ppr a2, text ") ? 1 : 0"]
pprOp CharEqOp [a1, a2] = hsep [text "(",ppr a1, text "==", ppr a2, text ") ? 1 : 0"]
pprOp CharNeOp [a1, a2] = hsep [text "(",ppr a1, text "!=", ppr a2, text ") ? 1 : 0"]
pprOp ChrOp [a1] = hcat [text "(char)",ppr a1]
pprOp OrdOp [a1] = hcat [text "(int)",ppr a1]
pprOp TagToEnumOp [a1] = hsep [text "GHC.Types.tagToEnumHash(",ppr a1, text ")"]
pprOp DataToTagOp [a1] = hcat [ppr a1, text ".Tag"]
pprOp RaiseOp args = hsep [text "GHC.Prim.raiseHash(",pprArgs args, text ")"]
pprOp RaiseIOOp args = hsep [text "GHC.Prim.raiseIOHash(",pprArgs args, text ")"]
pprOp CatchOp args = hsep [text "GHC.Prim.catchHash(",pprArgs args, text ")"]
pprOp MaskUninterruptibleOp args = hsep [text "GHC.Prim.maskUninterruptibleHash(",pprArgs args, text ")"]
pprOp MaskAsyncExceptionsOp args = hsep [text "GHC.Prim.maskAsyncExceptionsHash(",pprArgs args, text ")"]
pprOp UnmaskAsyncExceptionsOp args = hsep [text "GHC.Prim.unmaskAsyncExceptionsHash(",pprArgs args, text ")"]
pprOp MaskStatus args = hsep [text "GHC.Prim.getMaskingStateHash(",pprArgs args, text ")"]
pprOp SeqOp args = hsep [text "GHC.Prim.seqHash(",pprArgs args, text ")"]
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
