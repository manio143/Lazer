namespace Lazer.Runtime
{
    /**
        Generic closure. Takes a pointer to the static computation function
        and closure parameters.
     */

    public sealed unsafe class SingleEntry : Computation
    {
        private delegate*<Closure> f;

        public SingleEntry(delegate*<Closure> f)
        {
            this.f = f;
        }

        public override Closure Eval() => f();
    }

    public sealed unsafe class SingleEntry<F> : Computation
    {
        public F free;
        private delegate*<ref F, Closure> f;

        public SingleEntry(delegate*<ref F, Closure> f, F free)
        {
            this.f = f;
            this.free = free;
        }

        public override Closure Eval() => f(ref free);
    }
}