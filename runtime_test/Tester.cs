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
        private Closure MakeList = new App2u(Module.makeList, new I(1), new I(100_000));

        public Closure SumTakeInf()
            => new App1n(Module.sum, InfList);

        public Closure SumMakeList()
            => new App1n(Module.sum, MakeList);

        public Closure SumATakeInf()
            => new App2n(Module.suma, InfList, new I(0));

        public Closure SumAMakeList()
            => new App2n(Module.suma, MakeList, new I(0));

        public Closure Fibt()
            => new App1n(Module.fibt, new I(800_000));

        public Closure FoldMakeList()
            => new App2n(Module.sfoldl, new I(0), MakeList);

        public Closure FoldTakeInf()
            => new App2n(Module.sfoldl, new I(0), InfList);

        public (double, Closure) RunTest(Func<Closure> testCase)
        {
            var sw = Stopwatch.StartNew();
            var res = testCase().Eval(context);
            sw.Stop();
            return (sw.Elapsed.TotalMilliseconds, res);
        }

        public (double, double, double) Run(Func<Closure> testCase, int times)
        {
            var ts = new double[times];
            for (int i = 0; i < times; i++)
                ts[i] = RunTest(testCase).Item1;
            return (ts.Average(), ts.Min(), ts.Max());
        }

        public void ExecTest(string label, Func<Closure> testCase)
        {
            var (_, res) = RunTest(testCase);
            Console.WriteLine("{0}\t\t =>  {1}", label, (res as I).x0);
            var (avg, min, max) = Run(testCase, 100);
            Console.WriteLine("{0}\tAVG: {1:0.0000}, MIN: {2:0.0000}, MAX: {3:0.0000}", label, avg, min, max);
        }

        public void ExecTests()
        {
            ExecTest("Sum(Take(100000,Inf))", SumTakeInf);
            ExecTest("Sum(MakeList(1,100000))", SumMakeList);
            ExecTest("SumA(Take(100000,Inf))", SumATakeInf);
            ExecTest("SumA(MakeList(1,100000))", SumAMakeList);
            ExecTest("Fibt(800000)", Fibt);
            ExecTest("Fold(+,0, Take(100000,Inf))", FoldTakeInf);
            ExecTest("Fold(+,0, MakeList(1,100000))", FoldMakeList);
        }
    }
}