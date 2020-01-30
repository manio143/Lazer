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
        private Stack<Continuation> stack = new Stack<Continuation>();
        public void Push(Continuation c) => stack.Push(c);
        public Continuation Pop() => stack.Pop();
        public bool Empty => stack.Count == 0;

        /**
            If true then we're evaluating with a non-empty continuation stack. See StgEval class.
         */
        public bool trampoline;

        /**
            To decrease Update continuation allocation we use a pool.
         */
        public UpdatePool UpdatePool = new UpdatePool(20);
    }
}