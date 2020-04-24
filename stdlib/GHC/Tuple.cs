using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Tuple
    {
        public static Unit unit_DataCon = new Unit();

        public static Fun tuple2_DataCon;

        public static Fun tuple3_DataCon;

        public static Fun tuple4_DataCon;

        public static Fun tuple5_DataCon;

        static Tuple()
        {
            tuple2_DataCon = new Fun(2, CLR.LoadFunctionPointer<Closure, Closure, Closure>(tuple2_DataCon_Entry));

            tuple3_DataCon = new Fun(3, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure>(tuple3_DataCon_Entry));

            tuple4_DataCon = new Fun(4, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure>(tuple4_DataCon_Entry));

            tuple5_DataCon = new Fun(5, CLR.LoadFunctionPointer<Closure, Closure, Closure, Closure, Closure, Closure>(tuple5_DataCon_Entry));

        }
        public static Closure tuple2_DataCon_Entry(Closure etaB2, Closure etaB1)
        {
            return new GHC.Tuple.Tuple2(etaB2, etaB1);
        }
        public static Closure tuple3_DataCon_Entry(Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return new GHC.Tuple.Tuple3(etaB3, etaB2, etaB1);
        }
        public static Closure tuple4_DataCon_Entry(Closure etaB4, Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return new GHC.Tuple.Tuple4(etaB4, etaB3, etaB2, etaB1);
        }
        public static Closure tuple5_DataCon_Entry(Closure etaB5, Closure etaB4, Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return new GHC.Tuple.Tuple5(etaB5, etaB4, etaB3, etaB2, etaB1);
        }
        public sealed class Unit : Data
        {
            public Unit() { }
            public override int Tag => 1;
            public override string ToString() => "()";
        }
        public sealed class Tuple2 : Data
        {
            public Closure x0; public Closure x1;
            public Tuple2(Closure x0, Closure x1)
            {
                this.x0 = x0; this.x1 = x1;
            }
            public override int Tag => 1;
            public override string ToString() => $"({x0}, {x1})";
        }
        public sealed class Tuple3 : Data
        {
            public Closure x0; public Closure x1; public Closure x2;
            public Tuple3(Closure x0, Closure x1, Closure x2)
            {
                this.x0 = x0; this.x1 = x1; this.x2 = x2;
            }
            public override int Tag => 1;
            public override string ToString() => $"({x0}, {x1}, {x2})";
        }
        public sealed class Tuple4 : Data
        {
            public Closure x0;
            public Closure x1; public Closure x2; public Closure x3;
            public Tuple4(Closure x0, Closure x1, Closure x2, Closure x3)
            {
                this.x0 = x0; this.x1 = x1; this.x2 = x2; this.x3 = x3;
            }
            public override int Tag => 1;
            public override string ToString() => $"({x0}, {x1}, {x2}, {x3})";
        }
        public sealed class Tuple5 : Data
        {
            public Closure x0;
            public Closure x1;
            public Closure x2; public Closure x3; public Closure x4;
            public Tuple5(Closure x0, Closure x1, Closure x2, Closure x3, Closure x4)
            {
                this.x0 = x0;
                this.x1 = x1; this.x2 = x2; this.x3 = x3; this.x4 = x4;
            }
            public override int Tag => 1;
            public override string ToString() => $"({x0}, {x1}, {x2}, {x3}, {x4})";
        }
    }
}
