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
        public Fun(int arity, void* f)
        {
            this.arity = arity;
            this.f = f;
        }
        protected int arity;
        public override int Arity => arity;
        protected void* f;
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<A1, R>(a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<A1, A2, R>(a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<A1, A2, A3, R>(a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<A1, A2, A3, A4, R>(a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<A1, A2, A3, A4, A5, R>(a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, R>(a1, a2, a3, a4, a5, a6, f);
    }

    public unsafe class Fun<F0> : Fun
    {
        public F0 x0;
        public Fun(int arity, void* f, F0 x0) : base(arity, f)
        {
            this.x0 = x0;
        }
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, A1, R>(x0, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, A1, A2, R>(x0, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, A1, A2, A3, R>(x0, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, A1, A2, A3, A4, R>(x0, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, A1, A2, A3, A4, A5, R>(x0, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, A1, A2, A3, A4, A5, A6, R>(x0, a1, a2, a3, a4, a5, a6, f);
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
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, R>(x0, x1, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, A2, R>(x0, x1, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, A2, A3, R>(x0, x1, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, A2, A3, A4, R>(x0, x1, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, A2, A3, A4, A5, R>(x0, x1, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, F1, A1, A2, A3, A4, A5, A6, R>(x0, x1, a1, a2, a3, a4, a5, a6, f);
    }

    public unsafe class Fun<F0, F1, F2> : Fun
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public Fun(int arity, void* f, F0 x0, F1 x1, F2 x2) : base(arity, f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, R>(x0, x1, x2, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, A2, R>(x0, x1, x2, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, A2, A3, R>(x0, x1, x2, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, A2, A3, A4, R>(x0, x1, x2, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, A2, A3, A4, A5, R>(x0, x1, x2, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, A1, A2, A3, A4, A5, A6, R>(x0, x1, x2, a1, a2, a3, a4, a5, a6, f);
    }

    public unsafe class Fun<F0, F1, F2, F3> : Fun
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public Fun(int arity, void* f, F0 x0, F1 x1, F2 x2, F3 x3) : base(arity, f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, R>(x0, x1, x2, x3, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, A2, R>(x0, x1, x2, x3, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, A2, A3, R>(x0, x1, x2, x3, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, A2, A3, A4, R>(x0, x1, x2, x3, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, A2, A3, A4, A5, R>(x0, x1, x2, x3, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, A1, A2, A3, A4, A5, A6, R>(x0, x1, x2, x3, a1, a2, a3, a4, a5, a6, f);
    }

    public unsafe class Fun<F0, F1, F2, F3, F4> : Fun
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public Fun(int arity, void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4) : base(arity, f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, R>(x0, x1, x2, x3, x4, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, A2, R>(x0, x1, x2, x3, x4, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, A2, A3, R>(x0, x1, x2, x3, x4, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, A2, A3, A4, R>(x0, x1, x2, x3, x4, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, A2, A3, A4, A5, R>(x0, x1, x2, x3, x4, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, A1, A2, A3, A4, A5, A6, R>(x0, x1, x2, x3, x4, a1, a2, a3, a4, a5, a6, f);
    }

    public unsafe class Fun<F0, F1, F2, F3, F4, F5> : Fun
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public Fun(int arity, void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5) : base(arity, f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }
        public override R ApplyImpl<A1, R>(A1 a1)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, R>(x0, x1, x2, x3, x4, x5, a1, f);
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, A2, R>(x0, x1, x2, x3, x4, x5, a1, a2, f);
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, A2, A3, R>(x0, x1, x2, x3, x4, x5, a1, a2, a3, f);
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, A2, A3, A4, R>(x0, x1, x2, x3, x4, x5, a1, a2, a3, a4, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, A2, A3, A4, A5, R>(x0, x1, x2, x3, x4, x5, a1, a2, a3, a4, a5, f);
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, A1, A2, A3, A4, A5, A6, R>(x0, x1, x2, x3, x4, x5, a1, a2, a3, a4, a5, a6, f);
    }
}