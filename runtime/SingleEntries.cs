namespace Lazer.Runtime
{
    /**
        Generic closure. Takes a pointer to the static computation function
        and closure parameters.
     */

    public unsafe class SingleEntry : Computation
    {
        public SingleEntry(void* f)
        {
            this.f = f;
        }
        protected void* f;
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<Closure>(f);

    }

    public unsafe class SingleEntry<F0> : SingleEntry
    {
        public F0 x0;
        public SingleEntry(void* f, F0 x0) : base(f)
        {
            this.x0 = x0;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, Closure>(x0, f);

    }

    public unsafe class SingleEntry<F0, F1> : SingleEntry
    {
        public F0 x0;
        public F1 x1;
        public SingleEntry(void* f, F0 x0, F1 x1) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, F1, Closure>(x0, x1, f);

    }

    public unsafe class SingleEntry<F0, F1, F2> : SingleEntry
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public SingleEntry(void* f, F0 x0, F1 x1, F2 x2) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, Closure>(x0, x1, x2, f);

    }

    public unsafe class SingleEntry<F0, F1, F2, F3> : SingleEntry
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public SingleEntry(void* f, F0 x0, F1 x1, F2 x2, F3 x3) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, Closure>(x0, x1, x2, x3, f);

    }

    public unsafe class SingleEntry<F0, F1, F2, F3, F4> : SingleEntry
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public SingleEntry(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, Closure>(x0, x1, x2, x3, x4, f);

    }

    public unsafe class SingleEntry<F0, F1, F2, F3, F4, F5> : SingleEntry
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public SingleEntry(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }
        public override Closure Eval()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, Closure>(x0, x1, x2, x3, x4, x5, f);

    }
}