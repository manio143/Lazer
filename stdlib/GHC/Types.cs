using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Types
    {
        public static Function cons_DataCon = new Fun2<Closure, Closure, Closure>(&cons_DataCon_Entry);
        public static GHC.Types.Nil nil_DataCon = new GHC.Types.Nil();
        public static GHC.Types.GT gT_DataCon = new GHC.Types.GT();
        public static GHC.Types.EQ eQ_DataCon = new GHC.Types.EQ();
        public static GHC.Types.LT lT_DataCon = new GHC.Types.LT();
        public static GHC.Types.True true_DataCon = new GHC.Types.True();
        public static GHC.Types.False false_DataCon = new GHC.Types.False();
        public static Function isTrueHash = new Fun1<long, Closure>(&isTrueHash_Entry);
        public static Closure cons_DataCon_Entry(Closure etaB2, Closure etaB1)
        {
            return new GHC.Types.Cons(etaB2, etaB1);
        }
        public static Closure isTrueHash_Entry(long xsTl)
        {
            if (xsTl == 1)
                return true_DataCon;
            else
                return false_DataCon;
        }
        public static Closure tagToEnumHash(long t)
        {
            return new GenericEnum((int)t);
        }
        public sealed class Cons : Data
        {
            public Closure x0; public Closure x1;
            public Cons(Closure x0, Closure x1)
            {
                this.x0 = x0; this.x1 = x1;
            }
            public override int Tag => 2;
            public override string ToString()
            {
                var sb = new System.Text.StringBuilder();
                sb.Append("[");
                sb.Append(x0.ToString());
                Closure c = x1;
                while (c != null)
                {
                    switch (c.Eval())
                    {
                        default: throw new ImpossibleException();
                        case Nil nil: c = null; break;
                        case Cons cons:
                            sb.Append(", ");
                            sb.Append(cons.x0.ToString());
                            c = cons.x1;
                            break;
                    }
                }
                sb.Append("]");
                return sb.ToString();
            }
        }
        public sealed class Nil : Data
        {
            public Nil() { }
            public override int Tag => 1;
            public override string ToString() => "[]";
        }
        public sealed class GT : Data
        {
            public GT() { }
            public override int Tag => 3;
        }
        public sealed class EQ : Data
        {
            public EQ() { }
            public override int Tag => 2;
        }
        public sealed class LT : Data
        {
            public LT() { }
            public override int Tag => 1;
        }
        public sealed class True : Data
        {
            public True() { }
            public override int Tag => 2;
        }
        public sealed class False : Data
        {
            public False() { }
            public override int Tag => 1;
        }
        public sealed class IHash : Data
        {
            public long x0;
            public IHash(long x0) => this.x0 = x0;
            public override string ToString() => x0.ToString();
        }
        public sealed class CHash : Data
        {
            public char x0;
            public CHash(char x0) => this.x0 = x0;
            public override string ToString() => x0.ToString();
        }
        public sealed class FHash : Data
        {
            public float x0;
            public FHash(float x0) => this.x0 = x0;
            public override string ToString() => x0.ToString();
        }
        public sealed class DHash : Data
        {
            public double x0;
            public DHash(double x0) => this.x0 = x0;
            public override string ToString() => x0.ToString();
        }
        public sealed class WHash : Data
        {
            public ulong x0;
            public WHash(ulong x0) => this.x0 = x0;
            public override string ToString() => x0.ToString();
        }
        public sealed class GenericEnum : Data
        {
            private int tag;
            public GenericEnum(int tag) => this.tag = tag;
            public override int Tag => tag;
            public override string ToString() => $"Enum({tag})";
        }
    }
}