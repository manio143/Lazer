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
        // Those AppN functions are meant to simplify ldftn below
        private static Closure Apply1(Closure func, Closure arg1)
            => Apply(func, arg1);
        private static Closure Apply2(Closure func, Closure arg1, Closure arg2)
            => Apply(func, arg1, arg2);
        private static Closure Apply3(Closure func, Closure arg1, Closure arg2, Closure arg3)
            => Apply(func, arg1, arg2, arg3);
        public static Closure Apply(Closure func, Closure arg1)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun(func as Function, arg1);
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply(func, arg1);
            }
        }
        public static Closure Apply(Closure func, Closure arg1, Closure arg2)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun(func as Function, arg1, arg2);
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply(func, arg1, arg2);
            }
        }

        public static Closure Apply(Closure func, Closure arg1, Closure arg2, Closure arg3)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun(func as Function, arg1, arg2, arg3);
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply(func, arg1, arg2, arg3);
            }
        }

        private static Closure ApplyFun(Function f, Closure arg1)
        {
            switch (f.Arity)
            {
                case 1:
                    return f.Apply(arg1);
                default:
                    return new PAP1(f, arg1).Eval();
            }
        }
        private static Closure ApplyFun(Function f, Closure arg1, Closure arg2)
        {
            switch (f.Arity)
            {
                case 1:
                    var h = f.Apply(arg1);
                    return Apply(h, arg2);
                case 2:
                    return f.Apply(arg1, arg2);
                default:
                    return new PAP2(f, arg1, arg2).Eval();
            }
        }
        private static Closure ApplyFun(Function f, Closure arg1, Closure arg2, Closure arg3)
        {
            switch (f.Arity)
            {
                case 1:
                    {
                        var h = f.Apply(arg1);
                        return Apply(h, arg2, arg3);
                    }
                case 2:
                    {
                        var h = f.Apply(arg1, arg2);
                        return Apply(h, arg3);
                    }
                case 3:
                    return f.Apply(arg1, arg2, arg3);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}