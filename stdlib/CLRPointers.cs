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
    public static unsafe extern void* LoadFunctionPointer<U>(Func<U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, U>(Func<A1, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, U>(Func<A1, A2, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, U>(Func<A1, A2, A3, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, U>(Func<A1, A2, A3, A4, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, U>(Func<A1, A2, A3, A4, A5, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, U>(Func<A1, A2, A3, A4, A5, A6, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, U>(Func<A1, A2, A3, A4, A5, A6, A7, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, A8, U>(Func<A1, A2, A3, A4, A5, A6, A7, A8, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, A8, A9, U>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, U>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, U>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, U> f);

    [CompilerIntrinsic]
    public static unsafe extern void* LoadFunctionPointer<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, U>(Func<A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, A12, U> f);

}