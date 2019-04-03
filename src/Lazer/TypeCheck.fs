module rec TypeCheck

open Algorithms
open ResultMonad

open Model

exception ImpossibleException

type TypeCheckingError<'a> = 
    | MultipleErrors of TypeCheckingError<'a> list
    | RedefinitionOfType of Name: string * Here: 'a * Prev: 'a
    | UndefinedType of Name: string * Here: 'a
    | MergingSubstitutionsFail of 'a
    | TypesDoNotUnify of string * 'a
    | KindsDoNotMatch of 'a
    | TypesDoNotMatch of string * 'a
    | OccursCheck of string * 'a
    | ContextReduction of 'a
    | UnboundIdentifier of Name: string * Here: 'a
    | UnresolvableAmbiguity of 'a
    | SignatureToGeneral of string * Scheme * Scheme * 'a
    | ContextToWeak of string * 'a

let combineResults rl =
    let r = ResultMonad.combineResults rl
    match r with
    | Ok x -> Ok x
    | Error l -> Error (MultipleErrors l)

let rec namesFromType (t:Model.Type<'a>) =
    match t with
    | Model.TVar _ -> []
    | TUnion id -> [id]
    | TFunction (_, f, tt) -> namesFromType f @ namesFromType tt
    | TApp (_, tt, ps) -> namesFromType tt @ List.collect namesFromType ps

let typeDefDependencies td =
    let namesFromAlt (UAlt (_, _, ts)) =
        List.collect namesFromType ts |> List.distinct
    match td with
    | DataDef (_, id, alts) -> 
        let deps = alts |> List.collect namesFromAlt |> List.distinct
        (id, deps)
    | AliasDef (_, id, t) ->
        let deps = List.distinct (namesFromType t)
        (id, deps)

let identEq (Ident (_,n)) (Ident (_,m)) = (n = m)

let checkReferencedTypesExist imported (ts : TypeDef<'a> list) = result {
    let sorted = topoSortP identEq typeDefDependencies ts |> topoSortGroup identEq
    let vali (i : Ident<'a>) = i.Value
    let dependsOnExisting (_, deps, _) seen =
        let checkOne (d: Ident<'a>) =
            let m = d.Value
            match seen |> List.filter (fun (p, _,_) -> vali p = m) with
            | _::_ -> result.Return ()
            | [] ->
                let ns = imported |> Set.filter (fun idt -> vali idt = m) 
                if not (Set.isEmpty ns) then
                    result.Return ()
                else
                    result.Fail (UndefinedType (d.Value, d.Context))
        List.map checkOne deps
    let dependsOnExistingL l seen =
        l |> List.collect (fun x -> dependsOnExisting x (l @ List.concat seen))
    let res =
        mapSeen dependsOnExistingL sorted [] []
        |> List.concat
        |> combineResults
        |> Result.map ignore
    return! res
}

let checkRedefinition (ts : TypeDef<'a> list) = result {
    let getNameAndPosFromTypeDef t =
        match t with
        | AliasDef (ctx, name, _) -> (name, ctx)
        | DataDef (ctx, name, _) -> (name, ctx)
    let names = ts |> List.map getNameAndPosFromTypeDef
    let isRedefined (n,c) seen =
        let w = List.filter (fun (m, _) -> n = m) seen
        match w with
        | [] -> None
        | (_, cc) :: _ -> Some (n, c, cc)
    let errors =
        mapSeen isRedefined names [] []
        |> List.filter Option.isSome
        |> List.map (fun (Some (Ident(_,n),c,cc)) -> RedefinitionOfType (n,c,cc))
    if List.isEmpty errors then
        return ()
    else
        return! result.Fail (MultipleErrors errors)

}

let constrDefs (td:TypeDef<'a>) : (Ident<'a> * Assump) list =
    match td with
    | AliasDef _ -> []
    | DataDef (_,n,alts) ->
        alts |>List.map (fun (UAlt (_,c,ts)) -> 
            (c, Ass (c.Value, 
                     toScheme <| foldr1 fn ((ts|> List.map typeRepresentation)@[TCon (Tycon (n.Value,Star))]))))

// check type declarations
let checkTypeDefs imported ts = result {
    do! checkRedefinition ts
    do! checkReferencedTypesExist imported ts
    let declaredTypes = List.map (fst << typeDefDependencies) ts
    let constructors = List.collect constrDefs ts
    return (Set.union imported (Set.ofList declaredTypes), constructors)
}

// get a list of contructor signatures from types

// check signatures that their types exist
let checkSignatures types sigs = result {
    let vali (i:Ident<'a>) = i.Value
    let check = sigs |> List.collect (fun (TypeSig (_,_,t)) ->
                let ns = namesFromType t
                ns |> List.map (fun n -> if Set.filter (fun k -> vali k = vali n) types |> Set.isEmpty then result.Fail (UndefinedType (n.Value, n.Context)) else result.Return ()))
    return! combineResults check |> Result.map ignore
}

let rec patternVars p =
    match p with
    | PVar i -> [i]
    | PConstr (_,i, pp) -> i :: List.collect patternVars pp
    | PWildcard _ -> []
    | PLit _ -> []
and exprVars bound e =
    match e with
    | EVar i -> if elemEq identEq i bound then [] else [i]
    | ELet (_,bg,e2) ->
        let (intro,unbound) = bgVars bound bg
        exprVars (intro @ bound) e2
    | EIf (_, e1, e2, e3) ->
        List.collect (exprVars bound) [e1;e2;e3]
    | EMultiConstr (_,_,es) ->
        List.collect (exprVars bound) es
    | EApp (_,e1,e2) ->
        List.collect (exprVars bound) [e1;e2]
    | ELambda (_,p,e) ->
        let intro = patternVars p
        exprVars (intro @ bound) e
    | EBinOp (_,_,e1,e2) ->
        List.collect (exprVars bound) [e1;e2]
    | EUnOp (_,_,e) ->
        exprVars bound e
    | EConstr i -> [i]
    | _ -> []
and bgVars bound (BindGroup (_,bs)) =
    let intro b =
        match b with
        | BSig _ -> []
        | BPat (_,p,e) -> patternVars p
        | BFun (_,n,ps,e) -> [n]
    let expr intro b =
        match b with
        | BSig _ -> []
        | BPat (_,p,e) -> exprVars (intro @ bound) e
        | BFun (_,n,ps,e) ->
            let localIntro = List.collect patternVars ps
            exprVars (localIntro @ intro @ bound) e
    let introBg = List.collect intro bs
    (introBg, List.collect (expr introBg) bs)
let bindingDeps (pats, expr) =
    let bound = List.collect patternVars pats
    exprVars bound expr
let bindingDependencies b = 
    let alt b = 
        match b with
        | BFun (_,n,ps,e) -> (PVar n :: ps, e)
        | BPat (_,p,e) -> ([p],e)
        | BSig _ -> raise ImpossibleException
    let deps = bindingDeps (alt b)
    let intro b =
        match b with
        | BSig _ -> []
        | BPat (_,p,e) -> patternVars p
        | BFun (_,n,ps,e) -> [n]
    (intro b, deps)
let valDefDependencies vd =
    match vd with
    | MergedValDef (ctx, i, pats) ->
        let deps = pats |> List.collect bindingDeps
        (i, deps)

// sort and group value declarations by dependencies
let groupValueDeclarations imported constrs vds = result {
    let vdName (ValDef (_,Ident(_,name),_,_)) = name
    let merge (_, vds : ValDef<Position> list) =
        let posCombine (Pos (beg, _, f)) (Pos (_, e, _)) = Pos (beg, e, f)
        let len = List.length vds
        let name = vds.[0].Name.Value
        let ctx = posCombine (vds.[0].Context) (vds.[len-1].Context)
        MergedValDef (ctx, Ident(ctx, name), vds |> List.map (fun (ValDef (_,_,p,e)) -> (p,e)))
    let g = List.groupBy vdName vds |> List.map merge
    let sorted = topoSort identEq valDefDependencies g
    let usedValues = g |> List.collect (snd << valDefDependencies)
    let names = g |> List.map (fst << valDefDependencies)
    let unbound = 
        [ for v in usedValues do
            let isin = elemEq identEq v 
            if not (isin constrs || isin imported || isin names) then
                yield v
        ]
    if not (List.isEmpty unbound) then
        return! combineResults (unbound |> List.map (fun i -> result.Fail (UnboundIdentifier (i.Value,i.Context))))
    else
        return sorted
}

type Id = string

type Kind = Star | Kfun of Kind * Kind
    with
        override this.ToString() =
            match this with
            | Star -> "*"
            | Kfun (kl,kr) -> "("+string kl+" -> "+string kr+")"

type IKind =
    abstract Kind : Kind
let kind (x : IKind) = x.Kind

type ITypes<'T> =
    abstract Apply : Subst -> 'T
    abstract Tv    : Tyvar list
let apply s (x:ITypes<'a>) = x.Apply s
let tv (x:ITypes<'a>) = x.Tv

type IInstatiate<'T> =
    abstract Inst : Type list -> 'T
let inst ts (x:IInstatiate<'a>) = x.Inst ts

type Tyvar = Tyvar of Id * Kind
    with interface IKind with
            member this.Kind =
                match this with
                | Tyvar (_,k) -> k
         override this.ToString() =
            match this with
            | Tyvar (i,k) -> i + "`" + (string k)
type Tycon = Tycon of Id * Kind
    with interface IKind with
            member this.Kind =
                match this with
                | Tycon (_,k) -> k
         override this.ToString() =
            match this with
            | Tycon (i,k) -> i + "`" + (string k)
[<StructuredFormatDisplay("{AsString}")>]
type Type = TVar of Tyvar | TCon of Tycon | TAp of Type * Type | TGen of int
    with
    interface IKind with
            member this.Kind =
                match this with
                | TCon t -> kind t
                | TVar t -> kind t
                | TAp (t,_) ->
                    match kind t with
                    | Kfun (_,k) -> k
    interface ITypes<Type> with
        member this.Apply s =
            match this with
            | TVar u -> match Map.tryFind u s with
                        | Some t -> t
                        | None -> TVar u
            | TAp (l,r) -> TAp (apply s l, apply s r)
            | t -> t
        member this.Tv =
            match this with
            | TVar u -> [u]
            | TAp (l,r) -> (tv l @ tv r) |> List.distinct
            | _ -> []
    interface IInstatiate<Type> with
        member this.Inst ts =
            match this with
            | TAp (l,r) -> TAp (inst ts l, inst ts r)
            | TGen n -> ts.[n]
            | _ -> this
    override this.ToString() =
        match this with
        | TVar tv -> tv.ToString()
        | TCon tc -> tc.ToString()
        | TAp (arr, TAp (al,ar)) when arr = tArrow -> 
            let t = TAp (al, ar)
            "(" + t.ToString() + ") ->"
        | TAp (arr, t) when arr = tArrow -> t.ToString() + " ->"
        | TAp (tl, TAp (al,ar)) -> 
            let tr = TAp (al,ar)
            tl.ToString() + " (" + tr.ToString() + ")"
        | TAp (tl,tr) -> tl.ToString()+" "+tr.ToString()
        | TGen i -> "∀"+string i
    member this.AsString = this.ToString()

let tInt   = TCon (Tycon ("Int", Star))
let tChar  = TCon (Tycon ("Char", Star))
let tBool  = TCon (Tycon ("Bool", Star))
let tArrow = TCon (Tycon ("->", Kfun (Star, Kfun (Star, Star))))
let tList  = TCon (Tycon ("[]", Kfun (Star, Star)))

let tap a b = TAp (a, b)
let fn a b = TAp (TAp (tArrow, a), b)
let kfn a b = Kfun (a, b)
let list a = TAp (tList, a)

let tString = list tChar

let mkTuple k =
    let ident = System.String.Concat ('(' :: List.replicate (k-1) ',' @ [')'])
    TCon (Tycon (ident, foldr1 kfn (List.replicate k Star)))

let applyTuple t l = foldl1 tap (t::l)

type Subst = Map<Tyvar, Type>
let keys s = Map.fold (fun a k t -> k :: a) [] s
let nullSubst : Subst = Map.empty
let (+->) u t : Subst = Map.add u t nullSubst
// @@ composition ~> first s2 then s1
let (@@) s1 s2 =
    let m = Map.map (fun _ t -> apply s1 t) s2 
    Map.fold (fun m k t -> Map.add k t m) m s1
let substOfList = List.fold (fun m (k,t) -> Map.add k t m) nullSubst

type TI<'ctx, 'state,'a> = TI of (Subst -> int -> 'ctx -> 'state -> Result<(Subst * int * 'ctx * 'state * 'a), TypeCheckingError<'ctx>>)

type TIBuilder() =
    member z.Return(x) = TI (fun s i c r -> result { return (s,i,c,r,x) })
    member z.Bind((TI m, f)) = TI (fun s i c r -> result {
            let! (s', j, d, r', x) = m s i c r
            let (TI g) = f x
            return! g s' j d r'
        }
    )
    member z.ReturnFrom(m) = m

let getSubst = TI (fun s i c r -> result { return (s,i,c,r,s) })
let putSubst s = TI (fun _ i c r -> result { return (s,i,c,r,()) })
let getContext = TI (fun s i c r -> result { return (s,i,c,r,c) })
let putContext c = TI (fun s i _ r -> result { return (s,i,c,r,()) })
let getState = TI (fun s i c r -> result { return (s,i,c,r,r) })
let putState r = TI (fun s i c _ -> result { return (s,i,c,r,()) })

let fail x = TI (fun s i c r -> result.Fail x)
let monad = TIBuilder()

let extSubst s' = monad {
    let! s = getSubst
    return! putSubst (s' @@ s)
}

let intersect a b = List.filter (fun x -> List.contains x b) a 

let merge s1 s2 = monad {
    let agree = List.forall (fun u -> apply s1 (TVar u) = apply s2 (TVar u)) (intersect (keys s1) (keys s2))
    if agree then return Map.fold (fun m k t -> Map.add k t m) s2 s1
    else 
        let! ctx = getContext
        return! fail (MergingSubstitutionsFail ctx)
}

let rec mgu t1 t2 = monad {
    match t1, t2 with
    | TAp (l,r), TAp (l', r') ->
        let! s1 = mgu l l'
        let! s2 = mgu (apply s1 r) (apply s1 r')
        return (s2 @@ s1)
    | TVar u, t -> return! varBind u t
    | t, TVar u -> return! varBind u t
    | TCon tc1, TCon tc2 when tc1 = tc2 -> return nullSubst
    | _-> 
        let! ctx = getContext
        return! fail <| TypesDoNotUnify (sprintf "types `%A` and `%A` do not unify" t1 t2, ctx)
}

let varBind u t = monad {
    match t with
    | _ when t = TVar u -> return nullSubst
    | _ when List.contains u (tv t) ->
        let! ctx = getContext
        return! fail <| OccursCheck (sprintf "occurs check fails for u = `%A` and t = `%A` do not unify" u t, ctx)
    | _ when kind u <> kind t -> 
        let! ctx = getContext
        return! fail (KindsDoNotMatch ctx)
    | _ -> return (u +-> t)
}

// require t2 and t1 to match but don't unify them
let rec matchs t1 t2 = monad {
    match t1, t2 with
    | TAp (l, r), TAp (l', r') ->
        let! sl = matchs l l'
        let! sr = matchs r r'
        return! merge sl sr
    | TVar u, t when kind u = kind t -> return (u +-> t)
    | TCon tc1, TCon tc2 when tc1 = tc2 -> return nullSubst
    | _ -> 
        let! ctx = getContext
        return! fail <| TypesDoNotMatch (sprintf "types `%A` and `%A` do not match" t1 t2, ctx)
}

type Pred = IsIn of Id * Type
    with
    interface ITypes<Pred> with
        member this.Apply s =
            match this with
            | IsIn (i,t) -> IsIn (i, apply s t)
        member this.Tv =
            match this with
            | IsIn (i,t) -> tv t
    interface IInstatiate<Pred> with
        member this.Inst ts =
            match this with
            | IsIn (i,t) -> IsIn (i, inst ts t)
type Qual<'a when 'a :> ITypes<'a> and 'a :> IInstatiate<'a>> = Requires of Pred list * 'a
    with
    interface ITypes<Qual<'a>> with
        member this.Apply s =
            match this with
            | Requires (ps, t) -> List.map (apply s) ps => apply s t
        member this.Tv =
            match this with
            | Requires (ps, t) -> (List.collect tv ps @ tv t) |> List.distinct
    interface IInstatiate<Qual<'a>> with
        member this.Inst ts =
            match this with
            | Requires (ps, t) -> Requires (List.map (inst ts) ps, inst ts t)
    override this.ToString() =
        match this with
        | Requires (ps,a) -> string ps + " => " + a.ToString()

let (=>) p t = Requires (p,t)

let runTI (TI f) (ctx:'a) state = result {
    let! (_,_,_,_,x) = f nullSubst 0 ctx state
    return x
}

let lift m (IsIn (i,t)) (IsIn (i',t')) =
    if i = i' then runTI (m t t') () () |> optionOfResult
    else None //classes differ

let optionOfResult r = 
    match r with
    | Ok x -> Some x
    | _ -> None

let mguPred   = lift mgu
let matchPred = lift matchs

type Class = (Id list * Inst list)
type Inst  = Qual<Pred>

type ClassEnv = {Classes: Map<Id, Class>; Defaults: Type list}
let emptyClassEnv () = {Classes = Map.empty; Defaults = [tInt]}

let super ce i =
    match Map.tryFind i ce.Classes with
    | Some (is,_) -> is
let insts ce i = 
    match Map.tryFind i ce.Classes with
    | Some (_,its) -> its
let defined o = Option.isSome o

let modify ce i c = {ce with Classes = Map.add i c ce.Classes}

type EnvTransformer = ClassEnv -> ClassEnv option

let (<~>) f g ce = Option.bind g (f ce)

let addClass i is ce =
    if defined (Map.tryFind i ce.Classes) then
        None //fail (sprintf "Class `%s` already defined" i)
    else
        if List.exists (fun i -> not (defined (Map.tryFind i ce.Classes))) is then
            None //fail (sprintf "Superclass `%s` is not defined" (List.head undefinedSuper))
        else
            Some (modify ce i (is,[]))

let addPreludeClasses = addCoreClasses <~> addNumClasses

let addCoreClasses =
    addClass "Eq" []
    <~> addClass "Ord" ["Eq"]
    <~> addClass "Show" []
    <~> addClass "Enum" []
    <~> addClass "Functor" []
    <~> addClass "Monad" []
let addNumClasses =
    addClass "Num" ["Eq";"Show"]
    <~> addClass "Real" ["Num";"Ord"]
    <~> addClass "Integral" ["Real";"Enum"]

let addInst ps p ce =
    let (IsIn (i,_)) = p
    if not (defined (Map.tryFind i ce.Classes)) then
        None // fail "no class for instance"
    else
        let its = insts ce i
        let qs = List.map (fun (Requires (_, q)) -> q) its
        if List.exists (overlap p) qs then
            None //fail "overlaping instances"
        else
            let c = (super ce i, (ps => p) :: its)
            Some (modify ce i c)

let overlap p q = defined (mguPred p q)

let exampleInsts =
    addPreludeClasses
    <~> addInst [] (IsIn ("Eq", tInt))
    <~> addInst [IsIn ("Eq", (TVar (Tyvar ("a", Star))))] (IsIn ("Eq", list (TVar (Tyvar ("a", Star)))))

let rec bySuper ce p =
    let (IsIn (i,t)) = p
    p :: List.concat [for i' in super ce i -> bySuper ce (IsIn (i',t))]

let rec byInst ce p =
    let (IsIn (i,t)) = p
    let tryInst (Requires (ps,h)) = Option.bind (fun u -> Some (List.map (apply u) ps)) (matchPred h p)
    Seq.tryFind Option.isSome (seq { for it in insts ce i do yield tryInst it })
    |> Option.map (fun (Some x) -> x)

let entail ce ps p =
    List.exists (List.contains p) (List.map (bySuper ce) ps)
    || match byInst ce p with
       | None -> false
       | Some qs -> List.forall (entail ce ps) qs

let inHnf (IsIn (c,t)) =
    let rec hnf t =
        match t with
        | TVar _ -> true
        | TCon _ -> false
        | TAp (tt, _) -> hnf tt
        | _ -> raise ImpossibleException
    hnf t

let rec mapM f l = monad {
    match l with
    | [] -> return []
    | h::t ->
        let! x = f h
        let! xs = mapM f t
        return x::xs
}

let toHnfs ce ps = monad {
    let! pss = mapM (toHnf ce) ps
    return List.concat pss
}
let toHnf ce p = monad {
    if inHnf p then
        return [p]
    else
        match byInst ce p with
        | None -> 
            let! ctx = getContext
            return! fail (ContextReduction ctx)
        | Some ps -> return! toHnfs ce ps
}

let simplify ce =
    let rec loop rs l =
        match l with
        | [] -> rs
        | p::ps when entail ce (rs@ps) p -> loop rs ps
        | p::ps -> loop (p::rs) ps
    loop []

let reduce ce ps = monad {
    let! qs = toHnfs ce ps
    return simplify ce qs
}

type Scheme = Forall of Kind list * Qual<Type>
    with
    interface ITypes<Scheme> with
        member this.Apply s =
            match this with
            | Forall (ks, qt) -> Forall (ks,apply s qt)
        member this.Tv =
            match this with
            | Forall (_, qt) -> tv qt
    override this.ToString() =
        match this with
        | Forall (ks, qt) -> "∀ "+string ks+" {"+string qt + "}"

let quantify vs qt =
    let vs' = List.filter (fun v -> List.contains v vs) (tv qt)
    let ks = List.map kind vs'
    let s =
        List.zip vs' (List.map TGen [0..(List.length vs' - 1)])
        |> List.fold (fun m (v,t) -> v +-> t @@ m) nullSubst
    Forall (ks, apply s qt)

let toScheme t = Forall ([], [] => t)

type Assump = Ass of Id * Scheme
    with
    interface ITypes<Assump> with
        member this.Apply s =
            match this with
            | Ass (i,sc) -> Ass (i, apply s sc)
        member this.Tv =
            match this with
            | Ass (i,sc) -> tv sc

let (>~>) i s = Ass (i,s)

let rec find i ass =
    match ass with
    | [] -> monad {
        let! ctx = getContext
        return! fail (UnboundIdentifier (i,ctx))
      }
    | (Ass (i',sc))::t -> if i = i' then monad.Return sc else find i t

let unify t1 t2 = monad {
    let! s = getSubst
    let! u = mgu (apply s t1) (apply s t2)
    return! extSubst u
}

let enumId i = sprintf "v%d" i
let newTVar k = TI (fun s i c r -> let v = Tyvar (enumId i, k) in result.Return (s,i+1,c,r,TVar v))

let freshInst (Forall (ks, qt)) = monad {
    let! ts = mapM newTVar ks
    return inst ts qt
}

type Infer<'c,'s,'e,'t> = ClassEnv -> Assump list -> 'e -> TI<'c,'s,Pred list * 't>

type TIState = {Constructors : Map<Id,Assump>}

let tiLit l = monad {
    match l with
    | LChar (ctx,v) -> return ([], tChar, LChar((ctx, Some tChar),v))
    | LInt (ctx,va) ->
        let! v = newTVar Star
        return ([IsIn ("Num", v)], v, LInt((ctx, Some v),va))
    | LString (ctx,v) -> return ([], tString, LString((ctx, Some tString),v))
}

let tiPat p = monad {
    match p with
    | PVar (Ident (ctx,i)) ->
        let! v = newTVar Star
        return ([], [i >~> toScheme v], v, PVar (Ident ((ctx,Some v),i)))
    | PWildcard ctx ->
        let! v = newTVar Star
        return ([], [], v, PWildcard ((ctx,Some v)))
    | PLit l ->
        let! (ps, t, nl) = tiLit l
        return (ps, [], t, PLit nl)
    | PConstr (ctx,Ident(ctx',i),pats) ->
        do! putContext ctx
        let! (Ass (id, sc)) = lookupConstr i
        let! (ps,ass,ts,npats) = tiPats pats
        let! t' = newTVar Star
        let! (Requires (qs,t)) = freshInst sc
        do! unify t (List.foldBack fn ts t')
        return (ps@qs, ass, t', PConstr ((ctx, Some t'), Ident((ctx, Some t),i), npats))
}

let tiPats pats = monad {
    let! psasts = mapM tiPat pats
    let ps = psasts |> List.collect (fun (ps,_,_,_) -> ps)
    let ass = psasts |> List.collect (fun (_,ass,_,_) -> ass)
    let ts = psasts |> List.map (fun (_,_,ts,_) -> ts)
    let npats = psasts |> List.map (fun (_,_,_,p) -> p)
    return (ps,ass,ts,npats)
}

let lookupConstr i = monad {
    //printfn "looking up constr `%s`" i
    let! st = getState
    return Map.find i st.Constructors
}


let rec foldM f a l = monad {
    match l with
    | [] -> return a
    | h::t ->
        let! b = f a h
        return! foldM f b t
}

let foldM1 f l = foldM f (List.head l) (List.tail l)

let rec tiExpr ce ass e = monad {
    match e with
    | EVar (Ident(ctx, i)) ->
        do! putContext ctx
        let! sc = find i ass
        let! (Requires (ps,t)) = freshInst sc
        return (ps,t, EVar (Ident ((ctx,Some t),i)))
    | EConstr (Ident(ctx, i)) ->
        do! putContext ctx
        let! (Ass (_, sc)) = lookupConstr i
        let! (Requires (ps,t)) = freshInst sc
        return (ps,t, EConstr (Ident((ctx, Some t),i)))
    | ELiteral lit ->
        let! (a,b,l) = tiLit lit
        return (a,b,ELiteral l)
    | ELet (ctx, bg, ie) ->
        do! putContext ctx
        let! ps, as',bg' = tiBindingGroup ce ass bg
        let! qs, t, ie' = tiExpr ce (as' @ ass) ie
        return (ps @ qs, t, ELet ((ctx,Some t), bg', ie'))
    | EApp (ctx, el, er) ->
        do! putContext ctx
        let! (ps, te, el') = tiExpr ce ass el
        let! (qs, tf, er') = tiExpr ce ass er
        let! t = newTVar Star
        do! unify (fn tf t) te
        return (ps@qs, t, EApp ((ctx,Some t), el',er'))
    | ELambda (ctx, p, e) ->
        do! putContext ctx
        let! (ps, as', tp, p') = tiPat p //TODO how about multiple patterns?
        let! (qs, t, e') = tiExpr ce (as' @ ass) e
        return (ps@qs, fn tp t, ELambda ((ctx, Some (fn tp t)),p',e'))
    | EIf (ctx, c, t, e) ->
        do! putContext ctx
        let! (ps, tc, c') = tiExpr ce ass c
        let! (qs, tt, t') = tiExpr ce ass t
        let! (ws, te, e') = tiExpr ce ass e
        do! unify tBool tc
        do! unify tt te
        return (ps@qs@ws, tt, EIf ((ctx, Some tt), c', t', e'))
    | EMultiConstr (ctx, Ident(ctx',i), es) ->
        let! tps = mapM (tiExpr ce ass) es        
        do! putContext ctx
        let (pss, tss, es') = List.unzip3 tps
        if i = "[]" then
            let unifyNext t1 t2 = monad {
                do! unify t1 t2
                return t2
            }
            let! v = newTVar Star
            if List.isEmpty es then
                return ([], list v, EMultiConstr ((ctx,Some <| list v),Ident((ctx,None),i), es'))
            else
                let! _ = foldM1 unifyNext (v::tss)
                return (List.concat pss, list v, EMultiConstr ((ctx,Some <| list v),Ident((ctx,None),i), es'))
        else //tuple
            let! (t,lts) = monad {
                let n = (Seq.filter ((=) ',') i |> Seq.length) + 1
                let! lts = mapM (fun _ -> newTVar Star) [1..n]
                return (applyTuple (mkTuple n) lts, lts)
            }
            let! _ = mapM (fun (t1,t2) -> unify t1 t2) (List.zip lts tss)
            return (List.concat pss, t,EMultiConstr ((ctx,Some <| t),Ident((ctx,None),i), es'))
    | EBinOp (ctx, op, el, er) ->
        let ope = EVar op
        let ne = EApp (ctx, EApp (ctx, ope, el), er)
        return! tiExpr ce ass ne
    | EUnOp (ctx, op, e) ->
        let ope = EVar op
        let ne = EApp (ctx, ope, e)
        return! tiExpr ce ass ne
}

let fstt (x,_,_) = x
let sndd (_,x,_) = x
let thrd (_,_,x) = x

type PatBind<'a> = Pattern<'a> * Expr<'a>

let tiPatBind ce ass (pat, e) = monad {
    let! (ps, as', t, pat') = tiPat pat
    let! (qs, t', e') = tiExpr ce (as'@ass) e
    do! unify t t'
    return (ps@qs, (pat',e'))
}

type Alt<'a> = Pattern<'a> list * Expr<'a>

let tiAlt ce ass (pats, e) = monad {
    let! (ps, as', ts, npats) = tiPats pats
    let! (qs, t, e') = tiExpr ce (as'@ass) e
    return (ps@qs, List.foldBack fn ts t, (npats, e'))
}

let tiAlts ce ass (alts:Alt<'a> list) t = monad {
    let! psts = mapM (tiAlt ce ass) alts
    let! _ = mapM (unify t) (List.map sndd psts)
    return (List.collect fstt psts,List.map thrd psts)
}

let split ce fs gs ps = monad {
    let! ps' = reduce ce ps
    let (ds, rs) = List.partition (List.forall (fun x -> List.contains x fs) << tv) ps'
    let! rs' = defaultedPreds ce (fs@gs) rs
    return (ds, List.except rs' rs)
}

type Ambiguity = Tyvar * Pred list

let ambiguities ce (vs:Tyvar list) (ps:Pred list) = List.map (fun v -> (v, List.filter (List.contains v << tv) ps)) (List.except vs (List.collect tv ps))

let numClasses = ["Num";"Real";"Integral"]
let stdClasses = ["Eq";"Ord";"Show";"Enum";"Functor";"Monad"] @ numClasses

let candidates ce (v,qs) =
    let is = List.map (fun (IsIn (i,_)) -> i) qs
    let ts = List.map (fun (IsIn (_,t)) -> t) qs
    if List.forall ((=) (TVar v)) ts
       && List.exists (fun x -> List.contains x numClasses) is
       && List.forall (fun x -> List.contains x stdClasses) is
    then
      [for t' in ce.Defaults do
        if List.forall (entail ce []) (List.map (fun i -> IsIn (i,t')) is) then
            yield t'
      ]
    else []

let withDefaults f ce vs ps = monad {
    let vps = ambiguities ce vs ps
    let tss = List.map (candidates ce) vps
    if List.exists List.isEmpty tss then
        let! ctx = getContext
        return! fail (UnresolvableAmbiguity ctx)
    else
        return (f vps (List.map List.head tss))
}

let defaultedPreds ce = withDefaults (fun vps ts -> List.collect snd vps) ce

let defaultSubst ce = withDefaults (fun vps ts -> List.zip (List.map fst vps) ts) ce

let noType c = (c,None)

let equivalent s1 s2 =
    let t1 = tv s1
    let t2 = tv s2
    let s = substOfList (zipWith (fun a b -> (a,TVar b)) t1 t2)
    apply s s1 = apply s s2

type Expl<'a> = Ident<'a> * Scheme * Alt<'a> list

let tiExpl ce ass (i:Ident<'a>, sc, alts) = monad {
    let! (Requires (qs,t)) = freshInst sc
    let! (ps, alts') = tiAlts ce ass alts t
    let! s = getSubst
    let qs' = List.map (apply s) qs
    let t' = apply s t
    let fs = List.collect tv (List.map (apply s) ass)
    let gs = List.except fs (tv t')
    let sc' = quantify gs (qs' => t')
    let ps' = List.filter (not << entail ce qs') (List.map (apply s) ps)
    let! ds, rs = split ce fs gs ps'
    if not <| equivalent sc sc' then
        return! fail (SignatureToGeneral (i.Value, sc, sc', i.Context))
    else if not (List.isEmpty rs) then
        return! fail (ContextToWeak (i.Value,i.Context))
    else
        return (ds,(i.Map noType,sc',alts'))
}

type Impl<'a> = ImplFun of Ident<'a> * Alt<'a> list | ImplPat of PatBind<'a>

let restricted (bs:Impl<'a> list) =
    let simple (i,alts) = List.exists (List.isEmpty << fst) alts
    let checkI i =
        match i with
        | ImplFun (i,alts) -> simple (i,alts)
        | ImplPat _ -> true
    List.exists checkI bs

let sequence ml = monad {
    match ml with
    | h::t -> 
        let! hh = h
        let! tt = sequence t
        return hh :: tt
    | [] -> return []
}

let tiImpls ce ass (bs:Impl<'a> list) = monad {
    let funsW, patsW = List.partition (function ImplFun _ -> true | _ -> false) bs
    let funs = List.map (fun (ImplFun (i,a)) -> (i,a)) funsW
    let! tfs = mapM (fun _ -> newTVar Star) funs
    let pats = List.map (fun (ImplPat a) -> a) patsW
    let isD,altss = List.unzip funs
    let is = isD |> List.map (fun i -> i.Value)
    let scs = List.map toScheme tfs
    let as' = zipWith (>~>) is scs @ ass
    let! pssZ = sequence (zipWith (tiAlts ce as') altss tfs)
    let pss,altss' = List.unzip pssZ
    let! patsZ = mapM (tiPatBind ce as') pats
    let (pss2,pats') = List.unzip  patsZ
    let isD' = isD |> List.map (fun i -> i.Map (fun ctx -> (ctx,None)))
    let bs' = (List.zip isD' altss' |> List.map ImplFun) @ (List.map ImplPat pats')
    let! s = getSubst
    let ps' = List.map (apply s) (List.concat <| pss2 @ pss)
    let ts' = List.map (apply s) tfs
    let fs = List.collect tv (List.map (apply s) ass)
    let vss = List.map tv ts'
    let foldr1 f l =
        match l with
        | [] -> []
        | _ -> Algorithms.foldr1 f l
    let gs = List.except fs <| foldr1 (fun a b -> List.distinct (a @ b)) vss
    let! ds, rs = split ce fs (foldr1 intersect vss) ps'
    if restricted bs then
        let gs' = List.except (List.collect tv rs) gs
        let scs' = List.map (quantify gs' << ((=>) [])) ts'
        return (ds@rs, zipWith (>~>) is scs',bs')
    else
        let scs' = List.map (quantify gs << ((=>) rs)) ts'
        return (ds, zipWith (>~>) is scs', bs')
}

let tiSeq ti ce ass l = monad {
    match l with
    | [] -> return ([],[],[])
    | bs::bss ->
        let! ps,as',v' = ti ce ass bs
        let! qs,as'',vs' = tiSeq ti ce (as'@ass) bss
        return (ps@qs, as''@as',v'::vs')
}

type BindGroup<'a> = Expl<'a> list * Impl<'a> list list

let tiBindGroup ce ass (es:Expl<'a> list, iss) = monad {
    let! ass = mapM anonimizeAssump ass
    let as' = es |> List.map (fun (v,sc,_) -> v.Value >~> sc)
    let! ps, as'',iss' = tiSeq tiImpls ce (as'@ass) iss
    let! qssZ = es |> mapM (tiExpl ce (as''@as'@ass)) 
    let qss,es' = List.unzip qssZ
    return (ps@List.concat qss, as''@as',(es',iss'))
}

let anonimizeAssump (Ass (i,sc)) = monad {
    let ts = tv sc
    let! ts' = mapM (fun _ -> newTVar Star) ts
    let sc' = apply (substOfList <| List.zip ts ts') sc
    return i >~> sc'
}

let typeRepresentation t =
    let rec withKind k t =
        match t with
        | TUnion (Ident(_,"[]")) -> TCon (Tycon ("[]",kfn Star Star))
        | TUnion (Ident(_,i)) -> TCon (Tycon (i,k))
        | Model.Type.TVar (Ident(_,i)) -> TVar (Tyvar (i,k))
        | TFunction (_,f,t) -> fn (withKind Star f) (withKind Star t)
        | TApp (_,t, ts) ->
            let ts' = List.map (withKind Star) ts
            let n = List.length ts
            applyTuple (withKind (foldr1 kfn (List.replicate n Star)) t) ts'
    withKind Star t

let implDependencies impl =
    match impl with
    | ImplFun (i,alts) -> 
        let deps = List.collect bindingDeps alts
        ([i],deps)
    | ImplPat (p,e) ->
        let names = patternVars p |> List.filter (fun (Ident(_,n)) -> System.Char.IsLower n.[0])
        let deps = bindingDeps ([p],e)
        (names, deps)

let tiBindingGroup ce ass (BindGroup (ctx,bs)) = monad {
    let isSig b = match b with BSig _ -> true | BFun _ | BPat _ -> false
    let (signatures,definitions) = List.partition isSig bs
    let isExplicit def =
        match def with
        | BFun (ctx, n, pats, e) -> 
            match List.tryFind (fun (BSig (TypeSig (_,m,_))) -> identEq n m) signatures with
            | Some (BSig (TypeSig (_,_,t))) ->
                let sc = toScheme (typeRepresentation t)
                [(n, sc, [(pats, e)])]
            | None -> []
        | _ -> []
    let isImplicit def =
        match def with
        | BFun (ctx, n, pats, e) -> 
            match List.tryFind (fun (BSig (TypeSig (_,m,_))) -> identEq n m) signatures with
            | Some _ -> []
            | None -> [ImplFun (n,[(pats,e)])]
        | BPat (_,p,e) -> [ImplPat (p,e)]
    let explicitDefs : Expl<'a> list = List.collect isExplicit definitions
    let implicitDefs : Impl<'a> list = List.collect isImplicit definitions
    let sorted = topoSort (fun lbl dep -> List.contains dep lbl) implDependencies implicitDefs
    let! (ps, ass, (expls, impls)) = tiBindGroup ce ass (explicitDefs,sorted)
    let revExpl (i:Ident<'a * 'b option>,_,[(pats,e)]) = BFun (i.Context, i, pats, e)
    let revImpl i =
        match i with
        | ImplFun (i,[(pats,e)]) -> BFun (i.Context, i, pats, e)
        | ImplPat (p,e) -> BPat (p.Context, p, e)
    let explBs = expls |> List.map revExpl
    let implBs = impls |> List.concat |> List.map revImpl
    let sigBs = signatures |> List.map (fun x -> x.Map noType)
    let newBs = explBs @ implBs @ sigBs
    return (ps,ass,BindGroup (noType ctx, newBs))
}

type TIProgram<'a> = BindGroup<'a> list

let tiProgram ce ass (bgs:TIProgram<'a>) =
    let ti = monad {
        let! ps,as',(bgs':BindGroup<'a*Type option> list) = tiSeq tiBindGroup ce ass bgs
        let! s = getSubst
        let! rs = reduce ce (List.map (apply s) ps)
        let! ss = defaultSubst ce [] rs 
        let s' = substOfList ss
        let bigs = List.collect toBindingGroup bgs'
        let valdefMapper (bg : ValDef<'a * Type option>) =
            bg.Map (fun (c,t) -> (c,Option.map (apply (s'@@s)) t))
        return (List.map (apply (s'@@s)) as', bigs |> List.map valdefMapper)
    }
    runTI ti
    
let typeCheck imported (typeSigs : TypeSig<'a> list) (vdss : ValDef<'a> list list) =
    let assumptions = imported //Maybe do something here
    let vdToBG vds =
        let isExpl vd =
            match vd with
            | MergedValDef (_,n,alts) ->
                match List.tryFind (fun (TypeSig (_,m,_)) -> identEq n m) typeSigs with
                | Some (TypeSig (_,_,t)) -> [(n,toScheme <| typeRepresentation t, alts)]
                | None -> []
            | _ -> raise ImpossibleException
        let isImpl vd =
            match vd with
            | MergedValDef (_,n,alts) ->
                match List.tryFind (fun (TypeSig (_,m,_)) -> identEq n m) typeSigs with
                | Some _ -> []
                | None -> [ImplFun (n,alts)]
            | _ -> raise ImpossibleException
        let expls = vds |> List.collect isExpl
        let impls = vds |> List.collect isImpl
        (expls,[impls])
    let bgs : BindGroup<'a> list = List.map vdToBG vdss
    //printfn "BIND GROUPS\n%A" bgs
    tiProgram (addPreludeClasses (emptyClassEnv ()) |> Option.get) assumptions bgs

let toBindingGroup (expls,implss) =
    let fromExpl (i:Ident<'a>,s,alts) =
        MergedValDef (i.Context,i,alts) //TODO better context
    let fromImpl i =
        match i with
        | ImplFun (i,alts) ->
            MergedValDef (i.Context, i, alts) //TODO better context
        | ImplPat (p,e) -> raise ImpossibleException
    (List.map fromExpl expls) @ (List.map fromImpl (List.concat implss))


let typeCheckModule (imtypes, imconstrs, imvals, imass) (modul:Module<Position>) = //: Result<Module<Position * Type option>,TypeCheckingError<Position>> =
    let (Module (name,exporto,infixs,defs)) = modul
    let types, signatures, valDefs =
        let rec partition ds tds vds tss =
            match ds with
            | [] -> (tds, tss, vds)
            | h::t ->
                match h with
                | TypeDefinition td  -> partition t (td::tds) vds tss
                | ValueDefinition vd -> partition t tds (vd::vds) tss
                | TypeSignature ts   -> partition t tds vds (ts::tss)
        partition defs [] [] []
    result {
        let! (types, constrs) = checkTypeDefs imtypes types
        //printfn "TYPES\n%A\n\nCONSTRUCTORS\n%A" types constrs
        let! sortedValDefs = groupValueDeclarations imvals (List.map fst (constrs @ imconstrs)) valDefs
        let! (ass, bgs) = typeCheck imass signatures sortedValDefs UndefPos {Constructors = Map.ofList (List.map (fun (Ident(_,n),a) -> (n,a)) (constrs @ imconstrs))}
        let names = bgs |> List.map (fun (MergedValDef (_,n,_)) -> n.Map fst)
        return (types, constrs, names, ass, bgs)
    }

let builtIns = 
    let x f t : Ident<'a> * Assump = (f, Ass (f.Value, toScheme <| typeRepresentation t))
    let y f tt : Ident<'a> * Assump = (f, Ass (f.Value, toScheme tt))
    let bt s = Ident (BuiltIn, s)
    let v a = TVar (Tyvar (a,Star))
    
    let listCons = y (bt ":") (fn (v "a") (fn (list (v "a")) (list (v "a"))))
    let listNil = y (bt "[]") (list (v "a"))
    let lt = y (bt "<") (fn tInt (fn tInt tBool))
    (Set.ofList [bt "Int"],
     [listCons; listNil],
     [fst listCons; fst lt],
     [snd listCons; snd lt])
// run type-inferencing algorithm on a group of values
//
// Everything should be contained in a function
// typeCheck: 
//     Program Position -> Result<TypingError, Program (Position * Type option)>
//