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
        public static R Apply<A0, R>(Closure func, A0 a0)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun<A0, R>(func as Function, a0);
                case ClosureType.PartialApplication:
                    return (func as PAP).Apply<A0, R>(a0);
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply<A0, R>(func, a0);
            }
        }
        public static R Apply<A0, A1, R>(Closure func, A0 a0, A1 a1)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun<A0, A1, R>(func as Function, a0, a1);
                case ClosureType.PartialApplication:
                    return (func as PAP).Apply<A0, A1, R>(a0, a1);
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply<A0, A1, R>(func, a0, a1);
            }
        }

        public static R Apply<A0, A1, A2, R>(Closure func, A0 a0, A1 a1, A2 a2)
        {
            switch (func.Type)
            {
                case ClosureType.Function:
                    return ApplyFun<A0, A1, A2, R>(func as Function, a0, a1, a2);
                case ClosureType.PartialApplication:
                    throw new NotSupportedException("Cannot apply more than 3 parameters to a function");
                case ClosureType.Data:
                    throw new Exception($"Cannot apply a value ({func.GetType()})");
                default:
                    func = func.Eval();
                    return Apply<A0, A1, A2, R>(func, a0, a1, a2);
            }
        }

        private static R ApplyFun<A0, R>(Function f, A0 a0)
        {
            switch (f.Arity)
            {
                case 1:
                    return f.Apply<A0, R>(a0);
                default:
                    return (R)(object)new PAP<A0>(f, a0);
            }
        }
        private static R ApplyFun<A0, A1, R>(Function f, A0 a0, A1 a1)
        {
            switch (f.Arity)
            {
                case 1:
                    var h = f.Apply<A0, Closure>(a0);
                    return Apply<A1, R>(h, a1);
                case 2:
                    return f.Apply<A0, A1, R>(a0, a1);
                default:
                    return (R)(object)new PAP<A0, A1>(f, a0, a1);
            }
        }
        private static R ApplyFun<A0, A1, A2, R>(Function f, A0 a0, A1 a1, A2 a2)
        {
            switch (f.Arity)
            {
                case 1:
                    {
                        var h = f.Apply<A0, Closure>(a0);
                        return Apply<A1, A2, R>(h, a1, a2);
                    }
                case 2:
                    {
                        var h = f.Apply<A0, A1, Closure>(a0, a1);
                        return Apply<A2, R>(h, a2);
                    }
                case 3:
                    return f.Apply<A0, A1, A2, R>(a0, a1, a2);
                default:
                    throw new NotSupportedException();
            }
        }
    }
}