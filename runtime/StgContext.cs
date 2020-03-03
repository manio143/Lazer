using System.Collections.Generic;

namespace Lazer.Runtime
{
    /**
        This is an evaluation context, passed around during every 
        evaluation step.
        The main purpose of this class is to hold a continuation stack
        and allow controlling the trampoline system.
     */
    public sealed class StgContext
    {
        public StgContext()
        {
            Cont = new IdCont();
            // Doing Pop() at the bottom of continuation stack
            // will keep IdCont
            Cont.With(Cont);
        }
        public Continuation Cont;

        /**
            To decrease Update continuation allocation we use a pool.
         */
        public UpdatePool UpdatePool = new UpdatePool(128);

        /**
            Evaluates closure x, which continues with cont,
            which later continues with Cont.
            This is a CPS style trampoline.
         */
        public Closure Eval(Closure x, Continuation cont)
        {
            Cont = cont.With(Cont);
            return x.Eval(this);
        }

        /**
            Evaluates closure x on a new trampoline.
         */
        public Closure Eval(Closure x)
        {
            return Eval(x, new IdCont());
        }

        public void Push(Continuation cont)
        {
            Cont = cont.With(Cont);
        }
        public void Pop()
        {
            Cont = Cont.next;
        }

    }
}