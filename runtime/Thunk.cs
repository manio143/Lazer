namespace Lazer.Runtime
{
    /**
        Thunk is an updateable closure.
        Once a Thunk has been evaluated it returns the indirection value.
     */
    public abstract class Thunk : Closure
    {
        public Closure ind;
        protected abstract Closure Compute(StgContext ctx);
        protected internal virtual void Cleanup() { }
        public override Closure Eval(StgContext ctx)
        {
            if (ind != null) 
                // if it's a Blackhole then Eval will throw
                // otherwise it just returns the ind object
                return ind.Eval(ctx);

            ctx.Push(ctx.UpdatePool.Get(this));
            // Having pushed the Update we setup loop detection
            // and evaluate the actual thunk code
            ind = Blackhole.Instance;
            return Compute(ctx);
        }
    }

    /**
        This is a temporary object used by Thunk to mark a started 
        computation. If the during thunk evaluation we need to evaluate 
        it then it's an error and there's an infinite loop in our program.
     */
    public sealed class Blackhole : Closure
    {
        public override Closure Eval(StgContext ctx) =>
            throw new System.Exception("BLACKHOLE");
        public static Blackhole Instance = new Blackhole();
    }
}