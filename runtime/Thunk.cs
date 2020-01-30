namespace Lazer.Runtime
{
    /**
        Thunk is an updateable closure. It has two references - one to a 
        single entry computation closure and one to an indirection, the 
        result of the computation.
        Once a Thunk has been evaluated it returns the indirection value.
     */
    public abstract class Thunk : Closure
    {
        public Closure ind;
        public Closure compute;
        public override Closure Eval(StgContext ctx)
        {
            if (ind != null) 
                // if it's a Blackhole then Eval will throw
                // otherwise it just returns the ind object
                return ind.Eval(ctx); 
            ind = Blackhole.Instance;
            return StgEval.EvalAndContinueWith(ctx, compute, ctx.UpdatePool.Get(this));
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