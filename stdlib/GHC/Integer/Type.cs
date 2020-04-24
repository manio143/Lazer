using System;
using System.Numerics;
using Lazer.Runtime;

namespace GHC.Integer
{
    public unsafe static class Type
    {
        internal static string lvls4ms = "Integer/Type.hs:(230,5)-(233,16)|case";
        public static Fun bNHash_DataCon;

        public static Fun sHash_DataCon;

        internal static Fun cmins4ok;

        internal static Fun cmaxs4og;

        public static Fun geInteger;

        public static Fun geIntegerHash;

        public static Fun leInteger;

        public static Fun leIntegerHash;

        public static Fun gtInteger;

        public static Fun gtIntegerHash;

        public static Fun ltInteger;

        public static Fun ltIntegerHash;

        public static Fun testBitInteger;

        public static Fun neqInteger;

        public static Fun neqIntegerHash;

        public static Fun modInteger;

        public static Fun divInteger;

        public static Fun divModInteger;

        public static Fun eqInteger;

        public static Fun eqIntegerHash;

        public static Fun compareInteger;

        internal static Updatable lvls4mt;

        public static Fun absInteger;

        public static Fun signumInteger;

        internal static Fun wsignumIntegers4lV;

        public static Fun compareBigIntHash;

        public static Fun timesInteger;

        public static Fun checkedMul;

        public static Fun complementInteger;

        public static Fun minusInteger;

        public static Fun plusInteger;

        public static Fun checkedAdd;

        public static Fun negateInteger;

        public static Fun negBigIntHash;

        public static Fun notBigIntHash;

        public static Fun xorInteger;

        public static Fun xorBigIntHash;

        public static Fun orInteger;

        public static Fun orBigIntHash;

        public static Fun andInteger;

        public static Fun andBigIntHash;

        public static Fun remInteger;

        public static Fun quotInteger;

        public static Fun quotRemInteger;

        public static Fun remBigIntHash;

        public static Fun quotBigIntHash;

        public static Fun mulBigIntHash;

        public static Fun addBigIntHash;

        public static Fun integerToWord;

        public static Fun bigToWordHash;

        public static Fun hashInteger;

        public static Fun integerToInt;

        public static Fun bigToIntHash;

        public static Fun newBigIntI;

        public static Fun newBigIntIHash;

        public static Fun wordToInteger;

        public static Fun newBigIntWHash;

        public static Fun shiftRInteger;

        public static Fun shiftLInteger;

        public static Fun smallInteger;

        internal static GHC.Integer.Type.SHash lvls4kR;
        internal static GHC.Integer.Type.SHash lvls4n3;
        internal static GHC.Integer.Type.SHash lvls4nC;
        public static GHC.Classes.CColEq fEqInteger;
        public static GHC.Classes.CColOrd fOrdInteger;

        static Type()
        {
            bNHash_DataCon = new Fun(1, CLR.LoadFunctionPointer<long, Closure>(bNHash_DataCon_Entry));

            sHash_DataCon = new Fun(1, CLR.LoadFunctionPointer<long, Closure>(sHash_DataCon_Entry));

            cmins4ok = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cmins4ok_Entry));

            cmaxs4og = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cmaxs4og_Entry));

            geInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(geInteger_Entry));

            geIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(geIntegerHash_Entry));

            leInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(leInteger_Entry));

            leIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(leIntegerHash_Entry));

            gtInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(gtInteger_Entry));

            gtIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(gtIntegerHash_Entry));

            ltInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(ltInteger_Entry));

            ltIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(ltIntegerHash_Entry));

            testBitInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(testBitInteger_Entry));

            neqInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(neqInteger_Entry));

            neqIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(neqIntegerHash_Entry));

            modInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(modInteger_Entry));

            divInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(divInteger_Entry));

            divModInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, (Closure x0, Closure x1)>(divModInteger_Entry));

            eqInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(eqInteger_Entry));

            eqIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(eqIntegerHash_Entry));

            compareInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(compareInteger_Entry));

            lvls4mt = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls4mt_Entry));

            absInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(absInteger_Entry));

            signumInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(signumInteger_Entry));

            wsignumIntegers4lV = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(wsignumIntegers4lV_Entry));

            compareBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, long>(compareBigIntHash_Entry));

            timesInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(timesInteger_Entry));

            checkedMul = new Fun(2, CLR.LoadFunctionPointer<long, long, long>(checkedMul_Entry));

            complementInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(complementInteger_Entry));

            minusInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(minusInteger_Entry));

            plusInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(plusInteger_Entry));

            checkedAdd = new Fun(2, CLR.LoadFunctionPointer<long, long, long>(checkedAdd_Entry));

            negateInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(negateInteger_Entry));

            negBigIntHash = new Fun(1, CLR.LoadFunctionPointer<BigInteger, BigInteger>(negBigIntHash_Entry));

            notBigIntHash = new Fun(1, CLR.LoadFunctionPointer<BigInteger, BigInteger>(notBigIntHash_Entry));

            xorInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(xorInteger_Entry));

            xorBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(xorBigIntHash_Entry));

            orInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(orInteger_Entry));

            orBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(orBigIntHash_Entry));

            andInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(andInteger_Entry));

            andBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(andBigIntHash_Entry));

            remInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(remInteger_Entry));

            quotInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(quotInteger_Entry));

            quotRemInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, (Closure x0, Closure x1)>(quotRemInteger_Entry));

            remBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(remBigIntHash_Entry));

            quotBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(quotBigIntHash_Entry));

            mulBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(mulBigIntHash_Entry));

            addBigIntHash = new Fun(2, CLR.LoadFunctionPointer<BigInteger, BigInteger, BigInteger>(addBigIntHash_Entry));

            integerToWord = new Fun(1, CLR.LoadFunctionPointer<Closure, ulong>(integerToWord_Entry));

            bigToWordHash = new Fun(1, CLR.LoadFunctionPointer<BigInteger, ulong>(bigToWordHash_Entry));

            hashInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(hashInteger_Entry));

            integerToInt = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(integerToInt_Entry));

            bigToIntHash = new Fun(1, CLR.LoadFunctionPointer<BigInteger, long>(bigToIntHash_Entry));

            newBigIntI = new Fun(1, CLR.LoadFunctionPointer<long, Closure>(newBigIntI_Entry));

            newBigIntIHash = new Fun(1, CLR.LoadFunctionPointer<long, BigInteger>(newBigIntIHash_Entry));

            wordToInteger = new Fun(1, CLR.LoadFunctionPointer<ulong, Closure>(wordToInteger_Entry));

            newBigIntWHash = new Fun(1, CLR.LoadFunctionPointer<ulong, BigInteger>(newBigIntWHash_Entry));

            shiftRInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftRInteger_Entry));

            shiftLInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftLInteger_Entry));

            smallInteger = new Fun(1, CLR.LoadFunctionPointer<long, Closure>(smallInteger_Entry));

            fOrdInteger = new GHC.Classes.CColOrd(null, GHC.Integer.Type.compareInteger, GHC.Integer.Type.ltInteger, GHC.Integer.Type.leInteger, GHC.Integer.Type.gtInteger, GHC.Integer.Type.geInteger, cmaxs4og, cmins4ok);
            fEqInteger = new GHC.Classes.CColEq(GHC.Integer.Type.eqInteger, GHC.Integer.Type.neqInteger);
            lvls4nC = new GHC.Integer.Type.SHash(0);
            lvls4n3 = new GHC.Integer.Type.SHash(1);
            lvls4kR = new GHC.Integer.Type.SHash(-1);
            fOrdInteger.x0 = GHC.Integer.Type.fEqInteger;
        }
        public static Closure bNHash_DataCon_Entry(long etaB1)
        {
            return new GHC.Integer.Type.BNHash(etaB1);
        }
        public static Closure sHash_DataCon_Entry(long etaB1)
        {
            return new GHC.Integer.Type.SHash(etaB1);
        }
        public static Closure cmins4ok_Entry(Closure xs4ol, Closure ys4om)
        {
            var wilds4on = leIntegerHash_Entry(xs4ol, ys4om);
            switch (wilds4on)
            {
                default: { return ys4om.Eval(); }
                case 1: { return xs4ol.Eval(); }
            }
        }
        public static Closure cmaxs4og_Entry(Closure xs4oh, Closure ys4oi)
        {
            var wilds4oj = leIntegerHash_Entry(xs4oh, ys4oi);
            switch (wilds4oj)
            {
                default: { return xs4oh.Eval(); }
                case 1: { return ys4oi.Eval(); }
            }
        }
        public static Closure geInteger_Entry(Closure as4od, Closure bs4oe)
        {
            var wilds4of = geIntegerHash_Entry(as4od, bs4oe);
            return GHC.Types.isTrueHash_Entry(wilds4of);
        }
        public static long geIntegerHash_Entry(Closure xs4o9, Closure ys4oa)
        {
            var wilds4ob = compareInteger_Entry(xs4o9, ys4oa).Eval();
            var wilds4obTags4ob = wilds4ob.Tag;
            switch (wilds4obTags4ob)
            {
                default: { return 1; }
                case 1: { var wilds4ob_LT = wilds4ob as GHC.Types.LT; return 0; }
            }
        }
        public static Closure leInteger_Entry(Closure as4o5, Closure bs4o6)
        {
            var wilds4o7 = leIntegerHash_Entry(as4o5, bs4o6);
            return GHC.Types.isTrueHash_Entry(wilds4o7);
        }
        public static long leIntegerHash_Entry(Closure xs4o1, Closure ys4o2)
        {
            var wilds4o3 = compareInteger_Entry(xs4o1, ys4o2).Eval();
            var wilds4o3Tags4o3 = wilds4o3.Tag;
            switch (wilds4o3Tags4o3)
            {
                default: { return 1; }
                case 3: { var wilds4o3_GT = wilds4o3 as GHC.Types.GT; return 0; }
            }
        }
        public static Closure gtInteger_Entry(Closure as4nX, Closure bs4nY)
        {
            var wilds4nZ = gtIntegerHash_Entry(as4nX, bs4nY);
            return GHC.Types.isTrueHash_Entry(wilds4nZ);
        }
        public static long gtIntegerHash_Entry(Closure xs4nT, Closure ys4nU)
        {
            var wilds4nV = compareInteger_Entry(xs4nT, ys4nU).Eval();
            var wilds4nVTags4nV = wilds4nV.Tag;
            switch (wilds4nVTags4nV)
            {
                default: { return 0; }
                case 3: { var wilds4nV_GT = wilds4nV as GHC.Types.GT; return 1; }
            }
        }
        public static Closure ltInteger_Entry(Closure as4nP, Closure bs4nQ)
        {
            var wilds4nR = ltIntegerHash_Entry(as4nP, bs4nQ);
            return GHC.Types.isTrueHash_Entry(wilds4nR);
        }
        public static long ltIntegerHash_Entry(Closure xs4nL, Closure ys4nM)
        {
            var wilds4nN = compareInteger_Entry(xs4nL, ys4nM).Eval();
            var wilds4nNTags4nN = wilds4nN.Tag;
            switch (wilds4nNTags4nN)
            {
                default: { return 0; }
                case 1: { var wilds4nN_LT = wilds4nN as GHC.Types.LT; return 1; }
            }
        }
        public static Closure testBitInteger_Entry(Closure xs4nE, long is4nF)
        {
            var sats4nG = shiftLInteger_Entry(lvls4n3, is4nF).Eval();
            var sats4nH = andInteger_Entry(xs4nE, sats4nG).Eval();
            var wilds4nI = neqIntegerHash_Entry(sats4nH, lvls4nC);
            return GHC.Types.isTrueHash_Entry(wilds4nI);
        }
        public static Closure neqInteger_Entry(Closure as4nz, Closure bs4nA)
        {
            var wilds4nB = neqIntegerHash_Entry(as4nz, bs4nA);
            return GHC.Types.isTrueHash_Entry(wilds4nB);
        }
        public static long neqIntegerHash_Entry(Closure xs4nv, Closure ys4nw)
        {
            var wilds4nx = compareInteger_Entry(xs4nv, ys4nw).Eval();
            var wilds4nxTags4nx = wilds4nx.Tag;
            switch (wilds4nxTags4nx)
            {
                default: { return 1; }
                case 2: { var wilds4nx_EQ = wilds4nx as GHC.Types.EQ; return 0; }
            }
        }
        public static Closure modInteger_Entry(Closure ns4np, Closure ds4nq)
        {
            var dss4nr = divModInteger_Entry(ns4np, ds4nq);
            var dss4nr_RawTuple = dss4nr;
            var ipvs4ns = dss4nr_RawTuple.x0;
            var ipvs4nt = dss4nr_RawTuple.x1; return ipvs4nt.Eval();
        }
        public static Closure divInteger_Entry(Closure ns4nj, Closure ds4nk)
        {
            var dss4nl = divModInteger_Entry(ns4nj, ds4nk);
            var dss4nl_RawTuple = dss4nl;
            var ipvs4nm = dss4nl_RawTuple.x0;
            var ipvs4nn = dss4nl_RawTuple.x1; return ipvs4nm.Eval();
        }
        public static (Closure x0, Closure x1) divModInteger_Entry(Closure ns4n5, Closure ds4n6)
        {
            var dss4n7 = quotRemInteger_Entry(ns4n5, ds4n6);
            var dss4n7_RawTuple = dss4n7;
            var ipvs4n8 = dss4n7_RawTuple.x0;
            var ipvs4n9 = dss4n7_RawTuple.x1;
            var wws4na = wsignumIntegers4lV_Entry(ipvs4n9);
            var wws4nb = wsignumIntegers4lV_Entry(ds4n6);
            var sats4nd = new GHC.Integer.Type.SHash(wws4nb);
            var sats4ne = negateInteger_Entry(sats4nd).Eval();
            var sats4nc = new GHC.Integer.Type.SHash(wws4na);
            var wilds4nf = eqIntegerHash_Entry(sats4nc, sats4ne);
            switch (wilds4nf)
            {
                default: { return (ipvs4n8, ipvs4n9); }
                case 1:
                    {
                        var sats4nh = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(sats4nh_Entry), ds4n6, ipvs4n9);
                        var sats4ng = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats4ng_Entry), ipvs4n8);
                        return (sats4ng, sats4nh);
                    }
            }
        }
        public static Closure sats4ng_Entry(Closure ipvs4n8)
        {
            return minusInteger_Entry(ipvs4n8, lvls4n3);
        }
        public static Closure sats4nh_Entry(Closure ds4n6, Closure ipvs4n9)
        {
            return plusInteger_Entry(ipvs4n9, ds4n6);
        }
        public static Closure eqInteger_Entry(Closure as4n0, Closure bs4n1)
        {
            var wilds4n2 = eqIntegerHash_Entry(as4n0, bs4n1);
            return GHC.Types.isTrueHash_Entry(wilds4n2);
        }
        public static long eqIntegerHash_Entry(Closure xs4mW, Closure ys4mX)
        {
            var wilds4mY = compareInteger_Entry(xs4mW, ys4mX).Eval();
            var wilds4mYTags4mY = wilds4mY.Tag;
            switch (wilds4mYTags4mY)
            {
                default: { return 0; }
                case 2: { var wilds4mY_EQ = wilds4mY as GHC.Types.EQ; return 1; }
            }
        }
        public static Closure compareInteger_Entry(Closure dss4mv, Closure dss4mw)
        {
            var wilds4mx = dss4mv.Eval();
            switch (wilds4mx)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4mx_SHash:
                    {
                        var xs4my = wilds4mx_SHash.x0;
                        var wilds4mz = dss4mw.Eval();
                        switch (wilds4mz)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4mz_SHash:
                                {
                                    var ys4mA = wilds4mz_SHash.x0;
                                    return GHC.Classes.compareIntHash_Entry(xs4my, ys4mA);
                                }
                            case GHC.Integer.Type.BNHash wilds4mz_BNHash:
                                {
                                    var ipvs4mB = wilds4mz_BNHash.x0;
                                    var wilds4mD = mkBigInt(xs4my, GHC.Prim.realWorldHash);
                                    var dss4mF = wilds4mD;
                                    var sats4mG = new GHC.Integer.Type.BNHash(dss4mF);
                                    return compareInteger_Entry(sats4mG, wilds4mz);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4mx_BNHash:
                    {
                        var bns4mH = wilds4mx_BNHash.x0;
                        var wilds4mI = dss4mw.Eval();
                        switch (wilds4mI)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4mI_SHash:
                                {
                                    var ipvs4mJ = wilds4mI_SHash.x0;
                                    var wilds4mL = mkBigInt(ipvs4mJ, GHC.Prim.realWorldHash);
                                    var dss4mN = wilds4mL;
                                    var sats4mO = new GHC.Integer.Type.BNHash(dss4mN);
                                    return compareInteger_Entry(wilds4mx, sats4mO);
                                }
                            case GHC.Integer.Type.BNHash wilds4mI_BNHash:
                                {
                                    var bms4mP = wilds4mI_BNHash.x0;
                                    var wilds4mR = compareBigIntHash_Entry(bns4mH, bms4mP);
                                    var dss4mT = wilds4mR;
                                    var dss4mU = dss4mT;
                                    switch (dss4mU)
                                    {
                                        default: { return lvls4mt.Eval(); }
                                        case -1: { return GHC.Types.lT_DataCon.Eval(); }
                                        case 0: { return GHC.Types.eQ_DataCon.Eval(); }
                                        case 1: { return GHC.Types.gT_DataCon.Eval(); }
                                    }
                                }
                        }
                    }
            }
        }
        public static Closure lvls4mt_Entry()
        {
            throw new System.Exception(lvls4ms);
        }
        public static Closure absInteger_Entry(Closure is4me)
        {
            var wilds4mf = is4me.Eval();
            switch (wilds4mf)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4mf_SHash:
                    {
                        var xs4mg = wilds4mf_SHash.x0;
                        var dss4mh = (xs4mg < 0) ? 1 : 0;
                        switch (dss4mh)
                        {
                            default: { return wilds4mf.Eval(); }
                            case 1: { return negateInteger_Entry(wilds4mf); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4mf_BNHash:
                    {
                        var bns4mi = wilds4mf_BNHash.x0;
                        var wilds4mk = mkBigInt(0, GHC.Prim.realWorldHash);
                        var dss4mm = wilds4mk;
                        var wilds4mo = compareBigIntHash_Entry(bns4mi, dss4mm);
                        var dss4mq = wilds4mo;
                        var wilds4mr = dss4mq;
                        switch (wilds4mr)
                        {
                            default: { return wilds4mf.Eval(); }
                            case -1: { return negateInteger_Entry(wilds4mf); }
                        }
                    }
            }
        }
        public static Closure signumInteger_Entry(Closure ws4mb)
        {
            var wws4mc = wsignumIntegers4lV_Entry(ws4mb);
            return new GHC.Integer.Type.SHash(wws4mc);
        }
        public static long wsignumIntegers4lV_Entry(Closure ws4lW)
        {
            var wilds4lX = ws4lW.Eval();
            switch (wilds4lX)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4lX_SHash:
                    {
                        var xs4lY = wilds4lX_SHash.x0;
                        var dss4lZ = (xs4lY < 0) ? 1 : 0;
                        switch (dss4lZ)
                        {
                            default:
                                {
                                    var wilds4m0 = xs4lY;
                                    switch (wilds4m0)
                                    {
                                        default: { return 1; }
                                        case 0: { return 0; }
                                    }
                                }
                            case 1: { return -1; }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4lX_BNHash:
                    {
                        var bns4m1 = wilds4lX_BNHash.x0;
                        var wilds4m3 = mkBigInt(0, GHC.Prim.realWorldHash);
                        var dss4m5 = wilds4m3;
                        var wilds4m7 = compareBigIntHash_Entry(bns4m1, dss4m5);
                        var dss4m9 = wilds4m7; return dss4m9;
                    }
            }
        }
        public static long compareBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return BigInteger.Compare(a, b);
        }
        public static Closure timesInteger_Entry(Closure xs4l2, Closure dss4l3)
        {
            var wilds4lK = dss4l3.Eval();
            switch (wilds4lK)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4lK_SHash:
                    {
                        var dss4lL = wilds4lK_SHash.x0;
                        var dss4lM = dss4lL;
                        switch (dss4lM)
                        {
                            default:
                                {
                                    return fails4l4_Entry(xs4l2, dss4l3, GHC.Prim.voidHash);
                                }
                            case 0: { return wilds4lK.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4lK_BNHash:
                    {
                        return fails4l4_Entry(xs4l2, dss4l3, GHC.Prim.voidHash);
                    }
            }
        }
        public static Closure fails4l4_Entry(Closure xs4l2, Closure dss4l3, GHC.Prim.Void void0E)
        {
            var wilds4l6 = xs4l2.Eval();
            switch (wilds4l6)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4l6_SHash:
                    {
                        var dss4l7 = wilds4l6_SHash.x0;
                        var dss4l8 = dss4l7;
                        switch (dss4l8)
                        {
                            default:
                                {
                                    var wilds4l9 = dss4l3.Eval();
                                    switch (wilds4l9)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.SHash wilds4l9_SHash:
                                            {
                                                var ys4la = wilds4l9_SHash.x0;
                                                var wilds4lc = checkedMul_Entry(dss4l8, ys4la);
                                                var dss4le = wilds4lc;
                                                var wilds4lf = dss4le;
                                                switch (wilds4lf)
                                                {
                                                    default:
                                                        {
                                                            var sats4lg = dss4l8 * ys4la;
                                                            return new GHC.Integer.Type.SHash(sats4lg);
                                                        }
                                                    case 0:
                                                        {
                                                            var wilds4li = mkBigInt(dss4l8, GHC.Prim.realWorldHash);
                                                            var dss4lk = wilds4li;
                                                            var wilds4lm = mkBigInt(ys4la, GHC.Prim.realWorldHash);
                                                            var dss4lo = wilds4lm;
                                                            var sats4lq = new GHC.Integer.Type.BNHash(dss4lo);
                                                            var sats4lp = new GHC.Integer.Type.BNHash(dss4lk);
                                                            return timesInteger_Entry(sats4lp, sats4lq);
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.BNHash wilds4l9_BNHash:
                                            {
                                                var ipvs4lr = wilds4l9_BNHash.x0;
                                                var wilds4lt = mkBigInt(dss4l8, GHC.Prim.realWorldHash);
                                                var dss4lv = wilds4lt;
                                                var sats4lw = new GHC.Integer.Type.BNHash(dss4lv);
                                                return timesInteger_Entry(sats4lw, wilds4l9);
                                            }
                                    }
                                }
                            case 0: { return wilds4l6.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4l6_BNHash:
                    {
                        var bns4lx = wilds4l6_BNHash.x0;
                        var wilds4ly = dss4l3.Eval();
                        switch (wilds4ly)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4ly_SHash:
                                {
                                    var ipvs4lz = wilds4ly_SHash.x0;
                                    var wilds4lB = mkBigInt(ipvs4lz, GHC.Prim.realWorldHash);
                                    var dss4lD = wilds4lB;
                                    var sats4lE = new GHC.Integer.Type.BNHash(dss4lD);
                                    return timesInteger_Entry(wilds4l6, sats4lE);
                                }
                            case GHC.Integer.Type.BNHash wilds4ly_BNHash:
                                {
                                    var bms4lF = wilds4ly_BNHash.x0;
                                    var wilds4lH = mulBigIntHash_Entry(bns4lx, bms4lF);
                                    var dss4lJ = wilds4lH;
                                    return new GHC.Integer.Type.BNHash(dss4lJ);
                                }
                        }
                    }
            }
        }
        public static long checkedMul_Entry(long a, long b)
        {
            try {
                var t = checked(a * b);
                if (t > 0) // t has to be used so that it's not removed
                    return 1;
                return 1;
            } catch (System.OverflowException) {
                return 0;
            }
        }
        public static Closure complementInteger_Entry(Closure xs4kT)
        {
            return minusInteger_Entry(lvls4kR, xs4kT);
        }
        public static Closure minusInteger_Entry(Closure i1s4kO, Closure i2s4kP)
        {
            var sats4kQ = negateInteger_Entry(i2s4kP).Eval();
            return plusInteger_Entry(i1s4kO, sats4kQ);
        }
        public static Closure plusInteger_Entry(Closure xs4k1, Closure dss4k2)
        {
            var wilds4kJ = dss4k2.Eval();
            switch (wilds4kJ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4kJ_SHash:
                    {
                        var dss4kK = wilds4kJ_SHash.x0;
                        var dss4kL = dss4kK;
                        switch (dss4kL)
                        {
                            default:
                                {
                                    return fails4k3_Entry(xs4k1, dss4k2, GHC.Prim.voidHash);
                                }
                            case 0: { return xs4k1.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4kJ_BNHash:
                    {
                        return fails4k3_Entry(xs4k1, dss4k2, GHC.Prim.voidHash);
                    }
            }
        }
        public static Closure fails4k3_Entry(Closure xs4k1, Closure dss4k2, GHC.Prim.Void void0E)
        {
            var wilds4k5 = xs4k1.Eval();
            switch (wilds4k5)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4k5_SHash:
                    {
                        var dss4k6 = wilds4k5_SHash.x0;
                        var dss4k7 = dss4k6;
                        switch (dss4k7)
                        {
                            default:
                                {
                                    var wilds4k8 = dss4k2.Eval();
                                    switch (wilds4k8)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.SHash wilds4k8_SHash:
                                            {
                                                var ys4k9 = wilds4k8_SHash.x0;
                                                var wilds4kb = checkedAdd_Entry(dss4k7, ys4k9);
                                                var dss4kd = wilds4kb;
                                                var wilds4ke = dss4kd;
                                                switch (wilds4ke)
                                                {
                                                    default:
                                                        {
                                                            var sats4kf = dss4k7 + ys4k9;
                                                            return new GHC.Integer.Type.SHash(sats4kf);
                                                        }
                                                    case 0:
                                                        {
                                                            var wilds4kh = mkBigInt(dss4k7, GHC.Prim.realWorldHash);
                                                            var dss4kj = wilds4kh;
                                                            var wilds4kl = mkBigInt(ys4k9, GHC.Prim.realWorldHash);
                                                            var dss4kn = wilds4kl;
                                                            var sats4kp = new GHC.Integer.Type.BNHash(dss4kn);
                                                            var sats4ko = new GHC.Integer.Type.BNHash(dss4kj);
                                                            return plusInteger_Entry(sats4ko, sats4kp);
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.BNHash wilds4k8_BNHash:
                                            {
                                                var ipvs4kq = wilds4k8_BNHash.x0;
                                                var wilds4ks = mkBigInt(dss4k7, GHC.Prim.realWorldHash);
                                                var dss4ku = wilds4ks;
                                                var sats4kv = new GHC.Integer.Type.BNHash(dss4ku);
                                                return plusInteger_Entry(sats4kv, wilds4k8);
                                            }
                                    }
                                }
                            case 0: { return dss4k2.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4k5_BNHash:
                    {
                        var bns4kw = wilds4k5_BNHash.x0;
                        var wilds4kx = dss4k2.Eval();
                        switch (wilds4kx)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4kx_SHash:
                                {
                                    var ipvs4ky = wilds4kx_SHash.x0;
                                    var wilds4kA = mkBigInt(ipvs4ky, GHC.Prim.realWorldHash);
                                    var dss4kC = wilds4kA;
                                    var sats4kD = new GHC.Integer.Type.BNHash(dss4kC);
                                    return plusInteger_Entry(wilds4k5, sats4kD);
                                }
                            case GHC.Integer.Type.BNHash wilds4kx_BNHash:
                                {
                                    var bms4kE = wilds4kx_BNHash.x0;
                                    var wilds4kG = addBigIntHash_Entry(bns4kw, bms4kE);
                                    var dss4kI = wilds4kG;
                                    return new GHC.Integer.Type.BNHash(dss4kI);
                                }
                        }
                    }
            }
        }
        public static long checkedAdd_Entry(long a, long b)
        {
            try {
                var t = checked(a + b);
                if (t > 0) // t has to be used so that it's not removed
                    return 1;
                return 1;
            } catch (System.OverflowException) {
                return 0;
            }
        }
        public static Closure negateInteger_Entry(Closure dss4jE)
        {
            var wilds4jF = dss4jE.Eval();
            switch (wilds4jF)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4jF_SHash:
                    {
                        var is4jG = wilds4jF_SHash.x0;
                        var wilds4jH = is4jG;
                        switch (wilds4jH)
                        {
                            default:
                                {
                                    var sats4jI = -wilds4jH;
                                    return new GHC.Integer.Type.SHash(sats4jI);
                                }
                            case -9223372036854775808:
                                {
                                    var wilds4jK = mkBigInt(-9223372036854775808, GHC.Prim.realWorldHash);
                                    var dss4jM = wilds4jK;
                                    var sats4jN = new GHC.Integer.Type.BNHash(dss4jM);
                                    return negateInteger_Entry(sats4jN);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4jF_BNHash:
                    {
                        var bns4jO = wilds4jF_BNHash.x0;
                        var wilds4jQ = negBigIntHash_Entry(bns4jO);
                        var dss4jS = wilds4jQ;
                        return new GHC.Integer.Type.BNHash(dss4jS);
                    }
            }
        }
        public static BigInteger negBigIntHash_Entry(BigInteger x)
        {
            return -x;
        }
        public static BigInteger notBigIntHash_Entry(BigInteger x)
        {
            return ~x;
        }
        public static Closure xorInteger_Entry(Closure dss4j1, Closure dss4j2)
        {
            var wilds4j3 = dss4j1.Eval();
            switch (wilds4j3)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4j3_SHash:
                    {
                        var is4j4 = wilds4j3_SHash.x0;
                        var wilds4j5 = dss4j2.Eval();
                        switch (wilds4j5)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4j5_SHash:
                                {
                                    var js4j6 = wilds4j5_SHash.x0;
                                    var sats4j7 = is4j4 ^ js4j6;
                                    return new GHC.Integer.Type.SHash(sats4j7);
                                }
                            case GHC.Integer.Type.BNHash wilds4j5_BNHash:
                                {
                                    var ipvs4j8 = wilds4j5_BNHash.x0;
                                    var wilds4ja = mkBigInt(is4j4, GHC.Prim.realWorldHash);
                                    var dss4jc = wilds4ja;
                                    var sats4jd = new GHC.Integer.Type.BNHash(dss4jc);
                                    return xorInteger_Entry(sats4jd, wilds4j5);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4j3_BNHash:
                    {
                        var bns4je = wilds4j3_BNHash.x0;
                        var wilds4jf = dss4j2.Eval();
                        switch (wilds4jf)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4jf_SHash:
                                {
                                    var ipvs4jg = wilds4jf_SHash.x0;
                                    var wilds4ji = mkBigInt(ipvs4jg, GHC.Prim.realWorldHash);
                                    var dss4jk = wilds4ji;
                                    var sats4jl = new GHC.Integer.Type.BNHash(dss4jk);
                                    return xorInteger_Entry(wilds4j3, sats4jl);
                                }
                            case GHC.Integer.Type.BNHash wilds4jf_BNHash:
                                {
                                    var bms4jm = wilds4jf_BNHash.x0;
                                    var wilds4jo = xorBigIntHash_Entry(bns4je, bms4jm);
                                    var dss4jq = wilds4jo;
                                    return new GHC.Integer.Type.BNHash(dss4jq);
                                }
                        }
                    }
            }
        }
        public static BigInteger xorBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a ^ b;
        }
        public static Closure orInteger_Entry(Closure dss4it, Closure dss4iu)
        {
            var wilds4iv = dss4it.Eval();
            switch (wilds4iv)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4iv_SHash:
                    {
                        var is4iw = wilds4iv_SHash.x0;
                        var wilds4ix = dss4iu.Eval();
                        switch (wilds4ix)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4ix_SHash:
                                {
                                    var js4iy = wilds4ix_SHash.x0;
                                    var sats4iz = is4iw | js4iy;
                                    return new GHC.Integer.Type.SHash(sats4iz);
                                }
                            case GHC.Integer.Type.BNHash wilds4ix_BNHash:
                                {
                                    var ipvs4iA = wilds4ix_BNHash.x0;
                                    var wilds4iC = mkBigInt(is4iw, GHC.Prim.realWorldHash);
                                    var dss4iE = wilds4iC;
                                    var sats4iF = new GHC.Integer.Type.BNHash(dss4iE);
                                    return orInteger_Entry(sats4iF, wilds4ix);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4iv_BNHash:
                    {
                        var bns4iG = wilds4iv_BNHash.x0;
                        var wilds4iH = dss4iu.Eval();
                        switch (wilds4iH)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4iH_SHash:
                                {
                                    var ipvs4iI = wilds4iH_SHash.x0;
                                    var wilds4iK = mkBigInt(ipvs4iI, GHC.Prim.realWorldHash);
                                    var dss4iM = wilds4iK;
                                    var sats4iN = new GHC.Integer.Type.BNHash(dss4iM);
                                    return orInteger_Entry(wilds4iv, sats4iN);
                                }
                            case GHC.Integer.Type.BNHash wilds4iH_BNHash:
                                {
                                    var bms4iO = wilds4iH_BNHash.x0;
                                    var wilds4iQ = orBigIntHash_Entry(bns4iG, bms4iO);
                                    var dss4iS = wilds4iQ;
                                    return new GHC.Integer.Type.BNHash(dss4iS);
                                }
                        }
                    }
            }
        }
        public static BigInteger orBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a | b;
        }
        public static Closure andInteger_Entry(Closure dss4hV, Closure dss4hW)
        {
            var wilds4hX = dss4hV.Eval();
            switch (wilds4hX)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4hX_SHash:
                    {
                        var is4hY = wilds4hX_SHash.x0;
                        var wilds4hZ = dss4hW.Eval();
                        switch (wilds4hZ)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4hZ_SHash:
                                {
                                    var js4i0 = wilds4hZ_SHash.x0;
                                    var sats4i1 = is4hY & js4i0;
                                    return new GHC.Integer.Type.SHash(sats4i1);
                                }
                            case GHC.Integer.Type.BNHash wilds4hZ_BNHash:
                                {
                                    var ipvs4i2 = wilds4hZ_BNHash.x0;
                                    var wilds4i4 = mkBigInt(is4hY, GHC.Prim.realWorldHash);
                                    var dss4i6 = wilds4i4;
                                    var sats4i7 = new GHC.Integer.Type.BNHash(dss4i6);
                                    return andInteger_Entry(sats4i7, wilds4hZ);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4hX_BNHash:
                    {
                        var bns4i8 = wilds4hX_BNHash.x0;
                        var wilds4i9 = dss4hW.Eval();
                        switch (wilds4i9)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4i9_SHash:
                                {
                                    var ipvs4ia = wilds4i9_SHash.x0;
                                    var wilds4ic = mkBigInt(ipvs4ia, GHC.Prim.realWorldHash);
                                    var dss4ie = wilds4ic;
                                    var sats4if = new GHC.Integer.Type.BNHash(dss4ie);
                                    return andInteger_Entry(wilds4hX, sats4if);
                                }
                            case GHC.Integer.Type.BNHash wilds4i9_BNHash:
                                {
                                    var bms4ig = wilds4i9_BNHash.x0;
                                    var wilds4ii = andBigIntHash_Entry(bns4i8, bms4ig);
                                    var dss4ik = wilds4ii;
                                    return new GHC.Integer.Type.BNHash(dss4ik);
                                }
                        }
                    }
            }
        }

        public static Closure mkInteger_Entry(Closure positive, Closure ints)
        {
            var b = mkFromList(ints);
            switch(positive.Eval().Tag)
            {
                default: throw new ImpossibleException();
                case 1: return b;
                case 0: return negateInteger_Entry(b);
            }
        }
        private static Closure mkFromList(Closure ints)
        {
            switch(ints.Eval())
            {
                default: throw new ImpossibleException();
                case GHC.Types.Nil nil:
                    return smallInteger_Entry(0);
                case GHC.Types.Cons cons:
                    var h = cons.x0;
                    var y = cons.x1;
                    var lh = smallInteger_Entry((h.Eval() as GHC.Types.IHash).x0 & 0x7fffffff);
                    var rh = shiftLInteger_Entry(mkFromList(y), 31);
                    return orInteger_Entry(lh, rh);
            }
        }

        public static BigInteger andBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a & b;
        }
        public static Closure remInteger_Entry(Closure xs4hI, Closure ys4hJ)
        {
            var dss4hK = quotRemInteger_Entry(xs4hI, ys4hJ);
            var dss4hK_RawTuple = dss4hK;
            var ipvs4hL = dss4hK_RawTuple.x0;
            var ipvs4hM = dss4hK_RawTuple.x1; return ipvs4hM.Eval();
        }
        public static Closure quotInteger_Entry(Closure xs4hC, Closure ys4hD)
        {
            var dss4hE = quotRemInteger_Entry(xs4hC, ys4hD);
            var dss4hE_RawTuple = dss4hE;
            var ipvs4hF = dss4hE_RawTuple.x0;
            var ipvs4hG = dss4hE_RawTuple.x1; return ipvs4hF.Eval();
        }
        public static (Closure x0, Closure x1) quotRemInteger_Entry(Closure dss4h1, Closure dss4h2)
        {
            var wilds4h3 = dss4h1.Eval();
            switch (wilds4h3)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4h3_SHash:
                    {
                        var is4h4 = wilds4h3_SHash.x0;
                        var wilds4h5 = dss4h2.Eval();
                        switch (wilds4h5)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4h5_SHash:
                                {
                                    var js4h6 = wilds4h5_SHash.x0;
                                    var dss4h7 = (x0: is4h4 / js4h6, x1: is4h4 % js4h6);
                                    var dss4h7_RawTuple = dss4h7;
                                    var ipvs4h8 = dss4h7_RawTuple.x0;
                                    var ipvs4h9 = dss4h7_RawTuple.x1;
                                    var sats4hb = new GHC.Integer.Type.SHash(ipvs4h9);
                                    var sats4ha = new GHC.Integer.Type.SHash(ipvs4h8);
                                    return (sats4ha, sats4hb);
                                }
                            case GHC.Integer.Type.BNHash wilds4h5_BNHash:
                                {
                                    var ipvs4hc = wilds4h5_BNHash.x0;
                                    var wilds4he = mkBigInt(is4h4, GHC.Prim.realWorldHash);
                                    var dss4hg = wilds4he;
                                    var sats4hh = new GHC.Integer.Type.BNHash(dss4hg);
                                    return quotRemInteger_Entry(sats4hh, wilds4h5);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4h3_BNHash:
                    {
                        var bns4hi = wilds4h3_BNHash.x0;
                        var wilds4hj = dss4h2.Eval();
                        switch (wilds4hj)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4hj_SHash:
                                {
                                    var ipvs4hk = wilds4hj_SHash.x0;
                                    var wilds4hm = mkBigInt(ipvs4hk, GHC.Prim.realWorldHash);
                                    var dss4ho = wilds4hm;
                                    var sats4hp = new GHC.Integer.Type.BNHash(dss4ho);
                                    return quotRemInteger_Entry(wilds4h3, sats4hp);
                                }
                            case GHC.Integer.Type.BNHash wilds4hj_BNHash:
                                {
                                    var bms4hq = wilds4hj_BNHash.x0;
                                    var wilds4hs = remBigIntHash_Entry(bns4hi, bms4hq);
                                    var dss4hu = wilds4hs;
                                    var wilds4hw = quotBigIntHash_Entry(bns4hi, bms4hq);
                                    var dss4hy = wilds4hw;
                                    var sats4hA = new GHC.Integer.Type.BNHash(dss4hu);
                                    var sats4hz = new GHC.Integer.Type.BNHash(dss4hy);
                                    return (sats4hz, sats4hA);
                                }
                        }
                    }
            }
        }
        public static BigInteger remBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a % b;
        }
        public static BigInteger quotBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a / b;
        }
        public static BigInteger mulBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a * b;
        }
        public static BigInteger addBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a + b;
        }
        public static ulong integerToWord_Entry(Closure dss4gu)
        {
            var wilds4gv = dss4gu.Eval();
            switch (wilds4gv)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4gv_SHash:
                    {
                        var is4gw = wilds4gv_SHash.x0; return (ulong)is4gw;
                    }
                case GHC.Integer.Type.BNHash wilds4gv_BNHash:
                    {
                        var bns4gx = wilds4gv_BNHash.x0;
                        return bigToWordHash_Entry(bns4gx);
                    }
            }
        }
        public static ulong bigToWordHash_Entry(BigInteger x)
        {
            return (ulong)x;
        }
        public static long hashInteger_Entry(Closure etaB1)
        {
            return integerToInt_Entry(etaB1);
        }
        public static long integerToInt_Entry(Closure dss4gi)
        {
            var wilds4gj = dss4gi.Eval();
            switch (wilds4gj)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4gj_SHash:
                    {
                        var is4gk = wilds4gj_SHash.x0; return is4gk;
                    }
                case GHC.Integer.Type.BNHash wilds4gj_BNHash:
                    {
                        var bns4gl = wilds4gj_BNHash.x0;
                        return bigToIntHash_Entry(bns4gl);
                    }
            }
        }
        public static long bigToIntHash_Entry(BigInteger x)
        {
            return (long)x;
        }
        public static Closure newBigIntI_Entry(long is4g6)
        {
            var wilds4g8 = mkBigInt(is4g6, GHC.Prim.realWorldHash);
            var dss4ga = wilds4g8;
            return new GHC.Integer.Type.BNHash(dss4ga);
        }
        public static BigInteger newBigIntIHash_Entry(long dss4g0)
        {
            var wilds4g2 = mkBigInt(dss4g0, GHC.Prim.realWorldHash);
            var dss4g4 = wilds4g2; return dss4g4;
        }
        public static Closure wordToInteger_Entry(ulong ws4fS)
        {
            var dss4fT = (ws4fS > 9223372036854775807UL) ? 1 : 0;
            switch (dss4fT)
            {
                default:
                    {
                        var sats4fU = (long)ws4fS;
                        return new GHC.Integer.Type.SHash(sats4fU);
                    }
                case 1:
                    {
                        var wilds4fW = mkBigInt(ws4fS, GHC.Prim.realWorldHash);
                        var dss4fY = wilds4fW;
                        return new GHC.Integer.Type.BNHash(dss4fY);
                    }
            }
        }
        public static BigInteger newBigIntWHash_Entry(ulong x)
        {
            return x;
        }
        public static BigInteger mkBigInt(ulong x, GHC.Prim.StateHash sh)
        {
            return x;
        }
        public static BigInteger mkBigInt(long x, GHC.Prim.StateHash sh)
        {
            return x;
        }

        public static Closure shiftRInteger_Entry(Closure xs4fs, long is4ft)
        {
            switch(xs4fs.Eval())
            {
                default: throw new ImpossibleException();
                case SHash sHash:
                    return shiftRInteger_Entry(newBigIntI_Entry(sHash.x0), is4ft);
                case BNHash bN:
                    return new BNHash(bN.x0 >> (int)is4ft);
            }
        }
        public static Closure shiftLInteger_Entry(Closure xs4fp, long is4fq)
        {
            switch(xs4fp.Eval())
            {
                default: throw new ImpossibleException();
                case SHash sHash:
                    return shiftRInteger_Entry(newBigIntI_Entry(sHash.x0), is4fq);
                case BNHash bN:
                    return new BNHash(bN.x0 << (int)is4fq);
            }
        }
        public static Closure smallInteger_Entry(long etaB1)
        {
            return new GHC.Integer.Type.SHash(etaB1);
        }
        public sealed class BNHash : Data
        {
            public BigInteger x0;
            public BNHash(BigInteger x0) { this.x0 = x0; }
            public override int Tag => 2;
        }
        public sealed class SHash : Data
        {
            public long x0;
            public SHash(long x0) { this.x0 = x0; }
            public override int Tag => 1;
        }
    }
}
