using System.Runtime.CompilerServices;

namespace Lazer.Runtime
{
    /**
        Generic function. Takes a pointer to the static computation function
        and closure parameters.

        Usage:
        given static method F(Closure) and free variable long x
            new Fun1<long,Closure>(&F, x);
     */

    public unsafe sealed class Fun1<T0,U> : Function
    {
         private delegate*<T0,U> funPtr;
         public Fun1(delegate*<T0,U> funPtr)
         {
              this.Arity = 1;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,R>(A0 a0) {
              var fun = (delegate*<A0,R>)funPtr;
              return fun(a0);
         }
    }
    public unsafe sealed class Fun1<F,T0,U> : Function
    {
         public F free;
         private delegate*<F,T0,U> funPtr;
         public Fun1(delegate*<F,T0,U> funPtr, F free)
         {
              this.Arity = 1;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,R>(A0 a0) {
              var fun = (delegate*<F,A0,R>)funPtr;
              return fun(free,a0);
         }
    }
    public unsafe sealed class Fun2<T0,T1,U> : Function
    {
         private delegate*<T0,T1,U> funPtr;
         public Fun2(delegate*<T0,T1,U> funPtr)
         {
              this.Arity = 2;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,R>(A0 a0, A1 a1) {
              var fun = (delegate*<A0,A1,R>)funPtr;
              return fun(a0,a1);
         }
    }

    public unsafe sealed class Fun2<F,T0,T1,U> : Function
    {
         private delegate*<F,T0,T1,U> funPtr;
         public F free;
         public Fun2(delegate*<F,T0,T1,U> funPtr, F free)
         {
              this.Arity = 2;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,R>(A0 a0, A1 a1) {
              var fun = (delegate*<F,A0,A1,R>)funPtr;
              return fun(free,a0,a1);
         }
    }
    public unsafe sealed class Fun3<T0,T1,T2,U> : Function
    {
         private delegate*<T0,T1,T2,U> funPtr;
         public Fun3(delegate*<T0,T1,T2,U> funPtr)
         {
              this.Arity = 3;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,A2,R>(A0 a0, A1 a1, A2 a2) {
              var fun = (delegate*<A0,A1,A2,R>)funPtr;
              return fun(a0,a1, a2);
         }
    }

    public unsafe sealed class Fun3<F,T0,T1,T2,U> : Function
    {
         private delegate*<F,T0,T1,T2,U> funPtr;
         public F free;
         public Fun3(delegate*<F,T0,T1,T2,U> funPtr, F free)
         {
              this.Arity = 3;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,R>(A0 a0, A1 a1,A2 a2) {
              var fun = (delegate*<F,A0,A1,A2,R>)funPtr;
              return fun(free,a0,a1,a2);
         }
    }
}