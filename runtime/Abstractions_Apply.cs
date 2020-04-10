using System;

namespace Lazer.Runtime
{
    public abstract partial class Closure
    {

        /**
            This leverages OOP features to allow applying
            closures - both functions and unevaluated functions
            without helper static methods
         */
        public virtual R Apply<A0, R>(A0 a0)
            => this.Eval().Apply<A0, R>(a0);
        public virtual R Apply<A0, A1, R>(A0 a0, A1 a1)
            => this.Eval().Apply<A0, A1, R>(a0, a1);
        public virtual R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
            => this.Eval().Apply<A0, A1, A2, R>(a0, a1, a2);
    }

    public abstract partial class Data
    {
        public override R Apply<A0, R>(A0 a0)
            => throw new Exception($"Cannot apply a value ({GetType()})");
        public override R Apply<A0, A1, R>(A0 a0, A1 a1)
            => throw new Exception($"Cannot apply a value ({GetType()})");
        public override R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
            => throw new Exception($"Cannot apply a value ({GetType()})");
    }

    public abstract partial class Function
    {

        public abstract R ApplyImpl<A0, R>(A0 a0);
        public abstract R ApplyImpl<A0, A1, R>(A0 a0, A1 a1);
        public abstract R ApplyImpl<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2);
        
        public override R Apply<A0, R>(A0 a0)
        {
            switch (this.Arity)
            {
                case 1:
                    return this.ApplyImpl<A0, R>(a0);
                default:
                    return (R)(object)new PAP<A0>(this, a0);
            }
        }
        public override R Apply<A0, A1, R>(A0 a0, A1 a1)
        {
            switch (this.Arity)
            {
                case 1:
                    var h = this.ApplyImpl<A0, Closure>(a0);
                    return h.Apply<A1, R>(a1);
                case 2:
                    return this.ApplyImpl<A0, A1, R>(a0, a1);
                default:
                    return (R)(object)new PAP<A0, A1>(this, a0, a1);
            }
        }
        public override R Apply<A0, A1, A2, R>(A0 a0, A1 a1, A2 a2)
        {
            switch (this.Arity)
            {
                case 1:
                    {
                        var h = this.ApplyImpl<A0, Closure>(a0);
                        return h.Apply<A1, A2, R>(a1, a2);
                    }
                case 2:
                    {
                        var h = this.ApplyImpl<A0, A1, Closure>(a0, a1);
                        return h.Apply<A2, R>(a2);
                    }
                case 3:
                    return this.ApplyImpl<A0, A1, A2, R>(a0, a1, a2);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}