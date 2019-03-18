module ResultMonad

type ResultBuilder() =
    member z.Return(x) = Ok x
    member z.Bind(m, f) = Result.bind f m
    member z.ReturnFrom(m) = m
    member z.Delay(f:unit -> _) = f
    member z.Run(f) = f()
    member z.While(cond, f) =
        if cond() then z.Bind(f(), fun _ -> z.While(cond, f)) 
        else z.Zero()
    member z.Zero() = Ok ()
    member z.Combine(m, f:unit -> _) = z.Bind(m, f)
    member z.For(s, f) =
        Seq.map f s |> Seq.fold (fun l r -> z.Bind(l, fun _ -> r)) (z.Zero())
    member z.Fail(x) = Error x

let result = ResultBuilder()

let combineResults rl =
    let rec inner l sl el =
        match l with
        | h :: t ->
            match h with
            | Ok x -> inner t (x::sl) el
            | Error x -> inner t sl (x::el)
        | [] -> if List.isEmpty el then
                    Ok sl
                else
                    Error el
    inner rl [] []
