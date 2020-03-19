using System;

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
            Eval **must** return into ctx.Cont.
         */
        public abstract Closure Eval(StgContext ctx);

        /**
            A more performant way of checking closure type
            than doing `isinst` and traversing inheritance tree.
         */
        public virtual ClosureType Type => ClosureType.Closure;
    }

    [System.Flags]
    public enum ClosureType : byte
    {
        Closure = 0,
        Thunk = 0,
        SingleEntry = 0,
        Data = 1,
        Function = 2,
    }

    /**
        Base class for any data constructor.
     */
    public abstract class Data : Closure
    {
        public override Closure Eval(StgContext ctx) => ctx.Cont.Call(ctx, this);
        public override ClosureType Type => ClosureType.Data;
    }

    /**
        Base class for any function.
     */
    public abstract class Function : Closure
    {
        public override Closure Eval(StgContext ctx) => ctx.Cont.Call(ctx, this);
        public override ClosureType Type => ClosureType.Function;

        /**
            Each function has an arity which is used during application
            when the function is not statically known.
         */
        public abstract int Arity { get; }

        public virtual Closure Apply(StgContext ctx, Closure a0)
            => throw new NotImplementedException();
        public virtual Closure Apply(StgContext ctx, Closure a0, Closure a1)
            => throw new NotImplementedException();
        public virtual Closure Apply(StgContext ctx, Closure a0, Closure a1, Closure a2)
            => throw new NotImplementedException();

        /**
            Whenever returning a data object from a Function.Apply you need to
            tail call into Eval of the data object.
            i.e. return new Box<int>(1).Eval(ctx);
         */
    }

    /**
        A continuation object is used during evaluation in order to do something after a Closure is evaluted.
        The main two uses are Case expressions and Updates.
     */
    public abstract class Continuation
    {
        /**
            This method is called with an evaluated Closure (in WHNF).
            Before returning it has to peform a `ctx.Pop()` to remove itself
            from the continuation stack.
         */
        public abstract Closure Call(StgContext ctx, Closure c);

        /** The next continuation in the stack. */
        protected internal Continuation next;
        /**
            After executing this continuation continue with argument.
            `next` is later loaded by StgContext.Pop().
         */
        public Continuation With(Continuation cont)
        {
            next = cont;
            return this;
        }
    }
}