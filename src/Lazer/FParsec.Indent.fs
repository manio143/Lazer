module FParsec.Indent

open FParsec

  type Indentation = 
      | Fail
      | Any
      | Greater of Position 
      | Exact of Position 
      | AtLeast of Position 
      | StartIndent of Position
      with
        member this.Position = match this with
                               | Any | Fail -> None
                               | Greater p -> Some p
                               | Exact p -> Some p
                               | AtLeast p -> Some p
                               | StartIndent p -> Some p

  type IndentState<'T> = { Indent : Indentation; UserState : 'T }
  type IndentParser<'T, 'UserState> = Parser<'T, IndentState<'UserState>>

  let indentState u = {Indent = Any; UserState = u}
  let runParser p u s = runParserOnString p (indentState u) "" s
  let runParserOnStream p u n s = runParserOnStream p (indentState u) n s (System.Text.Encoding.UTF8)
  let runParserOnFile p u path = runParserOnFile p (indentState u) path System.Text.Encoding.UTF8

  let getIndentation : IndentParser<_,_> =
    fun stream -> match stream.UserState with
                  | {Indent = i} -> Reply i
  let getUserState : IndentParser<_,_> =
    fun stream -> match stream.UserState with
                  | {UserState = u} -> Reply u

  let putIndentation newi : IndentParser<unit, _> =
    fun stream ->
      stream.UserState <- {stream.UserState with Indent = newi}
      Reply(Unchecked.defaultof<unit>)
  let putUserState st : IndentParser<unit, _> =
    fun stream ->
      stream.UserState <- {stream.UserState with UserState = st}
      Reply(Unchecked.defaultof<unit>)

  let modifyUserState f = getUserState >>= (putUserState << f)

  let failf fmt = fail << sprintf fmt

  let acceptable i (pos : Position) =
    match i with
    | Any -> true
    | Fail -> false
    | Greater bp -> bp.Column < pos.Column
    | Exact ep -> ep.Column = pos.Column
    | AtLeast ap -> ap.Column <= pos.Column
    | StartIndent _ -> true

  let nestableIn i o =
    match i, o with
    | Greater i, Greater o -> o.Column < i.Column
    | Greater i, Exact o -> o.Column < i.Column
    | Exact i, Exact o -> o.Column = i.Column
    | Exact i, Greater o -> o.Column <= i.Column
    | _, _ -> true

  let lineComment<'u> : IndentParser<_,'u> =
    (pstring "//" >>. restOfLine true) |>> ignore <?> "comment"
  let multilineComment<'u> : IndentParser<_,'u> =
    between 
        (pstring "/*") 
        (pstring "*/") 
        (charsTillString "*/" false System.Int32.MaxValue)
    |>> ignore <?> "comment"
  let spaces<'u> : IndentParser<_,'u> = 
    skipMany (lineComment <|> multilineComment <|> spaces1)

  let tokeniser p = parse {
    let! pos = getPosition
    let! i = getIndentation
    if acceptable i pos then return! p .>> spaces
    else return! failf "incorrect indentation at %A" pos
  }

  let nestP i o p = parse {
    do! putIndentation i
    let! x = p
    do! notFollowedBy (tokeniser anyChar) <?> (sprintf "unterminated indentation")
    do! putIndentation o
    return x
  }

  let nest indentor p = parse {
    let! outerI = getIndentation
    let! curPos = getPosition
    let innerI = indentor curPos
    if nestableIn innerI outerI
    then return! nestP innerI outerI p
    else return! nestP Fail outerI p
  }

  let nestWithPos indentor pos p = parse {
    let! outerI = getIndentation
    let innerI = indentor pos
    if nestableIn innerI outerI
    then return! nestP innerI outerI p
    else return! nestP Fail outerI p
  }

  let neglectIndent p = parse {
    let! o = getIndentation
    do! putIndentation Any
    let! x = p
    do! putIndentation o
    return x
  }

  let checkIndent<'u> : IndentParser<unit, 'u> = tokeniser (preturn ())

  let indented<'a,'u> i pos (p : Parser<'a,_>) : IndentParser<_, 'u> = nestWithPos i pos (tokeniser p)

  let exact<'a,'u> pos p: IndentParser<'a, 'u> = indented Exact pos p
  let greater<'a,'u> pos p: IndentParser<'a, 'u> = indented Greater pos p
  let atLeast<'a,'u> pos p: IndentParser<'a, 'u> = indented AtLeast pos p
  let any<'a,'u> pos p: IndentParser<'a, 'u> = indented StartIndent pos p

  let newline<'u> : IndentParser<unit, 'u> = many (skipAnyOf " \t" <?> "whitespace") >>. newline |>> ignore

  let rec blockOf p = parse {
    do! spaces
    let! pos = getPosition    
    let! x = exact pos p
    let! xs = attempt (exact pos <| blockOf p) <|> preturn []
    return x::xs
  }