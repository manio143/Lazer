namespace Lazer.Runtime
{
    /**
        Those interfaces are used on classes deriving Function of 
        a certain arity and allow us to apply arguments to partial
        application objects (PAPs).
     */

    public interface IFunction1
    {
        Closure Apply(StgContext ctx, Closure arg1);
    }
    public interface IFunction2
    {
        Closure Apply(StgContext ctx, Closure arg1, Closure arg2);
    }
    public interface IFunction3
    {
        Closure Apply(StgContext ctx, Closure arg1, Closure arg2, Closure arg3);
    }
}