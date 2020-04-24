using Lazer.Runtime;

public unsafe static class DigitsE1
{
    internal static string lvls5xZ = "Main.lhs:(40,3)-(41,67)|function takeDigits";
    internal static string lvls5x7 = "Main.lhs:(30,3)-(35,59)|function ratTrans";
    public static Fun main;

    internal static Fun mains5yq;

    internal static Fun gos5yk;

    public static Fun e;

    public static Fun takeDigits;

    internal static Fun wtakeDigitss5y1;

    internal static Updatable lvls5y0;

    public static Fun ratTrans;

    internal static Fun wratTranss5xa;

    internal static Updatable lvls5x8;

    internal static Updatable eContFracs5x2;

    internal static Fun wauxs5wT;

    internal static Data eContFracs5wR;
    internal static Data lvls5wS;
    public static GHC.Types.Cons eContFrac;
    internal static Data lvls5x9;
    internal static Data lvls5xY;

    static DigitsE1()
    {
        main = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(main_Entry));

        mains5yq = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(mains5yq_Entry));

        gos5yk = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(gos5yk_Entry));

        e = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(e_Entry));

        takeDigits = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(takeDigits_Entry));

        wtakeDigitss5y1 = new Fun(2, CLR.LoadFunctionPointer<long, Closure, Closure>(wtakeDigitss5y1_Entry));

        lvls5y0 = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls5y0_Entry));

        ratTrans = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(ratTrans_Entry));

        wratTranss5xa = new Fun(5, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure>(wratTranss5xa_Entry));

        lvls5x8 = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls5x8_Entry));

        eContFracs5x2 = new Updatable(CLR.LoadFunctionPointer<Closure>(eContFracs5x2_Entry));

        wauxs5wT = new Fun(1, CLR.LoadFunctionPointer<Closure, (Closure x0, Closure x1)>(wauxs5wT_Entry));

        lvls5xY = GHC.Integer.Type.smallInteger_Entry(10) as Data;
        lvls5x9 = GHC.Integer.Type.smallInteger_Entry(0) as Data;
        eContFrac = new GHC.Types.Cons(null, eContFracs5x2);
        lvls5wS = GHC.Integer.Type.smallInteger_Entry(1) as Data;
        eContFracs5wR = GHC.Integer.Type.smallInteger_Entry(2) as Data;
        eContFrac.x0 = eContFracs5wR;
    }
    public static Closure TestEntry()
    {
        for (int i = 0; i < 99; i++)
            main_Entry(GHC.Prim.voidHash);
        return main_Entry(GHC.Prim.voidHash);
    }
    public static Closure main_Entry(GHC.Prim.Void void0E)
    {
        return mains5yq_Entry(GHC.Prim.voidHash);
    }
    public static Closure mains5yq_Entry(GHC.Prim.Void void0E)
    {
        var sats5ys = wtakeDigitss5y1_Entry(50, DigitsE1.eContFrac).Eval();
        var wilds5yt = gos5yk_Entry(sats5ys).Eval();
        var wilds5ytTags5yt = wilds5yt.Tag;
        switch (wilds5ytTags5yt)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds5yt_Unit = wilds5yt as GHC.Tuple.Unit;
                    return GHC.Tuple.unit_DataCon;
                }
        }
    }
    public static Closure gos5yk_Entry(Closure dss5yl)
    {
        var wilds5ym = dss5yl.Eval();
        switch (wilds5ym)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5ym_Nil:
                {
                    return GHC.Tuple.unit_DataCon.Eval();
                }
            case GHC.Types.Cons wilds5ym_Cons:
                {
                    var xs5yn = wilds5ym_Cons.x0;
                    var xss5yo = wilds5ym_Cons.x1;
                    var ds1s5yp = xs5yn.Eval(); return gos5yk_Entry(xss5yo);
                }
        }
    }
    public static Closure e_Entry(Closure ns5yh)
    {
        var wws5yi = ns5yh.Eval();
        var wws5yi_IHash = wws5yi as GHC.Types.IHash;
        var wws5yj = wws5yi_IHash.x0;
        return wtakeDigitss5y1_Entry(wws5yj, DigitsE1.eContFrac);
    }
    public static Closure takeDigits_Entry(Closure ws5yc, Closure ws5yd)
    {
        var wws5ye = ws5yc.Eval();
        var wws5ye_IHash = wws5ye as GHC.Types.IHash;
        var wws5yf = wws5ye_IHash.x0;
        return wtakeDigitss5y1_Entry(wws5yf, ws5yd);
    }
    public static Closure wtakeDigitss5y1_Entry(long wws5y2, Closure ws5y3)
    {
        var dss5y4 = wws5y2;
        switch (dss5y4)
        {
            default:
                {
                    var wilds5y5 = ws5y3.Eval();
                    switch (wilds5y5)
                    {
                        default: { throw new ImpossibleException($"{wilds5y5.GetType()}"); }
                        case GHC.Types.Nil wilds5y5_Nil: { return lvls5y0.Eval(); }
                        case GHC.Types.Cons wilds5y5_Cons:
                            {
                                var xs5y6 = wilds5y5_Cons.x0;
                                var xss5y7 = wilds5y5_Cons.x1;
                                var sats5ya = new Updatable<long, Closure>(CLR.LoadFunctionPointer<long, Closure, Closure>(sats5ya_Entry), dss5y4, xss5y7);
                                return new GHC.Types.Cons(xs5y6, sats5ya);
                            }
                    }
                }
            case 0: { return GHC.Types.nil_DataCon.Eval(); }
        }
    }
    public static Closure sats5ya_Entry(long dss5y4, Closure xss5y7)
    {
        var sats5y9 = new SingleEntry<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats5y9_Entry), xss5y7);
        var sats5y8 = dss5y4 - 1;
        return wtakeDigitss5y1_Entry(sats5y8, sats5y9);
    }
    public static Closure sats5y9_Entry(Closure xss5y7)
    {
        return wratTranss5xa_Entry(lvls5xY, lvls5x9, lvls5x9, lvls5wS, xss5y7);
    }
    public static Closure lvls5y0_Entry()
    {
        throw new System.Exception(lvls5xZ);
    }
    public static Closure ratTrans_Entry(Closure ws5xR, Closure ws5xS)
    {
        var wws5xT = ws5xR.Eval();
        var wws5xT_Tuple4 = wws5xT as GHC.Tuple.Tuple4;
        var wws5xU = wws5xT_Tuple4.x0;
        var wws5xV = wws5xT_Tuple4.x1;
        var wws5xW = wws5xT_Tuple4.x2;
        var wws5xX = wws5xT_Tuple4.x3;
        return wratTranss5xa_Entry(wws5xU, wws5xV, wws5xW, wws5xX, ws5xS);
    }
    public static Closure wratTranss5xa_Entry(Closure wws5xb, Closure wws5xc, Closure wws5xd, Closure wws5xe, Closure ws5xf)
    {
        var wws5xg = GHC.Integer.Type.signumInteger_Entry(wws5xd);
        var wws5xh = GHC.Integer.Type.signumInteger_Entry(wws5xe);
        var sats5xj = wws5xh;
        var sats5xi = wws5xg;
        var wilds5xk = GHC.Integer.Type.eqIntegerHash_Entry(sats5xi, sats5xj);
        var js5xl = new Updatable<Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure>(js5xl_Entry), wws5xb, wws5xc, wws5xd, wws5xe, ws5xf);
        var js5xt = new Updatable<Closure, Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure, Closure>(js5xt_Entry), wws5xb, wws5xc, wws5xd, wws5xe, ws5xf, js5xl);
        var lwilds5xM = wilds5xk;
        switch (lwilds5xM)
        {
            default:
                {
                    var sats5xO = GHC.Integer.Type.absInteger_Entry(wws5xe).Eval();
                    var sats5xN = GHC.Integer.Type.absInteger_Entry(wws5xd).Eval();
                    var wilds5xP = GHC.Integer.Type.ltIntegerHash_Entry(sats5xN, sats5xO);
                    switch (wilds5xP)
                    {
                        default: { return js5xl.Eval(); }
                        case 1: { return js5xt.Eval(); }
                    }
                }
            case 1: { return js5xt.Eval(); }
        }
    }
    public static Closure js5xt_Entry(Closure wws5xb, Closure wws5xc, Closure wws5xd, Closure wws5xe, Closure ws5xf, Closure js5xl)
    {
        var wilds5xu = GHC.Integer.Type.eqIntegerHash_Entry(wws5xe, lvls5x9);
        switch (wilds5xu)
        {
            default:
                {
                    var qs5xv = GHC.Integer.Type.divInteger_Entry(wws5xc, wws5xe).Eval();
                    var sats5xy = GHC.Integer.Type.plusInteger_Entry(wws5xb, wws5xc).Eval();
                    var sats5xw = GHC.Integer.Type.plusInteger_Entry(wws5xd, wws5xe).Eval();
                    var sats5xx = GHC.Integer.Type.timesInteger_Entry(sats5xw, qs5xv).Eval();
                    var wilds5xz = GHC.Integer.Type.leIntegerHash_Entry(sats5xx, sats5xy);
                    switch (wilds5xz)
                    {
                        default: { return js5xl.Eval(); }
                        case 1:
                            {
                                var sats5xE = GHC.Integer.Type.plusInteger_Entry(wws5xb, wws5xc).Eval();
                                var sats5xC = GHC.Integer.Type.plusInteger_Entry(wws5xd, wws5xe).Eval();
                                var sats5xA = GHC.Integer.Type.plusInteger_Entry(wws5xd, wws5xe).Eval();
                                var sats5xB = GHC.Integer.Type.timesInteger_Entry(sats5xA, qs5xv).Eval();
                                var sats5xD = GHC.Integer.Type.plusInteger_Entry(sats5xB, sats5xC).Eval();
                                var wilds5xF = GHC.Integer.Type.gtIntegerHash_Entry(sats5xD, sats5xE);
                                switch (wilds5xF)
                                {
                                    default: { return js5xl.Eval(); }
                                    case 1:
                                        {
                                            var sats5xK = new Updatable<Closure, Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure, Closure>(sats5xK_Entry), wws5xb, wws5xc, wws5xd, wws5xe, ws5xf, qs5xv);
                                            return new GHC.Types.Cons(qs5xv, sats5xK);
                                        }
                                }
                            }
                    }
                }
            case 1: { throw new System.Exception("Division by zero"); }
        }
    }
    public static Closure sats5xK_Entry(Closure wws5xb, Closure wws5xc, Closure wws5xd, Closure wws5xe, Closure ws5xf, Closure qs5xv)
    {
        var sats5xI = GHC.Integer.Type.timesInteger_Entry(qs5xv, wws5xe).Eval();
        var sats5xJ = GHC.Integer.Type.minusInteger_Entry(wws5xc, sats5xI).Eval();
        var sats5xG = GHC.Integer.Type.timesInteger_Entry(qs5xv, wws5xd).Eval();
        var sats5xH = GHC.Integer.Type.minusInteger_Entry(wws5xb, sats5xG).Eval();
        return wratTranss5xa_Entry(wws5xd, wws5xe, sats5xH, sats5xJ, ws5xf);
    }
    public static Closure js5xl_Entry(Closure wws5xb, Closure wws5xc, Closure wws5xd, Closure wws5xe, Closure ws5xf)
    {
        var wilds5xm = ws5xf.Eval();
        switch (wilds5xm)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds5xm_Nil: { return lvls5x8.Eval(); }
            case GHC.Types.Cons wilds5xm_Cons:
                {
                    var xs5xn = wilds5xm_Cons.x0;
                    var xss5xo = wilds5xm_Cons.x1;
                    var sats5xr = GHC.Integer.Type.timesInteger_Entry(xs5xn, wws5xe).Eval();
                    var sats5xs = GHC.Integer.Type.plusInteger_Entry(wws5xd, sats5xr).Eval();
                    var sats5xp = GHC.Integer.Type.timesInteger_Entry(xs5xn, wws5xc).Eval();
                    var sats5xq = GHC.Integer.Type.plusInteger_Entry(wws5xb, sats5xp).Eval();
                    return wratTranss5xa_Entry(wws5xc, sats5xq, wws5xe, sats5xs, xss5xo);
                }
        }
    }
    public static Closure lvls5x8_Entry()
    {
        throw new System.Exception(lvls5x7);
    }
    public static Closure eContFracs5x2_Entry()
    {
        var wws5x3 = wauxs5wT_Entry(eContFracs5wR);
        var wws5x3_RawTuple = wws5x3;
        var wws5x4 = wws5x3_RawTuple.x0;
        var wws5x5 = wws5x3_RawTuple.x1;
        return new GHC.Types.Cons(wws5x4, wws5x5);
    }
    public static (Closure x0, Closure x1) wauxs5wT_Entry(Closure ws5wU)
    {
        var sats5wZ = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats5wZ_Entry), ws5wU);
        var sats5x0 = new GHC.Types.Cons(lvls5wS, sats5wZ);
        var sats5x1 = new GHC.Types.Cons(ws5wU, sats5x0);
        return (lvls5wS, sats5x1);
    }
    public static Closure sats5wZ_Entry(Closure ws5wU)
    {
        var sats5wV = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats5wV_Entry), ws5wU);
        var wws5wW = wauxs5wT_Entry(sats5wV);
        var wws5wW_RawTuple = wws5wW;
        var wws5wX = wws5wW_RawTuple.x0;
        var wws5wY = wws5wW_RawTuple.x1;
        return new GHC.Types.Cons(wws5wX, wws5wY);
    }
    public static Closure sats5wV_Entry(Closure ws5wU)
    {
        return GHC.Integer.Type.plusInteger_Entry(ws5wU, eContFracs5wR);
    }

}
