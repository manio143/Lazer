using System;
using System.Linq;
using System.Diagnostics;
using Lazer.Runtime;

namespace Lazer.Runtime.Test
{
    public unsafe class Tester
    {
        private Closure InfList = Module.take.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(100_000), Module.inf);
        private Closure InfList2 = Module.takeOnStack.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(100_000), Module.inf);
        private Closure MakeList = Module.makeList.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(1), new GHC.Types.IHash(100_000));

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
            => Module.suma.Apply<Closure,Closure,Closure>(InfList, new GHC.Types.IHash(0));

        public Closure SumATakeInf2()
            => Module.suma.Apply<Closure,Closure,Closure>(InfList2, new GHC.Types.IHash(0));

        public Closure SumAMakeList()
            => Module.suma.Apply<Closure,Closure,Closure>(MakeList, new GHC.Types.IHash(0));

        public Closure Fibt()
            => Module.fibt.Apply<Closure,Closure>(new GHC.Types.IHash(800_000));

        public Closure FoldMakeList()
            => Module.sfoldl.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(0), MakeList);

        public Closure FoldTakeInf()
            => Module.sfoldl.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(0), InfList);

        public Closure PiSum()
            => Module.suma.Apply<Closure,Closure,Closure>(Module.map.Apply<Closure,Closure,Closure>(Module.integerToInt, Module.take.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(6000), Module.pi_)), new GHC.Types.IHash(0));

        public Closure AppProcess()
            => Code.appProcessTest();
        public Closure AppProcessI()
            => Code.appProcessTestI();

        public Closure LinqSumRange()
            => new GHC.Types.IHash(Enumerable.Range(0, 100_000).Aggregate(0, (a, i) => unchecked(a + i)));

        public Closure LoopSum()
        {
            int sum = 0;
            for (int i = 0; i <= 100_000; i++)
                sum += i;
            return new GHC.Types.IHash(sum);
        }

        public Closure SumFromTo()
            => Module.sumFromTo.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(0), new GHC.Types.IHash(100_000));

        public Closure SumOs(Data[] arr, Function extract) {
            var os = Code.loopArray(arr, 0);
            var @is = Module.map.Apply<Closure, Closure, Closure>(extract, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new GHC.Types.IHash(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new GHC.Types.IHash(0));
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
            var tk = Module.take.Apply<Closure, Closure, Closure>(new GHC.Types.IHash(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new GHC.Types.IHash(0));
        }
        public Closure SumOsRandomTag() {
            var os = Code.RandomO();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new GHC.Types.IHash(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new GHC.Types.IHash(0));
        }
        public Closure SumOsRandomTypeL() {
            var os = Code.RandomOL();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new GHC.Types.IHash(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new GHC.Types.IHash(0));
        }
        public Closure SumOsRandomTagL() {
            var os = Code.RandomOL();
            var @is = Module.map.Apply<Closure, Closure, Closure>(Module.extractOtype, os);
            var tk = Module.take.Apply<Closure, Closure, Closure>(new GHC.Types.IHash(500_000), @is);
            return Module.suma.Apply<Closure, Closure, Closure>(tk, new GHC.Types.IHash(0));
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

        public Closure NoFib_Exp()
            => new GHC.Types.IHash(Exp3.TestEntry(8));
        public Closure NoFib_DigitsE1()
            => DigitsE1.TestEntry();
        public Closure NoFib_Primes()
            => Primes.TestEntry();
        public Closure NoFib_Primes2()
            => Primes2.TestEntry();
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
            {
                ts[i] = RunTest(testCase).Item1;
            }
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
            var (avg, min, max, sd) = Run(testCase, 100);
            Console.WriteLine("{0}\tAVG: {1:0.0000}, SD: {4:0.00} MIN: {2:0.0000}, MAX: {3:0.0000}", label, avg, min, max, sd);
        }

        public void ExecTests()
        {
            /*
            ExecTest("Sum2(Take(100000,Inf))", Sum2TakeInf);
            ExecTest("Sum2(MakeList(1,100000))", Sum2MakeList);
            ExecTest("Sum(Take2(100000,Inf))", SumTakeInf2);
            Console.WriteLine("----");
            ExecTest("Sum(Take(100000,Inf))", SumTakeInf);
            // GC.TryStartNoGCRegion(200_000_000, 10_000_000);
            ExecTest("Sum(MakeList(1,100000))", SumMakeList);
            // GC.EndNoGCRegion();
            ExecTest("SumA(MakeList(1,100000))", SumAMakeList);
            ExecTest("SumA(Take(100000,Inf))", SumATakeInf);
            ExecTest("Fold(+,0, Take(100000,Inf))", FoldTakeInf);
            ExecTest("Fold(+,0, MakeList(1,100000))", FoldMakeList);
            ExecTest("SumFromTo", SumFromTo);
            ExecTest("~LinqSumRange", LinqSumRange);
            ExecTest("~LoopSum", LoopSum);
            // ExecTest("SumA(Take2(100000,Inf))", SumATakeInf2);
            ExecTest("Fibt(800000)", Fibt);
            ExecTest("SumA(Take(6000,Pi), 0)", PiSum);
            
            ExecTest("appProcess (take 100000 (repeat 1))", AppProcess);
            ExecTest("appProcessI (take 100000 (repeat 1))", AppProcessI);
            ExecTest("appAppTest", Code.appAppTest);
            ExecTest("appCallTest", Code.appCallTest); 
            ExecTest("loopAppTest", Code.loopAppTest);
            ExecTest("loopCallTest", Code.loopCallTest);*/
            // Console.WriteLine(Module.take.Apply<Closure,Closure,Closure>(new GHC.Types.IHash(15), Module.pi_));

            ExecTest("loop CALL call long INL", () => ApplyCall.loopCallLongInline(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop CALL call long NO ", () => ApplyCall.loopCallLongNoInline(0, ApplyCall.EXEC_TIMES));
            //ExecTest("loop CALL call lonW INL", () => ApplyCall.loopCallWLongInline(ApplyCall.zero, ApplyCall.EXEC_TIMES));
            //ExecTest("loop CALL call lonW NO ", () => ApplyCall.loopCallWLongNoInline(ApplyCall.zero, ApplyCall.EXEC_TIMES));
            //ExecTest("loop CALL call cloN INL", () => ApplyCall.loopCallNClosureInline(0, ApplyCall.EXEC_TIMES));
            //ExecTest("loop CALL call cloN NO ", () => ApplyCall.loopCallNClosureNoInline(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt long STI", () => ApplyCall.loopAppLongNonGenericInd(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt long STD", () => ApplyCall.loopAppLongNonGenericDir(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt long GEN", () => ApplyCall.loopAppLongGeneric(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt long GCL", () => ApplyCall.loopAppLongGenericClosure(0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt long    ", () => ApplyCall.loopAppLong(ApplyCall.add1L, 0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt clos    ", () => ApplyCall.loopAppClosure(ApplyCall.add1C, 0, ApplyCall.EXEC_TIMES));
            ExecTest("loop APP  virt clos CA ", () => ApplyCall.loopAppClosureWithCache(ApplyCall.add1C, 0, ApplyCall.EXEC_TIMES));


            //ExecTest("nofib: exp3_8(8)", NoFib_Exp);
            // ExecTest("nofib: digits_e1(150)", NoFib_DigitsE1);
            // ExecTest("nofib: primes(500)", NoFib_Primes);
            // ExecTest("nofib: primes2(500)", NoFib_Primes2);

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