using Lazer.Runtime;

public unsafe static class DigitsE1
{
    internal static string lvls5xX = "Main.lhs:(40,3)-(41,67)|function takeDigits";
    internal static string lvls5x5 = "Main.lhs:(30,3)-(35,59)|function ratTrans";
    public static Function main;

    internal static Function mains5yo;

    internal static Function gos5yi;

    public static Function e;

    public static Function takeDigits;

    internal static Function wtakeDigitss5xZ;

    internal static Thunk lvls5xY;

    public static Function ratTrans;

    internal static Function wratTranss5x8;

    internal static Thunk lvls5x6;

    internal static Thunk eContFracs5x0;

    internal static Function wauxs5wR;

    internal static GHC.Integer.Type.SHash eContFracs5wP;
    internal static GHC.Integer.Type.SHash lvls5wQ;
    public static GHC.Types.Cons eContFrac;
    internal static GHC.Integer.Type.SHash lvls5x7;
    internal static GHC.Integer.Type.SHash lvls5xW;

    static DigitsE1()
    {
        main = new Fun1<GHC.Prim.Void, Closure>(&main_Entry);
        mains5yo = new Fun1<GHC.Prim.Void, Closure>(&mains5yo_Entry);

        gos5yi = new Fun1<Closure, Closure>(&gos5yi_Entry);
        e = new Fun1<Closure, Closure>(&e_Entry);
        takeDigits = new Fun2<Closure, Closure, Closure>(&takeDigits_Entry);

        wtakeDigitss5xZ = new Fun2<long, Closure, Closure>(&wtakeDigitss5xZ_Entry);

        lvls5xY = new Updatable(&lvls5xY_Entry);
        ratTrans = new Fun2<Closure, Closure, Closure>(&ratTrans_Entry);

        wratTranss5x8 = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&wratTranss5x8_Entry);

        lvls5x6 = new Updatable(&lvls5x6_Entry);
        eContFracs5x0 = new Updatable(&eContFracs5x0_Entry);
        wauxs5wR = new Fun1<Closure, (Closure x0, Closure x1)>(&wauxs5wR_Entry);

        lvls5xW = new GHC.Integer.Type.SHash(10);
        lvls5x7 = new GHC.Integer.Type.SHash(0);
        eContFrac = new GHC.Types.Cons((Closure)null, eContFracs5x0);
        lvls5wQ = new GHC.Integer.Type.SHash(1);
        eContFracs5wP = new GHC.Integer.Type.SHash(2);
        eContFrac.x0 = eContFracs5wP;
    }
    public static Closure TestEntry()
    {
        // for (int i = 0; i < 99; i++)
        //     main_Entry(GHC.Prim.voidHash);
        return main_Entry(GHC.Prim.voidHash);
    }
    public static Closure main_Entry(GHC.Prim.Void void0E)
    {
        return mains5yo_Entry(GHC.Prim.voidHash);
    }
    public static Closure mains5yo_Entry(GHC.Prim.Void void0E)
    {
        var sats5yq = wtakeDigitss5xZ_Entry(50, DigitsE1.eContFrac);
        var wilds5yr = gos5yi_Entry(sats5yq);
        var wilds5yrTags5yr = wilds5yr.Tag;
        switch (wilds5yrTags5yr)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds5yr_Unit = wilds5yr as GHC.Tuple.Unit;
                    return GHC.Tuple.unit_DataCon;
                }
        }
    }
    public static Closure gos5yi_Entry(Closure dss5yj)
    {
        var wilds5yk = dss5yj.Eval();
        switch (wilds5yk)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5yk_Nil:
                {
                    return GHC.Tuple.unit_DataCon.Eval();
                }
            case GHC.Types.Cons wilds5yk_Cons:
                {
                    var xs5yl = wilds5yk_Cons.x0;
                    var xss5ym = wilds5yk_Cons.x1;
                    var ds1s5yn = xs5yl.Eval(); return gos5yi_Entry(xss5ym);
                }
        }
    }
    public static Closure e_Entry(Closure ns5yf)
    {
        var wws5yg = ns5yf.Eval();
        var wws5yg_IHash = wws5yg as GHC.Types.IHash;
        var wws5yh = wws5yg_IHash.x0;
        return wtakeDigitss5xZ_Entry(wws5yh, DigitsE1.eContFrac);
    }
    public static Closure takeDigits_Entry(Closure ws5ya, Closure ws5yb)
    {
        var wws5yc = ws5ya.Eval();
        var wws5yc_IHash = wws5yc as GHC.Types.IHash;
        var wws5yd = wws5yc_IHash.x0;
        return wtakeDigitss5xZ_Entry(wws5yd, ws5yb);
    }
    public static Closure wtakeDigitss5xZ_Entry(long wws5y0, Closure ws5y1)
    {
        var dss5y2 = wws5y0;
        switch (dss5y2)
        {
            default:
                {
                    var wilds5y3 = ws5y1.Eval();
                    switch (wilds5y3)
                    {
                        default: { throw new ImpossibleException(); }
                        case GHC.Types.Nil wilds5y3_Nil: { return lvls5xY.Eval(); }
                        case GHC.Types.Cons wilds5y3_Cons:
                            {
                                var xs5y4 = wilds5y3_Cons.x0;
                                var xss5y5 = wilds5y3_Cons.x1;
                                var sat_Frees5y8 = (dss5y2, xss5y5);
                                var sats5y8 = new Updatable<(long x0, Closure x1)>(&sats5y8_Entry, sat_Frees5y8);
                                return new GHC.Types.Cons(xs5y4, sats5y8);
                            }
                    }
                }
            case 0: { return GHC.Types.nil_DataCon.Eval(); }
        }
    }
    public static Closure sats5y8_Entry(in (long x0, Closure x1) sat_Frees5y8)
    {
        var dss5y2 = sat_Frees5y8.x0;
        var xss5y5 = sat_Frees5y8.x1;
        var sats5y7 = new SingleEntry<Closure>(&sats5y7_Entry, xss5y5);
        var sats5y6 = dss5y2 - 1;
        return wtakeDigitss5xZ_Entry(sats5y6, sats5y7);
    }
    public static Closure sats5y7_Entry(in Closure xss5y5)
    {
        return wratTranss5x8_Entry(lvls5xW, lvls5x7, lvls5x7, lvls5wQ, xss5y5);
    }
    public static Closure lvls5xY_Entry()
    {
        throw new System.Exception(lvls5xX);
    }
    public static Closure ratTrans_Entry(Closure ws5xP, Closure ws5xQ)
    {
        var wws5xR = ws5xP.Eval();
        var wws5xR_Tuple4 = wws5xR as GHC.Tuple.Tuple4;
        var wws5xS = wws5xR_Tuple4.x0;
        var wws5xT = wws5xR_Tuple4.x1;
        var wws5xU = wws5xR_Tuple4.x2;
        var wws5xV = wws5xR_Tuple4.x3;
        return wratTranss5x8_Entry(wws5xS, wws5xT, wws5xU, wws5xV, ws5xQ);
    }
    public static Closure wratTranss5x8_Entry(Closure wws5x9, Closure wws5xa, Closure wws5xb, Closure wws5xc, Closure ws5xd)
    {
        var wws5xe = GHC.Integer.Type.wsignumInteger_Entry(wws5xb);
        var wws5xf = GHC.Integer.Type.wsignumInteger_Entry(wws5xc);
        var sats5xh = new GHC.Integer.Type.SHash(wws5xf);
        var sats5xg = new GHC.Integer.Type.SHash(wws5xe);
        var wilds5xi = GHC.Integer.Type.eqIntegerHash_Entry(sats5xg, sats5xh);
        var js5xj = js5xj_Entry(wws5x9, wws5xa, wws5xb, wws5xc, ws5xd);
        var js5xr = js5xr_Entry(wws5x9, wws5xa, wws5xb, wws5xc, ws5xd, js5xj);
        var lwilds5xK = wilds5xi;
        switch (lwilds5xK)
        {
            default:
                {
                    var sats5xM = GHC.Integer.Type.absInteger_Entry(wws5xc);
                    var sats5xL = GHC.Integer.Type.absInteger_Entry(wws5xb);
                    var wilds5xN = GHC.Integer.Type.ltIntegerHash_Entry(sats5xL, sats5xM);
                    switch (wilds5xN)
                    {
                        default: { return js5xj.Eval(); }
                        case 1: { return js5xr.Eval(); }
                    }
                }
            case 1: { return js5xr.Eval(); }
        }
    }
    public static Closure js5xr_Entry(Closure wws5x9, Closure wws5xa, Closure wws5xb, Closure wws5xc, Closure ws5xd, Closure js5xj)
    {
        var wilds5xs = GHC.Integer.Type.eqIntegerHash_Entry(wws5xc, lvls5x7);
        switch (wilds5xs)
        {
            default:
                {
                    var qs5xt = GHC.Integer.Type.divInteger_Entry(wws5xa, wws5xc);
                    var sats5xw = GHC.Integer.Type.plusInteger_Entry(wws5x9, wws5xa);
                    var sats5xu = GHC.Integer.Type.plusInteger_Entry(wws5xb, wws5xc);
                    var sats5xv = GHC.Integer.Type.timesInteger_Entry(sats5xu, qs5xt);
                    var wilds5xx = GHC.Integer.Type.leIntegerHash_Entry(sats5xv, sats5xw);
                    switch (wilds5xx)
                    {
                        default: { return js5xj.Eval(); }
                        case 1:
                            {
                                var sats5xC = GHC.Integer.Type.plusInteger_Entry(wws5x9, wws5xa);
                                var sats5xA = GHC.Integer.Type.plusInteger_Entry(wws5xb, wws5xc);
                                var sats5xy = GHC.Integer.Type.plusInteger_Entry(wws5xb, wws5xc);
                                var sats5xz = GHC.Integer.Type.timesInteger_Entry(sats5xy, qs5xt);
                                var sats5xB = GHC.Integer.Type.plusInteger_Entry(sats5xz, sats5xA);
                                var wilds5xD = GHC.Integer.Type.gtIntegerHash_Entry(sats5xB, sats5xC);
                                switch (wilds5xD)
                                {
                                    default: { return js5xj.Eval(); }
                                    case 1:
                                        {
                                            var sat_Frees5xI = (wws5x9, wws5xa, wws5xb, wws5xc, ws5xd, qs5xt);
                                            var sats5xI = new Updatable<(Closure x0, Closure x1, Closure x2, Closure x3, Closure x4, Closure x5)>(&sats5xI_Entry, sat_Frees5xI);
                                            return new GHC.Types.Cons(qs5xt, sats5xI);
                                        }
                                }
                            }
                    }
                }
            case 1: { throw new System.Exception("Division by zero"); }
        }
    }
    public static Closure sats5xI_Entry(in (Closure x0, Closure x1, Closure x2, Closure x3, Closure x4, Closure x5) sat_Frees5xI)
    {
        var wws5x9 = sat_Frees5xI.x0;
        var wws5xa = sat_Frees5xI.x1;
        var wws5xb = sat_Frees5xI.x2;
        var wws5xc = sat_Frees5xI.x3;
        var ws5xd = sat_Frees5xI.x4;
        var qs5xt = sat_Frees5xI.x5;
        var sats5xG = GHC.Integer.Type.timesInteger_Entry(qs5xt, wws5xc);
        var sats5xH = GHC.Integer.Type.minusInteger_Entry(wws5xa, sats5xG);
        var sats5xE = GHC.Integer.Type.timesInteger_Entry(qs5xt, wws5xb);
        var sats5xF = GHC.Integer.Type.minusInteger_Entry(wws5x9, sats5xE);
        return wratTranss5x8_Entry(wws5xb, wws5xc, sats5xF, sats5xH, ws5xd);
    }
    public static Closure js5xj_Entry(Closure wws5x9, Closure wws5xa, Closure wws5xb, Closure wws5xc, Closure ws5xd)
    {
        var wilds5xk = ws5xd.Eval();
        switch (wilds5xk)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5xk_Nil: { return lvls5x6.Eval(); }
            case GHC.Types.Cons wilds5xk_Cons:
                {
                    var xs5xl = wilds5xk_Cons.x0;
                    var xss5xm = wilds5xk_Cons.x1;
                    var sats5xp = GHC.Integer.Type.timesInteger_Entry(xs5xl, wws5xc);
                    var sats5xq = GHC.Integer.Type.plusInteger_Entry(wws5xb, sats5xp);
                    var sats5xn = GHC.Integer.Type.timesInteger_Entry(xs5xl, wws5xa);
                    var sats5xo = GHC.Integer.Type.plusInteger_Entry(wws5x9, sats5xn);
                    return wratTranss5x8_Entry(wws5xa, sats5xo, wws5xc, sats5xq, xss5xm);
                }
        }
    }
    public static Closure lvls5x6_Entry()
    {
        throw new System.Exception(lvls5x5);
    }
    public static Closure eContFracs5x0_Entry()
    {
        var wws5x1 = wauxs5wR_Entry(eContFracs5wP);
        var wws5x1_RawTuple = wws5x1;
        var wws5x2 = wws5x1_RawTuple.x0;
        var wws5x3 = wws5x1_RawTuple.x1;
        return new GHC.Types.Cons(wws5x2, wws5x3);
    }
    public static (Closure x0, Closure x1) wauxs5wR_Entry(Closure ws5wS)
    {
        var sats5wX = new Updatable<Closure>(&sats5wX_Entry, ws5wS);
        var sats5wY = new GHC.Types.Cons(lvls5wQ, sats5wX);
        var sats5wZ = new GHC.Types.Cons(ws5wS, sats5wY);
        return (lvls5wQ, sats5wZ);
    }
    public static Closure sats5wX_Entry(in Closure ws5wS)
    {
        var sats5wT = new Updatable<Closure>(&sats5wT_Entry, ws5wS);
        var wws5wU = wauxs5wR_Entry(sats5wT);
        var wws5wU_RawTuple = wws5wU;
        var wws5wV = wws5wU_RawTuple.x0;
        var wws5wW = wws5wU_RawTuple.x1;
        return new GHC.Types.Cons(wws5wV, wws5wW);
    }
    public static Closure sats5wT_Entry(in Closure ws5wS)
    {
        return GHC.Integer.Type.plusInteger_Entry(ws5wS, eContFracs5wP);
    }

}
