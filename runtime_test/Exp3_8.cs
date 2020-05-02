using Lazer.Runtime;

public unsafe static class Exp3
{
    internal static string lvls7XC = "Result: ";
    internal static string lvls7Xu = "AVG: ";
    internal static string lvls7Xi = "MIN: ";
    internal static string lvls7X7 = "MAX: ";
    internal static string lvls7VW = "w p";
    internal static string tc_Ss7VO = "'S";
    internal static string tc_Zs7VL = "'Z";
    internal static string tcNats7VG = "Nat";
    internal static string trModules7VD = "Main";
    internal static string trModules7VB = "main";
    internal static string lvls7U9 = "Z";
    internal static string fs7U7 = "S ";
    internal static string lvls7TD = "Main2.hs:27:10-16|abs";
    internal static string lvls7TB = "Main2.hs:27:10-16|signum";
    internal static string lvls7Th = "maximum";
    internal static string lvls7SX = "minimum";
    internal static string lvls7Sf = "Negative exponent";
    public static Function s_DataCon;

    internal static Function wfs7W1;

    internal static Thunk lvls7VY;

    internal static Thunk lvls7VX;

    internal static Function wints7VR;

    public static Function g;

    internal static Thunk lvls7Vx;

    internal static Thunk lvls7Vv;

    public static Function hatHatHat;

    internal static Function hatHatHats7Vn;

    internal static Function cmins7Vh;

    internal static Function cGtEqs7Vd;

    internal static Function cGts7Va;

    internal static Function cmaxs7V6;

    internal static Function cLtEqs7V2;

    internal static Function cLts7UT;

    internal static Function ccompares7UK;

    internal static Function cSlshEqs7UF;

    internal static Function cEqEqs7Uw;

    internal static Function cshowLists7Us;

    internal static Function lvls7Ur;

    internal static Function cshows7Up;

    internal static Function cshowsPrecs7Ub;

    internal static Thunk lvls7Ua;

    internal static Thunk fs7U8;

    internal static Function cnegates7U3;

    internal static Function cDashs7U0;

    internal static Thunk lvls7TY;

    internal static Function wDollcDashs7TX;

    internal static Thunk lvls7TW;

    internal static Function cfromIntegers7TR;

    internal static Function cAstrs7TL;

    internal static Function cPluss7TF;

    internal static Thunk cabss7TE;

    internal static Thunk csignums7TC;

    internal static Thunk lvls7Sg;

    internal static Function sfromIntegrals7Sc;

    internal static GHC.Integer.Type.SHash lvls7Si;
    internal static GHC.Integer.Type.SHash lvls7Sj;
    internal static GHC.Integer.Type.SHash lvls7Sk;
    public static GHC.Num.CColNum fNumNat;
    internal static GHC.Types.IHash lvls7U6;
    internal static GHC.Types.IHash lvls7Uo;
    public static GHC.Show.CColShow fShowNat;
    public static GHC.Classes.CColEq fEqNat;
    public static GHC.Classes.CColOrd fOrdNat;
    internal static Exp3.S lvls7Vm;
    internal static GHC.Integer.Type.SHash lvls7Vu;
    internal static GHC.Integer.Type.SHash lvls7Vw;
    internal static GHC.Types.DHash lvls7W7;
    public static Exp3.Z z_DataCon;

    static Exp3()
    {
        s_DataCon = new Fun1<Closure, Closure>(&s_DataCon_Entry);


        wfs7W1 = new Fun1<GHC.Prim.Void, long>(&wfs7W1_Entry);
        lvls7VY = new Updatable(&lvls7VY_Entry);
        lvls7VX = new Updatable(&lvls7VX_Entry);
        wints7VR = new Fun1<Closure, long>(&wints7VR_Entry);
        g = new Fun1<Closure, Closure>(&g_Entry);
        lvls7Vx = new Updatable(&lvls7Vx_Entry);
        lvls7Vv = new Updatable(&lvls7Vv_Entry);
        hatHatHat = new Fun2<Closure, Closure, Closure>(&hatHatHat_Entry);

        hatHatHats7Vn = new Fun2<Closure, Closure, Closure>(&hatHatHats7Vn_Entry);

        cmins7Vh = new Fun2<Closure, Closure, Closure>(&cmins7Vh_Entry);

        cGtEqs7Vd = new Fun2<Closure, Closure, Closure>(&cGtEqs7Vd_Entry);

        cGts7Va = new Fun2<Closure, Closure, Closure>(&cGts7Va_Entry);

        cmaxs7V6 = new Fun2<Closure, Closure, Closure>(&cmaxs7V6_Entry);

        cLtEqs7V2 = new Fun2<Closure, Closure, Closure>(&cLtEqs7V2_Entry);

        cLts7UT = new Fun2<Closure, Closure, Closure>(&cLts7UT_Entry);

        ccompares7UK = new Fun2<Closure, Closure, Closure>(&ccompares7UK_Entry);

        cSlshEqs7UF = new Fun2<Closure, Closure, Closure>(&cSlshEqs7UF_Entry);

        cEqEqs7Uw = new Fun2<Closure, Closure, Closure>(&cEqEqs7Uw_Entry);

        cshowLists7Us = new Fun2<Closure, Closure, Closure>(&cshowLists7Us_Entry);

        lvls7Ur = new Fun2<Closure, Closure, Closure>(&lvls7Ur_Entry);

        cshows7Up = new Fun1<Closure, Closure>(&cshows7Up_Entry);

        cshowsPrecs7Ub = new Fun3<Closure, Closure, Closure, Closure>(&cshowsPrecs7Ub_Entry);

        lvls7Ua = new Updatable(&lvls7Ua_Entry);
        fs7U8 = new Updatable(&fs7U8_Entry);
        cnegates7U3 = new Fun1<Closure, Closure>(&cnegates7U3_Entry);

        cDashs7U0 = new Fun2<Closure, Closure, Closure>(&cDashs7U0_Entry);

        lvls7TY = new Updatable(&lvls7TY_Entry);
        wDollcDashs7TX = new Fun1<Closure, Closure>(&wDollcDashs7TX_Entry);

        lvls7TW = new Updatable(&lvls7TW_Entry);
        cfromIntegers7TR = new Fun1<Closure, Closure>(&cfromIntegers7TR_Entry);

        cAstrs7TL = new Fun2<Closure, Closure, Closure>(&cAstrs7TL_Entry);

        cPluss7TF = new Fun2<Closure, Closure, Closure>(&cPluss7TF_Entry);

        cabss7TE = new Updatable(&cabss7TE_Entry);
        csignums7TC = new Updatable(&csignums7TC_Entry);

        lvls7Sg = new Updatable(&lvls7Sg_Entry);
        sfromIntegrals7Sc = new Fun1<Closure, Closure>(&sfromIntegrals7Sc_Entry);

        z_DataCon = new Exp3.Z();
        lvls7W7 = new GHC.Types.DHash(10.0);
        lvls7Vw = new GHC.Integer.Type.SHash(9);
        lvls7Vu = new GHC.Integer.Type.SHash(3);
        lvls7Vm = new Exp3.S((Closure)null);
        fOrdNat = new GHC.Classes.CColOrd((Closure)null, ccompares7UK, cLts7UT, cLtEqs7V2, cGts7Va, cGtEqs7Vd, cmaxs7V6, cmins7Vh);
        fEqNat = new GHC.Classes.CColEq(cEqEqs7Uw, cSlshEqs7UF);
        fShowNat = new GHC.Show.CColShow(cshowsPrecs7Ub, cshows7Up, cshowLists7Us);
        lvls7Uo = new GHC.Types.IHash(0);
        lvls7U6 = new GHC.Types.IHash(11);
        fNumNat = new GHC.Num.CColNum(cPluss7TF, cDashs7U0, cAstrs7TL, cnegates7U3, cabss7TE, csignums7TC, cfromIntegers7TR);
        lvls7Sk = new GHC.Integer.Type.SHash(0);
        lvls7Sj = new GHC.Integer.Type.SHash(1);
        lvls7Si = new GHC.Integer.Type.SHash(2);
        fOrdNat.x0 = Exp3.fEqNat; lvls7Vm.x0 = Exp3.z_DataCon;
    }
    public static Closure s_DataCon_Entry(Closure etaB1)
    {
        return new Exp3.S(etaB1);
    }
    public static long TestEntry(int n)
    {
        
        var xs6bm = GHC.Integer.Type.smallInteger_Entry(n);
        var sats6bp = cfromIntegers7TR_Entry(xs6bm).Eval();
        var sats6bq = hatHatHats7Vn_Entry(lvls7Vv, sats6bp).Eval();
        var wws6br = wints7VR_Entry(sats6bq);
        return wws6br;
    }
    public static long wfs7W1_Entry(GHC.Prim.Void void0E)
    {
        var vs7W3 = lvls7VY.Eval();
        var vs7W3_IHash = vs7W3 as GHC.Types.IHash;
        var vs7W4 = vs7W3_IHash.x0; return vs7W4;
    }
    public static Closure lvls7VY_Entry()
    {
        var sats7VZ = g_Entry(lvls7VX);
        var vs7W0 = wints7VR_Entry(sats7VZ);
        return new GHC.Types.IHash(vs7W0);
    }
    public static Closure lvls7VX_Entry()
    {
        throw new System.Exception(lvls7VW);
    }
    public static long wints7VR_Entry(Closure ws7VS)
    {
        var wilds7VT = ws7VS.Eval();
        switch (wilds7VT)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7VT_Z: { return 0; }
            case Exp3.S wilds7VT_S:
                {
                    var xs7VU = wilds7VT_S.x0;
                    var wws7VV = wints7VR_Entry(xs7VU); return 1 + wws7VV;
                }
        }
    }
    public static Closure g_Entry(Closure xs7VA)
    {
        return lvls7Vx.Eval();
    }
    public static Closure lvls7Vx_Entry()
    {
        var sats7Vy = cfromIntegers7TR_Entry(lvls7Vw);
        return hatHatHat_Entry(lvls7Vv, sats7Vy);
    }
    public static Closure lvls7Vv_Entry()
    {
        return cfromIntegers7TR_Entry(lvls7Vu);
    }
    public static Closure hatHatHat_Entry(Closure etaB2, Closure etaB1)
    {
        return hatHatHats7Vn_Entry(etaB2, etaB1);
    }
    public static Closure hatHatHats7Vn_Entry(Closure xs7Vo, Closure dss7Vp)
    {
        var wilds7Vq = dss7Vp.Eval();
        switch (wilds7Vq)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7Vq_Z: { return lvls7Vm.Eval(); }
            case Exp3.S wilds7Vq_S:
                {
                    var ys7Vr = wilds7Vq_S.x0;
                    var sats7Vs = hatHatHats7Vn_Entry(xs7Vo, ys7Vr);
                    return cAstrs7TL_Entry(xs7Vo, sats7Vs);
                }
        }
    }
    public static Closure cmins7Vh_Entry(Closure xs7Vi, Closure ys7Vj)
    {
        var wilds7Vk = cLts7UT_Entry(ys7Vj, xs7Vi);
        var wilds7VkTags7Vk = wilds7Vk.Tag;
        switch (wilds7VkTags7Vk)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds7Vk_False = wilds7Vk as GHC.Types.False;
                    return xs7Vi.Eval();
                }
            case 2:
                {
                    var wilds7Vk_True = wilds7Vk as GHC.Types.True;
                    return ys7Vj.Eval();
                }
        }
    }
    public static Closure cGtEqs7Vd_Entry(Closure as7Ve, Closure bs7Vf)
    {
        var wilds7Vg = cLts7UT_Entry(as7Ve, bs7Vf);
        var wilds7VgTags7Vg = wilds7Vg.Tag;
        switch (wilds7VgTags7Vg)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds7Vg_False = wilds7Vg as GHC.Types.False;
                    return GHC.Types.true_DataCon.Eval();
                }
            case 2:
                {
                    var wilds7Vg_True = wilds7Vg as GHC.Types.True;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cGts7Va_Entry(Closure as7Vb, Closure bs7Vc)
    {
        return cLts7UT_Entry(bs7Vc, as7Vb);
    }
    public static Closure cmaxs7V6_Entry(Closure xs7V7, Closure ys7V8)
    {
        var wilds7V9 = cLts7UT_Entry(ys7V8, xs7V7);
        var wilds7V9Tags7V9 = wilds7V9.Tag;
        switch (wilds7V9Tags7V9)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds7V9_False = wilds7V9 as GHC.Types.False;
                    return ys7V8.Eval();
                }
            case 2:
                {
                    var wilds7V9_True = wilds7V9 as GHC.Types.True;
                    return xs7V7.Eval();
                }
        }
    }
    public static Closure cLtEqs7V2_Entry(Closure as7V3, Closure bs7V4)
    {
        var wilds7V5 = cLts7UT_Entry(bs7V4, as7V3);
        var wilds7V5Tags7V5 = wilds7V5.Tag;
        switch (wilds7V5Tags7V5)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds7V5_False = wilds7V5 as GHC.Types.False;
                    return GHC.Types.true_DataCon.Eval();
                }
            case 2:
                {
                    var wilds7V5_True = wilds7V5 as GHC.Types.True;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cLts7UT_Entry(Closure as7UU, Closure bs7UV)
    {
        var wilds7UW = as7UU.Eval();
        switch (wilds7UW)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7UW_Z:
                {
                    var wilds7UX = bs7UV.Eval();
                    switch (wilds7UX)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7UX_Z: { return GHC.Types.false_DataCon.Eval(); }
                        case Exp3.S wilds7UX_S:
                            {
                                var ipvs7UY = wilds7UX_S.x0; return GHC.Types.true_DataCon.Eval();
                            }
                    }
                }
            case Exp3.S wilds7UW_S:
                {
                    var a1s7UZ = wilds7UW_S.x0;
                    var wilds7V0 = bs7UV.Eval();
                    switch (wilds7V0)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7V0_Z: { return GHC.Types.false_DataCon.Eval(); }
                        case Exp3.S wilds7V0_S:
                            {
                                var b1s7V1 = wilds7V0_S.x0;
                                return cLts7UT_Entry(a1s7UZ, b1s7V1);
                            }
                    }
                }
        }
    }
    public static Closure ccompares7UK_Entry(Closure as7UL, Closure bs7UM)
    {
        var wilds7UN = as7UL.Eval();
        switch (wilds7UN)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7UN_Z:
                {
                    var wilds7UO = bs7UM.Eval();
                    switch (wilds7UO)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7UO_Z: { return GHC.Types.eQ_DataCon.Eval(); }
                        case Exp3.S wilds7UO_S:
                            {
                                var ipvs7UP = wilds7UO_S.x0; return GHC.Types.lT_DataCon.Eval();
                            }
                    }
                }
            case Exp3.S wilds7UN_S:
                {
                    var a1s7UQ = wilds7UN_S.x0;
                    var wilds7UR = bs7UM.Eval();
                    switch (wilds7UR)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7UR_Z: { return GHC.Types.gT_DataCon.Eval(); }
                        case Exp3.S wilds7UR_S:
                            {
                                var b1s7US = wilds7UR_S.x0;
                                return ccompares7UK_Entry(a1s7UQ, b1s7US);
                            }
                    }
                }
        }
    }
    public static Closure cSlshEqs7UF_Entry(Closure etas7UG, Closure etas7UH)
    {
        var wilds7UI = cEqEqs7Uw_Entry(etas7UG, etas7UH);
        var wilds7UITags7UI = wilds7UI.Tag;
        switch (wilds7UITags7UI)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wilds7UI_False = wilds7UI as GHC.Types.False;
                    return GHC.Types.true_DataCon.Eval();
                }
            case 2:
                {
                    var wilds7UI_True = wilds7UI as GHC.Types.True;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cEqEqs7Uw_Entry(Closure dss7Ux, Closure dss7Uy)
    {
        var wilds7Uz = dss7Ux.Eval();
        switch (wilds7Uz)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7Uz_Z:
                {
                    var wilds7UA = dss7Uy.Eval();
                    switch (wilds7UA)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7UA_Z: { return GHC.Types.true_DataCon.Eval(); }
                        case Exp3.S wilds7UA_S:
                            {
                                var ipvs7UB = wilds7UA_S.x0;
                                return GHC.Types.false_DataCon.Eval();
                            }
                    }
                }
            case Exp3.S wilds7Uz_S:
                {
                    var a1s7UC = wilds7Uz_S.x0;
                    var wilds7UD = dss7Uy.Eval();
                    switch (wilds7UD)
                    {
                        default: { throw new ImpossibleException(); }
                        case Exp3.Z wilds7UD_Z: { return GHC.Types.false_DataCon.Eval(); }
                        case Exp3.S wilds7UD_S:
                            {
                                var b1s7UE = wilds7UD_S.x0;
                                return cEqEqs7Uw_Entry(a1s7UC, b1s7UE);
                            }
                    }
                }
        }
    }
    public static Closure cshowLists7Us_Entry(Closure lss7Ut, Closure ss7Uu)
    {
        return GHC.Show.showList___Entry(lvls7Ur, lss7Ut, ss7Uu);
    }
    public static Closure lvls7Ur_Entry(Closure etaB2, Closure etaB1)
    {
        return cshowsPrecs7Ub_Entry(lvls7Uo, etaB2, etaB1);
    }
    public static Closure cshows7Up_Entry(Closure xs7Uq)
    {
        return cshowsPrecs7Ub_Entry(lvls7Uo, xs7Uq, GHC.Types.nil_DataCon);
    }
    public static Closure cshowsPrecs7Ub_Entry(Closure dss7Uc, Closure dss7Ud, Closure etas7Ue)
    {
        var wilds7Uf = dss7Ud.Eval();
        switch (wilds7Uf)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7Uf_Z:
                {
                    return GHC.Base.plusPlus_Entry(lvls7Ua, etas7Ue);
                }
            case Exp3.S wilds7Uf_S:
                {
                    var b1s7Ug = wilds7Uf_S.x0;
                    var wilds7Uh = dss7Uc.Eval();
                    var wilds7Uh_IHash = wilds7Uh as GHC.Types.IHash;
                    var xs7Ui = wilds7Uh_IHash.x0;
                    var lwilds7Uj = (xs7Ui >= 11) ? 1 : 0;
                    switch (lwilds7Uj)
                    {
                        default:
                            {
                                var sat_Frees7Uk = (etas7Ue, b1s7Ug);
                                var sats7Uk = new SingleEntry<(Closure x0, Closure x1)>(&sats7Uk_Entry, sat_Frees7Uk);
                                return GHC.Base.plusPlus_Entry(fs7U8, sats7Uk);
                            }
                        case 1:
                            {
                                var sat_Frees7Un = (etas7Ue, b1s7Ug);
                                var sats7Un = new Updatable<(Closure x0, Closure x1)>(&sats7Un_Entry, sat_Frees7Un);
                                return new GHC.Types.Cons(GHC.Show.fShowPrOComPrC, sats7Un);
                            }
                    }
                }
        }
    }
    public static Closure sats7Uk_Entry(in (Closure x0, Closure x1) sat_Frees7Uk)
    {
        var etas7Ue = sat_Frees7Uk.x0;
        var b1s7Ug = sat_Frees7Uk.x1;
        return cshowsPrecs7Ub_Entry(lvls7U6, b1s7Ug, etas7Ue);
    }
    public static Closure sats7Un_Entry(in (Closure x0, Closure x1) sat_Frees7Un)
    {
        var etas7Ue = sat_Frees7Un.x0;
        var b1s7Ug = sat_Frees7Un.x1;
        var sat_Frees7Um = (etas7Ue, b1s7Ug);
        var sats7Um = new SingleEntry<(Closure x0, Closure x1)>(&sats7Um_Entry, sat_Frees7Um);
        return GHC.Base.plusPlus_Entry(fs7U8, sats7Um);
    }
    public static Closure sats7Um_Entry(in (Closure x0, Closure x1) sat_Frees7Um)
    {
        var etas7Ue = sat_Frees7Um.x0;
        var b1s7Ug = sat_Frees7Um.x1;
        var sats7Ul = new GHC.Types.Cons(GHC.Show.fShowPrOComPrC, etas7Ue);
        return cshowsPrecs7Ub_Entry(lvls7U6, b1s7Ug, sats7Ul);
    }
    public static Closure lvls7Ua_Entry()
    {
        return GHC.CString.unpackCStringHash_Entry(lvls7U9);
    }
    public static Closure fs7U8_Entry()
    {
        return GHC.CString.unpackCStringHash_Entry(fs7U7);
    }
    public static Closure cnegates7U3_Entry(Closure etas7U4)
    {
        return lvls7TY.Eval();
    }
    public static Closure cDashs7U0_Entry(Closure ws7U1, Closure ws7U2)
    {
        return wDollcDashs7TX_Entry(ws7U1);
    }
    public static Closure lvls7TY_Entry()
    {
        return wDollcDashs7TX_Entry(lvls7TW);
    }
    public static Closure wDollcDashs7TX_Entry(Closure ws7TZ)
    {
        return cPluss7TF_Entry(ws7TZ, lvls7TY);
    }
    public static Closure lvls7TW_Entry()
    {
        return cfromIntegers7TR_Entry(lvls7Sk);
    }
    public static Closure cfromIntegers7TR_Entry(Closure xs7TS)
    {
        var wilds7TT = GHC.Integer.Type.ltIntegerHash_Entry(xs7TS, lvls7Sj);
        switch (wilds7TT)
        {
            default:
                {
                    var sats7TV = new Updatable<Closure>(&sats7TV_Entry, xs7TS);
                    return new Exp3.S(sats7TV);
                }
            case 1: { return Exp3.z_DataCon.Eval(); }
        }
    }
    public static Closure sats7TV_Entry(in Closure xs7TS)
    {
        var sats7TU = GHC.Integer.Type.minusInteger_Entry(xs7TS, lvls7Sj);
        return cfromIntegers7TR_Entry(sats7TU);
    }
    public static Closure cAstrs7TL_Entry(Closure xs7TM, Closure dss7TN)
    {
        var wilds7TO = dss7TN.Eval();
        switch (wilds7TO)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7TO_Z: { return Exp3.z_DataCon.Eval(); }
            case Exp3.S wilds7TO_S:
                {
                    var ys7TP = wilds7TO_S.x0;
                    var sats7TQ = cAstrs7TL_Entry(xs7TM, ys7TP);
                    return cPluss7TF_Entry(sats7TQ, xs7TM);
                }
        }
    }
    public static Closure cPluss7TF_Entry(Closure dss7TG, Closure ys7TH)
    {
        var wilds7TI = dss7TG.Eval();
        switch (wilds7TI)
        {
            default: { throw new ImpossibleException(); }
            case Exp3.Z wilds7TI_Z: { return ys7TH.Eval(); }
            case Exp3.S wilds7TI_S:
                {
                    var xs7TJ = wilds7TI_S.x0;
                    var sat_Frees7TK = (ys7TH, xs7TJ);
                    var sats7TK = new Updatable<(Closure x0, Closure x1)>(&sats7TK_Entry, sat_Frees7TK);
                    return new Exp3.S(sats7TK);
                }
        }
    }
    public static Closure sats7TK_Entry(in (Closure x0, Closure x1) sat_Frees7TK)
    {
        var ys7TH = sat_Frees7TK.x0;
        var xs7TJ = sat_Frees7TK.x1;
        return cPluss7TF_Entry(xs7TJ, ys7TH);
    }
    public static Closure cabss7TE_Entry()
    {
        throw new System.Exception(lvls7TD);
    }
    public static Closure csignums7TC_Entry()
    {
        throw new System.Exception(lvls7TB);
    }
    
    public static Closure lvls7Sg_Entry()
    {
        var sats7Sh = GHC.CString.unpackCStringHash_Entry(lvls7Sf);
        return GHC.Err.errorWithoutStackTrace_Entry<Closure>(sats7Sh);
    }
    public static Closure sfromIntegrals7Sc_Entry(Closure w2s7Sd)
    {
        var wilds7Se = GHC.Integer.Type.doubleFromInteger_Entry(w2s7Sd);
        return new GHC.Types.DHash(wilds7Se);
    }
    public sealed class S : Data
    {
        public Closure x0;
        public S(Closure x0) { this.x0 = x0; }
        public override int Tag => 2;
    }
    public sealed class Z : Data
    {
        public Z() { }
        public override int Tag => 1;
    }
}
