using Lazer.Runtime;

public unsafe static class Example
{
    public static Function o4_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(o4_DataCon_Entry));
    public static Function o3_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(o3_DataCon_Entry));
    public static Function o2_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(o2_DataCon_Entry));
    public static Function o1_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(o1_DataCon_Entry));
    public static Function o0_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(o0_DataCon_Entry));
    public static Function cColW_DataCon = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cColW_DataCon_Entry));
    public static Function h_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(h_DataCon_Entry));
    public static Example.C c_DataCon = new Example.C();
    public static Example.B b_DataCon = new Example.B();
    public static Example.A a_DataCon = new Example.A();
    public static Thunk pi_ = new Updatable(CLR.LoadFunctionPointer<Closure>(pi__Entry));
    internal static GHC.Integer.Type.SHash lvls6qz = new GHC.Integer.Type.SHash(60);
    internal static GHC.Integer.Type.SHash lvls6qy = new GHC.Integer.Type.SHash(180);
    internal static Function wgs6pW = new Fun(4, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, (Closure x0, Closure x1)>(wgs6pW_Entry));
    internal static GHC.Integer.Type.SHash lvls6pV = new GHC.Integer.Type.SHash(27);
    internal static GHC.Integer.Type.SHash lvls6pU = new GHC.Integer.Type.SHash(12);
    internal static GHC.Integer.Type.SHash lvls6pT = new GHC.Integer.Type.SHash(0);
    internal static GHC.Integer.Type.SHash lvls6pS = new GHC.Integer.Type.SHash(3);
    internal static GHC.Integer.Type.SHash lvls6pR = new GHC.Integer.Type.SHash(10);
    internal static GHC.Integer.Type.SHash lvls6pQ = new GHC.Integer.Type.SHash(5);
    internal static GHC.Integer.Type.SHash lvls6pP = new GHC.Integer.Type.SHash(2);
    public static Function gcd_ = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(gcd__Entry));
    internal static Function wgcd_s6pz = new Fun(2, CLR.LoadFunctionPointer<long, long, long>(wgcd_s6pz_Entry));
    public static Thunk fibs = new Updatable(CLR.LoadFunctionPointer<Closure>(fibs_Entry));
    public static Function fibt = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(fibt_Entry));
    public static Function fiba = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fiba_Entry));
    internal static Function wfibas6pb = new Fun(3, CLR.LoadFunctionPointer<long, long, long, long>(wfibas6pb_Entry));
    public static Function sumFromTo = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(sumFromTo_Entry));
    internal static Function gos6oS = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(gos6oS_Entry));
    internal static Function wgos6oL = new Fun(3, CLR.LoadFunctionPointer<long, long, long, long>(wgos6oL_Entry));
    public static Function main = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(main_Entry));
    internal static Function mains6on = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(mains6on_Entry));
    internal static GHC.Types.Cons lvls6om = new GHC.Types.Cons(GHC.Show.fShowPrOComPrC3r2e, lvls6ok);
    internal static Thunk lvls6ok = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls6ok_Entry));
    internal static string lvls6oj = "sum1";
    internal static GHC.Types.Cons lvls6oi = new GHC.Types.Cons(GHC.Show.fShowPrOComPrC3r2e, lvls6og);
    internal static Thunk lvls6og = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls6og_Entry));
    internal static string lvls6of = "sum2";
    public static Function sum1_ = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(sum1__Entry));
    internal static Function sum1_s6oa = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(sum1_s6oa_Entry));
    internal static Thunk xs6o7 = new Updatable(CLR.LoadFunctionPointer<Closure>(xs6o7_Entry));
    internal static Thunk inf_s6o6 = new Updatable(CLR.LoadFunctionPointer<Closure>(inf_s6o6_Entry));
    public static GHC.Types.Cons inf_ = new GHC.Types.Cons(croots6jk, inf_s6o6);
    public static Function inc_ = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(inc__Entry));
    public static Function inc = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(inc_Entry));
    public static Function sum2_ = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(sum2__Entry));
    internal static Function sum2_s6nU = new Fun(1, CLR.LoadFunctionPointer<GHC.Prim.Void, Closure>(sum2_s6nU_Entry));
    internal static Thunk xs6nR = new Updatable(CLR.LoadFunctionPointer<Closure>(xs6nR_Entry));
    public static Function sum_ = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(sum__Entry));
    internal static Function wsum_s6nG = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(wsum_s6nG_Entry));
    public static Function suma = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(suma_Entry));
    internal static Function wsumas6nr = new Fun(2, CLR.LoadFunctionPointer<Closure, long, long>(wsumas6nr_Entry));
    public static Function facc2 = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(facc2_Entry));
    internal static Function wfacc2s6ng = new Fun(1, CLR.LoadFunctionPointer<long, long>(wfacc2s6ng_Entry));
    public static Function sumfold = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(sumfold_Entry));
    internal static GHC.Types.IHash sumfolds6ne = new GHC.Types.IHash(0);
    public static Function take_ = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(take__Entry));
    internal static Function wtake_s6n0 = new Fun(2, CLR.LoadFunctionPointer<long, Closure, Closure>(wtake_s6n0_Entry));
    public static Function pp = new Fun(2, CLR.LoadFunctionPointer<Closure, GHC.Prim.Void, Closure>(pp_Entry));
    internal static Function pps6mW = new Fun(2, CLR.LoadFunctionPointer<Closure, GHC.Prim.Void, Closure>(pps6mW_Entry));
    public static Example.CColW fWInt = new Example.CColW(GHC.Classes.fEqInt, cidens6jl, croots6jk);
    internal static string tc_Cs6mS = "'C";
    internal static string tc_Bs6mP = "'B";
    internal static string tc_As6mM = "'A";
    internal static string tcLetters6mI = "Letter";
    internal static string tc_Hs6mF = "'H";
    internal static string tcHs6mA = "H";
    internal static string tc_CColWs6mx = "'C:W";
    internal static string tcWs6mq = "W";
    internal static string tc_O4s6mn = "'O4";
    internal static string tc_O3s6mk = "'O3";
    internal static string tc_O2s6mh = "'O2";
    internal static string tc_O1s6me = "'O1";
    internal static string tc_O0s6mb = "'O0";
    internal static string tcOs6m6 = "O";
    internal static GHC.Types.Cons kreps6m4 = new GHC.Types.Cons(kreps6m2, GHC.Types.nil_DataCon);
    internal static string trModules6lW = "Example";
    internal static string trModules6lU = "main";
    public static Function letterChar = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(letterChar_Entry));
    internal static GHC.Types.CHash lvls6lQ = new GHC.Types.CHash(c);
    internal static GHC.Types.CHash lvls6lP = new GHC.Types.CHash(b);
    internal static GHC.Types.CHash lvls6lO = new GHC.Types.CHash(a);
    public static Function wt = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(wt_Entry));
    public static Function test = new Fun(5, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, GHC.Prim.Void, Closure>(test_Entry));
    internal static Function tests6lu = new Fun(5, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, GHC.Prim.Void, Closure>(tests6lu_Entry));
    public static Function tildDollQMark = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(tildDollQMark_Entry));
    public static Example.O1 so1 = new Example.O1(croots6jk);
    public static Function o1 = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(o1_Entry));
    internal static GHC.Integer.Type.SHash lvls6lk = new GHC.Integer.Type.SHash(1);
    public static Function wd = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(wd_Entry));
    public static Function extractO = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(extractO_Entry));
    public static Function foldl_ = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(foldl__Entry));
    public static Function map_ = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(map__Entry));
    public static Function fOrdH = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(fOrdH_Entry));
    internal static Function cmins6kC = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cmins6kC_Entry));
    internal static Function cmaxs6kt = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cmaxs6kt_Entry));
    internal static Function cLtEqs6kk = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cLtEqs6kk_Entry));
    internal static Function cGts6kb = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cGts6kb_Entry));
    internal static Function cGtEqs6k2 = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cGtEqs6k2_Entry));
    internal static Function cLts6jT = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cLts6jT_Entry));
    internal static Function cp1Ords6jQ = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cp1Ords6jQ_Entry));
    public static Function fEqH = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(fEqH_Entry));
    internal static Function cSlshEqs6jD = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cSlshEqs6jD_Entry));
    internal static Function cEqEqs6jv = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(cEqEqs6jv_Entry));
    internal static Function ccompares6jn = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(ccompares6jn_Entry));
    internal static Function cidens6jl = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cidens6jl_Entry));
    internal static GHC.Types.IHash croots6jk = new GHC.Types.IHash(1);
    public static Function p1W = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(p1W_Entry));
    public static Function iden = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(iden_Entry));
    public static Function root = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(root_Entry));
    public static Closure o4_DataCon_Entry(Closure etaB1)
    {
        return new Example.O4(etaB1);
    }
    public static Closure o3_DataCon_Entry(Closure etaB1)
    {
        return new Example.O3(etaB1);
    }
    public static Closure o2_DataCon_Entry(Closure etaB1)
    {
        return new Example.O2(etaB1);
    }
    public static Closure o1_DataCon_Entry(Closure etaB1)
    {
        return new Example.O1(etaB1);
    }
    public static Closure o0_DataCon_Entry(Closure etaB1)
    {
        return new Example.O0(etaB1);
    }
    public static Closure cColW_DataCon_Entry(Closure etaB3, Closure etaB2, Closure etaB1)
    {
        return new Example.CColW(etaB3, etaB2, etaB1);
    }
    public static Closure h_DataCon_Entry(Closure etaB1)
    {
        return new Example.H(etaB1);
    }
    public static Closure pi__Entry()
    {
        var gj_s6qB = wgs6pW_Entry(lvls6lk, lvls6qy, lvls6qz, lvls6pP);
        var gj_s6qB_RawTuple = gj_s6qB;
        var hj_s6qC = gj_s6qB_RawTuple.x0;
        var ij_s6qD = gj_s6qB_RawTuple.x1;
        return new GHC.Types.Cons(hj_s6qC, ij_s6qD);
    }
    public static (Closure x0, Closure x1) wgs6pW_Entry(Closure ws6pX, Closure ws6pY, Closure ws6pZ, Closure ws6q0)
    {
        var xh_s6q1 = new Updatable<Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure>(wgs6pW_xh_s6q1_Entry), ws6pX, ws6pY, ws6pZ, ws6q0);
        var gi_s6qx = new Updatable<Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure>(wgs6pW_gi_s6qx_Entry), ws6pX, ws6pY, ws6pZ, ws6q0, xh_s6q1);
        return (xh_s6q1, gi_s6qx);
    }
    public static Closure wgs6pW_xh_s6q1_Entry(Closure ws6pX, Closure ws6pY, Closure ws6pZ, Closure ws6q0)
    {
        var yh_s6q2 = GHC.Integer.Type.timesInteger_Entry(lvls6pQ, ws6pZ);
        var ai_s6q3 = GHC.Integer.Type.eqIntegerHash_Entry(yh_s6q2, lvls6pT);
        switch (ai_s6q3)
        {
            default:
                {
                    var bi_s6q7 = GHC.Integer.Type.timesInteger_Entry(lvls6pQ, ws6pY);
                    var ci_s6q4 = GHC.Integer.Type.timesInteger_Entry(lvls6pV, ws6q0);
                    var di_s6q5 = GHC.Integer.Type.minusInteger_Entry(ci_s6q4, lvls6pU);
                    var ei_s6q6 = GHC.Integer.Type.timesInteger_Entry(ws6pX, di_s6q5);
                    var fi_s6q8 = GHC.Integer.Type.plusInteger_Entry(ei_s6q6, bi_s6q7);
                    return GHC.Integer.Type.divInteger_Entry(fi_s6q8, yh_s6q2);
                }
            case 1: { return GHC.Real.divZeroError.Eval(); }
        }
    }
    public static Closure wgs6pW_gi_s6qx_Entry(Closure ws6pX, Closure ws6pY, Closure ws6pZ, Closure ws6q0, Closure xh_s6q1)
    {
        var hi_s6q9 = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(gi_s6qx_hi_s6q9_Entry), ws6q0);
        var ni_s6qt = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(gi_s6qx_ni_s6qt_Entry), ws6q0);
        var oi_s6qs = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(gi_s6qx_oi_s6qs_Entry), ws6pZ, hi_s6q9);
        var pi_s6qr = new Updatable<Closure, Closure, Closure, Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure, Closure>(gi_s6qx_pi_s6qr_Entry), ws6pX, ws6pY, ws6pZ, ws6q0, xh_s6q1, hi_s6q9);
        var xi_s6qj = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(gi_s6qx_xi_s6qj_Entry), ws6pX, ws6q0);
        var dj_s6qu = wgs6pW_Entry(xi_s6qj, pi_s6qr, oi_s6qs, ni_s6qt);
        var dj_s6qu_RawTuple = dj_s6qu;
        var ej_s6qv = dj_s6qu_RawTuple.x0;
        var fj_s6qw = dj_s6qu_RawTuple.x1;
        return new GHC.Types.Cons(ej_s6qv, fj_s6qw);
    }
    public static Closure gi_s6qx_hi_s6q9_Entry(Closure ws6q0)
    {
        var ii_s6qd = GHC.Integer.Type.timesInteger_Entry(lvls6pS, ws6q0);
        var ji_s6qe = GHC.Integer.Type.plusInteger_Entry(ii_s6qd, lvls6pP);
        var ki_s6qa = GHC.Integer.Type.timesInteger_Entry(lvls6pS, ws6q0);
        var li_s6qb = GHC.Integer.Type.plusInteger_Entry(ki_s6qa, lvls6lk);
        var mi_s6qc = GHC.Integer.Type.timesInteger_Entry(lvls6pS, li_s6qb);
        return GHC.Integer.Type.timesInteger_Entry(mi_s6qc, ji_s6qe);
    }
    public static Closure gi_s6qx_ni_s6qt_Entry(Closure ws6q0)
    {
        return GHC.Integer.Type.plusInteger_Entry(ws6q0, lvls6lk);
    }
    public static Closure gi_s6qx_oi_s6qs_Entry(Closure ws6pZ, Closure hi_s6q9)
    {
        return GHC.Integer.Type.timesInteger_Entry(ws6pZ, hi_s6q9);
    }
    public static Closure gi_s6qx_pi_s6qr_Entry(Closure ws6pX, Closure ws6pY, Closure ws6pZ, Closure ws6q0, Closure xh_s6q1, Closure hi_s6q9)
    {
        var qi_s6qp = GHC.Integer.Type.timesInteger_Entry(xh_s6q1, ws6pZ);
        var ri_s6ql = GHC.Integer.Type.timesInteger_Entry(lvls6pQ, ws6q0);
        var si_s6qm = GHC.Integer.Type.minusInteger_Entry(ri_s6ql, lvls6pP);
        var ti_s6qn = GHC.Integer.Type.timesInteger_Entry(ws6pX, si_s6qm);
        var ui_s6qo = GHC.Integer.Type.plusInteger_Entry(ti_s6qn, ws6pY);
        var vi_s6qq = GHC.Integer.Type.minusInteger_Entry(ui_s6qo, qi_s6qp);
        var wi_s6qk = GHC.Integer.Type.timesInteger_Entry(lvls6pR, hi_s6q9);
        return GHC.Integer.Type.timesInteger_Entry(wi_s6qk, vi_s6qq);
    }
    public static Closure gi_s6qx_xi_s6qj_Entry(Closure ws6pX, Closure ws6q0)
    {
        var yi_s6qh = GHC.Integer.Type.timesInteger_Entry(lvls6pP, ws6q0);
        var aj_s6qi = GHC.Integer.Type.minusInteger_Entry(yi_s6qh, lvls6lk);
        var bj_s6qf = GHC.Integer.Type.timesInteger_Entry(lvls6pR, ws6pX);
        var cj_s6qg = GHC.Integer.Type.timesInteger_Entry(bj_s6qf, ws6q0);
        return GHC.Integer.Type.timesInteger_Entry(cj_s6qg, aj_s6qi);
    }
    public static Closure gcd__Entry(Closure ws6pI, Closure ws6pJ)
    {
        var sh_s6pK = ws6pI;
        sh_s6pK = sh_s6pK.Eval();
        var sh_s6pK_IHash = sh_s6pK as GHC.Types.IHash;
        var th_s6pL = sh_s6pK_IHash.x0;
        var uh_s6pM = ws6pJ;
        uh_s6pM = uh_s6pM.Eval();
        var uh_s6pM_IHash = uh_s6pM as GHC.Types.IHash;
        var vh_s6pN = uh_s6pM_IHash.x0;
        var wh_s6pO = wgcd_s6pz_Entry(th_s6pL, vh_s6pN);
        return new GHC.Types.IHash(wh_s6pO);
    }
    public static long wgcd_s6pz_Entry(long wws6pA, long wws6pB)
    {
        var nh_s6pC = wws6pA;
        switch (nh_s6pC)
        {
            default:
                {
                    var oh_s6pD = wws6pB;
                    switch (oh_s6pD)
                    {
                        default:
                            {
                                var ph_s6pE = (nh_s6pC > oh_s6pD) ? 1 : 0;
                                switch (ph_s6pE)
                                {
                                    default:
                                        {
                                            var qh_s6pF = oh_s6pD - nh_s6pC;
                                            return wgcd_s6pz_Entry(nh_s6pC, qh_s6pF);
                                        }
                                    case 1:
                                        {
                                            var rh_s6pG = nh_s6pC - oh_s6pD;
                                            return wgcd_s6pz_Entry(rh_s6pG, oh_s6pD);
                                        }
                                }
                            }
                        case 0: { return nh_s6pC; }
                    }
                }
            case 0: { return wws6pB; }
        }
    }
    public static Closure fibs_Entry()
    {
        return map__Entry(Example.fibt, Example.inf_);
    }
    public static Closure fibt_Entry(Closure ws6pu)
    {
        var kh_s6pv = ws6pu;
        kh_s6pv = kh_s6pv.Eval();
        var kh_s6pv_IHash = kh_s6pv as GHC.Types.IHash;
        var lh_s6pw = kh_s6pv_IHash.x0;
        var mh_s6px = wfibas6pb_Entry(0, 1, lh_s6pw);
        return new GHC.Types.IHash(mh_s6px);
    }
    public static Closure fiba_Entry(Closure ws6pj, Closure ws6pk, Closure ws6pl)
    {
        var dh_s6pm = ws6pj;
        dh_s6pm = dh_s6pm.Eval();
        var dh_s6pm_IHash = dh_s6pm as GHC.Types.IHash;
        var eh_s6pn = dh_s6pm_IHash.x0;
        var fh_s6po = ws6pk;
        fh_s6po = fh_s6po.Eval();
        var fh_s6po_IHash = fh_s6po as GHC.Types.IHash;
        var gh_s6pp = fh_s6po_IHash.x0;
        var hh_s6pq = ws6pl;
        hh_s6pq = hh_s6pq.Eval();
        var hh_s6pq_IHash = hh_s6pq as GHC.Types.IHash;
        var ih_s6pr = hh_s6pq_IHash.x0;
        var jh_s6ps = wfibas6pb_Entry(eh_s6pn, gh_s6pp, ih_s6pr);
        return new GHC.Types.IHash(jh_s6ps);
    }
    public static long wfibas6pb_Entry(long wws6pc, long wws6pd, long wws6pe)
    {
        var ah_s6pf = (wws6pe <= 0) ? 1 : 0;
        switch (ah_s6pf)
        {
            default:
                {
                    var bh_s6ph = wws6pe - 1;
                    var ch_s6pg = wws6pc + wws6pd;
                    return wfibas6pb_Entry(wws6pd, ch_s6pg, bh_s6ph);
                }
            case 1: { return wws6pc; }
        }
    }
    public static Closure sumFromTo_Entry(Closure froms6p4, Closure tos6p5)
    {
        var ug_s6p6 = froms6p4;
        ug_s6p6 = ug_s6p6.Eval();
        var ug_s6p6_IHash = ug_s6p6 as GHC.Types.IHash;
        var vg_s6p7 = ug_s6p6_IHash.x0;
        var wg_s6p8 = tos6p5;
        wg_s6p8 = wg_s6p8.Eval();
        var wg_s6p8_IHash = wg_s6p8 as GHC.Types.IHash;
        var xg_s6p9 = wg_s6p8_IHash.x0;
        var yg_s6pa = wgos6oL_Entry(vg_s6p7, xg_s6p9, 0);
        return new GHC.Types.IHash(yg_s6pa);
    }
    public static Closure gos6oS_Entry(Closure ws6oT, Closure ws6oU, Closure ws6oV)
    {
        var ng_s6oW = ws6oT;
        ng_s6oW = ng_s6oW.Eval();
        var ng_s6oW_IHash = ng_s6oW as GHC.Types.IHash;
        var og_s6oX = ng_s6oW_IHash.x0;
        var pg_s6oY = ws6oU;
        pg_s6oY = pg_s6oY.Eval();
        var pg_s6oY_IHash = pg_s6oY as GHC.Types.IHash;
        var qg_s6oZ = pg_s6oY_IHash.x0;
        var rg_s6p0 = ws6oV;
        rg_s6p0 = rg_s6p0.Eval();
        var rg_s6p0_IHash = rg_s6p0 as GHC.Types.IHash;
        var sg_s6p1 = rg_s6p0_IHash.x0;
        var tg_s6p2 = wgos6oL_Entry(og_s6oX, qg_s6oZ, sg_s6p1);
        return new GHC.Types.IHash(tg_s6p2);
    }
    public static long wgos6oL_Entry(long wws6oM, long wws6oN, long wws6oO)
    {
        var kg_s6oP = (wws6oM > wws6oN) ? 1 : 0;
        switch (kg_s6oP)
        {
            default:
                {
                    var lg_s6oR = wws6oO + wws6oM;
                    var mg_s6oQ = wws6oM + 1;
                    return wgos6oL_Entry(mg_s6oQ, wws6oN, lg_s6oR);
                }
            case 1: { return wws6oO; }
        }
    }
    public static Closure main_Entry(GHC.Prim.Void void0E)
    {
        return mains6on_Entry(GHC.Prim.voidHash);
    }
    public static Closure mains6on_Entry(GHC.Prim.Void void0E)
    {
        var rf_s6op = GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, lvls6om, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
        rf_s6op = rf_s6op.Eval();
        var sf_s6or = rf_s6op;
        var tf_s6os = xs6o7;
        tf_s6os = tf_s6os.Eval();
        var tf_s6os_IHash = tf_s6os as GHC.Types.IHash;
        var uf_s6ot = tf_s6os_IHash.x0;
        var vf_s6ox = new SingleEntry<long>(CLR.LoadFunctionPointer<long, Closure>(mains6on_vf_s6ox_Entry), uf_s6ot);
        var ag_s6oy = GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, vf_s6ox, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
        ag_s6oy = ag_s6oy.Eval();
        var bg_s6oA = ag_s6oy;
        var cg_s6oB = GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, lvls6oi, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
        cg_s6oB = cg_s6oB.Eval();
        var dg_s6oD = cg_s6oB;
        var eg_s6oE = xs6nR;
        eg_s6oE = eg_s6oE.Eval();
        var eg_s6oE_IHash = eg_s6oE as GHC.Types.IHash;
        var fg_s6oF = eg_s6oE_IHash.x0;
        var gg_s6oJ = new SingleEntry<long>(CLR.LoadFunctionPointer<long, Closure>(mains6on_gg_s6oJ_Entry), fg_s6oF);
        return GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, gg_s6oJ, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
    }
    public static Closure mains6on_vf_s6ox_Entry(long uf_s6ot)
    {
        var wf_s6ou = GHC.Show.wshowSignedIntr2b_Entry(0, uf_s6ot, GHC.Types.nil_DataCon);
        var wf_s6ou_RawTuple = wf_s6ou;
        var xf_s6ov = wf_s6ou_RawTuple.x0;
        var yf_s6ow = wf_s6ou_RawTuple.x1;
        return new GHC.Types.Cons(xf_s6ov, yf_s6ow);
    }
    public static Closure mains6on_gg_s6oJ_Entry(long fg_s6oF)
    {
        var hg_s6oG = GHC.Show.wshowSignedIntr2b_Entry(0, fg_s6oF, GHC.Types.nil_DataCon);
        var hg_s6oG_RawTuple = hg_s6oG;
        var ig_s6oH = hg_s6oG_RawTuple.x0;
        var jg_s6oI = hg_s6oG_RawTuple.x1;
        return new GHC.Types.Cons(ig_s6oH, jg_s6oI);
    }
    public static Closure lvls6ok_Entry()
    {
        var qf_s6ol = GHC.CString.unpackCStringHash_Entry(lvls6oj);
        return GHC.Show.showLitString_Entry(qf_s6ol).Apply<Closure, Closure>(GHC.Show.fShowBrOBrC1r2j);
    }
    public static Closure lvls6og_Entry()
    {
        var pf_s6oh = GHC.CString.unpackCStringHash_Entry(lvls6of);
        return GHC.Show.showLitString_Entry(pf_s6oh).Apply<Closure, Closure>(GHC.Show.fShowBrOBrC1r2j);
    }
    public static Closure sum1__Entry(GHC.Prim.Void void0E)
    {
        return sum1_s6oa_Entry(GHC.Prim.voidHash);
    }
    public static Closure sum1_s6oa_Entry(GHC.Prim.Void void0E)
    {
        var nf_s6oc = xs6o7;
        nf_s6oc = nf_s6oc.Eval();
        var nf_s6oc_IHash = nf_s6oc as GHC.Types.IHash;
        var of_s6od = nf_s6oc_IHash.x0; return nf_s6oc;
    }
    public static Closure xs6o7_Entry()
    {
        var lf_s6o8 = wtake_s6n0_Entry(100000, Example.inf_);
        var mf_s6o9 = wsum_s6nG_Entry(lf_s6o8);
        return new GHC.Types.IHash(mf_s6o9);
    }
    public static Closure inf_s6o6_Entry()
    {
        return map__Entry(Example.inc, Example.inf_);
    }
    public static Closure inc__Entry(Closure etaB1)
    {
        return map__Entry(Example.inc, etaB1);
    }
    public static Closure inc_Entry(Closure ds1s6o0)
    {
        var if_s6o1 = ds1s6o0;
        if_s6o1 = if_s6o1.Eval();
        var if_s6o1_IHash = if_s6o1 as GHC.Types.IHash;
        var jf_s6o2 = if_s6o1_IHash.x0;
        var kf_s6o3 = 1 + jf_s6o2; return new GHC.Types.IHash(kf_s6o3);
    }
    public static Closure sum2__Entry(GHC.Prim.Void void0E)
    {
        return sum2_s6nU_Entry(GHC.Prim.voidHash);
    }
    public static Closure sum2_s6nU_Entry(GHC.Prim.Void void0E)
    {
        var gf_s6nW = xs6nR;
        gf_s6nW = gf_s6nW.Eval();
        var gf_s6nW_IHash = gf_s6nW as GHC.Types.IHash;
        var hf_s6nX = gf_s6nW_IHash.x0; return gf_s6nW;
    }
    public static Closure xs6nR_Entry()
    {
        var ef_s6nS = GHC.Enum.eftInt_Entry(1, 100000);
        var ff_s6nT = wsum_s6nG_Entry(ef_s6nS);
        return new GHC.Types.IHash(ff_s6nT);
    }
    public static Closure sum__Entry(Closure ws6nP)
    {
        var df_s6nQ = wsum_s6nG_Entry(ws6nP);
        return new GHC.Types.IHash(df_s6nQ);
    }
    public static long wsum_s6nG_Entry(Closure ws6nH)
    {
        var we_s6nI = ws6nH;
        we_s6nI = we_s6nI.Eval();
        switch (we_s6nI)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil we_s6nI_Nil: { return 0; }
            case GHC.Types.Cons we_s6nI_Cons:
                {
                    var xe_s6nJ = we_s6nI_Cons.x0;
                    var ye_s6nK = we_s6nI_Cons.x1;
                    var af_s6nL = xe_s6nJ;
                    af_s6nL = af_s6nL.Eval();
                    var af_s6nL_IHash = af_s6nL as GHC.Types.IHash;
                    var bf_s6nM = af_s6nL_IHash.x0;
                    var cf_s6nN = wsum_s6nG_Entry(ye_s6nK);
                    return bf_s6nM + cf_s6nN;
                }
        }
    }
    public static Closure suma_Entry(Closure ws6nB, Closure ws6nC)
    {
        var te_s6nD = ws6nC;
        te_s6nD = te_s6nD.Eval();
        var te_s6nD_IHash = te_s6nD as GHC.Types.IHash;
        var ue_s6nE = te_s6nD_IHash.x0;
        var ve_s6nF = wsumas6nr_Entry(ws6nB, ue_s6nE);
        return new GHC.Types.IHash(ve_s6nF);
    }
    public static long wsumas6nr_Entry(Closure ws6ns, long wws6nt)
    {
        var ne_s6nu = ws6ns;
        ne_s6nu = ne_s6nu.Eval();
        switch (ne_s6nu)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil ne_s6nu_Nil: { return wws6nt; }
            case GHC.Types.Cons ne_s6nu_Cons:
                {
                    var oe_s6nv = ne_s6nu_Cons.x0;
                    var pe_s6nw = ne_s6nu_Cons.x1;
                    var qe_s6nx = oe_s6nv;
                    qe_s6nx = qe_s6nx.Eval();
                    var qe_s6nx_IHash = qe_s6nx as GHC.Types.IHash;
                    var re_s6ny = qe_s6nx_IHash.x0;
                    var se_s6nz = re_s6ny + wws6nt;
                    return wsumas6nr_Entry(pe_s6nw, se_s6nz);
                }
        }
    }
    public static Closure facc2_Entry(Closure ws6nn)
    {
        var ke_s6no = ws6nn;
        ke_s6no = ke_s6no.Eval();
        var ke_s6no_IHash = ke_s6no as GHC.Types.IHash;
        var le_s6np = ke_s6no_IHash.x0;
        var me_s6nq = wfacc2s6ng_Entry(le_s6np);
        return new GHC.Types.IHash(me_s6nq);
    }
    public static long wfacc2s6ng_Entry(long wws6nh)
    {
        var ge_s6ni = (wws6nh <= 1) ? 1 : 0;
        switch (ge_s6ni)
        {
            default:
                {
                    var he_s6nj = wws6nh - 1;
                    var ie_s6nk = wfacc2s6ng_Entry(he_s6nj);
                    var je_s6nl = wws6nh * ie_s6nk; return je_s6nl + 1;
                }
            case 1: { return 2; }
        }
    }
    public static Closure sumfold_Entry(Closure etaB1)
    {
        return foldl__Entry(GHC.Num.fNumInt_DollcPlusr2x, sumfolds6ne, etaB1);
    }
    public static Closure take__Entry(Closure ws6na, Closure ws6nb)
    {
        var ee_s6nc = ws6na;
        ee_s6nc = ee_s6nc.Eval();
        var ee_s6nc_IHash = ee_s6nc as GHC.Types.IHash;
        var fe_s6nd = ee_s6nc_IHash.x0;
        return wtake_s6n0_Entry(fe_s6nd, ws6nb);
    }
    public static Closure wtake_s6n0_Entry(long wws6n1, Closure ws6n2)
    {
        var xd_s6n3 = wws6n1;
        switch (xd_s6n3)
        {
            default:
                {
                    var yd_s6n4 = ws6n2;
                    yd_s6n4 = yd_s6n4.Eval();
                    switch (yd_s6n4)
                    {
                        default: { throw new ImpossibleException(); }
                        case GHC.Types.Nil yd_s6n4_Nil:
                            {
                                return GHC.Types.nil_DataCon.Eval();
                            }
                        case GHC.Types.Cons yd_s6n4_Cons:
                            {
                                var ae_s6n5 = yd_s6n4_Cons.x0;
                                var be_s6n6 = yd_s6n4_Cons.x1;
                                var ce_s6n8 = new Updatable<long, Closure>(CLR.LoadFunctionPointer<long, Closure, Closure>(wtake_s6n0_ce_s6n8_Entry), xd_s6n3, be_s6n6);
                                return new GHC.Types.Cons(ae_s6n5, ce_s6n8);
                            }
                    }
                }
            case 0: { return GHC.Types.nil_DataCon.Eval(); }
        }
    }
    public static Closure wtake_s6n0_ce_s6n8_Entry(long xd_s6n3, Closure be_s6n6)
    {
        var de_s6n7 = xd_s6n3 - 1;
        return wtake_s6n0_Entry(de_s6n7, be_s6n6);
    }
    public static Closure pp_Entry(Closure etaB2, GHC.Prim.Void void0E)
    {
        return pps6mW_Entry(etaB2, GHC.Prim.voidHash);
    }
    public static Closure pps6mW_Entry(Closure dss6mX, GHC.Prim.Void void0E)
    {
        return croots6jk;
    }
    public static Closure letterChar_Entry(Closure dss6lS)
    {
        var wd_s6lT = dss6lS;
        wd_s6lT = wd_s6lT.Eval();
        var wd_s6lTTags6lT = wd_s6lT.Tag;
        switch (wd_s6lTTags6lT)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var wd_s6lT_A = wd_s6lT as Example.A; return lvls6lO.Eval();
                }
            case 2:
                {
                    var wd_s6lT_B = wd_s6lT as Example.B; return lvls6lP.Eval();
                }
            case 3:
                {
                    var wd_s6lT_C = wd_s6lT as Example.C; return lvls6lQ.Eval();
                }
        }
    }
    public static Closure wt_Entry(Closure dWs6lK, Closure dss6lL)
    {
        var ud_s6lM = dss6lL;
        ud_s6lM = ud_s6lM.Eval();
        var ud_s6lMTags6lM = ud_s6lM.Tag;
        switch (ud_s6lMTags6lM)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var ud_s6lM_Unit = ud_s6lM as GHC.Tuple.Unit;
                    var vd_s6lN = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(wt_vd_s6lN_Entry), dWs6lK);
                    return Example.iden_Entry(dWs6lK, vd_s6lN);
                }
        }
    }
    public static Closure wt_vd_s6lN_Entry(Closure dWs6lK)
    {
        return Example.root_Entry(dWs6lK);
    }
    public static Closure test_Entry(Closure etaB5, Closure etaB4, Closure etaB3, Closure etaB2, GHC.Prim.Void void0E)
    {
        return tests6lu_Entry(etaB5, etaB4, etaB3, etaB2, GHC.Prim.voidHash);
    }
    public static Closure tests6lu_Entry(Closure dShows6lv, Closure dShows6lw, Closure texts6lx, Closure ms6ly, GHC.Prim.Void void0E)
    {
        var od_s6lA = new SingleEntry<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(tests6lu_od_s6lA_Entry), dShows6lv, texts6lx);
        var pd_s6lB = GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, od_s6lA, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
        pd_s6lB = pd_s6lB.Eval();
        var qd_s6lD = pd_s6lB;
        var rd_s6lE = ms6ly.Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
        var sd_s6lG = rd_s6lE;
        var td_s6lH = new SingleEntry<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(tests6lu_td_s6lH_Entry), dShows6lw, sd_s6lG);
        return GHC.IO.Handle.Text.hPutStr__Entry(GHC.IO.Handle.FD.stdout, td_s6lH, GHC.Types.true_DataCon).Apply<GHC.Prim.Void, Closure>(GHC.Prim.voidHash);
    }
    public static Closure tests6lu_od_s6lA_Entry(Closure dShows6lv, Closure texts6lx)
    {
        return GHC.Show.show_Entry(dShows6lv, texts6lx);
    }
    public static Closure tests6lu_td_s6lH_Entry(Closure dShows6lw, Closure sd_s6lG)
    {
        return GHC.Show.show_Entry(dShows6lw, sd_s6lG);
    }
    public static Closure tildDollQMark_Entry(Closure dNums6lr, Closure dss6ls)
    {
        var nd_s6lt = dss6ls;
        nd_s6lt = nd_s6lt.Eval();
        var nd_s6ltTags6lt = nd_s6lt.Tag;
        switch (nd_s6ltTags6lt)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var nd_s6lt_Unit = nd_s6lt as GHC.Tuple.Unit;
                    return GHC.Num.fromInteger_Entry(dNums6lr, lvls6lk);
                }
        }
    }
    public static Closure o1_Entry(Closure dNums6lm, Closure prods6ln)
    {
        var md_s6lo = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(o1_md_s6lo_Entry), dNums6lm);
        return prods6ln.Apply<Closure, Closure>(md_s6lo);
    }
    public static Closure o1_md_s6lo_Entry(Closure dNums6lm)
    {
        return GHC.Num.fromInteger_Entry(dNums6lm, lvls6lk);
    }
    public static Closure wd_Entry(Closure etaB1)
    {
        return Data.OldList.words_Entry(etaB1);
    }
    public static Closure extractO_Entry(Closure os6lc)
    {
        var gd_s6ld = os6lc;
        gd_s6ld = gd_s6ld.Eval();
        var gd_s6ldTags6ld = gd_s6ld.Tag;
        switch (gd_s6ldTags6ld)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var gd_s6ld_O0 = gd_s6ld as Example.O0;
                    var hd_s6le = gd_s6ld_O0.x0; return hd_s6le.Eval();
                }
            case 2:
                {
                    var gd_s6ld_O1 = gd_s6ld as Example.O1;
                    var id_s6lf = gd_s6ld_O1.x0; return id_s6lf.Eval();
                }
            case 3:
                {
                    var gd_s6ld_O2 = gd_s6ld as Example.O2;
                    var jd_s6lg = gd_s6ld_O2.x0; return jd_s6lg.Eval();
                }
            case 4:
                {
                    var gd_s6ld_O3 = gd_s6ld as Example.O3;
                    var kd_s6lh = gd_s6ld_O3.x0; return kd_s6lh.Eval();
                }
            case 5:
                {
                    var gd_s6ld_O4 = gd_s6ld as Example.O4;
                    var ld_s6li = gd_s6ld_O4.x0; return ld_s6li.Eval();
                }
        }
    }
    public static Closure foldl__Entry(Closure fs6l4, Closure x0s6l5, Closure dss6l6)
    {
        var cd_s6l7 = dss6l6;
        cd_s6l7 = cd_s6l7.Eval();
        switch (cd_s6l7)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil cd_s6l7_Nil: { return x0s6l5.Eval(); }
            case GHC.Types.Cons cd_s6l7_Cons:
                {
                    var dd_s6l8 = cd_s6l7_Cons.x0;
                    var ed_s6l9 = cd_s6l7_Cons.x1;
                    var fd_s6la = new Updatable<Closure, Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(foldl__fd_s6la_Entry), fs6l4, x0s6l5, dd_s6l8);
                    return foldl__Entry(fs6l4, fd_s6la, ed_s6l9);
                }
        }
    }
    public static Closure foldl__fd_s6la_Entry(Closure fs6l4, Closure x0s6l5, Closure dd_s6l8)
    {
        return fs6l4.Apply<Closure, Closure, Closure>(x0s6l5, dd_s6l8);
    }
    public static Closure map__Entry(Closure fs6kW, Closure dss6kX)
    {
        var wc_s6kY = dss6kX;
        wc_s6kY = wc_s6kY.Eval();
        switch (wc_s6kY)
        {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wc_s6kY_Nil:
                {
                    return GHC.Types.nil_DataCon.Eval();
                }
            case GHC.Types.Cons wc_s6kY_Cons:
                {
                    var xc_s6kZ = wc_s6kY_Cons.x0;
                    var yc_s6l0 = wc_s6kY_Cons.x1;
                    var ad_s6l2 = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(map__ad_s6l2_Entry), fs6kW, yc_s6l0);
                    var bd_s6l1 = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(map__bd_s6l1_Entry), fs6kW, xc_s6kZ);
                    return new GHC.Types.Cons(bd_s6l1, ad_s6l2);
                }
        }
    }
    public static Closure map__ad_s6l2_Entry(Closure fs6kW, Closure yc_s6l0)
    {
        return map__Entry(fs6kW, yc_s6l0);
    }
    public static Closure map__bd_s6l1_Entry(Closure fs6kW, Closure xc_s6kZ)
    {
        return fs6kW.Apply<Closure, Closure>(xc_s6kZ);
    }
    public static Closure fOrdH_Entry(Closure dOrds6kM)
    {
        var ac_s6kU = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_ac_s6kU_Entry), dOrds6kM);
        var dc_s6kT = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_dc_s6kT_Entry), dOrds6kM);
        var gc_s6kS = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_gc_s6kS_Entry), dOrds6kM);
        var jc_s6kR = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_jc_s6kR_Entry), dOrds6kM);
        var mc_s6kQ = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_mc_s6kQ_Entry), dOrds6kM);
        var pc_s6kP = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_pc_s6kP_Entry), dOrds6kM);
        var sc_s6kO = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fOrdH_sc_s6kO_Entry), dOrds6kM);
        var vc_s6kN = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(fOrdH_vc_s6kN_Entry), dOrds6kM);
        return new GHC.Classes.CColOrd(vc_s6kN, sc_s6kO, pc_s6kP, mc_s6kQ, jc_s6kR, gc_s6kS, dc_s6kT, ac_s6kU);
    }
    public static Closure fOrdH_ac_s6kU_Entry(Closure dOrds6kM, Closure bc_B2, Closure cc_B1)
    {
        return cmins6kC_Entry(dOrds6kM, bc_B2, cc_B1);
    }
    public static Closure fOrdH_dc_s6kT_Entry(Closure dOrds6kM, Closure ec_B2, Closure fc_B1)
    {
        return cmaxs6kt_Entry(dOrds6kM, ec_B2, fc_B1);
    }
    public static Closure fOrdH_gc_s6kS_Entry(Closure dOrds6kM, Closure hc_B2, Closure ic_B1)
    {
        return cGtEqs6k2_Entry(dOrds6kM, hc_B2, ic_B1);
    }
    public static Closure fOrdH_jc_s6kR_Entry(Closure dOrds6kM, Closure kc_B2, Closure lc_B1)
    {
        return cGts6kb_Entry(dOrds6kM, kc_B2, lc_B1);
    }
    public static Closure fOrdH_mc_s6kQ_Entry(Closure dOrds6kM, Closure nc_B2, Closure oc_B1)
    {
        return cLtEqs6kk_Entry(dOrds6kM, nc_B2, oc_B1);
    }
    public static Closure fOrdH_pc_s6kP_Entry(Closure dOrds6kM, Closure qc_B2, Closure rc_B1)
    {
        return cLts6jT_Entry(dOrds6kM, qc_B2, rc_B1);
    }
    public static Closure fOrdH_sc_s6kO_Entry(Closure dOrds6kM, Closure tc_B2, Closure uc_B1)
    {
        return ccompares6jn_Entry(dOrds6kM, tc_B2, uc_B1);
    }
    public static Closure fOrdH_vc_s6kN_Entry(Closure dOrds6kM)
    {
        return cp1Ords6jQ_Entry(dOrds6kM);
    }
    public static Closure cmins6kC_Entry(Closure dOrds6kD, Closure xs6kE, Closure ys6kF)
    {
        var ub_s6kG = xs6kE;
        ub_s6kG = ub_s6kG.Eval();
        var ub_s6kG_H = ub_s6kG as Example.H;
        var vb_s6kH = ub_s6kG_H.x0;
        var wb_s6kI = ys6kF;
        wb_s6kI = wb_s6kI.Eval();
        var wb_s6kI_H = wb_s6kI as Example.H;
        var xb_s6kJ = wb_s6kI_H.x0;
        var yb_s6kK = GHC.Classes.compare_Entry(dOrds6kD, vb_s6kH, xb_s6kJ);
        var yb_s6kKTags6kK = yb_s6kK.Tag;
        switch (yb_s6kKTags6kK)
        {
            default: { return ub_s6kG.Eval(); }
            case 3:
                {
                    var yb_s6kK_GT = yb_s6kK as GHC.Types.GT; return wb_s6kI.Eval();
                }
        }
    }
    public static Closure cmaxs6kt_Entry(Closure dOrds6ku, Closure xs6kv, Closure ys6kw)
    {
        var pb_s6kx = xs6kv;
        pb_s6kx = pb_s6kx.Eval();
        var pb_s6kx_H = pb_s6kx as Example.H;
        var qb_s6ky = pb_s6kx_H.x0;
        var rb_s6kz = ys6kw;
        rb_s6kz = rb_s6kz.Eval();
        var rb_s6kz_H = rb_s6kz as Example.H;
        var sb_s6kA = rb_s6kz_H.x0;
        var tb_s6kB = GHC.Classes.compare_Entry(dOrds6ku, qb_s6ky, sb_s6kA);
        var tb_s6kBTags6kB = tb_s6kB.Tag;
        switch (tb_s6kBTags6kB)
        {
            default: { return rb_s6kz.Eval(); }
            case 3:
                {
                    var tb_s6kB_GT = tb_s6kB as GHC.Types.GT; return pb_s6kx.Eval();
                }
        }
    }
    public static Closure cLtEqs6kk_Entry(Closure dOrds6kl, Closure xs6km, Closure ys6kn)
    {
        var kb_s6ko = xs6km;
        kb_s6ko = kb_s6ko.Eval();
        var kb_s6ko_H = kb_s6ko as Example.H;
        var lb_s6kp = kb_s6ko_H.x0;
        var mb_s6kq = ys6kn;
        mb_s6kq = mb_s6kq.Eval();
        var mb_s6kq_H = mb_s6kq as Example.H;
        var nb_s6kr = mb_s6kq_H.x0;
        var ob_s6ks = GHC.Classes.compare_Entry(dOrds6kl, lb_s6kp, nb_s6kr);
        var ob_s6ksTags6ks = ob_s6ks.Tag;
        switch (ob_s6ksTags6ks)
        {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 3:
                {
                    var ob_s6ks_GT = ob_s6ks as GHC.Types.GT;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cGts6kb_Entry(Closure dOrds6kc, Closure xs6kd, Closure ys6ke)
    {
        var fb_s6kf = xs6kd;
        fb_s6kf = fb_s6kf.Eval();
        var fb_s6kf_H = fb_s6kf as Example.H;
        var gb_s6kg = fb_s6kf_H.x0;
        var hb_s6kh = ys6ke;
        hb_s6kh = hb_s6kh.Eval();
        var hb_s6kh_H = hb_s6kh as Example.H;
        var ib_s6ki = hb_s6kh_H.x0;
        var jb_s6kj = GHC.Classes.compare_Entry(dOrds6kc, gb_s6kg, ib_s6ki);
        var jb_s6kjTags6kj = jb_s6kj.Tag;
        switch (jb_s6kjTags6kj)
        {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 3:
                {
                    var jb_s6kj_GT = jb_s6kj as GHC.Types.GT;
                    return GHC.Types.true_DataCon.Eval();
                }
        }
    }
    public static Closure cGtEqs6k2_Entry(Closure dOrds6k3, Closure xs6k4, Closure ys6k5)
    {
        var z_s6k6 = xs6k4;
        z_s6k6 = z_s6k6.Eval();
        var z_s6k6_H = z_s6k6 as Example.H;
        var bb_s6k7 = z_s6k6_H.x0;
        var cb_s6k8 = ys6k5;
        cb_s6k8 = cb_s6k8.Eval();
        var cb_s6k8_H = cb_s6k8 as Example.H;
        var db_s6k9 = cb_s6k8_H.x0;
        var eb_s6ka = GHC.Classes.compare_Entry(dOrds6k3, bb_s6k7, db_s6k9);
        var eb_s6kaTags6ka = eb_s6ka.Tag;
        switch (eb_s6kaTags6ka)
        {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 1:
                {
                    var eb_s6ka_LT = eb_s6ka as GHC.Types.LT;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cLts6jT_Entry(Closure dOrds6jU, Closure xs6jV, Closure ys6jW)
    {
        var u_s6jX = xs6jV;
        u_s6jX = u_s6jX.Eval();
        var u_s6jX_H = u_s6jX as Example.H;
        var v_s6jY = u_s6jX_H.x0;
        var w_s6jZ = ys6jW;
        w_s6jZ = w_s6jZ.Eval();
        var w_s6jZ_H = w_s6jZ as Example.H;
        var x_s6k0 = w_s6jZ_H.x0;
        var y_s6k1 = GHC.Classes.compare_Entry(dOrds6jU, v_s6jY, x_s6k0);
        var y_s6k1Tags6k1 = y_s6k1.Tag;
        switch (y_s6k1Tags6k1)
        {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 1:
                {
                    var y_s6k1_LT = y_s6k1 as GHC.Types.LT;
                    return GHC.Types.true_DataCon.Eval();
                }
        }
    }
    public static Closure cp1Ords6jQ_Entry(Closure dOrds6jR)
    {
        var t_s6jS = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(cp1Ords6jQ_t_s6jS_Entry), dOrds6jR);
        return fEqH_Entry(t_s6jS);
    }
    public static Closure cp1Ords6jQ_t_s6jS_Entry(Closure dOrds6jR)
    {
        return GHC.Classes.p1Ord_Entry(dOrds6jR);
    }
    public static Closure fEqH_Entry(Closure dEqs6jN)
    {
        var n_s6jP = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fEqH_n_s6jP_Entry), dEqs6jN);
        var q_s6jO = new Fun<Closure>(2, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(fEqH_q_s6jO_Entry), dEqs6jN);
        return new GHC.Classes.CColEq(q_s6jO, n_s6jP);
    }
    public static Closure fEqH_n_s6jP_Entry(Closure dEqs6jN, Closure o_B2, Closure p_B1)
    {
        return cSlshEqs6jD_Entry(dEqs6jN, o_B2, p_B1);
    }
    public static Closure fEqH_q_s6jO_Entry(Closure dEqs6jN, Closure r_B2, Closure s_B1)
    {
        return cEqEqs6jv_Entry(dEqs6jN, r_B2, s_B1);
    }
    public static Closure cSlshEqs6jD_Entry(Closure dEqs6jE, Closure etas6jF, Closure etas6jG)
    {
        var i_s6jH = etas6jF;
        i_s6jH = i_s6jH.Eval();
        var i_s6jH_H = i_s6jH as Example.H;
        var j_s6jI = i_s6jH_H.x0;
        var k_s6jJ = etas6jG;
        k_s6jJ = k_s6jJ.Eval();
        var k_s6jJ_H = k_s6jJ as Example.H;
        var l_s6jK = k_s6jJ_H.x0;
        var m_s6jL = GHC.Classes.eqEq_Entry(dEqs6jE, j_s6jI, l_s6jK);
        var m_s6jLTags6jL = m_s6jL.Tag;
        switch (m_s6jLTags6jL)
        {
            default: { throw new ImpossibleException(); }
            case 1:
                {
                    var m_s6jL_False = m_s6jL as GHC.Types.False;
                    return GHC.Types.true_DataCon.Eval();
                }
            case 2:
                {
                    var m_s6jL_True = m_s6jL as GHC.Types.True;
                    return GHC.Types.false_DataCon.Eval();
                }
        }
    }
    public static Closure cEqEqs6jv_Entry(Closure dEqs6jw, Closure dss6jx, Closure dss6jy)
    {
        var e_s6jz = dss6jx;
        e_s6jz = e_s6jz.Eval();
        var e_s6jz_H = e_s6jz as Example.H;
        var f_s6jA = e_s6jz_H.x0;
        var g_s6jB = dss6jy;
        g_s6jB = g_s6jB.Eval();
        var g_s6jB_H = g_s6jB as Example.H;
        var h_s6jC = g_s6jB_H.x0;
        return GHC.Classes.eqEq_Entry(dEqs6jw, f_s6jA, h_s6jC);
    }
    public static Closure ccompares6jn_Entry(Closure dOrds6jo, Closure dss6jp, Closure dss6jq)
    {
        var a_s6jr = dss6jp;
        a_s6jr = a_s6jr.Eval();
        var a_s6jr_H = a_s6jr as Example.H;
        var b_s6js = a_s6jr_H.x0;
        var c_s6jt = dss6jq;
        c_s6jt = c_s6jt.Eval();
        var c_s6jt_H = c_s6jt as Example.H;
        var d_s6ju = c_s6jt_H.x0;
        return GHC.Classes.compare_Entry(dOrds6jo, b_s6js, d_s6ju);
    }
    public static Closure cidens6jl_Entry(Closure xs6jm)
    {
        return xs6jm.Eval();
    }
    public static Closure p1W_Entry(Closure a0)
    {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x0; return dictItem.Eval();
    }
    public static Closure iden_Entry(Closure a0, Closure a1)
    {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x1;
        return dictItem.Apply<Closure, Closure>(a1);
    }
    public static Closure root_Entry(Closure a0)
    {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x2; return dictItem.Eval();
    }
    public sealed class O4 : Data
    {
        public Closure x0;
        public O4(Closure x0) { this.x0 = x0; }
        public override int Tag => 5;
    }
    public sealed class O3 : Data
    {
        public Closure x0;
        public O3(Closure x0) { this.x0 = x0; }
        public override int Tag => 4;
    }
    public sealed class O2 : Data
    {
        public Closure x0;
        public O2(Closure x0) { this.x0 = x0; }
        public override int Tag => 3;
    }
    public sealed class O1 : Data
    {
        public Closure x0;
        public O1(Closure x0) { this.x0 = x0; }
        public override int Tag => 2;
    }
    public sealed class O0 : Data
    {
        public Closure x0;
        public O0(Closure x0) { this.x0 = x0; }
        public override int Tag => 1;
    }
    public sealed class CColW : Data
    {
        public Closure x0; public Closure x1; public Closure x2;
        public CColW(Closure x0, Closure x1, Closure x2)
        {
            this.x0 = x0; this.x1 = x1; this.x2 = x2;
        }
        public override int Tag => 1;
    }
    public sealed class H : Data
    {
        public Closure x0;
        public H(Closure x0) { this.x0 = x0; }
        public override int Tag => 1;
    }
    public sealed class C : Data
    {
        public C() { }
        public override int Tag => 3;
    }
    public sealed class B : Data
    {
        public B() { }
        public override int Tag => 2;
    }
    public sealed class A : Data
    {
        public A() { }
        public override int Tag => 1;
    }
}
