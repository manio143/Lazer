namespace Lazer.Runtime
{
    /**
        Generic function. Takes a pointer to the static computation function
        and closure parameters.
     */

    public unsafe class Function1 : Function
    {
        protected internal void* f;
        public override int Arity => 1;
        public Function1(void* f)
        {
            this.f = f;
        }
        public override Closure Apply(StgContext ctx, Closure a0)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, Closure>(ctx, a0, f);
        }
        public static Function Make(void* f) => new Function1(f);
        public static Function1<T0> Make<T0>(void* f, T0 x0) => new Function1<T0>(f, x0);
        public static Function1<T0, T1> Make<T0, T1>(void* f, T0 x0, T1 x1) => new Function1<T0, T1>(f, x0, x1);
    }
    public unsafe class Function1<T0> : Function
    {
        protected internal void* f;
        public T0 x0;
        public override int Arity => 1;
        public Function1(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Apply(StgContext ctx, Closure a0)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, Closure, Closure>(ctx, x0, a0, f);
        }
    }
    public unsafe class Function1<T0, T1> : Function
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public override int Arity => 1;
        public Function1(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Apply(StgContext ctx, Closure a0)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, Closure, Closure>(ctx, x0, x1, a0, f);
        }
    }
    public unsafe class Function2 : Function
    {
        protected internal void* f;
        public override int Arity => 2;
        public Function2(void* f)
        {
            this.f = f;
        }
        public override Closure Apply(StgContext ctx, Closure a0, Closure a1)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, Closure, Closure>(ctx, a0, a1, f);
        }
        public static Function2 Make(void* f) => new Function2(f);
        public static Function2<T0> Make<T0>(void* f, T0 x0) => new Function2<T0>(f, x0);
        public static Function2<T0, T1> Make<T0, T1>(void* f, T0 x0, T1 x1) => new Function2<T0, T1>(f, x0, x1);
    }
    public unsafe class Function2<T0> : Function
    {
        protected internal void* f;
        public T0 x0;
        public override int Arity => 2;
        public Function2(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Apply(StgContext ctx, Closure a0, Closure a1)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, Closure, Closure, Closure>(ctx, x0, a0, a1, f);
        }
    }
    public unsafe class Function2<T0, T1> : Function
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public override int Arity => 2;
        public Function2(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Apply(StgContext ctx, Closure a0, Closure a1)
        {
            return CLR.TailCallIndirectGeneric<StgContext, T0, T1, Closure, Closure, Closure>(ctx, x0, x1, a0, a1, f);
        }
    }
    public unsafe class Function3 : Function
    {
        protected internal void* f;
        public override int Arity => 3;
        public Function3(void* f)
        {
            this.f = f;
        }
        public override Closure Apply(StgContext ctx, Closure a0, Closure a1, Closure a2)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, Closure, Closure, Closure>(ctx, a0, a1, a2, f);
        }
        public static Function3 Make(void* f) => new Function3(f);
    }
}