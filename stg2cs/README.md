# stg2cs
This is a small executable application that uses GHC 8.6.4 to compile a file called `Example.hs` in the current directory and convert the STG representation into C# code that can be further compiled with the Lazer runtime.

Currently this utility is just meant to be a helping hand in compiling Haskell to C# - it's not a complete solution. The output is still meant to be manually fixed before applying the Roslyn compiler.

## Build & run

    stack build
    stack run

**Note**: this program generates a `.hi` file for `Example.hs` and currently throws a GHC panic when rerun. To mitigate this you need to either remove the `Example.hi` file or touch (update date) the `Example.hs` to force recompilation.
