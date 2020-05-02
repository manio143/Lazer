using System;
using System.Numerics;
using Lazer.Runtime;

namespace GHC.Integer
{
    public unsafe static class Type
    {
        internal static string lvls4il = "Integer/Type.hs:(230,5)-(233,16)|case";
        public static Function bNHash_DataCon;

        public static Function sHash_DataCon;

        internal static Function cmins4kd;

        internal static Function cmaxs4k9;

        public static Function geInteger;

        public static Function geIntegerHash;

        public static Function leInteger;

        public static Function leIntegerHash;

        public static Function gtInteger;

        public static Function gtIntegerHash;

        public static Function ltInteger;

        public static Function ltIntegerHash;

        public static Function testBitInteger;

        public static Function neqInteger;

        public static Function neqIntegerHash;

        public static Function modInteger;

        public static Function divInteger;

        public static Function divModInteger;

        public static Function eqInteger;

        public static Function eqIntegerHash;

        public static Function compareInteger;

        internal static Thunk lvls4im;

        public static Function absInteger;

        public static Function signumInteger;

        internal static Function wsignumIntegers4hO;

        public static Function compareBigIntHash;

        public static Function timesInteger;

        public static Function checkedMul;

        public static Function complementInteger;

        public static Function minusInteger;

        public static Function plusInteger;

        public static Function checkedAdd;

        public static Function negateInteger;

        public static Function negBigIntHash;

        public static Function notBigIntHash;

        public static Function xorInteger;

        public static Function xorBigIntHash;

        public static Function orInteger;

        public static Function orBigIntHash;

        public static Function andInteger;

        public static Function andBigIntHash;

        public static Function remInteger;

        public static Function quotInteger;

        public static Function quotRemInteger;

        public static Function remBigIntHash;

        public static Function quotBigIntHash;

        public static Function mulBigIntHash;

        public static Function addBigIntHash;

        public static Function integerToWord;

        public static Function bigToWordHash;

        public static Function hashInteger;

        public static Function integerToInt;

        public static Function bigToIntHash;

        public static Function newBigIntI;

        public static Function newBigIntIHash;

        public static Function wordToInteger;

        public static Function newBigIntWHash;

        public static Function shiftRInteger;

        public static Function shiftLInteger;

        public static Function smallInteger;

        internal static GHC.Integer.Type.SHash lvls4gK;
        internal static GHC.Integer.Type.SHash lvls4iW;
        internal static GHC.Integer.Type.SHash lvls4jv;
        public static GHC.Classes.CColEq fEqInteger;
        public static GHC.Classes.CColOrd fOrdInteger;

        static Type()
        {
            bNHash_DataCon = new Fun1<long, Closure>(&bNHash_DataCon_Entry);

            sHash_DataCon = new Fun1<long, Closure>(&sHash_DataCon_Entry);

            cmins4kd = new Fun2<Closure, Closure, Closure>(&cmins4kd_Entry);

            cmaxs4k9 = new Fun2<Closure, Closure, Closure>(&cmaxs4k9_Entry);

            geInteger = new Fun2<Closure, Closure, Closure>(&geInteger_Entry);

            geIntegerHash = new Fun2<Closure, Closure, long>(&geIntegerHash_Entry);

            leInteger = new Fun2<Closure, Closure, Closure>(&leInteger_Entry);

            leIntegerHash = new Fun2<Closure, Closure, long>(&leIntegerHash_Entry);

            gtInteger = new Fun2<Closure, Closure, Closure>(&gtInteger_Entry);

            gtIntegerHash = new Fun2<Closure, Closure, long>(&gtIntegerHash_Entry);

            ltInteger = new Fun2<Closure, Closure, Closure>(&ltInteger_Entry);

            ltIntegerHash = new Fun2<Closure, Closure, long>(&ltIntegerHash_Entry);

            testBitInteger = new Fun2<Closure, long, Closure>(&testBitInteger_Entry);

            neqInteger = new Fun2<Closure, Closure, Closure>(&neqInteger_Entry);

            neqIntegerHash = new Fun2<Closure, Closure, long>(&neqIntegerHash_Entry);

            modInteger = new Fun2<Closure, Closure, Closure>(&modInteger_Entry);

            divInteger = new Fun2<Closure, Closure, Closure>(&divInteger_Entry);

            divModInteger = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&divModInteger_Entry);

            eqInteger = new Fun2<Closure, Closure, Closure>(&eqInteger_Entry);

            eqIntegerHash = new Fun2<Closure, Closure, long>(&eqIntegerHash_Entry);

            compareInteger = new Fun2<Closure, Closure, Closure>(&compareInteger_Entry);

            lvls4im = new Updatable(&lvls4im_Entry);
            absInteger = new Fun1<Closure, Closure>(&absInteger_Entry);

            signumInteger = new Fun1<Closure, Closure>(&signumInteger_Entry);

            wsignumIntegers4hO = new Fun1<Closure, long>(&wsignumInteger_Entry);

            compareBigIntHash = new Fun2<BigInteger, BigInteger, long>(&compareBigIntHash_Entry);

            timesInteger = new Fun2<Closure, Closure, Closure>(&timesInteger_Entry);

            checkedMul = new Fun2<long, long, long>(&checkedMul_Entry);

            complementInteger = new Fun1<Closure, Closure>(&complementInteger_Entry);

            minusInteger = new Fun2<Closure, Closure, Closure>(&minusInteger_Entry);

            plusInteger = new Fun2<Closure, Closure, Closure>(&plusInteger_Entry);

            checkedAdd = new Fun2<long, long, long>(&checkedAdd_Entry);

            negateInteger = new Fun1<Closure, Closure>(&negateInteger_Entry);

            negBigIntHash = new Fun1<BigInteger, BigInteger>(&negBigIntHash_Entry);

            notBigIntHash = new Fun1<BigInteger, BigInteger>(&notBigIntHash_Entry);

            xorInteger = new Fun2<Closure, Closure, Closure>(&xorInteger_Entry);

            xorBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&xorBigIntHash_Entry);

            orInteger = new Fun2<Closure, Closure, Closure>(&orInteger_Entry);

            orBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&orBigIntHash_Entry);

            andInteger = new Fun2<Closure, Closure, Closure>(&andInteger_Entry);

            andBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&andBigIntHash_Entry);

            remInteger = new Fun2<Closure, Closure, Closure>(&remInteger_Entry);

            quotInteger = new Fun2<Closure, Closure, Closure>(&quotInteger_Entry);

            quotRemInteger = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&quotRemInteger_Entry);

            remBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&remBigIntHash_Entry);

            quotBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&quotBigIntHash_Entry);

            mulBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&mulBigIntHash_Entry);

            addBigIntHash = new Fun2<BigInteger, BigInteger, BigInteger>(&addBigIntHash_Entry);

            integerToWord = new Fun1<Closure, ulong>(&integerToWord_Entry);

            bigToWordHash = new Fun1<BigInteger, ulong>(&bigToWordHash_Entry);

            hashInteger = new Fun1<Closure, long>(&hashInteger_Entry);

            integerToInt = new Fun1<Closure, long>(&integerToInt_Entry);

            bigToIntHash = new Fun1<BigInteger, long>(&bigToIntHash_Entry);

            newBigIntI = new Fun1<long, Closure>(&newBigIntI_Entry);
            newBigIntIHash = new Fun1<long, BigInteger>(&newBigIntIHash_Entry);

            wordToInteger = new Fun1<ulong, Closure>(&wordToInteger_Entry);

            newBigIntWHash = new Fun1<ulong, BigInteger>(&newBigIntWHash_Entry);

            shiftRInteger = new Fun2<Closure, long, Closure>(&shiftRInteger_Entry);

            shiftLInteger = new Fun2<Closure, long, Closure>(&shiftLInteger_Entry);

            smallInteger = new Fun1<long, Closure>(&smallInteger_Entry);

            fOrdInteger = new GHC.Classes.CColOrd(null, GHC.Integer.Type.compareInteger, GHC.Integer.Type.ltInteger, GHC.Integer.Type.leInteger, GHC.Integer.Type.gtInteger, GHC.Integer.Type.geInteger, cmaxs4k9, cmins4kd);
            fEqInteger = new GHC.Classes.CColEq(GHC.Integer.Type.eqInteger, GHC.Integer.Type.neqInteger);
            lvls4jv = new GHC.Integer.Type.SHash(0);
            lvls4iW = new GHC.Integer.Type.SHash(1);
            lvls4gK = new GHC.Integer.Type.SHash(-1);
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
        public static Closure cmins4kd_Entry(Closure xs4ke, Closure ys4kf)
        {
            var wilds4kg = leIntegerHash_Entry(xs4ke, ys4kf);
            switch (wilds4kg)
            {
                default: { return ys4kf.Eval(); }
                case 1: { return xs4ke.Eval(); }
            }
        }
        public static Closure cmaxs4k9_Entry(Closure xs4ka, Closure ys4kb)
        {
            var wilds4kc = leIntegerHash_Entry(xs4ka, ys4kb);
            switch (wilds4kc)
            {
                default: { return xs4ka.Eval(); }
                case 1: { return ys4kb.Eval(); }
            }
        }
        public static Closure geInteger_Entry(Closure as4k6, Closure bs4k7)
        {
            var wilds4k8 = geIntegerHash_Entry(as4k6, bs4k7);
            return GHC.Types.isTrueHash_Entry(wilds4k8);
        }
        public static long geIntegerHash_Entry(Closure xs4k2, Closure ys4k3)
        {
            var wilds4k4 = compareInteger_Entry(xs4k2, ys4k3);
            var wilds4k4Tags4k4 = wilds4k4.Tag;
            switch (wilds4k4Tags4k4)
            {
                default: { return 1; }
                case 1: { return 0; }
            }
        }
        public static Closure leInteger_Entry(Closure as4jY, Closure bs4jZ)
        {
            var wilds4k0 = leIntegerHash_Entry(as4jY, bs4jZ);
            return GHC.Types.isTrueHash_Entry(wilds4k0);
        }
        public static long leIntegerHash_Entry(Closure xs4jU, Closure ys4jV)
        {
            var wilds4jW = compareInteger_Entry(xs4jU, ys4jV);
            var wilds4jWTags4jW = wilds4jW.Tag;
            switch (wilds4jWTags4jW)
            {
                default: { return 1; }
                case 3: { return 0; }
            }
        }
        public static Closure gtInteger_Entry(Closure as4jQ, Closure bs4jR)
        {
            var wilds4jS = gtIntegerHash_Entry(as4jQ, bs4jR);
            return GHC.Types.isTrueHash_Entry(wilds4jS);
        }
        public static long gtIntegerHash_Entry(Closure xs4jM, Closure ys4jN)
        {
            var wilds4jO = compareInteger_Entry(xs4jM, ys4jN);
            var wilds4jOTags4jO = wilds4jO.Tag;
            switch (wilds4jOTags4jO)
            {
                default: { return 0; }
                case 3: { return 1; }
            }
        }
        public static Closure ltInteger_Entry(Closure as4jI, Closure bs4jJ)
        {
            var wilds4jK = ltIntegerHash_Entry(as4jI, bs4jJ);
            return GHC.Types.isTrueHash_Entry(wilds4jK);
        }
        public static long ltIntegerHash_Entry(Closure xs4jE, Closure ys4jF)
        {
            var wilds4jG = compareInteger_Entry(xs4jE, ys4jF);
            var wilds4jGTags4jG = wilds4jG.Tag;
            switch (wilds4jGTags4jG)
            {
                default: { return 0; }
                case 1: { return 1; }
            }
        }
        public static Closure testBitInteger_Entry(Closure xs4jx, long is4jy)
        {
            var sats4jz = shiftLInteger_Entry(lvls4iW, is4jy);
            var sats4jA = andInteger_Entry(xs4jx, sats4jz);
            var wilds4jB = neqIntegerHash_Entry(sats4jA, lvls4jv);
            return GHC.Types.isTrueHash_Entry(wilds4jB);
        }
        public static Closure neqInteger_Entry(Closure as4js, Closure bs4jt)
        {
            var wilds4ju = neqIntegerHash_Entry(as4js, bs4jt);
            return GHC.Types.isTrueHash_Entry(wilds4ju);
        }
        public static long neqIntegerHash_Entry(Closure xs4jo, Closure ys4jp)
        {
            var wilds4jq = compareInteger_Entry(xs4jo, ys4jp);
            var wilds4jqTags4jq = wilds4jq.Tag;
            switch (wilds4jqTags4jq)
            {
                default: { return 1; }
                case 2: { return 0; }
            }
        }
        public static Closure modInteger_Entry(Closure ns4ji, Closure ds4jj)
        {
            var dss4jk = divModInteger_Entry(ns4ji, ds4jj);
            var dss4jk_RawTuple = dss4jk;
            var ipvs4jl = dss4jk_RawTuple.x0;
            var ipvs4jm = dss4jk_RawTuple.x1; return ipvs4jm.Eval();
        }
        public static Closure divInteger_Entry(Closure ns4jc, Closure ds4jd)
        {
            var dss4je = divModInteger_Entry(ns4jc, ds4jd);
            var dss4je_RawTuple = dss4je;
            var ipvs4jf = dss4je_RawTuple.x0;
            var ipvs4jg = dss4je_RawTuple.x1; return ipvs4jf.Eval();
        }
        public static (Closure x0, Closure x1) divModInteger_Entry(Closure ns4iY, Closure ds4iZ)
        {
            var dss4j0 = quotRemInteger_Entry(ns4iY, ds4iZ);
            var dss4j0_RawTuple = dss4j0;
            var ipvs4j1 = dss4j0_RawTuple.x0;
            var ipvs4j2 = dss4j0_RawTuple.x1;
            var wws4j3 = wsignumInteger_Entry(ipvs4j2);
            var wws4j4 = wsignumInteger_Entry(ds4iZ);
            var sats4j6 = new GHC.Integer.Type.SHash(wws4j4);
            var sats4j7 = negateInteger_Entry(sats4j6);
            var sats4j5 = new GHC.Integer.Type.SHash(wws4j3);
            var wilds4j8 = eqIntegerHash_Entry(sats4j5, sats4j7);
            switch (wilds4j8)
            {
                default: { return (ipvs4j1, ipvs4j2); }
                case 1:
                    {
                        var sat_Frees4ja = (ds4iZ, ipvs4j2);
                        var sats4ja = new Updatable<(Closure x0, Closure x1)>(&sats4ja_Entry, sat_Frees4ja);
                        var sats4j9 = new Updatable<Closure>(&sats4j9_Entry, ipvs4j1);
                        return (sats4j9, sats4ja);
                    }
            }
        }
        public static Closure sats4j9_Entry(in Closure ipvs4j1)
        {
            return minusInteger_Entry(ipvs4j1, lvls4iW);
        }
        public static Closure sats4ja_Entry(in (Closure x0, Closure x1) sat_Frees4ja)
        {
            var ds4iZ = sat_Frees4ja.x0;
            var ipvs4j2 = sat_Frees4ja.x1;
            return plusInteger_Entry(ipvs4j2, ds4iZ);
        }
        public static Closure eqInteger_Entry(Closure as4iT, Closure bs4iU)
        {
            var wilds4iV = eqIntegerHash_Entry(as4iT, bs4iU);
            return GHC.Types.isTrueHash_Entry(wilds4iV);
        }
        public static long eqIntegerHash_Entry(Closure xs4iP, Closure ys4iQ)
        {
            var wilds4iR = compareInteger_Entry(xs4iP, ys4iQ);
            var wilds4iRTags4iR = wilds4iR.Tag;
            switch (wilds4iRTags4iR)
            {
                default: { return 0; }
                case 2: { return 1; }
            }
        }
        public static Closure compareInteger_Entry(Closure dss4io, Closure dss4ip)
        {
            var wilds4iq = dss4io.Eval();
            switch (wilds4iq)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4iq_SHash:
                    {
                        var xs4ir = wilds4iq_SHash.x0;
                        var wilds4is = dss4ip.Eval();
                        switch (wilds4is)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4is_SHash:
                                {
                                    var ys4it = wilds4is_SHash.x0;
                                    return GHC.Classes.compareIntHash_Entry(xs4ir, ys4it);
                                }
                            case GHC.Integer.Type.BNHash wilds4is_BNHash:
                                {
                                    var ipvs4iu = wilds4is_BNHash.x0;
                                    var wilds4iw = mkBigInt(xs4ir, GHC.Prim.realWorldHash);
                                    var dss4iy = wilds4iw;
                                    var sats4iz = new GHC.Integer.Type.BNHash(dss4iy);
                                    return compareInteger_Entry(sats4iz, wilds4is);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4iq_BNHash:
                    {
                        var bns4iA = wilds4iq_BNHash.x0;
                        var wilds4iB = dss4ip.Eval();
                        switch (wilds4iB)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4iB_SHash:
                                {
                                    var ipvs4iC = wilds4iB_SHash.x0;
                                    var wilds4iE = mkBigInt(ipvs4iC, GHC.Prim.realWorldHash);
                                    var dss4iG = wilds4iE;
                                    var sats4iH = new GHC.Integer.Type.BNHash(dss4iG);
                                    return compareInteger_Entry(wilds4iq, sats4iH);
                                }
                            case GHC.Integer.Type.BNHash wilds4iB_BNHash:
                                {
                                    var bms4iI = wilds4iB_BNHash.x0;
                                    var wilds4iK = compareBigInt(bns4iA, bms4iI, GHC.Prim.realWorldHash);
                                    var dss4iM = wilds4iK;
                                    var dss4iN = dss4iM;
                                    switch (dss4iN)
                                    {
                                        default: { return lvls4im.Eval(); }
                                        case -1: { return GHC.Types.lT_DataCon.Eval(); }
                                        case 0: { return GHC.Types.eQ_DataCon.Eval(); }
                                        case 1: { return GHC.Types.gT_DataCon.Eval(); }
                                    }
                                }
                        }
                    }
            }
        }
        public static long compareBigInt(BigInteger a, BigInteger b, GHC.Prim.StateHash _)
        {
            return compareBigIntHash_Entry(a, b);
        }
        public static Closure lvls4im_Entry()
        {
            throw new System.Exception(lvls4il);
        }
        public static Closure absInteger_Entry(Closure is4i7)
        {
            var wilds4i8 = is4i7.Eval();
            switch (wilds4i8)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4i8_SHash:
                    {
                        var xs4i9 = wilds4i8_SHash.x0;
                        var dss4ia = (xs4i9 < 0) ? 1 : 0;
                        switch (dss4ia)
                        {
                            default: { return wilds4i8.Eval(); }
                            case 1: { return negateInteger_Entry(wilds4i8); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4i8_BNHash:
                    {
                        var bns4ib = wilds4i8_BNHash.x0;
                        var wilds4id = mkBigInt(0, GHC.Prim.realWorldHash);
                        var dss4if = wilds4id;
                        var wilds4ih = compareBigInt(bns4ib, dss4if, GHC.Prim.realWorldHash);
                        var dss4ij = wilds4ih;
                        var wilds4ik = dss4ij;
                        switch (wilds4ik)
                        {
                            default: { return wilds4i8.Eval(); }
                            case -1: { return negateInteger_Entry(wilds4i8); }
                        }
                    }
            }
        }
        public static Closure signumInteger_Entry(Closure ws4i4)
        {
            var wws4i5 = wsignumInteger_Entry(ws4i4);
            return new GHC.Integer.Type.SHash(wws4i5);
        }
        public static long wsignumInteger_Entry(Closure ws4hP)
        {
            var wilds4hQ = ws4hP.Eval();
            switch (wilds4hQ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4hQ_SHash:
                    {
                        var xs4hR = wilds4hQ_SHash.x0;
                        var dss4hS = (xs4hR < 0) ? 1 : 0;
                        switch (dss4hS)
                        {
                            default:
                                {
                                    var wilds4hT = xs4hR;
                                    switch (wilds4hT)
                                    {
                                        default: { return 1; }
                                        case 0: { return 0; }
                                    }
                                }
                            case 1: { return -1; }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4hQ_BNHash:
                    {
                        var bns4hU = wilds4hQ_BNHash.x0;
                        var wilds4hW = mkBigInt(0, GHC.Prim.realWorldHash);
                        var dss4hY = wilds4hW;
                        var wilds4i0 = compareBigInt(bns4hU, dss4hY, GHC.Prim.realWorldHash);
                        var dss4i2 = wilds4i0; return dss4i2;
                    }
            }
        }
        public static long compareBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return BigInteger.Compare(a, b);
        }
        public static Closure timesInteger_Entry(Closure xs4gV, Closure zs4gW)
        {
            var wilds4hD = zs4gW.Eval();
            switch (wilds4hD)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4hD_SHash:
                    {
                        var dss4hE = wilds4hD_SHash.x0;
                        var dss4hF = dss4hE;
                        switch (dss4hF)
                        {
                            default:
                                {
                                    return fails4gX_Entry(xs4gV, zs4gW, GHC.Prim.voidHash);
                                }
                            case 0: { return wilds4hD.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4hD_BNHash:
                    {
                        return fails4gX_Entry(xs4gV, zs4gW, GHC.Prim.voidHash);
                    }
            }
        }
        public static Closure fails4gX_Entry(Closure x0, Closure x1, GHC.Prim.Void void0E)
        {
            var xs4gV = x0;
            var zs4gW = x1;
            var wilds4gZ = xs4gV.Eval();
            switch (wilds4gZ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4gZ_SHash:
                    {
                        var dss4h0 = wilds4gZ_SHash.x0;
                        var dss4h1 = dss4h0;
                        switch (dss4h1)
                        {
                            default:
                                {
                                    var wilds4h2 = zs4gW.Eval();
                                    switch (wilds4h2)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.SHash wilds4h2_SHash:
                                            {
                                                var ys4h3 = wilds4h2_SHash.x0;
                                                var wilds4h5 = checkedMul_Entry(dss4h1, ys4h3);
                                                var dss4h7 = wilds4h5;
                                                var wilds4h8 = dss4h7;
                                                switch (wilds4h8)
                                                {
                                                    default:
                                                        {
                                                            var sats4h9 = dss4h1 * ys4h3;
                                                            return new GHC.Integer.Type.SHash(sats4h9);
                                                        }
                                                    case 0:
                                                        {
                                                            var wilds4hb = mkBigInt(ys4h3, GHC.Prim.realWorldHash);
                                                            var dss4hd = wilds4hb;
                                                            var sats4hj = new GHC.Integer.Type.BNHash(dss4hd);
                                                            var sats4hi = new Updatable<long>(&sats4hi_Entry, dss4h1);
                                                            return timesInteger_Entry(sats4hi, sats4hj);
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.BNHash wilds4h2_BNHash:
                                            {
                                                var ipvs4hk = wilds4h2_BNHash.x0;
                                                var sats4hp = new Updatable<long>(&sats4hp_Entry, dss4h1);
                                                return timesInteger_Entry(sats4hp, wilds4h2);
                                            }
                                    }
                                }
                            case 0: { return wilds4gZ.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4gZ_BNHash:
                    {
                        var bns4hq = wilds4gZ_BNHash.x0;
                        var wilds4hr = zs4gW.Eval();
                        switch (wilds4hr)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4hr_SHash:
                                {
                                    var ipvs4hs = wilds4hr_SHash.x0;
                                    var wilds4hu = mkBigInt(ipvs4hs, GHC.Prim.realWorldHash);
                                    var dss4hw = wilds4hu;
                                    var sats4hx = new GHC.Integer.Type.BNHash(dss4hw);
                                    return timesInteger_Entry(wilds4gZ, sats4hx);
                                }
                            case GHC.Integer.Type.BNHash wilds4hr_BNHash:
                                {
                                    var bms4hy = wilds4hr_BNHash.x0;
                                    var wilds4hA = mulBigIntHash_Entry(bns4hq, bms4hy);
                                    var dss4hC = wilds4hA;
                                    return new GHC.Integer.Type.BNHash(dss4hC);
                                }
                        }
                    }
            }
        }
        public static Closure sats4hi_Entry(in long dss4h1)
        {
            var wilds4hf = mkBigInt(dss4h1, GHC.Prim.realWorldHash);
            var dss4hh = wilds4hf;
            return new GHC.Integer.Type.BNHash(dss4hh);
        }
        public static Closure sats4hp_Entry(in long dss4h1)
        {
            var wilds4hm = mkBigInt(dss4h1, GHC.Prim.realWorldHash);
            var dss4ho = wilds4hm;
            return new GHC.Integer.Type.BNHash(dss4ho);
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
        public static Closure complementInteger_Entry(Closure xs4gM)
        {
            return minusInteger_Entry(lvls4gK, xs4gM);
        }
        public static Closure minusInteger_Entry(Closure i1s4gH, Closure i2s4gI)
        {
            var sats4gJ = negateInteger_Entry(i2s4gI);
            return plusInteger_Entry(i1s4gH, sats4gJ);
        }
        public static Closure plusInteger_Entry(Closure xs4fU, Closure dss4fV)
        {
            var wilds4gC = dss4fV.Eval();
            switch (wilds4gC)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4gC_SHash:
                    {
                        var dss4gD = wilds4gC_SHash.x0;
                        var dss4gE = dss4gD;
                        switch (dss4gE)
                        {
                            default:
                                {
                                    return fails4fW_Entry(xs4fU, dss4fV, GHC.Prim.voidHash);
                                }
                            case 0: { return xs4fU.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4gC_BNHash:
                    {
                        return fails4fW_Entry(xs4fU, dss4fV, GHC.Prim.voidHash);
                    }
            }
        }
        public static Closure fails4fW_Entry(Closure x0, Closure x1, GHC.Prim.Void void0E)
        {
            var xs4fU = x0;
            var dss4fV = x1;
            var wilds4fY = xs4fU.Eval();
            switch (wilds4fY)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4fY_SHash:
                    {
                        var dss4fZ = wilds4fY_SHash.x0;
                        var dss4g0 = dss4fZ;
                        switch (dss4g0)
                        {
                            default:
                                {
                                    var wilds4g1 = dss4fV.Eval();
                                    switch (wilds4g1)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.SHash wilds4g1_SHash:
                                            {
                                                var ys4g2 = wilds4g1_SHash.x0;
                                                var wilds4g4 = checkedAdd_Entry(dss4g0, ys4g2);
                                                var dss4g6 = wilds4g4;
                                                var wilds4g7 = dss4g6;
                                                switch (wilds4g7)
                                                {
                                                    default:
                                                        {
                                                            var sats4g8 = dss4g0 + ys4g2;
                                                            return new GHC.Integer.Type.SHash(sats4g8);
                                                        }
                                                    case 0:
                                                        {
                                                            var wilds4ga = mkBigInt(dss4g0, GHC.Prim.realWorldHash);
                                                            var dss4gc = wilds4ga;
                                                            var wilds4ge = mkBigInt(ys4g2, GHC.Prim.realWorldHash);
                                                            var dss4gg = wilds4ge;
                                                            var sats4gi = new GHC.Integer.Type.BNHash(dss4gg);
                                                            var sats4gh = new GHC.Integer.Type.BNHash(dss4gc);
                                                            return plusInteger_Entry(sats4gh, sats4gi);
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.BNHash wilds4g1_BNHash:
                                            {
                                                var ipvs4gj = wilds4g1_BNHash.x0;
                                                var wilds4gl = mkBigInt(dss4g0, GHC.Prim.realWorldHash);
                                                var dss4gn = wilds4gl;
                                                var sats4go = new GHC.Integer.Type.BNHash(dss4gn);
                                                return plusInteger_Entry(sats4go, wilds4g1);
                                            }
                                    }
                                }
                            case 0: { return dss4fV.Eval(); }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4fY_BNHash:
                    {
                        var bns4gp = wilds4fY_BNHash.x0;
                        var wilds4gq = dss4fV.Eval();
                        switch (wilds4gq)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4gq_SHash:
                                {
                                    var ipvs4gr = wilds4gq_SHash.x0;
                                    var wilds4gt = mkBigInt(ipvs4gr, GHC.Prim.realWorldHash);
                                    var dss4gv = wilds4gt;
                                    var sats4gw = new GHC.Integer.Type.BNHash(dss4gv);
                                    return plusInteger_Entry(wilds4fY, sats4gw);
                                }
                            case GHC.Integer.Type.BNHash wilds4gq_BNHash:
                                {
                                    var bms4gx = wilds4gq_BNHash.x0;
                                    var wilds4gz = addBigIntHash_Entry(bns4gp, bms4gx);
                                    var dss4gB = wilds4gz;
                                    return new GHC.Integer.Type.BNHash(dss4gB);
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
        public static Closure negateInteger_Entry(Closure dss4fx)
        {
            var wilds4fy = dss4fx.Eval();
            switch (wilds4fy)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4fy_SHash:
                    {
                        var is4fz = wilds4fy_SHash.x0;
                        var wilds4fA = is4fz;
                        switch (wilds4fA)
                        {
                            default:
                                {
                                    var sats4fB = -wilds4fA;
                                    return new GHC.Integer.Type.SHash(sats4fB);
                                }
                            case -9223372036854775808:
                                {
                                    var wilds4fD = mkBigInt(-9223372036854775808, GHC.Prim.realWorldHash);
                                    var dss4fF = wilds4fD;
                                    var sats4fG = new GHC.Integer.Type.BNHash(dss4fF);
                                    return negateInteger_Entry(sats4fG);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4fy_BNHash:
                    {
                        var bns4fH = wilds4fy_BNHash.x0;
                        var wilds4fJ = negBigIntHash_Entry(bns4fH);
                        var dss4fL = wilds4fJ;
                        return new GHC.Integer.Type.BNHash(dss4fL);
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
        public static Closure xorInteger_Entry(Closure dss4eU, Closure dss4eV)
        {
            var wilds4eW = dss4eU.Eval();
            switch (wilds4eW)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4eW_SHash:
                    {
                        var is4eX = wilds4eW_SHash.x0;
                        var wilds4eY = dss4eV.Eval();
                        switch (wilds4eY)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4eY_SHash:
                                {
                                    var js4eZ = wilds4eY_SHash.x0;
                                    var sats4f0 = is4eX ^ js4eZ;
                                    return new GHC.Integer.Type.SHash(sats4f0);
                                }
                            case GHC.Integer.Type.BNHash wilds4eY_BNHash:
                                {
                                    var ipvs4f1 = wilds4eY_BNHash.x0;
                                    var wilds4f3 = mkBigInt(is4eX, GHC.Prim.realWorldHash);
                                    var dss4f5 = wilds4f3;
                                    var sats4f6 = new GHC.Integer.Type.BNHash(dss4f5);
                                    return xorInteger_Entry(sats4f6, wilds4eY);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4eW_BNHash:
                    {
                        var bns4f7 = wilds4eW_BNHash.x0;
                        var wilds4f8 = dss4eV.Eval();
                        switch (wilds4f8)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4f8_SHash:
                                {
                                    var ipvs4f9 = wilds4f8_SHash.x0;
                                    var wilds4fb = mkBigInt(ipvs4f9, GHC.Prim.realWorldHash);
                                    var dss4fd = wilds4fb;
                                    var sats4fe = new GHC.Integer.Type.BNHash(dss4fd);
                                    return xorInteger_Entry(wilds4eW, sats4fe);
                                }
                            case GHC.Integer.Type.BNHash wilds4f8_BNHash:
                                {
                                    var bms4ff = wilds4f8_BNHash.x0;
                                    var wilds4fh = xorBigIntHash_Entry(bns4f7, bms4ff);
                                    var dss4fj = wilds4fh;
                                    return new GHC.Integer.Type.BNHash(dss4fj);
                                }
                        }
                    }
            }
        }
        public static BigInteger xorBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a ^ b;
        }
        public static Closure orInteger_Entry(Closure dss4em, Closure dss4en)
        {
            var wilds4eo = dss4em.Eval();
            switch (wilds4eo)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4eo_SHash:
                    {
                        var is4ep = wilds4eo_SHash.x0;
                        var wilds4eq = dss4en.Eval();
                        switch (wilds4eq)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4eq_SHash:
                                {
                                    var js4er = wilds4eq_SHash.x0;
                                    var sats4es = is4ep | js4er;
                                    return new GHC.Integer.Type.SHash(sats4es);
                                }
                            case GHC.Integer.Type.BNHash wilds4eq_BNHash:
                                {
                                    var ipvs4et = wilds4eq_BNHash.x0;
                                    var wilds4ev = mkBigInt(is4ep, GHC.Prim.realWorldHash);
                                    var dss4ex = wilds4ev;
                                    var sats4ey = new GHC.Integer.Type.BNHash(dss4ex);
                                    return orInteger_Entry(sats4ey, wilds4eq);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4eo_BNHash:
                    {
                        var bns4ez = wilds4eo_BNHash.x0;
                        var wilds4eA = dss4en.Eval();
                        switch (wilds4eA)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4eA_SHash:
                                {
                                    var ipvs4eB = wilds4eA_SHash.x0;
                                    var wilds4eD = mkBigInt(ipvs4eB, GHC.Prim.realWorldHash);
                                    var dss4eF = wilds4eD;
                                    var sats4eG = new GHC.Integer.Type.BNHash(dss4eF);
                                    return orInteger_Entry(wilds4eo, sats4eG);
                                }
                            case GHC.Integer.Type.BNHash wilds4eA_BNHash:
                                {
                                    var bms4eH = wilds4eA_BNHash.x0;
                                    var wilds4eJ = orBigIntHash_Entry(bns4ez, bms4eH);
                                    var dss4eL = wilds4eJ;
                                    return new GHC.Integer.Type.BNHash(dss4eL);
                                }
                        }
                    }
            }
        }
        public static BigInteger orBigIntHash_Entry(BigInteger a, BigInteger b)
        {
            return a | b;
        }
        public static Closure andInteger_Entry(Closure dss4dO, Closure dss4dP)
        {
            var wilds4dQ = dss4dO.Eval();
            switch (wilds4dQ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4dQ_SHash:
                    {
                        var is4dR = wilds4dQ_SHash.x0;
                        var wilds4dS = dss4dP.Eval();
                        switch (wilds4dS)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4dS_SHash:
                                {
                                    var js4dT = wilds4dS_SHash.x0;
                                    var sats4dU = is4dR & js4dT;
                                    return new GHC.Integer.Type.SHash(sats4dU);
                                }
                            case GHC.Integer.Type.BNHash wilds4dS_BNHash:
                                {
                                    var ipvs4dV = wilds4dS_BNHash.x0;
                                    var wilds4dX = mkBigInt(is4dR, GHC.Prim.realWorldHash);
                                    var dss4dZ = wilds4dX;
                                    var sats4e0 = new GHC.Integer.Type.BNHash(dss4dZ);
                                    return andInteger_Entry(sats4e0, wilds4dS);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4dQ_BNHash:
                    {
                        var bns4e1 = wilds4dQ_BNHash.x0;
                        var wilds4e2 = dss4dP.Eval();
                        switch (wilds4e2)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4e2_SHash:
                                {
                                    var ipvs4e3 = wilds4e2_SHash.x0;
                                    var wilds4e5 = mkBigInt(ipvs4e3, GHC.Prim.realWorldHash);
                                    var dss4e7 = wilds4e5;
                                    var sats4e8 = new GHC.Integer.Type.BNHash(dss4e7);
                                    return andInteger_Entry(wilds4dQ, sats4e8);
                                }
                            case GHC.Integer.Type.BNHash wilds4e2_BNHash:
                                {
                                    var bms4e9 = wilds4e2_BNHash.x0;
                                    var wilds4eb = andBigIntHash_Entry(bns4e1, bms4e9);
                                    var dss4ed = wilds4eb;
                                    return new GHC.Integer.Type.BNHash(dss4ed);
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
        public static Closure remInteger_Entry(Closure xs4dB, Closure ys4dC)
        {
            var dss4dD = quotRemInteger_Entry(xs4dB, ys4dC);
            var dss4dD_RawTuple = dss4dD;
            var ipvs4dE = dss4dD_RawTuple.x0;
            var ipvs4dF = dss4dD_RawTuple.x1; return ipvs4dF.Eval();
        }
        public static Closure quotInteger_Entry(Closure xs4dv, Closure ys4dw)
        {
            var dss4dx = quotRemInteger_Entry(xs4dv, ys4dw);
            var dss4dx_RawTuple = dss4dx;
            var ipvs4dy = dss4dx_RawTuple.x0;
            var ipvs4dz = dss4dx_RawTuple.x1; return ipvs4dy.Eval();
        }
        public static (Closure x0, Closure x1) quotRemInteger_Entry(Closure dss4cU, Closure dss4cV)
        {
            var wilds4cW = dss4cU.Eval();
            switch (wilds4cW)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4cW_SHash:
                    {
                        var is4cX = wilds4cW_SHash.x0;
                        var wilds4cY = dss4cV.Eval();
                        switch (wilds4cY)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4cY_SHash:
                                {
                                    var js4cZ = wilds4cY_SHash.x0;
                                    var ipvs4d1 = Math.DivRem(is4cX, js4cZ, out long ipvs4d2);
                                    var sats4d4 = new GHC.Integer.Type.SHash(ipvs4d2);
                                    var sats4d3 = new GHC.Integer.Type.SHash(ipvs4d1);
                                    return (sats4d3, sats4d4);
                                }
                            case GHC.Integer.Type.BNHash wilds4cY_BNHash:
                                {
                                    var ipvs4d5 = wilds4cY_BNHash.x0;
                                    var wilds4d7 = mkBigInt(is4cX, GHC.Prim.realWorldHash);
                                    var dss4d9 = wilds4d7;
                                    var sats4da = new GHC.Integer.Type.BNHash(dss4d9);
                                    return quotRemInteger_Entry(sats4da, wilds4cY);
                                }
                        }
                    }
                case GHC.Integer.Type.BNHash wilds4cW_BNHash:
                    {
                        var bns4db = wilds4cW_BNHash.x0;
                        var wilds4dc = dss4cV.Eval();
                        switch (wilds4dc)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.SHash wilds4dc_SHash:
                                {
                                    var ipvs4dd = wilds4dc_SHash.x0;
                                    var wilds4df = mkBigInt(ipvs4dd, GHC.Prim.realWorldHash);
                                    var dss4dh = wilds4df;
                                    var sats4di = new GHC.Integer.Type.BNHash(dss4dh);
                                    return quotRemInteger_Entry(wilds4cW, sats4di);
                                }
                            case GHC.Integer.Type.BNHash wilds4dc_BNHash:
                                {
                                    var bms4dj = wilds4dc_BNHash.x0;
                                    var wilds4dl = remBigIntHash_Entry(bns4db, bms4dj);
                                    var dss4dn = wilds4dl;
                                    var wilds4dp = quotBigIntHash_Entry(bns4db, bms4dj);
                                    var dss4dr = wilds4dp;
                                    var sats4dt = new GHC.Integer.Type.BNHash(dss4dn);
                                    var sats4ds = new GHC.Integer.Type.BNHash(dss4dr);
                                    return (sats4ds, sats4dt);
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
        public static ulong integerToWord_Entry(Closure dss4cn)
        {
            var wilds4co = dss4cn.Eval();
            switch (wilds4co)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4co_SHash:
                    {
                        var is4cp = wilds4co_SHash.x0; return (ulong)is4cp;
                    }
                case GHC.Integer.Type.BNHash wilds4co_BNHash:
                    {
                        var bns4cq = wilds4co_BNHash.x0;
                        return bigToWordHash_Entry(bns4cq);
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
        public static long integerToInt_Entry(Closure dss4cb)
        {
            var wilds4cc = dss4cb.Eval();
            switch (wilds4cc)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.SHash wilds4cc_SHash:
                    {
                        var is4cd = wilds4cc_SHash.x0; return is4cd;
                    }
                case GHC.Integer.Type.BNHash wilds4cc_BNHash:
                    {
                        var bns4ce = wilds4cc_BNHash.x0;
                        return bigToIntHash_Entry(bns4ce);
                    }
            }
        }
        public static long bigToIntHash_Entry(BigInteger x)
        {
            return (long)x;
        }
        public static Closure newBigIntI_Entry(long is4bZ)
        {
            var wilds4c1 = mkBigInt(is4bZ, GHC.Prim.realWorldHash);
            var dss4c3 = wilds4c1;
            return new GHC.Integer.Type.BNHash(dss4c3);
        }
        public static BigInteger newBigIntIHash_Entry(long dss4bT)
        {
            var wilds4bV = mkBigInt(dss4bT, GHC.Prim.realWorldHash);
            var dss4bX = wilds4bV; return dss4bX;
        }
        public static Closure wordToInteger_Entry(ulong ws4bL)
        {
            var dss4bM = (ws4bL > 9223372036854775807UL) ? 1 : 0;
            switch (dss4bM)
            {
                default:
                    {
                        var sats4bN = (long)ws4bL;
                        return new GHC.Integer.Type.SHash(sats4bN);
                    }
                case 1:
                    {
                        var wilds4bP = mkBigInt(ws4bL, GHC.Prim.realWorldHash);
                        var dss4bR = wilds4bP;
                        return new GHC.Integer.Type.BNHash(dss4bR);
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
        public static double doubleFromInteger_Entry(Closure i)
        {
            switch(i.Eval())
            {
                default: throw new ImpossibleException();
                case SHash sHash: return (double)sHash.x0;
                case BNHash bNHash: return (double)bNHash.x0;
            }
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
