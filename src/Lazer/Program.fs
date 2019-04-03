// Learn more about F# at http://fsharp.org

open System
open FParsec
open FParsec.Indent
open FParsec.Utils

open Model
open Parser
open ResultMonad
open TypeCheck

[<EntryPoint>]
let main argv =
    let res = runParserOnStream pModule defaultState "stdin" (Console.OpenStandardInput())
    let r = toResult res
    //printfn "%A" (r |> Result.map (fun x -> x.Map ignore))

    let t = result {
        let! p = r
        let tc = typeCheckModule builtIns p
        return! Result.mapError (string) tc
      }

    printfn "%A" t

    0 // return an integer exit code
