namespace Tests

open NUnit.Framework

open FParsec.Indent
open FParsec.Utils

open Model
open Parser
open ResultMonad
open TypeCheck

[<TestFixture>]
type TypeCheckTest () =

    let isSuccess r =
        match r with
        | Ok _ -> true
        | Error _ -> false

    [<SetUp>]
    member this.Setup () =
        ()

    [<Test>]
    member this.``Test checkRedefinition with empty list`` () =
        let value = []
        Assert.IsTrue(isSuccess (checkRedefinition value))

    [<Test>]
    member this.``Test checkRedefinition with good list`` () =
        let value = [
                DataDef ((), Ident ((), "A"), []) 
                DataDef ((), Ident ((), "B"), [])
                AliasDef ((), Ident ((), "C"), TUnion (Ident ((), "Int"))) 
            ]
        Assert.IsTrue(isSuccess (checkRedefinition value))

    [<Test>]
    member this.``Test checkRedefinition with bad list`` () =
        let value = [
                DataDef ((), Ident ((), "A"), []) 
                DataDef ((), Ident ((), "B"), [])
                AliasDef ((), Ident ((), "A"), TUnion (Ident ((), "Int"))) 
            ]
        Assert.IsFalse(isSuccess (checkRedefinition value))


    [<Test>]
    member this.``Test checkReferencedTypesExist with bad list`` () =
        let value = [
                AliasDef ((), Ident((), "A"), TUnion (Ident ((), "B")))
            ]
        Assert.IsFalse(isSuccess (checkReferencedTypesExist (Set.empty) value))

    [<Test>]
    member this.``Test checkReferencedTypesExist with good list`` () =
        let value = [
                AliasDef ((), Ident((), "A"), TUnion (Ident ((), "B")))
                DataDef ((), Ident((), "B"), [])
            ]
        Assert.IsTrue(isSuccess (checkReferencedTypesExist (Set.empty) value))

    [<Test>]
    member this.``Test checkReferencedTypesExist with bad list and imports set`` () =
        let sett = Set.add (Ident ((), "C")) Set.empty
        let value = [
                AliasDef ((), Ident((), "A"), TUnion (Ident ((), "B")))
            ]
        Assert.IsFalse(isSuccess (checkReferencedTypesExist sett value))

    [<Test>]
    member this.``Test checkReferencedTypesExist with good list and imports set`` () =
        let sett = Set.add (Ident ((), "B")) Set.empty
        let value = [
                AliasDef ((), Ident((), "A"), TUnion (Ident ((), "B")))
            ]
        Assert.IsTrue(isSuccess (checkReferencedTypesExist sett value))

    [<Test>]
    member this.``Test correct TypeDef set from string`` () =
        let text = 
            """
data T = W Int B
type B = Int
data F = R H
data H = E F | Q
            """
        let tdsr =
            runParser (many pTypeDef) defaultState text
            |> toResult
        let sett = Set.add (Ident (BuiltIn, "Int")) Set.empty
        let res =
            match tdsr with
            | Ok tds -> 
                Assert.AreEqual(
                    (Ident((),"T"), [Ident((),"Int"); Ident((), "B")]),
                    typeDefDependencies tds.Head
                    |> (fun (a,b) -> (a.Map ignore, b |> List.map (fun x -> x.Map ignore))))
                checkTypeDefs sett tds
            | Error s -> 
                Assert.Fail(sprintf "Error parsing test data\n%s" s)
                result.Return (Set.empty,[])
        match res with
        | Ok _ -> Assert.Pass()
        | Error e -> Assert.Fail(sprintf "%A" e)

    [<Test>]
    member this.``Test checkTypeDefs adds new to types to set`` () =
        let sett = Set.add (Ident ((), "B")) Set.empty
        let value = [
                AliasDef ((), Ident((), "A"), TUnion (Ident ((), "B")))
            ]
        let expected = Set.add (Ident ((),"A")) sett
        match checkTypeDefs sett value with
        | Ok (s,_) -> Assert.True(Set.isSubset expected s, sprintf "Expected set %A but got %A" expected s)
        | Error x -> Assert.Fail(sprintf "%A" x)