namespace Lazer.Runtime
{
    /**
        Generic thunk. Takes a pointer to the static computation function
        and closure parameters.

        Usage:
        given static method F and free variables x and y
            Updatable.Make(CLR.LoadFunctionPointer(F), x, y)
     */
    public unsafe class Updatable : Thunk
    {
        public Updatable(void* f)
        {
            this.f = f;
        }
        protected void* f;
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<Closure>(f);

    }

    public unsafe class Updatable<F0> : Updatable
    {
        public F0 x0;
        public Updatable(void* f, F0 x0) : base(f)
        {
            this.x0 = x0;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, Closure>(x0, f);
        protected override void Cleanup()
        {
            x0 = default;
        }

    }

    public unsafe class Updatable<F0, F1> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public Updatable(void* f, F0 x0, F1 x1) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, Closure>(x0, x1, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, Closure>(x0, x1, x2, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, Closure>(x0, x1, x2, x3, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, Closure>(x0, x1, x2, x3, x4, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, Closure>(x0, x1, x2, x3, x4, x5, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5, F6> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public F6 x6;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5, F6 x6) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, F6, Closure>(x0, x1, x2, x3, x4, x5, x6, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
            x6 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5, F6, F7> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public F6 x6;
        public F7 x7;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5, F6 x6, F7 x7) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
            this.x7 = x7;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, F6, F7, Closure>(x0, x1, x2, x3, x4, x5, x6, x7, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
            x6 = default;
            x7 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5, F6, F7, F8> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public F6 x6;
        public F7 x7;
        public F8 x8;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5, F6 x6, F7 x7, F8 x8) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
            this.x7 = x7;
            this.x8 = x8;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, F6, F7, F8, Closure>(x0, x1, x2, x3, x4, x5, x6, x7, x8, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
            x6 = default;
            x7 = default;
            x8 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5, F6, F7, F8, F9> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public F6 x6;
        public F7 x7;
        public F8 x8;
        public F9 x9;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5, F6 x6, F7 x7, F8 x8, F9 x9) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
            this.x7 = x7;
            this.x8 = x8;
            this.x9 = x9;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, F6, F7, F8, F9, Closure>(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
            x6 = default;
            x7 = default;
            x8 = default;
            x9 = default;
        }

    }

    public unsafe class Updatable<F0, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10> : Updatable
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public F6 x6;
        public F7 x7;
        public F8 x8;
        public F9 x9;
        public F10 x10;
        public Updatable(void* f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5, F6 x6, F7 x7, F8 x8, F9 x9, F10 x10) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
            this.x6 = x6;
            this.x7 = x7;
            this.x8 = x8;
            this.x9 = x9;
            this.x10 = x10;
        }
        protected override Closure Compute()
             => CLR.TailCallIndirectGeneric<F0, F1, F2, F3, F4, F5, F6, F7, F8, F9, F10, Closure>(x0, x1, x2, x3, x4, x5, x6, x7, x8, x9, x10, f);
        protected override void Cleanup()
        {
            x0 = default;
            x1 = default;
            x2 = default;
            x3 = default;
            x4 = default;
            x5 = default;
            x6 = default;
            x7 = default;
            x8 = default;
            x9 = default;
            x10 = default;
        }

    }
}