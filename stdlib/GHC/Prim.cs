using System;
using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Prim
    {
        public static Void voidHash;
        public static StateHash realWorldHash;

        public struct Void { }

        /**
            ()# is a special type that is used as a
            one element tuple for returns in IO.
         */
        public sealed class UnitHash : Data
        {
            public Closure x0;
            public UnitHash(Closure x0) { this.x0 = x0; }
        }

        public static Closure seqHash(Closure s, Void voidE)
        {
            return s.Eval();
        }
        public static Closure seq_Entry(Closure a, Closure b)
        {
            a.Eval();
            return b.Eval();
        }

        public static Closure raiseIOHash(Closure exc, Void voidHash)
        {
            throw new ClosureException() { Exception = exc };
        }
        public static Closure catchHash(Closure work, Closure handler, Void voidHash)
        {
            try
            {
                return work.Apply<Void, Closure>(voidHash);
            }
            catch (ClosureException ce)
            {
                return handler.Apply<Closure, Void, Closure>(ce.Exception, voidHash);
            }
        }

        public static Closure maskAsyncExceptionsHash(Closure id_s5Pa, Void voidHash)
        {
            throw new NotImplementedException();
        }

        public static Closure unmaskAsyncExceptionsHash(Closure yd_s5Ps, Void voidHash)
        {
            throw new NotImplementedException();
        }

        public static long getMaskingStateHash(Void voidHash)
        {
            throw new NotImplementedException();
        }

        public static Closure maskUninterruptibleHash(Closure ne_s5PK, Void voidHash)
        {
            throw new NotImplementedException();
        }

        public struct StateHash
        {
        }

        public static byte[] resizeArray(byte[] a, ulong size) {
            System.Array.Resize(ref a, (int)size);
            return a;
        }

        internal static object copyArray(byte[] aHashsyAk, long satsyAx, byte[] ipvsyAs, long satsyAy, long satsyAA, Void voidHash)
        {
            throw new NotImplementedException();
        }

        internal static (long x0, ulong x1, ulong x2, long x3) decodeDouble2Int(double d)
        {
            long bits = System.BitConverter.DoubleToInt64Bits(d);
            bool negative = (bits & (1L << 63)) != 0;
            uint exponent = (uint)((bits >> 52) & 0x7ffL);
            ulong mantissa = (ulong)bits & 0xfffffffffffffL;
            uint high = (uint)mantissa >> 32;
            uint low = (uint)mantissa;
            return (negative ? -1 : 1, high, low, exponent);

        }

        internal static (long x0, long x1) floatDouble2Int(float f)
        {
            uint bits = System.BitConverter.ToUInt32(System.BitConverter.GetBytes(f), 0);
            uint exponent = (bits >> 23) & 0x7f;
            long mantissa = bits & 0x7fffff;
            return (mantissa, exponent);
        }
    }
}