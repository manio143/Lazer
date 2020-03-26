using System;
using System.Linq;
using System.Diagnostics;
using Lazer.Runtime;

namespace Lazer.Runtime.Test
{
    public class Tester
    {
        private StgContext context = new StgContext();

        private Closure InfList = new App2u(Module.take, new I(100_000), Module.inf);
        private Closure InfList2 = new App2u(Module.takeOnStack, new I(100_000), Module.inf);
        private Closure MakeList = new App2u(Module.makeList, new I(1), new I(100_000));

        public Closure SumTakeInf()
            => new App1n(Module.sum, InfList);
        public Closure Sum2TakeInf()
                    => new App1n(Module.sum2, InfList);
        public Closure SumTakeInf2()
            => new App1n(Module.sum, InfList2);

        public Closure SumMakeList()
            => new App1n(Module.sum, MakeList);

        public Closure Sum2MakeList()
            => new App1n(Module.sum2, MakeList);
        public Closure SumATakeInf()
            => new App2n(Module.suma, InfList, new I(0));

        public Closure SumATakeInf2()
            => new App2n(Module.suma, InfList2, new I(0));

        public Closure SumAMakeList()
            => new App2n(Module.suma, MakeList, new I(0));

        public Closure Fibt()
            => new App1n(Module.fibt, new I(800_000));

        public Closure FoldMakeList()
            => new App2n(Module.sfoldl, new I(0), MakeList);

        public Closure FoldTakeInf()
            => new App2n(Module.sfoldl, new I(0), InfList);

        public Closure PiSum()
            => new App2n(Module.suma, new App2n(Module.map, Module.integerToInt, new App2n(Module.take, new I(4000), Module.pi_)), new I(0));

        public Closure LinqSumRange()
            => new I(Enumerable.Range(0, 100_000).Aggregate(0, (a, i) => unchecked(a + i)));

        public Closure LoopSum()
        {
            int sum = 0;
            for (int i = 0; i <= 100_000; i++)
                sum += i;
            return new I(sum);
        }

        public Closure SumFromTo()
            => new App2n(Module.sumFromTo, new I(0), new I(100_000));

        public (double, Closure) RunTest(Func<Closure> testCase)
        {
            var sw = Stopwatch.StartNew();
            var res = testCase().Eval(context);
            sw.Stop();
            return (sw.Elapsed.TotalMilliseconds, res);
        }

        public (double, double, double, double) Run(Func<Closure> testCase, int times)
        {
            var ts = new double[times];
            for (int i = 0; i < times; i++)
                ts[i] = RunTest(testCase).Item1;
            double avg, min = double.MaxValue, max = 0, sd = 0, sum = 0;
            for (int i = 0; i < times; i++)
            {
                var t = ts[i];
                sum += t;
                min = t < min ? t : min;
                max = t > max ? t : max;
            }
            avg = sum / times;
            for (int i = 0; i < times; i++)
            {
                var t = ts[i];
                var el = t - avg;
                sd += el * el;
            }
            sd /= times;
            sd = Math.Sqrt(sd);
            return (avg, min, max, sd);
        }

        public void ExecTest(string label, Func<Closure> testCase)
        {
            var (_, res) = RunTest(testCase);
            Console.WriteLine("{0}\t\t =>  {1}", label, res);
            var (avg, min, max, sd) = Run(testCase, 25);
            Console.WriteLine("{0}\tAVG: {1:0.0000}, SD: {4:0.00} MIN: {2:0.0000}, MAX: {3:0.0000}", label, avg, min, max, sd);
        }

        public void ExecTests()
        {
            // GC.TryStartNoGCRegion(200_000_000, 10_000_000);
            ExecTest("Sum(Take(100000,Inf))", SumTakeInf);
            // GC.EndNoGCRegion();
            // GC.TryStartNoGCRegion(200_000_000, 10_000_000);
            ExecTest("Sum(MakeList(1,100000))", SumMakeList);
            // GC.EndNoGCRegion();
            ExecTest("Sum2(Take(100000,Inf))", Sum2TakeInf);
            ExecTest("Sum2(MakeList(1,100000))", Sum2MakeList);
            ExecTest("Sum(Take2(100000,Inf))", SumTakeInf2);
            ExecTest("SumFromTo", SumFromTo);
            ExecTest("~LinqSumRange", LinqSumRange);
            ExecTest("~LoopSum", LoopSum);
            ExecTest("SumA(Take(100000,Inf))", SumATakeInf);
            ExecTest("SumA(MakeList(1,100000))", SumAMakeList);
            ExecTest("SumA(Take2(100000,Inf))", SumATakeInf2);
            ExecTest("Fibt(800000)", Fibt);
            ExecTest("Fold(+,0, Take(100000,Inf))", FoldTakeInf);
            ExecTest("Fold(+,0, MakeList(1,100000))", FoldMakeList);
            ExecTest("SumA(Take(4000,Pi), 0)", PiSum);
            Console.WriteLine(new App2n(Module.take, new I(15), Module.pi_).Eval(context));
        }
    }
}