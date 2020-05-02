using System.Runtime.CompilerServices;
using Lazer.Runtime;
using static Manual;
using static GHC.Tuple;

public static unsafe class ManualTest
{
    public const int EXEC_TIMES = 100_000;

    public static Closure sumTakeInf()
    {
        var list = take.Apply<long, Closure, Closure>(EXEC_TIMES, inf);
        var res = sum.Apply<Closure, long>(list);
        return new GHC.Types.IHash(res);
    }
    public static Closure sumMakelist()
    {
        var list = makelist.Apply<long, long, Closure>(0, EXEC_TIMES);
        var res = sum.Apply<Closure, long>(list);
        return new GHC.Types.IHash(res);
    }
    public static Closure sumfoldTakeInf()
    {
        var list = take.Apply<long, Closure, Closure>(EXEC_TIMES, inf);
        var res = sumfold.Apply<long, Closure, long>(0, list);
        return new GHC.Types.IHash(res);
    }
    public static Closure sumfoldMakelist()
    {
        var list = makelist.Apply<long, long, Closure>(0, EXEC_TIMES);
        var res = sumfold.Apply<long, Closure, long>(0, list);
        return new GHC.Types.IHash(res);
    }
    public static Closure lengthMakelist()
    {
        var list = makelist.Apply<long, long, Closure>(0, EXEC_TIMES);
        var res = length_Entry(list);
        return new GHC.Types.IHash(res);
    }
    public static Closure lengthTakeInf()
    {
        var list = take.Apply<long, Closure, Closure>(EXEC_TIMES, inf);
        var res = length_Entry(list);
        return new GHC.Types.IHash(res);
    }
    public static Closure nthMakelist()
    {
        var list = makelist.Apply<long, long, Closure>(0, EXEC_TIMES + 1);
        var res = nth_Entry(EXEC_TIMES, list);
        return res;
    }
    public static Closure nthTakeInf()
    {
        var list = take.Apply<long, Closure, Closure>(EXEC_TIMES + 1, inf);
        var res = nth_Entry(EXEC_TIMES, list);
        return res;
    }
    public static Closure nthInf()
    {
        var res = nth_Entry(EXEC_TIMES, inf);
        return res;
    }

    public static Closure evalData()
    {
        var c = evalWork();
        for (int i = 0; i < EXEC_TIMES; i++)
            c.Eval();
        return c;
    }
    public static Closure evalThunk()
    {
        var c = new Updatable(&evalWork);
        for (int i = 0; i < EXEC_TIMES; i++)
            c.Eval();
        return c;
    }
    public static Closure evalRepeatWork()
    {
        var c = new SingleEntry(&evalWork);
        for (int i = 0; i < EXEC_TIMES; i++)
            c.Eval();
        return c;
    }
    public static Closure evalRepeatWorkInline()
    {
        Closure c = null;
        for (int i = 0; i < EXEC_TIMES; i++)
            c = evalWork();
        return c;
    }
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static Closure evalWork() => new GHC.Types.IHash(1);

    public static Closure callMakeListInLoop()
    {
        Closure c = null;
        for (int i = 0; i < EXEC_TIMES; i++)
            c = makelist_Go(i, EXEC_TIMES);
        return c;
    }
    public static Closure callCreateSingleton()
    {
        Closure c = null;
        for (int i = 0; i < EXEC_TIMES; i++)
            c = createSingleton();
        return c;
    }
    private static Closure createSingleton()
    {
        // accessing Manual.one take 0.3ms over 100_000 iterations
        return new GHC.Types.Cons(null, GHC.Types.nil_DataCon);
    }
    public static Closure callNewObj()
    {
        for (int i = 0; i < EXEC_TIMES; i++)
            createNewObj();
        return GHC.Types.nil_DataCon;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    private static object createNewObj() => new object();
}

public static unsafe class Manual
{
    public static Function makelist = new Fun2<long, long, Closure>(&makelist_Go);
    public static Function sumfold = new Fun2<long, Closure, long>(&sumfold_Entry);
    public static Function sum = new Fun1<Closure, long>(&sum_Entry);
    public static Function suma = new Fun2<Closure, Closure, Closure>(&suma_Entry);
    public static Function take = new Fun2<long, Closure, Closure>(&take_Entry);

    public static GHC.Types.IHash zero = new GHC.Types.IHash(0);
    public static GHC.Types.IHash one = new GHC.Types.IHash(1);
    public static GHC.Types.Cons inf;

    static Manual()
    {
        inf = new GHC.Types.Cons(one, new Updatable(&inf_Entry));
    }

    public static Closure makelist_Go(long from, long to)
    {
        if (from <= to)
        {
            var t = new Updatable<(long, long)>(&makelist_Go_thunk, (from, to));
            return new GHC.Types.Cons(new GHC.Types.IHash(from), t);
        }
        return GHC.Types.nil_DataCon;
    }
    public static Closure makelist_Go_thunk(in (long from, long to) free)
        => makelist_Go(free.from + 1, free.to);

    public static long sumfold_Entry(long acc, Closure l)
    {
        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[Int]", al.GetType().ToString());
            case GHC.Types.Nil nil: return acc;
            case GHC.Types.Cons cons:
                var h = cons.x0.Eval() as GHC.Types.IHash;
                return sumfold_Entry(acc + h.x0, cons.x1);
        }
    }

    public static Closure mapInc_Entry(Closure l)
    {
        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[Int]", al.GetType().ToString());
            case GHC.Types.Nil nil: return GHC.Types.nil_DataCon.Eval();
            case GHC.Types.Cons cons:
                var h = cons.x0.Eval() as GHC.Types.IHash;
                var nh = new GHC.Types.IHash(h.x0 + 1);
                var nt = new Updatable<Closure>(&mapInc_Thunk, cons.x1);
                return new GHC.Types.Cons(nh, nt);
        }
    }
    private static Closure mapInc_Thunk(in Closure t) => mapInc_Entry(t);

    public static Closure inf_Entry() => mapInc_Entry(inf);

    public static long sum_Entry(Closure l)
    {
        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[Int]", al.GetType().ToString());
            case GHC.Types.Nil nil: return 0;
            case GHC.Types.Cons cons:
                var h = cons.x0.Eval() as GHC.Types.IHash;
                var i = h.x0;
                var st = sum_Entry(cons.x1);
                return i + st;
        }
    }

    public static Closure take_Entry(long n, Closure l)
    {
        if (n == 0) return GHC.Types.nil_DataCon.Eval();

        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[a]", al.GetType().ToString());
            case GHC.Types.Nil nil: return GHC.Types.nil_DataCon.Eval();
            case GHC.Types.Cons cons:
                var t = new Updatable<(long, Closure)>(&take_Thunk, (n, cons.x1));
                return new GHC.Types.Cons(cons.x0, t);
        }
    }
    public static Closure take_Thunk(in (long n, Closure t) free)
        => take_Entry(free.n - 1, free.t);

    public static long length_Entry(Closure l) => length_loop_Entry(0, l);
    public static long length_loop_Entry(long acc, Closure l)
    {
        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[a]", al.GetType().ToString());
            case GHC.Types.Nil nil: return acc;
            case GHC.Types.Cons cons:
                return length_loop_Entry(acc + 1, cons.x1);
        }
    }

    public static Closure nth_Entry(long n, Closure l)
    {
        var al = l.Eval();
        switch (al)
        {
            default: throw new ImpossibleException("[a]", al.GetType().ToString());
            case GHC.Types.Nil nil: throw new System.Exception("nth: empty list");
            case GHC.Types.Cons cons:
                if (n == 0)
                    return cons.x0;
                return nth_Entry(n - 1, cons.x1);
        }
    }

    public static Closure suma_Entry(Closure l, Closure acc)
    {
        var accI = acc.Eval() as GHC.Types.IHash;
        var accVal = accI.x0;
        var res = wsumas3bk_Entry(l, accVal);
        return new GHC.Types.IHash(res);
    }
    public static long wsumas3bk_Entry(Closure l, long acc)
    {
        var wild_s3bn = l.Eval();
        switch (wild_s3bn)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Cons cons:
                {
                    var x = cons.x0;
                    var xs = cons.x1;
                    var wildI = x.Eval() as GHC.Types.IHash;
                    var x2 = wildI.x0;
                    var sat_s3bs = x2 + acc;
                    return wsumas3bk_Entry(xs, sat_s3bs);
                }
            case GHC.Types.Nil nil: { return acc; }
        }
    }
}