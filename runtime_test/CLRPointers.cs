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
    public static unsafe extern void* LoadFunctionPointer<T1>(Func<T1, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T1, T2>(Func<T1, T2, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T1, T2, T3>(Func<T1, T2, T3, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T1, T2, T3, T4>(Func<T1, T2, T3, T4, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T1, T2, T3, T4, T5>(Func<T1, T2, T3, T4, T5, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<T1, T2, T3, T4, T5, T6>(Func<T1, T2, T3, T4, T5, T6, Closure> fun);
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
    public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure, Closure, Closure, Closure, Closure> fun);
    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer(Func<Closure, Closure, Closure, Closure, Closure, Closure, Closure> fun);
}