/**
    This file provides a shortcut around the C# compiler
    to allow use of CLR intrinsic opcodes such as
    * ldftn - load function pointer
    * tail. calli - perform an indirect tail call
    In order to be able to use those you need to compile the code with
    a modified Roslyn compiler. See: https://github.com/manio143/roslyn/
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
        public static unsafe extern void* LoadFunctionPointer(Func<StgContext, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<StgContext, Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<StgContext, Closure, Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<StgContext, Closure, Closure, Closure, Closure> fun);
        [CompilerIntrinsic]
        public static unsafe extern void* LoadFunctionPointer(Func<StgContext, Closure, Closure, Closure, Closure, Closure> fun);

        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<U>(void* funPtr);
        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<T0, U>(T0 x0, void* funPtr);
        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<T0, T1, U>(T0 x0, T1 x1, void* funPtr);
        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<T0, T1, T2, U>(T0 x0, T1 x1, T2 x2, void* funPtr);
        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<T0, T1, T2, T3, U>(T0 x0, T1 x1, T2 x2, T3 x3, void* funPtr);
        [CompilerIntrinsic]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static unsafe extern U TailCallIndirectGeneric<T0, T1, T2, T3, T4, U>(T0 x0, T1 x1, T2 x2, T3 x3, T4 x4, void* funPtr);
    }
}