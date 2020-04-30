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
         private delegate*<in F,T0,U> funPtr;
         public Fun1(delegate*<in F,T0,U> funPtr, F free)
         {
              this.Arity = 1;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,R>(A0 a0) {
              var fun = (delegate*<in F,A0,R>)funPtr;
              return fun(in free,a0);
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
         private delegate*<in F,T0,T1,U> funPtr;
         public F free;
         public Fun2(delegate*<in F,T0,T1,U> funPtr, F free)
         {
              this.Arity = 2;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,R>(A0 a0, A1 a1) {
              var fun = (delegate*<in F,A0,A1,R>)funPtr;
              return fun(in free,a0,a1);
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
         private delegate*<in F,T0,T1,T2,U> funPtr;
         public F free;
         public Fun3(delegate*<in F,T0,T1,T2,U> funPtr, F free)
         {
              this.Arity = 3;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,R>(A0 a0, A1 a1,A2 a2) {
              var fun = (delegate*<in F,A0,A1,A2,R>)funPtr;
              return fun(in free,a0,a1,a2);
         }
    }
    public unsafe sealed class Fun4<T0,T1,T2,T3,U> : Function
    {
         private delegate*<T0,T1,T2,T3,U> funPtr;
         public Fun4(delegate*<T0,T1,T2,T3,U> funPtr)
         {
              this.Arity = 4;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,A2,A3,R>(A0 a0, A1 a1, A2 a2, A3 a3) {
              var fun = (delegate*<A0,A1,A2,A3,R>)funPtr;
              return fun(a0,a1, a2, a3);
         }
    }

    public unsafe sealed class Fun4<F,T0,T1,T2,T3,U> : Function
    {
         private delegate*<in F,T0,T1,T2,T3,U> funPtr;
         public F free;
         public Fun4(delegate*<in F,T0,T1,T2,T3,U> funPtr, F free)
         {
              this.Arity = 4;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,A3,R>(A0 a0, A1 a1,A2 a2,A3 a3) {
              var fun = (delegate*<in F,A0,A1,A2,A3,R>)funPtr;
              return fun(in free,a0,a1,a2,a3);
         }
    }
    public unsafe sealed class Fun5<T0,T1,T2,T3,T4,U> : Function
    {
         private delegate*<T0,T1,T2,T3,T4,U> funPtr;
         public Fun5(delegate*<T0,T1,T2,T3,T4,U> funPtr)
         {
              this.Arity = 5;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,A2,A3,A4,R>(A0 a0, A1 a1, A2 a2, A3 a3,A4 a4) {
              var fun = (delegate*<A0,A1,A2,A3,A4,R>)funPtr;
              return fun(a0,a1, a2, a3, a4);
         }
    }

    public unsafe sealed class Fun5<F,T0,T1,T2,T3,T4,U> : Function
    {
         private delegate*<in F,T0,T1,T2,T3,T4,U> funPtr;
         public F free;
         public Fun5(delegate*<in F,T0,T1,T2,T3,T4,U> funPtr, F free)
         {
              this.Arity = 5;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,A3,A4,R>(A0 a0, A1 a1,A2 a2,A3 a3,A4 a4) {
              var fun = (delegate*<in F,A0,A1,A2,A3,A4,R>)funPtr;
              return fun(in free,a0,a1,a2,a3,a4);
         }
    }
    public unsafe sealed class Fun6<T0,T1,T2,T3,T4,T5,U> : Function
    {
         private delegate*<T0,T1,T2,T3,T4,T5,U> funPtr;
         public Fun6(delegate*<T0,T1,T2,T3,T4,T5,U> funPtr)
         {
              this.Arity = 6;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,A2,A3,A4,A5,R>(A0 a0, A1 a1, A2 a2, A3 a3,A4 a4,A5 a5) {
              var fun = (delegate*<A0,A1,A2,A3,A4,A5,R>)funPtr;
              return fun(a0,a1, a2, a3, a4,a5);
         }
    }

    public unsafe sealed class Fun6<F,T0,T1,T2,T3,T4,T5,U> : Function
    {
         private delegate*<in F,T0,T1,T2,T3,T4,T5,U> funPtr;
         public F free;
         public Fun6(delegate*<in F,T0,T1,T2,T3,T4,T5,U> funPtr, F free)
         {
              this.Arity = 6;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,A3,A4,A5,R>(A0 a0, A1 a1,A2 a2,A3 a3,A4 a4,A5 a5) {
              var fun = (delegate*<in F,A0,A1,A2,A3,A4,A5,R>)funPtr;
              return fun(in free,a0,a1,a2,a3,a4,a5);
         }
    }
    public unsafe sealed class Fun7<T0,T1,T2,T3,T4,T5,T6,U> : Function
    {
         private delegate*<T0,T1,T2,T3,T4,T5,T6,U> funPtr;
         public Fun7(delegate*<T0,T1,T2,T3,T4,T5,T6,U> funPtr)
         {
              this.Arity = 7;
              this.funPtr = funPtr;
         }
         public override R Apply<A0,A1,A2,A3,A4,A5,A6,R>(A0 a0, A1 a1, A2 a2, A3 a3,A4 a4,A5 a5,A6 a6) {
              var fun = (delegate*<A0,A1,A2,A3,A4,A5,A6,R>)funPtr;
              return fun(a0,a1, a2, a3, a4,a5,a6);
         }
    }

    public unsafe sealed class Fun7<F,T0,T1,T2,T3,T4,T5,T6,U> : Function
    {
         private delegate*<in F,T0,T1,T2,T3,T4,T5,T6,U> funPtr;
         public F free;
         public Fun7(delegate*<in F,T0,T1,T2,T3,T4,T5,T6,U> funPtr, F free)
         {
              this.Arity = 7;
              this.funPtr = funPtr;
              this.free = free;
         }
         public override R Apply<A0,A1,A2,A3,A4,A5,A6,R>(A0 a0, A1 a1,A2 a2,A3 a3,A4 a4,A5 a5,A6 a6) {
              var fun = (delegate*<in F,A0,A1,A2,A3,A4,A5,A6,R>)funPtr;
              return fun(in free,a0,a1,a2,a3,a4,a5,a6);
         }
    }
}