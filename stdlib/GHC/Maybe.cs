using Lazer.Runtime;

namespace GHC {
    public unsafe static class Maybe {
        internal static string tc_Justs2xV = "'Just" ;
        internal static string tc_Nothings2xR = "'Nothing" ;
        internal static string tcMaybes2xM = "Maybe" ;
        internal static string trModules2xI = "GHC.Maybe" ;
        internal static string trModules2xG = "main" ;
        public static Fun just_DataCon ;
        
        public static Fun fOrdMaybe ;
        
        internal static Fun cmins2xk ;
        
        internal static Fun cGtEqs2x9 ;
        
        internal static Fun cmaxs2x0 ;
        
        internal static Fun cLtEqs2wP ;
        
        internal static Fun cp1Ords2wM ;
        
        public static Fun fEqMaybe ;
        
        internal static Fun cSlshEqs2wx ;
        
        internal static Fun cEqEqs2wn ;
        
        internal static Fun ccompares2wd ;
        
        internal static Fun cLts2w3 ;
        
        public static GHC.Maybe.Nothing nothing_DataCon ;
        
        static Maybe() {
            just_DataCon = new Fun  (1, CLR.LoadFunctionPointer< Closure , Closure >(just_DataCon_Entry)   ) ;
            
            fOrdMaybe = new Fun  (1, CLR.LoadFunctionPointer< Closure , Closure >(fOrdMaybe_Entry)   ) ;
            
            cmins2xk = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cmins2xk_Entry)   ) ;
            
            cGtEqs2x9 = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cGtEqs2x9_Entry)   ) ;
            
            cmaxs2x0 = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cmaxs2x0_Entry)   ) ;
            
            cLtEqs2wP = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cLtEqs2wP_Entry)   ) ;
            
            cp1Ords2wM = new Fun  (1, CLR.LoadFunctionPointer< Closure , Closure >(cp1Ords2wM_Entry)   ) ;
            
            fEqMaybe = new Fun  (1, CLR.LoadFunctionPointer< Closure , Closure >(fEqMaybe_Entry)   ) ;
            
            cSlshEqs2wx = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cSlshEqs2wx_Entry)   ) ;
            
            cEqEqs2wn = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cEqEqs2wn_Entry)   ) ;
            
            ccompares2wd = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(ccompares2wd_Entry)   ) ;
            
            cLts2w3 = new Fun  (3, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(cLts2w3_Entry)   ) ;
            
            nothing_DataCon = new GHC.Maybe.Nothing(  ) ; 
            }
        public static Closure just_DataCon_Entry( Closure etaB1 ) {
            return new GHC.Maybe.Just( etaB1 ); }
        public static Closure fOrdMaybe_Entry( Closure dOrds2xv ) {
            var sats2xF = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xF_Entry) , dOrds2xv ) ;
            var sats2xE = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xE_Entry) , dOrds2xv ) ;
            var sats2xD = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xD_Entry) , dOrds2xv ) ;
            var sats2xC = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xC_Entry) , dOrds2xv ) ;
            var sats2xz = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xz_Entry) , dOrds2xv ) ;
            var sats2xy = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xy_Entry) , dOrds2xv ) ;
            var sats2xx = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2xx_Entry) , dOrds2xv ) ;
            var sats2xw = new Updatable < Closure > ( CLR.LoadFunctionPointer< Closure , Closure >(sats2xw_Entry) , dOrds2xv ) ;
            return new GHC.Classes.CColOrd( sats2xw , sats2xx , sats2xy , sats2xz , sats2xC , sats2xD , sats2xE , sats2xF );
            }
        public static Closure sats2xw_Entry( Closure dOrds2xv ) {
            return cp1Ords2wM_Entry( dOrds2xv ); }
        public static Closure sats2xx_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return ccompares2wd_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure sats2xy_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return cLts2w3_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure sats2xz_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return cLtEqs2wP_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure sats2xC_Entry( Closure dOrds2xv , Closure as2xA , Closure bs2xB ) {
            return cLts2w3_Entry( dOrds2xv , bs2xB , as2xA ); }
        public static Closure sats2xD_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return cGtEqs2x9_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure sats2xE_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return cmaxs2x0_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure sats2xF_Entry( Closure dOrds2xv , Closure etaB2 , Closure etaB1 ) {
            return cmins2xk_Entry( dOrds2xv , etaB2 , etaB1 ); }
        public static Closure cmins2xk_Entry( Closure dOrds2xl , Closure xs2xm , Closure ys2xn ) {
            var wilds2xo = ys2xn.Eval() ;
            switch ( wilds2xo ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2xo_Nothing: {
                    var wilds2xp = xs2xm.Eval() ;
                    return GHC.Maybe.nothing_DataCon.Eval();
                    }
                case GHC.Maybe.Just wilds2xo_Just: {
                    var a1s2xq = wilds2xo_Just.x0 ;
                    var wilds2xr = xs2xm.Eval() ;
                    switch ( wilds2xr ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2xr_Nothing: {
                            return GHC.Maybe.nothing_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2xr_Just: {
                            var b1s2xs = wilds2xr_Just.x0 ;
                            var wilds2xt = GHC.Classes.lt_Entry( dOrds2xl ).Apply < Closure , Closure , Closure > ( a1s2xq , b1s2xs ).Eval() ;
                            var  wilds2xtTags2xt = wilds2xt.Tag;
                            switch ( wilds2xtTags2xt ) {
                                default: { throw new ImpossibleException(); }
                                case 1 : {
                                    var wilds2xt_False = wilds2xt as GHC.Types.False;
                                    return wilds2xr.Eval();
                                    }
                                case 2 : {
                                    var wilds2xt_True = wilds2xt as GHC.Types.True;
                                    return wilds2xo.Eval();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        public static Closure cGtEqs2x9_Entry( Closure dOrds2xa , Closure as2xb , Closure bs2xc ) {
            var wilds2xd = as2xb.Eval() ;
            switch ( wilds2xd ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2xd_Nothing: {
                    var wilds2xe = bs2xc.Eval() ;
                    switch ( wilds2xe ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2xe_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2xe_Just: {
                            var ipvs2xf = wilds2xe_Just.x0 ;
                            return GHC.Types.false_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2xd_Just: {
                    var a1s2xg = wilds2xd_Just.x0 ;
                    var wilds2xh = bs2xc.Eval() ;
                    switch ( wilds2xh ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2xh_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2xh_Just: {
                            var b1s2xi = wilds2xh_Just.x0 ;
                            var wilds2xj = GHC.Classes.lt_Entry( dOrds2xa ).Apply < Closure , Closure , Closure > ( a1s2xg , b1s2xi ).Eval() ;
                            var  wilds2xjTags2xj = wilds2xj.Tag;
                            switch ( wilds2xjTags2xj ) {
                                default: { throw new ImpossibleException(); }
                                case 1 : {
                                    var wilds2xj_False = wilds2xj as GHC.Types.False;
                                    return GHC.Types.true_DataCon.Eval();
                                    }
                                case 2 : {
                                    var wilds2xj_True = wilds2xj as GHC.Types.True;
                                    return GHC.Types.false_DataCon.Eval();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        public static Closure cmaxs2x0_Entry( Closure dOrds2x1 , Closure xs2x2 , Closure ys2x3 ) {
            var wilds2x4 = ys2x3.Eval() ;
            switch ( wilds2x4 ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2x4_Nothing: { return xs2x2.Eval(); }
                case GHC.Maybe.Just wilds2x4_Just: {
                    var a1s2x5 = wilds2x4_Just.x0 ;
                    var wilds2x6 = xs2x2.Eval() ;
                    switch ( wilds2x6 ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2x6_Nothing: {
                            return wilds2x4.Eval(); }
                        case GHC.Maybe.Just wilds2x6_Just: {
                            var b1s2x7 = wilds2x6_Just.x0 ;
                            var wilds2x8 = GHC.Classes.lt_Entry( dOrds2x1 ).Apply < Closure , Closure , Closure > ( a1s2x5 , b1s2x7 ).Eval() ;
                            var  wilds2x8Tags2x8 = wilds2x8.Tag;
                            switch ( wilds2x8Tags2x8 ) {
                                default: { throw new ImpossibleException(); }
                                case 1 : {
                                    var wilds2x8_False = wilds2x8 as GHC.Types.False;
                                    return wilds2x4.Eval();
                                    }
                                case 2 : {
                                    var wilds2x8_True = wilds2x8 as GHC.Types.True;
                                    return wilds2x6.Eval();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        public static Closure cLtEqs2wP_Entry( Closure dOrds2wQ , Closure as2wR , Closure bs2wS ) {
            var wilds2wT = bs2wS.Eval() ;
            switch ( wilds2wT ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2wT_Nothing: {
                    var wilds2wU = as2wR.Eval() ;
                    switch ( wilds2wU ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wU_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wU_Just: {
                            var ipvs2wV = wilds2wU_Just.x0 ;
                            return GHC.Types.false_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2wT_Just: {
                    var a1s2wW = wilds2wT_Just.x0 ;
                    var wilds2wX = as2wR.Eval() ;
                    switch ( wilds2wX ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wX_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wX_Just: {
                            var b1s2wY = wilds2wX_Just.x0 ;
                            var wilds2wZ = GHC.Classes.lt_Entry( dOrds2wQ ).Apply < Closure , Closure , Closure > ( a1s2wW , b1s2wY ).Eval() ;
                            var  wilds2wZTags2wZ = wilds2wZ.Tag;
                            switch ( wilds2wZTags2wZ ) {
                                default: { throw new ImpossibleException(); }
                                case 1 : {
                                    var wilds2wZ_False = wilds2wZ as GHC.Types.False;
                                    return GHC.Types.true_DataCon.Eval();
                                    }
                                case 2 : {
                                    var wilds2wZ_True = wilds2wZ as GHC.Types.True;
                                    return GHC.Types.false_DataCon.Eval();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        public static Closure cp1Ords2wM_Entry( Closure dOrds2wN ) {
            var sats2wO = new Updatable < Closure > ( CLR.LoadFunctionPointer< Closure , Closure >(sats2wO_Entry) , dOrds2wN ) ;
            return fEqMaybe_Entry( sats2wO );
            }
        public static Closure sats2wO_Entry( Closure dOrds2wN ) {
            return GHC.Classes.p1Ord_Entry( dOrds2wN ); }
        public static Closure fEqMaybe_Entry( Closure dEqs2wJ ) {
            var sats2wL = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2wL_Entry) , dEqs2wJ ) ;
            var sats2wK = new Fun < Closure > (2, CLR.LoadFunctionPointer< Closure , Closure , Closure , Closure >(sats2wK_Entry) , dEqs2wJ ) ;
            return new GHC.Classes.CColEq( sats2wK , sats2wL );
            }
        public static Closure sats2wK_Entry( Closure dEqs2wJ , Closure etaB2 , Closure etaB1 ) {
            return cEqEqs2wn_Entry( dEqs2wJ , etaB2 , etaB1 ); }
        public static Closure sats2wL_Entry( Closure dEqs2wJ , Closure etaB2 , Closure etaB1 ) {
            return cSlshEqs2wx_Entry( dEqs2wJ , etaB2 , etaB1 ); }
        public static Closure cSlshEqs2wx_Entry( Closure dEqs2wy , Closure etas2wz , Closure etas2wA ) {
            var wilds2wB = etas2wz.Eval() ;
            switch ( wilds2wB ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2wB_Nothing: {
                    var wilds2wC = etas2wA.Eval() ;
                    switch ( wilds2wC ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wC_Nothing: {
                            return GHC.Types.false_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wC_Just: {
                            var ipvs2wD = wilds2wC_Just.x0 ;
                            return GHC.Types.true_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2wB_Just: {
                    var a1s2wE = wilds2wB_Just.x0 ;
                    var wilds2wF = etas2wA.Eval() ;
                    switch ( wilds2wF ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wF_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wF_Just: {
                            var b1s2wG = wilds2wF_Just.x0 ;
                            var wilds2wH = GHC.Classes.eqEq_Entry( dEqs2wy ).Apply < Closure , Closure , Closure > ( a1s2wE , b1s2wG ).Eval() ;
                            var  wilds2wHTags2wH = wilds2wH.Tag;
                            switch ( wilds2wHTags2wH ) {
                                default: { throw new ImpossibleException(); }
                                case 1 : {
                                    var wilds2wH_False = wilds2wH as GHC.Types.False;
                                    return GHC.Types.true_DataCon.Eval();
                                    }
                                case 2 : {
                                    var wilds2wH_True = wilds2wH as GHC.Types.True;
                                    return GHC.Types.false_DataCon.Eval();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        public static Closure cEqEqs2wn_Entry( Closure dEqs2wo , Closure dss2wp , Closure dss2wq ) {
            var wilds2wr = dss2wp.Eval() ;
            switch ( wilds2wr ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2wr_Nothing: {
                    var wilds2ws = dss2wq.Eval() ;
                    switch ( wilds2ws ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2ws_Nothing: {
                            return GHC.Types.true_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2ws_Just: {
                            var ipvs2wt = wilds2ws_Just.x0 ;
                            return GHC.Types.false_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2wr_Just: {
                    var a1s2wu = wilds2wr_Just.x0 ;
                    var wilds2wv = dss2wq.Eval() ;
                    switch ( wilds2wv ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wv_Nothing: {
                            return GHC.Types.false_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wv_Just: {
                            var b1s2ww = wilds2wv_Just.x0 ;
                            return GHC.Classes.eqEq_Entry( dEqs2wo ).Apply < Closure , Closure , Closure > ( a1s2wu , b1s2ww );
                            }
                        }
                    }
                }
            }
        public static Closure ccompares2wd_Entry( Closure dOrds2we , Closure as2wf , Closure bs2wg ) {
            var wilds2wh = as2wf.Eval() ;
            switch ( wilds2wh ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2wh_Nothing: {
                    var wilds2wi = bs2wg.Eval() ;
                    switch ( wilds2wi ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wi_Nothing: {
                            return GHC.Types.eQ_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wi_Just: {
                            var ipvs2wj = wilds2wi_Just.x0 ;
                            return GHC.Types.lT_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2wh_Just: {
                    var a1s2wk = wilds2wh_Just.x0 ;
                    var wilds2wl = bs2wg.Eval() ;
                    switch ( wilds2wl ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wl_Nothing: {
                            return GHC.Types.gT_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wl_Just: {
                            var b1s2wm = wilds2wl_Just.x0 ;
                            return GHC.Classes.compare_Entry( dOrds2we ).Apply < Closure , Closure , Closure > ( a1s2wk , b1s2wm );
                            }
                        }
                    }
                }
            }
        public static Closure cLts2w3_Entry( Closure dOrds2w4 , Closure as2w5 , Closure bs2w6 ) {
            var wilds2w7 = as2w5.Eval() ;
            switch ( wilds2w7 ) {
                default: { throw new ImpossibleException(); }
                case GHC.Maybe.Nothing wilds2w7_Nothing: {
                    var wilds2w8 = bs2w6.Eval() ;
                    switch ( wilds2w8 ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2w8_Nothing: {
                            return GHC.Types.false_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2w8_Just: {
                            var ipvs2w9 = wilds2w8_Just.x0 ;
                            return GHC.Types.true_DataCon.Eval();
                            }
                        }
                    }
                case GHC.Maybe.Just wilds2w7_Just: {
                    var a1s2wa = wilds2w7_Just.x0 ;
                    var wilds2wb = bs2w6.Eval() ;
                    switch ( wilds2wb ) {
                        default: { throw new ImpossibleException(); }
                        case GHC.Maybe.Nothing wilds2wb_Nothing: {
                            return GHC.Types.false_DataCon.Eval(); }
                        case GHC.Maybe.Just wilds2wb_Just: {
                            var b1s2wc = wilds2wb_Just.x0 ;
                            return GHC.Classes.lt_Entry( dOrds2w4 ).Apply < Closure , Closure , Closure > ( a1s2wa , b1s2wc );
                            }
                        }
                    }
                }
            }
        public sealed class Just : Data {
            public Closure x0; 
            public Just( Closure x0 ) { this.x0 = x0;  }
            public override int Tag => 2;
            }
        public sealed class Nothing : Data {
             public Nothing(  ) {  } public override int Tag => 1; }
        }
    }
