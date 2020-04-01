# Lazer.Runtime
This is a core library with abstractions and a set of classes that will allow user code to be executed lazily.

## Navigating the code

* `Abstractions.cs`
    * `Closure` - the unit of computation and a unit representing a value
    * `Data` - base class for boxed values
    * `Function` - base class for functions
* `Thunk.cs`
    * `Thunk` - base class for updatable computations
    * `Blackhole` - a thunk loop detection system
* `PAP.cs` - a partial application object
* `Box.cs` - generic closure container for unlifted structs
* `StgApply.cs` - static helper methods to perform application of unknown functions
* `CLRPointers.cs` - compiler intrinsic functions for function pointers
* `Exceptions.cs` - common runtime exceptions
* Generic helpers
    * `Functions.cs` - function closures from static functions
    * `Updatables.cs` - thunks from static functions
    * `SingleEntries.cs` - closures from static functions
