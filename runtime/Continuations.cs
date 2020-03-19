using System.Collections.Generic;

namespace Lazer.Runtime
{
    /**
        Identity continuation - placed at the bottom of the continuation stack.
        Returns the result of the computation to the caller.
     */

    internal class IdCont : Continuation
    {
        bool nonPooled;
        public IdCont(bool nonPooled) => this.nonPooled = nonPooled;
        public IdCont() { }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            if (!nonPooled)
                ctx.IdContPool.Return(this);
            return c;
        }
    }

    /**
        Generic continuation. Takes a pointer to the static computation function
        and closure parameters.
     */

    public static unsafe class StgCont
    {
        public static Continuation Make(void* f) => new Cont0(f);
        public static Continuation Make<T0>(void* f, T0 x0) => new Cont1<T0>(f, x0);
        public static Continuation Make<T0, T1>(void* f, T0 x0, T1 x1) => new Cont2<T0, T1>(f, x0, x1);
        public static Continuation Make<T0, T1, T2>(void* f, T0 x0, T1 x1, T2 x2) => new Cont3<T0, T1, T2>(f, x0, x1, x2);
        public static Continuation Make<T0, T1, T2, T3>(void* f, T0 x0, T1 x1, T2 x2, T3 x3) => new Cont4<T0, T1, T2, T3>(f, x0, x1, x2, x3);
        public static Continuation Make<T0, T1, T2, T3, T4>(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4) => new Cont5<T0, T1, T2, T3, T4>(f, x0, x1, x2, x3, x4);
    }

    public unsafe class Cont0 : Continuation
    {
        protected internal void* f;
        public Cont0(void* f)
        {
            this.f = f;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, Closure>(ctx, c, f);
        }
    }
    public unsafe class Cont1<T0> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public Cont1(void* f, T0 x0)
        {
            this.f = f;
            this.x0 = x0;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, Closure>(ctx, c, x0, f);
        }
    }
    public unsafe class Cont2<T0, T1> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public Cont2(void* f, T0 x0, T1 x1)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, Closure>(ctx, c, x0, x1, f);
        }
    }
    public unsafe class Cont3<T0, T1, T2> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public Cont3(void* f, T0 x0, T1 x1, T2 x2)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, T2, Closure>(ctx, c, x0, x1, x2, f);
        }
    }
    public unsafe class Cont4<T0, T1, T2, T3> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public Cont4(void* f, T0 x0, T1 x1, T2 x2, T3 x3)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, T2, T3, Closure>(ctx, c, x0, x1, x2, x3, f);
        }
    }
    public unsafe class Cont5<T0, T1, T2, T3, T4> : Continuation
    {
        protected internal void* f;
        public T0 x0;
        public T1 x1;
        public T2 x2;
        public T3 x3;
        public T4 x4;
        public Cont5(void* f, T0 x0, T1 x1, T2 x2, T3 x3, T4 x4)
        {
            this.f = f;
            this.x0 = x0;
            this.x1 = x1;
            this.x2 = x2;
            this.x3 = x3;
            this.x4 = x4;
        }
        public override Closure Call(StgContext ctx, Closure c)
        {
            ctx.Pop();
            return CLR.TailCallIndirectGeneric<StgContext, Closure, T0, T1, T2, T3, T4, Closure>(ctx, c, x0, x1, x2, x3, x4, f);
        }
    }

    internal sealed class IdContPool
    {
        private List<IdCont> pool;
        private int index;
        public IdContPool(int initSize)
        {
            pool = new List<IdCont>(initSize);
            for (int i = 0; i < initSize; i++)
                pool.Add(new IdCont());
            index = 0;
        }
        public IdCont Get()
        {
            if (index < pool.Count)
            {
                var u = pool[index++];
                return u;
            }
            else
            {
                var u = new IdCont();
                pool.Add(u);
                index++;
                return u;
            }
        }
        public void Return(IdCont u)
        {
            u.next = null;
            index--;
        }
    }
}