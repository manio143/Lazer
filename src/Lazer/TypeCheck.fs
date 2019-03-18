module TypeCheck

open Alogrithms
open ResultMonad

open Model

type TypeCheckingError<'a> = 
    | MultipleErrors of TypeCheckingError<'a> list
    | RedefinitionOfType of Name: string * Here: 'a * Prev: 'a
    | UndefinedType of Name: string * Here: 'a

let combineResults rl =
    let r = combineResults rl
    match r with
    | Ok x -> Ok x
    | Error l -> Error (MultipleErrors l)

let typeDefDependencies td =
    let rec namesFromType t =
        match t with
        | TVar _ -> []
        | TUnion id -> [id]
        | TFunction (_, f, tt) -> namesFromType f @ namesFromType tt
        | TApp (_, tt, ps) -> namesFromType tt @ List.collect namesFromType ps
    let namesFromAlt (UAlt (_, _, ts)) =
        List.collect namesFromType ts |> List.distinct
    match td with
    | DataDef (_, id, alts) -> 
        let deps = alts |> List.collect namesFromAlt |> List.distinct
        (id, deps)
    | AliasDef (_, id, t) ->
        let deps = List.distinct (namesFromType t)
        (id, deps)

let checkReferencedTypesExist imported (ts : TypeDef<'a> list) = result {
    let identEq (Ident (_,n)) (Ident (_,m)) = (n = m)
    let sorted = topoSortP identEq typeDefDependencies ts |> topoSortGroup identEq
    printfn "%A" sorted
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

// check type declarations
let checkTypeDefs imported ts = result {
    do! checkRedefinition ts
    do! checkReferencedTypesExist imported ts
}

// get a list of contructor signatures from types
// check signatures that their types exist
// sort and group value declarations by dependencies
// run type-inferencing algorithm on a group of values
//
// Everything should be contained in a function
// typeCheck: 
//     Program Position -> Result<TypingError, Program (Position * Type option)>
// 