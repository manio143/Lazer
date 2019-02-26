module FParsec.Expr

open FParsec
open FParsec.Utils

type Assoc = AssocNone | AssocLeft | AssocRight

type Operator<'a, 'u> =
    | Infix of Parser<('a -> 'a -> 'a),'u> * Assoc
    | Prefix of Parser<('a -> 'a),'u>
    | Postfix of Parser<('a -> 'a),'u>

type OperatorTable<'a, 'u> = Operator<'a, 'u> list list

let binaryOp name f assoc = Infix ((op name >>. result f), assoc)
let prefixOp name f       = Prefix (op name >>. result f)
let postfixOp name f      = Postfix (op name >>. result f)

let private splitOp op (r,l,n,pre,post) =
    match op with
    | Infix (p,assoc) ->
        match assoc with
        | AssocNone -> (r,l,p::n,pre,post)
        | AssocLeft -> (r,p::l,n,pre,post)
        | AssocRight -> (p::r,l,n,pre,post)
    | Prefix p -> (r,l,n,p::pre,post)
    | Postfix p -> (r,l,n,pre,p::post)

let buildExpressionParser (operators : OperatorTable<'a, 'u>) (simpleExpr : Parser<'a, 'u>) =
    let makeParser term ops =
        let (rassoc, lassoc, nassoc, prefix, postfix) =
            List.foldBack splitOp ops ([], [], [], [], [])
        
        let rassocOp = choice rassoc
        let lassocOp = choice lassoc
        let nassocOp = choice nassoc
        let prefixOp = choice prefix <?> ""
        let postfixOp = choice postfix <?> ""
        
        let ambigious assoc op = attempt <| parse {
            let! _ = op
            return! fail (sprintf "ambiguous use of a %s associative operator" assoc)
        }
        
        let ambigiousRight = ambigious "right" rassocOp
        let ambigiousLeft = ambigious "left" lassocOp
        let ambigiousNon = ambigious "non" nassocOp
        
        let prefixP = prefixOp <|> parse.Return id
        let postfixP = postfixOp <|> parse.Return id

        let rec termP = 
            parse {
                let! pre = prefixP
                let! x = term
                let! post = postfixP
                return post (pre x)
            }
        and rassocP x =
            parse {
                let! f = rassocOp
                let! y = termP >>= rassocP1
                return (f x y)
            }
            <|> ambigiousLeft
            <|> ambigiousNon
        and rassocP1 x = rassocP x <|> parse.Return x
        and lassocP x =
            parse {
                let! f = lassocOp
                let! y = termP
                return! lassocP1 (f x y)
            }
            <|> ambigiousRight
            <|> ambigiousNon
        and lassocP1 x = lassocP x <|> parse.Return x
        and nassocP x =
            parse {
                let! f = nassocOp
                let! y = termP
                return! (ambigiousRight
                         <|> ambigiousLeft
                         <|> ambigiousNon
                         <|> parse.Return (f x y))
            }

        parse {
            let! x = termP
            return! (rassocP x <|> lassocP x <|> nassocP x <|> parse.Return x) <?> "operator"
        }
    List.fold makeParser simpleExpr operators