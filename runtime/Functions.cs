namespace Lazer.Runtime
{
    /**
        Generic function. Takes a pointer to the static computation function
        and closure parameters.

        Usage:
        given static method F(Closure) and free variable long x
            new Fun<long>(1, CLR.LoadFunctionPointer(F), x)
     */

    public unsafe class Fun : Function
    {
        protected internal void* f;
        public override int Arity => arity;
        protected internal int arity;
        public Fun(int arity, void* f)
        {
            this.arity = arity;
            this.f = f;
        }
        public override R ApplyImpl<A0, R>(A0 a0)
        {
            return CLR.TailCallIndirectGeneric<A0, R>(a0, f);
        }
        public override R ApplyImpl<A0, A1, R>(A0 a0, A1 a1)
        {
            return CLR.TailCallIndirectGeneric<A0, A1, R>(a0, a1, f);
        }
        public override R ApplyImpl<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
        {
            return CLR.TailCallIndirectGeneric<A0, A1, A2, R>(a0, a1, a2, f);
        }
    }

    public unsafe class Fun<F0> : Fun
    {
        public F0 x0;
        public Fun(int arity, void* f, F0 x0) : base(arity, f)
        {
            this.x0 = x0;
        }
        public override R ApplyImpl<A0, R>(A0 a0)
        {
            return CLR.TailCallIndirectGeneric<F0, A0, R>(x0, a0, f);
        }
        public override R ApplyImpl<A0, A1, R>(A0 a0, A1 a1)
        {
            return CLR.TailCallIndirectGeneric<F0, A0, A1, R>(x0, a0, a1, f);
        }
        public override R ApplyImpl<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
        {
            return CLR.TailCallIndirectGeneric<F0, A0, A1, A2, R>(x0, a0, a1, a2, f);
        }
    }
    public unsafe class Fun<F0, F1> : Fun
    {
        public F0 x0;
        public F1 x1;
        public Fun(int arity, void* f, F0 x0, F1 x1) : base(arity, f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        public override R ApplyImpl<A0, R>(A0 a0)
        {
            return CLR.TailCallIndirectGeneric<F0, F1, A0, R>(x0, x1, a0, f);
        }
        public override R ApplyImpl<A0, A1, R>(A0 a0, A1 a1)
        {
            return CLR.TailCallIndirectGeneric<F0, F1, A0, A1, R>(x0, x1, a0, a1, f);
        }
        public override R ApplyImpl<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
        {
            return CLR.TailCallIndirectGeneric<F0, F1, A0, A1, A2, R>(x0, x1, a0, a1, a2, f);
        }
    }
}