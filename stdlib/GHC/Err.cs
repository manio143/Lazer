using System;
using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Err
    {
        public static Function error = new Fun1<Closure,Closure>(&error_Entry);
        public static Closure error_Entry(Closure s)
        {
            string errorMessage = CString.packCStringHash(s);
            throw new System.Exception(errorMessage);
        }
        public static R undefined_Entry<R>(Closure callstack)
        {
            throw new System.Exception("Prelude.undefined");
        }

        public static R errorWithoutStackTrace_Entry<R>(Closure s)
        {
            string errorMessage = CString.packCStringHash(s);
            throw new System.Exception(errorMessage);
        }
    }
}