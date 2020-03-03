# Lazer.Runtime
This is a core library with abstractions and a set of classes that will allow user code to be executed without getting StackOverflow exception.

## Navigating the code

* `Abstractions.cs`
    * `Closure` - the unit of computation and a unit representing a value
    * `Data` - base class for boxed values
    * `Function` - base class for functions
    * `Continuation` - base class for code continuations
* `Thunk.cs`
    * `Thunk` - base class for updateable computations
    * `Blackhole` - a thunk loop detection system
* `Updates.cs`
    * `Update` - a continuation for updating thunks
    * `UpdatePool` - reusable Update objects
* `IFunction.cs` - interfaces for functions (you need to know function arity to call it)
* `PAP.cs` - a partial application object
* `Box.cs` - generic closure container for unlifted structs
* `StgApply.cs` - static helper methods to perform application of unknown functions
* `StgContext.cs` - a computation context
* `CLRPointers.cs` - compiler intrinsic functions for function pointers
* `Exceptions.cs` - common runtime exceptions
* Generic helpers
    * `AppNx.cs` - closures for delaying function application
    * `Continuations.cs` - continuations from static functions
    * `Functions.cs` - function closures from static functions
    * `Updatables.cs` - thunks from static functions
    * `SingleEntries.cs` - closures from static functions
