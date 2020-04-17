using System;
using Lazer.Runtime;

namespace GHC.Integer
{
    public unsafe static class Type
    {
        public static Fun some_DataCon;

        public static Fun negative_DataCon;

        public static Fun positive_DataCon;

        public static Fun cons_DataCon;

        public static Fun encodeFloatInteger;

        internal static Fun fs77K;

        public static Fun encodeFloatHash;

        public static Fun encodeDoubleInteger;

        internal static Fun fs77i;

        public static Fun encodeDoubleHash;

        public static Fun xorInteger;

        public static Fun xorDigits;

        public static Fun testBitInteger;

        public static Fun andInteger;

        public static Fun mkInteger;

        internal static Fun fs74H;

        public static Fun orInteger;

        public static Fun orDigits;

        public static Fun andDigitsOnes;

        public static Fun andDigits;

        public static Fun remInteger;

        public static Fun quotInteger;

        public static Fun modInteger;

        public static Fun divInteger;

        public static Fun divModInteger;

        public static Fun quotRemInteger;

        public static Fun quotRemPositive;

        internal static Fun gs71E;

        public static Fun some;

        public static Fun shiftLInteger;

        public static Fun shiftLPositive;

        public static Fun shiftRInteger;

        public static Fun shiftRPositive;

        public static Fun smallShiftRPositive;

        public static Fun smallShiftLPositive;

        public static Fun decodeDoubleInteger;

        public static Fun complementInteger;

        public static Fun minusInteger;

        public static Fun plusInteger;

        internal static Fun cmins6ZV;

        internal static Fun cmaxs6ZR;

        public static Fun geInteger;

        public static Fun geIntegerHash;

        public static Fun leInteger;

        public static Fun leIntegerHash;

        public static Fun gtInteger;

        public static Fun gtIntegerHash;

        public static Fun ltInteger;

        public static Fun ltIntegerHash;

        public static Fun neqInteger;

        public static Fun neqIntegerHash;

        public static Fun eqInteger;

        public static Fun eqIntegerHash;

        public static Fun compareInteger;

        public static Fun comparePositive;

        public static Fun digitsToInteger;

        public static Fun digitsToNegativeInteger;

        public static Fun removeZeroTails;

        public static Fun digitsMaybeZeroToInteger;

        public static Fun timesInteger;

        public static Fun timesPositive;

        public static Fun timesDigit;

        public static Fun floatFromInteger;

        public static Fun floatFromPositive;

        public static Fun doubleFromInteger;

        public static Fun doubleFromPositive;

        public static Fun splitHalves;

        public static Fun highHalfShift;

        public static Fun lowHalfMask;

        public static Fun twosComplementPositive;

        internal static Fun twosComplementPositives6W4;

        public static Fun minusPositive;

        public static Fun plusPositive;

        internal static Fun addWithCarrys6V2;

        internal static Updatable lvls6UY;

        public static Fun succPositive;

        internal static Fun wsuccPositives6UI;

        public static Fun fullBound;

        public static Fun halfBoundUp;

        public static Fun signumInteger;

        public static Fun absInteger;

        public static Fun decodeFloatInteger;

        public static Fun smallInteger;

        public static Fun negateInteger;

        public static Fun flipBits;

        internal static Fun flipBitss6U5;

        public static Fun flipBitsDigits;

        public static Fun hashInteger;

        public static Fun integerToInt;

        public static Fun integerToWord;

        public static Fun wordToInteger;

        public static GHC.Integer.Type.Some errorPositive;
        public static GHC.Integer.Type.Positive errorInteger;
        public static GHC.Integer.Type.Some onePositive;
        public static GHC.Integer.Type.Negative negativeOneInteger;
        public static GHC.Integer.Type.Positive oneInteger;
        public static GHC.Integer.Type.Some twoToTheThirtytwoPositive;
        public static GHC.Integer.Type.Positive twoToTheThirtytwoInteger;
        public static GHC.Classes.CColEq fEqInteger;
        public static GHC.Classes.CColOrd fOrdInteger;
        public static GHC.Integer.Type.Nil nil_DataCon;
        public static GHC.Integer.Type.Naught naught_DataCon;
        public static GHC.Integer.Type.None none_DataCon;

        static Type()
        {
            some_DataCon = new Fun(2, CLR.LoadFunctionPointer<ulong, Closure, Closure>(some_DataCon_Entry));

            negative_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(negative_DataCon_Entry));

            positive_DataCon = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(positive_DataCon_Entry));

            cons_DataCon = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cons_DataCon_Entry));

            encodeFloatInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, float>(encodeFloatInteger_Entry));

            fs77K = new Fun(3, CLR.LoadFunctionPointer<float, Closure, long, float>(fs77K_Entry));

            encodeFloatHash = new Fun(2, CLR.LoadFunctionPointer<ulong, long, float>(encodeFloatHash_Entry));

            encodeDoubleInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, double>(encodeDoubleInteger_Entry));

            fs77i = new Fun(3, CLR.LoadFunctionPointer<double, Closure, long, double>(fs77i_Entry));

            encodeDoubleHash = new Fun(2, CLR.LoadFunctionPointer<ulong, long, double>(encodeDoubleHash_Entry));

            xorInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(xorInteger_Entry));

            xorDigits = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(xorDigits_Entry));

            testBitInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(testBitInteger_Entry));

            andInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(andInteger_Entry));

            mkInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(mkInteger_Entry));

            fs74H = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(fs74H_Entry));

            orInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(orInteger_Entry));

            orDigits = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(orDigits_Entry));

            andDigitsOnes = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(andDigitsOnes_Entry));

            andDigits = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(andDigits_Entry));

            remInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(remInteger_Entry));

            quotInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(quotInteger_Entry));

            modInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(modInteger_Entry));

            divInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(divInteger_Entry));

            divModInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, (Closure x0, Closure x1)>(divModInteger_Entry));

            quotRemInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, (Closure x0, Closure x1)>(quotRemInteger_Entry));

            quotRemPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, (Closure x0, Closure x1)>(quotRemPositive_Entry));

            gs71E = new Fun(3, CLR.LoadFunctionPointer<ulong, Closure, Closure, (ulong x0, Closure x1)>(gs71E_Entry));

            some = new Fun(2, CLR.LoadFunctionPointer<ulong, Closure, Closure>(some_Entry));

            shiftLInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftLInteger_Entry));

            shiftLPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftLPositive_Entry));

            shiftRInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftRInteger_Entry));

            shiftRPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(shiftRPositive_Entry));

            smallShiftRPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(smallShiftRPositive_Entry));

            smallShiftLPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, long, Closure>(smallShiftLPositive_Entry));

            decodeDoubleInteger = new Fun(1, CLR.LoadFunctionPointer<double, (Closure x0, long x1)>(decodeDoubleInteger_Entry));

            complementInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(complementInteger_Entry));

            minusInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(minusInteger_Entry));

            plusInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(plusInteger_Entry));

            cmins6ZV = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cmins6ZV_Entry));

            cmaxs6ZR = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(cmaxs6ZR_Entry));

            geInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(geInteger_Entry));

            geIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(geIntegerHash_Entry));

            leInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(leInteger_Entry));

            leIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(leIntegerHash_Entry));

            gtInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(gtInteger_Entry));

            gtIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(gtIntegerHash_Entry));

            ltInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(ltInteger_Entry));

            ltIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(ltIntegerHash_Entry));

            neqInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(neqInteger_Entry));

            neqIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(neqIntegerHash_Entry));

            eqInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(eqInteger_Entry));

            eqIntegerHash = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, long>(eqIntegerHash_Entry));

            compareInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(compareInteger_Entry));

            comparePositive = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(comparePositive_Entry));

            digitsToInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(digitsToInteger_Entry));

            digitsToNegativeInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(digitsToNegativeInteger_Entry));

            removeZeroTails = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(removeZeroTails_Entry));

            digitsMaybeZeroToInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(digitsMaybeZeroToInteger_Entry));

            timesInteger = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(timesInteger_Entry));

            timesPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(timesPositive_Entry));

            timesDigit = new Fun(2, CLR.LoadFunctionPointer<ulong, ulong, Closure>(timesDigit_Entry));

            floatFromInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, float>(floatFromInteger_Entry));

            floatFromPositive = new Fun(1, CLR.LoadFunctionPointer<Closure, float>(floatFromPositive_Entry));

            doubleFromInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, double>(doubleFromInteger_Entry));

            doubleFromPositive = new Fun(1, CLR.LoadFunctionPointer<Closure, double>(doubleFromPositive_Entry));

            splitHalves = new Fun(1, CLR.LoadFunctionPointer<ulong, (ulong x0, ulong x1)>(splitHalves_Entry));

            highHalfShift = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(highHalfShift_Entry));

            lowHalfMask = new Fun(1, CLR.LoadFunctionPointer<Closure, ulong>(lowHalfMask_Entry));

            twosComplementPositive = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(twosComplementPositive_Entry));

            twosComplementPositives6W4 = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(twosComplementPositives6W4_Entry));

            minusPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(minusPositive_Entry));

            plusPositive = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(plusPositive_Entry));

            addWithCarrys6V2 = new Fun(3, CLR.LoadFunctionPointer<ulong, Closure, Closure, Closure>(addWithCarrys6V2_Entry));

            lvls6UY = new Updatable(CLR.LoadFunctionPointer<Closure>(lvls6UY_Entry));

            succPositive = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(succPositive_Entry));

            wsuccPositives6UI = new Fun(1, CLR.LoadFunctionPointer<Closure, (ulong x0, Closure x1)>(wsuccPositives6UI_Entry));

            fullBound = new Fun(1, CLR.LoadFunctionPointer<Closure, ulong>(fullBound_Entry));

            halfBoundUp = new Fun(1, CLR.LoadFunctionPointer<Closure, ulong>(halfBoundUp_Entry));

            signumInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(signumInteger_Entry));

            absInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(absInteger_Entry));

            decodeFloatInteger = new Fun(1, CLR.LoadFunctionPointer<float, (Closure x0, long x1)>(decodeFloatInteger_Entry));

            smallInteger = new Fun(1, CLR.LoadFunctionPointer<long, Closure>(smallInteger_Entry));

            negateInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(negateInteger_Entry));

            flipBits = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(flipBits_Entry));

            flipBitss6U5 = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(flipBitss6U5_Entry));

            flipBitsDigits = new Fun(1, CLR.LoadFunctionPointer<Closure, Closure>(flipBitsDigits_Entry));

            hashInteger = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(hashInteger_Entry));

            integerToInt = new Fun(1, CLR.LoadFunctionPointer<Closure, long>(integerToInt_Entry));

            integerToWord = new Fun(1, CLR.LoadFunctionPointer<Closure, ulong>(integerToWord_Entry));

            wordToInteger = new Fun(1, CLR.LoadFunctionPointer<ulong, Closure>(wordToInteger_Entry));

            none_DataCon = new GHC.Integer.Type.None();
            naught_DataCon = new GHC.Integer.Type.Naught();
            nil_DataCon = new GHC.Integer.Type.Nil();
            fOrdInteger = new GHC.Classes.CColOrd(null, GHC.Integer.Type.compareInteger, GHC.Integer.Type.ltInteger, GHC.Integer.Type.leInteger, GHC.Integer.Type.gtInteger, GHC.Integer.Type.geInteger, cmaxs6ZR, cmins6ZV);
            fEqInteger = new GHC.Classes.CColEq(GHC.Integer.Type.eqInteger, GHC.Integer.Type.neqInteger);
            twoToTheThirtytwoInteger = new GHC.Integer.Type.Positive(null);
            twoToTheThirtytwoPositive = new GHC.Integer.Type.Some(4294967296UL, null);
            oneInteger = new GHC.Integer.Type.Positive(null);
            negativeOneInteger = new GHC.Integer.Type.Negative(null);
            onePositive = new GHC.Integer.Type.Some(1UL, null);
            errorInteger = new GHC.Integer.Type.Positive(null);
            errorPositive = new GHC.Integer.Type.Some(47UL, null);
            errorPositive.x1 = GHC.Integer.Type.none_DataCon;
            errorInteger.x0 = GHC.Integer.Type.errorPositive;
            onePositive.x1 = GHC.Integer.Type.none_DataCon;
            negativeOneInteger.x0 = GHC.Integer.Type.onePositive;
            oneInteger.x0 = GHC.Integer.Type.onePositive;
            twoToTheThirtytwoPositive.x1 = GHC.Integer.Type.none_DataCon;
            twoToTheThirtytwoInteger.x0 = GHC.Integer.Type.twoToTheThirtytwoPositive;
            fOrdInteger.x0 = GHC.Integer.Type.fEqInteger;
        }
        public static Closure some_DataCon_Entry(ulong etaB2, Closure etaB1)
        {
            return new GHC.Integer.Type.Some(etaB2, etaB1);
        }
        public static Closure negative_DataCon_Entry(Closure etaB1)
        {
            return new GHC.Integer.Type.Negative(etaB1);
        }
        public static Closure positive_DataCon_Entry(Closure etaB1)
        {
            return new GHC.Integer.Type.Positive(etaB1);
        }
        public static Closure cons_DataCon_Entry(Closure etaB2, Closure etaB1)
        {
            return new GHC.Integer.Type.Cons(etaB2, etaB1);
        }
        public static float encodeFloatInteger_Entry(Closure dss77Y, long e0s77Z)
        {
            var wilds780 = dss77Y.Eval();
            switch (wilds780)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds780_Positive:
                    {
                        var ds0s781 = wilds780_Positive.x0;
                        return fs77K_Entry(0 % 1f, ds0s781, e0s77Z);
                    }
                case GHC.Integer.Type.Negative wilds780_Negative:
                    {
                        var dss782 = wilds780_Negative.x0;
                        var sats783 = new GHC.Integer.Type.Positive(dss782);
                        var wilds784 = encodeFloatInteger_Entry(sats783, e0s77Z);
                        return -wilds784;
                    }
                case GHC.Integer.Type.Naught wilds780_Naught: { return 0 % 1f; }
            }
        }
        public static float fs77K_Entry(float accs77L, Closure dss77M, long dss77N)
        {
            var wilds77O = dss77M.Eval();
            switch (wilds77O)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds77O_Some:
                    {
                        var ds77P = wilds77O_Some.x0;
                        var dss77Q = wilds77O_Some.x1;
                        var wilds77S = __word_encodeFloat(ds77P, dss77N, GHC.Prim.realWorldHash);
                        var dss77U = wilds77S;
                        var sats77W = dss77N + 64;
                        var sats77V = accs77L + dss77U;
                        return fs77K_Entry(sats77V, dss77Q, sats77W);
                    }
                case GHC.Integer.Type.None wilds77O_None: { return accs77L; }
            }
        }
        public static float encodeFloatHash_Entry(ulong dss77E, long dss77F)
        {
            var wilds77H = __word_encodeFloat(dss77E, dss77F, GHC.Prim.realWorldHash);
            var dss77J = wilds77H; return dss77J;
        }

        private static float __word_encodeFloat(ulong man, long exp, Prim.StateHash realWorldHash)
        {
            uint m = (uint)(man + ((ulong)exp << 23));
            return System.BitConverter.ToSingle(System.BitConverter.GetBytes(m), 0);
        }

        public static double encodeDoubleInteger_Entry(Closure dss77w, long e0s77x)
        {
            var wilds77y = dss77w.Eval();
            switch (wilds77y)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds77y_Positive:
                    {
                        var ds0s77z = wilds77y_Positive.x0;
                        return fs77i_Entry(0 % 1, ds0s77z, e0s77x);
                    }
                case GHC.Integer.Type.Negative wilds77y_Negative:
                    {
                        var dss77A = wilds77y_Negative.x0;
                        var sats77B = new GHC.Integer.Type.Positive(dss77A);
                        var wilds77C = encodeDoubleInteger_Entry(sats77B, e0s77x);
                        return -wilds77C;
                    }
                case GHC.Integer.Type.Naught wilds77y_Naught: { return 0 % 1; }
            }
        }
        public static double fs77i_Entry(double accs77j, Closure dss77k, long dss77l)
        {
            var wilds77m = dss77k.Eval();
            switch (wilds77m)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds77m_Some:
                    {
                        var ds77n = wilds77m_Some.x0;
                        var dss77o = wilds77m_Some.x1;
                        var wilds77q = __word_encodeDouble(ds77n, dss77l, GHC.Prim.realWorldHash);
                        var dss77s = wilds77q;
                        var sats77u = dss77l + 64;
                        var sats77t = accs77j + dss77s;
                        return fs77i_Entry(sats77t, dss77o, sats77u);
                    }
                case GHC.Integer.Type.None wilds77m_None: { return accs77j; }
            }
        }
        public static double encodeDoubleHash_Entry(ulong dss77c, long dss77d)
        {
            var wilds77f = __word_encodeDouble(dss77c, dss77d, GHC.Prim.realWorldHash);
            var dss77h = wilds77f; return dss77h;
        }

        private static double __word_encodeDouble(ulong man, long exp, Prim.StateHash realWorldHash)
        {
            ulong m = man + ((ulong)exp << 52);
            return System.BitConverter.ToDouble(System.BitConverter.GetBytes(m), 0);
        }

        public static Closure xorInteger_Entry(Closure dss75N, Closure is75O)
        {
            var wilds75P = dss75N.Eval();
            switch (wilds75P)
            {
                default:
                    {
                        var wilds75Q = is75O.Eval();
                        switch (wilds75Q)
                        {
                            default:
                                {
                                    var wilds75R = wilds75P.Eval();
                                    switch (wilds75R)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Positive wilds75R_Positive:
                                            {
                                                var xs75S = wilds75R_Positive.x0;
                                                var wilds75T = wilds75Q.Eval();
                                                switch (wilds75T)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds75T_Positive:
                                                        {
                                                            var ys75U = wilds75T_Positive.x0;
                                                            var sats75V = xorDigits_Entry(xs75S, ys75U).Eval();
                                                            var wilds75W = removeZeroTails_Entry(sats75V).Eval();
                                                            switch (wilds75W)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds75W_Some:
                                                                    {
                                                                        var ipvs75X = wilds75W_Some.x0;
                                                                        var ipvs75Y = wilds75W_Some.x1;
                                                                        return new GHC.Integer.Type.Positive(wilds75W);
                                                                    }
                                                                case GHC.Integer.Type.None wilds75W_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                    case GHC.Integer.Type.Negative wilds75T_Negative:
                                                        {
                                                            var ys75Z = wilds75T_Negative.x0;
                                                            var sats760 = minusPositive_Entry(ys75Z, GHC.Integer.Type.onePositive).Eval();
                                                            var sats761 = xorDigits_Entry(xs75S, sats760).Eval();
                                                            var wws762 = wsuccPositives6UI_Entry(sats761);
                                                            var wws762_RawTuple = wws762;
                                                            var wws763 = wws762_RawTuple.x0;
                                                            var wws764 = wws762_RawTuple.x1;
                                                            var sats765 = new GHC.Integer.Type.Some(wws763, wws764);
                                                            var wilds766 = removeZeroTails_Entry(sats765).Eval();
                                                            switch (wilds766)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds766_Some:
                                                                    {
                                                                        var ipvs767 = wilds766_Some.x0;
                                                                        var ipvs768 = wilds766_Some.x1;
                                                                        return new GHC.Integer.Type.Negative(wilds766);
                                                                    }
                                                                case GHC.Integer.Type.None wilds766_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.Negative wilds75R_Negative:
                                            {
                                                var xs769 = wilds75R_Negative.x0;
                                                var wilds76a = wilds75Q.Eval();
                                                switch (wilds76a)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds76a_Positive:
                                                        {
                                                            var ys76b = wilds76a_Positive.x0;
                                                            return xorInteger_Entry(wilds76a, wilds75R);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds76a_Negative:
                                                        {
                                                            var ys76c = wilds76a_Negative.x0;
                                                            var sats76e = minusPositive_Entry(ys76c, GHC.Integer.Type.onePositive).Eval();
                                                            var sats76d = minusPositive_Entry(xs769, GHC.Integer.Type.onePositive).Eval();
                                                            var sats76f = xorDigits_Entry(sats76d, sats76e).Eval();
                                                            var wilds76g = removeZeroTails_Entry(sats76f).Eval();
                                                            switch (wilds76g)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds76g_Some:
                                                                    {
                                                                        var ipvs76h = wilds76g_Some.x0;
                                                                        var ipvs76i = wilds76g_Some.x1;
                                                                        return new GHC.Integer.Type.Positive(wilds76g);
                                                                    }
                                                                case GHC.Integer.Type.None wilds76g_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.Naught wilds75Q_Naught:
                                {
                                    return wilds75P.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds75P_Naught:
                    {
                        return is75O.Eval();
                    }
            }
        }
        public static Closure xorDigits_Entry(Closure dss75C, Closure dss75D)
        {
            var wilds75E = dss75C.Eval();
            switch (wilds75E)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds75E_Some:
                    {
                        var dss75F = wilds75E_Some.x0;
                        var dss75G = wilds75E_Some.x1;
                        var wilds75H = dss75D.Eval();
                        switch (wilds75H)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds75H_Some:
                                {
                                    var w2s75I = wilds75H_Some.x0;
                                    var ds2s75J = wilds75H_Some.x1;
                                    var dts75K = xorDigits_Entry(dss75G, ds2s75J).Eval();
                                    var sats75L = dss75F ^ w2s75I;
                                    return new GHC.Integer.Type.Some(sats75L, dts75K);
                                }
                            case GHC.Integer.Type.None wilds75H_None:
                                {
                                    return wilds75E.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds75E_None: { return dss75D.Eval(); }
            }
        }
        public static Closure testBitInteger_Entry(Closure xs75w, long is75x)
        {
            var sats75y = shiftLInteger_Entry(GHC.Integer.Type.oneInteger, is75x).Eval();
            var sats75z = andInteger_Entry(xs75w, sats75y).Eval();
            var wilds75A = neqIntegerHash_Entry(sats75z, GHC.Integer.Type.naught_DataCon);
            return GHC.Types.tagToEnumHash(wilds75A);
        }
        public static Closure andInteger_Entry(Closure dss74X, Closure dss74Y)
        {
            var wilds74Z = dss74X.Eval();
            switch (wilds74Z)
            {
                default:
                    {
                        var wilds750 = dss74Y.Eval();
                        switch (wilds750)
                        {
                            default:
                                {
                                    var wilds751 = wilds74Z.Eval();
                                    switch (wilds751)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Positive wilds751_Positive:
                                            {
                                                var xs752 = wilds751_Positive.x0;
                                                var wilds753 = wilds750.Eval();
                                                switch (wilds753)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds753_Positive:
                                                        {
                                                            var ys754 = wilds753_Positive.x0;
                                                            var sats755 = andDigits_Entry(xs752, ys754).Eval();
                                                            var wilds756 = removeZeroTails_Entry(sats755).Eval();
                                                            switch (wilds756)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds756_Some:
                                                                    {
                                                                        var ipvs757 = wilds756_Some.x0;
                                                                        var ipvs758 = wilds756_Some.x1;
                                                                        return new GHC.Integer.Type.Positive(wilds756);
                                                                    }
                                                                case GHC.Integer.Type.None wilds756_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                    case GHC.Integer.Type.Negative wilds753_Negative:
                                                        {
                                                            var ys759 = wilds753_Negative.x0;
                                                            var sats75a = minusPositive_Entry(ys759, GHC.Integer.Type.onePositive).Eval();
                                                            var sats75b = flipBitsDigits_Entry(sats75a).Eval();
                                                            var sats75c = andDigitsOnes_Entry(sats75b, xs752).Eval();
                                                            var wilds75d = removeZeroTails_Entry(sats75c).Eval();
                                                            switch (wilds75d)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds75d_Some:
                                                                    {
                                                                        var ipvs75e = wilds75d_Some.x0;
                                                                        var ipvs75f = wilds75d_Some.x1;
                                                                        return new GHC.Integer.Type.Positive(wilds75d);
                                                                    }
                                                                case GHC.Integer.Type.None wilds75d_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.Negative wilds751_Negative:
                                            {
                                                var xs75g = wilds751_Negative.x0;
                                                var wilds75h = wilds750.Eval();
                                                switch (wilds75h)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds75h_Positive:
                                                        {
                                                            var ys75i = wilds75h_Positive.x0;
                                                            return andInteger_Entry(wilds75h, wilds751);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds75h_Negative:
                                                        {
                                                            var ys75j = wilds75h_Negative.x0;
                                                            var sats75l = minusPositive_Entry(ys75j, GHC.Integer.Type.onePositive).Eval();
                                                            var sats75k = minusPositive_Entry(xs75g, GHC.Integer.Type.onePositive).Eval();
                                                            var sats75m = orDigits_Entry(sats75k, sats75l).Eval();
                                                            var wws75n = wsuccPositives6UI_Entry(sats75m);
                                                            var wws75n_RawTuple = wws75n;
                                                            var wws75o = wws75n_RawTuple.x0;
                                                            var wws75p = wws75n_RawTuple.x1;
                                                            var sats75q = new GHC.Integer.Type.Some(wws75o, wws75p);
                                                            var wilds75r = removeZeroTails_Entry(sats75q).Eval();
                                                            switch (wilds75r)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds75r_Some:
                                                                    {
                                                                        var ipvs75s = wilds75r_Some.x0;
                                                                        var ipvs75t = wilds75r_Some.x1;
                                                                        return new GHC.Integer.Type.Negative(wilds75r);
                                                                    }
                                                                case GHC.Integer.Type.None wilds75r_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.Naught wilds750_Naught:
                                {
                                    return GHC.Integer.Type.naught_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds74Z_Naught:
                    {
                        var dss75u = dss74Y.Eval();
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure mkInteger_Entry(Closure nonNegatives74S, Closure iss74T)
        {
            var wilds74U = nonNegatives74S.Eval();
            var wilds74UTags74U = wilds74U.Tag;
            switch (wilds74UTags74U)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds74U_False = wilds74U as GHC.Types.False;
                        var sats74V = fs74H_Entry(iss74T).Eval();
                        return negateInteger_Entry(sats74V);
                    }
                case 2:
                    {
                        var wilds74U_True = wilds74U as GHC.Types.True;
                        return fs74H_Entry(iss74T);
                    }
            }
        }
        public static Closure fs74H_Entry(Closure dss74I)
        {
            var wilds74J = dss74I.Eval();
            switch (wilds74J)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds74J_Nil:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds74J_Cons:
                    {
                        var dss74K = wilds74J_Cons.x0;
                        var is_s74L = wilds74J_Cons.x1;
                        var wilds74M = dss74K.Eval();
                        var wilds74M_IHash = wilds74M as GHC.Types.IHash;
                        var is74N = wilds74M_IHash.x0;
                        var sats74P = fs74H_Entry(is_s74L).Eval();
                        var sats74Q = shiftLInteger_Entry(sats74P, 31).Eval();
                        var sats74O = smallInteger_Entry(is74N).Eval();
                        return orInteger_Entry(sats74O, sats74Q);
                    }
            }
        }
        public static Closure orInteger_Entry(Closure dss749, Closure is74a)
        {
            var wilds74b = dss749.Eval();
            switch (wilds74b)
            {
                default:
                    {
                        var wilds74c = is74a.Eval();
                        switch (wilds74c)
                        {
                            default:
                                {
                                    var wilds74d = wilds74b.Eval();
                                    switch (wilds74d)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Positive wilds74d_Positive:
                                            {
                                                var xs74e = wilds74d_Positive.x0;
                                                var wilds74f = wilds74c.Eval();
                                                switch (wilds74f)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds74f_Positive:
                                                        {
                                                            var ys74g = wilds74f_Positive.x0;
                                                            var dts74h = orDigits_Entry(xs74e, ys74g).Eval();
                                                            return new GHC.Integer.Type.Positive(dts74h);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds74f_Negative:
                                                        {
                                                            var ys74i = wilds74f_Negative.x0;
                                                            var sats74k = minusPositive_Entry(ys74i, GHC.Integer.Type.onePositive).Eval();
                                                            var sats74j = flipBitsDigits_Entry(xs74e).Eval();
                                                            var sats74l = andDigitsOnes_Entry(sats74j, sats74k).Eval();
                                                            var wws74m = wsuccPositives6UI_Entry(sats74l);
                                                            var wws74m_RawTuple = wws74m;
                                                            var wws74n = wws74m_RawTuple.x0;
                                                            var wws74o = wws74m_RawTuple.x1;
                                                            var sats74p = new GHC.Integer.Type.Some(wws74n, wws74o);
                                                            var wilds74q = removeZeroTails_Entry(sats74p).Eval();
                                                            switch (wilds74q)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds74q_Some:
                                                                    {
                                                                        var ipvs74r = wilds74q_Some.x0;
                                                                        var ipvs74s = wilds74q_Some.x1;
                                                                        return new GHC.Integer.Type.Negative(wilds74q);
                                                                    }
                                                                case GHC.Integer.Type.None wilds74q_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.Negative wilds74d_Negative:
                                            {
                                                var xs74t = wilds74d_Negative.x0;
                                                var wilds74u = wilds74c.Eval();
                                                switch (wilds74u)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds74u_Positive:
                                                        {
                                                            var ys74v = wilds74u_Positive.x0;
                                                            return orInteger_Entry(wilds74u, wilds74d);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds74u_Negative:
                                                        {
                                                            var ys74w = wilds74u_Negative.x0;
                                                            var sats74y = minusPositive_Entry(ys74w, GHC.Integer.Type.onePositive).Eval();
                                                            var sats74x = minusPositive_Entry(xs74t, GHC.Integer.Type.onePositive).Eval();
                                                            var sats74z = andDigits_Entry(sats74x, sats74y).Eval();
                                                            var wws74A = wsuccPositives6UI_Entry(sats74z);
                                                            var wws74A_RawTuple = wws74A;
                                                            var wws74B = wws74A_RawTuple.x0;
                                                            var wws74C = wws74A_RawTuple.x1;
                                                            var sats74D = new GHC.Integer.Type.Some(wws74B, wws74C);
                                                            var wilds74E = removeZeroTails_Entry(sats74D).Eval();
                                                            switch (wilds74E)
                                                            {
                                                                default: { throw new ImpossibleException(); }
                                                                case GHC.Integer.Type.Some wilds74E_Some:
                                                                    {
                                                                        var ipvs74F = wilds74E_Some.x0;
                                                                        var ipvs74G = wilds74E_Some.x1;
                                                                        return new GHC.Integer.Type.Negative(wilds74E);
                                                                    }
                                                                case GHC.Integer.Type.None wilds74E_None:
                                                                    {
                                                                        return GHC.Integer.Type.naught_DataCon.Eval();
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.Naught wilds74c_Naught:
                                {
                                    return wilds74b.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds74b_Naught:
                    {
                        return is74a.Eval();
                    }
            }
        }
        public static Closure orDigits_Entry(Closure dss73Y, Closure dss73Z)
        {
            var wilds740 = dss73Y.Eval();
            switch (wilds740)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds740_Some:
                    {
                        var dss741 = wilds740_Some.x0;
                        var dss742 = wilds740_Some.x1;
                        var wilds743 = dss73Z.Eval();
                        switch (wilds743)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds743_Some:
                                {
                                    var w2s744 = wilds743_Some.x0;
                                    var ds2s745 = wilds743_Some.x1;
                                    var dts746 = orDigits_Entry(dss742, ds2s745).Eval();
                                    var sats747 = dss741 | w2s744;
                                    return new GHC.Integer.Type.Some(sats747, dts746);
                                }
                            case GHC.Integer.Type.None wilds743_None:
                                {
                                    return wilds740.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds740_None: { return dss73Z.Eval(); }
            }
        }
        public static Closure andDigitsOnes_Entry(Closure dss73N, Closure dss73O)
        {
            var wilds73P = dss73N.Eval();
            switch (wilds73P)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds73P_Some:
                    {
                        var dss73Q = wilds73P_Some.x0;
                        var dss73R = wilds73P_Some.x1;
                        var wilds73S = dss73O.Eval();
                        switch (wilds73S)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds73S_Some:
                                {
                                    var w2s73T = wilds73S_Some.x0;
                                    var ws2s73U = wilds73S_Some.x1;
                                    var dts73V = andDigitsOnes_Entry(dss73R, ws2s73U).Eval();
                                    var sats73W = dss73Q & w2s73T;
                                    return new GHC.Integer.Type.Some(sats73W, dts73V);
                                }
                            case GHC.Integer.Type.None wilds73S_None:
                                {
                                    return GHC.Integer.Type.none_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds73P_None: { return dss73O.Eval(); }
            }
        }
        public static Closure andDigits_Entry(Closure dss73B, Closure dss73C)
        {
            var wilds73D = dss73B.Eval();
            switch (wilds73D)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds73D_Some:
                    {
                        var dss73E = wilds73D_Some.x0;
                        var dss73F = wilds73D_Some.x1;
                        var wilds73G = dss73C.Eval();
                        switch (wilds73G)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds73G_Some:
                                {
                                    var w2s73H = wilds73G_Some.x0;
                                    var ws2s73I = wilds73G_Some.x1;
                                    var dts73J = andDigits_Entry(dss73F, ws2s73I).Eval();
                                    var sats73K = dss73E & w2s73H;
                                    return new GHC.Integer.Type.Some(sats73K, dts73J);
                                }
                            case GHC.Integer.Type.None wilds73G_None:
                                {
                                    return GHC.Integer.Type.none_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds73D_None:
                    {
                        var wilds73L = dss73C.Eval();
                        return GHC.Integer.Type.none_DataCon.Eval();
                    }
            }
        }
        public static Closure remInteger_Entry(Closure xs73v, Closure ys73w)
        {
            var dss73x = quotRemInteger_Entry(xs73v, ys73w);
            var dss73x_RawTuple = dss73x;
            var ipvs73y = dss73x_RawTuple.x0;
            var ipvs73z = dss73x_RawTuple.x1; return ipvs73z.Eval();
        }
        public static Closure quotInteger_Entry(Closure xs73p, Closure ys73q)
        {
            var dss73r = quotRemInteger_Entry(xs73p, ys73q);
            var dss73r_RawTuple = dss73r;
            var ipvs73s = dss73r_RawTuple.x0;
            var ipvs73t = dss73r_RawTuple.x1; return ipvs73s.Eval();
        }
        public static Closure modInteger_Entry(Closure ns73j, Closure ds73k)
        {
            var dss73l = divModInteger_Entry(ns73j, ds73k);
            var dss73l_RawTuple = dss73l;
            var ipvs73m = dss73l_RawTuple.x0;
            var ipvs73n = dss73l_RawTuple.x1; return ipvs73n.Eval();
        }
        public static Closure divInteger_Entry(Closure ns73d, Closure ds73e)
        {
            var dss73f = divModInteger_Entry(ns73d, ds73e);
            var dss73f_RawTuple = dss73f;
            var ipvs73g = dss73f_RawTuple.x0;
            var ipvs73h = dss73f_RawTuple.x1; return ipvs73g.Eval();
        }
        public static (Closure x0, Closure x1) divModInteger_Entry(Closure ns731, Closure ds732)
        {
            var dss733 = quotRemInteger_Entry(ns731, ds732);
            var dss733_RawTuple = dss733;
            var ipvs734 = dss733_RawTuple.x0;
            var ipvs735 = dss733_RawTuple.x1;
            var sats737 = signumInteger_Entry(ds732).Eval();
            var sats738 = negateInteger_Entry(sats737).Eval();
            var sats736 = signumInteger_Entry(ipvs735).Eval();
            var wilds739 = eqIntegerHash_Entry(sats736, sats738);
            switch (wilds739)
            {
                default: { return (ipvs734, ipvs735); }
                case 1:
                    {
                        var sats73b = new Updatable<Closure, Closure>(CLR.LoadFunctionPointer<Closure, Closure, Closure>(sats73b_Entry), ds732, ipvs735);
                        var sats73a = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats73a_Entry), ipvs734);
                        return (sats73a, sats73b);
                    }
            }
        }
        public static Closure sats73a_Entry(Closure ipvs734)
        {
            return minusInteger_Entry(ipvs734, GHC.Integer.Type.oneInteger);
        }
        public static Closure sats73b_Entry(Closure ds732, Closure ipvs735)
        {
            return plusInteger_Entry(ipvs735, ds732);
        }
        public static (Closure x0, Closure x1) quotRemInteger_Entry(Closure dss72z, Closure dss72A)
        {
            var wilds72B = dss72z.Eval();
            switch (wilds72B)
            {
                default:
                    {
                        var wilds72C = dss72A.Eval();
                        switch (wilds72C)
                        {
                            default:
                                {
                                    var wilds72D = wilds72B.Eval();
                                    switch (wilds72D)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Positive wilds72D_Positive:
                                            {
                                                var p1s72E = wilds72D_Positive.x0;
                                                var wilds72F = wilds72C.Eval();
                                                switch (wilds72F)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds72F_Positive:
                                                        {
                                                            var p2s72G = wilds72F_Positive.x0;
                                                            return quotRemPositive_Entry(p1s72E, p2s72G);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds72F_Negative:
                                                        {
                                                            var p2s72H = wilds72F_Negative.x0;
                                                            var dss72I = quotRemPositive_Entry(p1s72E, p2s72H);
                                                            var dss72I_RawTuple = dss72I;
                                                            var ipvs72J = dss72I_RawTuple.x0;
                                                            var ipvs72K = dss72I_RawTuple.x1;
                                                            var sats72L = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72L_Entry), ipvs72J);
                                                            return (sats72L, ipvs72K);
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.Negative wilds72D_Negative:
                                            {
                                                var p1s72M = wilds72D_Negative.x0;
                                                var wilds72N = wilds72C.Eval();
                                                switch (wilds72N)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Positive wilds72N_Positive:
                                                        {
                                                            var p2s72O = wilds72N_Positive.x0;
                                                            var dss72P = quotRemPositive_Entry(p1s72M, p2s72O);
                                                            var dss72P_RawTuple = dss72P;
                                                            var ipvs72Q = dss72P_RawTuple.x0;
                                                            var ipvs72R = dss72P_RawTuple.x1;
                                                            var sats72T = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72T_Entry), ipvs72R);
                                                            var sats72S = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72S_Entry), ipvs72Q);
                                                            return (sats72S, sats72T);
                                                        }
                                                    case GHC.Integer.Type.Negative wilds72N_Negative:
                                                        {
                                                            var p2s72U = wilds72N_Negative.x0;
                                                            var dss72V = quotRemPositive_Entry(p1s72M, p2s72U);
                                                            var dss72V_RawTuple = dss72V;
                                                            var ipvs72W = dss72V_RawTuple.x0;
                                                            var ipvs72X = dss72V_RawTuple.x1;
                                                            var sats72Y = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72Y_Entry), ipvs72X);
                                                            return (ipvs72W, sats72Y);
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.Naught wilds72C_Naught:
                                {
                                    return (GHC.Integer.Type.errorInteger, GHC.Integer.Type.errorInteger);
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds72B_Naught:
                    {
                        var dss72Z = dss72A.Eval();
                        return (GHC.Integer.Type.naught_DataCon, GHC.Integer.Type.naught_DataCon);
                    }
            }
        }
        public static Closure sats72L_Entry(Closure ipvs72J)
        {
            return negateInteger_Entry(ipvs72J);
        }
        public static Closure sats72S_Entry(Closure ipvs72Q)
        {
            return negateInteger_Entry(ipvs72Q);
        }
        public static Closure sats72T_Entry(Closure ipvs72R)
        {
            return negateInteger_Entry(ipvs72R);
        }
        public static Closure sats72Y_Entry(Closure ipvs72X)
        {
            return negateInteger_Entry(ipvs72X);
        }
        public static (Closure x0, Closure x1) quotRemPositive_Entry(Closure xss71S, Closure yss71T)
        {
            var yss71U = yss71T.Eval();
            var subtractorss71V = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(subtractorss71V_Entry), yss71U);
            var fs723 = new Fun<Closure, Closure>(1, CLR.LoadFunctionPointer<Closure, Closure, Closure, (Closure x0, Closure x1)>(fs723_Entry), subtractorss71V, null);
            fs723.x1 = fs723;
            var dss72t = fs723.Apply<Closure, (Closure x0, Closure x1)>(xss71S);
            var dss72t_RawTuple = dss72t;
            var ipvs72u = dss72t_RawTuple.x0;
            var ipvs72v = dss72t_RawTuple.x1;
            var sats72x = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72x_Entry), ipvs72v);
            var sats72w = new Updatable<Closure>(CLR.LoadFunctionPointer<Closure, Closure>(sats72w_Entry), ipvs72u);
            return (sats72w, sats72x);
        }
        public static Closure sats72w_Entry(Closure ipvs72u)
        {
            return digitsMaybeZeroToInteger_Entry(ipvs72u);
        }
        public static Closure sats72x_Entry(Closure ipvs72v)
        {
            return digitsMaybeZeroToInteger_Entry(ipvs72v);
        }
        public static (Closure x0, Closure x1) fs723_Entry(Closure subtractorss71V, Closure fs723, Closure dss724)
        {
            var wilds725 = dss724.Eval();
            switch (wilds725)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds725_Some:
                    {
                        var zs726 = wilds725_Some.x0;
                        var zss727 = wilds725_Some.x1;
                        var dss728 = fs723.Apply<Closure, (Closure x0, Closure x1)>(zss727);
                        var dss728_RawTuple = dss728;
                        var ipvs729 = dss728_RawTuple.x0;
                        var ipvs72a = dss728_RawTuple.x1;
                        var wilds72b = ipvs72a.Eval();
                        switch (wilds72b)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds72b_Some:
                                {
                                    var ipvs72c = wilds72b_Some.x0;
                                    var ipvs72d = wilds72b_Some.x1;
                                    var sats72e = new GHC.Integer.Type.Some(zs726, wilds72b);
                                    var dss72f = gs71E_Entry(0UL, subtractorss71V, sats72e);
                                    var dss72f_RawTuple = dss72f;
                                    var ipvs72g = dss72f_RawTuple.x0;
                                    var ipvs72h = dss72f_RawTuple.x1;
                                    var sats72i = new Updatable<Closure, ulong>(CLR.LoadFunctionPointer<Closure, ulong, Closure>(sats72i_Entry), ipvs729, ipvs72g);
                                    return (sats72i, ipvs72h);
                                }
                            case GHC.Integer.Type.None wilds72b_None:
                                {
                                    var wilds72j = zs726;
                                    switch (wilds72j)
                                    {
                                        default:
                                            {
                                                var sats72k = new GHC.Integer.Type.Some(wilds72j, GHC.Integer.Type.none_DataCon);
                                                var dss72l = gs71E_Entry(0UL, subtractorss71V, sats72k);
                                                var dss72l_RawTuple = dss72l;
                                                var ipvs72m = dss72l_RawTuple.x0;
                                                var ipvs72n = dss72l_RawTuple.x1;
                                                var sats72o = new Updatable<Closure, ulong>(CLR.LoadFunctionPointer<Closure, ulong, Closure>(sats72o_Entry), ipvs729, ipvs72m);
                                                return (sats72o, ipvs72n);
                                            }
                                        case 0UL:
                                            {
                                                var dss72p = gs71E_Entry(0UL, subtractorss71V, GHC.Integer.Type.none_DataCon);
                                                var dss72p_RawTuple = dss72p;
                                                var ipvs72q = dss72p_RawTuple.x0;
                                                var ipvs72r = dss72p_RawTuple.x1;
                                                var sats72s = new Updatable<Closure, ulong>(CLR.LoadFunctionPointer<Closure, ulong, Closure>(sats72s_Entry), ipvs729, ipvs72q);
                                                return (sats72s, ipvs72r);
                                            }
                                    }
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds725_None:
                    {
                        return (GHC.Integer.Type.none_DataCon, GHC.Integer.Type.none_DataCon);
                    }
            }
        }
        public static Closure sats72i_Entry(Closure ipvs729, ulong ipvs72g)
        {
            return some_Entry(ipvs72g, ipvs729);
        }
        public static Closure sats72o_Entry(Closure ipvs729, ulong ipvs72m)
        {
            return some_Entry(ipvs72m, ipvs729);
        }
        public static Closure sats72s_Entry(Closure ipvs729, ulong ipvs72q)
        {
            return some_Entry(ipvs72q, ipvs729);
        }
        public static Closure subtractorss71V_Entry(Closure yss71U)
        {
            var lvls71W = new GHC.Integer.Type.Cons(yss71U, GHC.Integer.Type.nil_DataCon);
            var mkSubtractorss71X = new Fun<Closure, Closure, Closure>(1, CLR.LoadFunctionPointer<Closure, Closure, Closure, long, Closure>(mkSubtractorss71X_Entry), yss71U, lvls71W, null);
            mkSubtractorss71X.x2 = mkSubtractorss71X;
            return mkSubtractorss71X.Apply<long, Closure>(63);
        }
        public static Closure mkSubtractorss71X_Entry(Closure yss71U, Closure lvls71W, Closure mkSubtractorss71X, long ns71Y)
        {
            var wilds71Z = ns71Y;
            switch (wilds71Z)
            {
                default:
                    {
                        var sats722 = new Updatable<Closure, long>(CLR.LoadFunctionPointer<Closure, long, Closure>(sats722_Entry), mkSubtractorss71X, wilds71Z);
                        var sats720 = new Updatable<Closure, long>(CLR.LoadFunctionPointer<Closure, long, Closure>(sats720_Entry), yss71U, wilds71Z);
                        return new GHC.Integer.Type.Cons(sats720, sats722);
                    }
                case 0: { return lvls71W.Eval(); }
            }
        }
        public static Closure sats720_Entry(Closure yss71U, long wilds71Z)
        {
            return smallShiftLPositive_Entry(yss71U, wilds71Z);
        }
        public static Closure sats722_Entry(Closure mkSubtractorss71X, long wilds71Z)
        {
            var sats721 = wilds71Z - 1;
            return mkSubtractorss71X.Apply<long, Closure>(sats721);
        }
        public static (ulong x0, Closure x1) gs71E_Entry(ulong ds71F, Closure dss71G, Closure ms71H)
        {
            var wilds71I = dss71G.Eval();
            switch (wilds71I)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Nil wilds71I_Nil:
                    {
                        var ms71J = ms71H.Eval(); return (ds71F, ms71J);
                    }
                case GHC.Integer.Type.Cons wilds71I_Cons:
                    {
                        var subs71K = wilds71I_Cons.x0;
                        var subss71L = wilds71I_Cons.x1;
                        var wilds71M = comparePositive_Entry(ms71H, subs71K).Eval();
                        var wilds71MTags71M = wilds71M.Tag;
                        switch (wilds71MTags71M)
                        {
                            default:
                                {
                                    var sats71P = minusPositive_Entry(ms71H, subs71K).Eval();
                                    var sats71N = ds71F << (int)1;
                                    var sats71O = sats71N + 1UL;
                                    return gs71E_Entry(sats71O, subss71L, sats71P);
                                }
                            case 1:
                                {
                                    var wilds71M_LT = wilds71M as GHC.Types.LT;
                                    var sats71Q = ds71F << (int)1;
                                    return gs71E_Entry(sats71Q, subss71L, ms71H);
                                }
                        }
                    }
            }
        }
        public static Closure some_Entry(ulong ws71y, Closure dss71z)
        {
            var wilds71A = dss71z.Eval();
            switch (wilds71A)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds71A_Some:
                    {
                        var ipvs71B = wilds71A_Some.x0;
                        var ipvs71C = wilds71A_Some.x1;
                        return new GHC.Integer.Type.Some(ws71y, wilds71A);
                    }
                case GHC.Integer.Type.None wilds71A_None:
                    {
                        var wilds71D = ws71y;
                        switch (wilds71D)
                        {
                            default:
                                {
                                    return new GHC.Integer.Type.Some(wilds71D, GHC.Integer.Type.none_DataCon);
                                }
                            case 0UL: { return GHC.Integer.Type.none_DataCon.Eval(); }
                        }
                    }
            }
        }
        public static Closure shiftLInteger_Entry(Closure dss71q, long is71r)
        {
            var wilds71s = dss71q.Eval();
            switch (wilds71s)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds71s_Positive:
                    {
                        var ps71t = wilds71s_Positive.x0;
                        var dts71u = shiftLPositive_Entry(ps71t, is71r).Eval();
                        return new GHC.Integer.Type.Positive(dts71u);
                    }
                case GHC.Integer.Type.Negative wilds71s_Negative:
                    {
                        var ns71v = wilds71s_Negative.x0;
                        var dts71w = shiftLPositive_Entry(ns71v, is71r).Eval();
                        return new GHC.Integer.Type.Negative(dts71w);
                    }
                case GHC.Integer.Type.Naught wilds71s_Naught:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure shiftLPositive_Entry(Closure ps71j, long is71k)
        {
            var lwilds71l = (is71k >= 64) ? 1 : 0;
            switch (lwilds71l)
            {
                default: { return smallShiftLPositive_Entry(ps71j, is71k); }
                case 1:
                    {
                        var dts71m = ps71j.Eval();
                        var sats71o = is71k - 64;
                        var sats71n = new GHC.Integer.Type.Some(0UL, dts71m);
                        return shiftLPositive_Entry(sats71n, sats71o);
                    }
            }
        }
        public static Closure shiftRInteger_Entry(Closure dss71b, long is71c)
        {
            var wilds71d = dss71b.Eval();
            switch (wilds71d)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds71d_Positive:
                    {
                        var ps71e = wilds71d_Positive.x0;
                        return shiftRPositive_Entry(ps71e, is71c);
                    }
                case GHC.Integer.Type.Negative wilds71d_Negative:
                    {
                        var dss71f = wilds71d_Negative.x0;
                        var sats71g = complementInteger_Entry(wilds71d).Eval();
                        var sats71h = shiftRInteger_Entry(sats71g, is71c).Eval();
                        return complementInteger_Entry(sats71h);
                    }
                case GHC.Integer.Type.Naught wilds71d_Naught:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure shiftRPositive_Entry(Closure dss713, long dss714)
        {
            var wilds715 = dss713.Eval();
            switch (wilds715)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds715_Some:
                    {
                        var dss716 = wilds715_Some.x0;
                        var qs717 = wilds715_Some.x1;
                        var lwilds718 = (dss714 >= 64) ? 1 : 0;
                        switch (lwilds718)
                        {
                            default: { return smallShiftRPositive_Entry(wilds715, dss714); }
                            case 1:
                                {
                                    var sats719 = dss714 - 64;
                                    return shiftRPositive_Entry(qs717, sats719);
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds715_None:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure smallShiftRPositive_Entry(Closure ps70R, long is70S)
        {
            var ps70T = ps70R.Eval();
            var wilds70U = is70S;
            switch (wilds70U)
            {
                default:
                    {
                        var sats70V = 64 - wilds70U;
                        var wilds70W = smallShiftLPositive_Entry(ps70T, sats70V).Eval();
                        switch (wilds70W)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds70W_Some:
                                {
                                    var dss70X = wilds70W_Some.x0;
                                    var p_s70Y = wilds70W_Some.x1;
                                    var wilds70Z = p_s70Y.Eval();
                                    switch (wilds70Z)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Some wilds70Z_Some:
                                            {
                                                var dss710 = wilds70Z_Some.x0;
                                                var dss711 = wilds70Z_Some.x1;
                                                return new GHC.Integer.Type.Positive(wilds70Z);
                                            }
                                        case GHC.Integer.Type.None wilds70Z_None:
                                            {
                                                return GHC.Integer.Type.naught_DataCon.Eval();
                                            }
                                    }
                                }
                            case GHC.Integer.Type.None wilds70W_None:
                                {
                                    return GHC.Integer.Type.naught_DataCon.Eval();
                                }
                        }
                    }
                case 0: { return new GHC.Integer.Type.Positive(ps70T); }
            }
        }
        public static Closure smallShiftLPositive_Entry(Closure ps70B, long dss70C)
        {
            var dss70D = dss70C;
            switch (dss70D)
            {
                default:
                    {
                        var js70E = 64 - dss70D;
                        var fs70F = new Fun<long, long, Closure>(2, CLR.LoadFunctionPointer<long, long, Closure, ulong, Closure, Closure>(fs70F_Entry), dss70D, js70E, null);
                        fs70F.x2 = fs70F;
                        return fs70F.Apply<ulong, Closure, Closure>(0UL, ps70B);
                    }
                case 0: { return ps70B.Eval(); }
            }
        }
        public static Closure fs70F_Entry(long dss70D, long js70E, Closure fs70F, ulong carrys70G, Closure dss70H)
        {
            var wilds70I = dss70H.Eval();
            switch (wilds70I)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds70I_Some:
                    {
                        var ws70J = wilds70I_Some.x0;
                        var wss70K = wilds70I_Some.x1;
                        var sats70L = ws70J >> (int)js70E;
                        var dts70M = fs70F.Apply<ulong, Closure, Closure>(sats70L, wss70K).Eval();
                        var sats70N = ws70J << (int)dss70D;
                        var sats70O = sats70N | carrys70G;
                        return new GHC.Integer.Type.Some(sats70O, dts70M);
                    }
                case GHC.Integer.Type.None wilds70I_None:
                    {
                        var wilds70P = carrys70G;
                        switch (wilds70P)
                        {
                            default:
                                {
                                    return new GHC.Integer.Type.Some(wilds70P, GHC.Integer.Type.none_DataCon);
                                }
                            case 0UL: { return GHC.Integer.Type.none_DataCon.Eval(); }
                        }
                    }
            }
        }
        public static (Closure x0, long x1) decodeDoubleInteger_Entry(double ds70o)
        {
            var dss70p = GHC.Prim.decodeDouble2Int(ds70o);
            var dss70p_RawTuple = dss70p;
            var ipvs70q = dss70p_RawTuple.x0;
            var ipvs70r = dss70p_RawTuple.x1;
            var ipvs70s = dss70p_RawTuple.x2;
            var ipvs70t = dss70p_RawTuple.x3;
            var sats70z = new Updatable<long, ulong, ulong>(CLR.LoadFunctionPointer<long, ulong, ulong, Closure>(sats70z_Entry), ipvs70q, ipvs70r, ipvs70s);
            return (sats70z, ipvs70t);
        }
        public static Closure sats70z_Entry(long ipvs70q, ulong ipvs70r, ulong ipvs70s)
        {
            var sats70x = wordToInteger_Entry(ipvs70s).Eval();
            var sats70v = wordToInteger_Entry(ipvs70r).Eval();
            var sats70w = timesInteger_Entry(sats70v, GHC.Integer.Type.twoToTheThirtytwoInteger).Eval();
            var sats70y = plusInteger_Entry(sats70w, sats70x).Eval();
            var sats70u = smallInteger_Entry(ipvs70q).Eval();
            return timesInteger_Entry(sats70u, sats70y);
        }
        public static Closure complementInteger_Entry(Closure xs70m)
        {
            return minusInteger_Entry(GHC.Integer.Type.negativeOneInteger, xs70m);
        }
        public static Closure minusInteger_Entry(Closure i1s70i, Closure i2s70j)
        {
            var sats70k = negateInteger_Entry(i2s70j).Eval();
            return plusInteger_Entry(i1s70i, sats70k);
        }
        public static Closure plusInteger_Entry(Closure dss701, Closure dss702)
        {
            var wilds703 = dss701.Eval();
            switch (wilds703)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds703_Positive:
                    {
                        var p1s704 = wilds703_Positive.x0;
                        var wilds705 = dss702.Eval();
                        switch (wilds705)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Positive wilds705_Positive:
                                {
                                    var p2s706 = wilds705_Positive.x0;
                                    var dts707 = addWithCarrys6V2_Entry(0UL, p1s704, p2s706).Eval();
                                    return new GHC.Integer.Type.Positive(dts707);
                                }
                            case GHC.Integer.Type.Negative wilds705_Negative:
                                {
                                    var p2s708 = wilds705_Negative.x0;
                                    var wilds709 = comparePositive_Entry(p1s704, p2s708).Eval();
                                    var wilds709Tags709 = wilds709.Tag;
                                    switch (wilds709Tags709)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case 1:
                                            {
                                                var wilds709_LT = wilds709 as GHC.Types.LT;
                                                var dts70a = minusPositive_Entry(p2s708, p1s704).Eval();
                                                return new GHC.Integer.Type.Negative(dts70a);
                                            }
                                        case 2:
                                            {
                                                var wilds709_EQ = wilds709 as GHC.Types.EQ;
                                                return GHC.Integer.Type.naught_DataCon.Eval();
                                            }
                                        case 3:
                                            {
                                                var wilds709_GT = wilds709 as GHC.Types.GT;
                                                var dts70b = minusPositive_Entry(p1s704, p2s708).Eval();
                                                return new GHC.Integer.Type.Positive(dts70b);
                                            }
                                    }
                                }
                            case GHC.Integer.Type.Naught wilds705_Naught:
                                {
                                    return wilds703.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Negative wilds703_Negative:
                    {
                        var p1s70c = wilds703_Negative.x0;
                        var wilds70d = dss702.Eval();
                        switch (wilds70d)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Positive wilds70d_Positive:
                                {
                                    var p2s70e = wilds70d_Positive.x0;
                                    return plusInteger_Entry(wilds70d, wilds703);
                                }
                            case GHC.Integer.Type.Negative wilds70d_Negative:
                                {
                                    var p2s70f = wilds70d_Negative.x0;
                                    var dts70g = addWithCarrys6V2_Entry(0UL, p1s70c, p2s70f).Eval();
                                    return new GHC.Integer.Type.Negative(dts70g);
                                }
                            case GHC.Integer.Type.Naught wilds70d_Naught:
                                {
                                    return wilds703.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds703_Naught:
                    {
                        return dss702.Eval();
                    }
            }
        }
        public static Closure cmins6ZV_Entry(Closure xs6ZW, Closure ys6ZX)
        {
            var wilds6ZY = leIntegerHash_Entry(xs6ZW, ys6ZX);
            switch (wilds6ZY)
            {
                default: { return ys6ZX.Eval(); }
                case 1: { return xs6ZW.Eval(); }
            }
        }
        public static Closure cmaxs6ZR_Entry(Closure xs6ZS, Closure ys6ZT)
        {
            var wilds6ZU = leIntegerHash_Entry(xs6ZS, ys6ZT);
            switch (wilds6ZU)
            {
                default: { return xs6ZS.Eval(); }
                case 1: { return ys6ZT.Eval(); }
            }
        }
        public static Closure geInteger_Entry(Closure as6ZO, Closure bs6ZP)
        {
            var wilds6ZQ = geIntegerHash_Entry(as6ZO, bs6ZP);
            return GHC.Types.tagToEnumHash(wilds6ZQ);
        }
        public static long geIntegerHash_Entry(Closure xs6ZK, Closure ys6ZL)
        {
            var wilds6ZM = compareInteger_Entry(xs6ZK, ys6ZL).Eval();
            var wilds6ZMTags6ZM = wilds6ZM.Tag;
            switch (wilds6ZMTags6ZM)
            {
                default: { return 1; }
                case 1: { var wilds6ZM_LT = wilds6ZM as GHC.Types.LT; return 0; }
            }
        }
        public static Closure leInteger_Entry(Closure as6ZG, Closure bs6ZH)
        {
            var wilds6ZI = leIntegerHash_Entry(as6ZG, bs6ZH);
            return GHC.Types.tagToEnumHash(wilds6ZI);
        }
        public static long leIntegerHash_Entry(Closure xs6ZC, Closure ys6ZD)
        {
            var wilds6ZE = compareInteger_Entry(xs6ZC, ys6ZD).Eval();
            var wilds6ZETags6ZE = wilds6ZE.Tag;
            switch (wilds6ZETags6ZE)
            {
                default: { return 1; }
                case 3: { var wilds6ZE_GT = wilds6ZE as GHC.Types.GT; return 0; }
            }
        }
        public static Closure gtInteger_Entry(Closure as6Zy, Closure bs6Zz)
        {
            var wilds6ZA = gtIntegerHash_Entry(as6Zy, bs6Zz);
            return GHC.Types.tagToEnumHash(wilds6ZA);
        }
        public static long gtIntegerHash_Entry(Closure xs6Zu, Closure ys6Zv)
        {
            var wilds6Zw = compareInteger_Entry(xs6Zu, ys6Zv).Eval();
            var wilds6ZwTags6Zw = wilds6Zw.Tag;
            switch (wilds6ZwTags6Zw)
            {
                default: { return 0; }
                case 3: { var wilds6Zw_GT = wilds6Zw as GHC.Types.GT; return 1; }
            }
        }
        public static Closure ltInteger_Entry(Closure as6Zq, Closure bs6Zr)
        {
            var wilds6Zs = ltIntegerHash_Entry(as6Zq, bs6Zr);
            return GHC.Types.tagToEnumHash(wilds6Zs);
        }
        public static long ltIntegerHash_Entry(Closure xs6Zm, Closure ys6Zn)
        {
            var wilds6Zo = compareInteger_Entry(xs6Zm, ys6Zn).Eval();
            var wilds6ZoTags6Zo = wilds6Zo.Tag;
            switch (wilds6ZoTags6Zo)
            {
                default: { return 0; }
                case 1: { var wilds6Zo_LT = wilds6Zo as GHC.Types.LT; return 1; }
            }
        }
        public static Closure neqInteger_Entry(Closure as6Zh, Closure bs6Zi)
        {
            var wilds6Zj = neqIntegerHash_Entry(as6Zh, bs6Zi);
            return GHC.Types.tagToEnumHash(wilds6Zj);
        }
        public static long neqIntegerHash_Entry(Closure xs6Zd, Closure ys6Ze)
        {
            var wilds6Zf = compareInteger_Entry(xs6Zd, ys6Ze).Eval();
            var wilds6ZfTags6Zf = wilds6Zf.Tag;
            switch (wilds6ZfTags6Zf)
            {
                default: { return 1; }
                case 2: { var wilds6Zf_EQ = wilds6Zf as GHC.Types.EQ; return 0; }
            }
        }
        public static Closure eqInteger_Entry(Closure as6Z9, Closure bs6Za)
        {
            var wilds6Zb = eqIntegerHash_Entry(as6Z9, bs6Za);
            return GHC.Types.tagToEnumHash(wilds6Zb);
        }
        public static long eqIntegerHash_Entry(Closure xs6Z5, Closure ys6Z6)
        {
            var wilds6Z7 = compareInteger_Entry(xs6Z5, ys6Z6).Eval();
            var wilds6Z7Tags6Z7 = wilds6Z7.Tag;
            switch (wilds6Z7Tags6Z7)
            {
                default: { return 0; }
                case 2: { var wilds6Z7_EQ = wilds6Z7 as GHC.Types.EQ; return 1; }
            }
        }
        public static Closure compareInteger_Entry(Closure dss6YS, Closure dss6YT)
        {
            var wilds6YU = dss6YS.Eval();
            switch (wilds6YU)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6YU_Positive:
                    {
                        var xs6YV = wilds6YU_Positive.x0;
                        var wilds6YW = dss6YT.Eval();
                        switch (wilds6YW)
                        {
                            default: { return GHC.Types.gT_DataCon.Eval(); }
                            case GHC.Integer.Type.Positive wilds6YW_Positive:
                                {
                                    var ys6YX = wilds6YW_Positive.x0;
                                    return comparePositive_Entry(xs6YV, ys6YX);
                                }
                        }
                    }
                case GHC.Integer.Type.Negative wilds6YU_Negative:
                    {
                        var xs6YY = wilds6YU_Negative.x0;
                        var wilds6YZ = dss6YT.Eval();
                        switch (wilds6YZ)
                        {
                            default: { return GHC.Types.lT_DataCon.Eval(); }
                            case GHC.Integer.Type.Negative wilds6YZ_Negative:
                                {
                                    var ys6Z0 = wilds6YZ_Negative.x0;
                                    return comparePositive_Entry(ys6Z0, xs6YY);
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds6YU_Naught:
                    {
                        var wilds6Z1 = dss6YT.Eval();
                        switch (wilds6Z1)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Positive wilds6Z1_Positive:
                                {
                                    var ipvs6Z2 = wilds6Z1_Positive.x0;
                                    return GHC.Types.lT_DataCon.Eval();
                                }
                            case GHC.Integer.Type.Negative wilds6Z1_Negative:
                                {
                                    var dss6Z3 = wilds6Z1_Negative.x0;
                                    return GHC.Types.gT_DataCon.Eval();
                                }
                            case GHC.Integer.Type.Naught wilds6Z1_Naught:
                                {
                                    return GHC.Types.eQ_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure comparePositive_Entry(Closure dss6YD, Closure dss6YE)
        {
            var wilds6YF = dss6YD.Eval();
            switch (wilds6YF)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6YF_Some:
                    {
                        var xs6YG = wilds6YF_Some.x0;
                        var xss6YH = wilds6YF_Some.x1;
                        var wilds6YI = dss6YE.Eval();
                        switch (wilds6YI)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6YI_Some:
                                {
                                    var ys6YJ = wilds6YI_Some.x0;
                                    var yss6YK = wilds6YI_Some.x1;
                                    var wilds6YL = comparePositive_Entry(xss6YH, yss6YK).Eval();
                                    var wilds6YLTags6YL = wilds6YL.Tag;
                                    switch (wilds6YLTags6YL)
                                    {
                                        default: { return wilds6YL.Eval(); }
                                        case 2:
                                            {
                                                var wilds6YL_EQ = wilds6YL as GHC.Types.EQ;
                                                var lwilds6YM = (xs6YG < ys6YJ) ? 1 : 0;
                                                switch (lwilds6YM)
                                                {
                                                    default:
                                                        {
                                                            var lwilds6YN = (xs6YG > ys6YJ) ? 1 : 0;
                                                            switch (lwilds6YN)
                                                            {
                                                                default: { return GHC.Types.eQ_DataCon.Eval(); }
                                                                case 1: { return GHC.Types.gT_DataCon.Eval(); }
                                                            }
                                                        }
                                                    case 1: { return GHC.Types.lT_DataCon.Eval(); }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.None wilds6YI_None:
                                {
                                    return GHC.Types.gT_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6YF_None:
                    {
                        var wilds6YO = dss6YE.Eval();
                        switch (wilds6YO)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6YO_Some:
                                {
                                    var dss6YP = wilds6YO_Some.x0;
                                    var dss6YQ = wilds6YO_Some.x1; return GHC.Types.lT_DataCon.Eval();
                                }
                            case GHC.Integer.Type.None wilds6YO_None:
                                {
                                    return GHC.Types.eQ_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure digitsToInteger_Entry(Closure dss6Yy)
        {
            var wilds6Yz = removeZeroTails_Entry(dss6Yy).Eval();
            switch (wilds6Yz)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Yz_Some:
                    {
                        var ipvs6YA = wilds6Yz_Some.x0;
                        var ipvs6YB = wilds6Yz_Some.x1;
                        return new GHC.Integer.Type.Positive(wilds6Yz);
                    }
                case GHC.Integer.Type.None wilds6Yz_None:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure digitsToNegativeInteger_Entry(Closure dss6Yt)
        {
            var wilds6Yu = removeZeroTails_Entry(dss6Yt).Eval();
            switch (wilds6Yu)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Yu_Some:
                    {
                        var ipvs6Yv = wilds6Yu_Some.x0;
                        var ipvs6Yw = wilds6Yu_Some.x1;
                        return new GHC.Integer.Type.Negative(wilds6Yu);
                    }
                case GHC.Integer.Type.None wilds6Yu_None:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure removeZeroTails_Entry(Closure dss6Yj)
        {
            var wilds6Yk = dss6Yj.Eval();
            switch (wilds6Yk)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Yk_Some:
                    {
                        var ws6Yl = wilds6Yk_Some.x0;
                        var dss6Ym = wilds6Yk_Some.x1;
                        var wilds6Yn = ws6Yl;
                        switch (wilds6Yn)
                        {
                            default:
                                {
                                    var dts6Yo = removeZeroTails_Entry(dss6Ym).Eval();
                                    return new GHC.Integer.Type.Some(wilds6Yn, dts6Yo);
                                }
                            case 0UL:
                                {
                                    var wilds6Yp = removeZeroTails_Entry(dss6Ym).Eval();
                                    switch (wilds6Yp)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Some wilds6Yp_Some:
                                            {
                                                var ipvs6Yq = wilds6Yp_Some.x0;
                                                var ipvs6Yr = wilds6Yp_Some.x1;
                                                return new GHC.Integer.Type.Some(0UL, wilds6Yp);
                                            }
                                        case GHC.Integer.Type.None wilds6Yp_None:
                                            {
                                                return GHC.Integer.Type.none_DataCon.Eval();
                                            }
                                    }
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6Yk_None:
                    {
                        return GHC.Integer.Type.none_DataCon.Eval();
                    }
            }
        }
        public static Closure digitsMaybeZeroToInteger_Entry(Closure dss6Ye)
        {
            var wilds6Yf = dss6Ye.Eval();
            switch (wilds6Yf)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Yf_Some:
                    {
                        var ipvs6Yg = wilds6Yf_Some.x0;
                        var ipvs6Yh = wilds6Yf_Some.x1;
                        return new GHC.Integer.Type.Positive(wilds6Yf);
                    }
                case GHC.Integer.Type.None wilds6Yf_None:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure timesInteger_Entry(Closure dss6XV, Closure dss6XW)
        {
            var wilds6XX = dss6XV.Eval();
            switch (wilds6XX)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6XX_Positive:
                    {
                        var p1s6XY = wilds6XX_Positive.x0;
                        var wilds6XZ = dss6XW.Eval();
                        switch (wilds6XZ)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Positive wilds6XZ_Positive:
                                {
                                    var p2s6Y0 = wilds6XZ_Positive.x0;
                                    var dts6Y1 = timesPositive_Entry(p1s6XY, p2s6Y0).Eval();
                                    return new GHC.Integer.Type.Positive(dts6Y1);
                                }
                            case GHC.Integer.Type.Negative wilds6XZ_Negative:
                                {
                                    var p2s6Y2 = wilds6XZ_Negative.x0;
                                    var dts6Y3 = timesPositive_Entry(p1s6XY, p2s6Y2).Eval();
                                    return new GHC.Integer.Type.Negative(dts6Y3);
                                }
                            case GHC.Integer.Type.Naught wilds6XZ_Naught:
                                {
                                    return GHC.Integer.Type.naught_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Negative wilds6XX_Negative:
                    {
                        var p1s6Y4 = wilds6XX_Negative.x0;
                        var wilds6Y5 = dss6XW.Eval();
                        switch (wilds6Y5)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Positive wilds6Y5_Positive:
                                {
                                    var p2s6Y6 = wilds6Y5_Positive.x0;
                                    var dts6Y7 = timesPositive_Entry(p1s6Y4, p2s6Y6).Eval();
                                    return new GHC.Integer.Type.Negative(dts6Y7);
                                }
                            case GHC.Integer.Type.Negative wilds6Y5_Negative:
                                {
                                    var p2s6Y8 = wilds6Y5_Negative.x0;
                                    var dts6Y9 = timesPositive_Entry(p1s6Y4, p2s6Y8).Eval();
                                    return new GHC.Integer.Type.Positive(dts6Y9);
                                }
                            case GHC.Integer.Type.Naught wilds6Y5_Naught:
                                {
                                    return GHC.Integer.Type.naught_DataCon.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.Naught wilds6XX_Naught:
                    {
                        var dss6Ya = dss6XW.Eval();
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure timesPositive_Entry(Closure dss6Xt, Closure dss6Xu)
        {
            var wilds6Xv = dss6Xt.Eval();
            switch (wilds6Xv)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Xv_Some:
                    {
                        var dss6Xw = wilds6Xv_Some.x0;
                        var dss6Xx = wilds6Xv_Some.x1;
                        var wilds6Xy = dss6Xu.Eval();
                        switch (wilds6Xy)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6Xy_Some:
                                {
                                    var ys6Xz = wilds6Xy_Some.x0;
                                    var ys_s6XA = wilds6Xy_Some.x1;
                                    var wilds6XB = dss6Xx.Eval();
                                    switch (wilds6XB)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Integer.Type.Some wilds6XB_Some:
                                            {
                                                var dss6XC = wilds6XB_Some.x0;
                                                var dss6XD = wilds6XB_Some.x1;
                                                var wilds6XE = ys_s6XA.Eval();
                                                switch (wilds6XE)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Some wilds6XE_Some:
                                                        {
                                                            var dss6XF = wilds6XE_Some.x0;
                                                            var dss6XG = wilds6XE_Some.x1;
                                                            var dts6XH = timesPositive_Entry(wilds6XB, wilds6Xy).Eval();
                                                            var sats6XK = new GHC.Integer.Type.Some(0UL, dts6XH);
                                                            var sats6XI = new GHC.Integer.Type.Some(dss6Xw, GHC.Integer.Type.none_DataCon);
                                                            var sats6XJ = timesPositive_Entry(sats6XI, wilds6Xy).Eval();
                                                            return addWithCarrys6V2_Entry(0UL, sats6XJ, sats6XK);
                                                        }
                                                    case GHC.Integer.Type.None wilds6XE_None:
                                                        {
                                                            var wilds6XL = dss6Xw;
                                                            switch (wilds6XL)
                                                            {
                                                                default:
                                                                    {
                                                                        var dts6XM = timesPositive_Entry(wilds6XB, wilds6Xy).Eval();
                                                                        var sats6XO = new GHC.Integer.Type.Some(0UL, dts6XM);
                                                                        var sats6XN = timesDigit_Entry(wilds6XL, ys6Xz).Eval();
                                                                        return addWithCarrys6V2_Entry(0UL, sats6XN, sats6XO);
                                                                    }
                                                                case 0UL:
                                                                    {
                                                                        var dts6XP = timesPositive_Entry(wilds6XB, wilds6Xy).Eval();
                                                                        return new GHC.Integer.Type.Some(0UL, dts6XP);
                                                                    }
                                                            }
                                                        }
                                                }
                                            }
                                        case GHC.Integer.Type.None wilds6XB_None:
                                            {
                                                var wilds6XQ = ys_s6XA.Eval();
                                                switch (wilds6XQ)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Some wilds6XQ_Some:
                                                        {
                                                            var dss6XR = wilds6XQ_Some.x0;
                                                            var dss6XS = wilds6XQ_Some.x1;
                                                            return timesPositive_Entry(wilds6Xy, wilds6Xv);
                                                        }
                                                    case GHC.Integer.Type.None wilds6XQ_None:
                                                        {
                                                            return timesDigit_Entry(dss6Xw, ys6Xz);
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.None wilds6Xy_None:
                                {
                                    return GHC.Integer.Type.errorPositive.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6Xv_None:
                    {
                        var wilds6XT = dss6Xu.Eval();
                        return GHC.Integer.Type.errorPositive.Eval();
                    }
            }
        }
        public static Closure timesDigit_Entry(ulong xs6X3, ulong ys6X4)
        {
            var dss6X5 = xs6X3 >> (int)32;
            var dss6X6 = ys6X4 & 4294967295UL;
            var xs6X7 = dss6X5 * dss6X6;
            var dss6X8 = xs6X3 & 4294967295UL;
            var dss6X9 = ys6X4 >> (int)32;
            var xs6Xa = dss6X8 * dss6X9;
            var sats6Xj = dss6X8 * dss6X6;
            var sats6Xk = new GHC.Integer.Type.Some(sats6Xj, GHC.Integer.Type.none_DataCon);
            var sats6Xf = xs6Xa & 4294967295UL;
            var sats6Xg = sats6Xf << (int)32;
            var sats6Xh = new GHC.Integer.Type.Some(sats6Xg, GHC.Integer.Type.none_DataCon);
            var sats6Xc = xs6X7 & 4294967295UL;
            var sats6Xd = sats6Xc << (int)32;
            var sats6Xe = new GHC.Integer.Type.Some(sats6Xd, GHC.Integer.Type.none_DataCon);
            var sats6Xi = addWithCarrys6V2_Entry(0UL, sats6Xe, sats6Xh).Eval();
            var lows6Xb = addWithCarrys6V2_Entry(0UL, sats6Xi, sats6Xk).Eval();
            var sats6Xo = xs6Xa >> (int)32;
            var sats6Xm = xs6X7 >> (int)32;
            var sats6Xl = dss6X5 * dss6X9;
            var sats6Xn = sats6Xl + sats6Xm;
            var wilds6Xp = sats6Xn + sats6Xo;
            switch (wilds6Xp)
            {
                default:
                    {
                        var sats6Xq = new GHC.Integer.Type.Some(wilds6Xp, GHC.Integer.Type.none_DataCon);
                        var sats6Xr = new GHC.Integer.Type.Some(0UL, sats6Xq);
                        return addWithCarrys6V2_Entry(0UL, sats6Xr, lows6Xb);
                    }
                case 0UL: { return lows6Xb.Eval(); }
            }
        }
        public static float floatFromInteger_Entry(Closure dss6WX)
        {
            var wilds6WY = dss6WX.Eval();
            switch (wilds6WY)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6WY_Positive:
                    {
                        var ps6WZ = wilds6WY_Positive.x0;
                        return floatFromPositive_Entry(ps6WZ);
                    }
                case GHC.Integer.Type.Negative wilds6WY_Negative:
                    {
                        var ps6X0 = wilds6WY_Negative.x0;
                        var wilds6X1 = floatFromPositive_Entry(ps6X0);
                        return -wilds6X1;
                    }
                case GHC.Integer.Type.Naught wilds6WY_Naught: { return 0 % 1f; }
            }
        }
        public static float floatFromPositive_Entry(Closure dss6WG)
        {
            var wilds6WH = dss6WG.Eval();
            switch (wilds6WH)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6WH_Some:
                    {
                        var ws6WI = wilds6WH_Some.x0;
                        var dss6WJ = wilds6WH_Some.x1;
                        var wilds6WK = floatFromPositive_Entry(dss6WJ);
                        var sats6WT = ws6WI & 4294967295UL;
                        var sats6WU = (long)sats6WT;
                        var sats6WV = (float)sats6WU;
                        var sats6WQ = (float)System.Math.Pow(2 % 1f, 32 % 1f);
                        var sats6WN = ws6WI >> (int)32;
                        var sats6WO = (long)sats6WN;
                        var sats6WP = (float)sats6WO;
                        var sats6WR = sats6WP * sats6WQ;
                        var sats6WL = (float)System.Math.Pow(2 % 1f, 64 % 1f);
                        var sats6WM = wilds6WK * sats6WL;
                        var sats6WS = sats6WM + sats6WR; return sats6WS + sats6WV;
                    }
                case GHC.Integer.Type.None wilds6WH_None: { return 0 % 1f; }
            }
        }
        public static double doubleFromInteger_Entry(Closure dss6WA)
        {
            var wilds6WB = dss6WA.Eval();
            switch (wilds6WB)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6WB_Positive:
                    {
                        var ps6WC = wilds6WB_Positive.x0;
                        return doubleFromPositive_Entry(ps6WC);
                    }
                case GHC.Integer.Type.Negative wilds6WB_Negative:
                    {
                        var ps6WD = wilds6WB_Negative.x0;
                        var wilds6WE = doubleFromPositive_Entry(ps6WD);
                        return -wilds6WE;
                    }
                case GHC.Integer.Type.Naught wilds6WB_Naught: { return 0 % 1; }
            }
        }
        public static double doubleFromPositive_Entry(Closure dss6Wj)
        {
            var wilds6Wk = dss6Wj.Eval();
            switch (wilds6Wk)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6Wk_Some:
                    {
                        var ws6Wl = wilds6Wk_Some.x0;
                        var dss6Wm = wilds6Wk_Some.x1;
                        var wilds6Wn = doubleFromPositive_Entry(dss6Wm);
                        var sats6Ww = ws6Wl & 4294967295UL;
                        var sats6Wx = (long)sats6Ww;
                        var sats6Wy = (float)sats6Wx;
                        var sats6Wt = System.Math.Pow(2 % 1, 32 % 1);
                        var sats6Wq = ws6Wl >> (int)32;
                        var sats6Wr = (long)sats6Wq;
                        var sats6Ws = (float)sats6Wr;
                        var sats6Wu = sats6Ws * sats6Wt;
                        var sats6Wo = System.Math.Pow(2 % 1, 64 % 1);
                        var sats6Wp = wilds6Wn * sats6Wo;
                        var sats6Wv = sats6Wp + sats6Wu; return sats6Wv + sats6Wy;
                    }
                case GHC.Integer.Type.None wilds6Wk_None: { return 0 % 1; }
            }
        }
        public static (ulong x0, ulong x1) splitHalves_Entry(ulong xs6Wf)
        {
            var sats6Wh = xs6Wf & 4294967295UL;
            var sats6Wg = xs6Wf >> (int)32; return (sats6Wg, sats6Wh);
        }
        public static long highHalfShift_Entry(Closure dss6Wc)
        {
            var wilds6Wd = dss6Wc.Eval();
            var wilds6WdTags6Wd = wilds6Wd.Tag;
            switch (wilds6WdTags6Wd)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds6Wd_Unit = wilds6Wd as GHC.Tuple.Unit; return 32;
                    }
            }
        }
        public static ulong lowHalfMask_Entry(Closure dss6W9)
        {
            var wilds6Wa = dss6W9.Eval();
            var wilds6WaTags6Wa = wilds6Wa.Tag;
            switch (wilds6WaTags6Wa)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds6Wa_Unit = wilds6Wa as GHC.Tuple.Unit;
                        return 4294967295UL;
                    }
            }
        }
        public static Closure twosComplementPositive_Entry(Closure etaB1)
        {
            return twosComplementPositives6W4_Entry(etaB1);
        }
        public static Closure twosComplementPositives6W4_Entry(Closure ps6W5)
        {
            var sats6W6 = minusPositive_Entry(ps6W5, GHC.Integer.Type.onePositive).Eval();
            return flipBitsDigits_Entry(sats6W6);
        }
        public static Closure minusPositive_Entry(Closure dss6VJ, Closure dss6VK)
        {
            var wilds6VL = dss6VJ.Eval();
            switch (wilds6VL)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6VL_Some:
                    {
                        var xs6VM = wilds6VL_Some.x0;
                        var xss6VN = wilds6VL_Some.x1;
                        var wilds6VO = dss6VK.Eval();
                        switch (wilds6VO)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6VO_Some:
                                {
                                    var ys6VP = wilds6VO_Some.x0;
                                    var yss6VQ = wilds6VO_Some.x1;
                                    var lwilds6VR = (xs6VM == ys6VP) ? 1 : 0;
                                    switch (lwilds6VR)
                                    {
                                        default:
                                            {
                                                var lwilds6VS = (xs6VM > ys6VP) ? 1 : 0;
                                                switch (lwilds6VS)
                                                {
                                                    default:
                                                        {
                                                            var sats6VT = minusPositive_Entry(xss6VN, yss6VQ).Eval();
                                                            var dts6VU = minusPositive_Entry(sats6VT, GHC.Integer.Type.onePositive).Eval();
                                                            var sats6VV = xs6VM - ys6VP;
                                                            return new GHC.Integer.Type.Some(sats6VV, dts6VU);
                                                        }
                                                    case 1:
                                                        {
                                                            var dts6VW = minusPositive_Entry(xss6VN, yss6VQ).Eval();
                                                            var sats6VX = xs6VM - ys6VP;
                                                            return new GHC.Integer.Type.Some(sats6VX, dts6VW);
                                                        }
                                                }
                                            }
                                        case 1:
                                            {
                                                var wilds6VY = minusPositive_Entry(xss6VN, yss6VQ).Eval();
                                                switch (wilds6VY)
                                                {
                                                    default: { throw new ImpossibleException(); }
                                                    case GHC.Integer.Type.Some wilds6VY_Some:
                                                        {
                                                            var ipvs6VZ = wilds6VY_Some.x0;
                                                            var ipvs6W0 = wilds6VY_Some.x1;
                                                            return new GHC.Integer.Type.Some(0UL, wilds6VY);
                                                        }
                                                    case GHC.Integer.Type.None wilds6VY_None:
                                                        {
                                                            return GHC.Integer.Type.none_DataCon.Eval();
                                                        }
                                                }
                                            }
                                    }
                                }
                            case GHC.Integer.Type.None wilds6VO_None:
                                {
                                    return wilds6VL.Eval();
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6VL_None:
                    {
                        var wilds6W1 = dss6VK.Eval();
                        switch (wilds6W1)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6W1_Some:
                                {
                                    var dss6W2 = wilds6W1_Some.x0;
                                    var dss6W3 = wilds6W1_Some.x1;
                                    return GHC.Integer.Type.errorPositive.Eval();
                                }
                            case GHC.Integer.Type.None wilds6W1_None:
                                {
                                    return GHC.Integer.Type.none_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure plusPositive_Entry(Closure x0s6VG, Closure y0s6VH)
        {
            return addWithCarrys6V2_Entry(0UL, x0s6VG, y0s6VH);
        }
        public static Closure addWithCarrys6V2_Entry(ulong cs6V3, Closure dss6V4, Closure dss6V5)
        {
            var wilds6V6 = dss6V4.Eval();
            switch (wilds6V6)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6V6_Some:
                    {
                        var dss6V7 = wilds6V6_Some.x0;
                        var dss6V8 = wilds6V6_Some.x1;
                        var wilds6V9 = dss6V5.Eval();
                        switch (wilds6V9)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6V9_Some:
                                {
                                    var ys6Va = wilds6V9_Some.x0;
                                    var ys_s6Vb = wilds6V9_Some.x1;
                                    var lwilds6Vc = (dss6V7 < ys6Va) ? 1 : 0;
                                    switch (lwilds6Vc)
                                    {
                                        default:
                                            {
                                                var lwilds6Vd = (ys6Va >= 9223372036854775808UL) ? 1 : 0;
                                                switch (lwilds6Vd)
                                                {
                                                    default:
                                                        {
                                                            var lwilds6Ve = (dss6V7 >= 9223372036854775808UL) ? 1 : 0;
                                                            switch (lwilds6Ve)
                                                            {
                                                                default:
                                                                    {
                                                                        var dts6Vf = addWithCarrys6V2_Entry(0UL, dss6V8, ys_s6Vb).Eval();
                                                                        var sats6Vg = dss6V7 + ys6Va;
                                                                        var sats6Vh = sats6Vg + cs6V3;
                                                                        return new GHC.Integer.Type.Some(sats6Vh, dts6Vf);
                                                                    }
                                                                case 1:
                                                                    {
                                                                        var sats6Vj = ys6Va + dss6V7;
                                                                        var sats6Vk = cs6V3 + sats6Vj;
                                                                        var zs6Vi = sats6Vk - 9223372036854775808UL;
                                                                        var lwilds6Vl = (zs6Vi < 9223372036854775808UL) ? 1 : 0;
                                                                        switch (lwilds6Vl)
                                                                        {
                                                                            default:
                                                                                {
                                                                                    var dts6Vm = addWithCarrys6V2_Entry(1UL, dss6V8, ys_s6Vb).Eval();
                                                                                    var sats6Vn = zs6Vi - 9223372036854775808UL;
                                                                                    return new GHC.Integer.Type.Some(sats6Vn, dts6Vm);
                                                                                }
                                                                            case 1:
                                                                                {
                                                                                    var dts6Vo = addWithCarrys6V2_Entry(0UL, dss6V8, ys_s6Vb).Eval();
                                                                                    var sats6Vp = zs6Vi + 9223372036854775808UL;
                                                                                    return new GHC.Integer.Type.Some(sats6Vp, dts6Vo);
                                                                                }
                                                                        }
                                                                    }
                                                            }
                                                        }
                                                    case 1:
                                                        {
                                                            var dts6Vq = addWithCarrys6V2_Entry(1UL, dss6V8, ys_s6Vb).Eval();
                                                            var sats6Vr = dss6V7 + ys6Va;
                                                            var sats6Vs = sats6Vr + cs6V3;
                                                            return new GHC.Integer.Type.Some(sats6Vs, dts6Vq);
                                                        }
                                                }
                                            }
                                        case 1:
                                            {
                                                return addWithCarrys6V2_Entry(cs6V3, wilds6V9, wilds6V6);
                                            }
                                    }
                                }
                            case GHC.Integer.Type.None wilds6V9_None:
                                {
                                    var wilds6Vt = cs6V3;
                                    switch (wilds6Vt)
                                    {
                                        default:
                                            {
                                                var wws6Vu = wsuccPositives6UI_Entry(wilds6V6);
                                                var wws6Vu_RawTuple = wws6Vu;
                                                var wws6Vv = wws6Vu_RawTuple.x0;
                                                var wws6Vw = wws6Vu_RawTuple.x1;
                                                return new GHC.Integer.Type.Some(wws6Vv, wws6Vw);
                                            }
                                        case 0UL: { return wilds6V6.Eval(); }
                                    }
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6V6_None:
                    {
                        var wilds6Vx = dss6V5.Eval();
                        switch (wilds6Vx)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6Vx_Some:
                                {
                                    var dss6Vy = wilds6Vx_Some.x0;
                                    var dss6Vz = wilds6Vx_Some.x1;
                                    var wilds6VA = cs6V3;
                                    switch (wilds6VA)
                                    {
                                        default:
                                            {
                                                var wws6VB = wsuccPositives6UI_Entry(wilds6Vx);
                                                var wws6VB_RawTuple = wws6VB;
                                                var wws6VC = wws6VB_RawTuple.x0;
                                                var wws6VD = wws6VB_RawTuple.x1;
                                                return new GHC.Integer.Type.Some(wws6VC, wws6VD);
                                            }
                                        case 0UL: { return wilds6Vx.Eval(); }
                                    }
                                }
                            case GHC.Integer.Type.None wilds6Vx_None:
                                {
                                    var wilds6VE = cs6V3;
                                    switch (wilds6VE)
                                    {
                                        default: { return lvls6UY.Eval(); }
                                        case 0UL: { return GHC.Integer.Type.none_DataCon.Eval(); }
                                    }
                                }
                        }
                    }
            }
        }
        public static Closure lvls6UY_Entry()
        {
            var wws6UZ = wsuccPositives6UI_Entry(GHC.Integer.Type.none_DataCon);
            var wws6UZ_RawTuple = wws6UZ;
            var wws6V0 = wws6UZ_RawTuple.x0;
            var wws6V1 = wws6UZ_RawTuple.x1;
            return new GHC.Integer.Type.Some(wws6V0, wws6V1);
        }
        public static Closure succPositive_Entry(Closure ws6UU)
        {
            var wws6UV = wsuccPositives6UI_Entry(ws6UU);
            var wws6UV_RawTuple = wws6UV;
            var wws6UW = wws6UV_RawTuple.x0;
            var wws6UX = wws6UV_RawTuple.x1;
            return new GHC.Integer.Type.Some(wws6UW, wws6UX);
        }
        public static (ulong x0, Closure x1) wsuccPositives6UI_Entry(Closure ws6UJ)
        {
            var wilds6UK = ws6UJ.Eval();
            switch (wilds6UK)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6UK_Some:
                    {
                        var ws6UL = wilds6UK_Some.x0;
                        var wss6UM = wilds6UK_Some.x1;
                        var wilds6UN = ws6UL;
                        switch (wilds6UN)
                        {
                            default:
                                {
                                    var sats6UO = wilds6UN + 1UL; return (sats6UO, wss6UM);
                                }
                            case 18446744073709551615UL:
                                {
                                    var wws6UP = wsuccPositives6UI_Entry(wss6UM);
                                    var wws6UP_RawTuple = wws6UP;
                                    var wws6UQ = wws6UP_RawTuple.x0;
                                    var wws6UR = wws6UP_RawTuple.x1;
                                    var sats6US = new GHC.Integer.Type.Some(wws6UQ, wws6UR);
                                    return (0UL, sats6US);
                                }
                        }
                    }
                case GHC.Integer.Type.None wilds6UK_None:
                    {
                        return (1UL, GHC.Integer.Type.none_DataCon);
                    }
            }
        }
        public static ulong fullBound_Entry(Closure dss6UG)
        {
            var wilds6UH = dss6UG.Eval();
            var wilds6UHTags6UH = wilds6UH.Tag;
            switch (wilds6UHTags6UH)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds6UH_Unit = wilds6UH as GHC.Tuple.Unit;
                        return 18446744073709551615UL;
                    }
            }
        }
        public static ulong halfBoundUp_Entry(Closure dss6UD)
        {
            var wilds6UE = dss6UD.Eval();
            var wilds6UETags6UE = wilds6UE.Tag;
            switch (wilds6UETags6UE)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds6UE_Unit = wilds6UE as GHC.Tuple.Unit;
                        return 9223372036854775808UL;
                    }
            }
        }
        public static Closure signumInteger_Entry(Closure dss6Uy)
        {
            var wilds6Uz = dss6Uy.Eval();
            switch (wilds6Uz)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6Uz_Positive:
                    {
                        var dss6UA = wilds6Uz_Positive.x0;
                        return GHC.Integer.Type.oneInteger.Eval();
                    }
                case GHC.Integer.Type.Negative wilds6Uz_Negative:
                    {
                        var dss6UB = wilds6Uz_Negative.x0;
                        return GHC.Integer.Type.negativeOneInteger.Eval();
                    }
                case GHC.Integer.Type.Naught wilds6Uz_Naught:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure absInteger_Entry(Closure dss6Ur)
        {
            var wilds6Us = dss6Ur.Eval();
            switch (wilds6Us)
            {
                default: { return wilds6Us.Eval(); }
                case GHC.Integer.Type.Negative wilds6Us_Negative:
                    {
                        var xs6Ut = wilds6Us_Negative.x0;
                        return new GHC.Integer.Type.Positive(xs6Ut);
                    }
            }
        }
        public static (Closure x0, long x1) decodeFloatInteger_Entry(float fs6Ul)
        {
            var dss6Um = GHC.Prim.floatDouble2Int(fs6Ul);
            var dss6Um_RawTuple = dss6Um;
            var ipvs6Un = dss6Um_RawTuple.x0;
            var ipvs6Uo = dss6Um_RawTuple.x1;
            var sats6Up = new Updatable<long>(CLR.LoadFunctionPointer<long, Closure>(sats6Up_Entry), ipvs6Un);
            return (sats6Up, ipvs6Uo);
        }
        public static Closure sats6Up_Entry(long ipvs6Un)
        {
            return smallInteger_Entry(ipvs6Un);
        }
        public static Closure smallInteger_Entry(long is6Ue)
        {
            var lwilds6Uf = (is6Ue >= 0) ? 1 : 0;
            switch (lwilds6Uf)
            {
                default:
                    {
                        var sats6Ug = -is6Ue;
                        var sats6Uh = (ulong)sats6Ug;
                        var sats6Ui = wordToInteger_Entry(sats6Uh).Eval();
                        return negateInteger_Entry(sats6Ui);
                    }
                case 1:
                    {
                        var sats6Uj = (ulong)is6Ue;
                        return wordToInteger_Entry(sats6Uj);
                    }
            }
        }
        public static Closure negateInteger_Entry(Closure dss6U9)
        {
            var wilds6Ua = dss6U9.Eval();
            switch (wilds6Ua)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6Ua_Positive:
                    {
                        var ps6Ub = wilds6Ua_Positive.x0;
                        return new GHC.Integer.Type.Negative(ps6Ub);
                    }
                case GHC.Integer.Type.Negative wilds6Ua_Negative:
                    {
                        var ps6Uc = wilds6Ua_Negative.x0;
                        return new GHC.Integer.Type.Positive(ps6Uc);
                    }
                case GHC.Integer.Type.Naught wilds6Ua_Naught:
                    {
                        return GHC.Integer.Type.naught_DataCon.Eval();
                    }
            }
        }
        public static Closure flipBits_Entry(Closure etaB1)
        {
            return flipBitss6U5_Entry(etaB1);
        }
        public static Closure flipBitss6U5_Entry(Closure dss6U6)
        {
            return flipBitsDigits_Entry(dss6U6);
        }
        public static Closure flipBitsDigits_Entry(Closure dss6TZ)
        {
            var wilds6U0 = dss6TZ.Eval();
            switch (wilds6U0)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Some wilds6U0_Some:
                    {
                        var ws6U1 = wilds6U0_Some.x0;
                        var wss6U2 = wilds6U0_Some.x1;
                        var dts6U3 = flipBitsDigits_Entry(wss6U2).Eval();
                        var sats6U4 = ~ws6U1;
                        return new GHC.Integer.Type.Some(sats6U4, dts6U3);
                    }
                case GHC.Integer.Type.None wilds6U0_None:
                    {
                        return GHC.Integer.Type.none_DataCon.Eval();
                    }
            }
        }
        public static long hashInteger_Entry(Closure etaB1)
        {
            return integerToInt_Entry(etaB1);
        }
        public static long integerToInt_Entry(Closure is6TV)
        {
            var wilds6TW = integerToWord_Entry(is6TV);
            return (long)wilds6TW;
        }
        public static ulong integerToWord_Entry(Closure dss6TK)
        {
            var wilds6TL = dss6TK.Eval();
            switch (wilds6TL)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Integer.Type.Positive wilds6TL_Positive:
                    {
                        var dss6TM = wilds6TL_Positive.x0;
                        var wilds6TN = dss6TM.Eval();
                        switch (wilds6TN)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6TN_Some:
                                {
                                    var ws6TO = wilds6TN_Some.x0;
                                    var dss6TP = wilds6TN_Some.x1; return ws6TO;
                                }
                            case GHC.Integer.Type.None wilds6TN_None: { return 0UL; }
                        }
                    }
                case GHC.Integer.Type.Negative wilds6TL_Negative:
                    {
                        var dss6TQ = wilds6TL_Negative.x0;
                        var wilds6TR = dss6TQ.Eval();
                        switch (wilds6TR)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Integer.Type.Some wilds6TR_Some:
                                {
                                    var ws6TS = wilds6TR_Some.x0;
                                    var dss6TT = wilds6TR_Some.x1; return 0UL - ws6TS;
                                }
                            case GHC.Integer.Type.None wilds6TR_None: { return 0UL; }
                        }
                    }
                case GHC.Integer.Type.Naught wilds6TL_Naught: { return 0UL; }
            }
        }
        public static Closure wordToInteger_Entry(ulong ws6TG)
        {
            var wilds6TH = ws6TG;
            switch (wilds6TH)
            {
                default:
                    {
                        var sats6TI = new GHC.Integer.Type.Some(wilds6TH, GHC.Integer.Type.none_DataCon);
                        return new GHC.Integer.Type.Positive(sats6TI);
                    }
                case 0UL: { return GHC.Integer.Type.naught_DataCon.Eval(); }
            }
        }
        public sealed class None : Data
        {
            public None() { }
            public override int Tag => 2;
        }
        public sealed class Some : Data
        {
            public ulong x0; public Closure x1;
            public Some(ulong x0, Closure x1)
            {
                this.x0 = x0; this.x1 = x1;
            }
            public override int Tag => 1;
        }
        public sealed class Naught : Data
        {
            public Naught() { }
            public override int Tag => 3;
        }
        public sealed class Negative : Data
        {
            public Closure x0;
            public Negative(Closure x0) { this.x0 = x0; }
            public override int Tag => 2;
        }
        public sealed class Positive : Data
        {
            public Closure x0;
            public Positive(Closure x0) { this.x0 = x0; }
            public override int Tag => 1;
        }
        public sealed class Cons : Data
        {
            public Closure x0; public Closure x1;
            public Cons(Closure x0, Closure x1)
            {
                this.x0 = x0; this.x1 = x1;
            }
            public override int Tag => 2;
        }
        public sealed class Nil : Data
        {
            public Nil() { }
            public override int Tag => 1;
        }
    }
}
