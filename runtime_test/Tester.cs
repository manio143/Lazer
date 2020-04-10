using System;
using System.Linq;
using System.Diagnostics;
using Lazer.Runtime;

namespace Lazer.Runtime.Test
{
    public unsafe class Tester
    {
        private Closure InfList = Module.take.Apply<Closure,Closure,Closure>(new I(100_000), Module.inf);
        private Closure InfList2 = Module.takeOnStack.Apply<Closure,Closure,Closure>(new I(100_000), Module.inf);
        private Closure MakeList = Module.makeList.Apply<Closure,Closure,Closure>(new I(1), new I(100_000));

        public Closure SumTakeInf()
            => Module.sum.Apply<Closure,Closure>(InfList);
        public Closure Sum2TakeInf()
                    => Module.sum2.Apply<Closure,Closure>(InfList);
        public Closure SumTakeInf2()
            => Module.sum.Apply<Closure,Closure>(InfList2);

        public Closure SumMakeList()
            => Module.sum.Apply<Closure,Closure>(MakeList);

        public Closure Sum2MakeList()
            => Module.sum2.Apply<Closure,Closure>(MakeList);
        public Closure SumATakeInf()
            => Module.suma.Apply<Closure,Closure,Closure>(InfList, new I(0));

        public Closure SumATakeInf2()
            => Module.suma.Apply<Closure,Closure,Closure>(InfList2, new I(0));

        public Closure SumAMakeList()
            => Module.suma.Apply<Closure,Closure,Closure>(MakeList, new I(0));

        public Closure Fibt()
            => Module.fibt.Apply<Closure,Closure>(new I(800_000));

        public Closure FoldMakeList()
            => Module.sfoldl.Apply<Closure,Closure,Closure>(new I(0), MakeList);

        public Closure FoldTakeInf()
            => Module.sfoldl.Apply<Closure,Closure,Closure>(new I(0), InfList);

        public Closure PiSum()
            => Module.suma.Apply<Closure,Closure,Closure>(Module.map.Apply<Closure,Closure,Closure>(Module.integerToInt, Module.take.Apply<Closure,Closure,Closure>(new I(4000), Module.pi_)), new I(0));

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
            => Module.sumFromTo.Apply<Closure,Closure,Closure>(new I(0), new I(100_000));

        public Closure SumOs(Data[] arr, Function extract) {
            var os = Code.loopArray(arr, 0);
            var @is = Module.map.Apply<Closure, Closure, Closure>(extract, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new I(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new I(0));
        }
        public Closure SumOs2TypeL()
            => SumOs(new Data[] { new O0(1), new O1(1) }, Module.extractOtypeL);
        public Closure SumOs2Type()
            => SumOs(new Data[] { new O0(1), new O1(1) }, Module.extractOtype);
        public Closure SumOs3Type()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1) }, Module.extractOtype);
        public Closure SumOs4Type()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1), new O3(1) }, Module.extractOtype);
        public Closure SumOs5Type()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1), new O3(1), new O4(1) }, Module.extractOtype);
        public Closure SumOs2Tag()
            => SumOs(new Data[] { new O0(1), new O1(1) }, Module.extractOtag);
        public Closure SumOs2TagL()
            => SumOs(new Data[] { new O0(1), new O1(1) }, Module.extractOtagL);
        public Closure SumOs3Tag()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1) }, Module.extractOtag);
        public Closure SumOs4Tag()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1), new O3(1) }, Module.extractOtag);
        public Closure SumOs5Tag()
            => SumOs(new Data[] { new O0(1), new O1(1), new O2(1), new O3(1), new O4(1) }, Module.extractOtag);

        public Closure SumOsRandomType() {
            var os = Code.RandomO();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new I(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new I(0));
        }
        public Closure SumOsRandomTag() {
            var os = Code.RandomO();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new I(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new I(0));
        }
        public Closure SumOsRandomTypeL() {
            var os = Code.RandomOL();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new I(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new I(0));
        }
        public Closure SumOsRandomTagL() {
            var os = Code.RandomOL();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new I(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new I(0));
        }
        public Closure SumOsConst0Type()
            => SumOs(new Data[] { new O0(1) }, Module.extractOtype);
        public Closure SumOsConst4Type()
            => SumOs(new Data[] { new O3(1) }, Module.extractOtype);
        public Closure SumOsConst5Type()
            => SumOs(new Data[] { new O4(1) }, Module.extractOtype);
        public Closure SumOsConst9Type()
            => SumOs(new Data[] { new OFucked(1) }, Module.extractOtype);
        public Closure SumOsConst0Tag()
            => SumOs(new Data[] { new O0(1) }, Module.extractOtag);
        public Closure SumOsConst4Tag()
            => SumOs(new Data[] { new O3(1) }, Module.extractOtag);
        public Closure SumOsConst5Tag()
            => SumOs(new Data[] { new O4(1) }, Module.extractOtag);
        public Closure SumOsConst9Tag()
            => SumOs(new Data[] { new OFucked(1) }, Module.extractOtag);
        public (double, Closure) RunTest(Func<Closure> testCase)
        {
            var sw = Stopwatch.StartNew();
            var res = testCase().Eval();
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
                Console.WriteLine(Module.take.Apply<Closure,Closure,Closure>(new I(15), Module.pi_));
            
            // ExecTest("SumA(Take(500000,Map(extractOType, O1-2)), 0)", SumOs2Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O1-2)), 0)", SumOs2Tag);
            // ExecTest("SumA(Take(500000,Map(extractOTypeL, O1-2)), 0)", SumOs2TypeL);
            // ExecTest("SumA(Take(500000,Map(extractOTagL, O1-2)), 0)", SumOs2TagL);
            // ExecTest("SumA(Take(500000,Map(extractOType, O1-3)), 0)", SumOs3Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O1-3)), 0)", SumOs3Tag);
            // ExecTest("SumA(Take(500000,Map(extractOType, O1-4)), 0)", SumOs4Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O1-4)), 0)", SumOs4Tag);
            // ExecTest("SumA(Take(500000,Map(extractOType, O1-5)), 0)", SumOs5Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O1-5)), 0)", SumOs5Tag);

            // ExecTest("SumA(Take(500000,Map(extractOType, random)), 0)", SumOsRandomType);
            // ExecTest("SumA(Take(500000,Map(extractOTag, random)), 0)", SumOsRandomTag);
            // ExecTest("SumA(Take(500000,Map(extractOTypeL, random)), 0)", SumOsRandomTypeL);
            // ExecTest("SumA(Take(500000,Map(extractOTagL, random)), 0)", SumOsRandomTagL);       

            // ExecTest("SumA(Take(500000,Map(extractOType, O1)), 0)", SumOsConst0Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O1)), 0)", SumOsConst0Tag);
            // ExecTest("SumA(Take(500000,Map(extractOType, O4)), 0)", SumOsConst4Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O4)), 0)", SumOsConst4Tag);
            // ExecTest("SumA(Take(500000,Map(extractOType, O5)), 0)", SumOsConst5Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O5)), 0)", SumOsConst5Tag);
            // ExecTest("SumA(Take(500000,Map(extractOType, O9)), 0)", SumOsConst9Type);
            // ExecTest("SumA(Take(500000,Map(extractOTag, O9)), 0)", SumOsConst9Tag);
        }
    }
}