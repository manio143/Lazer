module FParsec.Utils

open System

open FParsec
open FParsec.Indent

let rec oneOf = function
    | [p] -> p
    | (h::t) -> h <|> oneOf t

let underscore<'u> : IndentParser<_,'u> = tokeniser <| pchar '_'
let dot<'u> : IndentParser<_,'u> = tokeniser <| pchar '.'
let comma<'u> : IndentParser<_,'u> = tokeniser <| pchar ','
let semi<'u> : IndentParser<_,'u> = tokeniser <| pchar ';'
let colon<'u> : IndentParser<_,'u> = tokeniser <| pchar ':'
let prim<'u> : IndentParser<_,'u> = tokeniser <| pchar '\''

let keyword str = tokeniser (pstring str >>? (notFollowedBy (oneOf [asciiLetter; digit ; underscore; prim]) <?> str))
let op str = tokeniser (pstring str >>? (nextCharSatisfiesNot (isAnyOf "!@#$%^&*()-+=?/><|") <?> str))

let operator<'u> : IndentParser<_, 'u> = tokeniser (many1 (anyOf "!@#$%^&*-+=?/><|") |>> String.Concat)

let integer<'u> : IndentParser<int32, 'u> = tokeniser pint32
let integer64<'u> : IndentParser<int64, 'u> = tokeniser pint64

let (=<<) a b = b >>= a

let result x = parse { return x }

let maybe p = attempt (tokeniser p) |>> Some <|> parse.Return None

let chainl1 p op =
    let rec rest x = 
        parse {
            let! f = op
            let! y = p
            return! rest (f x y)
        } <|> result x
    tokeniser <| parse {
        let! x = p
        return! rest x
    }

let sepBy2 p s = tokeniser <| parse {
    let! f = p
    let! _ = s
    let! r = sepBy1 p s
    return (f::r)
}

let many p = tokeniser (many p)
let many1 p = tokeniser (many1 p)
let sepBy p s = tokeniser (sepBy p s)
let sepBy1 p s = tokeniser (sepBy1 p s)

let str s = tokeniser <| pstring s .>> spaces

let makeIdent (body: Parser<char,_>) reserved start = parse {
    let! s = start
    let! rest = many <| body
    let str = String.Concat (s::rest)
    if List.contains str reserved then
        return! fail <| sprintf "Unexpected reserved keyword '%s'" str
    else return str
}

let ident r s = tokeniser <| makeIdent (oneOf [asciiLetter; digit ; underscore; prim]) r s
let dottedIdent r s = tokeniser <| makeIdent (oneOf [asciiLetter; digit ; underscore; prim; dot]) r s

let delimitedStr s e = tokeniser << between (str s) (str e)
let parens p = delimitedStr "(" ")" p
let brackets p = delimitedStr "[" "]" p
let qoute p = delimitedStr "\"" "\"" p

let escapedChar<'u> : IndentParser<_,'u> =
    let escape = parse {
        let! d = pchar '\\'
        let! c = anyOf "\\\'\"nt"
        match c with
        | 'n' -> return '\n'
        | 't' -> return '\t'
        | _ -> return c
    }
    let nonEscape = noneOf "\\\'\"nt"
    tokeniser (nonEscape <|> escape)

let toResult c =
    match c with
    | Success (r,s,p) -> Result.Ok r
    | Failure (r,s,p) -> Result.Error r
