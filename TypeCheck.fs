module TypeCheck

open ResultMonad

open Model

//          this->(label, dependsOn)
// topoSort : (a -> (b, [b])) -> [a] -> [[a]]  where b : comparable
let topoSort f l = [[null]] //TODO

let checkReferencedTypesExist a = result.Return () //TODO
let checkReduplication a = result.Return () //TODO

let flatten a = List.collect id a

// check type declarations
let checkTypeDefs (ts : TypeDef<'a> list) = result {
    let sortedDefs = topoSort () ts
    do! checkReferencedTypesExist sortedDefs
    do! checkReduplication sortedDefs
    return flatten sortedDefs
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