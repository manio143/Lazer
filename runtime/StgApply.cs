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
    public static class StgApply
    {
        public static Closure Apply(StgContext ctx, Closure func, Closure arg1)
        {
            if (func is Thunk)
            {
                return Apply(ctx, func.Eval(ctx), arg1);
            }
            else if (func is Function f)
            {
                switch (f.Arity)
                {
                    case 1:
                        return ((IFunction1)f).Apply(ctx, arg1);
                    default:
                        return new PAP(f, arg1);
                }
            }
            else if (func is PAP pap)
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
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }
        public static Closure Apply(StgContext ctx, Closure func, Closure arg1, Closure arg2)
        {
            if (func is Thunk)
            {
                return Apply(ctx, func.Eval(ctx), arg1, arg2);
            }
            else if (func is Function f)
            {
                switch (f.Arity)
                {
                    case 1:
                        Closure nf = ((IFunction1)f).Apply(ctx, arg1);
                        return Apply(ctx, nf, arg2);
                    case 2:
                        return ((IFunction2)f).Apply(ctx, arg1, arg2);
                    default:
                        return new PAP(f, arg1, arg2);
                }
            }
            else if (func is PAP pap)
            {
                var args = pap.args;
                switch (pap.Arity)
                {
                    case 1:
                        Closure n;
                        switch (pap.f)
                        {
                            case IFunction2 f1_2:
                                n = f1_2.Apply(ctx, args[0], arg1);
                                break;
                            case IFunction3 f1_3:
                                n = f1_3.Apply(ctx, args[0], args[1], arg1);
                                break;
                            default:
                                throw new NotSupportedException();
                        }
                        return Apply(ctx, n, arg2);
                    case 2:
                        switch (pap.f)
                        {
                            case IFunction2 f2_2:
                                throw new NotSupportedException("PAP of IFunction2 with arity 2?");
                            case IFunction3 f2_3:
                                return f2_3.Apply(ctx, args[0], arg1, arg2);
                            default:
                                throw new NotSupportedException();
                        }
                    default:
                        Array.Resize(ref args, args.Length + 1);
                        args[args.Length - 1] = arg1;
                        return new PAP(pap.f, args);
                }
            }
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }
        public static Closure Apply(StgContext ctx, Closure func, Closure arg1, Closure arg2, Closure arg3)
        {
            if (func is Thunk)
            {
                return Apply(ctx, func.Eval(ctx), arg1, arg2, arg3);
            }
            else if (func is Function f)
            {
                switch (f.Arity)
                {
                    case 1:
                        Closure nf = ((IFunction1)f).Apply(ctx, arg1);
                        return Apply(ctx, nf, arg2, arg3);
                    case 2:
                        nf = ((IFunction2)f).Apply(ctx, arg1, arg2);
                        return Apply(ctx, nf, arg3);
                    case 3:
                        return ((IFunction3)f).Apply(ctx, arg1, arg2, arg3);
                    default:
                        System.Console.WriteLine("WARN: creating partial app of fun >3");
                        return new PAP(f, arg1, arg2, arg3); // this should not be hit
                }
            }
            else if (func is PAP)
            {
                System.Console.WriteLine("WARN: applying partial app of fun >3");
                throw new System.NotSupportedException("cannot apply arguments to a PAP that makes >3");
            }
            throw new Exception($"Cannot apply a value ({func.GetType()})");
        }
    }
}