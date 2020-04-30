using Lazer.Runtime;

namespace GHC
{
    public unsafe static class CString
    {
        public static string packCStringHash(Closure s)
        {
            var sb = new System.Text.StringBuilder();
            while (true)
            {
                s = s.Eval();
                switch (s)
                {
                    default: return null;
                    case Types.Nil s_nil: return sb.ToString();
                    case Types.Cons s_cons:
                        char c = (s_cons.x0 as Types.CHash).x0;
                        sb.Append(c);
                        s = s_cons.x1;
                        continue;
                }
            }
        }
        public static Closure unpackCStringHash_Entry(string s)
        {
            return unpackCStringHash_(s, 0);
        }
        private static Closure unpackCStringHash_(string s, int idx)
        {
            if(idx == s.Length)
                return Types.nil_DataCon;
            var cont = new Updatable<(string, int)>(&unpackCStringHash__, (s, idx));
            return new Types.Cons(new Types.CHash(s[idx]), cont);
        }
        private static Closure unpackCStringHash__(in (string s, int idx) f)
            => unpackCStringHash_(f.s, f.idx+1);
        public static Closure unpackAppendCStringHash_Entry(string s, Closure rest)
        {
            return unpackAppendCStringHash_(rest, s, 0);
        }
        private static Closure unpackAppendCStringHash_(Closure rest, string s, int idx)
        {
            if(idx == s.Length)
                return rest;
            var cont = new Updatable<(Closure, string, int)>(&unpackAppendCStringHash__, (rest, s, idx));
            return new Types.Cons(new Types.CHash(s[idx]), cont);
        }
        private static Closure unpackAppendCStringHash__(in (Closure rest, string s, int idx) f)
            => unpackAppendCStringHash_(f.rest, f.s, f.idx + 1);

        /*
            TODO: Implement (?)
                unpackFoldrCString#, unpackCStringUtf8#, unpackNBytes#
         */
    }
}