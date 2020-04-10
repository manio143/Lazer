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

    public sealed class PAP<B0> : PAP
    {
        public B0 x0;
        public PAP(Function f, B0 x0) : base(f)
        {
            this.x0 = x0;
        }
        public override R Apply<A0, R>(A0 a0) => f.Apply<B0, A0, R>(x0, a0);
        public override R Apply<A0, A1, R>(A0 a0, A1 a1) => f.Apply<B0, A0, A1, R>(x0, a0, a1);
        public override R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
            => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }

    public sealed class PAP<B0,B1> : PAP
    {
        public B0 x0;
        public B1 x1;
        public PAP(Function f, B0 x0, B1 x1) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        public override R Apply<A0, R>(A0 a0) => f.Apply<B0, B1, A0, R>(x0, x1, a0);
        public override R Apply<A0, A1, R>(A0 a0, A1 a1)
            => throw new NotSupportedException("Application exceeds runtime argument limit.");
        public override R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
            => throw new NotSupportedException("Application exceeds runtime argument limit.");
    }
}