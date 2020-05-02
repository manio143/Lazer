using Lazer.Runtime;

public unsafe static class Primes
{
    internal static string lvls5kr = "Main.hs:10:1-40|function the_filter";
    public static Function main;

    internal static Function mains5l7;

    internal static Function ws5kZ;

    internal static Function wws5kP;

    internal static Function wprimes5kK;

    internal static Function go2s5kt;

    internal static Thunk lvls5ks;

    internal static Function smapM_s5kl;

    internal static Function smapM_s5k8;

    static Primes()
    {
        main = new Fun1<GHC.Prim.Void, Closure>(&main_Entry);
        mains5l7 = new Fun1<GHC.Prim.Void, Closure>(&mains5l7_Entry);

        ws5kZ = new Fun3<Closure, Closure, GHC.Prim.Void, Closure>(&ws5kZ_Entry);

        wws5kP = new Fun3<long, long, GHC.Prim.Void, Closure>(&wws5kP_Entry);

        wprimes5kK = new Fun1<long, Closure>(&wprimes5kK_Entry);
        go2s5kt = new Fun1<Closure, Closure>(&go2s5kt_Entry);
        lvls5ks = new Updatable(&lvls5ks_Entry);
        smapM_s5kl = new Fun3<Closure, Closure, GHC.Prim.Void, Closure>(&smapM_s5kl_Entry);

        smapM_s5k8 = new Fun3<Closure, Closure, GHC.Prim.Void, Closure>(&smapM_s5k8_Entry);

    }
    public static Closure TestEntry()
    {
        return main_Entry(GHC.Prim.voidHash);
    }
    public static Closure main_Entry(GHC.Prim.Void void0E)
    {
        return mains5l7_Entry(GHC.Prim.voidHash);
    }
    public static Closure mains5l7_Entry(GHC.Prim.Void void0E)
    {
        var ds1s5l9 = wws5kP_Entry(100, 1500, GHC.Prim.voidHash);
        var ipv1s5lb = ds1s5l9; return GHC.Tuple.unit_DataCon;
    }
    public static Closure ws5kZ_Entry(Closure ws5l0, Closure ws5l1, GHC.Prim.Void void0E)
    {
        var wws5l3 = ws5l0.Eval();
        var wws5l3_IHash = wws5l3 as GHC.Types.IHash;
        var wws5l4 = wws5l3_IHash.x0;
        var wws5l5 = ws5l1.Eval();
        var wws5l5_IHash = wws5l5 as GHC.Types.IHash;
        var wws5l6 = wws5l5_IHash.x0;
        return wws5kP_Entry(wws5l4, wws5l6, GHC.Prim.voidHash);
    }
    public static Closure wws5kP_Entry(long wws5kQ, long wws5kR, GHC.Prim.Void void0E)
    {
        var dss5kT = wws5kQ;
        switch (dss5kT)
        {
            default:
                {
                    var ds1s5kU = wprimes5kK_Entry(wws5kR);
                    var ds1s5kU_IHash = ds1s5kU as GHC.Types.IHash;
                    var ipvs5kV = ds1s5kU_IHash.x0;
                    var sats5kW = dss5kT - 1;
                    return wws5kP_Entry(sats5kW, wws5kR, GHC.Prim.voidHash);
                }
            case 1:
                {
                    var ds1s5kX = wprimes5kK_Entry(wws5kR);
                    var ds1s5kX_IHash = ds1s5kX as GHC.Types.IHash;
                    var ipvs5kY = ds1s5kX_IHash.x0; return GHC.Tuple.unit_DataCon;
                }
        }
    }
    public static Closure wprimes5kK_Entry(long wws5kL)
    {
        var sats5kN = new Updatable<long>(&sats5kN_Entry, wws5kL);
        var sats5kO = go2s5kt_Entry(sats5kN);
        return GHC.List.wBangBang_Entry(sats5kO, wws5kL);
    }
    public static Closure sats5kN_Entry(in long wws5kL)
    {
        var sats5kM = wws5kL * wws5kL;
        return GHC.Enum.eftInt_Entry(2, sats5kM);
    }
    public static Closure go2s5kt_Entry(Closure xs5ku)
    {
        var sats5kJ = new Updatable<Closure>(&sats5kJ_Entry, xs5ku);
        var sats5kv = new Updatable<Closure>(&sats5kv_Entry, xs5ku);
        return new GHC.Types.Cons(sats5kv, sats5kJ);
    }
    public static Closure sats5kv_Entry(in Closure xs5ku)
    {
        return GHC.List.head_Entry(xs5ku);
    }
    public static Closure sats5kJ_Entry(in Closure xs5ku)
    {
        var sats5kI = new Updatable<Closure>(&sats5kI_Entry, xs5ku);
        return go2s5kt_Entry(sats5kI);
    }
    public static Closure sats5kI_Entry(in Closure xs5ku)
    {
        var wilds5kw = xs5ku.Eval();
        switch (wilds5kw)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5kw_Nil: { return lvls5ks.Eval(); }
            case GHC.Types.Cons wilds5kw_Cons:
                {
                    var ns5kx = wilds5kw_Cons.x0;
                    var nss5ky = wilds5kw_Cons.x1;
                    var sats5kH = new Fun1<Closure, Closure, Closure>(&sats5kH_Entry, ns5kx);
                    return GHC.List.filter_Entry(sats5kH, nss5ky);
                }
        }
    }
    public static Closure sats5kH_Entry(in Closure ns5kx, Closure xs5kz)
    {
        var wws5kA = ns5kx.Eval();
        var wws5kA_IHash = wws5kA as GHC.Types.IHash;
        var ww1s5kB = wws5kA_IHash.x0;
        var wilds5kC = ww1s5kB;
        switch (wilds5kC)
        {
            default:
                {
                    var wild1s5kD = xs5kz.Eval();
                    var wild1s5kD_IHash = wild1s5kD as GHC.Types.IHash;
                    var xs5kE = wild1s5kD_IHash.x0;
                    var ww2s5kF = GHC.Classes.modIntHash_Entry(xs5kE, wilds5kC);
                    switch (ww2s5kF)
                    {
                        default: { return GHC.Types.true_DataCon.Eval(); }
                        case 0: { return GHC.Types.false_DataCon.Eval(); }
                    }
                }
            case -1: { return GHC.Types.false_DataCon.Eval(); }
            case 0: { throw new System.Exception("Division by zero"); }
        }
    }
    public static Closure lvls5ks_Entry()
    {
        throw new System.Exception(lvls5kr);
    }
    public static Closure smapM_s5kl_Entry(Closure etaB3, Closure etaB2, GHC.Prim.Void void0E)
    {
        return smapM_s5k8_Entry(etaB3, etaB2, GHC.Prim.voidHash);
    }
    public static Closure smapM_s5k8_Entry(Closure w2s5k9, Closure etas5ka, GHC.Prim.Void void0E)
    {
        var go_Frees5kc = (w2s5k9, (Closure)null);
        var gos5kc = new Fun2<(Closure x0, Closure x1), Closure, GHC.Prim.Void, Closure>(&gos5kc_Entry, go_Frees5kc);
        gos5kc.free.x1 = gos5kc;
        return gos5kc.Apply<Closure, GHC.Prim.Void, Closure>(etas5ka, GHC.Prim.voidHash);
    }
    public static Closure gos5kc_Entry(in (Closure x0, Closure x1) go_Frees5kc, Closure dss5kd, GHC.Prim.Void void0E)
    {
        var w2s5k9 = go_Frees5kc.x0;
        var gos5kc = go_Frees5kc.x1;
        var wilds5kf = dss5kd.Eval();
        switch (wilds5kf)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5kf_Nil:
                {
                    return GHC.Tuple.unit_DataCon;
                }
            case GHC.Types.Cons wilds5kf_Cons:
                {
                    var ys5kg = wilds5kf_Cons.x0;
                    var yss5kh = wilds5kf_Cons.x1;
                    var ds1s5ki = w2s5k9.Apply<Closure, GHC.Prim.Void, Closure>(ys5kg, GHC.Prim.voidHash);
                    var ipv1s5kk = ds1s5ki;
                    return gos5kc.Apply<Closure, GHC.Prim.Void, Closure>(yss5kh, GHC.Prim.voidHash);
                }
        }
    }

}
