using System;

namespace Lazer.Runtime
{
    /**
        This is a set of helper methods for applying unknown functions.
        The `func` may be either a Function, a Thunk or a PAP
        (partially applied function).
        Currently I only support functions up to three arguments.
        In my tests so far I didn't have many PAPs.
     */
    public static unsafe class StgApply
    {
        private static Closure Apply1(StgContext ctx, Closure func, Closure arg1)
            => Apply(ctx, func, arg1);
        private static Closure Apply2(StgContext ctx, Closure func, Closure arg1, Closure arg2)
            => Apply(ctx, func, arg1, arg2);
        private static Closure Apply3(StgContext ctx, Closure func, Closure arg1, Closure arg2, Closure arg3)
            => Apply(ctx, func, arg1, arg2, arg3);
        public static Closure Apply(StgContext ctx, Closure func, Closure arg1)
        {
            if (func is Function f)
            {
                return ApplyFun(ctx, f, arg1);
            }
            else if (func is Thunk)
            {
                var cont = CLR.LoadFunctionPointer(Apply1);
                return StgEval.EvalThen(ctx, func, new Cont1<Closure>(cont, arg1));
            }
            else if (func is PAP pap)
            {
                return ApplyPAP(ctx, pap, arg1);
            }
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }
        public static Closure Apply(StgContext ctx, Closure func, Closure arg1, Closure arg2)
        {
            if (func is Function f)
            {
                return ApplyFun(ctx, f, arg1, arg2);
            }
            else if (func is Thunk)
            {
                var cont = CLR.LoadFunctionPointer(Apply2);
                return StgEval.EvalThen(ctx, func, new Cont2<Closure, Closure>(cont, arg1, arg2));
            }
            else if (func is PAP pap)
            {
                return ApplyPAP(ctx, pap, arg1, arg2);
            }
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }

        public static Closure Apply(StgContext ctx, Closure func, Closure arg1, Closure arg2, Closure arg3)
        {
            if (func is Function f)
            {
                return ApplyFun(ctx, f, arg1, arg2, arg3);
            }
            else if (func is Thunk)
            {
                var cont = CLR.LoadFunctionPointer(Apply3);
                return StgEval.EvalThen(ctx, func, new Cont3<Closure, Closure, Closure>(cont, arg1, arg2, arg3));
            }
            else if (func is PAP)
            {
                System.Console.WriteLine("WARN: applying partial app of fun >3");
                throw new System.NotSupportedException("cannot apply arguments to a PAP that makes >3");
            }
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }

        private static Closure ApplyFun(StgContext ctx, Function f, Closure arg1)
        {
            switch (f.Arity)
            {
                case 1:
                    return ((IFunction1)f).Apply(ctx, arg1);
                default:
                    return new PAP(f, arg1);
            }
        }
        private static Closure ApplyFun(StgContext ctx, Function f, Closure arg1, Closure arg2)
        {
            switch (f.Arity)
            {
                case 1:
                    var cont = CLR.LoadFunctionPointer(Apply1);
                    ctx.Push(new Cont1<Closure>(cont, arg2));
                    return ((IFunction1)f).Apply(ctx, arg1);
                case 2:
                    return ((IFunction2)f).Apply(ctx, arg1, arg2);
                default:
                    return new PAP(f, arg1, arg2);
            }
        }
        private static Closure ApplyFun(StgContext ctx, Function f, Closure arg1, Closure arg2, Closure arg3)
        {
            switch (f.Arity)
            {
                case 1:
                    {
                        var cont = CLR.LoadFunctionPointer(Apply2);
                        ctx.Push(new Cont2<Closure, Closure>(cont, arg2, arg3));
                        return ((IFunction1)f).Apply(ctx, arg1);
                    }
                case 2:
                    {
                        var cont = CLR.LoadFunctionPointer(Apply1);
                        ctx.Push(new Cont1<Closure>(cont, arg3));
                        return ((IFunction2)f).Apply(ctx, arg1, arg2);
                    }
                case 3:
                    return ((IFunction3)f).Apply(ctx, arg1, arg2, arg3);
                default:
                    System.Console.WriteLine("WARN: creating partial app of fun >3");
                    return new PAP(f, arg1, arg2, arg3);
            }
        }

        private static Closure ApplyPAP(StgContext ctx, PAP pap, Closure arg1)
        {
            var args = pap.args;
            switch (pap.Arity)
            {
                case 1:
                    switch (pap.f)
                    {
                        case IFunction2 f2:
                            return f2.Apply(ctx, args[0], arg1);
                        case IFunction3 f3:
                            return f3.Apply(ctx, args[0], args[1], arg1);
                        default:
                            throw new NotSupportedException();
                    }
                default:
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = arg1;
                    return new PAP(pap.f, args);
            }
        }
        private static Closure ApplyPAP(StgContext ctx, PAP pap, Closure arg1, Closure arg2)
        {
            var args = pap.args;
            switch (pap.Arity)
            {
                case 1:
                    var cont = CLR.LoadFunctionPointer(Apply1);
                    ctx.Push(new Cont1<Closure>(cont, arg2));
                    switch (pap.f)
                    {
                        case IFunction2 f1_2:
                            return f1_2.Apply(ctx, args[0], arg1);
                        case IFunction3 f1_3:
                            return f1_3.Apply(ctx, args[0], args[1], arg1);
                        default:
                            throw new System.NotSupportedException();
                    }
                case 2:
                    switch (pap.f)
                    {
                        case IFunction3 f2_3:
                            return f2_3.Apply(ctx, args[0], arg1, arg2);
                        case IFunction2 f2_2:
                            throw new System.NotSupportedException("PAP of IFunction2 with arity 2?");
                        default:
                            throw new System.NotSupportedException();
                    }
                default:
                    Array.Resize(ref args, args.Length + 1);
                    args[args.Length - 1] = arg1;
                    return new PAP(pap.f, args);
            }
        }
    }
}