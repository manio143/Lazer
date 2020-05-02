using Lazer.Runtime;

namespace GHC
{
    public unsafe static class Char
    {
        internal static string lvls1id = "Prelude.chr: bad argument: ";
        public static Function chr;

        internal static Function lvls1il;

        internal static Function wlvls1ie;

        static Char()
        {
            chr = new Fun1<Closure, Closure>(&chr_Entry);
            lvls1il = new Fun1<Closure, Closure>(&lvls1il_Entry);
            wlvls1ie = new Fun1<long, Closure>(&wlvls1ie_Entry);
        }
        public static Closure chr_Entry(Closure is1iq)
        {
            var wilds1ir = is1iq.Eval();
            var wilds1ir_IHash = wilds1ir as GHC.Types.IHash;
            var iHashs1is = wilds1ir_IHash.x0;
            var sats1it = (ulong)iHashs1is;
            var lwilds1iu = (sats1it <= 1114111UL) ? 1 : 0;
            switch (lwilds1iu)
            {
                default: { return wlvls1ie_Entry(iHashs1is); }
                case 1:
                    {
                        var sats1iv = (char)iHashs1is;
                        return new GHC.Types.CHash(sats1iv);
                    }
            }
        }
        public static Closure lvls1il_Entry(Closure ws1im)
        {
            var wws1in = ws1im.Eval();
            var wws1in_IHash = wws1in as GHC.Types.IHash;
            var wws1io = wws1in_IHash.x0; return wlvls1ie_Entry(wws1io);
        }
        public static Closure wlvls1ie_Entry(long wws1if)
        {
            var sats1ij = new Updatable<long>(&sats1ij_Entry, wws1if);
            var sats1ik = GHC.CString.unpackAppendCStringHash_Entry(lvls1id, sats1ij);
            return GHC.Err.errorWithoutStackTrace_Entry<Closure>(sats1ik);
        }
        public static Closure sats1ij_Entry(in long wws1if)
        {
            var ww4s1ig = GHC.Show.wshowSignedInt_Entry(9, wws1if, GHC.Types.nil_DataCon);
            var ww4s1ig_RawTuple = ww4s1ig;
            var ww5s1ih = ww4s1ig_RawTuple.x0;
            var ww6s1ii = ww4s1ig_RawTuple.x1;
            return new GHC.Types.Cons(ww5s1ih, ww6s1ii);
        }

    }
}
