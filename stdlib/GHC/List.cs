using Lazer.Runtime;

namespace GHC
{
    public unsafe static class List
    {
        internal static string lvls8Np = "List.hs:410:34-55|qs@(q : _)";
        internal static string lvls8GB = "foldl1";
        internal static string lvls8Gy = "foldl1'";
        internal static string lvls8Fj = "minimum";
        internal static string lvls8F2 = "maximum";
        internal static string lvls8EU = "head";
        internal static string lvls8EM = "tail";
        internal static string lvls8EB = "last";
        internal static string lvls8Et = "init";
        internal static string lvls8Ee = "foldr1";
        internal static string lvls8E5 = "cycle";
        internal static string lvls8DI = "!!: index too large";
        internal static string lvls8DE = "!!: negative index";
        internal static string prel_list_strs8Dy = "Prelude.";
        internal static string lvls8Dw = ": empty list";
        public static Function uncons;

        public static Function @null;

        public static Function length;

        public static Function lenAcc;

        internal static Function wlenAccs8QL;

        public static Function lengthFB;

        public static Function idLength;

        public static Function filter;

        public static Function filterFB;

        public static Function foldl1;

        public static Function product;

        public static Function sum;

        public static Function foldl;

        public static Function foldl1_;

        public static Function foldl_;

        public static Function scanl1;

        public static Function scanl;

        internal static Function scanlGos8Pn;

        internal static Function wscanlGos8Pb;

        public static Function scanlFB;

        public static Function constScanl;

        public static Function scanl_;

        internal static Function scanlGo_s8OU;

        internal static Function wscanlGo_s8OH;

        public static Function scanlFB_;

        public static Function flipSeqScanl_;

        public static Function scanr;

        public static Function strictUncurryScanr;

        internal static Function wscanrs8NX;

        public static Function scanrFB;

        public static Function scanr1;

        internal static Thunk lvls8Nq;

        public static Function iterate;

        public static Function iterateFB;

        internal static Function witerates8N3;

        public static Function iterate_;

        public static Function iterate_FB;

        internal static Function witerate_s8MH;

        public static Function replicate;

        public static Function repeatFB;

        public static Function repeat;

        public static Function takeWhile;

        public static Function takeWhileFB;

        public static Function dropWhile;

        public static Function take;

        public static Function unsafeTake;

        internal static Function wunsafeTakes8LI;

        public static Function flipSeqTake;

        public static Function takeFB;

        public static Function span;

        internal static Function wspans8L1;

        public static Function @break;

        internal static Function wbreaks8KB;

        public static Function reverse;

        internal static Function poly_revs8Ks;

        public static Function and;

        public static Function or;

        public static Function any;

        public static Function all;

        public static Function elem;

        public static Function notElem;

        public static Function lookup;

        public static Function concatMap;

        public static Function concat;

        internal static Function gos8Jk;

        public static Function foldr2;

        public static Function zipWith;

        public static Function zip;

        public static Function foldr2_left;

        public static Function zipFB;

        public static Function zip3;

        public static Function zipWithFB;

        public static Function zipWith3;

        public static Function unzip;

        internal static Function gos8HD;

        internal static Function wgos8Hh;

        public static Function unzip3;

        internal static Function gos8Ha;

        internal static Function wgos8GE;

        internal static Thunk lvls8GD;

        internal static Thunk lvls8GC;

        internal static Thunk lvls8GA;

        internal static Thunk lvls8Gz;

        public static Function minimum;

        internal static Function sminimums8Gd;

        internal static Function wgos8G4;

        public static Function maximum;

        internal static Function smaximums8FJ;

        internal static Function wgos8FA;

        internal static Function sminimums8Fv;

        internal static Function gos8Fo;

        internal static Thunk lvls8Fn;

        internal static Thunk lvls8Fm;

        internal static Thunk lvls8Fl;

        internal static Thunk lvls8Fk;

        internal static Function smaximums8Fe;

        internal static Function gos8F7;

        internal static Thunk lvls8F6;

        internal static Thunk lvls8F5;

        internal static Thunk lvls8F4;

        internal static Thunk lvls8F3;

        public static Function head;

        public static Thunk badHead;

        internal static Thunk lvls8EV;

        public static Function tail;

        internal static Thunk lvls8EO;

        internal static Thunk lvls8EN;

        public static Function last;

        internal static Function poly_gos8EE;

        public static Thunk lastError;

        internal static Thunk lvls8EC;

        public static Function init;

        internal static Thunk lvls8Ev;

        internal static Thunk lvls8Eu;

        public static Function foldr1;

        internal static Thunk lvls8Eg;

        internal static Thunk lvls8Ef;

        public static Function cycle;

        internal static Thunk lvls8E7;

        internal static Thunk lvls8E6;

        public static Function bangBang;

        internal static Function wBangBangs8DW;

        internal static Function poly_Dollwgos8DO;

        internal static Thunk poly_exits8DN;

        public static Function tooLarge;

        internal static Thunk lvls8DK;

        internal static Thunk lvls8DJ;

        public static Thunk negIndex;

        internal static Thunk lvls8DF;

        public static Function errorEmptyList;

        public static Thunk prel_list_str;

        internal static Thunk lvls8Dx;

        internal static Function poly_init_s8Dp;

        public static Function splitAt;

        internal static Function splitAt_s8D5;

        internal static Function wsplitAt_s8CG;

        public static Function drop;

        internal static Function wunsafeDrops8Cs;

        internal static GHC.Integer.Type.SHash lvls8PX;
        internal static GHC.Integer.Type.SHash lvls8PY;

        static List()
        {
            uncons = new Fun1<Closure, Closure>(&uncons_Entry);
            @null = new Fun1<Closure, Closure>(&@null_Entry);
            length = new Fun1<Closure, Closure>(&length_Entry);
            lenAcc = new Fun2<Closure, Closure, Closure>(&lenAcc_Entry);

            wlenAccs8QL = new Fun2<Closure, long, long>(&wlenAccs8QL_Entry);

            lengthFB = new Fun3<Closure, Closure, Closure, Closure>(&lengthFB_Entry);

            idLength = new Fun1<Closure, Closure>(&idLength_Entry);
            filter = new Fun2<Closure, Closure, Closure>(&filter_Entry);

            filterFB = new Fun4<Closure, Closure, Closure, Closure, Closure>(&filterFB_Entry);

            foldl1 = new Fun2<Closure, Closure, Closure>(&foldl1_Entry);

            product = new Fun1<Closure, Closure>(&product_Entry);
            sum = new Fun1<Closure, Closure>(&sum_Entry);
            foldl = new Fun3<Closure, Closure, Closure, Closure>(&foldl_Entry);

            foldl1_ = new Fun2<Closure, Closure, Closure>(&foldl1__Entry);

            foldl_ = new Fun3<Closure, Closure, Closure, Closure>(&foldl__Entry);

            scanl1 = new Fun2<Closure, Closure, Closure>(&scanl1_Entry);

            scanl = new Fun3<Closure, Closure, Closure, Closure>(&scanl_Entry);

            scanlGos8Pn = new Fun3<Closure, Closure, Closure, Closure>(&scanlGos8Pn_Entry);

            wscanlGos8Pb = new Fun3<Closure, Closure, Closure, (Closure x0, Closure x1)>(&wscanlGos8Pb_Entry);

            scanlFB = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&scanlFB_Entry);

            constScanl = new Fun2<Closure, Closure, Closure>(&constScanl_Entry);

            scanl_ = new Fun3<Closure, Closure, Closure, Closure>(&scanl__Entry);

            scanlGo_s8OU = new Fun3<Closure, Closure, Closure, Closure>(&scanlGo_s8OU_Entry);

            wscanlGo_s8OH = new Fun3<Closure, Closure, Closure, (Closure x0, Closure x1)>(&wscanlGo_s8OH_Entry);

            scanlFB_ = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&scanlFB__Entry);

            flipSeqScanl_ = new Fun2<Closure, Closure, Closure>(&flipSeqScanl__Entry);

            scanr = new Fun3<Closure, Closure, Closure, Closure>(&scanr_Entry);

            strictUncurryScanr = new Fun2<Closure, Closure, Closure>(&strictUncurryScanr_Entry);

            wscanrs8NX = new Fun3<Closure, Closure, Closure, (Closure x0, Closure x1)>(&wscanrs8NX_Entry);

            scanrFB = new Fun4<Closure, Closure, Closure, Closure, Closure>(&scanrFB_Entry);

            scanr1 = new Fun2<Closure, Closure, Closure>(&scanr1_Entry);

            lvls8Nq = new Updatable(&lvls8Nq_Entry);
            iterate = new Fun2<Closure, Closure, Closure>(&iterate_Entry);

            iterateFB = new Fun3<Closure, Closure, Closure, Closure>(&iterateFB_Entry);

            witerates8N3 = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&witerates8N3_Entry);

            iterate_ = new Fun2<Closure, Closure, Closure>(&iterate__Entry);

            iterate_FB = new Fun3<Closure, Closure, Closure, Closure>(&iterate_FB_Entry);

            witerate_s8MH = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&witerate_s8MH_Entry);

            replicate = new Fun2<Closure, Closure, Closure>(&replicate_Entry);

            repeatFB = new Fun2<Closure, Closure, Closure>(&repeatFB_Entry);

            repeat = new Fun1<Closure, Closure>(&repeat_Entry);
            takeWhile = new Fun2<Closure, Closure, Closure>(&takeWhile_Entry);

            takeWhileFB = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&takeWhileFB_Entry);

            dropWhile = new Fun2<Closure, Closure, Closure>(&dropWhile_Entry);

            take = new Fun2<Closure, Closure, Closure>(&take_Entry);

            unsafeTake = new Fun2<Closure, Closure, Closure>(&unsafeTake_Entry);

            wunsafeTakes8LI = new Fun2<long, Closure, Closure>(&wunsafeTakes8LI_Entry);

            flipSeqTake = new Fun2<Closure, Closure, Closure>(&flipSeqTake_Entry);

            takeFB = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&takeFB_Entry);

            span = new Fun2<Closure, Closure, Closure>(&span_Entry);

            wspans8L1 = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&wspans8L1_Entry);

            @break = new Fun2<Closure, Closure, Closure>(&@break_Entry);

            wbreaks8KB = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&wbreaks8KB_Entry);

            reverse = new Fun1<Closure, Closure>(&reverse_Entry);
            poly_revs8Ks = new Fun2<Closure, Closure, Closure>(&poly_revs8Ks_Entry);

            and = new Fun1<Closure, Closure>(&and_Entry);
            or = new Fun1<Closure, Closure>(&or_Entry);
            any = new Fun2<Closure, Closure, Closure>(&any_Entry);
            all = new Fun2<Closure, Closure, Closure>(&all_Entry);
            elem = new Fun3<Closure, Closure, Closure, Closure>(&elem_Entry);

            notElem = new Fun3<Closure, Closure, Closure, Closure>(&notElem_Entry);

            lookup = new Fun3<Closure, Closure, Closure, Closure>(&lookup_Entry);

            concatMap = new Fun2<Closure, Closure, Closure>(&concatMap_Entry);

            concat = new Fun1<Closure, Closure>(&concat_Entry);
            gos8Jk = new Fun1<Closure, Closure>(&gos8Jk_Entry);
            foldr2 = new Fun4<Closure, Closure, Closure, Closure, Closure>(&foldr2_Entry);

            zipWith = new Fun3<Closure, Closure, Closure, Closure>(&zipWith_Entry);

            zip = new Fun2<Closure, Closure, Closure>(&zip_Entry);
            foldr2_left = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&foldr2_left_Entry);

            zipFB = new Fun4<Closure, Closure, Closure, Closure, Closure>(&zipFB_Entry);

            zip3 = new Fun3<Closure, Closure, Closure, Closure>(&zip3_Entry);

            zipWithFB = new Fun5<Closure, Closure, Closure, Closure, Closure, Closure>(&zipWithFB_Entry);

            zipWith3 = new Fun4<Closure, Closure, Closure, Closure, Closure>(&zipWith3_Entry);

            unzip = new Fun1<Closure, Closure>(&unzip_Entry);
            gos8HD = new Fun1<Closure, Closure>(&gos8HD_Entry);
            wgos8Hh = new Fun1<Closure, (Closure x0, Closure x1)>(&wgos8Hh_Entry);

            unzip3 = new Fun1<Closure, Closure>(&unzip3_Entry);
            gos8Ha = new Fun1<Closure, Closure>(&gos8Ha_Entry);
            wgos8GE = new Fun1<Closure, (Closure x0, Closure x1, Closure x2)>(&wgos8GE_Entry);

            lvls8GD = new Updatable(&lvls8GD_Entry);
            lvls8GC = new Updatable(&lvls8GC_Entry);
            lvls8GA = new Updatable(&lvls8GA_Entry);
            lvls8Gz = new Updatable(&lvls8Gz_Entry);
            minimum = new Fun2<Closure, Closure, Closure>(&minimum_Entry);

            sminimums8Gd = new Fun1<Closure, Closure>(&sminimums8Gd_Entry);

            wgos8G4 = new Fun2<Closure, long, long>(&wgos8G4_Entry);

            maximum = new Fun2<Closure, Closure, Closure>(&maximum_Entry);

            smaximums8FJ = new Fun1<Closure, Closure>(&smaximums8FJ_Entry);

            wgos8FA = new Fun2<Closure, long, long>(&wgos8FA_Entry);

            sminimums8Fv = new Fun1<Closure, Closure>(&sminimums8Fv_Entry);

            gos8Fo = new Fun2<Closure, Closure, Closure>(&gos8Fo_Entry);

            lvls8Fn = new Updatable(&lvls8Fn_Entry);
            lvls8Fm = new Updatable(&lvls8Fm_Entry);
            lvls8Fl = new Updatable(&lvls8Fl_Entry);
            lvls8Fk = new Updatable(&lvls8Fk_Entry);
            smaximums8Fe = new Fun1<Closure, Closure>(&smaximums8Fe_Entry);

            gos8F7 = new Fun2<Closure, Closure, Closure>(&gos8F7_Entry);

            lvls8F6 = new Updatable(&lvls8F6_Entry);
            lvls8F5 = new Updatable(&lvls8F5_Entry);
            lvls8F4 = new Updatable(&lvls8F4_Entry);
            lvls8F3 = new Updatable(&lvls8F3_Entry);
            head = new Fun1<Closure, Closure>(&head_Entry);
            badHead = new Updatable(&badHead_Entry);
            lvls8EV = new Updatable(&lvls8EV_Entry);
            tail = new Fun1<Closure, Closure>(&tail_Entry);
            lvls8EO = new Updatable(&lvls8EO_Entry);
            lvls8EN = new Updatable(&lvls8EN_Entry);
            last = new Fun1<Closure, Closure>(&last_Entry);
            poly_gos8EE = new Fun2<Closure, Closure, Closure>(&poly_gos8EE_Entry);

            lastError = new Updatable(&lastError_Entry);
            lvls8EC = new Updatable(&lvls8EC_Entry);
            init = new Fun1<Closure, Closure>(&init_Entry);
            lvls8Ev = new Updatable(&lvls8Ev_Entry);
            lvls8Eu = new Updatable(&lvls8Eu_Entry);
            foldr1 = new Fun2<Closure, Closure, Closure>(&foldr1_Entry);

            lvls8Eg = new Updatable(&lvls8Eg_Entry);
            lvls8Ef = new Updatable(&lvls8Ef_Entry);
            cycle = new Fun1<Closure, Closure>(&cycle_Entry);
            lvls8E7 = new Updatable(&lvls8E7_Entry);
            lvls8E6 = new Updatable(&lvls8E6_Entry);
            bangBang = new Fun2<Closure, Closure, Closure>(&bangBang_Entry);

            wBangBangs8DW = new Fun2<Closure, long, Closure>(&wBangBangs8DW_Entry);

            poly_Dollwgos8DO = new Fun2<Closure, long, Closure>(&poly_Dollwgos8DO_Entry);

            poly_exits8DN = new Updatable(&poly_exits8DN_Entry);
            tooLarge = new Fun1<Closure, Closure>(&tooLarge_Entry);
            lvls8DK = new Updatable(&lvls8DK_Entry);
            lvls8DJ = new Updatable(&lvls8DJ_Entry);
            negIndex = new Updatable(&negIndex_Entry);
            lvls8DF = new Updatable(&lvls8DF_Entry);
            errorEmptyList = new Fun1<Closure, Closure>(&errorEmptyList_Entry);

            prel_list_str = new Updatable(&prel_list_str_Entry);
            lvls8Dx = new Updatable(&lvls8Dx_Entry);
            poly_init_s8Dp = new Fun2<Closure, Closure, Closure>(&poly_init_s8Dp_Entry);

            splitAt = new Fun2<Closure, Closure, Closure>(&splitAt_Entry);

            splitAt_s8D5 = new Fun2<Closure, Closure, Closure>(&splitAt_s8D5_Entry);

            wsplitAt_s8CG = new Fun2<Closure, Closure, (Closure x0, Closure x1)>(&wsplitAt_s8CG_Entry);

            drop = new Fun2<Closure, Closure, Closure>(&drop_Entry);

            wunsafeDrops8Cs = new Fun2<long, Closure, Closure>(&wunsafeDrops8Cs_Entry);

            lvls8PY = new GHC.Integer.Type.SHash(0);
            lvls8PX = new GHC.Integer.Type.SHash(1);
        }
        public static Closure uncons_Entry(Closure dss8R7)
        {
            var wilds8R8 = dss8R7.Eval();
            switch (wilds8R8)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8R8_Nil:
                    {
                        return GHC.Maybe.nothing_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8R8_Cons:
                    {
                        var xs8R9 = wilds8R8_Cons.x0;
                        var xss8Ra = wilds8R8_Cons.x1;
                        var sats8Rb = new GHC.Tuple.Tuple2(xs8R9, xss8Ra);
                        return new GHC.Maybe.Just(sats8Rb);
                    }
            }
        }
        public static Closure @null_Entry(Closure dss8R2)
        {
            var wilds8R3 = dss8R2.Eval();
            switch (wilds8R3)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8R3_Nil:
                    {
                        return GHC.Types.true_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8R3_Cons:
                    {
                        var dss8R4 = wilds8R3_Cons.x0;
                        var dss8R5 = wilds8R3_Cons.x1;
                        return GHC.Types.false_DataCon.Eval();
                    }
            }
        }
        public static Closure length_Entry(Closure ws8QZ)
        {
            var wws8R0 = wlenAccs8QL_Entry(ws8QZ, 0);
            return new GHC.Types.IHash(wws8R0);
        }
        public static Closure lenAcc_Entry(Closure ws8QT, Closure ws8QU)
        {
            var wws8QV = ws8QU.Eval();
            var wws8QV_IHash = wws8QV as GHC.Types.IHash;
            var wws8QW = wws8QV_IHash.x0;
            var wws8QX = wlenAccs8QL_Entry(ws8QT, wws8QW);
            return new GHC.Types.IHash(wws8QX);
        }
        public static long wlenAccs8QL_Entry(Closure ws8QM, long wws8QN)
        {
            var wilds8QO = ws8QM.Eval();
            switch (wilds8QO)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8QO_Nil: { return wws8QN; }
                case GHC.Types.Cons wilds8QO_Cons:
                    {
                        var dss8QP = wilds8QO_Cons.x0;
                        var yss8QQ = wilds8QO_Cons.x1;
                        var sats8QR = wws8QN + 1;
                        return wlenAccs8QL_Entry(yss8QQ, sats8QR);
                    }
            }
        }
        public static Closure lengthFB_Entry(Closure etas8QE, Closure etas8QF, Closure as8QG)
        {
            var as8QH = as8QG.Eval();
            var as8QH_IHash = as8QH as GHC.Types.IHash;
            var ipvs8QI = as8QH_IHash.x0;
            var sats8QJ = ipvs8QI + 1;
            var sats8QK = new GHC.Types.IHash(sats8QJ);
            return etas8QF.Apply<Closure, Closure>(sats8QK);
        }
        public static Closure idLength_Entry(Closure etaB1)
        {
            return GHC.Base.id_Entry(etaB1);
        }
        public static Closure filter_Entry(Closure _preds8Qv, Closure dss8Qw)
        {
            var wilds8Qx = dss8Qw.Eval();
            switch (wilds8Qx)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Qx_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Qx_Cons:
                    {
                        var xs8Qy = wilds8Qx_Cons.x0;
                        var xss8Qz = wilds8Qx_Cons.x1;
                        var wilds8QA = _preds8Qv.Apply<Closure, Closure>(xs8Qy);
                        var wilds8QATags8QA = wilds8QA.Tag;
                        switch (wilds8QATags8QA)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8QA_False = wilds8QA as GHC.Types.False;
                                    return filter_Entry(_preds8Qv, xss8Qz);
                                }
                            case 2:
                                {
                                    var wilds8QA_True = wilds8QA as GHC.Types.True;
                                    var sat_Frees8QB = (_preds8Qv, xss8Qz);
                                    var sats8QB = new Updatable<(Closure x0, Closure x1)>(&sats8QB_Entry, sat_Frees8QB);
                                    return new GHC.Types.Cons(xs8Qy, sats8QB);
                                }
                        }
                    }
            }
        }
        public static Closure sats8QB_Entry(in (Closure x0, Closure x1) sat_Frees8QB)
        {
            var _preds8Qv = sat_Frees8QB.x0;
            var xss8Qz = sat_Frees8QB.x1;
            return filter_Entry(_preds8Qv, xss8Qz);
        }
        public static Closure filterFB_Entry(Closure cs8Qp, Closure ps8Qq, Closure xs8Qr, Closure rs8Qs)
        {
            var wilds8Qt = ps8Qq.Apply<Closure, Closure>(xs8Qr);
            var wilds8QtTags8Qt = wilds8Qt.Tag;
            switch (wilds8QtTags8Qt)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds8Qt_False = wilds8Qt as GHC.Types.False;
                        return rs8Qs.Eval();
                    }
                case 2:
                    {
                        var wilds8Qt_True = wilds8Qt as GHC.Types.True;
                        return cs8Qp.Apply<Closure, Closure, Closure>(xs8Qr, rs8Qs);
                    }
            }
        }
        public static Closure foldl1_Entry(Closure fs8Qj, Closure dss8Qk)
        {
            var wilds8Ql = dss8Qk.Eval();
            switch (wilds8Ql)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ql_Nil: { return lvls8GD.Eval(); }
                case GHC.Types.Cons wilds8Ql_Cons:
                    {
                        var xs8Qm = wilds8Ql_Cons.x0;
                        var xss8Qn = wilds8Ql_Cons.x1;
                        return foldl_Entry(fs8Qj, xs8Qm, xss8Qn);
                    }
            }
        }
        public static Closure product_Entry(Closure dNums8Qf)
        {
            var sats8Qh = new Updatable<Closure>(&sats8Qh_Entry, dNums8Qf);
            var sats8Qg = new Updatable<Closure>(&sats8Qg_Entry, dNums8Qf);
            return GHC.List.foldl.Apply<Closure, Closure, Closure>(sats8Qg, sats8Qh);
        }
        public static Closure sats8Qg_Entry(in Closure dNums8Qf)
        {
            return GHC.Num.astr_Entry(dNums8Qf);
        }
        public static Closure sats8Qh_Entry(in Closure dNums8Qf)
        {
            return GHC.Num.fromInteger_Entry(dNums8Qf).Apply<Closure, Closure>(lvls8PX);
        }
        public static Closure sum_Entry(Closure dNums8Qb)
        {
            var sats8Qd = new Updatable<Closure>(&sats8Qd_Entry, dNums8Qb);
            var sats8Qc = new Updatable<Closure>(&sats8Qc_Entry, dNums8Qb);
            return GHC.List.foldl.Apply<Closure, Closure, Closure>(sats8Qc, sats8Qd);
        }
        public static Closure sats8Qc_Entry(in Closure dNums8Qb)
        {
            return GHC.Num.plus_Entry(dNums8Qb);
        }
        public static Closure sats8Qd_Entry(in Closure dNums8Qb)
        {
            return GHC.Num.fromInteger_Entry(dNums8Qb).Apply<Closure, Closure>(lvls8PY);
        }
        public static Closure foldl_Entry(Closure ks8Q0, Closure z0s8Q1, Closure xss8Q2)
        {
            var go_Frees8Q3 = (ks8Q0, (Closure)null);
            var gos8Q3 = new Fun2<(Closure x0, Closure x1), Closure, Closure, Closure>(&gos8Q3_Entry, go_Frees8Q3);
            gos8Q3.free.x1 = gos8Q3;
            return gos8Q3.Apply<Closure, Closure, Closure>(xss8Q2, z0s8Q1);
        }
        public static Closure gos8Q3_Entry(in (Closure x0, Closure x1) go_Frees8Q3, Closure dss8Q4, Closure etas8Q5)
        {
            var ks8Q0 = go_Frees8Q3.x0;
            var gos8Q3 = go_Frees8Q3.x1;
            var wilds8Q6 = dss8Q4.Eval();
            switch (wilds8Q6)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Q6_Nil: { return etas8Q5.Eval(); }
                case GHC.Types.Cons wilds8Q6_Cons:
                    {
                        var ys8Q7 = wilds8Q6_Cons.x0;
                        var yss8Q8 = wilds8Q6_Cons.x1;
                        var sat_Frees8Q9 = (ks8Q0, etas8Q5, ys8Q7);
                        var sats8Q9 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Q9_Entry, sat_Frees8Q9);
                        return gos8Q3.Apply<Closure, Closure, Closure>(yss8Q8, sats8Q9);
                    }
            }
        }
        public static Closure sats8Q9_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Q9)
        {
            var ks8Q0 = sat_Frees8Q9.x0;
            var etas8Q5 = sat_Frees8Q9.x1;
            var ys8Q7 = sat_Frees8Q9.x2;
            return ks8Q0.Apply<Closure, Closure, Closure>(etas8Q5, ys8Q7);
        }
        public static Closure foldl1__Entry(Closure fs8PS, Closure dss8PT)
        {
            var wilds8PU = dss8PT.Eval();
            switch (wilds8PU)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8PU_Nil: { return lvls8GA.Eval(); }
                case GHC.Types.Cons wilds8PU_Cons:
                    {
                        var xs8PV = wilds8PU_Cons.x0;
                        var xss8PW = wilds8PU_Cons.x1;
                        return foldl__Entry(fs8PS, xs8PV, xss8PW);
                    }
            }
        }
        public static Closure foldl__Entry(Closure ks8PG, Closure z0s8PH, Closure xss8PI)
        {
            var go_Frees8PJ = (ks8PG, (Closure)null);
            var gos8PJ = new Fun2<(Closure x0, Closure x1), Closure, Closure, Closure>(&gos8PJ_Entry, go_Frees8PJ);
            gos8PJ.free.x1 = gos8PJ;
            return gos8PJ.Apply<Closure, Closure, Closure>(xss8PI, z0s8PH);
        }
        public static Closure gos8PJ_Entry(in (Closure x0, Closure x1) go_Frees8PJ, Closure dss8PK, Closure etas8PL)
        {
            var ks8PG = go_Frees8PJ.x0;
            var gos8PJ = go_Frees8PJ.x1;
            var wilds8PM = dss8PK.Eval();
            switch (wilds8PM)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8PM_Nil: { return etas8PL.Eval(); }
                case GHC.Types.Cons wilds8PM_Cons:
                    {
                        var ys8PN = wilds8PM_Cons.x0;
                        var yss8PO = wilds8PM_Cons.x1;
                        var zs8PP = etas8PL.Eval();
                        var sats8PQ = ks8PG.Apply<Closure, Closure, Closure>(zs8PP, ys8PN);
                        return gos8PJ.Apply<Closure, Closure, Closure>(yss8PO, sats8PQ);
                    }
            }
        }
        public static Closure scanl1_Entry(Closure fs8Pw, Closure dss8Px)
        {
            var wilds8Py = dss8Px.Eval();
            switch (wilds8Py)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Py_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Py_Cons:
                    {
                        var xs8Pz = wilds8Py_Cons.x0;
                        var xss8PA = wilds8Py_Cons.x1;
                        var sat_Frees8PE = (fs8Pw, xs8Pz, xss8PA);
                        var sats8PE = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8PE_Entry, sat_Frees8PE);
                        return new GHC.Types.Cons(xs8Pz, sats8PE);
                    }
            }
        }
        public static Closure sats8PE_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8PE)
        {
            var fs8Pw = sat_Frees8PE.x0;
            var xs8Pz = sat_Frees8PE.x1;
            var xss8PA = sat_Frees8PE.x2;
            var wws8PB = wscanlGos8Pb_Entry(fs8Pw, xs8Pz, xss8PA);
            var wws8PB_RawTuple = wws8PB;
            var wws8PC = wws8PB_RawTuple.x0;
            var wws8PD = wws8PB_RawTuple.x1; return wws8PD.Eval();
        }
        public static Closure scanl_Entry(Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return scanlGos8Pn_Entry(etaB3, etaB2, etaB1);
        }
        public static Closure scanlGos8Pn_Entry(Closure ws8Po, Closure ws8Pp, Closure ws8Pq)
        {
            var wws8Pr = wscanlGos8Pb_Entry(ws8Po, ws8Pp, ws8Pq);
            var wws8Pr_RawTuple = wws8Pr;
            var wws8Ps = wws8Pr_RawTuple.x0;
            var wws8Pt = wws8Pr_RawTuple.x1;
            return new GHC.Types.Cons(wws8Ps, wws8Pt);
        }
        public static (Closure x0, Closure x1) wscanlGos8Pb_Entry(Closure ws8Pc, Closure ws8Pd, Closure ws8Pe)
        {
            var sat_Frees8Pm = (ws8Pc, ws8Pd, ws8Pe);
            var sats8Pm = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Pm_Entry, sat_Frees8Pm);
            return (ws8Pd, sats8Pm);
        }
        public static Closure sats8Pm_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Pm)
        {
            var ws8Pc = sat_Frees8Pm.x0;
            var ws8Pd = sat_Frees8Pm.x1;
            var ws8Pe = sat_Frees8Pm.x2;
            var wilds8Pf = ws8Pe.Eval();
            switch (wilds8Pf)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Pf_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Pf_Cons:
                    {
                        var xs8Pg = wilds8Pf_Cons.x0;
                        var xss8Ph = wilds8Pf_Cons.x1;
                        var sat_Frees8Pi = (ws8Pc, ws8Pd, xs8Pg);
                        var sats8Pi = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Pi_Entry, sat_Frees8Pi);
                        var wws8Pj = wscanlGos8Pb_Entry(ws8Pc, sats8Pi, xss8Ph);
                        var wws8Pj_RawTuple = wws8Pj;
                        var wws8Pk = wws8Pj_RawTuple.x0;
                        var wws8Pl = wws8Pj_RawTuple.x1;
                        return new GHC.Types.Cons(wws8Pk, wws8Pl);
                    }
            }
        }
        public static Closure sats8Pi_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Pi)
        {
            var ws8Pc = sat_Frees8Pi.x0;
            var ws8Pd = sat_Frees8Pi.x1;
            var xs8Pg = sat_Frees8Pi.x2;
            return ws8Pc.Apply<Closure, Closure, Closure>(ws8Pd, xs8Pg);
        }
        public static Closure scanlFB_Entry(Closure fs8P4, Closure cs8P5, Closure bs8P6, Closure gs8P7, Closure vs8P8)
        {
            var b__Frees8P9 = (fs8P4, bs8P6, vs8P8);
            var b_s8P9 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&b_s8P9_Entry, b__Frees8P9);
            var sat_Frees8Pa = (gs8P7, b_s8P9);
            var sats8Pa = new Updatable<(Closure x0, Closure x1)>(&sats8Pa_Entry, sat_Frees8Pa);
            return cs8P5.Apply<Closure, Closure, Closure>(b_s8P9, sats8Pa);
        }
        public static Closure sats8Pa_Entry(in (Closure x0, Closure x1) sat_Frees8Pa)
        {
            var gs8P7 = sat_Frees8Pa.x0;
            var b_s8P9 = sat_Frees8Pa.x1;
            return gs8P7.Apply<Closure, Closure>(b_s8P9);
        }
        public static Closure b_s8P9_Entry(in (Closure x0, Closure x1, Closure x2) b__Frees8P9)
        {
            var fs8P4 = b__Frees8P9.x0;
            var bs8P6 = b__Frees8P9.x1;
            var vs8P8 = b__Frees8P9.x2;
            return fs8P4.Apply<Closure, Closure, Closure>(vs8P8, bs8P6);
        }
        public static Closure constScanl_Entry(Closure etaB2, Closure etaB1)
        {
            return GHC.Base.@const_Entry(etaB2, etaB1);
        }
        public static Closure scanl__Entry(Closure etaB3, Closure etaB2, Closure etaB1)
        {
            return scanlGo_s8OU_Entry(etaB3, etaB2, etaB1);
        }
        public static Closure scanlGo_s8OU_Entry(Closure ws8OV, Closure ws8OW, Closure ws8OX)
        {
            var wws8OY = wscanlGo_s8OH_Entry(ws8OV, ws8OW, ws8OX);
            var wws8OY_RawTuple = wws8OY;
            var wws8OZ = wws8OY_RawTuple.x0;
            var wws8P0 = wws8OY_RawTuple.x1;
            return new GHC.Types.Cons(wws8OZ, wws8P0);
        }
        public static (Closure x0, Closure x1) wscanlGo_s8OH_Entry(Closure ws8OI, Closure ws8OJ, Closure ws8OK)
        {
            var qs8OL = ws8OJ.Eval();
            var sat_Frees8OT = (ws8OI, ws8OK, qs8OL);
            var sats8OT = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8OT_Entry, sat_Frees8OT);
            return (qs8OL, sats8OT);
        }
        public static Closure sats8OT_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8OT)
        {
            var ws8OI = sat_Frees8OT.x0;
            var ws8OK = sat_Frees8OT.x1;
            var qs8OL = sat_Frees8OT.x2;
            var wilds8OM = ws8OK.Eval();
            switch (wilds8OM)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8OM_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8OM_Cons:
                    {
                        var xs8ON = wilds8OM_Cons.x0;
                        var xss8OO = wilds8OM_Cons.x1;
                        var sats8OP = ws8OI.Apply<Closure, Closure, Closure>(qs8OL, xs8ON);
                        var wws8OQ = wscanlGo_s8OH_Entry(ws8OI, sats8OP, xss8OO);
                        var wws8OQ_RawTuple = wws8OQ;
                        var wws8OR = wws8OQ_RawTuple.x0;
                        var wws8OS = wws8OQ_RawTuple.x1;
                        return new GHC.Types.Cons(wws8OR, wws8OS);
                    }
            }
        }
        public static Closure scanlFB__Entry(Closure fs8OA, Closure cs8OB, Closure bs8OC, Closure gs8OD, Closure vs8OE)
        {
            var b_s8OF = fs8OA.Apply<Closure, Closure, Closure>(vs8OE, bs8OC);
            var sat_Frees8OG = (gs8OD, b_s8OF);
            var sats8OG = new Updatable<(Closure x0, Closure x1)>(&sats8OG_Entry, sat_Frees8OG);
            return cs8OB.Apply<Closure, Closure, Closure>(b_s8OF, sats8OG);
        }
        public static Closure sats8OG_Entry(in (Closure x0, Closure x1) sat_Frees8OG)
        {
            var gs8OD = sat_Frees8OG.x0;
            var b_s8OF = sat_Frees8OG.x1;
            return gs8OD.Apply<Closure, Closure>(b_s8OF);
        }
        public static Closure flipSeqScanl__Entry(Closure as8Ow, Closure _bs8Ox)
        {
            var _bs8Oy = _bs8Ox.Eval(); return as8Ow.Eval();
        }
        public static Closure scanr_Entry(Closure ws8Op, Closure ws8Oq, Closure ws8Or)
        {
            var wws8Os = wscanrs8NX_Entry(ws8Op, ws8Oq, ws8Or);
            var wws8Os_RawTuple = wws8Os;
            var wws8Ot = wws8Os_RawTuple.x0;
            var wws8Ou = wws8Os_RawTuple.x1;
            return new GHC.Types.Cons(wws8Ot, wws8Ou);
        }
        public static Closure strictUncurryScanr_Entry(Closure fs8Ok, Closure pairs8Ol)
        {
            var wilds8Om = pairs8Ol.Eval();
            var wilds8Om_Tuple2 = wilds8Om as GHC.Tuple.Tuple2;
            var xs8On = wilds8Om_Tuple2.x0;
            var ys8Oo = wilds8Om_Tuple2.x1;
            return fs8Ok.Apply<Closure, Closure, Closure>(xs8On, ys8Oo);
        }
        public static (Closure x0, Closure x1) wscanrs8NX_Entry(Closure ws8NY, Closure ws8NZ, Closure ws8O0)
        {
            var wilds8O1 = ws8O0.Eval();
            switch (wilds8O1)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8O1_Nil:
                    {
                        return (ws8NZ, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8O1_Cons:
                    {
                        var xs8O2 = wilds8O1_Cons.x0;
                        var xss8O3 = wilds8O1_Cons.x1;
                        var ds_Frees8O4 = (ws8NY, ws8NZ, xss8O3);
                        var dss8O4 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&dss8O4_Entry, ds_Frees8O4);
                        var sats8Oh = new Updatable<Closure>(&sats8Oh_Entry, dss8O4);
                        var sat_Frees8Od = (ws8NY, xs8O2, dss8O4);
                        var sats8Od = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Od_Entry, sat_Frees8Od);
                        return (sats8Od, sats8Oh);
                    }
            }
        }
        public static Closure sats8Od_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Od)
        {
            var ws8NY = sat_Frees8Od.x0;
            var xs8O2 = sat_Frees8Od.x1;
            var dss8O4 = sat_Frees8Od.x2;
            var sats8Oc = new Updatable<Closure>(&sats8Oc_Entry, dss8O4);
            return ws8NY.Apply<Closure, Closure, Closure>(xs8O2, sats8Oc);
        }
        public static Closure sats8Oc_Entry(in Closure dss8O4)
        {
            var dss8O9 = dss8O4.Eval();
            var dss8O9_Tuple2 = dss8O9 as GHC.Tuple.Tuple2;
            var qss8Oa = dss8O9_Tuple2.x0;
            var qs8Ob = dss8O9_Tuple2.x1; return qs8Ob.Eval();
        }
        public static Closure sats8Oh_Entry(in Closure dss8O4)
        {
            var dss8Oe = dss8O4.Eval();
            var dss8Oe_Tuple2 = dss8Oe as GHC.Tuple.Tuple2;
            var qss8Of = dss8Oe_Tuple2.x0;
            var qs8Og = dss8Oe_Tuple2.x1; return qss8Of.Eval();
        }
        public static Closure dss8O4_Entry(in (Closure x0, Closure x1, Closure x2) ds_Frees8O4)
        {
            var ws8NY = ds_Frees8O4.x0;
            var ws8NZ = ds_Frees8O4.x1;
            var xss8O3 = ds_Frees8O4.x2;
            var wws8O5 = wscanrs8NX_Entry(ws8NY, ws8NZ, xss8O3);
            var wws8O5_RawTuple = wws8O5;
            var wws8O6 = wws8O5_RawTuple.x0;
            var wws8O7 = wws8O5_RawTuple.x1;
            var sats8O8 = new GHC.Types.Cons(wws8O6, wws8O7);
            return new GHC.Tuple.Tuple2(sats8O8, wws8O6);
        }
        public static Closure scanrFB_Entry(Closure fs8NO, Closure cs8NP, Closure xs8NQ, Closure dss8NR)
        {
            var wilds8NS = dss8NR.Eval();
            var wilds8NS_Tuple2 = wilds8NS as GHC.Tuple.Tuple2;
            var rs8NT = wilds8NS_Tuple2.x0;
            var ests8NU = wilds8NS_Tuple2.x1;
            var sat_Frees8NW = (cs8NP, rs8NT, ests8NU);
            var sats8NW = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8NW_Entry, sat_Frees8NW);
            var sat_Frees8NV = (fs8NO, xs8NQ, rs8NT);
            var sats8NV = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8NV_Entry, sat_Frees8NV);
            return new GHC.Tuple.Tuple2(sats8NV, sats8NW);
        }
        public static Closure sats8NV_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8NV)
        {
            var fs8NO = sat_Frees8NV.x0;
            var xs8NQ = sat_Frees8NV.x1;
            var rs8NT = sat_Frees8NV.x2;
            return fs8NO.Apply<Closure, Closure, Closure>(xs8NQ, rs8NT);
        }
        public static Closure sats8NW_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8NW)
        {
            var cs8NP = sat_Frees8NW.x0;
            var rs8NT = sat_Frees8NW.x1;
            var ests8NU = sat_Frees8NW.x2;
            return cs8NP.Apply<Closure, Closure, Closure>(rs8NT, ests8NU);
        }
        public static Closure scanr1_Entry(Closure dss8Ns, Closure dss8Nt)
        {
            var wilds8Nu = dss8Nt.Eval();
            switch (wilds8Nu)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Nu_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Nu_Cons:
                    {
                        var xs8Nv = wilds8Nu_Cons.x0;
                        var dss8Nw = wilds8Nu_Cons.x1;
                        var wilds8Nx = dss8Nw.Eval();
                        switch (wilds8Nx)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8Nx_Nil:
                                {
                                    return new GHC.Types.Cons(xs8Nv, GHC.Types.nil_DataCon);
                                }
                            case GHC.Types.Cons wilds8Nx_Cons:
                                {
                                    var ipvs8Ny = wilds8Nx_Cons.x0;
                                    var ipvs8Nz = wilds8Nx_Cons.x1;
                                    var ds_Frees8NA = (dss8Ns, wilds8Nx);
                                    var dss8NA = new Updatable<(Closure x0, Closure x1)>(&dss8NA_Entry, ds_Frees8NA);
                                    var sats8NM = new Updatable<Closure>(&sats8NM_Entry, dss8NA);
                                    var sat_Frees8NI = (dss8Ns, xs8Nv, dss8NA);
                                    var sats8NI = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8NI_Entry, sat_Frees8NI);
                                    return new GHC.Types.Cons(sats8NI, sats8NM);
                                }
                        }
                    }
            }
        }
        public static Closure sats8NI_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8NI)
        {
            var dss8Ns = sat_Frees8NI.x0;
            var xs8Nv = sat_Frees8NI.x1;
            var dss8NA = sat_Frees8NI.x2;
            var sats8NH = new Updatable<Closure>(&sats8NH_Entry, dss8NA);
            return dss8Ns.Apply<Closure, Closure, Closure>(xs8Nv, sats8NH);
        }
        public static Closure sats8NH_Entry(in Closure dss8NA)
        {
            var dss8NE = dss8NA.Eval();
            var dss8NE_Tuple2 = dss8NE as GHC.Tuple.Tuple2;
            var qss8NF = dss8NE_Tuple2.x0;
            var qs8NG = dss8NE_Tuple2.x1; return qs8NG.Eval();
        }
        public static Closure sats8NM_Entry(in Closure dss8NA)
        {
            var dss8NJ = dss8NA.Eval();
            var dss8NJ_Tuple2 = dss8NJ as GHC.Tuple.Tuple2;
            var qss8NK = dss8NJ_Tuple2.x0;
            var qs8NL = dss8NJ_Tuple2.x1; return qss8NK.Eval();
        }
        public static Closure dss8NA_Entry(in (Closure x0, Closure x1) ds_Frees8NA)
        {
            var dss8Ns = ds_Frees8NA.x0;
            var wilds8Nx = ds_Frees8NA.x1;
            var wilds8NB = scanr1_Entry(dss8Ns, wilds8Nx);
            switch (wilds8NB)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8NB_Nil: { return lvls8Nq.Eval(); }
                case GHC.Types.Cons wilds8NB_Cons:
                    {
                        var qs8NC = wilds8NB_Cons.x0;
                        var dss8ND = wilds8NB_Cons.x1;
                        return new GHC.Tuple.Tuple2(wilds8NB, qs8NC);
                    }
            }
        }
        public static Closure lvls8Nq_Entry()
        {
            throw new System.Exception(lvls8Np);
        }
        public static Closure iterate_Entry(Closure ws8Nk, Closure ws8Nl)
        {
            var wws8Nm = witerates8N3_Entry(ws8Nk, ws8Nl);
            var wws8Nm_RawTuple = wws8Nm;
            var wws8Nn = wws8Nm_RawTuple.x0;
            var wws8No = wws8Nm_RawTuple.x1;
            return new GHC.Types.Cons(wws8Nn, wws8No);
        }
        public static Closure iterateFB_Entry(Closure cs8Nd, Closure fs8Ne, Closure x0s8Nf)
        {
            var go_Frees8Ng = (cs8Nd, fs8Ne, (Closure)null);
            var gos8Ng = new Fun1<(Closure x0, Closure x1, Closure x2), Closure, Closure>(&gos8Ng_Entry, go_Frees8Ng);
            gos8Ng.free.x2 = gos8Ng;
            return gos8Ng.Apply<Closure, Closure>(x0s8Nf);
        }
        public static Closure gos8Ng_Entry(in (Closure x0, Closure x1, Closure x2) go_Frees8Ng, Closure xs8Nh)
        {
            var cs8Nd = go_Frees8Ng.x0;
            var fs8Ne = go_Frees8Ng.x1;
            var gos8Ng = go_Frees8Ng.x2;
            var sat_Frees8Nj = (fs8Ne, gos8Ng, xs8Nh);
            var sats8Nj = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Nj_Entry, sat_Frees8Nj);
            return cs8Nd.Apply<Closure, Closure, Closure>(xs8Nh, sats8Nj);
        }
        public static Closure sats8Nj_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Nj)
        {
            var fs8Ne = sat_Frees8Nj.x0;
            var gos8Ng = sat_Frees8Nj.x1;
            var xs8Nh = sat_Frees8Nj.x2;
            var sat_Frees8Ni = (fs8Ne, xs8Nh);
            var sats8Ni = new Updatable<(Closure x0, Closure x1)>(&sats8Ni_Entry, sat_Frees8Ni);
            return gos8Ng.Apply<Closure, Closure>(sats8Ni);
        }
        public static Closure sats8Ni_Entry(in (Closure x0, Closure x1) sat_Frees8Ni)
        {
            var fs8Ne = sat_Frees8Ni.x0;
            var xs8Nh = sat_Frees8Ni.x1;
            return fs8Ne.Apply<Closure, Closure>(xs8Nh);
        }
        public static (Closure x0, Closure x1) witerates8N3_Entry(Closure ws8N4, Closure ws8N5)
        {
            var sat_Frees8Na = (ws8N4, ws8N5);
            var sats8Na = new Updatable<(Closure x0, Closure x1)>(&sats8Na_Entry, sat_Frees8Na);
            return (ws8N5, sats8Na);
        }
        public static Closure sats8Na_Entry(in (Closure x0, Closure x1) sat_Frees8Na)
        {
            var ws8N4 = sat_Frees8Na.x0;
            var ws8N5 = sat_Frees8Na.x1;
            var sat_Frees8N6 = (ws8N4, ws8N5);
            var sats8N6 = new Updatable<(Closure x0, Closure x1)>(&sats8N6_Entry, sat_Frees8N6);
            var wws8N7 = witerates8N3_Entry(ws8N4, sats8N6);
            var wws8N7_RawTuple = wws8N7;
            var wws8N8 = wws8N7_RawTuple.x0;
            var wws8N9 = wws8N7_RawTuple.x1;
            return new GHC.Types.Cons(wws8N8, wws8N9);
        }
        public static Closure sats8N6_Entry(in (Closure x0, Closure x1) sat_Frees8N6)
        {
            var ws8N4 = sat_Frees8N6.x0;
            var ws8N5 = sat_Frees8N6.x1;
            return ws8N4.Apply<Closure, Closure>(ws8N5);
        }
        public static Closure iterate__Entry(Closure ws8MY, Closure ws8MZ)
        {
            var wws8N0 = witerate_s8MH_Entry(ws8MY, ws8MZ);
            var wws8N0_RawTuple = wws8N0;
            var wws8N1 = wws8N0_RawTuple.x0;
            var wws8N2 = wws8N0_RawTuple.x1;
            return new GHC.Types.Cons(wws8N1, wws8N2);
        }
        public static Closure iterate_FB_Entry(Closure cs8MR, Closure fs8MS, Closure x0s8MT)
        {
            var go_Frees8MU = (cs8MR, fs8MS, (Closure)null);
            var gos8MU = new Fun1<(Closure x0, Closure x1, Closure x2), Closure, Closure>(&gos8MU_Entry, go_Frees8MU);
            gos8MU.free.x2 = gos8MU;
            return gos8MU.Apply<Closure, Closure>(x0s8MT);
        }
        public static Closure gos8MU_Entry(in (Closure x0, Closure x1, Closure x2) go_Frees8MU, Closure xs8MV)
        {
            var cs8MR = go_Frees8MU.x0;
            var fs8MS = go_Frees8MU.x1;
            var gos8MU = go_Frees8MU.x2;
            var x_s8MW = fs8MS.Apply<Closure, Closure>(xs8MV);
            var sat_Frees8MX = (gos8MU, x_s8MW);
            var sats8MX = new Updatable<(Closure x0, Closure x1)>(&sats8MX_Entry, sat_Frees8MX);
            return cs8MR.Apply<Closure, Closure, Closure>(xs8MV, sats8MX);
        }
        public static Closure sats8MX_Entry(in (Closure x0, Closure x1) sat_Frees8MX)
        {
            var gos8MU = sat_Frees8MX.x0;
            var x_s8MW = sat_Frees8MX.x1;
            return gos8MU.Apply<Closure, Closure>(x_s8MW);
        }
        public static (Closure x0, Closure x1) witerate_s8MH_Entry(Closure ws8MI, Closure ws8MJ)
        {
            var x_s8MK = ws8MI.Apply<Closure, Closure>(ws8MJ);
            var sat_Frees8MO = (ws8MI, x_s8MK);
            var sats8MO = new Updatable<(Closure x0, Closure x1)>(&sats8MO_Entry, sat_Frees8MO);
            return (ws8MJ, sats8MO);
        }
        public static Closure sats8MO_Entry(in (Closure x0, Closure x1) sat_Frees8MO)
        {
            var ws8MI = sat_Frees8MO.x0;
            var x_s8MK = sat_Frees8MO.x1;
            var wws8ML = witerate_s8MH_Entry(ws8MI, x_s8MK);
            var wws8ML_RawTuple = wws8ML;
            var wws8MM = wws8ML_RawTuple.x0;
            var wws8MN = wws8ML_RawTuple.x1;
            return new GHC.Types.Cons(wws8MM, wws8MN);
        }
        public static Closure replicate_Entry(Closure ns8Mw, Closure xs8Mx)
        {
            var wild1s8My = ns8Mw.Eval();
            var wild1s8My_IHash = wild1s8My as GHC.Types.IHash;
            var ys8Mz = wild1s8My_IHash.x0;
            var lwilds8MA = (0 < ys8Mz) ? 1 : 0;
            switch (lwilds8MA)
            {
                default: { return GHC.Types.nil_DataCon.Eval(); }
                case 1:
                    {
                        var lvls8MB = new GHC.Types.Cons(xs8Mx, GHC.Types.nil_DataCon);
                        var wxs_Frees8MC = (xs8Mx, lvls8MB, (Closure)null);
                        var wxss8MC = new Fun1<(Closure x0, Closure x1, Closure x2), long, Closure>(&wxss8MC_Entry, wxs_Frees8MC);
                        wxss8MC.free.x2 = wxss8MC;
                        return wxss8MC.Apply<long, Closure>(ys8Mz);
                    }
            }
        }
        public static Closure wxss8MC_Entry(in (Closure x0, Closure x1, Closure x2) wxs_Frees8MC, long wws8MD)
        {
            var xs8Mx = wxs_Frees8MC.x0;
            var lvls8MB = wxs_Frees8MC.x1;
            var wxss8MC = wxs_Frees8MC.x2;
            var dss8ME = wws8MD;
            switch (dss8ME)
            {
                default:
                    {
                        var sat_Frees8MG = (wxss8MC, dss8ME);
                        var sats8MG = new Updatable<(Closure x0, long x1)>(&sats8MG_Entry, sat_Frees8MG);
                        return new GHC.Types.Cons(xs8Mx, sats8MG);
                    }
                case 1: { return lvls8MB.Eval(); }
            }
        }
        public static Closure sats8MG_Entry(in (Closure x0, long x1) sat_Frees8MG)
        {
            var wxss8MC = sat_Frees8MG.x0;
            var dss8ME = sat_Frees8MG.x1;
            var sats8MF = dss8ME - 1;
            return wxss8MC.Apply<long, Closure>(sats8MF);
        }
        public static Closure repeatFB_Entry(Closure cs8Ms, Closure xs8Mt)
        {
            var xs_Frees8Mu = (cs8Ms, xs8Mt, (Closure)null);
            var xss8Mu = new Updatable<(Closure x0, Closure x1, Closure x2)>(&xss8Mu_Entry, xs_Frees8Mu);
            xss8Mu.free.x2 = xss8Mu; return xss8Mu.Eval();
        }
        public static Closure xss8Mu_Entry(in (Closure x0, Closure x1, Closure x2) xs_Frees8Mu)
        {
            var cs8Ms = xs_Frees8Mu.x0;
            var xs8Mt = xs_Frees8Mu.x1;
            var xss8Mu = xs_Frees8Mu.x2;
            return cs8Ms.Apply<Closure, Closure, Closure>(xs8Mt, xss8Mu);
        }
        public static Closure repeat_Entry(Closure xs8Mq)
        {
            var xss8Mr = new GHC.Types.Cons(xs8Mq, (Closure)null);
            xss8Mr.x1 = xss8Mr; return xss8Mr.Eval();
        }
        public static Closure takeWhile_Entry(Closure dss8Mh, Closure dss8Mi)
        {
            var wilds8Mj = dss8Mi.Eval();
            switch (wilds8Mj)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Mj_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Mj_Cons:
                    {
                        var xs8Mk = wilds8Mj_Cons.x0;
                        var xss8Ml = wilds8Mj_Cons.x1;
                        var wilds8Mm = dss8Mh.Apply<Closure, Closure>(xs8Mk);
                        var wilds8MmTags8Mm = wilds8Mm.Tag;
                        switch (wilds8MmTags8Mm)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8Mm_False = wilds8Mm as GHC.Types.False;
                                    return GHC.Types.nil_DataCon.Eval();
                                }
                            case 2:
                                {
                                    var wilds8Mm_True = wilds8Mm as GHC.Types.True;
                                    var sat_Frees8Mn = (dss8Mh, xss8Ml);
                                    var sats8Mn = new Updatable<(Closure x0, Closure x1)>(&sats8Mn_Entry, sat_Frees8Mn);
                                    return new GHC.Types.Cons(xs8Mk, sats8Mn);
                                }
                        }
                    }
            }
        }
        public static Closure sats8Mn_Entry(in (Closure x0, Closure x1) sat_Frees8Mn)
        {
            var dss8Mh = sat_Frees8Mn.x0;
            var xss8Ml = sat_Frees8Mn.x1;
            return takeWhile_Entry(dss8Mh, xss8Ml);
        }
        public static Closure takeWhileFB_Entry(Closure ps8Ma, Closure cs8Mb, Closure ns8Mc, Closure xs8Md, Closure rs8Me)
        {
            var wilds8Mf = ps8Ma.Apply<Closure, Closure>(xs8Md);
            var wilds8MfTags8Mf = wilds8Mf.Tag;
            switch (wilds8MfTags8Mf)
            {
                default: { throw new ImpossibleException(); }
                case 1:
                    {
                        var wilds8Mf_False = wilds8Mf as GHC.Types.False;
                        return ns8Mc.Eval();
                    }
                case 2:
                    {
                        var wilds8Mf_True = wilds8Mf as GHC.Types.True;
                        return cs8Mb.Apply<Closure, Closure, Closure>(xs8Md, rs8Me);
                    }
            }
        }
        public static Closure dropWhile_Entry(Closure dss8M3, Closure dss8M4)
        {
            var wilds8M5 = dss8M4.Eval();
            switch (wilds8M5)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8M5_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8M5_Cons:
                    {
                        var xs8M6 = wilds8M5_Cons.x0;
                        var xs_s8M7 = wilds8M5_Cons.x1;
                        var wilds8M8 = dss8M3.Apply<Closure, Closure>(xs8M6);
                        var wilds8M8Tags8M8 = wilds8M8.Tag;
                        switch (wilds8M8Tags8M8)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8M8_False = wilds8M8 as GHC.Types.False;
                                    return wilds8M5.Eval();
                                }
                            case 2:
                                {
                                    var wilds8M8_True = wilds8M8 as GHC.Types.True;
                                    return dropWhile_Entry(dss8M3, xs_s8M7);
                                }
                        }
                    }
            }
        }
        public static Closure take_Entry(Closure etas8LX, Closure etas8LY)
        {
            var wild1s8LZ = etas8LX.Eval();
            var wild1s8LZ_IHash = wild1s8LZ as GHC.Types.IHash;
            var ys8M0 = wild1s8LZ_IHash.x0;
            var lwilds8M1 = (0 < ys8M0) ? 1 : 0;
            switch (lwilds8M1)
            {
                default: { return GHC.Types.nil_DataCon.Eval(); }
                case 1: { return wunsafeTakes8LI_Entry(ys8M0, etas8LY); }
            }
        }
        public static Closure unsafeTake_Entry(Closure ws8LS, Closure ws8LT)
        {
            var wws8LU = ws8LS.Eval();
            var wws8LU_IHash = wws8LU as GHC.Types.IHash;
            var wws8LV = wws8LU_IHash.x0;
            return wunsafeTakes8LI_Entry(wws8LV, ws8LT);
        }
        public static Closure wunsafeTakes8LI_Entry(long wws8LJ, Closure ws8LK)
        {
            var wilds8LL = ws8LK.Eval();
            switch (wilds8LL)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8LL_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8LL_Cons:
                    {
                        var ipvs8LM = wilds8LL_Cons.x0;
                        var ipvs8LN = wilds8LL_Cons.x1;
                        var dss8LO = wws8LJ;
                        switch (dss8LO)
                        {
                            default:
                                {
                                    var sat_Frees8LQ = (ipvs8LN, dss8LO);
                                    var sats8LQ = new Updatable<(Closure x0, long x1)>(&sats8LQ_Entry, sat_Frees8LQ);
                                    return new GHC.Types.Cons(ipvs8LM, sats8LQ);
                                }
                            case 1:
                                {
                                    return new GHC.Types.Cons(ipvs8LM, GHC.Types.nil_DataCon);
                                }
                        }
                    }
            }
        }
        public static Closure sats8LQ_Entry(in (Closure x0, long x1) sat_Frees8LQ)
        {
            var ipvs8LN = sat_Frees8LQ.x0;
            var dss8LO = sat_Frees8LQ.x1;
            var sats8LP = dss8LO - 1;
            return wunsafeTakes8LI_Entry(sats8LP, ipvs8LN);
        }
        public static Closure flipSeqTake_Entry(Closure xs8LE, Closure _ns8LF)
        {
            var _ns8LG = _ns8LF.Eval();
            var _ns8LG_IHash = _ns8LG as GHC.Types.IHash;
            var ipvs8LH = _ns8LG_IHash.x0; return xs8LE.Eval();
        }
        public static Closure takeFB_Entry(Closure etas8Ls, Closure etas8Lt, Closure etas8Lu, Closure etas8Lv, Closure ms8Lw)
        {
            var wilds8Lx = ms8Lw.Eval();
            var wilds8Lx_IHash = wilds8Lx as GHC.Types.IHash;
            var dss8Ly = wilds8Lx_IHash.x0;
            var dss8Lz = dss8Ly;
            switch (dss8Lz)
            {
                default:
                    {
                        var sat_Frees8LC = (etas8Lv, dss8Lz);
                        var sats8LC = new Updatable<(Closure x0, long x1)>(&sats8LC_Entry, sat_Frees8LC);
                        return etas8Ls.Apply<Closure, Closure, Closure>(etas8Lu, sats8LC);
                    }
                case 1:
                    {
                        return etas8Ls.Apply<Closure, Closure, Closure>(etas8Lu, etas8Lt);
                    }
            }
        }
        public static Closure sats8LC_Entry(in (Closure x0, long x1) sat_Frees8LC)
        {
            var etas8Lv = sat_Frees8LC.x0;
            var dss8Lz = sat_Frees8LC.x1;
            var sats8LA = dss8Lz - 1;
            var sats8LB = new GHC.Types.IHash(sats8LA);
            return etas8Lv.Apply<Closure, Closure>(sats8LB);
        }
        public static Closure span_Entry(Closure ws8Lm, Closure ws8Ln)
        {
            var wws8Lo = wspans8L1_Entry(ws8Lm, ws8Ln);
            var wws8Lo_RawTuple = wws8Lo;
            var wws8Lp = wws8Lo_RawTuple.x0;
            var wws8Lq = wws8Lo_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8Lp, wws8Lq);
        }
        public static (Closure x0, Closure x1) wspans8L1_Entry(Closure ws8L2, Closure ws8L3)
        {
            var wilds8L4 = ws8L3.Eval();
            switch (wilds8L4)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8L4_Nil:
                    {
                        return (GHC.Types.nil_DataCon, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8L4_Cons:
                    {
                        var xs8L5 = wilds8L4_Cons.x0;
                        var xs_s8L6 = wilds8L4_Cons.x1;
                        var wilds8L7 = ws8L2.Apply<Closure, Closure>(xs8L5);
                        var wilds8L7Tags8L7 = wilds8L7.Tag;
                        switch (wilds8L7Tags8L7)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8L7_False = wilds8L7 as GHC.Types.False;
                                    return (GHC.Types.nil_DataCon, wilds8L4);
                                }
                            case 2:
                                {
                                    var wilds8L7_True = wilds8L7 as GHC.Types.True;
                                    var ds_Frees8L8 = (ws8L2, xs_s8L6);
                                    var dss8L8 = new Updatable<(Closure x0, Closure x1)>(&dss8L8_Entry, ds_Frees8L8);
                                    var sats8Lk = new Updatable<Closure>(&sats8Lk_Entry, dss8L8);
                                    var sats8Lf = new Updatable<Closure>(&sats8Lf_Entry, dss8L8);
                                    var sats8Lg = new GHC.Types.Cons(xs8L5, sats8Lf);
                                    return (sats8Lg, sats8Lk);
                                }
                        }
                    }
            }
        }
        public static Closure sats8Lf_Entry(in Closure dss8L8)
        {
            var wilds8Lc = dss8L8.Eval();
            var wilds8Lc_Tuple2 = wilds8Lc as GHC.Tuple.Tuple2;
            var yss8Ld = wilds8Lc_Tuple2.x0;
            var zss8Le = wilds8Lc_Tuple2.x1; return yss8Ld.Eval();
        }
        public static Closure sats8Lk_Entry(in Closure dss8L8)
        {
            var wilds8Lh = dss8L8.Eval();
            var wilds8Lh_Tuple2 = wilds8Lh as GHC.Tuple.Tuple2;
            var yss8Li = wilds8Lh_Tuple2.x0;
            var zss8Lj = wilds8Lh_Tuple2.x1; return zss8Lj.Eval();
        }
        public static Closure dss8L8_Entry(in (Closure x0, Closure x1) ds_Frees8L8)
        {
            var ws8L2 = ds_Frees8L8.x0;
            var xs_s8L6 = ds_Frees8L8.x1;
            var wws8L9 = wspans8L1_Entry(ws8L2, xs_s8L6);
            var wws8L9_RawTuple = wws8L9;
            var wws8La = wws8L9_RawTuple.x0;
            var wws8Lb = wws8L9_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8La, wws8Lb);
        }
        public static Closure @break_Entry(Closure ws8KW, Closure ws8KX)
        {
            var wws8KY = wbreaks8KB_Entry(ws8KW, ws8KX);
            var wws8KY_RawTuple = wws8KY;
            var wws8KZ = wws8KY_RawTuple.x0;
            var wws8L0 = wws8KY_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8KZ, wws8L0);
        }
        public static (Closure x0, Closure x1) wbreaks8KB_Entry(Closure ws8KC, Closure ws8KD)
        {
            var wilds8KE = ws8KD.Eval();
            switch (wilds8KE)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8KE_Nil:
                    {
                        return (GHC.Types.nil_DataCon, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8KE_Cons:
                    {
                        var xs8KF = wilds8KE_Cons.x0;
                        var xs_s8KG = wilds8KE_Cons.x1;
                        var wilds8KH = ws8KC.Apply<Closure, Closure>(xs8KF);
                        var wilds8KHTags8KH = wilds8KH.Tag;
                        switch (wilds8KHTags8KH)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8KH_False = wilds8KH as GHC.Types.False;
                                    var ds_Frees8KI = (ws8KC, xs_s8KG);
                                    var dss8KI = new Updatable<(Closure x0, Closure x1)>(&dss8KI_Entry, ds_Frees8KI);
                                    var sats8KU = new Updatable<Closure>(&sats8KU_Entry, dss8KI);
                                    var sats8KP = new Updatable<Closure>(&sats8KP_Entry, dss8KI);
                                    var sats8KQ = new GHC.Types.Cons(xs8KF, sats8KP);
                                    return (sats8KQ, sats8KU);
                                }
                            case 2:
                                {
                                    var wilds8KH_True = wilds8KH as GHC.Types.True;
                                    return (GHC.Types.nil_DataCon, wilds8KE);
                                }
                        }
                    }
            }
        }
        public static Closure sats8KP_Entry(in Closure dss8KI)
        {
            var wilds8KM = dss8KI.Eval();
            var wilds8KM_Tuple2 = wilds8KM as GHC.Tuple.Tuple2;
            var yss8KN = wilds8KM_Tuple2.x0;
            var zss8KO = wilds8KM_Tuple2.x1; return yss8KN.Eval();
        }
        public static Closure sats8KU_Entry(in Closure dss8KI)
        {
            var wilds8KR = dss8KI.Eval();
            var wilds8KR_Tuple2 = wilds8KR as GHC.Tuple.Tuple2;
            var yss8KS = wilds8KR_Tuple2.x0;
            var zss8KT = wilds8KR_Tuple2.x1; return zss8KT.Eval();
        }
        public static Closure dss8KI_Entry(in (Closure x0, Closure x1) ds_Frees8KI)
        {
            var ws8KC = ds_Frees8KI.x0;
            var xs_s8KG = ds_Frees8KI.x1;
            var wws8KJ = wbreaks8KB_Entry(ws8KC, xs_s8KG);
            var wws8KJ_RawTuple = wws8KJ;
            var wws8KK = wws8KJ_RawTuple.x0;
            var wws8KL = wws8KJ_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8KK, wws8KL);
        }
        public static Closure reverse_Entry(Closure ls8KA)
        {
            return poly_revs8Ks_Entry(ls8KA, GHC.Types.nil_DataCon);
        }
        public static Closure poly_revs8Ks_Entry(Closure dss8Kt, Closure as8Ku)
        {
            var wilds8Kv = dss8Kt.Eval();
            switch (wilds8Kv)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Kv_Nil: { return as8Ku.Eval(); }
                case GHC.Types.Cons wilds8Kv_Cons:
                    {
                        var xs8Kw = wilds8Kv_Cons.x0;
                        var xss8Kx = wilds8Kv_Cons.x1;
                        var sats8Ky = new GHC.Types.Cons(xs8Kw, as8Ku);
                        return poly_revs8Ks_Entry(xss8Kx, sats8Ky);
                    }
            }
        }
        public static Closure and_Entry(Closure dss8Kn)
        {
            var wilds8Ko = dss8Kn.Eval();
            switch (wilds8Ko)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ko_Nil:
                    {
                        return GHC.Types.true_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Ko_Cons:
                    {
                        var xs8Kp = wilds8Ko_Cons.x0;
                        var xss8Kq = wilds8Ko_Cons.x1;
                        var wilds8Kr = xs8Kp.Eval();
                        var wilds8KrTags8Kr = wilds8Kr.Tag;
                        switch (wilds8KrTags8Kr)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8Kr_False = wilds8Kr as GHC.Types.False;
                                    return GHC.Types.false_DataCon.Eval();
                                }
                            case 2:
                                {
                                    var wilds8Kr_True = wilds8Kr as GHC.Types.True;
                                    return and_Entry(xss8Kq);
                                }
                        }
                    }
            }
        }
        public static Closure or_Entry(Closure dss8Kh)
        {
            var wilds8Ki = dss8Kh.Eval();
            switch (wilds8Ki)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ki_Nil:
                    {
                        return GHC.Types.false_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Ki_Cons:
                    {
                        var xs8Kj = wilds8Ki_Cons.x0;
                        var xss8Kk = wilds8Ki_Cons.x1;
                        var wilds8Kl = xs8Kj.Eval();
                        var wilds8KlTags8Kl = wilds8Kl.Tag;
                        switch (wilds8KlTags8Kl)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8Kl_False = wilds8Kl as GHC.Types.False;
                                    return or_Entry(xss8Kk);
                                }
                            case 2:
                                {
                                    var wilds8Kl_True = wilds8Kl as GHC.Types.True;
                                    return GHC.Types.true_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure any_Entry(Closure dss8Ka, Closure dss8Kb)
        {
            var wilds8Kc = dss8Kb.Eval();
            switch (wilds8Kc)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Kc_Nil:
                    {
                        return GHC.Types.false_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Kc_Cons:
                    {
                        var xs8Kd = wilds8Kc_Cons.x0;
                        var xss8Ke = wilds8Kc_Cons.x1;
                        var wilds8Kf = dss8Ka.Apply<Closure, Closure>(xs8Kd);
                        var wilds8KfTags8Kf = wilds8Kf.Tag;
                        switch (wilds8KfTags8Kf)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8Kf_False = wilds8Kf as GHC.Types.False;
                                    return any_Entry(dss8Ka, xss8Ke);
                                }
                            case 2:
                                {
                                    var wilds8Kf_True = wilds8Kf as GHC.Types.True;
                                    return GHC.Types.true_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure all_Entry(Closure dss8K3, Closure dss8K4)
        {
            var wilds8K5 = dss8K4.Eval();
            switch (wilds8K5)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8K5_Nil:
                    {
                        return GHC.Types.true_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8K5_Cons:
                    {
                        var xs8K6 = wilds8K5_Cons.x0;
                        var xss8K7 = wilds8K5_Cons.x1;
                        var wilds8K8 = dss8K3.Apply<Closure, Closure>(xs8K6);
                        var wilds8K8Tags8K8 = wilds8K8.Tag;
                        switch (wilds8K8Tags8K8)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8K8_False = wilds8K8 as GHC.Types.False;
                                    return GHC.Types.false_DataCon.Eval();
                                }
                            case 2:
                                {
                                    var wilds8K8_True = wilds8K8 as GHC.Types.True;
                                    return all_Entry(dss8K3, xss8K7);
                                }
                        }
                    }
            }
        }
        public static Closure elem_Entry(Closure dEqs8JV, Closure dss8JW, Closure dss8JX)
        {
            var wilds8JY = dss8JX.Eval();
            switch (wilds8JY)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8JY_Nil:
                    {
                        return GHC.Types.false_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8JY_Cons:
                    {
                        var ys8JZ = wilds8JY_Cons.x0;
                        var yss8K0 = wilds8JY_Cons.x1;
                        var wilds8K1 = GHC.Classes.eqEq_Entry(dEqs8JV).Apply<Closure, Closure, Closure>(dss8JW, ys8JZ);
                        var wilds8K1Tags8K1 = wilds8K1.Tag;
                        switch (wilds8K1Tags8K1)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8K1_False = wilds8K1 as GHC.Types.False;
                                    return elem_Entry(dEqs8JV, dss8JW, yss8K0);
                                }
                            case 2:
                                {
                                    var wilds8K1_True = wilds8K1 as GHC.Types.True;
                                    return GHC.Types.true_DataCon.Eval();
                                }
                        }
                    }
            }
        }
        public static Closure notElem_Entry(Closure dEqs8JN, Closure dss8JO, Closure dss8JP)
        {
            var wilds8JQ = dss8JP.Eval();
            switch (wilds8JQ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8JQ_Nil:
                    {
                        return GHC.Types.true_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8JQ_Cons:
                    {
                        var ys8JR = wilds8JQ_Cons.x0;
                        var yss8JS = wilds8JQ_Cons.x1;
                        var wilds8JT = GHC.Classes.slshEq_Entry(dEqs8JN).Apply<Closure, Closure, Closure>(dss8JO, ys8JR);
                        var wilds8JTTags8JT = wilds8JT.Tag;
                        switch (wilds8JTTags8JT)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8JT_False = wilds8JT as GHC.Types.False;
                                    return GHC.Types.false_DataCon.Eval();
                                }
                            case 2:
                                {
                                    var wilds8JT_True = wilds8JT as GHC.Types.True;
                                    return notElem_Entry(dEqs8JN, dss8JO, yss8JS);
                                }
                        }
                    }
            }
        }
        public static Closure lookup_Entry(Closure dEqs8JC, Closure _keys8JD, Closure dss8JE)
        {
            var wilds8JF = dss8JE.Eval();
            switch (wilds8JF)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8JF_Nil:
                    {
                        return GHC.Maybe.nothing_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8JF_Cons:
                    {
                        var dss8JG = wilds8JF_Cons.x0;
                        var xyss8JH = wilds8JF_Cons.x1;
                        var wilds8JI = dss8JG.Eval();
                        var wilds8JI_Tuple2 = wilds8JI as GHC.Tuple.Tuple2;
                        var xs8JJ = wilds8JI_Tuple2.x0;
                        var ys8JK = wilds8JI_Tuple2.x1;
                        var wilds8JL = GHC.Classes.eqEq_Entry(dEqs8JC).Apply<Closure, Closure, Closure>(_keys8JD, xs8JJ);
                        var wilds8JLTags8JL = wilds8JL.Tag;
                        switch (wilds8JLTags8JL)
                        {
                            default: { throw new ImpossibleException(); }
                            case 1:
                                {
                                    var wilds8JL_False = wilds8JL as GHC.Types.False;
                                    return lookup_Entry(dEqs8JC, _keys8JD, xyss8JH);
                                }
                            case 2:
                                {
                                    var wilds8JL_True = wilds8JL as GHC.Types.True;
                                    return new GHC.Maybe.Just(ys8JK);
                                }
                        }
                    }
            }
        }
        public static Closure concatMap_Entry(Closure fs8Js, Closure etas8Jt)
        {
            var go_Frees8Ju = (fs8Js, (Closure)null);
            var gos8Ju = new Fun1<(Closure x0, Closure x1), Closure, Closure>(&gos8Ju_Entry, go_Frees8Ju);
            gos8Ju.free.x1 = gos8Ju;
            return gos8Ju.Apply<Closure, Closure>(etas8Jt);
        }
        public static Closure gos8Ju_Entry(in (Closure x0, Closure x1) go_Frees8Ju, Closure dss8Jv)
        {
            var fs8Js = go_Frees8Ju.x0;
            var gos8Ju = go_Frees8Ju.x1;
            var wilds8Jw = dss8Jv.Eval();
            switch (wilds8Jw)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Jw_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Jw_Cons:
                    {
                        var ys8Jx = wilds8Jw_Cons.x0;
                        var yss8Jy = wilds8Jw_Cons.x1;
                        var sat_Frees8JA = (gos8Ju, yss8Jy);
                        var sats8JA = new SingleEntry<(Closure x0, Closure x1)>(&sats8JA_Entry, sat_Frees8JA);
                        var sats8Jz = fs8Js.Apply<Closure, Closure>(ys8Jx);
                        return GHC.Base.plusPlus_Entry(sats8Jz, sats8JA);
                    }
            }
        }
        public static Closure sats8JA_Entry(in (Closure x0, Closure x1) sat_Frees8JA)
        {
            var gos8Ju = sat_Frees8JA.x0;
            var yss8Jy = sat_Frees8JA.x1;
            return gos8Ju.Apply<Closure, Closure>(yss8Jy);
        }
        public static Closure concat_Entry(Closure etaB1)
        {
            return gos8Jk_Entry(etaB1);
        }
        public static Closure gos8Jk_Entry(Closure dss8Jl)
        {
            var wilds8Jm = dss8Jl.Eval();
            switch (wilds8Jm)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Jm_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Jm_Cons:
                    {
                        var ys8Jn = wilds8Jm_Cons.x0;
                        var yss8Jo = wilds8Jm_Cons.x1;
                        var sats8Jp = new SingleEntry<Closure>(&sats8Jp_Entry, yss8Jo);
                        return GHC.Base.plusPlus_Entry(ys8Jn, sats8Jp);
                    }
            }
        }
        public static Closure sats8Jp_Entry(in Closure yss8Jo)
        {
            return gos8Jk_Entry(yss8Jo);
        }
        public static Closure foldr2_Entry(Closure ks8J6, Closure zs8J7, Closure etas8J8, Closure etas8J9)
        {
            var go_Frees8Ja = (ks8J6, zs8J7, (Closure)null);
            var gos8Ja = new Fun2<(Closure x0, Closure x1, Closure x2), Closure, Closure, Closure>(&gos8Ja_Entry, go_Frees8Ja);
            gos8Ja.free.x2 = gos8Ja;
            return gos8Ja.Apply<Closure, Closure, Closure>(etas8J8, etas8J9);
        }
        public static Closure gos8Ja_Entry(in (Closure x0, Closure x1, Closure x2) go_Frees8Ja, Closure dss8Jb, Closure _yss8Jc)
        {
            var ks8J6 = go_Frees8Ja.x0;
            var zs8J7 = go_Frees8Ja.x1;
            var gos8Ja = go_Frees8Ja.x2;
            var wilds8Jd = dss8Jb.Eval();
            switch (wilds8Jd)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Jd_Nil: { return zs8J7.Eval(); }
                case GHC.Types.Cons wilds8Jd_Cons:
                    {
                        var ipvs8Je = wilds8Jd_Cons.x0;
                        var ipvs8Jf = wilds8Jd_Cons.x1;
                        var wilds8Jg = _yss8Jc.Eval();
                        switch (wilds8Jg)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8Jg_Nil: { return zs8J7.Eval(); }
                            case GHC.Types.Cons wilds8Jg_Cons:
                                {
                                    var ipvs8Jh = wilds8Jg_Cons.x0;
                                    var ipvs8Ji = wilds8Jg_Cons.x1;
                                    var sat_Frees8Jj = (gos8Ja, ipvs8Jf, ipvs8Ji);
                                    var sats8Jj = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Jj_Entry, sat_Frees8Jj);
                                    return ks8J6.Apply<Closure, Closure, Closure, Closure>(ipvs8Je, ipvs8Jh, sats8Jj);
                                }
                        }
                    }
            }
        }
        public static Closure sats8Jj_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Jj)
        {
            var gos8Ja = sat_Frees8Jj.x0;
            var ipvs8Jf = sat_Frees8Jj.x1;
            var ipvs8Ji = sat_Frees8Jj.x2;
            return gos8Ja.Apply<Closure, Closure, Closure>(ipvs8Jf, ipvs8Ji);
        }
        public static Closure zipWith_Entry(Closure fs8IS, Closure etas8IT, Closure etas8IU)
        {
            var go_Frees8IV = (fs8IS, (Closure)null);
            var gos8IV = new Fun2<(Closure x0, Closure x1), Closure, Closure, Closure>(&gos8IV_Entry, go_Frees8IV);
            gos8IV.free.x1 = gos8IV;
            return gos8IV.Apply<Closure, Closure, Closure>(etas8IT, etas8IU);
        }
        public static Closure gos8IV_Entry(in (Closure x0, Closure x1) go_Frees8IV, Closure dss8IW, Closure dss8IX)
        {
            var fs8IS = go_Frees8IV.x0;
            var gos8IV = go_Frees8IV.x1;
            var wilds8IY = dss8IW.Eval();
            switch (wilds8IY)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8IY_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8IY_Cons:
                    {
                        var ipvs8IZ = wilds8IY_Cons.x0;
                        var ipvs8J0 = wilds8IY_Cons.x1;
                        var wilds8J1 = dss8IX.Eval();
                        switch (wilds8J1)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8J1_Nil:
                                {
                                    return GHC.Types.nil_DataCon.Eval();
                                }
                            case GHC.Types.Cons wilds8J1_Cons:
                                {
                                    var ipvs8J2 = wilds8J1_Cons.x0;
                                    var ipvs8J3 = wilds8J1_Cons.x1;
                                    var sat_Frees8J5 = (gos8IV, ipvs8J0, ipvs8J3);
                                    var sats8J5 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8J5_Entry, sat_Frees8J5);
                                    var sat_Frees8J4 = (fs8IS, ipvs8IZ, ipvs8J2);
                                    var sats8J4 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8J4_Entry, sat_Frees8J4);
                                    return new GHC.Types.Cons(sats8J4, sats8J5);
                                }
                        }
                    }
            }
        }
        public static Closure sats8J4_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8J4)
        {
            var fs8IS = sat_Frees8J4.x0;
            var ipvs8IZ = sat_Frees8J4.x1;
            var ipvs8J2 = sat_Frees8J4.x2;
            return fs8IS.Apply<Closure, Closure, Closure>(ipvs8IZ, ipvs8J2);
        }
        public static Closure sats8J5_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8J5)
        {
            var gos8IV = sat_Frees8J5.x0;
            var ipvs8J0 = sat_Frees8J5.x1;
            var ipvs8J3 = sat_Frees8J5.x2;
            return gos8IV.Apply<Closure, Closure, Closure>(ipvs8J0, ipvs8J3);
        }
        public static Closure zip_Entry(Closure dss8II, Closure _bss8IJ)
        {
            var wilds8IK = dss8II.Eval();
            switch (wilds8IK)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8IK_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8IK_Cons:
                    {
                        var ipvs8IL = wilds8IK_Cons.x0;
                        var ipvs8IM = wilds8IK_Cons.x1;
                        var wilds8IN = _bss8IJ.Eval();
                        switch (wilds8IN)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8IN_Nil:
                                {
                                    return GHC.Types.nil_DataCon.Eval();
                                }
                            case GHC.Types.Cons wilds8IN_Cons:
                                {
                                    var ipvs8IO = wilds8IN_Cons.x0;
                                    var ipvs8IP = wilds8IN_Cons.x1;
                                    var sat_Frees8IR = (ipvs8IM, ipvs8IP);
                                    var sats8IR = new Updatable<(Closure x0, Closure x1)>(&sats8IR_Entry, sat_Frees8IR);
                                    var sats8IQ = new GHC.Tuple.Tuple2(ipvs8IL, ipvs8IO);
                                    return new GHC.Types.Cons(sats8IQ, sats8IR);
                                }
                        }
                    }
            }
        }
        public static Closure sats8IR_Entry(in (Closure x0, Closure x1) sat_Frees8IR)
        {
            var ipvs8IM = sat_Frees8IR.x0;
            var ipvs8IP = sat_Frees8IR.x1;
            return zip_Entry(ipvs8IM, ipvs8IP);
        }
        public static Closure foldr2_left_Entry(Closure _ks8Iw, Closure zs8Ix, Closure _xs8Iy, Closure _rs8Iz, Closure dss8IA)
        {
            var wilds8IB = dss8IA.Eval();
            switch (wilds8IB)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8IB_Nil: { return zs8Ix.Eval(); }
                case GHC.Types.Cons wilds8IB_Cons:
                    {
                        var ys8IC = wilds8IB_Cons.x0;
                        var yss8ID = wilds8IB_Cons.x1;
                        var sat_Frees8IE = (_rs8Iz, yss8ID);
                        var sats8IE = new Updatable<(Closure x0, Closure x1)>(&sats8IE_Entry, sat_Frees8IE);
                        return _ks8Iw.Apply<Closure, Closure, Closure, Closure>(_xs8Iy, ys8IC, sats8IE);
                    }
            }
        }
        public static Closure sats8IE_Entry(in (Closure x0, Closure x1) sat_Frees8IE)
        {
            var _rs8Iz = sat_Frees8IE.x0;
            var yss8ID = sat_Frees8IE.x1;
            return _rs8Iz.Apply<Closure, Closure>(yss8ID);
        }
        public static Closure zipFB_Entry(Closure cs8Iq, Closure xs8Ir, Closure ys8Is, Closure rs8It)
        {
            var sats8Iu = new GHC.Tuple.Tuple2(xs8Ir, ys8Is);
            return cs8Iq.Apply<Closure, Closure, Closure>(sats8Iu, rs8It);
        }
        public static Closure zip3_Entry(Closure dss8Ib, Closure dss8Ic, Closure dss8Id)
        {
            var wilds8Ie = dss8Ib.Eval();
            switch (wilds8Ie)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ie_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Ie_Cons:
                    {
                        var as8If = wilds8Ie_Cons.x0;
                        var ass8Ig = wilds8Ie_Cons.x1;
                        var wilds8Ih = dss8Ic.Eval();
                        switch (wilds8Ih)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8Ih_Nil:
                                {
                                    return GHC.Types.nil_DataCon.Eval();
                                }
                            case GHC.Types.Cons wilds8Ih_Cons:
                                {
                                    var bs8Ii = wilds8Ih_Cons.x0;
                                    var bss8Ij = wilds8Ih_Cons.x1;
                                    var wilds8Ik = dss8Id.Eval();
                                    switch (wilds8Ik)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Types.Nil wilds8Ik_Nil:
                                            {
                                                return GHC.Types.nil_DataCon.Eval();
                                            }
                                        case GHC.Types.Cons wilds8Ik_Cons:
                                            {
                                                var cs8Il = wilds8Ik_Cons.x0;
                                                var css8Im = wilds8Ik_Cons.x1;
                                                var sat_Frees8Io = (ass8Ig, bss8Ij, css8Im);
                                                var sats8Io = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Io_Entry, sat_Frees8Io);
                                                var sats8In = new GHC.Tuple.Tuple3(as8If, bs8Ii, cs8Il);
                                                return new GHC.Types.Cons(sats8In, sats8Io);
                                            }
                                    }
                                }
                        }
                    }
            }
        }
        public static Closure sats8Io_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Io)
        {
            var ass8Ig = sat_Frees8Io.x0;
            var bss8Ij = sat_Frees8Io.x1;
            var css8Im = sat_Frees8Io.x2;
            return zip3_Entry(ass8Ig, bss8Ij, css8Im);
        }
        public static Closure zipWithFB_Entry(Closure cs8I4, Closure fs8I5, Closure xs8I6, Closure ys8I7, Closure rs8I8)
        {
            var sat_Frees8I9 = (fs8I5, xs8I6, ys8I7);
            var sats8I9 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8I9_Entry, sat_Frees8I9);
            return cs8I4.Apply<Closure, Closure, Closure>(sats8I9, rs8I8);
        }
        public static Closure sats8I9_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8I9)
        {
            var fs8I5 = sat_Frees8I9.x0;
            var xs8I6 = sat_Frees8I9.x1;
            var ys8I7 = sat_Frees8I9.x2;
            return fs8I5.Apply<Closure, Closure, Closure>(xs8I6, ys8I7);
        }
        public static Closure zipWith3_Entry(Closure zs8HK, Closure etas8HL, Closure etas8HM, Closure etas8HN)
        {
            var go_Frees8HO = (zs8HK, (Closure)null);
            var gos8HO = new Fun3<(Closure x0, Closure x1), Closure, Closure, Closure, Closure>(&gos8HO_Entry, go_Frees8HO);
            gos8HO.free.x1 = gos8HO;
            return gos8HO.Apply<Closure, Closure, Closure, Closure>(etas8HL, etas8HM, etas8HN);
        }
        public static Closure gos8HO_Entry(in (Closure x0, Closure x1) go_Frees8HO, Closure dss8HP, Closure dss8HQ, Closure dss8HR)
        {
            var zs8HK = go_Frees8HO.x0;
            var gos8HO = go_Frees8HO.x1;
            var wilds8HS = dss8HP.Eval();
            switch (wilds8HS)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8HS_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8HS_Cons:
                    {
                        var as8HT = wilds8HS_Cons.x0;
                        var ass8HU = wilds8HS_Cons.x1;
                        var wilds8HV = dss8HQ.Eval();
                        switch (wilds8HV)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8HV_Nil:
                                {
                                    return GHC.Types.nil_DataCon.Eval();
                                }
                            case GHC.Types.Cons wilds8HV_Cons:
                                {
                                    var bs8HW = wilds8HV_Cons.x0;
                                    var bss8HX = wilds8HV_Cons.x1;
                                    var wilds8HY = dss8HR.Eval();
                                    switch (wilds8HY)
                                    {
                                        default: { throw new ImpossibleException(); }
                                        case GHC.Types.Nil wilds8HY_Nil:
                                            {
                                                return GHC.Types.nil_DataCon.Eval();
                                            }
                                        case GHC.Types.Cons wilds8HY_Cons:
                                            {
                                                var cs8HZ = wilds8HY_Cons.x0;
                                                var css8I0 = wilds8HY_Cons.x1;
                                                var sat_Frees8I2 = (gos8HO, ass8HU, bss8HX, css8I0);
                                                var sats8I2 = new Updatable<(Closure x0, Closure x1, Closure x2, Closure x3)>(&sats8I2_Entry, sat_Frees8I2);
                                                var sat_Frees8I1 = (zs8HK, as8HT, bs8HW, cs8HZ);
                                                var sats8I1 = new Updatable<(Closure x0, Closure x1, Closure x2, Closure x3)>(&sats8I1_Entry, sat_Frees8I1);
                                                return new GHC.Types.Cons(sats8I1, sats8I2);
                                            }
                                    }
                                }
                        }
                    }
            }
        }
        public static Closure sats8I1_Entry(in (Closure x0, Closure x1, Closure x2, Closure x3) sat_Frees8I1)
        {
            var zs8HK = sat_Frees8I1.x0;
            var as8HT = sat_Frees8I1.x1;
            var bs8HW = sat_Frees8I1.x2;
            var cs8HZ = sat_Frees8I1.x3;
            return zs8HK.Apply<Closure, Closure, Closure, Closure>(as8HT, bs8HW, cs8HZ);
        }
        public static Closure sats8I2_Entry(in (Closure x0, Closure x1, Closure x2, Closure x3) sat_Frees8I2)
        {
            var gos8HO = sat_Frees8I2.x0;
            var ass8HU = sat_Frees8I2.x1;
            var bss8HX = sat_Frees8I2.x2;
            var css8I0 = sat_Frees8I2.x3;
            return gos8HO.Apply<Closure, Closure, Closure, Closure>(ass8HU, bss8HX, css8I0);
        }
        public static Closure unzip_Entry(Closure etaB1)
        {
            return gos8HD_Entry(etaB1);
        }
        public static Closure gos8HD_Entry(Closure ws8HE)
        {
            var wws8HF = wgos8Hh_Entry(ws8HE);
            var wws8HF_RawTuple = wws8HF;
            var wws8HG = wws8HF_RawTuple.x0;
            var wws8HH = wws8HF_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8HG, wws8HH);
        }
        public static (Closure x0, Closure x1) wgos8Hh_Entry(Closure ws8Hi)
        {
            var wilds8Hj = ws8Hi.Eval();
            switch (wilds8Hj)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Hj_Nil:
                    {
                        return (GHC.Types.nil_DataCon, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8Hj_Cons:
                    {
                        var ys8Hk = wilds8Hj_Cons.x0;
                        var yss8Hl = wilds8Hj_Cons.x1;
                        var wilds8Hm = ys8Hk.Eval();
                        var wilds8Hm_Tuple2 = wilds8Hm as GHC.Tuple.Tuple2;
                        var as8Hn = wilds8Hm_Tuple2.x0;
                        var bs8Ho = wilds8Hm_Tuple2.x1;
                        var dss8Hp = new Updatable<Closure>(&dss8Hp_Entry, yss8Hl);
                        var sats8HB = new Updatable<Closure>(&sats8HB_Entry, dss8Hp);
                        var sats8HC = new GHC.Types.Cons(bs8Ho, sats8HB);
                        var sats8Hw = new Updatable<Closure>(&sats8Hw_Entry, dss8Hp);
                        var sats8Hx = new GHC.Types.Cons(as8Hn, sats8Hw);
                        return (sats8Hx, sats8HC);
                    }
            }
        }
        public static Closure sats8Hw_Entry(in Closure dss8Hp)
        {
            var wilds8Ht = dss8Hp.Eval();
            var wilds8Ht_Tuple2 = wilds8Ht as GHC.Tuple.Tuple2;
            var ass8Hu = wilds8Ht_Tuple2.x0;
            var bss8Hv = wilds8Ht_Tuple2.x1; return ass8Hu.Eval();
        }
        public static Closure sats8HB_Entry(in Closure dss8Hp)
        {
            var wilds8Hy = dss8Hp.Eval();
            var wilds8Hy_Tuple2 = wilds8Hy as GHC.Tuple.Tuple2;
            var ass8Hz = wilds8Hy_Tuple2.x0;
            var bss8HA = wilds8Hy_Tuple2.x1; return bss8HA.Eval();
        }
        public static Closure dss8Hp_Entry(in Closure yss8Hl)
        {
            var wws8Hq = wgos8Hh_Entry(yss8Hl);
            var wws8Hq_RawTuple = wws8Hq;
            var wws8Hr = wws8Hq_RawTuple.x0;
            var wws8Hs = wws8Hq_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8Hr, wws8Hs);
        }
        public static Closure unzip3_Entry(Closure etaB1)
        {
            return gos8Ha_Entry(etaB1);
        }
        public static Closure gos8Ha_Entry(Closure ws8Hb)
        {
            var wws8Hc = wgos8GE_Entry(ws8Hb);
            var wws8Hc_RawTuple = wws8Hc;
            var wws8Hd = wws8Hc_RawTuple.x0;
            var wws8He = wws8Hc_RawTuple.x1;
            var wws8Hf = wws8Hc_RawTuple.x2;
            return new GHC.Tuple.Tuple3(wws8Hd, wws8He, wws8Hf);
        }
        public static (Closure x0, Closure x1, Closure x2) wgos8GE_Entry(Closure ws8GF)
        {
            var wilds8GG = ws8GF.Eval();
            switch (wilds8GG)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8GG_Nil:
                    {
                        return (GHC.Types.nil_DataCon, GHC.Types.nil_DataCon, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8GG_Cons:
                    {
                        var ys8GH = wilds8GG_Cons.x0;
                        var yss8GI = wilds8GG_Cons.x1;
                        var wilds8GJ = ys8GH.Eval();
                        var wilds8GJ_Tuple3 = wilds8GJ as GHC.Tuple.Tuple3;
                        var as8GK = wilds8GJ_Tuple3.x0;
                        var bs8GL = wilds8GJ_Tuple3.x1;
                        var cs8GM = wilds8GJ_Tuple3.x2;
                        var dss8GN = new Updatable<Closure>(&dss8GN_Entry, yss8GI);
                        var sats8H8 = new Updatable<Closure>(&sats8H8_Entry, dss8GN);
                        var sats8H9 = new GHC.Types.Cons(cs8GM, sats8H8);
                        var sats8H2 = new Updatable<Closure>(&sats8H2_Entry, dss8GN);
                        var sats8H3 = new GHC.Types.Cons(bs8GL, sats8H2);
                        var sats8GW = new Updatable<Closure>(&sats8GW_Entry, dss8GN);
                        var sats8GX = new GHC.Types.Cons(as8GK, sats8GW);
                        return (sats8GX, sats8H3, sats8H9);
                    }
            }
        }
        public static Closure sats8GW_Entry(in Closure dss8GN)
        {
            var wilds8GS = dss8GN.Eval();
            var wilds8GS_Tuple3 = wilds8GS as GHC.Tuple.Tuple3;
            var ass8GT = wilds8GS_Tuple3.x0;
            var bss8GU = wilds8GS_Tuple3.x1;
            var css8GV = wilds8GS_Tuple3.x2; return ass8GT.Eval();
        }
        public static Closure sats8H2_Entry(in Closure dss8GN)
        {
            var wilds8GY = dss8GN.Eval();
            var wilds8GY_Tuple3 = wilds8GY as GHC.Tuple.Tuple3;
            var ass8GZ = wilds8GY_Tuple3.x0;
            var bss8H0 = wilds8GY_Tuple3.x1;
            var css8H1 = wilds8GY_Tuple3.x2; return bss8H0.Eval();
        }
        public static Closure sats8H8_Entry(in Closure dss8GN)
        {
            var wilds8H4 = dss8GN.Eval();
            var wilds8H4_Tuple3 = wilds8H4 as GHC.Tuple.Tuple3;
            var ass8H5 = wilds8H4_Tuple3.x0;
            var bss8H6 = wilds8H4_Tuple3.x1;
            var css8H7 = wilds8H4_Tuple3.x2; return css8H7.Eval();
        }
        public static Closure dss8GN_Entry(in Closure yss8GI)
        {
            var wws8GO = wgos8GE_Entry(yss8GI);
            var wws8GO_RawTuple = wws8GO;
            var wws8GP = wws8GO_RawTuple.x0;
            var wws8GQ = wws8GO_RawTuple.x1;
            var wws8GR = wws8GO_RawTuple.x2;
            return new GHC.Tuple.Tuple3(wws8GP, wws8GQ, wws8GR);
        }
        public static Closure lvls8GD_Entry()
        {
            return errorEmptyList_Entry(lvls8GC);
        }
        public static Closure lvls8GC_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8GB);
        }
        public static Closure lvls8GA_Entry()
        {
            return errorEmptyList_Entry(lvls8Gz);
        }
        public static Closure lvls8Gz_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8Gy);
        }
        public static Closure minimum_Entry(Closure dOrds8Gm, Closure dss8Gn)
        {
            var wilds8Go = dss8Gn.Eval();
            switch (wilds8Go)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Go_Nil: { return lvls8Fn.Eval(); }
                case GHC.Types.Cons wilds8Go_Cons:
                    {
                        var ipvs8Gp = wilds8Go_Cons.x0;
                        var ipvs8Gq = wilds8Go_Cons.x1;
                        var go_Frees8Gr = (dOrds8Gm, (Closure)null);
                        var gos8Gr = new Fun2<(Closure x0, Closure x1), Closure, Closure, Closure>(&gos8Gr_Entry, go_Frees8Gr);
                        gos8Gr.free.x1 = gos8Gr;
                        return gos8Gr.Apply<Closure, Closure, Closure>(ipvs8Gq, ipvs8Gp);
                    }
            }
        }
        public static Closure gos8Gr_Entry(in (Closure x0, Closure x1) go_Frees8Gr, Closure dss8Gs, Closure etas8Gt)
        {
            var dOrds8Gm = go_Frees8Gr.x0;
            var gos8Gr = go_Frees8Gr.x1;
            var wilds8Gu = dss8Gs.Eval();
            switch (wilds8Gu)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Gu_Nil: { return etas8Gt.Eval(); }
                case GHC.Types.Cons wilds8Gu_Cons:
                    {
                        var ys8Gv = wilds8Gu_Cons.x0;
                        var yss8Gw = wilds8Gu_Cons.x1;
                        var sat_Frees8Gx = (dOrds8Gm, etas8Gt, ys8Gv);
                        var sats8Gx = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8Gx_Entry, sat_Frees8Gx);
                        return gos8Gr.Apply<Closure, Closure, Closure>(yss8Gw, sats8Gx);
                    }
            }
        }
        public static Closure sats8Gx_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8Gx)
        {
            var dOrds8Gm = sat_Frees8Gx.x0;
            var etas8Gt = sat_Frees8Gx.x1;
            var ys8Gv = sat_Frees8Gx.x2;
            return GHC.Classes.min_Entry(dOrds8Gm).Apply<Closure, Closure, Closure>(etas8Gt, ys8Gv);
        }
        public static Closure sminimums8Gd_Entry(Closure ws8Ge)
        {
            var wilds8Gf = ws8Ge.Eval();
            switch (wilds8Gf)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Gf_Nil: { return lvls8Fm.Eval(); }
                case GHC.Types.Cons wilds8Gf_Cons:
                    {
                        var ipvs8Gg = wilds8Gf_Cons.x0;
                        var ipvs8Gh = wilds8Gf_Cons.x1;
                        var wws8Gi = ipvs8Gg.Eval();
                        var wws8Gi_IHash = wws8Gi as GHC.Types.IHash;
                        var wws8Gj = wws8Gi_IHash.x0;
                        var wws8Gk = wgos8G4_Entry(ipvs8Gh, wws8Gj);
                        return new GHC.Types.IHash(wws8Gk);
                    }
            }
        }
        public static long wgos8G4_Entry(Closure ws8G5, long wws8G6)
        {
            var wilds8G7 = ws8G5.Eval();
            switch (wilds8G7)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8G7_Nil: { return wws8G6; }
                case GHC.Types.Cons wilds8G7_Cons:
                    {
                        var ys8G8 = wilds8G7_Cons.x0;
                        var yss8G9 = wilds8G7_Cons.x1;
                        var wild1s8Ga = ys8G8.Eval();
                        var wild1s8Ga_IHash = wild1s8Ga as GHC.Types.IHash;
                        var y1s8Gb = wild1s8Ga_IHash.x0;
                        var lwilds8Gc = (wws8G6 <= y1s8Gb) ? 1 : 0;
                        switch (lwilds8Gc)
                        {
                            default: { return wgos8G4_Entry(yss8G9, y1s8Gb); }
                            case 1: { return wgos8G4_Entry(yss8G9, wws8G6); }
                        }
                    }
            }
        }
        public static Closure maximum_Entry(Closure dOrds8FS, Closure dss8FT)
        {
            var wilds8FU = dss8FT.Eval();
            switch (wilds8FU)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8FU_Nil: { return lvls8F6.Eval(); }
                case GHC.Types.Cons wilds8FU_Cons:
                    {
                        var ipvs8FV = wilds8FU_Cons.x0;
                        var ipvs8FW = wilds8FU_Cons.x1;
                        var go_Frees8FX = (dOrds8FS, (Closure)null);
                        var gos8FX = new Fun2<(Closure x0, Closure x1), Closure, Closure, Closure>(&gos8FX_Entry, go_Frees8FX);
                        gos8FX.free.x1 = gos8FX;
                        return gos8FX.Apply<Closure, Closure, Closure>(ipvs8FW, ipvs8FV);
                    }
            }
        }
        public static Closure gos8FX_Entry(in (Closure x0, Closure x1) go_Frees8FX, Closure dss8FY, Closure etas8FZ)
        {
            var dOrds8FS = go_Frees8FX.x0;
            var gos8FX = go_Frees8FX.x1;
            var wilds8G0 = dss8FY.Eval();
            switch (wilds8G0)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8G0_Nil: { return etas8FZ.Eval(); }
                case GHC.Types.Cons wilds8G0_Cons:
                    {
                        var ys8G1 = wilds8G0_Cons.x0;
                        var yss8G2 = wilds8G0_Cons.x1;
                        var sat_Frees8G3 = (dOrds8FS, etas8FZ, ys8G1);
                        var sats8G3 = new Updatable<(Closure x0, Closure x1, Closure x2)>(&sats8G3_Entry, sat_Frees8G3);
                        return gos8FX.Apply<Closure, Closure, Closure>(yss8G2, sats8G3);
                    }
            }
        }
        public static Closure sats8G3_Entry(in (Closure x0, Closure x1, Closure x2) sat_Frees8G3)
        {
            var dOrds8FS = sat_Frees8G3.x0;
            var etas8FZ = sat_Frees8G3.x1;
            var ys8G1 = sat_Frees8G3.x2;
            return GHC.Classes.max_Entry(dOrds8FS).Apply<Closure, Closure, Closure>(etas8FZ, ys8G1);
        }
        public static Closure smaximums8FJ_Entry(Closure ws8FK)
        {
            var wilds8FL = ws8FK.Eval();
            switch (wilds8FL)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8FL_Nil: { return lvls8F5.Eval(); }
                case GHC.Types.Cons wilds8FL_Cons:
                    {
                        var ipvs8FM = wilds8FL_Cons.x0;
                        var ipvs8FN = wilds8FL_Cons.x1;
                        var wws8FO = ipvs8FM.Eval();
                        var wws8FO_IHash = wws8FO as GHC.Types.IHash;
                        var wws8FP = wws8FO_IHash.x0;
                        var wws8FQ = wgos8FA_Entry(ipvs8FN, wws8FP);
                        return new GHC.Types.IHash(wws8FQ);
                    }
            }
        }
        public static long wgos8FA_Entry(Closure ws8FB, long wws8FC)
        {
            var wilds8FD = ws8FB.Eval();
            switch (wilds8FD)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8FD_Nil: { return wws8FC; }
                case GHC.Types.Cons wilds8FD_Cons:
                    {
                        var ys8FE = wilds8FD_Cons.x0;
                        var yss8FF = wilds8FD_Cons.x1;
                        var wild1s8FG = ys8FE.Eval();
                        var wild1s8FG_IHash = wild1s8FG as GHC.Types.IHash;
                        var y1s8FH = wild1s8FG_IHash.x0;
                        var lwilds8FI = (wws8FC <= y1s8FH) ? 1 : 0;
                        switch (lwilds8FI)
                        {
                            default: { return wgos8FA_Entry(yss8FF, wws8FC); }
                            case 1: { return wgos8FA_Entry(yss8FF, y1s8FH); }
                        }
                    }
            }
        }
        public static Closure sminimums8Fv_Entry(Closure dss8Fw)
        {
            var wilds8Fx = dss8Fw.Eval();
            switch (wilds8Fx)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Fx_Nil: { return lvls8Fl.Eval(); }
                case GHC.Types.Cons wilds8Fx_Cons:
                    {
                        var ipvs8Fy = wilds8Fx_Cons.x0;
                        var ipvs8Fz = wilds8Fx_Cons.x1;
                        return gos8Fo_Entry(ipvs8Fz, ipvs8Fy);
                    }
            }
        }
        public static Closure gos8Fo_Entry(Closure dss8Fp, Closure etas8Fq)
        {
            var wilds8Fr = dss8Fp.Eval();
            switch (wilds8Fr)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Fr_Nil: { return etas8Fq.Eval(); }
                case GHC.Types.Cons wilds8Fr_Cons:
                    {
                        var ys8Fs = wilds8Fr_Cons.x0;
                        var yss8Ft = wilds8Fr_Cons.x1;
                        var wilds8Fu = GHC.Integer.Type.leIntegerHash_Entry(etas8Fq, ys8Fs);
                        switch (wilds8Fu)
                        {
                            default: { return gos8Fo_Entry(yss8Ft, ys8Fs); }
                            case 1: { return gos8Fo_Entry(yss8Ft, etas8Fq); }
                        }
                    }
            }
        }
        public static Closure lvls8Fn_Entry()
        {
            return errorEmptyList_Entry(lvls8Fk);
        }
        public static Closure lvls8Fm_Entry()
        {
            return errorEmptyList_Entry(lvls8Fk);
        }
        public static Closure lvls8Fl_Entry()
        {
            return errorEmptyList_Entry(lvls8Fk);
        }
        public static Closure lvls8Fk_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8Fj);
        }
        public static Closure smaximums8Fe_Entry(Closure dss8Ff)
        {
            var wilds8Fg = dss8Ff.Eval();
            switch (wilds8Fg)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Fg_Nil: { return lvls8F4.Eval(); }
                case GHC.Types.Cons wilds8Fg_Cons:
                    {
                        var ipvs8Fh = wilds8Fg_Cons.x0;
                        var ipvs8Fi = wilds8Fg_Cons.x1;
                        return gos8F7_Entry(ipvs8Fi, ipvs8Fh);
                    }
            }
        }
        public static Closure gos8F7_Entry(Closure dss8F8, Closure etas8F9)
        {
            var wilds8Fa = dss8F8.Eval();
            switch (wilds8Fa)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Fa_Nil: { return etas8F9.Eval(); }
                case GHC.Types.Cons wilds8Fa_Cons:
                    {
                        var ys8Fb = wilds8Fa_Cons.x0;
                        var yss8Fc = wilds8Fa_Cons.x1;
                        var wilds8Fd = GHC.Integer.Type.leIntegerHash_Entry(etas8F9, ys8Fb);
                        switch (wilds8Fd)
                        {
                            default: { return gos8F7_Entry(yss8Fc, etas8F9); }
                            case 1: { return gos8F7_Entry(yss8Fc, ys8Fb); }
                        }
                    }
            }
        }
        public static Closure lvls8F6_Entry()
        {
            return errorEmptyList_Entry(lvls8F3);
        }
        public static Closure lvls8F5_Entry()
        {
            return errorEmptyList_Entry(lvls8F3);
        }
        public static Closure lvls8F4_Entry()
        {
            return errorEmptyList_Entry(lvls8F3);
        }
        public static Closure lvls8F3_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8F2);
        }
        public static Closure head_Entry(Closure dss8EY)
        {
            var wilds8EZ = dss8EY.Eval();
            switch (wilds8EZ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8EZ_Nil:
                    {
                        return GHC.List.badHead.Eval();
                    }
                case GHC.Types.Cons wilds8EZ_Cons:
                    {
                        var xs8F0 = wilds8EZ_Cons.x0;
                        var dss8F1 = wilds8EZ_Cons.x1; return xs8F0.Eval();
                    }
            }
        }
        public static Closure badHead_Entry()
        {
            return errorEmptyList_Entry(lvls8EV);
        }
        public static Closure lvls8EV_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8EU);
        }
        public static Closure tail_Entry(Closure dss8EQ)
        {
            var wilds8ER = dss8EQ.Eval();
            switch (wilds8ER)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8ER_Nil: { return lvls8EO.Eval(); }
                case GHC.Types.Cons wilds8ER_Cons:
                    {
                        var dss8ES = wilds8ER_Cons.x0;
                        var xss8ET = wilds8ER_Cons.x1; return xss8ET.Eval();
                    }
            }
        }
        public static Closure lvls8EO_Entry()
        {
            return errorEmptyList_Entry(lvls8EN);
        }
        public static Closure lvls8EN_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8EM);
        }
        public static Closure last_Entry(Closure xss8EL)
        {
            return poly_gos8EE_Entry(xss8EL, GHC.List.lastError);
        }
        public static Closure poly_gos8EE_Entry(Closure dss8EF, Closure etas8EG)
        {
            var wilds8EH = dss8EF.Eval();
            switch (wilds8EH)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8EH_Nil: { return etas8EG.Eval(); }
                case GHC.Types.Cons wilds8EH_Cons:
                    {
                        var ys8EI = wilds8EH_Cons.x0;
                        var yss8EJ = wilds8EH_Cons.x1;
                        return poly_gos8EE_Entry(yss8EJ, ys8EI);
                    }
            }
        }
        public static Closure lastError_Entry()
        {
            return errorEmptyList_Entry(lvls8EC);
        }
        public static Closure lvls8EC_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8EB);
        }
        public static Closure init_Entry(Closure dss8Ex)
        {
            var wilds8Ey = dss8Ex.Eval();
            switch (wilds8Ey)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ey_Nil: { return lvls8Ev.Eval(); }
                case GHC.Types.Cons wilds8Ey_Cons:
                    {
                        var xs8Ez = wilds8Ey_Cons.x0;
                        var xss8EA = wilds8Ey_Cons.x1;
                        return poly_init_s8Dp_Entry(xs8Ez, xss8EA);
                    }
            }
        }
        public static Closure lvls8Ev_Entry()
        {
            return errorEmptyList_Entry(lvls8Eu);
        }
        public static Closure lvls8Eu_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8Et);
        }
        public static Closure foldr1_Entry(Closure fs8Ei, Closure etas8Ej)
        {
            var go_Frees8Ek = (fs8Ei, (Closure)null);
            var gos8Ek = new Fun1<(Closure x0, Closure x1), Closure, Closure>(&gos8Ek_Entry, go_Frees8Ek);
            gos8Ek.free.x1 = gos8Ek;
            return gos8Ek.Apply<Closure, Closure>(etas8Ej);
        }
        public static Closure gos8Ek_Entry(in (Closure x0, Closure x1) go_Frees8Ek, Closure dss8El)
        {
            var fs8Ei = go_Frees8Ek.x0;
            var gos8Ek = go_Frees8Ek.x1;
            var wilds8Em = dss8El.Eval();
            switch (wilds8Em)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Em_Nil: { return lvls8Eg.Eval(); }
                case GHC.Types.Cons wilds8Em_Cons:
                    {
                        var xs8En = wilds8Em_Cons.x0;
                        var dss8Eo = wilds8Em_Cons.x1;
                        var wilds8Ep = dss8Eo.Eval();
                        switch (wilds8Ep)
                        {
                            default: { throw new ImpossibleException(); }
                            case GHC.Types.Nil wilds8Ep_Nil: { return xs8En.Eval(); }
                            case GHC.Types.Cons wilds8Ep_Cons:
                                {
                                    var ipvs8Eq = wilds8Ep_Cons.x0;
                                    var ipvs8Er = wilds8Ep_Cons.x1;
                                    var sat_Frees8Es = (gos8Ek, wilds8Ep);
                                    var sats8Es = new Updatable<(Closure x0, Closure x1)>(&sats8Es_Entry, sat_Frees8Es);
                                    return fs8Ei.Apply<Closure, Closure, Closure>(xs8En, sats8Es);
                                }
                        }
                    }
            }
        }
        public static Closure sats8Es_Entry(in (Closure x0, Closure x1) sat_Frees8Es)
        {
            var gos8Ek = sat_Frees8Es.x0;
            var wilds8Ep = sat_Frees8Es.x1;
            return gos8Ek.Apply<Closure, Closure>(wilds8Ep);
        }
        public static Closure lvls8Eg_Entry()
        {
            return errorEmptyList_Entry(lvls8Ef);
        }
        public static Closure lvls8Ef_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8Ee);
        }
        public static Closure cycle_Entry(Closure dss8E9)
        {
            var wilds8Ea = dss8E9.Eval();
            switch (wilds8Ea)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ea_Nil: { return lvls8E7.Eval(); }
                case GHC.Types.Cons wilds8Ea_Cons:
                    {
                        var ipvs8Eb = wilds8Ea_Cons.x0;
                        var ipvs8Ec = wilds8Ea_Cons.x1;
                        var xs__Frees8Ed = (ipvs8Eb, ipvs8Ec, (Closure)null);
                        var xs_s8Ed = new Updatable<(Closure x0, Closure x1, Closure x2)>(&xs_s8Ed_Entry, xs__Frees8Ed);
                        xs_s8Ed.free.x2 = xs_s8Ed; return xs_s8Ed.Eval();
                    }
            }
        }
        public static Closure xs_s8Ed_Entry(in (Closure x0, Closure x1, Closure x2) xs__Frees8Ed)
        {
            var ipvs8Eb = xs__Frees8Ed.x0;
            var ipvs8Ec = xs__Frees8Ed.x1;
            var xs_s8Ed = xs__Frees8Ed.x2;
            return GHC.Base.plusPlus_DollsPlusPlus_Entry(xs_s8Ed, ipvs8Eb, ipvs8Ec);
        }
        public static Closure lvls8E7_Entry()
        {
            return errorEmptyList_Entry(lvls8E6);
        }
        public static Closure lvls8E6_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8E5);
        }
        public static Closure bangBang_Entry(Closure ws8E1, Closure ws8E2)
        {
            var wws8E3 = ws8E2.Eval();
            var wws8E3_IHash = wws8E3 as GHC.Types.IHash;
            var wws8E4 = wws8E3_IHash.x0;
            return wBangBangs8DW_Entry(ws8E1, wws8E4);
        }
        public static Closure wBangBangs8DW_Entry(Closure ws8DX, long wws8DY)
        {
            var lwilds8DZ = (wws8DY < 0) ? 1 : 0;
            switch (lwilds8DZ)
            {
                default: { return poly_Dollwgos8DO_Entry(ws8DX, wws8DY); }
                case 1: { return GHC.List.negIndex.Eval(); }
            }
        }
        public static Closure poly_Dollwgos8DO_Entry(Closure ws8DP, long wws8DQ)
        {
            var wilds8DR = ws8DP.Eval();
            switch (wilds8DR)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8DR_Nil: { return poly_exits8DN.Eval(); }
                case GHC.Types.Cons wilds8DR_Cons:
                    {
                        var ys8DS = wilds8DR_Cons.x0;
                        var yss8DT = wilds8DR_Cons.x1;
                        var dss8DU = wws8DQ;
                        switch (dss8DU)
                        {
                            default:
                                {
                                    var sats8DV = dss8DU - 1;
                                    return poly_Dollwgos8DO_Entry(yss8DT, sats8DV);
                                }
                            case 0: { return ys8DS.Eval(); }
                        }
                    }
            }
        }
        public static Closure poly_exits8DN_Entry()
        {
            return GHC.Err.errorWithoutStackTrace_Entry<Closure>(lvls8DK);
        }
        public static Closure tooLarge_Entry(Closure dss8DM)
        {
            return GHC.Err.errorWithoutStackTrace_Entry<Closure>(lvls8DK);
        }
        public static Closure lvls8DK_Entry()
        {
            return GHC.Base.plusPlus_Entry(GHC.List.prel_list_str, lvls8DJ);
        }
        public static Closure lvls8DJ_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8DI);
        }
        public static Closure negIndex_Entry()
        {
            var sats8DH = GHC.Base.plusPlus_Entry(GHC.List.prel_list_str, lvls8DF);
            return GHC.Err.errorWithoutStackTrace_Entry<Closure>(sats8DH);
        }
        public static Closure lvls8DF_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8DE);
        }
        public static Closure errorEmptyList_Entry(Closure funs8DB)
        {
            var sats8DC = new SingleEntry<Closure>(&sats8DC_Entry, funs8DB);
            var sats8DD = GHC.Base.plusPlus_Entry(GHC.List.prel_list_str, sats8DC);
            return GHC.Err.errorWithoutStackTrace_Entry<Closure>(sats8DD);
        }
        public static Closure sats8DC_Entry(in Closure funs8DB)
        {
            return GHC.Base.plusPlus_Entry(funs8DB, lvls8Dx);
        }
        public static Closure prel_list_str_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(prel_list_strs8Dy);
        }
        public static Closure lvls8Dx_Entry()
        {
            return GHC.CString.unpackCStringHash_Entry(lvls8Dw);
        }
        public static Closure poly_init_s8Dp_Entry(Closure dss8Dq, Closure dss8Dr)
        {
            var wilds8Ds = dss8Dr.Eval();
            switch (wilds8Ds)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Ds_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Ds_Cons:
                    {
                        var zs8Dt = wilds8Ds_Cons.x0;
                        var zss8Du = wilds8Ds_Cons.x1;
                        var sat_Frees8Dv = (zs8Dt, zss8Du);
                        var sats8Dv = new Updatable<(Closure x0, Closure x1)>(&sats8Dv_Entry, sat_Frees8Dv);
                        return new GHC.Types.Cons(dss8Dq, sats8Dv);
                    }
            }
        }
        public static Closure sats8Dv_Entry(in (Closure x0, Closure x1) sat_Frees8Dv)
        {
            var zs8Dt = sat_Frees8Dv.x0;
            var zss8Du = sat_Frees8Dv.x1;
            return poly_init_s8Dp_Entry(zs8Dt, zss8Du);
        }
        public static Closure splitAt_Entry(Closure ns8Dc, Closure lss8Dd)
        {
            var wilds8De = ns8Dc.Eval();
            var wilds8De_IHash = wilds8De as GHC.Types.IHash;
            var xs8Df = wilds8De_IHash.x0;
            var lwilds8Dg = (xs8Df <= 0) ? 1 : 0;
            switch (lwilds8Dg)
            {
                default:
                    {
                        var wws8Dh = wsplitAt_s8CG_Entry(wilds8De, lss8Dd);
                        var wws8Dh_RawTuple = wws8Dh;
                        var wws8Di = wws8Dh_RawTuple.x0;
                        var wws8Dj = wws8Dh_RawTuple.x1;
                        return new GHC.Tuple.Tuple2(wws8Di, wws8Dj);
                    }
                case 1:
                    {
                        return new GHC.Tuple.Tuple2(GHC.Types.nil_DataCon, lss8Dd);
                    }
            }
        }
        public static Closure splitAt_s8D5_Entry(Closure ws8D6, Closure ws8D7)
        {
            var wws8D8 = wsplitAt_s8CG_Entry(ws8D6, ws8D7);
            var wws8D8_RawTuple = wws8D8;
            var wws8D9 = wws8D8_RawTuple.x0;
            var wws8Da = wws8D8_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8D9, wws8Da);
        }
        public static (Closure x0, Closure x1) wsplitAt_s8CG_Entry(Closure ws8CH, Closure ws8CI)
        {
            var wilds8CJ = ws8CI.Eval();
            switch (wilds8CJ)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8CJ_Nil:
                    {
                        return (GHC.Types.nil_DataCon, GHC.Types.nil_DataCon);
                    }
                case GHC.Types.Cons wilds8CJ_Cons:
                    {
                        var ipvs8CK = wilds8CJ_Cons.x0;
                        var ipvs8CL = wilds8CJ_Cons.x1;
                        var wilds8CM = ws8CH.Eval();
                        var wilds8CM_IHash = wilds8CM as GHC.Types.IHash;
                        var dss8CN = wilds8CM_IHash.x0;
                        var dss8CO = dss8CN;
                        switch (dss8CO)
                        {
                            default:
                                {
                                    var ds_Frees8CP = (ipvs8CL, dss8CO);
                                    var dss8CP = new Updatable<(Closure x0, long x1)>(&dss8CP_Entry, ds_Frees8CP);
                                    var sats8D3 = new Updatable<Closure>(&sats8D3_Entry, dss8CP);
                                    var sats8CY = new Updatable<Closure>(&sats8CY_Entry, dss8CP);
                                    var sats8CZ = new GHC.Types.Cons(ipvs8CK, sats8CY);
                                    return (sats8CZ, sats8D3);
                                }
                            case 1:
                                {
                                    var sats8D4 = new GHC.Types.Cons(ipvs8CK, GHC.Types.nil_DataCon);
                                    return (sats8D4, ipvs8CL);
                                }
                        }
                    }
            }
        }
        public static Closure sats8CY_Entry(in Closure dss8CP)
        {
            var wilds8CV = dss8CP.Eval();
            var wilds8CV_Tuple2 = wilds8CV as GHC.Tuple.Tuple2;
            var xs_s8CW = wilds8CV_Tuple2.x0;
            var xs__s8CX = wilds8CV_Tuple2.x1; return xs_s8CW.Eval();
        }
        public static Closure sats8D3_Entry(in Closure dss8CP)
        {
            var wilds8D0 = dss8CP.Eval();
            var wilds8D0_Tuple2 = wilds8D0 as GHC.Tuple.Tuple2;
            var xs_s8D1 = wilds8D0_Tuple2.x0;
            var xs__s8D2 = wilds8D0_Tuple2.x1; return xs__s8D2.Eval();
        }
        public static Closure dss8CP_Entry(in (Closure x0, long x1) ds_Frees8CP)
        {
            var ipvs8CL = ds_Frees8CP.x0;
            var dss8CO = ds_Frees8CP.x1;
            var sats8CQ = dss8CO - 1;
            var sats8CR = new GHC.Types.IHash(sats8CQ);
            var wws8CS = wsplitAt_s8CG_Entry(sats8CR, ipvs8CL);
            var wws8CS_RawTuple = wws8CS;
            var wws8CT = wws8CS_RawTuple.x0;
            var wws8CU = wws8CS_RawTuple.x1;
            return new GHC.Tuple.Tuple2(wws8CT, wws8CU);
        }
        public static Closure drop_Entry(Closure etas8CB, Closure etas8CC)
        {
            var wilds8CD = etas8CB.Eval();
            var wilds8CD_IHash = wilds8CD as GHC.Types.IHash;
            var xs8CE = wilds8CD_IHash.x0;
            var lwilds8CF = (xs8CE <= 0) ? 1 : 0;
            switch (lwilds8CF)
            {
                default: { return wunsafeDrops8Cs_Entry(xs8CE, etas8CC); }
                case 1: { return etas8CC.Eval(); }
            }
        }
        public static Closure wunsafeDrops8Cs_Entry(long wws8Ct, Closure ws8Cu)
        {
            var wilds8Cv = ws8Cu.Eval();
            switch (wilds8Cv)
            {
                default: { throw new ImpossibleException(); }
                case GHC.Types.Nil wilds8Cv_Nil:
                    {
                        return GHC.Types.nil_DataCon.Eval();
                    }
                case GHC.Types.Cons wilds8Cv_Cons:
                    {
                        var ipvs8Cw = wilds8Cv_Cons.x0;
                        var ipvs8Cx = wilds8Cv_Cons.x1;
                        var dss8Cy = wws8Ct;
                        switch (dss8Cy)
                        {
                            default:
                                {
                                    var sats8Cz = dss8Cy - 1;
                                    return wunsafeDrops8Cs_Entry(sats8Cz, ipvs8Cx);
                                }
                            case 1: { return ipvs8Cx.Eval(); }
                        }
                    }
            }
        }

    }
}
