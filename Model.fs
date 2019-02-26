module Model

type Position = Pos of Begin : (int64 * int64)
                     * End   : (int64 * int64)
                     * File  : string
              | BuiltIn

type Ident<'a> = Ident of Ctx   : 'a
                        * Ident : string

type DottedIdent<'a> = Ident<'a> //TODO ?

type Export<'a> = Export of Context   : 'a
                          * Elements  : Ident<'a> list

type Assoc = AssLeft | AssRight | AssNone

type Infix<'a> = Infix of Context : 'a
                        * Assoc   : Assoc
                        * Level   : int
                        * Op      : Ident<'a>

type Type<'a> = TVar of Ident<'a>
              | TUnion of Ident<'a>
              | TFunction of Context : 'a
                           * From    : Type<'a>
                           * To      : Type<'a>
              | TApp of Context : 'a
                      * Type    : Type<'a>
                      * Param   : Type<'a> list

type UnionAlt<'a> = UAlt of Context    : 'a
                          * Name       : Ident<'a>
                          * Parameters : Type<'a> list

type TypeDef<'a> = DataDef of Context : 'a
                            * Name    : Ident<'a>
                            * Alts    : UnionAlt<'a> list
                 | AliasDef of Context : 'a
                             * Name    : Ident<'a>
                             * Type    : Type<'a>

type TypeSig<'a> = TypeSig of Context : 'a
                            * Name    : Ident<'a>
                            * Type    : Type<'a>

type Pattern<'a> = PVar of Ident<'a>
                 | PConstr of Context    : 'a
                            * ConstrName : Ident<'a>
                            * Patterns   : Pattern<'a> list

type Literal<'a> = LInt of Context : 'a
                         * Value   : int64
                 | LChar of Context : 'a
                          * Value   : char
                 | LString of Context : 'a
                            * Value   : string

type Expr<'a> = EVar of Ident<'a>
              | EConstr of Ident<'a>
              | ELiteral of Literal<'a>
              | ELet of Context : 'a
                      * Pattern : Pattern<'a>
                      * BExpr   : Expr<'a>
                      * IExpr   : Expr<'a>
              | EIf of Context : 'a
                     * Cond    : Expr<'a>
                     * Then    : Expr<'a>
                     * Else    : Expr<'a>
              | EMultiContr of Context : 'a
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

type ValDef<'a> = ValDef of Context    : 'a
                          * Name       : Ident<'a>
                          * Patterns   : Pattern<'a> list
                          * Expression : Expr<'a>

type Definition<'a> = TypeDefintion of TypeDef<'a>
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

type Ident<'a> with
    member this.Context =
        match this with
        | Ident (ctx,_) -> ctx

type Expr<'a> with
    member this.Context =
        match this with
        | EVar (Ident (ctx,_)) -> ctx
        | EConstr (Ident (ctx, _)) -> ctx
        | ELiteral lit -> lit.Context
        | ELet (ctx, _, _, _) -> ctx
        | EIf (ctx, _, _, _) -> ctx
        | EMultiContr (ctx, _, _) -> ctx
        | EApp (ctx, _, _) -> ctx
        | ELambda (ctx, _, _) -> ctx
        | EBinOp (ctx, _, _, _) -> ctx
        | EUnOp (ctx, _, _) -> ctx
