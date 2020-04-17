/**
    This file provides a shortcut around the C# compiler
    to allow use of CLR intrinsic opcodes such as
    * ldftn - load function pointer
    * tail. calli - perform an indirect tail call
    * calli - perform an indirect call
    In order to be able to use those you need to compile the code with
    a modified Roslyn compiler. See: https://github.com/manio143/roslyn/

    Hopefully in the future C# will be have function pointers.
    See: https://github.com/dotnet/csharplang/issues/302
 */
using System;
using System.Runtime.CompilerServices;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class CompilerIntrinsicAttribute : Attribute { }
}

namespace Lazer.Runtime
{
    public static class CLR
    {
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure, Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure, Closure, Closure, Closure> fun);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<U>(void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, U>(A1 a1, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, U>(A1 a1, A2 a2, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, U>(A1 a1, A2 a2, A3 a3, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, U>(A1 a1, A2 a2, A3 a3, A4 a4, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, void* funPtr);

        [CompilerIntrinsic]
        public static unsafe extern U TailCallIndirectGeneric<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, A13, A14, U>(A1 a1, A2 a2, A3 a3, A4 a4, A5 a5, A6 a6, A7 a7, A8 a8, A9 a9, A10 a10, A11 a11, A12 a12, A13 a13, A14 a14, void* funPtr);
    }
}