using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Lazer.Runtime;
using static Module;

public sealed class O0 : Data
{
    public int x0;
    public O0(int x0) => this.x0 = x0;
    public override int Tag => 0;
}
public sealed class O1 : Data
{
    public int x0;
    public O1(int x0) => this.x0 = x0;
    public override int Tag => 1;
}
public sealed class O2 : Data
{
    public int x0;
    public O2(int x0) => this.x0 = x0;
    public override int Tag => 2;
}
public sealed class O3 : Data
{
    public int x0;
    public O3(int x0) => this.x0 = x0;
    public override int Tag => 3;
}
public sealed class O4 : Data
{
    public int x0;
    public O4(int x0) => this.x0 = x0;
    public override int Tag => 4;
}
public sealed class OFucked : Data
{
    public int x0;
    public OFucked(int x0) => this.x0 = x0;
    public override int Tag => 5;
}

public static unsafe class Module
{
    public static Thunk fibs = new Updatable(CLR.LoadFunctionPointer(Code.fibs_Entry));
    public static Thunk inf_s3cv = new Updatable(CLR.LoadFunctionPointer(Code.inf_s3cv_Entry));
    public static GHC.Types.IHash inf_s3ct = new GHC.Types.IHash(1);
    public static GHC.Types.Cons inf = new GHC.Types.Cons(inf_s3ct, inf_s3cv);
    public static Data lvl_s4BA = GHC.Integer.Type.smallInteger_Entry(60) as Data;
    public static Data lvl_s4Bz = GHC.Integer.Type.smallInteger_Entry(180) as Data;
    public static Data lvl_s4AW = GHC.Integer.Type.smallInteger_Entry(27) as Data;
    public static Data lvl_s4AV = GHC.Integer.Type.smallInteger_Entry(12) as Data;
    public static Data lvl_s4AU = GHC.Integer.Type.smallInteger_Entry(0) as Data;
    public static Data lvl_s4AT = GHC.Integer.Type.smallInteger_Entry(3) as Data;
    public static Data lvl_s4AS = GHC.Integer.Type.smallInteger_Entry(10) as Data;
    public static Data lvl_s4AR = GHC.Integer.Type.smallInteger_Entry(5) as Data;
    public static Data lvl_s4AQ = GHC.Integer.Type.smallInteger_Entry(2) as Data;
    public static Data lvl_s4AP = GHC.Integer.Type.smallInteger_Entry(1) as Data;
    public static Thunk pi_ = new Updatable(CLR.LoadFunctionPointer(Code.pi__Entry));
    public static Function inc = new Fun(1, CLR.LoadFunctionPointer(Code.inc_Entry));
    public static Function inc_ = new Fun(1, CLR.LoadFunctionPointer(Code.inc__Entry));
    public static Function gcd = new Fun(2, CLR.LoadFunctionPointer(Code.gcd_Entry));
    public static Function fibt = new Fun(1, CLR.LoadFunctionPointer(Code.fibt_Entry));
    public static Function fiba = new Fun(3, CLR.LoadFunctionPointer(Code.fiba_Entry));
    public static Function sum = new Fun(1, CLR.LoadFunctionPointer(Code.sum_Entry));
    public static Function sum2 = new Fun(1, CLR.LoadFunctionPointer(Code.sum2_Entry));
    public static Function suma = new Fun(2, CLR.LoadFunctionPointer(Code.suma_Entry));
    public static Function takeOnStack = new Fun(2, CLR.LoadFunctionPointer(Code.takeOnStack_Entry));
    public static Function take = new Fun(2, CLR.LoadFunctionPointer(Code.take_Entry));
    public static Function facc2 = new Fun(1, CLR.LoadFunctionPointer(Code.facc2_Entry));
    public static Function foldl = new Fun(3, CLR.LoadFunctionPointer(Code.foldl_Entry));
    public static Function map = new Fun(2, CLR.LoadFunctionPointer(Code.map_Entry));
    public static Function sfoldl = new Fun(2, CLR.LoadFunctionPointer(Code.sfoldl_Entry));
    public static Function makeList = new Fun(2, CLR.LoadFunctionPointer(Code.makelist_Entry));
    public static Function sumFromTo = new Fun(2, CLR.LoadFunctionPointer(Code.sumFromTo_Entry));
    public static Function integerToInt = new Fun(1, CLR.LoadFunctionPointer(Code.integerToInt_Entry));
    public static Function extractOtype = new Fun(1, CLR.LoadFunctionPointer(Code.extractOtype_Entry));
    public static Function extractOtag = new Fun(1, CLR.LoadFunctionPointer(Code.extractOtag_Entry));
    public static Function extractOtypeL = new Fun(1, CLR.LoadFunctionPointer(Code.extractOtypeL_Entry));
    public static Function extractOtagL = new Fun(1, CLR.LoadFunctionPointer(Code.extractOtagL_Entry));
}

public static unsafe class Code
{
    private static Data lvls9nE = new GHC.Types.IHash(10);
    private static Data lvls9n8 = new GHC.Integer.Type.SHash(60);
    private static Data lvls9n7 = new GHC.Integer.Type.SHash(180);
    private static Data lvls9mu = new GHC.Integer.Type.SHash(27);
    private static Data lvls9mt = new GHC.Integer.Type.SHash(12);
    private static Data lvls9ms = new GHC.Integer.Type.SHash(3);
    private static Data lvls9mr = new GHC.Integer.Type.SHash(10);
    private static Data lvls9mq = new GHC.Integer.Type.SHash(5);
    private static Data lvls9kw = new GHC.Types.IHash(0);
    private static Data lvls9kt = new GHC.Integer.Type.SHash(9);
    private static Data lvls9iV = new GHC.Integer.Type.SHash(0);
    private static Data lvls9iU = new GHC.Integer.Type.SHash(1);
    private static Data lvls9iT = new GHC.Integer.Type.SHash(2);

    public static Closure makelist_Entry(Closure a, Closure b)
    {
        var from = (a.Eval() as GHC.Types.IHash).x0;
        var to = (b.Eval() as GHC.Types.IHash).x0;
        return makelist_Go(from, to);
    }
    public static Closure makelist_Go(long from, long to)
    {
        if (from <= to)
        {
            var t = new Updatable<long, long>(CLR.LoadFunctionPointer<long, long, Closure>(makelist_Go), from + 1, to);
            return new GHC.Types.Cons(new GHC.Types.IHash(from), t);
        }
        return GHC.Types.nil_DataCon;
    }
    public static Closure sfoldl_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        switch (a)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.IHash a_I:
                {
                    var x = a_I.x0;
                    var r = wfoldl_gos3NN_Entry(x, b);
                    return new GHC.Types.IHash(r);
                }
        }
    }
    public static long wfoldl_gos3NN_Entry(long ww_s3NO, Closure w_s3NP)
    {
        var wild_s3NQ = w_s3NP;
        wild_s3NQ = wild_s3NQ.Eval();
        switch (wild_s3NQ)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_s3NQ_Nil: { return ww_s3NO; }
            case GHC.Types.Cons wild_s3NQ_Cons:
                {
                    var x = wild_s3NQ_Cons.x0;
                    var xs = wild_s3NQ_Cons.x1;
                    var wild1 = x;
                    wild1 = wild1.Eval();
                    switch (wild1)
                    {
                        default: { throw new ImpossibleException(); }
                        case GHC.Types.IHash wild1_I:
                            {
                                var y = wild1_I.x0;
                                var sat_s3NV = ww_s3NO + y;
                                switch (sat_s3NV)
                                {
                                    default: { return wfoldl_gos3NN_Entry(sat_s3NV, xs); }
                                }
                            }
                    }
                }
        }
    }
    public static Closure fibs_Entry()
    {
        return map_Entry(fibt, inf);
    }
    public static Closure inf_s3cv_Entry()
    {
        return map_Entry(inc, inf);
    }
    public static Closure inc__Entry(Closure eta_B1)
    {
        return map_Entry(inc, eta_B1);
    }
    public static Closure inc_Entry(Closure ds1)
    {
        var wild1 = ds1.Eval();
        switch (wild1)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.IHash wild1_I:
                {
                    var y = wild1_I.x0;
                    var sat_s3cr = 1 + y;
                    switch (sat_s3cr)
                    {
                        default:
                            {
                                return new GHC.Types.IHash(sat_s3cr);
                            }
                    }
                }
        }
    }
    public static Closure gcd_Entry(Closure w_s3cg, Closure w_s3ch)
    {
        var ww_s3ci_I = w_s3cg.Eval() as GHC.Types.IHash;
        var ww_s3cj = ww_s3ci_I.x0;
        var ww_s3ck_I = w_s3ch.Eval() as GHC.Types.IHash;
        var ww_s3cl = ww_s3ck_I.x0;
        var ww_s3cm = wgcds3c7_Entry(ww_s3cj, ww_s3cl);
        return new GHC.Types.IHash(ww_s3cm);
    }
    public static long wgcds3c7_Entry(long ww_s3c8, long ww_s3c9)
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
                                                default: { return wgcds3c7_Entry(ds_s3ca, sat_s3cd); }
                                            }
                                        }
                                    case 1:
                                        {
                                            var sat_s3ce = ds_s3ca - ds_s3cb;
                                            switch (sat_s3ce)
                                            {
                                                default: { return wgcds3c7_Entry(sat_s3ce, ds_s3cb); }
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
    public static Closure fibt_Entry(Closure w_s3c3)
    {
        var ww_s3c4_I = w_s3c3.Eval() as GHC.Types.IHash;
        var ww_s3c5 = ww_s3c4_I.x0;
        var ww_s3c6 = wfibas3bK_Entry(0, 1, ww_s3c5);
        return new GHC.Types.IHash(ww_s3c6);
    }
    public static Closure fiba_Entry(Closure w_s3bS, Closure w_s3bT, Closure w_s3bU)
    {
        var ww_s3bV_I = w_s3bS.Eval() as GHC.Types.IHash;
        var ww_s3bW = ww_s3bV_I.x0;
        var ww_s3bX_I = w_s3bT.Eval() as GHC.Types.IHash;
        var ww_s3bY = ww_s3bX_I.x0;
        var ww_s3bZ_I = w_s3bU.Eval() as GHC.Types.IHash;
        var ww_s3c0 = ww_s3bZ_I.x0;
        var ww_s3c1 = wfibas3bK_Entry(ww_s3bW, ww_s3bY, ww_s3c0);
        return new GHC.Types.IHash(ww_s3c1);
    }
    public static long wfibas3bK_Entry(long ww_s3bL, long ww_s3bM, long ww_s3bN)
    {
        var lwild_s3bO = (ww_s3bN <= 0) ? 1 : 0;
        switch (lwild_s3bO)
        {
            default:
                {
                    var sat_s3bQ = ww_s3bN - 1;
                    var sat_s3bP = ww_s3bL + ww_s3bM;
                    return wfibas3bK_Entry(ww_s3bM, sat_s3bP, sat_s3bQ);
                }
            case 1: { return ww_s3bL; }
        }
    }

    public static Closure sum2_Entry(Closure l)
    {
        l = l.Eval();
        switch (l)
        {
            default:
                {
                    throw new ImpossibleException();
                }
            case GHC.Types.Nil wild_s3bB_Nil:
                {
                    return new GHC.Types.IHash(0);
                }
            case GHC.Types.Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    var wild_I = x.Eval() as GHC.Types.IHash;
                    var x2 = wild_I.x0;
                    var ww_s3bG = sum2_Entry(xs);  // puts int in GHC.Types.IHash | => a lot of GC
                    var ww_s3bG_I = ww_s3bG.Eval() as GHC.Types.IHash; // unpacks   |
                    var x1 = ww_s3bG_I.x0;
                    return new GHC.Types.IHash(x1 + x2);
                }
        }
    }

    public static Closure sum_Entry(Closure w_s3bI)
    {
        var ww_s3bJ = wsums3bz_Entry(w_s3bI);
        switch (ww_s3bJ) { default: { return new GHC.Types.IHash(ww_s3bJ); } }
    }
    public static long wsums3bz_Entry(Closure w_s3bA)
    {
        var wild_s3bB = w_s3bA;
        wild_s3bB = wild_s3bB.Eval();
        switch (wild_s3bB)
        {
            default:
                {
                    throw new ImpossibleException();
                }
            case GHC.Types.Nil wild_s3bB_Nil:
                {
                    return 0;
                }
            case GHC.Types.Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    x = x.Eval();
                    var x2 = (x as GHC.Types.IHash).x0;
                    var ww_s3bG = wsums3bz_Entry(xs);
                    return x2 + ww_s3bG;
                }
        }
    }
    public static Closure suma_Entry(Closure w_s3bu, Closure w_s3bv)
    {
        var ww_s3bw_I = w_s3bv.Eval() as GHC.Types.IHash;
        var ww_s3bx = ww_s3bw_I.x0;
        var ww_s3by = wsumas3bk_Entry(w_s3bu, ww_s3bx);
        return new GHC.Types.IHash(ww_s3by);
    }
    public static long wsumas3bk_Entry(Closure w_s3bl, long ww_s3bm)
    {
        var wild_s3bn = w_s3bl;
        wild_s3bn = wild_s3bn.Eval();
        switch (wild_s3bn)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Cons
                wild_s3bn_Cons:
                {
                    var x = wild_s3bn_Cons.x0;
                    var xs = wild_s3bn_Cons.x1;
                    var wild = x;
                    wild = wild.Eval();
                    switch (wild)
                    {
                        default: { throw new ImpossibleException(); }
                        case GHC.Types.IHash wild_I:
                            {
                                var x2 = wild_I.x0;
                                var sat_s3bs = x2 + ww_s3bm;
                                switch (sat_s3bs)
                                {
                                    default: { return wsumas3bk_Entry(xs, sat_s3bs); }
                                }
                            }
                    }
                }
            case GHC.Types.Nil wild_s3bn_Nil: { return ww_s3bm; }
        }
    }
    public static Closure takeOnStack_Entry(Closure n, Closure l)
    {
        n = n.Eval();
        var nn = (n as GHC.Types.IHash).x0;
        return takeOnStack_Entry2(nn, l);
    }

    public static Closure takeOnStack_Entry2(long nn, Closure l)
    {
        if (nn == 0)
            return GHC.Types.nil_DataCon;
        l = l.Eval();
        switch (l)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Cons wild_s3MH_Cons:
                {
                    var h = wild_s3MH_Cons.x0;
                    var t = wild_s3MH_Cons.x1;
                    var takeOnStack = new Updatable<long, Closure>(CLR.LoadFunctionPointer<long, Closure, Closure>(takeOnStack_Thunk), nn, t);
                    return new GHC.Types.Cons(h, takeOnStack);
                }
            case GHC.Types.Nil wild_s3MH_Nil: { return GHC.Types.nil_DataCon; }
        }
    }
    public static Closure takeOnStack_Thunk(long nn, Closure t)
    {
        return takeOnStack_Entry2(nn - 1, t);
    }

    public static Closure take_Entry(Closure w_s3MN, Closure w_s3MO)
    {
        var ww_s3MP_I = w_s3MN.Eval() as GHC.Types.IHash;
        var ww_s3MQ = ww_s3MP_I.x0;
        return wtakes3MD_Entry(ww_s3MQ, w_s3MO);
    }
    public static Closure wtakes3MD_Entry(long ww_s3ME, Closure w_s3MF)
    {
        var ds_s3MG = ww_s3ME;
        switch (ds_s3MG)
        {
            default:
                {
                    var wild_s3MH = w_s3MF.Eval();
                    switch (wild_s3MH)
                    {
                        default: { throw new ImpossibleException(); }
                        case GHC.Types.Cons wild_s3MH_Cons:
                            {
                                var h = wild_s3MH_Cons.x0;
                                var t = wild_s3MH_Cons.x1;
                                var sat_s3ML = new Updatable<long, Closure>(CLR.LoadFunctionPointer<long, Closure, Closure>(sat_s3ML_Entry), ds_s3MG, t);
                                return new GHC.Types.Cons(h, sat_s3ML);
                            }
                        case GHC.Types.Nil wild_s3MH_Nil: { return GHC.Types.nil_DataCon; }
                    }
                }
            case 0: { return GHC.Types.nil_DataCon; }
        }
    }
    public static Closure sat_s3ML_Entry(long ds_s3MG, Closure t)
    {
        var sat_s3MK = ds_s3MG - 1;
        switch (sat_s3MK)
        {
            default: { return wtakes3MD_Entry(sat_s3MK, t); }
        }
    }
    public static Closure facc2_Entry(Closure w_s3b4)
    {
        var ww_s3b5_I = w_s3b4.Eval() as GHC.Types.IHash;
        var ww_s3b6 = ww_s3b5_I.x0;
        var ww_s3b7 = wfacc2s3aX_Entry(ww_s3b6);
        return new GHC.Types.IHash(ww_s3b7);
    }
    public static long wfacc2s3aX_Entry(long ww_s3aY)
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
                                var ww_s3b1 = wfacc2s3aX_Entry(sat_s3b0);
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
    public static Closure foldl_Entry(Closure f, Closure x0, Closure xs)
    {
        var foldl_go = new Fun<Closure, Closure>(2, CLR.LoadFunctionPointer(foldl_go_Entry), f, null);
        foldl_go.x1 = foldl_go;
        return foldl_go.Apply<Closure, Closure, Closure>(x0, xs);
    }
    public static Closure foldl_go_Entry(Closure f, Closure foldl_go, Closure x0, Closure ds_s3aN)
    {
        var wild_s3aO = ds_s3aN.Eval();
        switch (wild_s3aO)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_s3aO_Nil: { return x0; }
            case GHC.Types.Cons
                wild_s3aO_Cons:
                {
                    var x = wild_s3aO_Cons.x0;
                    var xs = wild_s3aO_Cons.x1;
                    var sat_s3aR = new Updatable<Closure, Closure, Closure>(CLR.LoadFunctionPointer(sat_s3aR_Entry), f, x0, x);
                    return foldl_go.Apply<Closure, Closure, Closure>(sat_s3aR, xs);
                }
        }
    }
    public static Closure sat_s3aR_Entry(Closure f, Closure x0, Closure x)
    {
        return f.Apply<Closure, Closure, Closure>(x0, x);
    }
    public static Closure map_Entry(Closure f, Closure ds_s3aB)
    {
        var wild_s3aC = ds_s3aB.Eval();
        switch (wild_s3aC)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_s3aC_Nil: { return GHC.Types.nil_DataCon; }
            case GHC.Types.Cons
                wild_s3aC_Cons:
                {
                    var h = wild_s3aC_Cons.x0;
                    var t = wild_s3aC_Cons.x1;
                    var sat_s3aG = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer(map_Entry), f, t);
                    var sat_s3aF = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer(sat_s3aF_Entry), f, h);
                    return new GHC.Types.Cons(sat_s3aF, sat_s3aG);
                }
        }
    }
    public static Closure sat_s3aF_Entry(Closure f, Closure h)
    {
        return f.Apply<Closure, Closure>(h);
    }

    public static Closure sumFromTo_Entry(Closure from, Closure to)
    {
        var vc_ = from.Eval();
        var vc__I = vc_ as GHC.Types.IHash;
        var wc_ = vc__I.x0;
        var xc_ = to.Eval();
        var xc__I = xc_ as GHC.Types.IHash;
        var yc_ = xc__I.x0;
        var wgo = new Fun(3, CLR.LoadFunctionPointer<long, long, long, long>(wgos49U_Entry));
        var part1 = wgo.Apply<long, Closure>(wc_);
        var part2 = part1.Apply<long, Closure>(yc_);
        var ad_ = part2.Apply<long, long>(0);
        return new GHC.Types.IHash(ad_);
    }
    public static long wgos49U_Entry(long ww_s49V, long ww_s49W, long ww_s49X)
    {
        var lc_ = (ww_s49V > ww_s49W) ? 1 : 0;
        switch (lc_)
        {
            default:
                {
                    var mc_ = ww_s49X + ww_s49V;
                    var nc_ = ww_s49V + 1;
                    return wgos49U_Entry(nc_, ww_s49W, mc_);
                }
            case 1: { return ww_s49X; }
        }
    }

    public static Closure pi__Entry()
    {
        var wws9na = wgs9mv_Entry(lvls9iU, lvls9n7, lvls9n8, lvls9iT);
        var wws9na_RawTuple = wws9na;
        var wws9nb = wws9na_RawTuple.x0;
        var wws9nc = wws9na_RawTuple.x1;
        return new GHC.Types.Cons(wws9nb, wws9nc);
    }
    public static (Closure x0, Closure x1) wgs9mv_Entry(Closure ws9mw, Closure ws9mx, Closure ws9my, Closure ws9mz)
    {
        var ys9mA = new Updatable<Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure>(ys9mA_Entry), ws9mw, ws9mx, ws9my, ws9mz);
        var sats9n6 = new Updatable<Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure>(sats9n6_Entry), ws9mw, ws9mx, ws9my, ws9mz, ys9mA);
        return (ys9mA, sats9n6);
    }
    public static Closure sats9n6_Entry(Closure ws9mw, Closure ws9mx, Closure ws9my, Closure ws9mz, Closure ys9mA)
    {
        var us9mI = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(us9mI_Entry), ws9mz);
        var sats9n2 = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats9n2_Entry), ws9mz);
        var sats9n1 = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(sats9n1_Entry), ws9my, us9mI);
        var sats9n0 = new Updatable<Closure, Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure, Closure>(sats9n0_Entry), ws9mw, ws9mx, ws9my, ws9mz, ys9mA, us9mI);
        var sats9mS = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(sats9mS_Entry), ws9mw, ws9mz);
        var wws9n3 = wgs9mv_Entry(sats9mS, sats9n0, sats9n1, sats9n2);
        var wws9n3_RawTuple = wws9n3;
        var wws9n4 = wws9n3_RawTuple.x0;
        var wws9n5 = wws9n3_RawTuple.x1;
        return new GHC.Types.Cons(wws9n4, wws9n5);
    }
    public static Closure sats9mS_Entry(Closure ws9mw, Closure ws9mz)
    {
        var sats9mQ = GHC.Integer.Type.timesInteger_Entry(lvls9iT, ws9mz).Eval();
        var sats9mR = GHC.Integer.Type.minusInteger_Entry(sats9mQ, lvls9iU).Eval();
        var sats9mO = GHC.Integer.Type.timesInteger_Entry(lvls9mr, ws9mw).Eval();
        var sats9mP = GHC.Integer.Type.timesInteger_Entry(sats9mO, ws9mz).Eval();
        return GHC.Integer.Type.timesInteger_Entry(sats9mP, sats9mR);
    }
    public static Closure sats9n0_Entry(Closure ws9mw, Closure ws9mx, Closure ws9my, Closure ws9mz, Closure ys9mA, Closure us9mI)
    {
        var sats9mY = GHC.Integer.Type.timesInteger_Entry(ys9mA, ws9my).Eval();
        var sats9mU = GHC.Integer.Type.timesInteger_Entry(lvls9mq, ws9mz).Eval();
        var sats9mV = GHC.Integer.Type.minusInteger_Entry(sats9mU, lvls9iT).Eval();
        var sats9mW = GHC.Integer.Type.timesInteger_Entry(ws9mw, sats9mV).Eval();
        var sats9mX = GHC.Integer.Type.plusInteger_Entry(sats9mW, ws9mx).Eval();
        var sats9mZ = GHC.Integer.Type.minusInteger_Entry(sats9mX, sats9mY).Eval();
        var sats9mT = GHC.Integer.Type.timesInteger_Entry(lvls9mr, us9mI).Eval();
        return GHC.Integer.Type.timesInteger_Entry(sats9mT, sats9mZ);
    }
    public static Closure sats9n1_Entry(Closure ws9my, Closure us9mI)
    {
        return GHC.Integer.Type.timesInteger_Entry(ws9my, us9mI);
    }
    public static Closure sats9n2_Entry(Closure ws9mz)
    {
        return GHC.Integer.Type.plusInteger_Entry(ws9mz, lvls9iU);
    }
    public static Closure us9mI_Entry(Closure ws9mz)
    {
        var sats9mM = GHC.Integer.Type.timesInteger_Entry(lvls9ms, ws9mz).Eval();
        var sats9mN = GHC.Integer.Type.plusInteger_Entry(sats9mM, lvls9iT).Eval();
        var sats9mJ = GHC.Integer.Type.timesInteger_Entry(lvls9ms, ws9mz).Eval();
        var sats9mK = GHC.Integer.Type.plusInteger_Entry(sats9mJ, lvls9iU).Eval();
        var sats9mL = GHC.Integer.Type.timesInteger_Entry(lvls9ms, sats9mK).Eval();
        return GHC.Integer.Type.timesInteger_Entry(sats9mL, sats9mN);
    }
    public static Closure ys9mA_Entry(Closure ws9mw, Closure ws9mx, Closure ws9my, Closure ws9mz)
    {
        var ds1s9mB = GHC.Integer.Type.timesInteger_Entry(lvls9mq, ws9my).Eval();
        var wilds9mC = GHC.Integer.Type.eqIntegerHash_Entry(ds1s9mB, lvls9iV);
        switch (wilds9mC)
        {
            default:
                {
                    var sats9mG = GHC.Integer.Type.timesInteger_Entry(lvls9mq, ws9mx).Eval();
                    var sats9mD = GHC.Integer.Type.timesInteger_Entry(lvls9mu, ws9mz).Eval();
                    var sats9mE = GHC.Integer.Type.minusInteger_Entry(sats9mD, lvls9mt).Eval();
                    var sats9mF = GHC.Integer.Type.timesInteger_Entry(ws9mw, sats9mE).Eval();
                    var sats9mH = GHC.Integer.Type.plusInteger_Entry(sats9mF, sats9mG).Eval();
                    return GHC.Integer.Type.divInteger_Entry(sats9mH, ds1s9mB);
                }
            case 1: { throw new System.Exception("Division by zero"); }
        }
    }
    public static Closure repeat_Entry(Closure x)
    {
        var c = new GHC.Types.Cons(x, null);
        c.x1 = c;
        return c;
    }

    public static long wloopApps9Jb_Entry(Closure ws9Jc, long wws9Jd, long wws9Je)
    {
        var dss9Jf = wws9Je;
        switch (dss9Jf)
        {
            default:
                {
                    // var sats9Jg = new GHC.Types.IHash(dss9Jf);
                    // var wilds9Jh = ws9Jc.Apply<Closure, Closure>(sats9Jg).Eval();
                    // var wilds9Jh = appTestFC(sats9Jg).Eval();
                    // var wilds9Jh_IHash = wilds9Jh as GHC.Types.IHash;
                    // var xs9Ji = wilds9Jh_IHash.x0;
                    var xs9Ji = ws9Jc.Apply<long, long>(dss9Jf);
                    var sats9Jk = dss9Jf - 1;
                    var sats9Jj = xs9Ji + wws9Jd;
                    return wloopApps9Jb_Entry(ws9Jc, sats9Jj, sats9Jk);
                }
            case 0:
                {
                    // var wilds9Jl = ws9Jc.Apply<Closure, Closure>(lvls9kw).Eval();
                    var xs9Jm = ws9Jc.Apply<long, long>(0);
                    // var wilds9Jl_IHash = wilds9Jl as GHC.Types.IHash;
                    // var xs9Jm = wilds9Jl_IHash.x0; 
                    return xs9Jm + wws9Jd;
                }
        }
    }

    public static long wloopCalls9VJ_Entry(long wws9VK, long wws9VL)
    {
        var dss9VM = wws9VL;
        switch (dss9VM)
        {
            default:
                {
                    var wws9VN = appTestF(dss9VM);
                    var sats9VP = dss9VM - 1;
                    var sats9VO = wws9VK + wws9VN;
                    return wloopCalls9VJ_Entry(sats9VO, sats9VP);
                }
            case 0:
                {
                    var wilds9VQ = lvls9kw.Eval();
                    var wilds9VQ_IHash = wilds9VQ as GHC.Types.IHash;
                    var xs9VR = wilds9VQ_IHash.x0; return xs9VR + wws9VK;
                }
        }
    }

    private static Closure appf = new Fun(1, CLR.LoadFunctionPointer<long, long>(appTestF));
    private static Closure appfc = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(appTestFC));
    public static Closure appAppTest()
    {
        for (int i = 0; i < 100000; i++)
            appf.Apply<long, long>(i);
        return GHC.Tuple.unit_DataCon;
    }
    public static Closure loopAppTest()
    {
        return new GHC.Types.IHash(wloopApps9Jb_Entry(appf, 0, 100_000));
    }
    public static Closure loopCallTest()
    {
        return new GHC.Types.IHash(wloopCalls9VJ_Entry(0, 100_000));
    }
    public static Closure appCallTest()
    {
        for (int i = 0; i < 100000; i++)
            appTestF(i);
        return GHC.Tuple.unit_DataCon;
    }

    [MethodImpl(MethodImplOptions.NoInlining)]
    public static long appTestF(long x) => 1 + x;
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static Closure appTestFC(Closure x) => new GHC.Types.IHash(1 + (x as GHC.Types.IHash).x0);

    public static Closure appProcessTestI()
    {
        var sats9oV = 100000;
        var sats9oW = new GHC.Types.IHash(sats9oV);
        var sats9oX = take_Entry(sats9oW, repeat_Entry(inf_s3ct));
        var wws9oY = wappProcessIs9yg_Entry(sats9oX, 0);
        var sats9oZ = new GHC.Types.IHash(wws9oY); return sats9oZ;
    }
    public static Closure appProcessTest()
    {
        var sats9oV = 100000;
        var sats9oW = new GHC.Types.IHash(sats9oV);
        var sats9oX = take_Entry(sats9oW, repeat_Entry(inf_s3ct));
        var wws9oY = wappProcesss9nF_Entry(appChoose, sats9oX, 0);
        var sats9oZ = new GHC.Types.IHash(wws9oY); return sats9oZ;
    }
    private static Closure appChoose = new Fun(2, CLR.LoadFunctionPointer(appChoose_Entry));

    public static long wappProcesss9nF_Entry(Closure ws9nG, Closure ws9nH, long wws9nI)
    {
        var wilds9nJ = ws9nH.Eval();
        switch (wilds9nJ)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds9nJ_Nil: { return wws9nI; }
            case GHC.Types.Cons wilds9nJ_Cons:
                {
                    var xs9nK = wilds9nJ_Cons.x0;
                    var xss9nL = wilds9nJ_Cons.x1;
                    var wilds9nM = ws9nG.Apply<Closure, Closure, Closure>(xs9nK, lvls9nE).Eval();
                    var wilds9nM_IHash = wilds9nM as GHC.Types.IHash;
                    var xs9nN = wilds9nM_IHash.x0;
                    var sats9nO = xs9nN + wws9nI;
                    return wappProcesss9nF_Entry(ws9nG, xss9nL, sats9nO);
                }
        }
    }
    public static long wappProcessIs9yg_Entry(Closure ws9yh, long wws9yi)
    {
        var wilds9yj = ws9yh.Eval();
        switch (wilds9yj)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds9yj_Nil: { return wws9yi; }
            case GHC.Types.Cons wilds9yj_Cons:
                {
                    var xs9yk = wilds9yj_Cons.x0;
                    var xss9yl = wilds9yj_Cons.x1;
                    var wws9ym = xs9yk.Eval();
                    var wws9ym_IHash = wws9ym as GHC.Types.IHash;
                    var wws9yn = wws9ym_IHash.x0;
                    var wws9yo = wappChooses9nr_Entry(wws9yn, 10);
                    var sats9yp = wws9yo + wws9yi;
                    return wappProcessIs9yg_Entry(xss9yl, sats9yp);
                }
        }
    }
    public static Closure appChoose_Entry(Closure ws9nx, Closure ws9ny)
    {
        var wws9nz = ws9nx.Eval();
        var wws9nz_IHash = wws9nz as GHC.Types.IHash;
        var wws9nA = wws9nz_IHash.x0;
        var wws9nB = ws9ny.Eval();
        var wws9nB_IHash = wws9nB as GHC.Types.IHash;
        var wws9nC = wws9nB_IHash.x0;
        var wws9nD = wappChooses9nr_Entry(wws9nA, wws9nC);
        return new GHC.Types.IHash(wws9nD);
    }
    public static long wappChooses9nr_Entry(long wws9ns, long wws9nt)
    {
        var dss9nu = wws9ns;
        switch (dss9nu)
        {
            default: { throw new System.Exception("Pattern match failed in appChoose"); }
            case 1: { return wws9nt - 5; }
            case 2: { return wws9nt - 8; }
        }
    }
    public static Closure integerToInt_Entry(Closure i)
    {
        return new GHC.Types.IHash(GHC.Integer.Type.integerToInt_Entry(i));
    }

    public static Closure extractOtype_Entry(Closure o)
    {
        o = o.Eval();
        switch (o)
        {
            default: throw new ImpossibleException();
            case O0 o0:
                var i0 = o0.x0;
                return new GHC.Types.IHash(i0);
            case O1 o1:
                var i1 = o1.x0;
                return new GHC.Types.IHash(i1);
            case O2 o2:
                var i2 = o2.x0;
                return new GHC.Types.IHash(i2);
            case O3 o3:
                var i3 = o3.x0;
                return new GHC.Types.IHash(i3);
            case O4 o4:
                var i4 = o4.x0;
                return new GHC.Types.IHash(i4);
            case GHC.Types.IHash i:
                throw new Exception();
            case GHC.Types.Nil n:
                throw new Exception();
            case GHC.Types.Cons c:
                throw new Exception();
            case OFucked of:
                var @if = of.x0;
                return new GHC.Types.IHash(@if);
        }
    }
    public static Closure extractOtypeL_Entry(Closure o)
    {
        o = o.Eval();
        switch (o)
        {
            default: return new GHC.Types.IHash(0);
            case O0 o0:
                var i0 = o0.x0;
                return new GHC.Types.IHash(i0);
            case O1 o1:
                var i1 = o1.x0;
                return new GHC.Types.IHash(i1);
        }
    }
    public static Closure extractOtag_Entry(Closure o)
    {
        o = o.Eval();
        switch (o.Tag)
        {
            default: throw new ImpossibleException();
            case 0:
                var o0 = o as O0;
                var i0 = o0.x0;
                return new GHC.Types.IHash(i0);
            case 1:
                var o1 = o as O1;
                var i1 = o1.x0;
                return new GHC.Types.IHash(i1);
            case 2:
                var o2 = o as O2;
                var i2 = o2.x0;
                return new GHC.Types.IHash(i2);
            case 3:
                var o3 = o as O3;
                var i3 = o3.x0;
                return new GHC.Types.IHash(i3);
            case 4:
                var o4 = o as O4;
                var i4 = o4.x0;
                return new GHC.Types.IHash(i4);
            case 5:
                var of = o as OFucked;
                var @if = of.x0;
                return new GHC.Types.IHash(@if);
        }
    }
    public static Closure extractOtagL_Entry(Closure o)
    {
        o = o.Eval();
        switch (o.Tag)
        {
            default: return new GHC.Types.IHash(0);
            case 0:
                var o0 = o as O0;
                var i0 = o0.x0;
                return new GHC.Types.IHash(i0);
            case 1:
                var o1 = o as O1;
                var i1 = o1.x0;
                return new GHC.Types.IHash(i1);
        }
    }
    public static Closure loopArray(Closure[] arr, int currentIndex)
    {
        if (currentIndex >= arr.Length)
            currentIndex = 0;
        var head = arr[currentIndex];
        var tail = new SingleEntry<Closure[], int>(CLR.LoadFunctionPointer<Closure[], int, Closure>(loopArray), arr, currentIndex + 1);
        return new GHC.Types.Cons(head, tail);
    }
    private static Random rand = new Random();
    public static Closure RandomO()
    {
        var i = rand.Next(0, 4);
        Closure w = null;
        switch (i)
        {
            case 0: w = new O0(1); break;
            case 1: w = new O1(1); break;
            case 2: w = new O2(1); break;
            case 3: w = new O3(1); break;
            case 4: w = new O4(1); break;
        }
        return new GHC.Types.Cons(w, new SingleEntry(CLR.LoadFunctionPointer(RandomO)));
    }
    public static Closure RandomOL()
    {
        var i = rand.Next(0, 1);
        Closure w = null;
        switch (i)
        {
            case 0: w = new O0(1); break;
            case 1: w = new O1(1); break;
        }
        return new GHC.Types.Cons(w, new SingleEntry(CLR.LoadFunctionPointer(RandomOL)));
    }
}
