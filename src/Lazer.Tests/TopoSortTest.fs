namespace Tests

open NUnit.Framework

open Algorithms

[<TestFixture>]
type TopoSortTest () =

    [<Test>]
    member this.``Test topoSort on empty list`` () =
        let empty _ = ((), [])
        Assert.True([] = topoSort (=) empty [])

    [<Test>]
    member this.``Test topoSort simple example`` () =
        let f x =
            match x with
            | 1 -> (1, [2])
            | 2 -> (2, [])
        Assert.True([[2];[1]] = topoSort (=) f [1;2])

    [<Test>]
    member this.``Test topoSort typeDefCheck relevant example`` () =
        let f x =
            match x with
            | 1 -> ("T", ["Int";"B"])
            | 2 -> ("B", ["Int"])
            | 3 -> ("F", ["H"])
            | 4 -> ("H", ["F"])
        match topoSort (=) f [1..4] with
        | [[2];[1];[3;4]] -> Assert.Pass()
        | [[2];[1];[4;3]] -> Assert.Pass()
        | x -> Assert.Fail(sprintf "Expected [[2];[1];[3;4]], got %A" x)