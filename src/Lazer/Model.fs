module Model

type Position = Pos of Begin : (int64 * int64)
                     * End   : (int64 * int64)
                     * File  : string
              | BuiltIn | UndefPos

type Ident<'a> = Ident of Ctx   : 'a
                        * Ident : string

type DottedIdent<'a> = Ident<'a> //TODO ?

type Export<'a> = Export of Ctx       : 'a
                          * Elements  : Ident<'a> list

type Assoc = AssLeft | AssRight | AssNone

type Infix<'a> = Infix of Ctx    : 'a
                        * Assoc  : Assoc
                        * Level  : int
                        * Op     : Ident<'a>

type Type<'a> = TVar of Ident<'a>
              | TUnion of Ident<'a>
              | TFunction of Context : 'a
                           * From    : Type<'a>
                           * To      : Type<'a>
              | TApp of Context : 'a
                      * Type    : Type<'a>
                      * Param   : Type<'a> list

type UnionAlt<'a> = UAlt of Ctx        : 'a
                          * Name       : Ident<'a>
                          * Parameters : Type<'a> list

type TypeDef<'a> = DataDef of Context : 'a
                            * Name    : Ident<'a>
                            * Alts    : UnionAlt<'a> list
                 | AliasDef of Context : 'a
                             * Name    : Ident<'a>
                             * Type    : Type<'a>

type TypeSig<'a> = TypeSig of Ctx   : 'a
                            * Name  : Ident<'a>
                            * Type  : Type<'a>

type Literal<'a> = LInt of Context : 'a
                         * Value   : int64
                 | LChar of Context : 'a
                          * Value   : char
                 | LString of Context : 'a
                            * Value   : string

type Pattern<'a> = PVar of Ident<'a>
                 | PWildcard of Ctx : 'a
                 | PLit of Literal<'a>
                 | PConstr of Context    : 'a
                            * ConstrName : Ident<'a>
                            * Patterns   : Pattern<'a> list

type Binding<'a> = BSig of TypeSig<'a>
                 | BFun of Context : 'a
                         * Name    : Ident<'a>
                         * Patterns: Pattern<'a> list
                         * BExpr   : Expr<'a>
                 | BPat of Context : 'a
                         * Pattern : Pattern<'a>
                         * BExpr   : Expr<'a>
and BindingGroup<'a> = BindGroup of 'a * Binding<'a> list

and Expr<'a> = EVar of Ident<'a>
              | EConstr of Ident<'a>
              | ELiteral of Literal<'a>
              | ELet of Context   : 'a
                      * BindGroup : BindingGroup<'a>
                      * IExpr     : Expr<'a>
              | EIf of Context : 'a
                     * Cond    : Expr<'a>
                     * Then    : Expr<'a>
                     * Else    : Expr<'a>
              | EMultiConstr of Context : 'a
                             * Constr  : Ident<'a>
                             * Exps    : Expr<'a> list
              | EApp of Context : 'a
                      * Expr<'a> * Expr<'a>
              | ELambda of Context : 'a
                         * Pattern : Pattern<'a>
                         * Expr    : Expr<'a>
              | EBinOp of Context : 'a
                        * Op      : Ident<'a>
                        * Left    : Expr<'a>
                        * Right   : Expr<'a>
              | EUnOp of Context : 'a
                       * Op      : Ident<'a>
                       * Element : Expr<'a>

type ValDef<'a> = ValDef of Ctx        : 'a
                          * Name       : Ident<'a>
                          * Patterns   : Pattern<'a> list
                          * Expression : Expr<'a>
                | MergedValDef of Ctx  : 'a
                                * Name : Ident<'a>
                                * (Pattern<'a> list * Expr<'a>) list

type Definition<'a> = TypeDefinition of TypeDef<'a>
                    | ValueDefinition of ValDef<'a>
                    | TypeSignature of TypeSig<'a>

type Module<'a> = Module of Name    : DottedIdent<'a>
                          * Export  : Export<'a> option
                          * Infix   : Infix<'a> list
                          * Defs    : Definition<'a> list

type Program<'a> = Program of Module<'a> list

module Model =
    let mapModule (Program ms) f =
        List.map f ms |> Program
    let mapValue p f =
        let mapVD = function
            | ValueDefinition v -> ValueDefinition (f v)
            | x -> x
        let g (Module (ctx, n, e, ds)) =
            Module (ctx, n, e, List.map mapVD ds)
        mapModule p g
    let mapExpr p f =
        let g (ValDef (ctx, n, p, exp)) =
            ValDef (ctx, n, p, f exp)
        mapValue p g

type Literal<'a> with
    member this.Context =
        match this with
        | LInt (ctx, _) -> ctx
        | LChar (ctx, _) -> ctx
        | LString (ctx, _) -> ctx
    member this.Map (f : 'a -> 'b) =
        match this with
        | LInt (ctx, i) -> LInt (f ctx, i)
        | LChar (ctx, c) -> LChar (f ctx, c)
        | LString (ctx, s) -> LString (f ctx, s)

type Ident<'a> with
    member this.Context =
        match this with
        | Ident (ctx,_) -> ctx
    member this.Value =
        match this with
        | Ident (_, n) -> n
    member this.Map (f : 'a -> 'b) =
        match this with
        | Ident (ctx, s) -> Ident (f ctx, s)

type Export<'a> with
    member this.Context =
        match this with
        | Export (ctx, _) -> ctx
    member this.Map (f : 'a -> 'b) =
        match this with
        | Export (ctx, li) -> Export (f ctx, li |> List.map (fun i -> i.Map f))

type Infix<'a> with
    member this.Context =
        match this with
        | Infix (ctx, a, l, li) -> ctx
    member this.Map (f : 'a -> 'b) =
        match this with
        | Infix (ctx, a, l, i) -> Infix (f ctx, a, l, i.Map f)


type Type<'a> with
    member this.Context =
        match this with
        | TVar (Ident (ctx,_)) -> ctx
        | TUnion (Ident (ctx,_)) -> ctx
        | TFunction (ctx, ff, t) -> ctx
        | TApp (ctx, t, p) -> ctx
    member this.Map f =
        match this with
        | TVar id -> TVar (id.Map f)
        | TUnion id -> TUnion (id.Map f)
        | TFunction (ctx, ff, t) -> TFunction (f ctx, ff.Map f, t.Map f)
        | TApp (ctx, t, p) -> TApp (f ctx, t.Map f, p |> List.map (fun x -> x.Map f))

type UnionAlt<'a> with
    member this.Context =
        match this with
        | UAlt (ctx, i, ps) -> ctx
    member this.Map f =
        match this with
        | UAlt (ctx, i, ps) -> UAlt (f ctx, i.Map f, ps |> List.map (fun x -> x.Map f))

type TypeDef<'a> with
    member this.Context =
        match this with
        | DataDef (ctx, i, uas) -> ctx
        | AliasDef (ctx, i, t) -> ctx
    member this.Map f =
        match this with
        | DataDef (ctx, i, uas) -> DataDef (f ctx, i.Map f, uas |> List.map (fun x -> x.Map f))
        | AliasDef (ctx, i, t) -> AliasDef (f ctx, i.Map f, t.Map f)

type TypeSig<'a> with
    member this.Context =
        match this with
        | TypeSig (ctx, i, t) -> ctx
    member this.Map f =
        match this with
        | TypeSig (ctx, i, t) -> TypeSig (f ctx, i.Map f, t.Map f)

type Pattern<'a> with
    member this.Context =
        match this with
        | PVar id -> id.Context
        | PWildcard ctx -> ctx
        | PLit l -> l.Context
        | PConstr (ctx, i, ps) -> ctx
    member this.Map f =
        match this with
        | PVar id -> PVar (id.Map f)
        | PWildcard ctx -> PWildcard (f ctx)
        | PLit l -> PLit (l.Map f)
        | PConstr (ctx, i, ps) -> PConstr (f ctx, i.Map f, ps |> List.map (fun x -> x.Map f))

type Binding<'a> with
    member this.Context =
        match this with
        | BSig s -> s.Context
        | BFun (ctx,_,_,_) -> ctx
        | BPat (ctx,_,_) -> ctx
    member this.Map<'b> (f : 'a -> 'b) : Binding<'b> =
        match this with
        | BSig s -> BSig (s.Map f)
        | BFun (ctx, n,ps,e) -> BFun (f ctx, n.Map f, ps |> List.map (fun x -> x.Map f), e.Map f)
        | BPat (ctx,p,e) -> BPat (f ctx, p.Map f, e.Map f)
and BindingGroup<'a> with
    member this.Context =
        match this with
        | BindGroup (ctx,bs) -> ctx
    member this.Map<'b> (f : 'a -> 'b) : BindingGroup<'b> =
        match this with
        | BindGroup (ctx,bs) -> BindGroup (f ctx, bs |> List.map (fun x -> x.Map f))
and Expr<'a> with
    member this.Context =
        match this with
        | EVar (Ident (ctx,_)) -> ctx
        | EConstr (Ident (ctx, _)) -> ctx
        | ELiteral lit -> lit.Context
        | ELet (ctx, _, _) -> ctx
        | EIf (ctx, _, _, _) -> ctx
        | EMultiConstr (ctx, _, _) -> ctx
        | EApp (ctx, _, _) -> ctx
        | ELambda (ctx, _, _) -> ctx
        | EBinOp (ctx, _, _, _) -> ctx
        | EUnOp (ctx, _, _) -> ctx
    member this.Map<'b> (f : 'a -> 'b) : Expr<'b> =
        match this with
        | EVar id -> EVar (id.Map f)
        | EConstr id -> EVar (id.Map f)
        | ELiteral lit -> ELiteral (lit.Map f)
        | ELet (ctx, bg, i) -> ELet (f ctx, bg.Map f, i.Map f)
        | EIf (ctx, c, t, ff) -> EIf (f ctx, c.Map f, t.Map f, ff.Map f)
        | EMultiConstr (ctx, c, es) -> EMultiConstr (f ctx, c.Map f, es |> List.map (fun x -> x.Map f))
        | EApp (ctx, el, er) -> EApp (f ctx, el.Map f, er.Map f)
        | ELambda (ctx, p, e) -> ELambda (f ctx, p.Map f, e.Map f)
        | EBinOp (ctx, op, l, r) -> EBinOp (f ctx, op.Map f, l.Map f, r.Map f)
        | EUnOp (ctx, op, e) -> EUnOp (f ctx, op.Map f, e.Map f)

type ValDef<'a> with
    member this.Context =
        match this with
        | ValDef (ctx, i, ps, e) -> ctx
        | MergedValDef (ctx,_,_) -> ctx
    member this.Name =
        match this with
        | ValDef (_, id,_,_) -> id
        | MergedValDef (_, id,_) -> id
    member this.Map (f : 'a -> 'b) =
        match this with
        | ValDef (ctx, i, ps, e) -> ValDef (f ctx, i.Map f, ps |> List.map (fun x -> x.Map f), e.Map f)
        | MergedValDef (ctx, i, p) -> MergedValDef (f ctx, i.Map f, p |> List.map (fun (a,b) -> (a |> List.map (fun x -> x.Map f), b.Map f)))
    
type Definition<'a> with
    member this.Context =
        match this with
        | TypeDefinition td -> td.Context
        | ValueDefinition vd -> vd.Context
        | TypeSignature ts -> ts.Context
    member this.Map (f : 'a -> 'b) =
        match this with
        | TypeDefinition td -> TypeDefinition (td.Map f)
        | ValueDefinition vd -> ValueDefinition (vd.Map f)
        | TypeSignature ts -> TypeSignature (ts.Map f)
    
type Module<'a> with
    member this.Map (f : 'a -> 'b) =
        match this with
        | Module (n, ex, ixs, defs) -> Module (n.Map f, ex |> Option.map (fun e -> e.Map f), ixs |> List.map (fun x -> x.Map f), defs |> List.map (fun x -> x.Map f))

type Program<'a> with
    member this.Map (f : 'a -> 'b) =
        match this with
        | Program ms -> Program (ms |> List.map (fun x -> x.Map f))
