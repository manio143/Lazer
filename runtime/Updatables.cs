namespace Lazer.Runtime
{
    /**
        Generic thunk. Takes a pointer to the static computation function
        and closure parameters.
     */

    public static unsafe class Updatable
    {
        public static Updatable0 Make(void* f) => new Updatable0(f);
        public static Updatable1<T0> Make<T0>(void* f, T0 x0) => new Updatable1<T0>(f, x0);
        public static Updatable2<T0, T1> Make<T0, T1>(void* f, T0 x0, T1 x1) => new Updatable2<T0, T1>(f, x0, x1);
        public static Updatable3<T0, T1, T2> Make<T0, T1, T2>(void* f, T0 x0, T1 x1, T2 x2) => new Updatable3<T0, T1, T2>(f, x0, x1, x2);
        public static Updatable4<T0, T1, T2, T3> Make<T0, T1, T2, T3>(void* f, T0 x0, T1 x1, T2 x2, T3 x3) => new Updatable4<T0, T1, T2, T3>(f, x0, x1, x2, x3);
        public static Updatable5<T0, T1, T2, T3, T4> Make<T0, T1, T2, T3, T4>(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4) => new Updatable5<T0, T1, T2, T3, T4>(f, x0, x1, x2, x3, x4);
        public static Updatable6<T0, T1, T2, T3, T4, T5> Make<T0, T1, T2, T3, T4, T5>(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5) => new Updatable6<T0, T1, T2, T3, T4, T5>(f, x0, x1, x2, x3, x4, x5);
    }

    public unsafe class Updatable0 : Thunk
    {
        protected internal void* f;
        public Updatable0(void* f)
        {
            this.f = f;
        }
        protected override Closure Compute(StgContext ctx)
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
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, Closure>(ctx, x0, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
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
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, Closure>(ctx, x0, x1, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
            x1 = default;
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
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, T2, Closure>(ctx, x0, x1, x2, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
        }
    }
    public unsafe class Updatable4<T0, T1, T2, T3> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public Updatable4(void* f, T0 x0, T1 x1, T2 x2, T3 x3)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, T2, T3, Closure>(ctx, x0, x1, x2, x3, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
        }
    }
    public unsafe class Updatable5<T0, T1, T2, T3, T4> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public T4 x4;
        public Updatable5(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, T2, T3, T4, Closure>(ctx, x0, x1, x2, x3, x4, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
        }
    }
    public unsafe class Updatable6<T0, T1, T2, T3, T4, T5> : Thunk
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public T4 x4;
        public T5 x5;
        public Updatable6(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, T5 x5)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }
        protected override Closure Compute(StgContext ctx)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, T2, T3, T4, T5, Closure>(ctx, x0, x1, x2, x3, x4, x5, f);
        }
        protected internal override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
        }
    }
}