namespace Lazer.Runtime
{
    /**
        Generic continuation. Takes a pointer to the static computation function
        and closure parameters.
     */

    public static unsafe class StgCont
    {
        public static Continuation Make(void* f) => new Cont0(f);
        public static Continuation Make<T0>(void* f, T0 x0) => new Cont1<T0>(f, x0);
        public static Continuation Make<T0, T1>(void* f, T0 x0, T1 x1) => new Cont2<T0, T1>(f, x0, x1);
        public static Continuation Make<T0, T1, T2>(void* f, T0 x0, T1 x1, T2 x2) => new Cont3<T0, T1, T2>(f, x0, x1, x2);
    }

    public unsafe class Cont0 : Continuation
    {
        protected internal void* f;
        public Cont0(void* f)
        {
            this.f = f;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, Closure>(ctx, c, f);
        }
    }
    public unsafe class Cont1<T0> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public Cont1(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, Closure>(ctx, c, x0, f);
        }
    }
    public unsafe class Cont2<T0, T1> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public Cont2(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, Closure>(ctx, c, x0, x1, f);
        }
    }
    public unsafe class Cont3<T0, T1, T2> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public Cont3(void* f, T0 x0, T1 x1, T2 x2)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, T2, Closure>(ctx, c, x0, x1, x2, f);
        }
    }
}