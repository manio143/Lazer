namespace Lazer.Runtime
{
    /**
        Thunk is an updateable closure.
        Once a Thunk has been evaluated it returns the indirection value.
     */
    public abstract class Thunk : Closure
    {
        public Closure ind;
        protected abstract Closure Compute();
        protected internal virtual void Cleanup() { }
        public override Closure Eval()
        {
            if (ind != null) 
                // if it's a Blackhole then Eval will throw
                // otherwise it just returns the ind object
                return ind.Eval();

            // Having pushed the Update we setup loop detection
            // and evaluate the actual thunk code
            ind = Blackhole.Instance;
            ind = Compute();
            return ind;
        }
    }

    /**
        This is a temporary object used by Thunk to mark a started 
        computation. If the during thunk evaluation we need to evaluate 
        it then it's an error and there's an infinite loop in our program.
     */
    public sealed class Blackhole : Closure
    {
        public override Closure Eval() =>
            throw new System.Exception("BLACKHOLE");
        public static Blackhole Instance = new Blackhole();
    }
}