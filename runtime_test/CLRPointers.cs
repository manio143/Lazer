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
using Lazer.Runtime;

namespace System.Runtime.CompilerServices
{
    [AttributeUsage(AttributeTargets.Method)]
    internal class CompilerIntrinsicAttribute : Attribute { }
}

public static class CLR
{
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T0, U>(Func<T0, U> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T0, T1, U>(Func<T0, T1, U> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T0, T1, T2, U>(Func<T0, T1, T2, U> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T0, T1, T2, T3, U>(Func<T0, T1, T2, T3, U> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T0, T1, T2, T3, T4, U>(Func<T0, T1, T2, T3, T4, U> fun);
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
}