using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Num
    {
        public static Fun cColNum_DataCon;

        public static Fun subtract;

        internal static Fun cfromIntegers2Bl;

        internal static Fun cPluss2Bc;

        internal static Fun cDashs2B4;

        internal static Fun cAstrs2AW;

        internal static Fun cnegates2AP;

        internal static Fun cabss2AN;

        internal static Fun csignums2AI;

        internal static Fun cfromIntegers2AD;

        internal static Fun csignums2Aw;

        internal static Fun cabss2An;

        internal static Fun cPluss2Af;

        internal static Fun cDashs2A7;

        internal static Fun cAstrs2zZ;

        internal static Fun cnegates2zU;

        internal static Fun cfromIntegers2zR;

        internal static GHC.Types.IHash lvls2At;
        internal static GHC.Types.IHash lvls2Au;
        internal static GHC.Types.IHash lvls2Av;
        public static GHC.Num.CColNum fNumInt;
        internal static GHC.Types.WHash lvls2AG;
        internal static GHC.Types.WHash lvls2AH;
        public static GHC.Num.CColNum fNumWord;
        public static GHC.Num.CColNum fNumInteger;

        public static Function plus;

        public static Function dash;

        public static Function astr;

        public static Function negate;

        public static Function abs;

        public static Function signum;

        public static Function fromInteger;

        static Num()
        {
            cColNum_DataCon = new Fun(7, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure, Closure, Closure>(cColNum_DataCon_Entry));

            subtract = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(subtract_Entry));

            cfromIntegers2Bl = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cfromIntegers2Bl_Entry));

            cPluss2Bc = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cPluss2Bc_Entry));

            cDashs2B4 = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cDashs2B4_Entry));

            cAstrs2AW = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cAstrs2AW_Entry));

            cnegates2AP = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cnegates2AP_Entry));

            cabss2AN = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cabss2AN_Entry));

            csignums2AI = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(csignums2AI_Entry));

            cfromIntegers2AD = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cfromIntegers2AD_Entry));

            csignums2Aw = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(csignums2Aw_Entry));

            cabss2An = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cabss2An_Entry));

            cPluss2Af = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cPluss2Af_Entry));

            cDashs2A7 = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cDashs2A7_Entry));

            cAstrs2zZ = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cAstrs2zZ_Entry));

            cnegates2zU = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cnegates2zU_Entry));

            cfromIntegers2zR = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(cfromIntegers2zR_Entry));

            fNumInteger = new GHC.Num.CColNum(GHC.Integer.Type.plusInteger, GHC.Integer.Type.minusInteger, GHC.Integer.Type.timesInteger, GHC.Integer.Type.negateInteger, GHC.Integer.Type.absInteger, GHC.Integer.Type.signumInteger, cfromIntegers2Bl);
            fNumWord = new GHC.Num.CColNum(cPluss2Bc, cDashs2B4, cAstrs2AW, cnegates2AP, cabss2AN, csignums2AI, cfromIntegers2AD);
            lvls2AH = new GHC.Types.WHash(0UL);
            lvls2AG = new GHC.Types.WHash(1UL);
            fNumInt = new GHC.Num.CColNum(cPluss2Af, cDashs2A7, cAstrs2zZ, cnegates2zU, cabss2An, csignums2Aw, cfromIntegers2zR);
            lvls2Av = new GHC.Types.IHash(-1);
            lvls2Au = new GHC.Types.IHash(0);
            lvls2At = new GHC.Types.IHash(1);
            plus = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure>(plus_Entry));

            dash = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure>(dash_Entry));

            astr = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure>(astr_Entry));

            negate = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure>(negate_Entry));

            abs = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure>(abs_Entry));

            signum = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure>(signum_Entry));

            fromInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure>(fromInteger_Entry));

        }
        public static Closure cColNum_DataCon_Entry(Closure etaB7, Closure etaB6, Closure etaB5, Closure etaB4, Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return new GHC.Num.CColNum(etaB7, etaB6, etaB5, etaB4, etaB3, etaB2, etaB1);
        }
        public static Closure subtract_Entry(Closure dNums2Bp, Closure etas2Bq, Closure etas2Br)
        {
            return GHC.Num.dash_Entry(dNums2Bp).Apply<Closure, Closure, Closure>(etas2Br, etas2Bq);
        }
        public static Closure cfromIntegers2Bl_Entry(Closure xs2Bm)
        {
            return xs2Bm.Eval();
        }
        public static Closure cPluss2Bc_Entry(Closure dss2Bd, Closure dss2Be)
        {
            var wilds2Bf = dss2Bd.Eval();
            var wilds2Bf_WHash = wilds2Bf as GHC.Types.WHash;
            var xHashs2Bg = wilds2Bf_WHash.x0;
            var wilds2Bh = dss2Be.Eval();
            var wilds2Bh_WHash = wilds2Bh as GHC.Types.WHash;
            var yHashs2Bi = wilds2Bh_WHash.x0;
            var sats2Bj = xHashs2Bg + yHashs2Bi;
            return new GHC.Types.WHash(sats2Bj);
        }
        public static Closure cDashs2B4_Entry(Closure dss2B5, Closure dss2B6)
        {
            var wilds2B7 = dss2B5.Eval();
            var wilds2B7_WHash = wilds2B7 as GHC.Types.WHash;
            var xHashs2B8 = wilds2B7_WHash.x0;
            var wilds2B9 = dss2B6.Eval();
            var wilds2B9_WHash = wilds2B9 as GHC.Types.WHash;
            var yHashs2Ba = wilds2B9_WHash.x0;
            var sats2Bb = xHashs2B8 - yHashs2Ba;
            return new GHC.Types.WHash(sats2Bb);
        }
        public static Closure cAstrs2AW_Entry(Closure dss2AX, Closure dss2AY)
        {
            var wilds2AZ = dss2AX.Eval();
            var wilds2AZ_WHash = wilds2AZ as GHC.Types.WHash;
            var xHashs2B0 = wilds2AZ_WHash.x0;
            var wilds2B1 = dss2AY.Eval();
            var wilds2B1_WHash = wilds2B1 as GHC.Types.WHash;
            var yHashs2B2 = wilds2B1_WHash.x0;
            var sats2B3 = xHashs2B0 * yHashs2B2;
            return new GHC.Types.WHash(sats2B3);
        }
        public static Closure cnegates2AP_Entry(Closure dss2AQ)
        {
            var wilds2AR = dss2AQ.Eval();
            var wilds2AR_WHash = wilds2AR as GHC.Types.WHash;
            var xHashs2AS = wilds2AR_WHash.x0;
            var sats2AT = (long)xHashs2AS;
            var sats2AU = -sats2AT;
            var sats2AV = (ulong)sats2AU;
            return new GHC.Types.WHash(sats2AV);
        }
        public static Closure cabss2AN_Entry(Closure xs2AO)
        {
            return xs2AO.Eval();
        }
        public static Closure csignums2AI_Entry(Closure dss2AJ)
        {
            var wilds2AK = dss2AJ.Eval();
            var wilds2AK_WHash = wilds2AK as GHC.Types.WHash;
            var dss2AL = wilds2AK_WHash.x0;
            var dss2AM = dss2AL;
            switch (dss2AM)
            {
                default: { return lvls2AG.Eval(); }
                case 0UL: { return lvls2AH.Eval(); }
            }
        }
        public static Closure cfromIntegers2AD_Entry(Closure is2AE)
        {
            var wilds2AF = GHC.Integer.Type.integerToWord_Entry(is2AE);
            return new GHC.Types.WHash(wilds2AF);
        }
        public static Closure csignums2Aw_Entry(Closure ns2Ax)
        {
            var wilds2Ay = ns2Ax.Eval();
            var wilds2Ay_IHash = wilds2Ay as GHC.Types.IHash;
            var xs2Az = wilds2Ay_IHash.x0;
            var lwilds2AA = (xs2Az < 0) ? 1 : 0;
            switch (lwilds2AA)
            {
                default:
                    {
                        var wilds2AB = xs2Az;
                        switch (wilds2AB)
                        {
                            default: { return lvls2At.Eval(); }
                            case 0: { return lvls2Au.Eval(); }
                        }
                    }
                case 1: { return lvls2Av.Eval(); }
            }
        }
        public static Closure cabss2An_Entry(Closure ns2Ao)
        {
            var wilds2Ap = ns2Ao.Eval();
            var wilds2Ap_IHash = wilds2Ap as GHC.Types.IHash;
            var xs2Aq = wilds2Ap_IHash.x0;
            var lwilds2Ar = (xs2Aq >= 0) ? 1 : 0;
            switch (lwilds2Ar)
            {
                default:
                    {
                        var sats2As = -xs2Aq; return new GHC.Types.IHash(sats2As);
                    }
                case 1: { return wilds2Ap.Eval(); }
            }
        }
        public static Closure cPluss2Af_Entry(Closure dss2Ag, Closure dss2Ah)
        {
            var wilds2Ai = dss2Ag.Eval();
            var wilds2Ai_IHash = wilds2Ai as GHC.Types.IHash;
            var xs2Aj = wilds2Ai_IHash.x0;
            var wilds2Ak = dss2Ah.Eval();
            var wilds2Ak_IHash = wilds2Ak as GHC.Types.IHash;
            var ys2Al = wilds2Ak_IHash.x0;
            var sats2Am = xs2Aj + ys2Al;
            return new GHC.Types.IHash(sats2Am);
        }
        public static Closure cDashs2A7_Entry(Closure dss2A8, Closure dss2A9)
        {
            var wilds2Aa = dss2A8.Eval();
            var wilds2Aa_IHash = wilds2Aa as GHC.Types.IHash;
            var xs2Ab = wilds2Aa_IHash.x0;
            var wilds2Ac = dss2A9.Eval();
            var wilds2Ac_IHash = wilds2Ac as GHC.Types.IHash;
            var ys2Ad = wilds2Ac_IHash.x0;
            var sats2Ae = xs2Ab - ys2Ad;
            return new GHC.Types.IHash(sats2Ae);
        }
        public static Closure cAstrs2zZ_Entry(Closure dss2A0, Closure dss2A1)
        {
            var wilds2A2 = dss2A0.Eval();
            var wilds2A2_IHash = wilds2A2 as GHC.Types.IHash;
            var xs2A3 = wilds2A2_IHash.x0;
            var wilds2A4 = dss2A1.Eval();
            var wilds2A4_IHash = wilds2A4 as GHC.Types.IHash;
            var ys2A5 = wilds2A4_IHash.x0;
            var sats2A6 = xs2A3 * ys2A5;
            return new GHC.Types.IHash(sats2A6);
        }
        public static Closure cnegates2zU_Entry(Closure dss2zV)
        {
            var wilds2zW = dss2zV.Eval();
            var wilds2zW_IHash = wilds2zW as GHC.Types.IHash;
            var xs2zX = wilds2zW_IHash.x0;
            var sats2zY = -xs2zX; return new GHC.Types.IHash(sats2zY);
        }
        public static Closure cfromIntegers2zR_Entry(Closure is2zS)
        {
            var wilds2zT = GHC.Integer.Type.integerToInt_Entry(is2zS);
            return new GHC.Types.IHash(wilds2zT);
        }
        public static Closure plus_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x0; return dictItem.Eval();
        }
        public static Closure dash_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x1; return dictItem.Eval();
        }
        public static Closure astr_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x2; return dictItem.Eval();
        }
        public static Closure negate_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x3; return dictItem.Eval();
        }
        public static Closure abs_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x4; return dictItem.Eval();
        }
        public static Closure signum_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x5; return dictItem.Eval();
        }
        public static Closure fromInteger_Entry(Closure a0)
        {
            var dict = a0 as GHC.Num.CColNum;
            var dictItem = dict.x6; return dictItem.Eval();
        }
        public sealed class CColNum : Data
        {
            public Closure x0;
            public Closure x1;
            public Closure x2;
            public Closure x3;
            public Closure x4; public Closure x5; public Closure x6;
            public CColNum(Closure x0, Closure x1, Closure x2, Closure x3, Closure x4, Closure x5, Closure x6)
            {
                this.x0 = x0;
                this.x1 = x1;
                this.x2 = x2;
                this.x3 = x3; this.x4 = x4; this.x5 = x5; this.x6 = x6;
            }
            public override int Tag => 1;
        }
    }
}
