module Parser

#nowarn "40"

open System
open FParsec
open FParsec.Indent
open FParsec.Utils
open FParsec.Expr

open Model

let rec init = function
    | [] -> []
    | [x] -> []
    | (h::t) -> h :: (init t)

let makePos (pb:FParsec.Position) (pe:FParsec.Position) =
    Pos ((pb.Line, pb.Column), (pe.Line, pe.Column), pb.StreamName)
let posCombine (Pos (beg, _, f)) (Pos (_, e, _)) = Pos (beg, e, f)

let builtIdent s = Ident (BuiltIn, s)

type ParserState = {Operators : OperatorTable<Expr<Position>,IndentState<ParserState>>}

let mapAssoc = function
    | AssLeft -> AssocLeft
    | AssRight -> AssocRight
    | AssNone -> AssocNone
let binaryConstr op (el:Expr<_>) (er:Expr<_>) =
    EBinOp (posCombine el.Context er.Context, op, el, er)
let unaryConstr (op:Ident<_>) (el:Expr<_>) =
    EUnOp (el.Context, op, el)
let addAt idx a l =
    List.mapi (fun i l -> if i = idx then a::l else l) l
let addOp (lvl, Ident (p,op), ass) (st : ParserState) = 
    {st with Operators = addAt lvl (binaryOp op (binaryConstr (Ident (p,op))) (mapAssoc ass)) st.Operators}
let addUnOp (lvl, Ident (p,op)) (st : ParserState) =
    {st with Operators = addAt lvl (prefixOp op (unaryConstr (Ident (p,op)))) st.Operators}

let defaultState = 
    let initial = {Operators = [for i in [1..10] -> []]}
    let unOps = [
        (4, builtIdent "-")
    ]
    let binOps = [
        (6, builtIdent "*", AssLeft)
        (6, builtIdent "/", AssLeft)
        (7, builtIdent "+", AssLeft)
        (7, builtIdent "-", AssLeft)
        (5, builtIdent "**", AssRight)
        (5, builtIdent "&&", AssLeft)
        (6, builtIdent "||", AssLeft)
        (8, builtIdent ">", AssNone)
        (8, builtIdent ">=", AssNone)
        (8, builtIdent "<", AssNone)
        (8, builtIdent "<=", AssNone)
        (8, builtIdent "==", AssNone)
        (3, builtIdent ":", AssRight)
    ]
    let withBin = List.fold (fun acc e -> addOp e acc) initial binOps
    let withUn = List.fold (fun acc e -> addUnOp e acc) withBin unOps
    withUn
    

let getStartPos = spaces >>. getPosition
let getEndPos = getPosition .>> spaces

let withPos p = parse {
    let! pB = getStartPos
    let! x = p
    let! pE = getEndPos
    return (makePos pB pE, x)
}

let reserved = ["let"; "in";"if";"then";"else"]

let valIdent = withPos (ident reserved asciiLower) |>> Ident <?> "identifier"
let typeIdent = withPos (ident reserved asciiUpper) |>> Ident <?> "type identifier"
let constrIdent = typeIdent <?> "constructor"
let dottedIdent = withPos (dottedIdent [] asciiLetter) |>> Ident <?> "dotted identifier"

let pExport = withPos (keyword "export" >>. parens (sepBy1 (valIdent <|> typeIdent) comma)) |>> Export <?> "export declaration"



let listType = TUnion (Ident (BuiltIn, "[]"))
let tupleIdent i = 
    let ident = String.Concat ('(' :: List.replicate (i-1) ',' @ [')'])
    Ident (BuiltIn, ident)
let tupleType = TUnion << tupleIdent

let pTVar = valIdent |>> TVar
let pTUnion = typeIdent |>> TUnion
let rec pTArr = parse {
    let! pB = getStartPos
    let! t = brackets pType
    let! pE = getStartPos
    return TApp (makePos pB pE, listType, [t])
  }
and pTTuple = parse {
    let! pB = getStartPos
    let! t = parens (sepBy2 pType comma)
    let! pE = getStartPos
    return TApp (makePos pB pE, tupleType (List.length t), t)
  }
and pType = 
    parse {
        let! pB = getStartPos
        let! t = pTVar <|> pTUnion <|> pTArr <|> pTTuple <|> parens pType
        let! arrow = maybe (op  "->")
        match arrow with
        | Some _ ->
            let! rest = pType
            let! pE = getStartPos
            return TFunction (makePos pB pE, t, rest)
        | None -> return t
    } <?> "type"

let pUnionAlt = parse {
    let! pB = getStartPos
    let! ident = typeIdent
    let! parameters = many pType
    let! pE = getStartPos
    return UAlt (makePos pB pE, ident, parameters)
}

let pDataDef = parse {
    let! pB = getStartPos
    let! _ = keyword "data"
    let! name = typeIdent
    let! _ = op "="
    let! _ = maybe <| greater pB (op "|")
    let! alts = greater pB <| sepBy (pUnionAlt) (op "|")
    let! pE = getEndPos
    return DataDef (makePos pB pE, name, alts)
}

let pAliasDef = parse {
    let! pB = getStartPos
    let! _ = keyword "type"
    let! name = typeIdent
    let! _ = op "="
    let! t = greater pB pType
    let! pE = getEndPos
    return AliasDef (makePos pB pE, name, t)
}

let pTypeDef = (pDataDef <|> pAliasDef) <?> "type declaration"

let pTypeSig = 
    parse {
        let! pB = getStartPos
        let! id = valIdent
        let! _ = op "::"
        let! t = greater pB pType
        let! pE = getStartPos
        return TypeSig (makePos pB pE, id, t)
    } <?> "type signature"

let rec pPattern = 
    parse {
        return! pPVar <|> pPConstr <|> pPList <|> pPListHead <|> pPTuple <|> parens pPattern
    } <?> "binding pattern"
and pPVar = valIdent |>> PVar
and pPConstr =
    let pC = parse {
        let! (pos, c) = withPos constrIdent
        return PConstr (pos, c, [])
    }
    let pCA = parse {
        let! (pos,(c,ps)) = withPos <| parens (constrIdent .>>. many1 pPattern)
        return PConstr (pos, c, ps)
    }
    pC <|> attempt pCA
and pPList = attempt <| parse {
    let! pB = getStartPos
    let! pats = brackets (sepBy (getStartPos .>>. pPattern) comma)
    let! pE = getEndPos
    if List.isEmpty pats then
        return PConstr (makePos pB pE, builtIdent "[]", [])
    else
    let f pB ps = PConstr (makePos pB pE, builtIdent ":", ps)
    let rest = List.foldBack (fun (pB, p) acc -> f pB [p; acc]) (List.tail pats |> init) (snd (List.last pats))
    return PConstr (makePos pB pE, builtIdent ":", [snd <| List.head pats; rest])
  }
and pPListHead = attempt <| parse {
    let! pB = getStartPos
    let! pats = parens (sepBy2 (getStartPos .>>. pPattern) colon)
    let! pE = getEndPos
    let f pB ps = PConstr (makePos pB pE, builtIdent ":", ps)
    let rest = List.foldBack (fun (pB, p) acc -> f pB [p; acc]) (List.tail pats |> init) (snd (List.last pats))
    return PConstr (makePos pB pE, builtIdent ":", [snd <| List.head pats; rest])
  }
and pPTuple = attempt <| parse {
    let! (pos, ps) = withPos <| parens (sepBy2 pPattern comma)
    return PConstr (pos, tupleIdent (List.length ps), ps)
}

let pParensOp = parse {
    let! (pos, op) = withPos <| parens operator
    return Ident (pos, op)
}

let pLInt = withPos integer64 |>> LInt
let pLChar = withPos (str "\'" >>. escapedChar .>> pchar '\'') |>> LChar
let pLStr = withPos(str "\"" >>. many escapedChar .>> pchar '\"') |>> (LString << fun (p,cs) -> (p, String.Concat cs))
let pLit = 
    parse {
        return! pLInt <|> pLChar <|> pLStr
    } <?> "literal"

let rec pExpr = pOp <?> "expresion"
and pOp = parse {
    let! st = getUserState
    return! buildExpressionParser (st.Operators) pEApp
  }
and pEApp = chainl1 pESimple <| parse {
    return fun (l:Expr<_>) (r:Expr<_>) ->
        EApp (posCombine l.Context r.Context, l, r)
  }
and pESimple = parse {
    return! pELit <|> pEConstr <|> pEList <|> pETuple <|> pELet <|> pEIf <|> pEVar <|> pELambda <|> (attempt pParensOp |>> EVar) <|> parens pExpr
  }
and pELit = pLit |>> ELiteral
and pEVar = attempt valIdent |>> EVar
and pEConstr = typeIdent |>> EConstr
and pEList = parse {
    let! (pos, es) = withPos <| brackets (sepBy pExpr comma .>> maybe comma)
    return EMultiConstr (pos, builtIdent "[]", es)
  }
and pETuple = attempt <| parse {
    let! (pos, es) = withPos <| parens (sepBy2 pExpr comma)
    return EMultiConstr (pos, tupleIdent (List.length es), es)
  }
and pELet = parse {
    let! pB = getStartPos
    let! _ = keyword "let"
    let! p = pPattern
    let! _ = op "="
    let! eb = pExpr
    let! _ = keyword "in"
    let! ec = atLeast pB pExpr
    let! pE = getEndPos
    match p with
    | PVar n -> 
        return ELet (makePos pB pE, BindGroup (posCombine p.Context eb.Context, [BFun(posCombine p.Context eb.Context, n, [], eb)]), ec)
    | _ ->
        return ELet (makePos pB pE, BindGroup (posCombine p.Context eb.Context, [BPat(posCombine p.Context eb.Context, p, eb)]), ec)
  }
and pEIf = parse {
    let! pB = getStartPos
    let! _ = keyword "if"
    let! c = pExpr
    let! _ = keyword "then"
    let! t = greater pB pExpr
    let! _ = keyword "else"
    let! f = greater pB pExpr
    let! pE = getEndPos
    return EIf (makePos pB pE, c, t, f)
  }
and pELambda = parse {
    let inner = parse {
        let! _ = op "\\"
        let! id = pPattern
        let! _ = op "->"
        let! e = pExpr
        return (id, e)
    }
    let! (pos, (id, e)) = withPos inner
    return ELambda (pos, id, e)
  }

let pValDef = 
    parse {
        let! pB = getStartPos
        let! id = valIdent <|> pParensOp
        let! pats = many pPattern
        let! _ = op "="
        let! e = greater pB pExpr
        let! pE = getEndPos
        return ValDef (makePos pB pE, id, pats, e)
    } <?> "value definition"

let pDef =
    pTypeDef |>> TypeDefinition
    <|> (attempt pTypeSig |>> TypeSignature)
    <|> (pValDef |>> ValueDefinition)

let pInfix = 
    let part (k, f) = parse {
        do! keyword k
        let! level = integer
        if level >= 10 || level < 0 then
            return! fail "operator precedence must be in range [0..9]"
        else
            let! op = withPos (parens (operator)) |>> Ident
            return (level, op, f)
    }
    let inner = part ("infixl", AssLeft) <|> part ("infixr", AssRight) <|> part ("infix", AssNone)
    parse {
        let! (pos, (level, op, ass)) = withPos inner
        do! modifyUserState (addOp (level, op, ass))
        return Infix (pos, ass, level, op)
    } <?> "infix declaration"

let pModule = parse {
    do! spaces
    do! keyword "module"
    let! name = dottedIdent <?> "module name"
    let! exp = maybe pExport
    let! ops = many pInfix
    let! defs = many1 pDef
    do! eof
    return Module (name, exp, ops, defs)
}