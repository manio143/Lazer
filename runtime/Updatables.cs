namespace Lazer.Runtime
{
    /**
        Generic thunk. Takes a pointer to the static computation function
        and closure parameters.

        Usage:
        given static method F and free variables x and y
            Updatable.Make(CLR.LoadFunctionPointer(F), x, y)
     */
    public sealed unsafe class Updatable : Thunk
    {
        private delegate*<Closure> f;

        public Updatable(delegate*<Closure> f)
        {
            this.f = f;
        }

        protected override Closure Compute() => f();
    }

    public sealed unsafe class Updatable<F> : Thunk
    {
        public F free;
        private delegate*<in F, Closure> f;
        
        public Updatable(delegate*<in F,Closure> f, F free)
        {
            this.f = f;
            this.free = free;
        }

        protected override Closure Compute() => f(in free);
        
        protected override void Cleanup() => free = default;
    }
}