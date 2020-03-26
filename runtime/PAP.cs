namespace Lazer.Runtime
{
    /**
        PAP - Partial Application object
     */
    public abstract class PAP : Function
    {
        public Function f;
        protected PAP(Function f) => this.f = f;
        public override Closure Eval() => this;
    }

    public sealed class PAP1 : PAP
    {
        public Closure x0;
        public override int Arity => f.Arity - 1;
        public PAP1(Function f, Closure x0) : base(f)
        {
            this.x0 = x0;
        }
        public override Closure Apply(Closure a0)
            => f.Apply(x0, a0);
        public override Closure Apply(Closure a0, Closure a1)
            => f.Apply(x0, a0, a1);
    }

    public sealed class PAP2 : PAP
    {
        public Closure x0;
        public Closure x1;
        public override int Arity => f.Arity - 1;
        public PAP2(Function f, Closure x0, Closure x1) : base(f)
        {
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Apply(Closure a0)
            => f.Apply(x0, x1, a0);
    }
}