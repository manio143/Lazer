# Lazer
**Experimental** project to bring a lazy language to .NET

This work is part of my master thesis, work in progress.

I have managed to create a simple runtime in C# that allows to run lazy code efficiently.

You can even compile simple Haskell code to C# with the `stg2cs` compiler (needs more work).

The benchmark results (1x-2.5x running time compared to GHC):

![Lazer vs GHC benchmark](https://www.md-techblog.net.pl/assets/img/Lazer_vs_GHC.png)
