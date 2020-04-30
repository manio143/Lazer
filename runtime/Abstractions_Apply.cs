using System;
using System.Runtime.CompilerServices;

namespace Lazer.Runtime
{
    public abstract partial class Closure
    {

        /**
            This leverages OOP features to allow applying
            closures - both functions and unevaluated functions
            without helper static methods
         */
        public abstract R Apply<A1, R>(A1 a1);
        public abstract R Apply<A1, A2, R>(A1 a1, A2 a2);
        public abstract R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3);
        public abstract R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4);
        public abstract R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5);
        public abstract R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6);
        public abstract R Apply<A1, A2, A3, A4, A5, A6, A7, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7);
    }

    public abstract partial class Computation
    {
        public override R Apply<A1, R>(A1 a1)
             => this.Eval().Apply<A1, R>(a1);
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => this.Eval().Apply<A1, A2, R>(a1, a2);
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => this.Eval().Apply<A1, A2, A3, R>(a1, a2, a3);
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => this.Eval().Apply<A1, A2, A3, A4, R>(a1, a2, a3, a4);
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => this.Eval().Apply<A1, A2, A3, A4, A5, R>(a1, a2, a3, a4, a5);
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => this.Eval().Apply<A1, A2, A3, A4, A5, A6, R>(a1, a2, a3, a4, a5, a6);

        public override R Apply<A1, A2, A3, A4, A5, A6, A7, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
             => this.Eval().Apply<A1, A2, A3, A4, A5, A6, A7, R>(a1, a2, a3, a4, a5, a6, a7);
    }

    public abstract partial class Data
    {
        public override R Apply<A1, R>(A1 a1)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
        public override R Apply<A1, A2, A3, A4, A5, A6, A7, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
             => throw new NotSupportedException($"Cannot apply a value ({GetType()})");
    }

    public abstract partial class Function
    {
        /**
            Each apply method is the 'default' behaviour.
            If arity is less then apply exect and apply again.
            If arity is more then construct a PAP.
            When arity is exact this method is going to be overriden
                in a subclass. Therefore exact application will be a step faster.
        */
        public override R Apply<A1, R>(A1 a1)
        {
            var pap = new PAP<A1>(this, a1);
            return Unsafe.As<PAP<A1>, R>(ref pap);
        }
        public override R Apply<A1, A2, R>(A1 a1, A2 a2)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, R>(a2);
                default:
                    var pap = new PAP<A1, A2>(this, a1, a2);
                    return Unsafe.As<PAP<A1, A2>, R>(ref pap);
            }
        }
        public override R Apply<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, A3, R>(a2, a3);
                case 2:
                    h = this.Apply<A1, A2, Closure>(a1, a2);
                    return h.Apply<A3, R>(a3);
                default:
                    var pap = new PAP<A1, A2, A3>(this, a1, a2, a3);
                    return Unsafe.As<PAP<A1, A2, A3>, R>(ref pap);
            }
        }
        public override R Apply<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, A3, A4, R>(a2, a3, a4);
                case 2:
                    h = this.Apply<A1, A2, Closure>(a1, a2);
                    return h.Apply<A3, A4, R>(a3, a4);
                case 3:
                    h = this.Apply<A1, A2, A3, Closure>(a1, a2, a3);
                    return h.Apply<A4, R>(a4);
                default:
                    var pap = new PAP<A1, A2, A3, A4>(this, a1, a2, a3, a4);
                    return Unsafe.As<PAP<A1, A2, A3, A4>, R>(ref pap);
            }
        }
        public override R Apply<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, A3, A4, A5, R>(a2, a3, a4, a5);
                case 2:
                    h = this.Apply<A1, A2, Closure>(a1, a2);
                    return h.Apply<A3, A4, A5, R>(a3, a4, a5);
                case 3:
                    h = this.Apply<A1, A2, A3, Closure>(a1, a2, a3);
                    return h.Apply<A4, A5, R>(a4, a5);
                case 4:
                    h = this.Apply<A1, A2, A3, A4, Closure>(a1, a2, a3, a4);
                    return h.Apply<A5, R>(a5);
                default:
                    var pap = new PAP<A1, A2, A3, A4, A5>(this, a1, a2, a3, a4, a5);
                    return Unsafe.As<PAP<A1, A2, A3, A4, A5>, R>(ref pap);
            }
        }
        public override R Apply<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, A3, A4, A5, A6, R>(a2, a3, a4, a5, a6);
                case 2:
                    h = this.Apply<A1, A2, Closure>(a1, a2);
                    return h.Apply<A3, A4, A5, A6, R>(a3, a4, a5, a6);
                case 3:
                    h = this.Apply<A1, A2, A3, Closure>(a1, a2, a3);
                    return h.Apply<A4, A5, A6, R>(a4, a5, a6);
                case 4:
                    h = this.Apply<A1, A2, A3, A4, Closure>(a1, a2, a3, a4);
                    return h.Apply<A5, A6, R>(a5, a6);
                case 5:
                    h = this.Apply<A1, A2, A3, A4, A5, Closure>(a1, a2, a3, a4, a5);
                    return h.Apply<A6, R>(a6);
                default:
                    var pap = new PAP<A1, A2, A3, A4, A5, A6>(this, a1, a2, a3, a4, a5, a6);
                    return Unsafe.As<PAP<A1, A2, A3, A4, A5, A6>, R>(ref pap);
            }
        }
        public override R Apply<A1, A2, A3, A4, A5, A6, A7, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7)
        {
            Closure h;
            switch (this.Arity)
            {
                case 1:
                    h = this.Apply<A1, Closure>(a1);
                    return h.Apply<A2, A3, A4, A5, A6, A7, R>(a2, a3, a4, a5, a6, a7);
                case 2:
                    h = this.Apply<A1, A2, Closure>(a1, a2);
                    return h.Apply<A3, A4, A5, A6, A7, R>(a3, a4, a5, a6, a7);
                case 3:
                    h = this.Apply<A1, A2, A3, Closure>(a1, a2, a3);
                    return h.Apply<A4, A5, A6, A7, R>(a4, a5, a6, a7);
                case 4:
                    h = this.Apply<A1, A2, A3, A4, Closure>(a1, a2, a3, a4);
                    return h.Apply<A5, A6, A7, R>(a5, a6, a7);
                case 5:
                    h = this.Apply<A1, A2, A3, A4, A5, Closure>(a1, a2, a3, a4, a5);
                    return h.Apply<A6, A7, R>(a6, a7);
                case 6:
                    h = this.Apply<A1, A2, A3, A4, A5, A6, Closure>(a1, a2, a3, a4, a5, a6);
                    return h.Apply<A7, R>(a7);
                default:
                    var pap = new PAP<A1, A2, A3, A4, A5, A6, A7>(this, a1, a2, a3, a4, a5, a6, a7);
                    return Unsafe.As<PAP<A1, A2, A3, A4, A5, A6, A7>, R>(ref pap);
            }
        }
    }
}