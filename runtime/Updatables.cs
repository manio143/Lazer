namespace Lazer.Runtime
{
    /**
        Generic thunk. Takes a pointer to the static computation function
        and closure parameters.
     */

    public unsafe class Updatable0 : Thunk
    {
        protected internal void* f;
        public Updatable0(void* f)
        {
            this.f = f;
        }
        public override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure>(ctx, f);
        }
    }
    public unsafe class Updatable1<T0> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public Updatable1(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, Closure>(ctx, x0, f);
        }
    }
    public unsafe class Updatable2<T0, T1> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public Updatable2(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, Closure>(ctx, x0, x1, f);
        }
    }
    public unsafe class Updatable3<T0, T1, T2> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public Updatable3(void* f, T0 x0, T1 x1, T2 x2)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, T2, Closure>(ctx, x0, x1, x2, f);
        }
    }
}