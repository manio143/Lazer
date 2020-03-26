namespace Lazer.Runtime
{
    /**
        Generic closure. Takes a pointer to the static computation function
        and closure parameters.
     */

    public static unsafe class SingleEntry
    {
        public static SingleEntry0 Make(void* f) => new SingleEntry0(f);
        public static SingleEntry1<T0> Make<T0>(void* f, T0 x0) => new SingleEntry1<T0>(f, x0);
        public static SingleEntry2<T0, T1> Make<T0, T1>(void* f, T0 x0, T1 x1) => new SingleEntry2<T0, T1>(f, x0, x1);
        public static SingleEntry3<T0, T1, T2> Make<T0, T1, T2>(void* f, T0 x0, T1 x1, T2 x2) => new SingleEntry3<T0, T1, T2>(f, x0, x1, x2);
        public static SingleEntry4<T0, T1, T2, T3> Make<T0, T1, T2, T3>(void* f, T0 x0, T1 x1, T2 x2, T3 x3) => new SingleEntry4<T0, T1, T2, T3>(f, x0, x1, x2, x3);
    }

    public unsafe class SingleEntry0 : Closure
    {
        protected internal void* f;
        public SingleEntry0(void* f)
        {
            this.f = f;
        }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<Closure>(f);
        }
    }
    public unsafe class SingleEntry1<T0> : Closure
    {
        protected internal void* f;
        public T0 x0;
        public SingleEntry1(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<T0, Closure>(x0, f);
        }
    }
    public unsafe class SingleEntry2<T0, T1> : Closure
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public SingleEntry2(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<T0, T1, Closure>(x0, x1, f);
        }
    }
    public unsafe class SingleEntry3<T0, T1, T2> : Closure
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public SingleEntry3(void* f, T0 x0, T1 x1, T2 x2)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<T0, T1, T2, Closure>(x0, x1, x2, f);
        }
    }
    public unsafe class SingleEntry4<T0, T1, T2, T3> : Closure
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public SingleEntry4(void* f, T0 x0, T1 x1, T2 x2, T3 x3)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        public override Closure Eval()
        {
            return CLR.TailCallIndirectGeneric<T0, T1, T2, T3, Closure>(x0, x1, x2, x3, f);
        }
    }
}