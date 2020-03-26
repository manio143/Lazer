using System;
using System.Numerics;
using Lazer.Runtime;
using static Module;

public sealed class Nil : Data
{
    public override string ToString() => "[]";
    public override int Tag => 0;
}
public sealed class Cons : Data
{
    public Closure x0;
    public Closure x1;

    public override int Tag => 1;
    public Cons(Closure x0, Closure x1)
    {
        this.x0 = x0;
        this.x1 = x1;
    }

    public override string ToString()
    {
        var ctx = new StgContext();
        var h = x0.Eval(ctx);
        var t = x1.Eval(ctx);
        return $"{h} : {t}";
    }
}

public sealed class I : Data
{
    public long x0;
    public I(long x0)
    {
        this.x0 = x0;
    }

    public override string ToString() => x0.ToString();
}

public sealed class S : Data
{
    public BigInteger x0;
    public S(long x0)
        => this.x0 = new BigInteger(x0);
    public S(BigInteger x0) => this.x0 = x0;
    public override string ToString() => x0.ToString();
}

public static unsafe class Module
{
    public static Thunk fibs = new Updatable0(CLR.LoadFunctionPointer(Code.fibs_Entry));
    public static Thunk inf_s3cv = new Updatable0(CLR.LoadFunctionPointer(Code.inf_s3cv_Entry));
    public static I inf_s3ct = new I(1);
    public static Cons inf = new Cons(inf_s3ct, inf_s3cv);
    public static S lvl_s4BA = new S(60);
    public static S lvl_s4Bz = new S(180);
    public static S lvl_s4AW = new S(27);
    public static S lvl_s4AV = new S(12);
    public static S lvl_s4AU = new S(0);
    public static S lvl_s4AT = new S(3);
    public static S lvl_s4AS = new S(10);
    public static S lvl_s4AR = new S(5);
    public static S lvl_s4AQ = new S(2);
    public static S lvl_s4AP = new S(1);
    public static Thunk pi_ = new Updatable0(CLR.LoadFunctionPointer(Code.pi__Entry));
    public static Function inc = new Function1(CLR.LoadFunctionPointer(Code.inc_Entry));
    public static Function inc_ = new Function1(CLR.LoadFunctionPointer(Code.inc__Entry));
    public static Function gcd = new Function2(CLR.LoadFunctionPointer(Code.gcd_Entry));
    public static Function fibt = new Function1(CLR.LoadFunctionPointer(Code.fibt_Entry));
    public static Function fiba = new Function3(CLR.LoadFunctionPointer(Code.fiba_Entry));
    public static Function sum = new Function1(CLR.LoadFunctionPointer(Code.sum_Entry));
    public static Function sum2 = new Function1(CLR.LoadFunctionPointer(Code.sum2_Entry));
    public static Function suma = new Function2(CLR.LoadFunctionPointer(Code.suma_Entry));
    public static Function takeOnStack = new Function2(CLR.LoadFunctionPointer(Code.takeOnStack_Entry));
    public static Function take = new Function2(CLR.LoadFunctionPointer(Code.take_Entry));
    public static Function facc2 = new Function1(CLR.LoadFunctionPointer(Code.facc2_Entry));
    public static Function foldl = new Function3(CLR.LoadFunctionPointer(Code.foldl_Entry));
    public static Function map = new Function2(CLR.LoadFunctionPointer(Code.map_Entry));
    public static Function sfoldl = new Function2(CLR.LoadFunctionPointer(Code.sfoldl_Entry));
    public static Function makeList = new Function2(CLR.LoadFunctionPointer(Code.makelist_Entry));
    public static Function sumFromTo = new Function2(CLR.LoadFunctionPointer(Code.sumFromTo_Entry));
    public static Function timesInteger = new Function2(CLR.LoadFunctionPointer(Code.timesInteger_Entry));
    public static Function plusInteger = new Function2(CLR.LoadFunctionPointer(Code.plusInteger_Entry));
    public static Function minusInteger = new Function2(CLR.LoadFunctionPointer(Code.minusInteger_Entry));
    public static Function integerToInt = new Function1(CLR.LoadFunctionPointer(Code.integerToInt_Entry));
    public static Nil nil = new Nil();
}

public static unsafe class Code
{
    public static Closure makelist_Entry(StgContext ctx, Closure a, Closure b)
    {
        var from = (a as I).x0;
        var to = (b as I).x0;
        return makelist_Go(ctx, from, to);
    }
    public static Closure makelist_Go(StgContext ctx, long from, long to)
    {
        if (from <= to)
        {
            var t = Updatable.Make(CLR.LoadFunctionPointer<long, long>(makelist_Go), from + 1, to);
            return ctx.Return(new Cons(new I(from), t));
        }
        return ctx.Return(nil);
    }
    public static Closure sfoldl_Entry(StgContext ctx, Closure a, Closure b)
    {
        return ctx.Eval(a, StgCont.Make(CLR.LoadFunctionPointer(sfoldl_Case), b));
    }
    public static Closure sfoldl_Case(StgContext ctx, Closure a, Closure b)
    {
        switch (a)
        {
            default: { throw new ImpossibleException(); }
            case I a_I:
                {
                    var x = a_I.x0;
                    var r = wfoldl_gos3NN_Entry(ctx, x, b);
                    return ctx.Return(new I(r));
                }
        }
    }
    public static long wfoldl_gos3NN_Entry(StgContext ctx, long ww_s3NO, Closure w_s3NP)
    {
        var wild_s3NQ = w_s3NP;
        wild_s3NQ = ctx.Eval(wild_s3NQ);
        switch (wild_s3NQ)
        {
            default: { throw new ImpossibleException(); }
            case Nil wild_s3NQ_Nil: { return ww_s3NO; }
            case Cons wild_s3NQ_Cons:
                {
                    var x = wild_s3NQ_Cons.x0;
                    var xs = wild_s3NQ_Cons.x1;
                    var wild1 = x;
                    wild1 = ctx.Eval(wild1);
                    switch (wild1)
                    {
                        default: { throw new ImpossibleException(); }
                        case I wild1_I:
                            {
                                var y = wild1_I.x0;
                                var sat_s3NV = ww_s3NO + y;
                                switch (sat_s3NV)
                                {
                                    default: { return wfoldl_gos3NN_Entry(ctx, sat_s3NV, xs); }
                                }
                            }
                    }
                }
        }
    }
    public static Closure fibs_Entry(StgContext ctx)
    {
        return map_Entry(ctx, fibt, inf);
    }
    public static Closure inf_s3cv_Entry(StgContext ctx)
    {
        return map_Entry(ctx, inc, inf);
    }
    public static Closure inc__Entry(StgContext ctx, Closure eta_B1)
    {
        return map_Entry(ctx, inc, eta_B1);
    }
    public static Closure inc_Entry(StgContext ctx, Closure ds1)
    {
        var wild1 = ds1;
        return ctx.Eval(wild1, StgCont.Make(CLR.LoadFunctionPointer(inc_Case_wild1)));
    }
    public static Closure inc_Case_wild1(StgContext ctx, Closure wild1)
    {
        switch (wild1)
        {
            default: { throw new ImpossibleException(); }
            case I wild1_I:
                {
                    var y = wild1_I.x0;
                    var sat_s3cr = 1 + y;
                    switch (sat_s3cr)
                    {
                        default:
                            {
                                return ctx.Return(new I(sat_s3cr));
                            }
                    }
                }
        }
    }
    public static Closure gcd_Entry(StgContext ctx, Closure w_s3cg, Closure w_s3ch)
    {
        var ww_s3ci = w_s3cg;
        return ctx.Eval(ww_s3ci, StgCont.Make(CLR.LoadFunctionPointer(gcd_Case_ww_s3ci), w_s3ch));
    }
    public static Closure gcd_Case_ww_s3ci(StgContext ctx, Closure ww_s3ci, Closure w_s3ch)
    {
        switch (ww_s3ci)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3ci_I:
                {
                    var ww_s3cj = ww_s3ci_I.x0;
                    var ww_s3ck = w_s3ch;
                    return ctx.Eval(ww_s3ck, StgCont.Make(CLR.LoadFunctionPointer<Closure, long>(gcd_Case_ww_s3ck), ww_s3cj));
                }
        }
    }
    public static Closure gcd_Case_ww_s3ck(StgContext ctx, Closure ww_s3ck, long ww_s3cj)
    {
        switch (ww_s3ck)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3ck_I:
                {
                    var ww_s3cl = ww_s3ck_I.x0;
                    var ww_s3cm = wgcds3c7_Entry(ctx, ww_s3cj, ww_s3cl);
                    switch (ww_s3cm) { default: { return ctx.Return(new I(ww_s3cm)); } }
                }
        }
    }
    public static long wgcds3c7_Entry(StgContext ctx, long ww_s3c8, long ww_s3c9)
    {
        var ds_s3ca = ww_s3c8;
        switch (ds_s3ca)
        {
            default:
                {
                    var ds_s3cb = ww_s3c9;
                    switch (ds_s3cb)
                    {
                        default:
                            {
                                var lwild_s3cc = (ds_s3ca > ds_s3cb) ? 1 : 0;
                                switch (lwild_s3cc)
                                {
                                    default:
                                        {
                                            var sat_s3cd = ds_s3cb - ds_s3ca;
                                            switch (sat_s3cd)
                                            {
                                                default: { return wgcds3c7_Entry(ctx, ds_s3ca, sat_s3cd); }
                                            }
                                        }
                                    case 1:
                                        {
                                            var sat_s3ce = ds_s3ca - ds_s3cb;
                                            switch (sat_s3ce)
                                            {
                                                default: { return wgcds3c7_Entry(ctx, sat_s3ce, ds_s3cb); }
                                            }
                                        }
                                }
                            }
                        case 0: { return ds_s3ca; }
                    }
                }
            case 0: { return ww_s3c9; }
        }
    }
    public static Closure fibt_Entry(StgContext ctx, Closure w_s3c3)
    {
        var ww_s3c4 = w_s3c3;
        return ctx.Eval(ww_s3c4, StgCont.Make(CLR.LoadFunctionPointer(fibt_Case_ww_s3c4)));
    }
    public static Closure fibt_Case_ww_s3c4(StgContext ctx, Closure ww_s3c4)
    {
        switch (ww_s3c4)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3c4_I:
                {
                    var ww_s3c5 = ww_s3c4_I.x0;
                    var ww_s3c6 = wfibas3bK_Entry(ctx, 0, 1, ww_s3c5);
                    switch (ww_s3c6)
                    {
                        default:
                            {
                                return ctx.Return(new I(ww_s3c6));
                            }
                    }
                }
        }
    }
    public static Closure fiba_Entry(StgContext ctx, Closure w_s3bS, Closure w_s3bT, Closure w_s3bU)
    {
        var ww_s3bV = w_s3bS;
        return ctx.Eval(ww_s3bV, StgCont.Make(CLR.LoadFunctionPointer(fiba_Case_ww_s3bV), w_s3bT, w_s3bU));
    }
    public static Closure fiba_Case_ww_s3bV(StgContext ctx, Closure ww_s3bV, Closure w_s3bT, Closure w_s3bU)
    {
        switch (ww_s3bV)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bV_I:
                {
                    var ww_s3bW = ww_s3bV_I.x0;
                    var ww_s3bX = w_s3bT;
                    return ctx.Eval(ww_s3bX, StgCont.Make(CLR.LoadFunctionPointer<Closure, Closure, long>(fiba_Case_ww_s3bX), w_s3bU, ww_s3bW));
                }
        }
    }
    public static Closure fiba_Case_ww_s3bX(StgContext ctx, Closure ww_s3bX, Closure w_s3bU, long ww_s3bW)
    {
        switch (ww_s3bX)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bX_I:
                {
                    var ww_s3bY = ww_s3bX_I.x0;
                    var ww_s3bZ = w_s3bU;
                    return ctx.Eval(ww_s3bZ, StgCont.Make(CLR.LoadFunctionPointer<Closure, long, long>(fiba_Case_ww_s3bZ), ww_s3bW, ww_s3bY));
                }
        }
    }
    public static Closure fiba_Case_ww_s3bZ(StgContext ctx, Closure ww_s3bZ, long ww_s3bW, long ww_s3bY)
    {
        switch (ww_s3bZ)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bZ_I:
                {
                    var ww_s3c0 = ww_s3bZ_I.x0;
                    var ww_s3c1 = wfibas3bK_Entry(ctx, ww_s3bW, ww_s3bY, ww_s3c0);
                    return ctx.Return(new I(ww_s3c1));
                }
        }
    }
    public static long wfibas3bK_Entry(StgContext ctx, long ww_s3bL, long ww_s3bM, long ww_s3bN)
    {
        var lwild_s3bO = (ww_s3bN <= 0) ? 1 : 0;
        switch (lwild_s3bO)
        {
            default:
                {
                    var sat_s3bQ = ww_s3bN - 1;
                    var sat_s3bP = ww_s3bL + ww_s3bM;
                    return wfibas3bK_Entry(ctx, ww_s3bM, sat_s3bP, sat_s3bQ);
                }
            case 1: { return ww_s3bL; }
        }
    }
    public static Closure sum_Entry(StgContext ctx, Closure w_s3bI)
    {
        var ww_s3bJ = wsums3bz_Entry(ctx, w_s3bI);
        switch (ww_s3bJ) { default: { return ctx.Return(new I(ww_s3bJ)); } }
    }

    public static Closure sum2_Entry(StgContext ctx, Closure l)
    {
        return ctx.Eval(l, StgCont.Make(CLR.LoadFunctionPointer(sum2_Case1)));
    }

    public static Closure sum2_Case1(StgContext ctx, Closure l)
    {
        switch (l)
        {
            default:
                {
                    throw new ImpossibleException();
                }
            case Nil wild_s3bB_Nil:
                {
                    return ctx.Return(new I(0));
                }
            case Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    return ctx.Eval(x, StgCont.Make(CLR.LoadFunctionPointer(sum2_Case2), xs));
                }
        }
    }
    public static Closure sum2_Case2(StgContext ctx, Closure x, Closure xs)
    {
        switch (x)
        {
            default:
                {
                    throw new ImpossibleException();
                }
            case I wild_I:
                {
                    var x2 = wild_I.x0;
                    var ww_s3bG = new App1n(sum2, xs);
                    return ctx.Eval(ww_s3bG, StgCont.Make(CLR.LoadFunctionPointer<Closure, long>(sum2_Case3), x2));
                }
        }
    }
    public static Closure sum2_Case3(StgContext ctx, Closure x, long x2)
    {
        var x1 = (x as I).x0;
        return ctx.Return(new I(x1 + x2));
    }

    public static long wsums3bz_Entry(StgContext ctx, Closure w_s3bA)
    {
        var wild_s3bB = w_s3bA;
        wild_s3bB = ctx.Eval(wild_s3bB);
        switch (wild_s3bB)
        {
            default:
                {
                    throw new ImpossibleException();
                }
            case Nil wild_s3bB_Nil:
                {
                    return 0;
                }
            case Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    x = ctx.Eval(x);
                    var x2 = (x as I).x0;
                    var ww_s3bG = wsums3bz_Entry(ctx, xs);
                    return x2 + ww_s3bG;
                }
        }
    }
    public static Closure suma_Entry(StgContext ctx, Closure w_s3bu, Closure w_s3bv)
    {
        var ww_s3bw = w_s3bv;
        return ctx.Eval(ww_s3bw, StgCont.Make(CLR.LoadFunctionPointer(suma_Case_ww_s3bw), w_s3bu));
    }
    public static Closure suma_Case_ww_s3bw(StgContext ctx, Closure ww_s3bw, Closure w_s3bu)
    {
        switch (ww_s3bw)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bw_I:
                {
                    var ww_s3bx = ww_s3bw_I.x0;
                    var ww_s3by = wsumas3bk_Entry(ctx, w_s3bu, ww_s3bx);
                    switch (ww_s3by)
                    {
                        default:
                            {
                                return ctx.Return(new I(ww_s3by));
                            }
                    }
                }
        }
    }
    public static long wsumas3bk_Entry(StgContext ctx, Closure w_s3bl, long ww_s3bm)
    {
        var wild_s3bn = w_s3bl;
        wild_s3bn = ctx.Eval(wild_s3bn);
        switch (wild_s3bn)
        {
            default: { throw new ImpossibleException(); }
            case Cons
                wild_s3bn_Cons:
                {
                    var x = wild_s3bn_Cons.x0;
                    var xs = wild_s3bn_Cons.x1;
                    var wild = x;
                    wild = ctx.Eval(wild);
                    switch (wild)
                    {
                        default: { throw new ImpossibleException(); }
                        case I wild_I:
                            {
                                var x2 = wild_I.x0;
                                var sat_s3bs = x2 + ww_s3bm;
                                switch (sat_s3bs)
                                {
                                    default: { return wsumas3bk_Entry(ctx, xs, sat_s3bs); }
                                }
                            }
                    }
                }
            case Nil wild_s3bn_Nil: { return ww_s3bm; }
        }
    }
    public static Closure takeOnStack_Entry(StgContext ctx, Closure n, Closure l)
    {
        n = ctx.Eval(n);
        var nn = (n as I).x0;
        return takeOnStack_Entry2(ctx, nn, l);
    }

    public static Closure takeOnStack_Entry2(StgContext ctx, long nn, Closure l)
    {
        if (nn == 0)
            return ctx.Return(nil);
        l = ctx.Eval(l);
        switch (l)
        {
            default: { throw new ImpossibleException(); }
            case Cons wild_s3MH_Cons:
                {
                    var h = wild_s3MH_Cons.x0;
                    var t = wild_s3MH_Cons.x1;
                    var takeOnStack = Updatable.Make(CLR.LoadFunctionPointer<long, Closure>(takeOnStack_Thunk), nn, t);
                    return ctx.Return(new Cons(h, takeOnStack));
                }
            case Nil wild_s3MH_Nil: { return ctx.Return(nil); }
        }
    }
    public static Closure takeOnStack_Thunk(StgContext ctx, long nn, Closure t)
    {
        return takeOnStack_Entry2(ctx, nn - 1, t);
    }

    public static Closure take_Entry(StgContext ctx, Closure w_s3MN, Closure w_s3MO)
    {
        var ww_s3MP = w_s3MN;
        return ctx.Eval(ww_s3MP, StgCont.Make(CLR.LoadFunctionPointer(take_Case_ww_s3MP), w_s3MO));
    }
    public static Closure take_Case_ww_s3MP(StgContext ctx, Closure ww_s3MP, Closure w_s3MO)
    {
        switch (ww_s3MP)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3MP_I:
                {
                    var ww_s3MQ = ww_s3MP_I.x0;
                    return wtakes3MD_Entry(ctx, ww_s3MQ, w_s3MO);
                }
        }
    }
    public static Closure wtakes3MD_Entry(StgContext ctx, long ww_s3ME, Closure w_s3MF)
    {
        var ds_s3MG = ww_s3ME;
        switch (ds_s3MG)
        {
            default:
                {
                    var wild_s3MH = w_s3MF;
                    return ctx.Eval(wild_s3MH, StgCont.Make(CLR.LoadFunctionPointer<Closure, long>(wtakes3MD_Case_wild_s3MH), ds_s3MG));
                }
            case 0: { return ctx.Return(nil); }
        }
    }
    public static Closure wtakes3MD_Case_wild_s3MH(StgContext ctx, Closure wild_s3MH, long ds_s3MG)
    {
        switch (wild_s3MH)
        {
            default: { throw new ImpossibleException(); }
            case Cons wild_s3MH_Cons:
                {
                    var h = wild_s3MH_Cons.x0;
                    var t = wild_s3MH_Cons.x1;
                    var sat_s3ML = Updatable.Make(CLR.LoadFunctionPointer<long, Closure>(sat_s3ML_Entry), ds_s3MG, t);
                    return ctx.Return(new Cons(h, sat_s3ML));
                }
            case Nil wild_s3MH_Nil: { return ctx.Return(nil); }
        }
    }
    public static Closure sat_s3ML_Entry(StgContext ctx, long ds_s3MG, Closure t)
    {
        var sat_s3MK = ds_s3MG - 1;
        switch (sat_s3MK)
        {
            default: { return wtakes3MD_Entry(ctx, sat_s3MK, t); }
        }
    }
    public static Closure facc2_Entry(StgContext ctx, Closure w_s3b4)
    {
        var ww_s3b5 = w_s3b4;
        return ctx.Eval(ww_s3b5, StgCont.Make(CLR.LoadFunctionPointer(facc2_Case_ww_s3b5)));
    }
    public static Closure facc2_Case_ww_s3b5(StgContext ctx, Closure ww_s3b5)
    {
        switch (ww_s3b5)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3b5_I:
                {
                    var ww_s3b6 = ww_s3b5_I.x0;
                    var ww_s3b7 = wfacc2s3aX_Entry(ctx, ww_s3b6);
                    switch (ww_s3b7)
                    {
                        default:
                            {
                                return ctx.Return(new I(ww_s3b7));
                            }
                    }
                }
        }
    }
    public static long wfacc2s3aX_Entry(StgContext ctx, long ww_s3aY)
    {
        var lwild_s3aZ = (ww_s3aY <= 1) ? 1 : 0;
        switch (lwild_s3aZ)
        {
            default:
                {
                    var sat_s3b0 = ww_s3aY - 1;
                    switch (sat_s3b0)
                    {
                        default:
                            {
                                var ww_s3b1 = wfacc2s3aX_Entry(ctx, sat_s3b0);
                                switch (ww_s3b1)
                                {
                                    default:
                                        {
                                            var sat_s3b2 = ww_s3aY * ww_s3b1;
                                            switch (sat_s3b2) { default: { return sat_s3b2 + 1; } }
                                        }
                                }
                            }
                    }
                }
            case 1: { return 2; }
        }
    }
    public static Closure foldl_Entry(StgContext ctx, Closure f, Closure x0, Closure xs)
    {
        var foldl_go = Function2.Make<Closure, Closure>(CLR.LoadFunctionPointer(foldl_go_Entry), f, null);
        foldl_go.x1 = foldl_go;
        return StgApply.Apply(ctx, foldl_go, x0, xs);
    }
    public static Closure foldl_go_Entry(StgContext ctx, Closure f, Closure foldl_go, Closure x0, Closure ds_s3aN)
    {
        var wild_s3aO = ds_s3aN;
        return ctx.Eval(wild_s3aO, StgCont.Make(CLR.LoadFunctionPointer(foldl_go_Case_wild_s3aO), x0, f, foldl_go));
    }
    public static Closure foldl_go_Case_wild_s3aO(StgContext ctx, Closure wild_s3aO, Closure x0, Closure f, Closure foldl_go)
    {
        switch (wild_s3aO)
        {
            default: { throw new ImpossibleException(); }
            case Nil wild_s3aO_Nil: { return ctx.Return(x0); }
            case Cons
                wild_s3aO_Cons:
                {
                    var x = wild_s3aO_Cons.x0;
                    var xs = wild_s3aO_Cons.x1;
                    var sat_s3aR = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aR_Entry), f, x0, x);
                    return StgApply.Apply(ctx, foldl_go, sat_s3aR, xs);
                }
        }
    }
    public static Closure sat_s3aR_Entry(StgContext ctx, Closure f, Closure x0, Closure x)
    {
        return StgApply.Apply(ctx, f, x0, x);
    }
    public static Closure map_Entry(StgContext ctx, Closure f, Closure ds_s3aB)
    {
        var wild_s3aC = ds_s3aB;
        return ctx.Eval(wild_s3aC, StgCont.Make(CLR.LoadFunctionPointer(map_Case_wild_s3aC), f));
    }
    public static Closure map_Case_wild_s3aC(StgContext ctx, Closure wild_s3aC, Closure f)
    {
        switch (wild_s3aC)
        {
            default: { throw new ImpossibleException(); }
            case Nil wild_s3aC_Nil: { return ctx.Return(nil); }
            case Cons
                wild_s3aC_Cons:
                {
                    var h = wild_s3aC_Cons.x0;
                    var t = wild_s3aC_Cons.x1;
                    var sat_s3aG = Updatable.Make(CLR.LoadFunctionPointer(map_Entry), f, t);
                    var sat_s3aF = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aF_Entry), f, h);
                    return ctx.Return(new Cons(sat_s3aF, sat_s3aG));
                }
        }
    }
    public static Closure sat_s3aF_Entry(StgContext ctx, Closure f, Closure h)
    {
        return StgApply.Apply(ctx, f, h);
    }

    public static Closure sumFromTo_Entry(StgContext ctx, Closure from, Closure to)
    {
        var vc_ = from;
        return ctx.Eval(vc_, StgCont.Make(CLR.LoadFunctionPointer(sumFromTo_Case_vc_), to));
    }
    public static Closure sumFromTo_Case_vc_(StgContext ctx, Closure vc_, Closure to)
    {
        var vc__I = vc_ as I;
        var wc_ = vc__I.x0;
        var xc_ = to;
        return ctx.Eval(xc_, StgCont.Make(CLR.LoadFunctionPointer<Closure, long>(sumFromTo_Case_xc_), wc_));
    }
    public static Closure sumFromTo_Case_xc_(StgContext ctx, Closure xc_, long wc_)
    {
        var xc__I = xc_ as I;
        var yc_ = xc__I.x0;
        var ad_ = wgos49U_Entry(ctx, wc_, yc_, 0);
        return ctx.Return(new I(ad_));
    }
    public static long wgos49U_Entry(StgContext ctx, long ww_s49V, long ww_s49W, long ww_s49X)
    {
        var lc_ = (ww_s49V > ww_s49W) ? 1 : 0;
        switch (lc_)
        {
            default:
                {
                    var mc_ = ww_s49X + ww_s49V;
                    var nc_ = ww_s49V + 1;
                    return wgos49U_Entry(ctx, nc_, ww_s49W, mc_);
                }
            case 1: { return ww_s49X; }
        }
    }

    public static Closure pi__Entry(StgContext ctx)
    {
        var hf_ = wgs4AX_Entry(ctx, lvl_s4AP, lvl_s4Bz, lvl_s4BA, lvl_s4AQ);
        return ctx.Return(new Cons(hf_.Item1, hf_.Item2));
    }
    public static (Closure, Closure) wgs4AX_Entry(StgContext ctx, Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1)
    {
        var yd_ = Updatable.Make(CLR.LoadFunctionPointer(yd__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1);
        var he_ = Updatable.Make(CLR.LoadFunctionPointer(he__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1, yd_);
        return (yd_, he_);
    }
    public static Closure yd__Entry(StgContext ctx, Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1)
    {
        var ae_ = new App2n(timesInteger, lvl_s4AR, w_s4B0);
        return ctx.Eval(ae_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_ae_), w_s4AZ, w_s4B1, w_s4AY));
    }
    public static Closure yd__Case_ae_(StgContext ctx, Closure ae_, Closure w_s4AZ, Closure w_s4B1, Closure w_s4AY)
    {
        var be_ = (ae_ as S).x0 == lvl_s4AU.x0 ? 1 : 0;
        switch (be_)
        {
            default:
                {
                    var ce_ = new App2n(timesInteger, lvl_s4AR, w_s4AZ);
                    return ctx.Eval(ce_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_ce_), w_s4B1, w_s4AY, ae_));
                }
            case 1: { throw new Exception("Division by 0"); }
        }
    }
    public static Closure yd__Case_ce_(StgContext ctx, Closure ce_, Closure w_s4B1, Closure w_s4AY, Closure ae_)
    {
        var de_ = new App2n(timesInteger, lvl_s4AW, w_s4B1);
        return ctx.Eval(de_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_de_), w_s4AY, ce_, ae_));
    }
    public static Closure yd__Case_de_(StgContext ctx, Closure de_, Closure w_s4AY, Closure ce_, Closure ae_)
    {
        var ee_ = new App2n(minusInteger, de_, lvl_s4AV);
        return ctx.Eval(ee_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_ee_), w_s4AY, ce_, ae_));
    }
    public static Closure yd__Case_ee_(StgContext ctx, Closure ee_, Closure w_s4AY, Closure ce_, Closure ae_)
    {
        var fe_ = new App2n(timesInteger, w_s4AY, ee_);
        return ctx.Eval(fe_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_fe_), ce_, ae_));
    }
    public static Closure yd__Case_fe_(StgContext ctx, Closure fe_, Closure ce_, Closure ae_)
    {
        var ge_ = new App2n(plusInteger, fe_, ce_);
        return ctx.Eval(ge_, StgCont.Make(CLR.LoadFunctionPointer(yd__Case_ge_), ae_));
    }
    public static Closure yd__Case_ge_(StgContext ctx, Closure ge_, Closure ae_)
    {
        return divInteger_Entry(ctx, ge_, ae_);
    }
    public static Closure he__Entry(StgContext ctx, Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1, Closure yd_)
    {
        var ie_ = Updatable.Make(CLR.LoadFunctionPointer(ie__Entry), w_s4B1);
        var oe_ = Updatable.Make(CLR.LoadFunctionPointer(oe__Entry), w_s4B1);
        var pe_ = Updatable.Make(CLR.LoadFunctionPointer(pe__Entry), w_s4B0, ie_);
        var qe_ = Updatable.Make(CLR.LoadFunctionPointer(qe__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1, yd_, ie_);
        var ye_ = Updatable.Make(CLR.LoadFunctionPointer(ye__Entry), w_s4AY, w_s4B1);
        var ef_ = wgs4AX_Entry(ctx, ye_, qe_, pe_, oe_);
        return ctx.Return(new Cons(ef_.Item1, ef_.Item2));
    }
    public static Closure ie__Entry(StgContext ctx, Closure w_s4B1)
    {
        var je_ = new App2n(timesInteger, lvl_s4AT, w_s4B1);
        return ctx.Eval(je_, StgCont.Make(CLR.LoadFunctionPointer(ie__Case_je_), w_s4B1));
    }
    public static Closure ie__Case_je_(StgContext ctx, Closure je_, Closure w_s4B1)
    {
        var ke_ = new App2n(plusInteger, je_, lvl_s4AQ);
        return ctx.Eval(ke_, StgCont.Make(CLR.LoadFunctionPointer(ie__Case_ke_), w_s4B1, plusInteger));
    }
    public static Closure ie__Case_ke_(StgContext ctx, Closure ke_, Closure w_s4B1)
    {
        var le_ = new App2n(timesInteger, lvl_s4AT, w_s4B1);
        return ctx.Eval(le_, StgCont.Make(CLR.LoadFunctionPointer(ie__Case_le_), ke_));
    }
    public static Closure ie__Case_le_(StgContext ctx, Closure le_, Closure ke_)
    {
        var me_ = new App2n(plusInteger, le_, lvl_s4AP);
        return ctx.Eval(me_, StgCont.Make(CLR.LoadFunctionPointer(ie__Case_me_), ke_));
    }
    public static Closure ie__Case_me_(StgContext ctx, Closure me_, Closure ke_)
    {
        var ne_ = new App2n(timesInteger, lvl_s4AT, me_);
        return ctx.Eval(ne_, StgCont.Make(CLR.LoadFunctionPointer(ie__Case_ne_), ke_));
    }
    public static Closure ie__Case_ne_(StgContext ctx, Closure ne_, Closure ke_)
    {
        return timesInteger_Entry(ctx, ne_, ke_);
    }
    public static Closure oe__Entry(StgContext ctx, Closure w_s4B1)
    {
        return plusInteger_Entry(ctx, w_s4B1, lvl_s4AP);
    }
    public static Closure pe__Entry(StgContext ctx, Closure w_s4B0, Closure ie_)
    {
        return timesInteger_Entry(ctx, w_s4B0, ie_);
    }
    public static Closure qe__Entry(StgContext ctx, Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1, Closure yd_, Closure ie_)
    {
        var re_ = new App2n(timesInteger, yd_, w_s4B0);
        return ctx.Eval(re_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_re_), w_s4B1, w_s4AY, w_s4AZ, ie_));
    }
    public static Closure qe__Case_re_(StgContext ctx, Closure re_, Closure w_s4B1, Closure w_s4AY, Closure w_s4AZ, Closure ie_)
    {
        var se_ = new App2n(timesInteger, lvl_s4AR, w_s4B1);
        return ctx.Eval(se_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_se_), w_s4AY, w_s4AZ, re_, ie_));
    }
    public static Closure qe__Case_se_(StgContext ctx, Closure se_, Closure w_s4AY, Closure w_s4AZ, Closure re_, Closure ie_)
    {
        var te_ = new App2n(minusInteger, se_, lvl_s4AQ);
        return ctx.Eval(te_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_te_), w_s4AY, w_s4AZ, re_, ie_));
    }
    public static Closure qe__Case_te_(StgContext ctx, Closure te_, Closure w_s4AY, Closure w_s4AZ, Closure re_, Closure ie_)
    {
        var ue_ = new App2n(timesInteger, w_s4AY, te_);
        return ctx.Eval(ue_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_ue_), w_s4AZ, re_, ie_));
    }
    public static Closure qe__Case_ue_(StgContext ctx, Closure ue_, Closure w_s4AZ, Closure re_, Closure ie_)
    {
        var ve_ = new App2n(plusInteger, ue_, w_s4AZ);
        return ctx.Eval(ve_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_ve_), re_, ie_));
    }
    public static Closure qe__Case_ve_(StgContext ctx, Closure ve_, Closure re_, Closure ie_)
    {
        var we_ = new App2n(minusInteger, ve_, re_);
        return ctx.Eval(we_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_we_), ie_));
    }
    public static Closure qe__Case_we_(StgContext ctx, Closure we_, Closure ie_)
    {
        var xe_ = new App2n(timesInteger, lvl_s4AS, ie_);
        return ctx.Eval(xe_, StgCont.Make(CLR.LoadFunctionPointer(qe__Case_xe_), we_));
    }
    public static Closure qe__Case_xe_(StgContext ctx, Closure xe_, Closure we_)
    {
        return timesInteger_Entry(ctx, xe_, we_);
    }
    public static Closure ye__Entry(StgContext ctx, Closure w_s4AY, Closure w_s4B1)
    {
        var af_ = new App2n(timesInteger, lvl_s4AQ, w_s4B1);
        return ctx.Eval(af_, StgCont.Make(CLR.LoadFunctionPointer(ye__Case_af_), w_s4AY, w_s4B1));
    }
    public static Closure ye__Case_af_(StgContext ctx, Closure af_, Closure w_s4AY, Closure w_s4B1)
    {
        var bf_ = new App2n(minusInteger, af_, lvl_s4AP);
        return ctx.Eval(bf_, StgCont.Make(CLR.LoadFunctionPointer(ye__Case_bf_), w_s4AY, w_s4B1));
    }
    public static Closure ye__Case_bf_(StgContext ctx, Closure bf_, Closure w_s4AY, Closure w_s4B1)
    {
        var cf_ = new App2n(timesInteger, lvl_s4AS, w_s4AY);
        return ctx.Eval(cf_, StgCont.Make(CLR.LoadFunctionPointer(ye__Case_cf_), w_s4B1, bf_));
    }
    public static Closure ye__Case_cf_(StgContext ctx, Closure cf_, Closure w_s4B1, Closure bf_)
    {
        var df_ = new App2n(timesInteger, cf_, w_s4B1);
        return ctx.Eval(df_, StgCont.Make(CLR.LoadFunctionPointer(ye__Case_df_), bf_));
    }
    public static Closure ye__Case_df_(StgContext ctx, Closure df_, Closure bf_)
    {
        return timesInteger_Entry(ctx, df_, bf_);
    }

    public static Closure timesInteger_Entry(StgContext ctx, Closure a, Closure b)
    {
        a = ctx.Eval(a);
        b = ctx.Eval(b);
        return ctx.Return(new S((a as S).x0 * (b as S).x0));
    }
    public static Closure plusInteger_Entry(StgContext ctx, Closure a, Closure b)
    {
        a = ctx.Eval(a);
        b = ctx.Eval(b);
        return ctx.Return(new S((a as S).x0 + (b as S).x0));
    }
    public static Closure minusInteger_Entry(StgContext ctx, Closure a, Closure b)
    {
        a = ctx.Eval(a);
        b = ctx.Eval(b);
        return ctx.Return(new S((a as S).x0 - (b as S).x0));
    }
    public static Closure divInteger_Entry(StgContext ctx, Closure a, Closure b)
    {
        a = ctx.Eval(a);
        b = ctx.Eval(b);
        return ctx.Return(new S((a as S).x0 / (b as S).x0));
    }
    public static Closure integerToInt_Entry(StgContext ctx, Closure i)
    {
        i = ctx.Eval(i);
        return ctx.Return(new I((long)(i as S).x0));
    }
}
