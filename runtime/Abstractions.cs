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
         */
        public abstract Closure Eval();

        /**
            A more performant way of checking closure type
            than doing `isinst` and traversing inheritance tree.
         */
        public virtual ClosureType Type => ClosureType.Closure;

        /**
            A tag for switching on alternatives when dealing with
            more than 4-5 data constructors.
         */
        public virtual int Tag
            => throw new NotImplementedException("Accessing Tag on a non-data closure.");

    }

    [System.Flags]
    public enum ClosureType : byte
    {
        Closure = 0,
        Thunk = 0,
        Data = 1,
        Function = 2,
        PartialApplication = 4,
    }

    /**
        Base class for any data constructor.
     */
    public abstract class Data : Closure
    {
        public override Closure Eval() => this;
        public override ClosureType Type => ClosureType.Data;
        public override int Tag => 0;
    }

    /**
        Base class for any function.
     */
    public abstract class Function : Closure
    {
        public override Closure Eval() => this;
        public override ClosureType Type => ClosureType.Function;

        /**
            Each function has an arity which is used during application
            when the function is not statically known.
         */
        public abstract int Arity { get; }
        
        public abstract R Apply<A0, R>(A0 a0);
        public abstract R Apply<A0, A1, R>(A0 a0, A1 a1);
        public abstract R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2);
    }
}