using System;

namespace Lazer.Runtime
{
    /**
        PAP - Partial Application object
        It's an intermediate object used to apply functions
        to it's arguments.
     */
    public abstract class PAP : Closure
    {
        public Function f;
        protected PAP(Function f) => this.f = f;
        public override Closure Eval() => this;
        public override int Tag
            => throw new NotSupportedException("Accessing Tag on a PAP.");
    }

    public unsafe class PAP<F0> : PAP
    {
        public F0 x0;
        public PAP(Function f, F0 x0) : base(f)
        {
            this.x0 = x0;
        }
        public override R Apply<A1, R>(A1 a1)
             => f.Apply<F0, A1, R>(x0, a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => f.Apply<F0, A1, A2, R>(x0, a1, a2);
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => f.Apply<F0, A1, A2, A3, R>(x0, a1, a2, a3);
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => f.Apply<F0, A1, A2, A3, A4, R>(x0, a1, a2, a3, a4);
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => f.Apply<F0, A1, A2, A3, A4, A5, R>(x0, a1, a2, a3, a4, a5);
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public unsafe class PAP<F0, F1> : PAP
    {
        public F0 x0;
        public F1 x1;
        public PAP(Function f, F0 x0, F1 x1) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        public override R Apply<A1, R>(A1 a1)
             => f.Apply<F0, F1, A1, R>(x0, x1, a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => f.Apply<F0, F1, A1, A2, R>(x0, x1, a1, a2);
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => f.Apply<F0, F1, A1, A2, A3, R>(x0, x1, a1, a2, a3);
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => f.Apply<F0, F1, A1, A2, A3, A4, R>(x0, x1, a1, a2, a3, a4);
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public unsafe class PAP<F0, F1, F2> : PAP
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public PAP(Function f, F0 x0, F1 x1, F2 x2) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override R Apply<A1, R>(A1 a1)
             => f.Apply<F0, F1, F2, A1, R>(x0, x1, x2, a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => f.Apply<F0, F1, F2, A1, A2, R>(x0, x1, x2, a1, a2);
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => f.Apply<F0, F1, F2, A1, A2, A3, R>(x0, x1, x2, a1, a2, a3);
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public unsafe class PAP<F0, F1, F2, F3> : PAP
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public PAP(Function f, F0 x0, F1 x1, F2 x2, F3 x3) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        public override R Apply<A1, R>(A1 a1)
             => f.Apply<F0, F1, F2, F3, A1, R>(x0, x1, x2, x3, a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => f.Apply<F0, F1, F2, F3, A1, A2, R>(x0, x1, x2, x3, a1, a2);
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public unsafe class PAP<F0, F1, F2, F3, F4> : PAP
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public PAP(Function f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        public override R Apply<A1, R>(A1 a1)
             => f.Apply<F0, F1, F2, F3, F4, A1, R>(x0, x1, x2, x3, x4, a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public unsafe class PAP<F0, F1, F2, F3, F4, F5> : PAP
    {
        public F0 x0;
        public F1 x1;
        public F2 x2;
        public F3 x3;
        public F4 x4;
        public F5 x5;
        public PAP(Function f, F0 x0, F1 x1, F2 x2, F3 x3, F4 x4, F5 x5) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
            this.x5 = x5;
        }
        public override R Apply<A1, R>(A1 a1)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

}