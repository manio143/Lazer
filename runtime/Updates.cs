using System.Collections.Generic;

namespace Lazer.Runtime
{
    /**
        An update continuation. It's pushed onto the continuation stack 
        when a thunk is evaluated. After evaluation finishes Update is called
        and sets the indirection in the reference thunk.
     */
    public sealed class Update : Continuation
    {
        public Thunk t;
        public bool notPooled;
        public Update(Thunk t)
        {
            this.t = t;
            this.notPooled = true;
        }

        /**
            Used by the UpdatePool.
         */
        internal Update() { }

        /**
            Called with an evaluated closure, updates the referenced thunk.
            Returns the closure for further use in computation.
         */
        public override Closure Call(StgContext ctx, Closure c)
        {
            t.ind = c;
            if (!notPooled)
                ctx.UpdatePool.Return(this);
            ctx.Pop();
            return c.Eval(ctx);
        }
    }

    /**
        A simple object pool designed for Update continuations.
     */
    public sealed class UpdatePool
    {
        private List<Update> pool;
        private int index;

        /**
            Max index is used for profiling. Tells us how many update 
            objects have been rented at once.
         */
        public int maxIndex;
        public UpdatePool(int initSize)
        {
            pool = new List<Update>(initSize);
            for (int i = 0; i < initSize; i++)
                pool.Add(new Update());
            index = 0;
        }

        /**
            Gets a free Update from the pool or if there are no free ones
            creates a new object and adds it to the pool.
         */
        public Update Get(Thunk t)
        {
            if (index < pool.Count)
            {
                var u = pool[index++];
                maxIndex = index > maxIndex ? index : maxIndex;
                u.t = t;
                return u;
            }
            else
            {
                var u = new Update();
                pool.Add(u);
                index++;
                maxIndex++;
                u.t = t;
                return u;
            }
        }

        /**
            After Update continuation has been used it's returned to the pool.
         */
        public void Return(Update u)
        {
            u.t = null; //free thunk to GC
            index--;
        }
    }
}