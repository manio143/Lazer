namespace Lazer.Runtime
{
    /**
        A closure is the unit of value that can be evaluated.
        In this runtime nearly everything is a Closure and most methods
        will be returning one.
     */
    public abstract class Closure
    {
        /**
            Eval function called on a value (data/function) will just
            return the object itself.
            Eval function on a Thunk or App will actually perform a computation.
         */
        public abstract Closure Eval(StgContext ctx);
    }

    /**
        Base class for any data constructor.
     */
    public abstract class Data : Closure
    {
        public override Closure Eval(StgContext ctx) => this;
    }

    /**
        Base class for any function.
     */
    public abstract class Function : Closure
    {
        public override Closure Eval(StgContext ctx) => this;

        /**
            Each function has an arity which is used during application
            when the function is not statically known.
         */
        public abstract int Arity { get; }
    }

    /**
        A continuation object is used during evaluation in order to do something after a Closure is evaluted.
        The main two uses are Case expressions and Updates.
     */
    public abstract class Continuation
    {
        /**
            This method is called with an evaluated Closure (in WHNF).
         */
        public abstract Closure Call(StgContext ctx, Closure c);
    }

    /**
        This is a base class for derving Case expression continuations.
     */
    public abstract class Case : Continuation
    {
    }
}