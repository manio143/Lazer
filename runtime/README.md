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
* `AppNx.cs` - closures for delaying function application
* `PAP.cs` - a partial application object
* `StgApply.cs` - static helper methods to perform application of unknown functions
* `StgEval.cs` - static helper methods to perform trampoline bouncing
* `StgContext.cs` - a computation context
