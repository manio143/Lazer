using System.Runtime.CompilerServices;
using Lazer.Runtime;

public static unsafe class ApplyCall
{
    public static Closure zero = new GHC.Types.IHash(0);
    public static Function add1L = new Fun(1, CLR.LoadFunctionPointer<long, long>(add1_long));
    public static Function add1C = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(add1_closure));
    public const int EXEC_TIMES = 100_000;

    public static long add1_long_inlinable(long a) => a + 1;

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long add1_long(long a) => a + 1;

    public static Closure add1_closure_inlinable(Closure i)
        => new GHC.Types.IHash(1 + (i.Eval() as GHC.Types.IHash).x0);

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Closure add1_closure(Closure i)
        => new GHC.Types.IHash(1 + (i.Eval() as GHC.Types.IHash).x0);

    public static Closure loopCallLongInline(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + add1_long_inlinable(n);
        return loopCallLongInline(x, n - 1);
    }
    public static Closure loopCallWLongInline(Closure w, long n)
    {
        if (n == 0) return w.Eval();
        var wVal = (w.Eval() as GHC.Types.IHash).x0;
        var x = new GHC.Types.IHash(wVal + add1_long_inlinable(n));
        return loopCallWLongInline(x, n - 1);
    }
    public static Closure loopCallNClosureInline(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var k = (add1_closure_inlinable(new GHC.Types.IHash(n)) as GHC.Types.IHash).x0;
        var x = w + k;
        return loopCallNClosureInline(x, n - 1);
    }
    public static Closure loopCallLongNoInline(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + add1_long(n);
        return loopCallLongNoInline(x, n - 1);
    }
    public static Closure loopCallWLongNoInline(Closure w, long n)
    {
        if (n == 0) return w.Eval();
        var wVal = (w.Eval() as GHC.Types.IHash).x0;
        var x = new GHC.Types.IHash(wVal + add1_long(n));
        return loopCallWLongNoInline(x, n - 1);
    }
    public static Closure loopCallNClosureNoInline(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var k = (add1_closure(new GHC.Types.IHash(n)) as GHC.Types.IHash).x0;
        var x = w + k;
        return loopCallNClosureNoInline(x, n - 1);
    }
    public static Closure loopAppLong(Closure f, long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + f.Apply<long, long>(n);
        return loopAppLong(f, x, n - 1);
    }
    public static Closure loopAppLongNonGenericInd(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + LongApper.Instance.ApplyIndirect(n);
        return loopAppLongNonGenericInd(x, n - 1);
    }
    public static Closure loopAppLongNonGenericDir(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + LongApper.Instance.ApplyIndirect(n);
        return loopAppLongNonGenericDir(x, n - 1);
    }
    public static Closure loopAppLongGeneric(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + LongApper.Instance.ApplyGen<long, long>(n);
        return loopAppLongGeneric(x, n - 1);
    }
    private static Function funA = new FunA();
    public static Closure loopAppLongGenericClosure(long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var x = w + funA.Apply<long, long>(n);
        return loopAppLongGenericClosure(x, n - 1);
    }
    public static Closure loopAppClosure(Closure f, long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        var k = (f.Apply<Closure, Closure>(new GHC.Types.IHash(n)) as GHC.Types.IHash).x0;
        var x = w + k;
        return loopAppClosure(f, x, n - 1);
    }

    private static GHC.Types.IHash cache = new GHC.Types.IHash(0);
    public static Closure loopAppClosureWithCache(Closure f, long w, long n)
    {
        if (n == 0) return new GHC.Types.IHash(w);
        cache.x0 = n;
        // f is pure and returns a constructed value which means that
        // cache never escapes this method call - it's safe to modify
        var k = (f.Apply<Closure, Closure>(cache) as GHC.Types.IHash).x0;
        var x = w + k;
        return loopAppClosure(f, x, n - 1);
    }

    public abstract class LongApperBase
    {
        public abstract long ApplyIndirect(long x);
        public abstract long ApplyDirect(long x);
        public abstract R ApplyGen<T, R>(T x);
    }
    public unsafe class LongApper : LongApperBase

    {
        public static LongApperBase Instance = new LongApper();
        private void* f = CLR.LoadFunctionPointer<long, long>(add1_long);
        public override long ApplyIndirect(long x)
            => CLR.TailCallIndirectGeneric<long, long>(x, f);
        public override long ApplyDirect(long x)
                => add1_long(x);
        public override R ApplyGen<T, R>(T x)
            => CLR.TailCallIndirectGeneric<T, R>(x, f);
    }
    public unsafe class FunA : Function
    {
        private void* f = CLR.LoadFunctionPointer<long, long>(add1_long);
        public override int Arity => 1;
        public override R ApplyImpl<A1, R>(A1 a1)
        {
            var x = add1_long(Unsafe.As<A1, long>(ref a1));
            return Unsafe.As<long, R>(ref x);
        }
        public override R ApplyImpl<A1, A2, R>(A1 a1, A2 a2)
            => throw new System.Exception();
        public override R ApplyImpl<A1, A2, A3, R>(A1 a1, A2 a2, A3 a3)
            => throw new System.Exception();
        public override R ApplyImpl<A1, A2, A3, A4, R>(A1 a1, A2 a2, A3 a3, A4 a4)
            => throw new System.Exception();
        public override R ApplyImpl<A1, A2, A3, A4, A5, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5)
            => throw new System.Exception();
        public override R ApplyImpl<A1, A2, A3, A4, A5, A6, R>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6)
            => throw new System.Exception();
    }
}