// Learn more about F# at http://fsharp.org

open System
open FParsec
open FParsec.Indent
open FParsec.Utils

open Model
open Parser

[<EntryPoint>]
let main argv =
    let result = runParserOnStream pModule defaultState "stdin" (Console.OpenStandardInput())
    printfn "%A" (toResult result |> Result.map (fun x -> x.Map ignore))
    0 // return an integer exit code
