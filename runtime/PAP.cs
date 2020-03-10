namespace Lazer.Runtime
{
    /**
        PAP - Partial Application
        The .NET type system is not very friendly when it comes to
        being able to call some function with some parameters.
        If I wanted to do this properly I would need a class for each
        arity, number of supplied arguments combination.
        So for now we have some function f and an array of arguments.
        A PAP is used by StgApply to properly call the function.
     */
    public sealed class PAP : Closure
    {
        public Function f;
        public Closure[] args;
        public int Arity;
        public PAP(Function f, params Closure[] args)
        {
            this.Arity = f.Arity - args.Length;
            this.f = f;
            this.args = args;
        }
        public override Closure Eval(StgContext ctx) => ctx.Cont.Call(ctx, this);
        public override ClosureType Type => ClosureType.PartialApplication;
    }
}