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

    public sealed unsafe class UpdatableRef<F> : Thunk where F : struct
    {
        public F free;
        private delegate*<ref F, Closure> f;
        
        public UpdatableRef(delegate*<ref F,Closure> f, F free)
        {
            this.f = f;
            this.free = free;
        }

        protected override Closure Compute() => f(ref free);
        
        protected override void Cleanup() => free = default;
    }
    public sealed unsafe class Updatable<F> : Thunk
    {
        public F free;
        private delegate*<F, Closure> f;
        
        public Updatable(delegate*<F,Closure> f, F free)
        {
            this.f = f;
            this.free = free;
        }

        protected override Closure Compute() => f(free);
        
        protected override void Cleanup() => free = default;
    }

    public sealed unsafe class Updatable<F0, F1> : Thunk
    {
        public F0 x0;
        public F1 x1;
        private delegate*<F0,F1, Closure> f;
        
        public Updatable(delegate*<F0,F1,Closure> f, F0 x0, F1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }

        protected override Closure Compute() => f(x0,x1);
        
        protected override void Cleanup() {
            x0 = default;
            x1 = default;
        }
    }
}