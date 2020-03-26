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
        var h = x0.Eval();
        var t = x1.Eval();
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
    public static Function timesInteger = new Fun(2, CLR.LoadFunctionPointer(Code.timesInteger_Entry));
    public static Function plusInteger = new Fun(2, CLR.LoadFunctionPointer(Code.plusInteger_Entry));
    public static Function minusInteger = new Fun(2, CLR.LoadFunctionPointer(Code.minusInteger_Entry));
    public static Function integerToInt = new Fun(1, CLR.LoadFunctionPointer(Code.integerToInt_Entry));
    public static Nil nil = new Nil();
}

public static unsafe class Code
{
    public static Closure makelist_Entry(Closure a, Closure b)
    {
        var from = (a.Eval() as I).x0;
        var to = (b.Eval() as I).x0;
        return makelist_Go(from, to);
    }
    public static Closure makelist_Go(long from, long to)
    {
        if (from <= to)
        {
            var t = Updatable.Make(CLR.LoadFunctionPointer<long, long, Closure>(makelist_Go), from + 1, to);
            return new Cons(new I(from), t);
        }
        return nil;
    }
    public static Closure sfoldl_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        switch (a)
        {
            default: { throw new ImpossibleException(); }
            case I a_I:
                {
                    var x = a_I.x0;
                    var r = wfoldl_gos3NN_Entry(x, b);
                    return new I(r);
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
            case Nil wild_s3NQ_Nil: { return ww_s3NO; }
            case Cons wild_s3NQ_Cons:
                {
                    var x = wild_s3NQ_Cons.x0;
                    var xs = wild_s3NQ_Cons.x1;
                    var wild1 = x;
                    wild1 = wild1.Eval();
                    switch (wild1)
                    {
                        default: { throw new ImpossibleException(); }
                        case I wild1_I:
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
            case I wild1_I:
                {
                    var y = wild1_I.x0;
                    var sat_s3cr = 1 + y;
                    switch (sat_s3cr)
                    {
                        default:
                            {
                                return new I(sat_s3cr);
                            }
                    }
                }
        }
    }
    public static Closure gcd_Entry(Closure w_s3cg, Closure w_s3ch)
    {
        var ww_s3ci_I = w_s3cg.Eval() as I;
        var ww_s3cj = ww_s3ci_I.x0;
        var ww_s3ck_I = w_s3ch.Eval() as I;
        var ww_s3cl = ww_s3ck_I.x0;
        var ww_s3cm = wgcds3c7_Entry(ww_s3cj, ww_s3cl);
        return new I(ww_s3cm);
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
        var ww_s3c4_I = w_s3c3.Eval() as I;
        var ww_s3c5 = ww_s3c4_I.x0;
        var ww_s3c6 = wfibas3bK_Entry(0, 1, ww_s3c5);
        return new I(ww_s3c6);
    }
    public static Closure fiba_Entry(Closure w_s3bS, Closure w_s3bT, Closure w_s3bU)
    {
        var ww_s3bV_I = w_s3bS.Eval() as I;
        var ww_s3bW = ww_s3bV_I.x0;
        var ww_s3bX_I = w_s3bT.Eval() as I;
        var ww_s3bY = ww_s3bX_I.x0;
        var ww_s3bZ_I = w_s3bU.Eval() as I;
        var ww_s3c0 = ww_s3bZ_I.x0;
        var ww_s3c1 = wfibas3bK_Entry(ww_s3bW, ww_s3bY, ww_s3c0);
        return new I(ww_s3c1);
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
            case Nil wild_s3bB_Nil:
                {
                    return new I(0);
                }
            case Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    var wild_I = x.Eval() as I;
                    var x2 = wild_I.x0;
                    var ww_s3bG = sum2_Entry(xs);  // puts int in I | => a lot of GC
                    var ww_s3bG_I = ww_s3bG.Eval() as I; // unpacks   |
                    var x1 = ww_s3bG_I.x0;
                    return new I(x1 + x2);
                }
        }
    }

    public static Closure sum_Entry(Closure w_s3bI)
    {
        var ww_s3bJ = wsums3bz_Entry(w_s3bI);
        switch (ww_s3bJ) { default: { return new I(ww_s3bJ); } }
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
            case Nil wild_s3bB_Nil:
                {
                    return 0;
                }
            case Cons
                wild_s3bB_Cons:
                {
                    var x = wild_s3bB_Cons.x0;
                    var xs = wild_s3bB_Cons.x1;
                    x = x.Eval();
                    var x2 = (x as I).x0;
                    var ww_s3bG = wsums3bz_Entry(xs);
                    return x2 + ww_s3bG;
                }
        }
    }
    public static Closure suma_Entry(Closure w_s3bu, Closure w_s3bv)
    {
        var ww_s3bw_I = w_s3bv.Eval() as I;
        var ww_s3bx = ww_s3bw_I.x0;
        var ww_s3by = wsumas3bk_Entry(w_s3bu, ww_s3bx);
        return new I(ww_s3by);
    }
    public static long wsumas3bk_Entry(Closure w_s3bl, long ww_s3bm)
    {
        var wild_s3bn = w_s3bl;
        wild_s3bn = wild_s3bn.Eval();
        switch (wild_s3bn)
        {
            default: { throw new ImpossibleException(); }
            case Cons
                wild_s3bn_Cons:
                {
                    var x = wild_s3bn_Cons.x0;
                    var xs = wild_s3bn_Cons.x1;
                    var wild = x;
                    wild = wild.Eval();
                    switch (wild)
                    {
                        default: { throw new ImpossibleException(); }
                        case I wild_I:
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
            case Nil wild_s3bn_Nil: { return ww_s3bm; }
        }
    }
    public static Closure takeOnStack_Entry(Closure n, Closure l)
    {
        n = n.Eval();
        var nn = (n as I).x0;
        return takeOnStack_Entry2(nn, l);
    }

    public static Closure takeOnStack_Entry2(long nn, Closure l)
    {
        if (nn == 0)
            return nil;
        l = l.Eval();
        switch (l)
        {
            default: { throw new ImpossibleException(); }
            case Cons wild_s3MH_Cons:
                {
                    var h = wild_s3MH_Cons.x0;
                    var t = wild_s3MH_Cons.x1;
                    var takeOnStack = Updatable.Make(CLR.LoadFunctionPointer<long, Closure,Closure>(takeOnStack_Thunk), nn, t);
                    return new Cons(h, takeOnStack);
                }
            case Nil wild_s3MH_Nil: { return nil; }
        }
    }
    public static Closure takeOnStack_Thunk(long nn, Closure t)
    {
        return takeOnStack_Entry2(nn - 1, t);
    }

    public static Closure take_Entry(Closure w_s3MN, Closure w_s3MO)
    {
        var ww_s3MP_I = w_s3MN.Eval() as I;
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
                        case Cons wild_s3MH_Cons:
                            {
                                var h = wild_s3MH_Cons.x0;
                                var t = wild_s3MH_Cons.x1;
                                var sat_s3ML = Updatable.Make(CLR.LoadFunctionPointer<long, Closure,Closure>(sat_s3ML_Entry), ds_s3MG, t);
                                return new Cons(h, sat_s3ML);
                            }
                        case Nil wild_s3MH_Nil: { return nil; }
                    }
                }
            case 0: { return nil; }
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
        var ww_s3b5_I = w_s3b4.Eval() as I;
        var ww_s3b6 = ww_s3b5_I.x0;
        var ww_s3b7 = wfacc2s3aX_Entry(ww_s3b6);
        return new I(ww_s3b7);
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
        var foldl_go = new Fun<Closure,Closure>(2, CLR.LoadFunctionPointer(foldl_go_Entry), f, null);
        foldl_go.x1 = foldl_go;
        return StgApply.Apply<Closure,Closure,Closure>(foldl_go, x0, xs);
    }
    public static Closure foldl_go_Entry(Closure f, Closure foldl_go, Closure x0, Closure ds_s3aN)
    {
        var wild_s3aO = ds_s3aN.Eval();
        switch (wild_s3aO)
        {
            default: { throw new ImpossibleException(); }
            case Nil wild_s3aO_Nil: { return x0; }
            case Cons
                wild_s3aO_Cons:
                {
                    var x = wild_s3aO_Cons.x0;
                    var xs = wild_s3aO_Cons.x1;
                    var sat_s3aR = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aR_Entry), f, x0, x);
                    return StgApply.Apply<Closure,Closure,Closure>(foldl_go, sat_s3aR, xs);
                }
        }
    }
    public static Closure sat_s3aR_Entry(Closure f, Closure x0, Closure x)
    {
        return StgApply.Apply<Closure,Closure,Closure>(f, x0, x);
    }
    public static Closure map_Entry(Closure f, Closure ds_s3aB)
    {
        var wild_s3aC = ds_s3aB.Eval();
        switch (wild_s3aC)
        {
            default: { throw new ImpossibleException(); }
            case Nil wild_s3aC_Nil: { return nil; }
            case Cons
                wild_s3aC_Cons:
                {
                    var h = wild_s3aC_Cons.x0;
                    var t = wild_s3aC_Cons.x1;
                    var sat_s3aG = Updatable.Make(CLR.LoadFunctionPointer(map_Entry), f, t);
                    var sat_s3aF = Updatable.Make(CLR.LoadFunctionPointer(sat_s3aF_Entry), f, h);
                    return new Cons(sat_s3aF, sat_s3aG);
                }
        }
    }
    public static Closure sat_s3aF_Entry(Closure f, Closure h)
    {
        return StgApply.Apply<Closure,Closure>(f, h);
    }

    public static Closure sumFromTo_Entry(Closure from, Closure to)
    {
        var vc_ = from.Eval();
        var vc__I = vc_ as I;
        var wc_ = vc__I.x0;
        var xc_ = to.Eval();
        var xc__I = xc_ as I;
        var yc_ = xc__I.x0;
        var wgo = new Fun(3, CLR.LoadFunctionPointer<long,long,long,long>(wgos49U_Entry));
        var part1 = StgApply.Apply<long,Closure>(wgo, wc_);
        var part2 = StgApply.Apply<long,Closure>(part1, yc_);
        var ad_ = StgApply.Apply<long,long>(part2, 0);
        return new I(ad_);
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
        var hf_ = wgs4AX_Entry(lvl_s4AP, lvl_s4Bz, lvl_s4BA, lvl_s4AQ);
        return new Cons(hf_.Item1, hf_.Item2);
    }
    public static (Closure, Closure) wgs4AX_Entry(Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1)
    {
        var yd_ = Updatable.Make(CLR.LoadFunctionPointer(yd__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1);
        var he_ = Updatable.Make(CLR.LoadFunctionPointer(he__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1, yd_);
        return (yd_, he_);
    }
    public static Closure yd__Entry(Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1)
    {
        var ae_ = timesInteger_Entry(lvl_s4AR, w_s4B0);
        var be_ = (ae_ as S).x0 == lvl_s4AU.x0 ? 1 : 0;
        switch (be_)
        {
            default:
                {
                    var ce_ = timesInteger_Entry(lvl_s4AR, w_s4AZ);
                    var de_ = timesInteger_Entry(lvl_s4AW, w_s4B1);
                    var ee_ = minusInteger_Entry(de_, lvl_s4AV);
                    var fe_ = timesInteger_Entry(w_s4AY, ee_);
                    var ge_ = plusInteger_Entry(fe_, ce_);
                    return divInteger_Entry(ge_, ae_);
                }
            case 1: { throw new Exception("Division by 0"); }
        }
    }
    public static Closure he__Entry(Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1, Closure yd_)
    {
        var ie_ = Updatable.Make(CLR.LoadFunctionPointer(ie__Entry), w_s4B1);
        var oe_ = Updatable.Make(CLR.LoadFunctionPointer(oe__Entry), w_s4B1);
        var pe_ = Updatable.Make(CLR.LoadFunctionPointer(pe__Entry), w_s4B0, ie_);
        var qe_ = Updatable.Make(CLR.LoadFunctionPointer(qe__Entry), w_s4AY, w_s4AZ, w_s4B0, w_s4B1, yd_, ie_);
        var ye_ = Updatable.Make(CLR.LoadFunctionPointer(ye__Entry), w_s4AY, w_s4B1);
        var ef_ = wgs4AX_Entry(ye_, qe_, pe_, oe_);
        return new Cons(ef_.Item1, ef_.Item2);
    }
    public static Closure ie__Entry(Closure w_s4B1)
    {
        var je_ = timesInteger_Entry(lvl_s4AT, w_s4B1);
        var ke_ = plusInteger_Entry(je_, lvl_s4AQ);
        var le_ = timesInteger_Entry(lvl_s4AT, w_s4B1);
        var me_ = plusInteger_Entry(le_, lvl_s4AP);
        var ne_ = timesInteger_Entry(lvl_s4AT, me_);
        return timesInteger_Entry(ne_, ke_);
    }
    public static Closure oe__Entry(Closure w_s4B1)
    {
        return plusInteger_Entry(w_s4B1, lvl_s4AP);
    }
    public static Closure pe__Entry(Closure w_s4B0, Closure ie_)
    {
        return timesInteger_Entry(w_s4B0, ie_);
    }
    public static Closure qe__Entry(Closure w_s4AY, Closure w_s4AZ, Closure w_s4B0, Closure w_s4B1, Closure yd_, Closure ie_)
    {
        var re_ = timesInteger_Entry(yd_, w_s4B0);
        var se_ = timesInteger_Entry(lvl_s4AR, w_s4B1);
        var te_ = minusInteger_Entry(se_, lvl_s4AQ);
        var ue_ = timesInteger_Entry(w_s4AY, te_);
        var ve_ = plusInteger_Entry(ue_, w_s4AZ);
        var we_ = minusInteger_Entry(ve_, re_);
        var xe_ = timesInteger_Entry(lvl_s4AS, ie_);
        return timesInteger_Entry(xe_, we_);
    }
    public static Closure ye__Entry(Closure w_s4AY, Closure w_s4B1)
    {
        var af_ = timesInteger_Entry(lvl_s4AQ, w_s4B1);
        var bf_ = minusInteger_Entry(af_, lvl_s4AP);
        var cf_ = timesInteger_Entry(lvl_s4AS, w_s4AY);
        var df_ = timesInteger_Entry(cf_, w_s4B1);
        return timesInteger_Entry(df_, bf_);
    }

    public static Closure timesInteger_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        b = b.Eval();
        return new S((a as S).x0 * (b as S).x0);
    }
    public static Closure plusInteger_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        b = b.Eval();
        return new S((a as S).x0 + (b as S).x0);
    }
    public static Closure minusInteger_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        b = b.Eval();
        return new S((a as S).x0 - (b as S).x0);
    }
    public static Closure divInteger_Entry(Closure a, Closure b)
    {
        a = a.Eval();
        b = b.Eval();
        return new S((a as S).x0 / (b as S).x0);
    }
    public static Closure integerToInt_Entry(Closure i)
    {
        i = i.Eval();
        return new I((long)(i as S).x0);
    }
}
