namespace Lazer.Runtime
{
    /**
        This is the crucial part of the runtime that allows us to bounce
        on the trampoline and evaluate closures in a tail recursive fashion.
        Whenever you want to evaluate something for later use and don't
        want to risk a StackOverflow you need to create a continuation
        that will be called with the evaluated closure.
     */
    public static class StgEval
    {
        public static Closure EvalThen(StgContext ctx, Closure c, Continuation cont)
        {
            ctx.Push(cont);
            return c.Eval(ctx); // continue the trampoline from continuation
        }

        /*
            Evaluates a closure in a trampolined environment.
            This must be called when working in a non-lazy context.
         */
        public static Closure Eval(StgContext ctx, Closure next)
        {
            next = next.Eval(ctx);
            if (!ctx.Empty)
            {
                Continuation cont = ctx.Pop();
                next = cont.Call(ctx, next);
                return Eval(ctx, next);
            }
            return next;
        }
    }
}