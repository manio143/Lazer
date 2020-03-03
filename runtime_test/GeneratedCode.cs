using Lazer.Runtime;
using static Module;

public class Nil : Data { }
public class Cons : Data
{
    public Closure x0;
    public Closure x1;

    public Cons(Closure x0, Closure x1)
    {
        this.x0 = x0;
        this.x1 = x1;
    }
}

public class I : Data
{
    public int x0;
    public I(int x0)
    {
        this.x0 = x0;
    }
}

public static unsafe class Module
{
    public static Thunk fibs = new Updatable0(CLR.LoadFunctionPointer(Code.fibs_Entry));
    public static Thunk inf_s3cv = new Updatable0(CLR.LoadFunctionPointer(Code.inf_s3cv_Entry));
    public static I inf_s3ct = new I(1);
    public static Cons inf = new Cons(inf_s3ct, inf_s3cv);
    public static Function inc = new Function1(CLR.LoadFunctionPointer(Code.inc_Entry));
    public static Function inc_ = new Function1(CLR.LoadFunctionPointer(Code.inc__Entry));
    public static Function gcd = new Function2(CLR.LoadFunctionPointer(Code.gcd_Entry));
    public static Function fibt = new Function1(CLR.LoadFunctionPointer(Code.fibt_Entry));
    public static Function fiba = new Function3(CLR.LoadFunctionPointer(Code.fiba_Entry));
    public static Function sum = new Function1(CLR.LoadFunctionPointer(Code.sum_Entry));
    public static Function suma = new Function2(CLR.LoadFunctionPointer(Code.suma_Entry));
    public static Function take = new Function2(CLR.LoadFunctionPointer(Code.take_Entry));
    public static Function facc2 = new Function1(CLR.LoadFunctionPointer(Code.facc2_Entry));
    public static Function foldl = new Function3(CLR.LoadFunctionPointer(Code.foldl_Entry));
    public static Function map = new Function2(CLR.LoadFunctionPointer(Code.map_Entry));
    public static Function sfoldl = new Function2(CLR.LoadFunctionPointer(Code.sfoldl_Entry));
    public static Function makeList = new Function2(CLR.LoadFunctionPointer(Code.makelist_Entry));
}

public static unsafe class Code
{
    public static Closure makelist_Entry(StgContext ctx, Closure a, Closure b)
    {
        var from = (a as I).x0;
        var to = (b as I).x0;
        return makelist_Go(ctx, from, to);
    }
    public static Closure makelist_Go(StgContext ctx, int from, int to)
    {
        if (from <= to)
        {
            var t = Updatable.Make(CLR.LoadFunctionPointer<StgContext, int, int, Closure>(makelist_Go), from + 1, to);
            return new Cons(new I(from), t).Eval(ctx);
        }
        return new Nil().Eval(ctx);
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
                    return new I(r).Eval(ctx);
                }
        }
    }
    public static int wfoldl_gos3NN_Entry(StgContext ctx, int ww_s3NO, Closure w_s3NP)
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
                                return new I(sat_s3cr).Eval(ctx);
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
                    return ctx.Eval(ww_s3ck, StgCont.Make(CLR.LoadFunctionPointer<StgContext, Closure, int, Closure>(gcd_Case_ww_s3ck), ww_s3cj));
                }
        }
    }
    public static Closure gcd_Case_ww_s3ck(StgContext ctx, Closure ww_s3ck, int ww_s3cj)
    {
        switch (ww_s3ck)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3ck_I:
                {
                    var ww_s3cl = ww_s3ck_I.x0;
                    var ww_s3cm = wgcds3c7_Entry(ctx, ww_s3cj, ww_s3cl);
                    switch (ww_s3cm) { default: { return new I(ww_s3cm).Eval(ctx); } }
                }
        }
    }
    public static int wgcds3c7_Entry(StgContext ctx, int ww_s3c8, int ww_s3c9)
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
                                return new I(ww_s3c6).Eval(ctx);
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
                    return ctx.Eval(ww_s3bX, StgCont.Make(CLR.LoadFunctionPointer<StgContext, Closure, Closure, int, Closure>(fiba_Case_ww_s3bX), w_s3bU, ww_s3bW));
                }
        }
    }
    public static Closure fiba_Case_ww_s3bX(StgContext ctx, Closure ww_s3bX, Closure w_s3bU, int ww_s3bW)
    {
        switch (ww_s3bX)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bX_I:
                {
                    var ww_s3bY = ww_s3bX_I.x0;
                    var ww_s3bZ = w_s3bU;
                    return ctx.Eval(ww_s3bZ, StgCont.Make(CLR.LoadFunctionPointer<StgContext, Closure, int, int, Closure>(fiba_Case_ww_s3bZ), ww_s3bW, ww_s3bY));
                }
        }
    }
    public static Closure fiba_Case_ww_s3bZ(StgContext ctx, Closure ww_s3bZ, int ww_s3bW, int ww_s3bY)
    {
        switch (ww_s3bZ)
        {
            default: { throw new ImpossibleException(); }
            case I ww_s3bZ_I:
                {
                    var ww_s3c0 = ww_s3bZ_I.x0;
                    var ww_s3c1 = wfibas3bK_Entry(ctx, ww_s3bW, ww_s3bY, ww_s3c0);
                    return new I(ww_s3c1).Eval(ctx);
                }
        }
    }
    public static int wfibas3bK_Entry(StgContext ctx, int ww_s3bL, int ww_s3bM, int ww_s3bN)
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
        switch (ww_s3bJ) { default: { return new I(ww_s3bJ).Eval(ctx); } }
    }

    public static int wsums3bz_Entry(StgContext ctx, Closure w_s3bA)
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
                return wsums3bz_Entry2(ctx, x, xs);
            }
        }
    }
    
    public static int wsums3bz_Entry2(StgContext ctx, Closure x, Closure xs)
    {
        var wild = x;
        wild = ctx.Eval(wild);
        switch (wild)
        {
            default:
            {
                throw new ImpossibleException();
            }
            case I wild_I:
            {
                var x2 = wild_I.x0;
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
                                return new I(ww_s3by).Eval(ctx);
                            }
                    }
                }
        }
    }
    public static int wsumas3bk_Entry(StgContext ctx, Closure w_s3bl, int ww_s3bm)
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
    public static Closure wtakes3MD_Entry(StgContext ctx, int ww_s3ME, Closure w_s3MF)
    {
        var ds_s3MG = ww_s3ME;
        switch (ds_s3MG)
        {
            default:
                {
                    var wild_s3MH = w_s3MF;
                    return ctx.Eval(wild_s3MH, StgCont.Make(CLR.LoadFunctionPointer<StgContext, Closure, int, Closure>(wtakes3MD_Case_wild_s3MH), ds_s3MG));
                }
            case 0: { return new Nil().Eval(ctx); }
        }
    }
    public static Closure wtakes3MD_Case_wild_s3MH(StgContext ctx, Closure wild_s3MH, int ds_s3MG)
    {
        switch (wild_s3MH)
        {
            default: { throw new ImpossibleException(); }
            case Cons wild_s3MH_Cons:
                {
                    var h = wild_s3MH_Cons.x0;
                    var t = wild_s3MH_Cons.x1;
                    var sat_s3ML = Updatable.Make(CLR.LoadFunctionPointer<StgContext, int, Closure, Closure>(sat_s3ML_Entry), ds_s3MG, t);
                    return new Cons(h, sat_s3ML).Eval(ctx);
                }
            case Nil wild_s3MH_Nil: { return new Nil().Eval(ctx); }
        }
    }
    public static Closure sat_s3ML_Entry(StgContext ctx, int ds_s3MG, Closure t)
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
                                return new I(ww_s3b7).Eval(ctx);
                            }
                    }
                }
        }
    }
    public static int wfacc2s3aX_Entry(StgContext ctx, int ww_s3aY)
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
            case Nil wild_s3aO_Nil: { return x0.Eval(ctx); }
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
            case Nil wild_s3aC_Nil: { return new Nil().Eval(ctx); }
            case Cons
                wild_s3aC_Cons:
                {
                    var h = wild_s3aC_Cons.x0;
                    var t = wild_s3aC_Cons.x1;
                    var sat_s3aG = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aG_Entry), f, t);
                    var sat_s3aF = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aF_Entry), f, h);
                    return new Cons(sat_s3aF, sat_s3aG).Eval(ctx);
                }
        }
    }
    public static Closure sat_s3aG_Entry(StgContext ctx, Closure f, Closure t)
    {
        return map_Entry(ctx, f, t);
    }
    public static Closure sat_s3aF_Entry(StgContext ctx, Closure f, Closure h)
    {
        return StgApply.Apply(ctx, f, h);
    }
}
