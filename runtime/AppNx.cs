namespace Lazer.Runtime
{
    /**
        Application classes.
        Evaluating `new AppNx(f, arg1, ...)` will call StgApply properly
        apply arguments to f.
        Applications take N arguments and are either:
          u - Updateable
          n - SingleEntry
     */

    public sealed class App1u : Thunk
    {
        public App1u(Closure f, Closure arg1)
        {
            compute = new App1n(f, arg1);
        }
    }

    public sealed class App2u : Thunk
    {
        public App2u(Closure f, Closure arg1, Closure arg2)
        {
            compute = new App2n(f, arg1, arg2);
        }
    }

    public sealed class App3u : Thunk
    {
        public App3u(Closure f, Closure arg1, Closure arg2, Closure arg3)
        {
            compute = new App3n(f, arg1, arg2, arg3);
        }
    }
    public sealed class App1n : Closure
    {
        private Closure f;
        private Closure arg1;
        public App1n(Closure f, Closure arg1)
        {
            this.f = f;
            this.arg1 = arg1;
        }
        public override Closure Eval(StgContext ctx)
        {
            return StgApply.Apply(ctx, f, arg1);
        }
    }
    public sealed class App2n : Closure
    {
        private Closure f;
        private Closure arg1;
        private Closure arg2;
        public App2n(Closure f, Closure arg1, Closure arg2)
        {
            this.f = f;
            this.arg1 = arg1;
            this.arg2 = arg2;
        }
        public override Closure Eval(StgContext ctx)
        {
            return StgApply.Apply(ctx, f, arg1, arg2);
        }
    }
    public sealed class App3n : Closure
    {
        private Closure f;
        private Closure arg1;
        private Closure arg2;
        private Closure arg3;
        public App3n(Closure f, Closure arg1, Closure arg2, Closure arg3)
        {
            this.f = f;
            this.arg1 = arg1;
            this.arg2 = arg2;
            this.arg3 = arg3;
        }
        public override Closure Eval(StgContext ctx)
        {
            return StgApply.Apply(ctx, f, arg1, arg2, arg3);
        }
    }
}
