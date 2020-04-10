using System;

namespace Lazer.Runtime
{
    /**
        A closure is the unit of value that can be evaluated.
        In this runtime nearly everything is a Closure and most methods
        will be returning one.
     */
    public abstract partial class Closure
    {
        /**
            Eval function called on a value (data/function) will just
            return the object itself.
            Eval function on a Thunk or App will actually perform a computation.
         */
        public abstract Closure Eval();

        /**
            A tag for switching on alternatives when dealing with
            more than 4-5 data constructors.
         */
        public abstract int Tag { get; }
    }

    public abstract partial class Computation : Closure
    {
        public override int Tag
            => throw new NotSupportedException("Accessing Tag on a computation.");
    }

    /**
        Base class for any data constructor.
     */
    public abstract partial class Data : Closure
    {
        public override Closure Eval() => this;
        public override int Tag => 0;
    }

    /**
        Base class for any function.
     */
    public abstract partial class Function : Closure
    {
        public override Closure Eval() => this;

        /**
            Each function has an arity which is used during application
            when the function is not statically known.
         */
        public abstract int Arity { get; }

        public override int Tag
            => throw new NotSupportedException("Accessing Tag on a function.");
    }

    /**
        Thunk is an updateable closure.
        Once a Thunk has been evaluated it returns the indirection value.
     */
    public unsafe abstract class Thunk : Computation
    {
        public Closure ind;
        private void* eval;
        protected Thunk()
        {
            eval = CLR.LoadFunctionPointer(PerformComputation);
        }
        protected abstract Closure Compute();
        protected internal virtual void Cleanup() { }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<Thunk, Closure>(this, eval);
        }
        private Closure PerformComputation()
        {
            // setup loop detection
            // and evaluate the actual thunk code
            ind = Blackhole.Instance;
            ind = Compute();
            eval = CLR.LoadFunctionPointer(ReturnIndirection);
            // cleanup - release any resources so that 
            // they can be collected by GC
            Cleanup();
            return ind;
        }
        private Closure ReturnIndirection()
        {
            return ind.Eval();
        }
    }

    /**
        This is a temporary object used by Thunk to mark a started 
        computation. If the during thunk evaluation we need to evaluate 
        it then it's an error and there's an infinite loop in our program.
     */
    public sealed class Blackhole : Computation
    {
        public override Closure Eval() =>
            throw new System.Exception("BLACKHOLE");
        public static Blackhole Instance = new Blackhole();
    }
}