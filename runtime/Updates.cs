namespace Lazer.Runtime
{
    /**
        An update continuation. It's pushed onto the continuation stack 
        when a thunk is evaluated. After evaluation finishes Update is called and sets the indirection in the reference thunk.
     */
    public sealed class Update : Continuation
    {
        public Thunk t;
        public bool pooled;
        public Update(Thunk t)
        {
            this.t = t;
        }

        /**
            Used by the UpdatePool.
         */
        internal Update()
        {
            pooled = true;
        }

        /**
            Called with an evaluated closure, updates the referenced thunk.
            Returns the closure for further use in computation.
         */
        public override Closure Call(StgContext ctx, Closure c)
        {
            t.ind = c;
            if (pooled)
                ctx.UpdatePool.Return(this);
            return c;
        }
    }

    /**
        A simple object pool designed for Update continuations.
     */
    public sealed class UpdatePool
    {
        private Update[] pool;
        private int index;

        /**
            Max index is used for profiling. Tells us how many update 
            objects have been rented at once.
         */
        public int maxIndex;
        public UpdatePool(int initSize)
        {
            pool = new Update[initSize];
            for (int i = 0; i < initSize; i++)
                pool[i] = new Update();
            index = 0;
        }

        /**
            Gets a free Update from the pool or if there are no free ones
            creates a new object.
            FUTURE: after X attempts to get a continuation from a full 
                    pool, increase the size.
         */
        public Update Get(Thunk t)
        {
            if (index < pool.Length)
            {
                var u = pool[index++];
                maxIndex = index > maxIndex ? index : maxIndex;
                u.t = t;
                return u;
            }
            else return new Update(t);
        }

        /**
            After Update continuation has been used it's returned to the pool.
            We don't really need to check if it last right now, it 
            always is, but if there were multiple threads this can change.
         */
        public void Return(Update u)
        {
            if (pool[index - 1] == u)
            {
                u.t = null; //free thunk to GC
                index--;
            }
            else
                System.Console.Error.WriteLine("WARN, returned update is not the last one");
        }
    }
}