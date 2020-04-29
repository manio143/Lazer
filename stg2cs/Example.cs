using Lazer.Runtime;

public unsafe static class Example {
    internal static string lvls6pc = "sum1" ;
    internal static string lvls6p8 = "sum2" ;
    internal static string tc_Cs6nL = "'C" ;
    internal static string tc_Bs6nI = "'B" ;
    internal static string tc_As6nF = "'A" ;
    internal static string tcLetters6nB = "Letter" ;
    internal static string tc_Hs6ny = "'H" ;
    internal static string tcHs6nt = "H" ;
    internal static string tc_CColWs6nq = "'C:W" ;
    internal static string tcWs6nj = "W" ;
    internal static string tc_O4s6ng = "'O4" ;
    internal static string tc_O3s6nd = "'O3" ;
    internal static string tc_O2s6na = "'O2" ;
    internal static string tc_O1s6n7 = "'O1" ;
    internal static string tc_O0s6n4 = "'O0" ;
    internal static string tcOs6mZ = "O" ;
    internal static string trModules6mP = "Example" ;
    internal static string trModules6mN = "main" ;
    public static Fun o4_DataCon ;
    
    public static Fun o3_DataCon ;
    
    public static Fun o2_DataCon ;
    
    public static Fun o1_DataCon ;
    
    public static Fun o0_DataCon ;
    
    public static Fun cColW_DataCon ;
    
    public static Fun h_DataCon ;
    
    public static Updatable pi_ ;
    
    internal static Fun wgs6qO ;
    
    public static Fun gcd_ ;
    
    internal static Fun wgcd_s6qs ;
    
    public static Updatable fibs ;
    
    public static Fun fibt ;
    
    public static Fun fiba ;
    
    internal static Fun wfibas6q4 ;
    
    public static Fun sumFromTo ;
    
    internal static Fun gos6pL ;
    
    internal static Fun wgos6pE ;
    
    public static Fun main ;
    
    internal static Fun mains6pg ;
    
    internal static Updatable lvls6pd ;
    
    internal static Updatable lvls6p9 ;
    
    public static Fun sum1_ ;
    
    internal static Fun sum1_s6p3 ;
    
    internal static Updatable xs6p0 ;
    
    internal static Updatable inf_s6oZ ;
    
    public static Fun inc_ ;
    
    public static Fun inc ;
    
    public static Fun sum2_ ;
    
    internal static Fun sum2_s6oN ;
    
    internal static Updatable xs6oK ;
    
    public static Fun sum_ ;
    
    internal static Fun wsum_s6oz ;
    
    public static Fun suma ;
    
    internal static Fun wsumas6ok ;
    
    public static Fun facc2 ;
    
    internal static Fun wfacc2s6o9 ;
    
    public static Fun sumfold ;
    
    public static Fun take_ ;
    
    internal static Fun wtake_s6nT ;
    
    public static Fun pp ;
    
    internal static Fun pps6nP ;
    
    public static Fun letterChar ;
    
    public static Fun wt ;
    
    public static Fun test ;
    
    internal static Fun tests6mn ;
    
    public static Fun tildDollQMark ;
    
    public static Fun o1 ;
    
    public static Fun wd ;
    
    public static Fun extractO ;
    
    public static Fun foldl_ ;
    
    public static Fun map_ ;
    
    public static Fun fOrdH ;
    
    internal static Fun cmins6ls ;
    
    internal static Fun cmaxs6lj ;
    
    internal static Fun cLtEqs6la ;
    
    internal static Fun cGts6l1 ;
    
    internal static Fun cGtEqs6kS ;
    
    internal static Fun cLts6kJ ;
    
    internal static Fun cp1Ords6kG ;
    
    public static Fun fEqH ;
    
    internal static Fun cSlshEqs6kt ;
    
    internal static Fun cEqEqs6kl ;
    
    internal static Fun ccompares6kd ;
    
    internal static Fun cidens6kb ;
    
    internal static GHC.Types.IHash croots6ka ;
    internal static GHC.Integer.Type.SHash cycleAs6lT ;
    internal static GHC.Integer.Type.SHash cycleBs6lU ;
    public static GHC.Types.Cons cycleA ;
    public static GHC.Types.Cons cycleB ;
    public static Example.O1 so1 ;
    internal static GHC.Types.CHash lvls6mH ;
    internal static GHC.Types.CHash lvls6mI ;
    internal static GHC.Types.CHash lvls6mJ ;
    public static Example.CColW fWInt ;
    internal static GHC.Types.IHash sumfolds6o7 ;
    public static GHC.Types.Cons inf_ ;
    internal static GHC.Types.Cons lvls6pb ;
    internal static GHC.Types.Cons lvls6pf ;
    internal static GHC.Integer.Type.SHash lvls6qI ;
    internal static GHC.Integer.Type.SHash lvls6qJ ;
    internal static GHC.Integer.Type.SHash lvls6qK ;
    internal static GHC.Integer.Type.SHash lvls6qL ;
    internal static GHC.Integer.Type.SHash lvls6qM ;
    internal static GHC.Integer.Type.SHash lvls6qN ;
    internal static GHC.Integer.Type.SHash lvls6rq ;
    internal static GHC.Integer.Type.SHash lvls6rr ;
    public static Example.A a_DataCon ;
    public static Example.B b_DataCon ;
    public static Example.C c_DataCon ;
    
    public static Function p1W ;
    
    public static Function iden ;
    
    public static Function root ;
    
    static Example() {
        o4_DataCon = new Fun1 < Closure , Closure > ( &o4_DataCon_Entry   ) ;
        
        o3_DataCon = new Fun1 < Closure , Closure > ( &o3_DataCon_Entry   ) ;
        
        o2_DataCon = new Fun1 < Closure , Closure > ( &o2_DataCon_Entry   ) ;
        
        o1_DataCon = new Fun1 < Closure , Closure > ( &o1_DataCon_Entry   ) ;
        
        o0_DataCon = new Fun1 < Closure , Closure > ( &o0_DataCon_Entry   ) ;
        
        cColW_DataCon = new Fun3 < Closure , Closure , Closure , Closure > ( &cColW_DataCon_Entry   ) ;
        
        h_DataCon = new Fun1 < Closure , Closure > ( &h_DataCon_Entry   ) ;
        
        pi_ = new Updatable  ( &pi__Entry   ) ; 
        wgs6qO = new Fun4 < Closure , Closure , Closure , Closure , (Closure x0 , Closure x1) > ( &wgs6qO_Entry   ) ;
        
        gcd_ = new Fun2 < Closure , Closure , Closure > ( &gcd__Entry   ) ;
        
        wgcd_s6qs = new Fun2 < long , long , long > ( &wgcd_s6qs_Entry   ) ;
        
        fibs = new Updatable  ( &fibs_Entry   ) ; 
        fibt = new Fun1 < Closure , Closure > ( &fibt_Entry   ) ; 
        fiba = new Fun3 < Closure , Closure , Closure , Closure > ( &fiba_Entry   ) ;
        
        wfibas6q4 = new Fun3 < long , long , long , long > ( &wfibas6q4_Entry   ) ;
        
        sumFromTo = new Fun2 < Closure , Closure , Closure > ( &sumFromTo_Entry   ) ;
        
        gos6pL = new Fun3 < Closure , Closure , Closure , Closure > ( &gos6pL_Entry   ) ;
        
        wgos6pE = new Fun3 < long , long , long , long > ( &wgos6pE_Entry   ) ;
        
        main = new Fun1 < GHC.Prim.Void , Closure > ( &main_Entry   ) ; 
        mains6pg = new Fun1 < GHC.Prim.Void , Closure > ( &mains6pg_Entry   ) ;
        
        lvls6pd = new Updatable  ( &lvls6pd_Entry   ) ; 
        lvls6p9 = new Updatable  ( &lvls6p9_Entry   ) ; 
        sum1_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum1__Entry   ) ; 
        sum1_s6p3 = new Fun1 < GHC.Prim.Void , Closure > ( &sum1_s6p3_Entry   ) ;
        
        xs6p0 = new Updatable  ( &xs6p0_Entry   ) ; 
        inf_s6oZ = new Updatable  ( &inf_s6oZ_Entry   ) ; 
        inc_ = new Fun1 < Closure , Closure > ( &inc__Entry   ) ; 
        inc = new Fun1 < Closure , Closure > ( &inc_Entry   ) ; 
        sum2_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum2__Entry   ) ; 
        sum2_s6oN = new Fun1 < GHC.Prim.Void , Closure > ( &sum2_s6oN_Entry   ) ;
        
        xs6oK = new Updatable  ( &xs6oK_Entry   ) ; 
        sum_ = new Fun1 < Closure , Closure > ( &sum__Entry   ) ; 
        wsum_s6oz = new Fun1 < Closure , long > ( &wsum_s6oz_Entry   ) ; 
        suma = new Fun2 < Closure , Closure , Closure > ( &suma_Entry   ) ;
        
        wsumas6ok = new Fun2 < Closure , long , long > ( &wsumas6ok_Entry   ) ;
        
        facc2 = new Fun1 < Closure , Closure > ( &facc2_Entry   ) ; 
        wfacc2s6o9 = new Fun1 < long , long > ( &wfacc2s6o9_Entry   ) ; 
        sumfold = new Fun1 < Closure , Closure > ( &sumfold_Entry   ) ; 
        take_ = new Fun2 < Closure , Closure , Closure > ( &take__Entry   ) ;
        
        wtake_s6nT = new Fun2 < long , Closure , Closure > ( &wtake_s6nT_Entry   ) ;
        
        pp = new Fun2 < Closure , GHC.Prim.Void , Closure > ( &pp_Entry   ) ;
        
        pps6nP = new Fun2 < Closure , GHC.Prim.Void , Closure > ( &pps6nP_Entry   ) ;
        
        letterChar = new Fun1 < Closure , Closure > ( &letterChar_Entry   ) ;
        
        wt = new Fun2 < Closure , Closure , Closure > ( &wt_Entry   ) ; 
        test = new Fun5 < Closure , Closure , Closure , Closure , GHC.Prim.Void , Closure > ( &test_Entry   ) ;
        
        tests6mn = new Fun5 < Closure , Closure , Closure , Closure , GHC.Prim.Void , Closure > ( &tests6mn_Entry   ) ;
        
        tildDollQMark = new Fun2 < Closure , Closure , Closure > ( &tildDollQMark_Entry   ) ;
        
        o1 = new Fun2 < Closure , Closure , Closure > ( &o1_Entry   ) ; 
        wd = new Fun1 < Closure , Closure > ( &wd_Entry   ) ; 
        extractO = new Fun1 < Closure , Closure > ( &extractO_Entry   ) ; 
        foldl_ = new Fun3 < Closure , Closure , Closure , Closure > ( &foldl__Entry   ) ;
        
        map_ = new Fun2 < Closure , Closure , Closure > ( &map__Entry   ) ;
        
        fOrdH = new Fun1 < Closure , Closure > ( &fOrdH_Entry   ) ; 
        cmins6ls = new Fun3 < Closure , Closure , Closure , Closure > ( &cmins6ls_Entry   ) ;
        
        cmaxs6lj = new Fun3 < Closure , Closure , Closure , Closure > ( &cmaxs6lj_Entry   ) ;
        
        cLtEqs6la = new Fun3 < Closure , Closure , Closure , Closure > ( &cLtEqs6la_Entry   ) ;
        
        cGts6l1 = new Fun3 < Closure , Closure , Closure , Closure > ( &cGts6l1_Entry   ) ;
        
        cGtEqs6kS = new Fun3 < Closure , Closure , Closure , Closure > ( &cGtEqs6kS_Entry   ) ;
        
        cLts6kJ = new Fun3 < Closure , Closure , Closure , Closure > ( &cLts6kJ_Entry   ) ;
        
        cp1Ords6kG = new Fun1 < Closure , Closure > ( &cp1Ords6kG_Entry   ) ;
        
        fEqH = new Fun1 < Closure , Closure > ( &fEqH_Entry   ) ; 
        cSlshEqs6kt = new Fun3 < Closure , Closure , Closure , Closure > ( &cSlshEqs6kt_Entry   ) ;
        
        cEqEqs6kl = new Fun3 < Closure , Closure , Closure , Closure > ( &cEqEqs6kl_Entry   ) ;
        
        ccompares6kd = new Fun3 < Closure , Closure , Closure , Closure > ( &ccompares6kd_Entry   ) ;
        
        cidens6kb = new Fun1 < Closure , Closure > ( &cidens6kb_Entry   ) ;
        
        c_DataCon = new Example.C(  ) ;
        b_DataCon = new Example.B(  ) ;
        a_DataCon = new Example.A(  ) ;
        lvls6rr = new GHC.Integer.Type.SHash( 60 ) ;
        lvls6rq = new GHC.Integer.Type.SHash( 180 ) ;
        lvls6qN = new GHC.Integer.Type.SHash( 27 ) ;
        lvls6qM = new GHC.Integer.Type.SHash( 12 ) ;
        lvls6qL = new GHC.Integer.Type.SHash( 3 ) ;
        lvls6qK = new GHC.Integer.Type.SHash( 10 ) ;
        lvls6qJ = new GHC.Integer.Type.SHash( 5 ) ;
        lvls6qI = new GHC.Integer.Type.SHash( 2 ) ;
        lvls6pf = new GHC.Types.Cons( GHC.Show.fShowPrOComPrC3r2h , lvls6pd ) ;
        lvls6pb = new GHC.Types.Cons( GHC.Show.fShowPrOComPrC3r2h , lvls6p9 ) ;
        inf_ = new GHC.Types.Cons( null , inf_s6oZ ) ;
        sumfolds6o7 = new GHC.Types.IHash( 0 ) ;
        fWInt = new Example.CColW( GHC.Classes.fEqInt , cidens6kb , null ) ;
        lvls6mJ = new GHC.Types.CHash( 'c' ) ;
        lvls6mI = new GHC.Types.CHash( 'b' ) ;
        lvls6mH = new GHC.Types.CHash( 'a' ) ;
        so1 = new Example.O1( null ) ;
        cycleB = new GHC.Types.Cons( null , null ) ;
        cycleA = new GHC.Types.Cons( null , null ) ;
        cycleBs6lU = new GHC.Integer.Type.SHash( 0 ) ;
        cycleAs6lT = new GHC.Integer.Type.SHash( 1 ) ;
        croots6ka = new GHC.Types.IHash( 1 ) ;
        cycleA.x0 = cycleAs6lT ;
        cycleA.x1 = Example.cycleB ;
        cycleB.x0 = cycleBs6lU ;
        cycleB.x1 = Example.cycleA ;
        so1.x0 = croots6ka ; fWInt.x2 = croots6ka ; inf_.x0 = croots6ka ; 
        p1W = new Fun1 < Closure , Closure > ( &p1W_Entry   ) ; 
        iden = new Fun2 < Closure , Closure > ( &iden_Entry   ) ; 
        root = new Fun1 < Closure , Closure > ( &root_Entry   ) ; 
        }
    public static Closure o4_DataCon_Entry( Closure etaB1 ) {
        return new Example.O4( etaB1 ); }
    public static Closure o3_DataCon_Entry( Closure etaB1 ) {
        return new Example.O3( etaB1 ); }
    public static Closure o2_DataCon_Entry( Closure etaB1 ) {
        return new Example.O2( etaB1 ); }
    public static Closure o1_DataCon_Entry( Closure etaB1 ) {
        return new Example.O1( etaB1 ); }
    public static Closure o0_DataCon_Entry( Closure etaB1 ) {
        return new Example.O0( etaB1 ); }
    public static Closure cColW_DataCon_Entry( Closure etaB3 , Closure etaB2 , Closure etaB1 ) {
        return new Example.CColW( etaB3 , etaB2 , etaB1 ); }
    public static Closure h_DataCon_Entry( Closure etaB1 ) {
        return new Example.H( etaB1 ); }
    public static Closure pi__Entry(  ) {
        var wws6rt = wgs6qO_Entry( cycleAs6lT , lvls6rq , lvls6rr , lvls6qI ) ;
        var wws6rt_RawTuple = wws6rt ;
        var wws6ru = wws6rt_RawTuple.x0 ;
        var wws6rv = wws6rt_RawTuple.x1 ;
        return new GHC.Types.Cons( wws6ru , wws6rv );
        }
    public static (Closure x0 , Closure x1) wgs6qO_Entry( Closure ws6qP , Closure ws6qQ , Closure ws6qR , Closure ws6qS ) {
        var ys6qT = new Updatable < Closure , Closure , Closure , Closure > ( &ys6qT_Entry , ws6qP , ws6qQ , ws6qR , ws6qS ) ;
        var sats6rp = new Updatable < Closure , Closure , Closure , Closure , Closure > ( &sats6rp_Entry , ws6qP , ws6qQ , ws6qR , ws6qS , ys6qT ) ;
        return ( ys6qT , sats6rp );
        }
    public static Closure sats6rp_Entry( Closure ws6qP , Closure ws6qQ , Closure ws6qR , Closure ws6qS , Closure ys6qT ) {
        var us6r1 = new Updatable < Closure > ( &us6r1_Entry , ws6qS ) ;
        var sats6rl = new Updatable < Closure > ( &sats6rl_Entry , ws6qS ) ;
        var sats6rk = new Updatable < Closure , Closure > ( &sats6rk_Entry , ws6qR , us6r1 ) ;
        var sats6rj = new Updatable < Closure , Closure , Closure , Closure , Closure , Closure > ( &sats6rj_Entry , ws6qP , ws6qQ , ws6qR , ws6qS , ys6qT , us6r1 ) ;
        var sats6rb = new Updatable < Closure , Closure > ( &sats6rb_Entry , ws6qP , ws6qS ) ;
        var wws6rm = wgs6qO_Entry( sats6rb , sats6rj , sats6rk , sats6rl ) ;
        var wws6rm_RawTuple = wws6rm ;
        var wws6rn = wws6rm_RawTuple.x0 ;
        var wws6ro = wws6rm_RawTuple.x1 ;
        return new GHC.Types.Cons( wws6rn , wws6ro );
        }
    public static Closure sats6rb_Entry( Closure ws6qP , Closure ws6qS ) {
        var sats6r9 = GHC.Integer.Type.timesInteger_Entry( lvls6qI , ws6qS ) ;
        var sats6ra = GHC.Integer.Type.minusInteger_Entry( sats6r9 , cycleAs6lT ) ;
        var sats6r7 = GHC.Integer.Type.timesInteger_Entry( lvls6qK , ws6qP ) ;
        var sats6r8 = GHC.Integer.Type.timesInteger_Entry( sats6r7 , ws6qS ) ;
        return GHC.Integer.Type.timesInteger_Entry( sats6r8 , sats6ra );
        }
    public static Closure sats6rj_Entry( Closure ws6qP , Closure ws6qQ , Closure ws6qR , Closure ws6qS , Closure ys6qT , Closure us6r1 ) {
        var sats6rh = GHC.Integer.Type.timesInteger_Entry( ys6qT , ws6qR ) ;
        var sats6rd = GHC.Integer.Type.timesInteger_Entry( lvls6qJ , ws6qS ) ;
        var sats6re = GHC.Integer.Type.minusInteger_Entry( sats6rd , lvls6qI ) ;
        var sats6rf = GHC.Integer.Type.timesInteger_Entry( ws6qP , sats6re ) ;
        var sats6rg = GHC.Integer.Type.plusInteger_Entry( sats6rf , ws6qQ ) ;
        var sats6ri = GHC.Integer.Type.minusInteger_Entry( sats6rg , sats6rh ) ;
        var sats6rc = GHC.Integer.Type.timesInteger_Entry( lvls6qK , us6r1 ) ;
        return GHC.Integer.Type.timesInteger_Entry( sats6rc , sats6ri );
        }
    public static Closure sats6rk_Entry( Closure ws6qR , Closure us6r1 ) {
        return GHC.Integer.Type.timesInteger_Entry( ws6qR , us6r1 ); }
    public static Closure sats6rl_Entry( Closure ws6qS ) {
        return GHC.Integer.Type.plusInteger_Entry( ws6qS , cycleAs6lT ); }
    public static Closure us6r1_Entry( Closure ws6qS ) {
        var sats6r5 = GHC.Integer.Type.timesInteger_Entry( lvls6qL , ws6qS ) ;
        var sats6r6 = GHC.Integer.Type.plusInteger_Entry( sats6r5 , lvls6qI ) ;
        var sats6r2 = GHC.Integer.Type.timesInteger_Entry( lvls6qL , ws6qS ) ;
        var sats6r3 = GHC.Integer.Type.plusInteger_Entry( sats6r2 , cycleAs6lT ) ;
        var sats6r4 = GHC.Integer.Type.timesInteger_Entry( lvls6qL , sats6r3 ) ;
        return GHC.Integer.Type.timesInteger_Entry( sats6r4 , sats6r6 );
        }
    public static Closure ys6qT_Entry( Closure ws6qP , Closure ws6qQ , Closure ws6qR , Closure ws6qS ) {
        var ds1s6qU = GHC.Integer.Type.timesInteger_Entry( lvls6qJ , ws6qR ) ;
        var wilds6qV = GHC.Integer.Type.eqIntegerHash_Entry( ds1s6qU , cycleBs6lU ) ;
        switch ( wilds6qV ) {
            default: {
                var sats6qZ = GHC.Integer.Type.timesInteger_Entry( lvls6qJ , ws6qQ ) ;
                var sats6qW = GHC.Integer.Type.timesInteger_Entry( lvls6qN , ws6qS ) ;
                var sats6qX = GHC.Integer.Type.minusInteger_Entry( sats6qW , lvls6qM ) ;
                var sats6qY = GHC.Integer.Type.timesInteger_Entry( ws6qP , sats6qX ) ;
                var sats6r0 = GHC.Integer.Type.plusInteger_Entry( sats6qY , sats6qZ ) ;
                return GHC.Integer.Type.divInteger_Entry( sats6r0 , ds1s6qU );
                }
            case 1 : { return GHC.Real.divZeroError.Eval(); }
            }
        }
    public static Closure gcd__Entry( Closure ws6qB , Closure ws6qC ) {
        var wws6qD = ws6qB.Eval() ;
        var wws6qD_IHash = wws6qD as GHC.Types.IHash;
        var wws6qE = wws6qD_IHash.x0 ;
        var wws6qF = ws6qC.Eval() ;
        var wws6qF_IHash = wws6qF as GHC.Types.IHash;
        var wws6qG = wws6qF_IHash.x0 ;
        var wws6qH = wgcd_s6qs_Entry( wws6qE , wws6qG ) ;
        return new GHC.Types.IHash( wws6qH );
        }
    public static long wgcd_s6qs_Entry( long wws6qt , long wws6qu ) {
        var dss6qv = wws6qt ;
        switch ( dss6qv ) {
            default: {
                var dss6qw = wws6qu ;
                switch ( dss6qw ) {
                    default: {
                        var lwilds6qx = ( dss6qv > dss6qw ) ? 1 : 0 ;
                        switch ( lwilds6qx ) {
                            default: {
                                var sats6qy = dss6qw - dss6qv ;
                                return wgcd_s6qs_Entry( dss6qv , sats6qy );
                                }
                            case 1 : {
                                var sats6qz = dss6qv - dss6qw ;
                                return wgcd_s6qs_Entry( sats6qz , dss6qw );
                                }
                            }
                        }
                    case 0 : { return dss6qv ; }
                    }
                }
            case 0 : { return wws6qu ; }
            }
        }
    public static Closure fibs_Entry(  ) {
        return map__Entry( Example.fibt , Example.inf_ ); }
    public static Closure fibt_Entry( Closure ws6qn ) {
        var wws6qo = ws6qn.Eval() ;
        var wws6qo_IHash = wws6qo as GHC.Types.IHash;
        var wws6qp = wws6qo_IHash.x0 ;
        var wws6qq = wfibas6q4_Entry( 0 , 1 , wws6qp ) ;
        return new GHC.Types.IHash( wws6qq );
        }
    public static Closure fiba_Entry( Closure ws6qc , Closure ws6qd , Closure ws6qe ) {
        var wws6qf = ws6qc.Eval() ;
        var wws6qf_IHash = wws6qf as GHC.Types.IHash;
        var wws6qg = wws6qf_IHash.x0 ;
        var wws6qh = ws6qd.Eval() ;
        var wws6qh_IHash = wws6qh as GHC.Types.IHash;
        var wws6qi = wws6qh_IHash.x0 ;
        var wws6qj = ws6qe.Eval() ;
        var wws6qj_IHash = wws6qj as GHC.Types.IHash;
        var wws6qk = wws6qj_IHash.x0 ;
        var wws6ql = wfibas6q4_Entry( wws6qg , wws6qi , wws6qk ) ;
        return new GHC.Types.IHash( wws6ql );
        }
    public static long wfibas6q4_Entry( long wws6q5 , long wws6q6 , long wws6q7 ) {
        var lwilds6q8 = ( wws6q7 <= 0 ) ? 1 : 0 ;
        switch ( lwilds6q8 ) {
            default: {
                var sats6qa = wws6q7 - 1 ;
                var sats6q9 = wws6q5 + wws6q6 ;
                return wfibas6q4_Entry( wws6q6 , sats6q9 , sats6qa );
                }
            case 1 : { return wws6q5 ; }
            }
        }
    public static Closure sumFromTo_Entry( Closure froms6pX , Closure tos6pY ) {
        var wws6pZ = froms6pX.Eval() ;
        var wws6pZ_IHash = wws6pZ as GHC.Types.IHash;
        var wws6q0 = wws6pZ_IHash.x0 ;
        var wws6q1 = tos6pY.Eval() ;
        var wws6q1_IHash = wws6q1 as GHC.Types.IHash;
        var wws6q2 = wws6q1_IHash.x0 ;
        var wws6q3 = wgos6pE_Entry( wws6q0 , wws6q2 , 0 ) ;
        return new GHC.Types.IHash( wws6q3 );
        }
    public static Closure gos6pL_Entry( Closure ws6pM , Closure ws6pN , Closure ws6pO ) {
        var wws6pP = ws6pM.Eval() ;
        var wws6pP_IHash = wws6pP as GHC.Types.IHash;
        var wws6pQ = wws6pP_IHash.x0 ;
        var wws6pR = ws6pN.Eval() ;
        var wws6pR_IHash = wws6pR as GHC.Types.IHash;
        var wws6pS = wws6pR_IHash.x0 ;
        var wws6pT = ws6pO.Eval() ;
        var wws6pT_IHash = wws6pT as GHC.Types.IHash;
        var wws6pU = wws6pT_IHash.x0 ;
        var wws6pV = wgos6pE_Entry( wws6pQ , wws6pS , wws6pU ) ;
        return new GHC.Types.IHash( wws6pV );
        }
    public static long wgos6pE_Entry( long wws6pF , long wws6pG , long wws6pH ) {
        var lwilds6pI = ( wws6pF > wws6pG ) ? 1 : 0 ;
        switch ( lwilds6pI ) {
            default: {
                var sats6pK = wws6pH + wws6pF ;
                var sats6pJ = wws6pF + 1 ;
                return wgos6pE_Entry( sats6pJ , wws6pG , sats6pK );
                }
            case 1 : { return wws6pH ; }
            }
        }
    public static Closure main_Entry( GHC.Prim.Void void0E ) {
        return mains6pg_Entry( GHC.Prim.voidHash ); }
    public static Closure mains6pg_Entry( GHC.Prim.Void void0E ) {
        var ds1s6pi = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , lvls6pf , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1s6pk = ds1s6pi ;
        var ds1s6pl = xs6p0.Eval() ;
        var ds1s6pl_IHash = ds1s6pl as GHC.Types.IHash;
        var ipvs6pm = ds1s6pl_IHash.x0 ;
        var sats6pq = new SingleEntry < long > ( &sats6pq_Entry , ipvs6pm ) ;
        var ds1s6pr = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sats6pq , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1s6pt = ds1s6pr ;
        var ds1s6pu = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , lvls6pb , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1s6pw = ds1s6pu ;
        var ds1s6px = xs6oK.Eval() ;
        var ds1s6px_IHash = ds1s6px as GHC.Types.IHash;
        var ipvs6py = ds1s6px_IHash.x0 ;
        var sats6pC = new SingleEntry < long > ( &sats6pC_Entry , ipvs6py ) ;
        return GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sats6pC , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash );
        }
    public static Closure sats6pC_Entry( long ipvs6py ) {
        var ww4s6pz = GHC.Show.wshowSignedIntr2e_Entry( 0 , ipvs6py , GHC.Types.nil_DataCon ) ;
        var ww4s6pz_RawTuple = ww4s6pz ;
        var ww5s6pA = ww4s6pz_RawTuple.x0 ;
        var ww6s6pB = ww4s6pz_RawTuple.x1 ;
        return new GHC.Types.Cons( ww5s6pA , ww6s6pB );
        }
    public static Closure sats6pq_Entry( long ipvs6pm ) {
        var ww4s6pn = GHC.Show.wshowSignedIntr2e_Entry( 0 , ipvs6pm , GHC.Types.nil_DataCon ) ;
        var ww4s6pn_RawTuple = ww4s6pn ;
        var ww5s6po = ww4s6pn_RawTuple.x0 ;
        var ww6s6pp = ww4s6pn_RawTuple.x1 ;
        return new GHC.Types.Cons( ww5s6po , ww6s6pp );
        }
    public static Closure lvls6pd_Entry(  ) {
        var sats6pe = GHC.CString.unpackCStringHash_Entry( lvls6pc ) ;
        return GHC.Show.showLitString_Entry( sats6pe ).Apply < Closure , Closure > ( GHC.Show.fShowBrOBrC1r2m );
        }
    public static Closure lvls6p9_Entry(  ) {
        var sats6pa = GHC.CString.unpackCStringHash_Entry( lvls6p8 ) ;
        return GHC.Show.showLitString_Entry( sats6pa ).Apply < Closure , Closure > ( GHC.Show.fShowBrOBrC1r2m );
        }
    public static Closure sum1__Entry( GHC.Prim.Void void0E ) {
        return sum1_s6p3_Entry( GHC.Prim.voidHash ); }
    public static Closure sum1_s6p3_Entry( GHC.Prim.Void void0E ) {
        var ds1s6p5 = xs6p0.Eval() ;
        var ds1s6p5_IHash = ds1s6p5 as GHC.Types.IHash;
        var ipvs6p6 = ds1s6p5_IHash.x0 ; return ds1s6p5 ;
        }
    public static Closure xs6p0_Entry(  ) {
        var sats6p1 = wtake_s6nT_Entry( 100000 , Example.inf_ ) ;
        var wws6p2 = wsum_s6oz_Entry( sats6p1 ) ;
        return new GHC.Types.IHash( wws6p2 );
        }
    public static Closure inf_s6oZ_Entry(  ) {
        return map__Entry( Example.inc , Example.inf_ ); }
    public static Closure inc__Entry( Closure etaB1 ) {
        return map__Entry( Example.inc , etaB1 ); }
    public static Closure inc_Entry( Closure ds1s6oT ) {
        var wild1s6oU = ds1s6oT.Eval() ;
        var wild1s6oU_IHash = wild1s6oU as GHC.Types.IHash;
        var ys6oV = wild1s6oU_IHash.x0 ;
        var sats6oW = 1 + ys6oV ; return new GHC.Types.IHash( sats6oW );
        }
    public static Closure sum2__Entry( GHC.Prim.Void void0E ) {
        return sum2_s6oN_Entry( GHC.Prim.voidHash ); }
    public static Closure sum2_s6oN_Entry( GHC.Prim.Void void0E ) {
        var ds1s6oP = xs6oK.Eval() ;
        var ds1s6oP_IHash = ds1s6oP as GHC.Types.IHash;
        var ipvs6oQ = ds1s6oP_IHash.x0 ; return ds1s6oP ;
        }
    public static Closure xs6oK_Entry(  ) {
        var sats6oL = GHC.Enum.eftInt_Entry( 1 , 100000 ) ;
        var wws6oM = wsum_s6oz_Entry( sats6oL ) ;
        return new GHC.Types.IHash( wws6oM );
        }
    public static Closure sum__Entry( Closure ws6oI ) {
        var wws6oJ = wsum_s6oz_Entry( ws6oI ) ;
        return new GHC.Types.IHash( wws6oJ );
        }
    public static long wsum_s6oz_Entry( Closure ws6oA ) {
        var wilds6oB = ws6oA.Eval() ;
        switch ( wilds6oB ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds6oB_Nil: { return 0 ; }
            case GHC.Types.Cons wilds6oB_Cons: {
                var xs6oC = wilds6oB_Cons.x0 ;
                var xss6oD = wilds6oB_Cons.x1 ;
                var wilds6oE = xs6oC.Eval() ;
                var wilds6oE_IHash = wilds6oE as GHC.Types.IHash;
                var xs6oF = wilds6oE_IHash.x0 ;
                var wws6oG = wsum_s6oz_Entry( xss6oD ) ; return xs6oF + wws6oG ;
                }
            }
        }
    public static Closure suma_Entry( Closure ws6ou , Closure ws6ov ) {
        var wws6ow = ws6ov.Eval() ;
        var wws6ow_IHash = wws6ow as GHC.Types.IHash;
        var wws6ox = wws6ow_IHash.x0 ;
        var wws6oy = wsumas6ok_Entry( ws6ou , wws6ox ) ;
        return new GHC.Types.IHash( wws6oy );
        }
    public static long wsumas6ok_Entry( Closure ws6ol , long wws6om ) {
        var wilds6on = ws6ol.Eval() ;
        switch ( wilds6on ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds6on_Nil: { return wws6om ; }
            case GHC.Types.Cons wilds6on_Cons: {
                var xs6oo = wilds6on_Cons.x0 ;
                var xss6op = wilds6on_Cons.x1 ;
                var wilds6oq = xs6oo.Eval() ;
                var wilds6oq_IHash = wilds6oq as GHC.Types.IHash;
                var xs6or = wilds6oq_IHash.x0 ;
                var sats6os = xs6or + wws6om ;
                return wsumas6ok_Entry( xss6op , sats6os );
                }
            }
        }
    public static Closure facc2_Entry( Closure ws6og ) {
        var wws6oh = ws6og.Eval() ;
        var wws6oh_IHash = wws6oh as GHC.Types.IHash;
        var wws6oi = wws6oh_IHash.x0 ;
        var wws6oj = wfacc2s6o9_Entry( wws6oi ) ;
        return new GHC.Types.IHash( wws6oj );
        }
    public static long wfacc2s6o9_Entry( long wws6oa ) {
        var lwilds6ob = ( wws6oa <= 1 ) ? 1 : 0 ;
        switch ( lwilds6ob ) {
            default: {
                var sats6oc = wws6oa - 1 ;
                var wws6od = wfacc2s6o9_Entry( sats6oc ) ;
                var sats6oe = wws6oa * wws6od ; return sats6oe + 1 ;
                }
            case 1 : { return 2 ; }
            }
        }
    public static Closure sumfold_Entry( Closure etaB1 ) {
        return foldl__Entry( GHC.Num.fNumInt_DollcPlusr2z , sumfolds6o7 , etaB1 );
        }
    public static Closure take__Entry( Closure ws6o3 , Closure ws6o4 ) {
        var wws6o5 = ws6o3.Eval() ;
        var wws6o5_IHash = wws6o5 as GHC.Types.IHash;
        var wws6o6 = wws6o5_IHash.x0 ;
        return wtake_s6nT_Entry( wws6o6 , ws6o4 );
        }
    public static Closure wtake_s6nT_Entry( long wws6nU , Closure ws6nV ) {
        var dss6nW = wws6nU ;
        switch ( dss6nW ) {
            default: {
                var wilds6nX = ws6nV.Eval() ;
                switch ( wilds6nX ) {
                    default: { throw new ImpossibleException(); }
                    case GHC.Types.Nil wilds6nX_Nil: {
                        return GHC.Types.nil_DataCon.Eval(); }
                    case GHC.Types.Cons wilds6nX_Cons: {
                        var hs6nY = wilds6nX_Cons.x0 ;
                        var ts6nZ = wilds6nX_Cons.x1 ;
                        var sats6o1 = new Updatable < long , Closure > ( &sats6o1_Entry , dss6nW , ts6nZ ) ;
                        return new GHC.Types.Cons( hs6nY , sats6o1 );
                        }
                    }
                }
            case 0 : { return GHC.Types.nil_DataCon.Eval(); }
            }
        }
    public static Closure sats6o1_Entry( long dss6nW , Closure ts6nZ ) {
        var sats6o0 = dss6nW - 1 ;
        return wtake_s6nT_Entry( sats6o0 , ts6nZ );
        }
    public static Closure pp_Entry( Closure etaB2 , GHC.Prim.Void void0E ) {
        return pps6nP_Entry( etaB2 , GHC.Prim.voidHash ); }
    public static Closure pps6nP_Entry( Closure dss6nQ , GHC.Prim.Void void0E ) {
        return croots6ka ; }
    public static Closure letterChar_Entry( Closure dss6mL ) {
        var wilds6mM = dss6mL.Eval() ;
        var  wilds6mMTags6mM = wilds6mM.Tag;
        switch ( wilds6mMTags6mM ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wilds6mM_A = wilds6mM as Example.A; return lvls6mH.Eval(); }
            case 2 : {
                var wilds6mM_B = wilds6mM as Example.B; return lvls6mI.Eval(); }
            case 3 : {
                var wilds6mM_C = wilds6mM as Example.C; return lvls6mJ.Eval(); }
            }
        }
    public static Closure wt_Entry( Closure dWs6mD , Closure dss6mE ) {
        var wilds6mF = dss6mE.Eval() ;
        var  wilds6mFTags6mF = wilds6mF.Tag;
        switch ( wilds6mFTags6mF ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wilds6mF_Unit = wilds6mF as GHC.Tuple.Unit;
                var sats6mG = new Updatable < Closure > ( &sats6mG_Entry , dWs6mD ) ;
                return Example.iden_Entry( dWs6mD ).Apply < Closure , Closure > ( sats6mG );
                }
            }
        }
    public static Closure sats6mG_Entry( Closure dWs6mD ) {
        return Example.root_Entry( dWs6mD ); }
    public static Closure test_Entry( Closure etaB5 , Closure etaB4 , Closure etaB3 , Closure etaB2 , GHC.Prim.Void void0E ) {
        return tests6mn_Entry( etaB5 , etaB4 , etaB3 , etaB2 , GHC.Prim.voidHash );
        }
    public static Closure tests6mn_Entry( Closure dShows6mo , Closure dShows6mp , Closure texts6mq , Closure ms6mr , GHC.Prim.Void void0E ) {
        var sats6mt = new SingleEntry < Closure , Closure > ( &sats6mt_Entry , dShows6mo , texts6mq ) ;
        var ds1s6mu = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sats6mt , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1s6mw = ds1s6mu ;
        var ds1s6mx = ms6mr.Apply< GHC.Prim.Void , Closure >( GHC.Prim.voidHash ) ;
        var ipv1s6mz = ds1s6mx ;
        var sats6mA = new SingleEntry < Closure , Closure > ( &sats6mA_Entry , dShows6mp , ipv1s6mz ) ;
        return GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sats6mA , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash );
        }
    public static Closure sats6mA_Entry( Closure dShows6mp , Closure ipv1s6mz ) {
        return GHC.Show.show_Entry( dShows6mp ).Apply < Closure , Closure > ( ipv1s6mz );
        }
    public static Closure sats6mt_Entry( Closure dShows6mo , Closure texts6mq ) {
        return GHC.Show.show_Entry( dShows6mo ).Apply < Closure , Closure > ( texts6mq );
        }
    public static Closure tildDollQMark_Entry( Closure dNums6mk , Closure dss6ml ) {
        var wilds6mm = dss6ml.Eval() ;
        var  wilds6mmTags6mm = wilds6mm.Tag;
        switch ( wilds6mmTags6mm ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wilds6mm_Unit = wilds6mm as GHC.Tuple.Unit;
                return GHC.Num.fromInteger_Entry( dNums6mk ).Apply < Closure , Closure > ( cycleAs6lT );
                }
            }
        }
    public static Closure o1_Entry( Closure dNums6mf , Closure prods6mg ) {
        var sats6mh = new Updatable < Closure > ( &sats6mh_Entry , dNums6mf ) ;
        return prods6mg.Apply< Closure , Closure >( sats6mh );
        }
    public static Closure sats6mh_Entry( Closure dNums6mf ) {
        return GHC.Num.fromInteger_Entry( dNums6mf ).Apply < Closure , Closure > ( cycleAs6lT );
        }
    public static Closure wd_Entry( Closure etaB1 ) {
        return Data.OldList.words_Entry( etaB1 ); }
    public static Closure extractO_Entry( Closure os6m6 ) {
        var wilds6m7 = os6m6.Eval() ;
        var  wilds6m7Tags6m7 = wilds6m7.Tag;
        switch ( wilds6m7Tags6m7 ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wilds6m7_O0 = wilds6m7 as Example.O0;
                var o0s6m8 = wilds6m7_O0.x0 ; return o0s6m8.Eval();
                }
            case 2 : {
                var wilds6m7_O1 = wilds6m7 as Example.O1;
                var o1s6m9 = wilds6m7_O1.x0 ; return o1s6m9.Eval();
                }
            case 3 : {
                var wilds6m7_O2 = wilds6m7 as Example.O2;
                var o2s6ma = wilds6m7_O2.x0 ; return o2s6ma.Eval();
                }
            case 4 : {
                var wilds6m7_O3 = wilds6m7 as Example.O3;
                var o3s6mb = wilds6m7_O3.x0 ; return o3s6mb.Eval();
                }
            case 5 : {
                var wilds6m7_O4 = wilds6m7 as Example.O4;
                var o4s6mc = wilds6m7_O4.x0 ; return o4s6mc.Eval();
                }
            }
        }
    public static Closure foldl__Entry( Closure fs6lY , Closure x0s6lZ , Closure dss6m0 ) {
        var wilds6m1 = dss6m0.Eval() ;
        switch ( wilds6m1 ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds6m1_Nil: { return x0s6lZ.Eval(); }
            case GHC.Types.Cons wilds6m1_Cons: {
                var xs6m2 = wilds6m1_Cons.x0 ;
                var xss6m3 = wilds6m1_Cons.x1 ;
                var sats6m4 = new Updatable < Closure , Closure , Closure > ( &sats6m4_Entry , fs6lY , x0s6lZ , xs6m2 ) ;
                return foldl__Entry( fs6lY , sats6m4 , xss6m3 );
                }
            }
        }
    public static Closure sats6m4_Entry( Closure fs6lY , Closure x0s6lZ , Closure xs6m2 ) {
        return fs6lY.Apply< Closure , Closure , Closure >( x0s6lZ , xs6m2 );
        }
    public static Closure map__Entry( Closure fs6lM , Closure dss6lN ) {
        var wilds6lO = dss6lN.Eval() ;
        switch ( wilds6lO ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wilds6lO_Nil: {
                return GHC.Types.nil_DataCon.Eval(); }
            case GHC.Types.Cons wilds6lO_Cons: {
                var hs6lP = wilds6lO_Cons.x0 ;
                var ts6lQ = wilds6lO_Cons.x1 ;
                var sats6lS = new Updatable < Closure , Closure > ( &sats6lS_Entry , fs6lM , ts6lQ ) ;
                var sats6lR = new Updatable < Closure , Closure > ( &sats6lR_Entry , fs6lM , hs6lP ) ;
                return new GHC.Types.Cons( sats6lR , sats6lS );
                }
            }
        }
    public static Closure sats6lR_Entry( Closure fs6lM , Closure hs6lP ) {
        return fs6lM.Apply< Closure , Closure >( hs6lP ); }
    public static Closure sats6lS_Entry( Closure fs6lM , Closure ts6lQ ) {
        return map__Entry( fs6lM , ts6lQ ); }
    public static Closure fOrdH_Entry( Closure dOrds6lC ) {
        var sats6lK = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lK_Entry , dOrds6lC ) ;
        var sats6lJ = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lJ_Entry , dOrds6lC ) ;
        var sats6lI = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lI_Entry , dOrds6lC ) ;
        var sats6lH = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lH_Entry , dOrds6lC ) ;
        var sats6lG = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lG_Entry , dOrds6lC ) ;
        var sats6lF = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lF_Entry , dOrds6lC ) ;
        var sats6lE = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6lE_Entry , dOrds6lC ) ;
        var sats6lD = new Updatable < Closure > ( &sats6lD_Entry , dOrds6lC ) ;
        return new GHC.Classes.CColOrd( sats6lD , sats6lE , sats6lF , sats6lG , sats6lH , sats6lI , sats6lJ , sats6lK );
        }
    public static Closure sats6lD_Entry( Closure dOrds6lC ) {
        return cp1Ords6kG_Entry( dOrds6lC ); }
    public static Closure sats6lE_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return ccompares6kd_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lF_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cLts6kJ_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lG_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cLtEqs6la_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lH_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cGts6l1_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lI_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cGtEqs6kS_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lJ_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cmaxs6lj_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure sats6lK_Entry( Closure dOrds6lC , Closure etaB2 , Closure etaB1 ) {
        return cmins6ls_Entry( dOrds6lC , etaB2 , etaB1 ); }
    public static Closure cmins6ls_Entry( Closure dOrds6lt , Closure xs6lu , Closure ys6lv ) {
        var wilds6lw = xs6lu.Eval() ;
        var wilds6lw_H = wilds6lw as Example.H;
        var is6lx = wilds6lw_H.x0 ;
        var wilds6ly = ys6lv.Eval() ;
        var wilds6ly_H = wilds6ly as Example.H;
        var js6lz = wilds6ly_H.x0 ;
        var wilds6lA = GHC.Classes.compare_Entry( dOrds6lt ).Apply < Closure , Closure , Closure > ( is6lx , js6lz ) ;
        var  wilds6lATags6lA = wilds6lA.Tag;
        switch ( wilds6lATags6lA ) {
            default: { return wilds6lw.Eval(); }
            case 3 : {
                var wilds6lA_GT = wilds6lA as GHC.Types.GT; return wilds6ly.Eval();
                }
            }
        }
    public static Closure cmaxs6lj_Entry( Closure dOrds6lk , Closure xs6ll , Closure ys6lm ) {
        var wilds6ln = xs6ll.Eval() ;
        var wilds6ln_H = wilds6ln as Example.H;
        var is6lo = wilds6ln_H.x0 ;
        var wilds6lp = ys6lm.Eval() ;
        var wilds6lp_H = wilds6lp as Example.H;
        var js6lq = wilds6lp_H.x0 ;
        var wilds6lr = GHC.Classes.compare_Entry( dOrds6lk ).Apply < Closure , Closure , Closure > ( is6lo , js6lq ) ;
        var  wilds6lrTags6lr = wilds6lr.Tag;
        switch ( wilds6lrTags6lr ) {
            default: { return wilds6lp.Eval(); }
            case 3 : {
                var wilds6lr_GT = wilds6lr as GHC.Types.GT; return wilds6ln.Eval();
                }
            }
        }
    public static Closure cLtEqs6la_Entry( Closure dOrds6lb , Closure xs6lc , Closure ys6ld ) {
        var wilds6le = xs6lc.Eval() ;
        var wilds6le_H = wilds6le as Example.H;
        var is6lf = wilds6le_H.x0 ;
        var wilds6lg = ys6ld.Eval() ;
        var wilds6lg_H = wilds6lg as Example.H;
        var js6lh = wilds6lg_H.x0 ;
        var wilds6li = GHC.Classes.compare_Entry( dOrds6lb ).Apply < Closure , Closure , Closure > ( is6lf , js6lh ) ;
        var  wilds6liTags6li = wilds6li.Tag;
        switch ( wilds6liTags6li ) {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 3 : {
                var wilds6li_GT = wilds6li as GHC.Types.GT;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cGts6l1_Entry( Closure dOrds6l2 , Closure xs6l3 , Closure ys6l4 ) {
        var wilds6l5 = xs6l3.Eval() ;
        var wilds6l5_H = wilds6l5 as Example.H;
        var is6l6 = wilds6l5_H.x0 ;
        var wilds6l7 = ys6l4.Eval() ;
        var wilds6l7_H = wilds6l7 as Example.H;
        var js6l8 = wilds6l7_H.x0 ;
        var wilds6l9 = GHC.Classes.compare_Entry( dOrds6l2 ).Apply < Closure , Closure , Closure > ( is6l6 , js6l8 ) ;
        var  wilds6l9Tags6l9 = wilds6l9.Tag;
        switch ( wilds6l9Tags6l9 ) {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 3 : {
                var wilds6l9_GT = wilds6l9 as GHC.Types.GT;
                return GHC.Types.true_DataCon.Eval();
                }
            }
        }
    public static Closure cGtEqs6kS_Entry( Closure dOrds6kT , Closure xs6kU , Closure ys6kV ) {
        var wilds6kW = xs6kU.Eval() ;
        var wilds6kW_H = wilds6kW as Example.H;
        var is6kX = wilds6kW_H.x0 ;
        var wilds6kY = ys6kV.Eval() ;
        var wilds6kY_H = wilds6kY as Example.H;
        var js6kZ = wilds6kY_H.x0 ;
        var wilds6l0 = GHC.Classes.compare_Entry( dOrds6kT ).Apply < Closure , Closure , Closure > ( is6kX , js6kZ ) ;
        var  wilds6l0Tags6l0 = wilds6l0.Tag;
        switch ( wilds6l0Tags6l0 ) {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 1 : {
                var wilds6l0_LT = wilds6l0 as GHC.Types.LT;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cLts6kJ_Entry( Closure dOrds6kK , Closure xs6kL , Closure ys6kM ) {
        var wilds6kN = xs6kL.Eval() ;
        var wilds6kN_H = wilds6kN as Example.H;
        var is6kO = wilds6kN_H.x0 ;
        var wilds6kP = ys6kM.Eval() ;
        var wilds6kP_H = wilds6kP as Example.H;
        var js6kQ = wilds6kP_H.x0 ;
        var wilds6kR = GHC.Classes.compare_Entry( dOrds6kK ).Apply < Closure , Closure , Closure > ( is6kO , js6kQ ) ;
        var  wilds6kRTags6kR = wilds6kR.Tag;
        switch ( wilds6kRTags6kR ) {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 1 : {
                var wilds6kR_LT = wilds6kR as GHC.Types.LT;
                return GHC.Types.true_DataCon.Eval();
                }
            }
        }
    public static Closure cp1Ords6kG_Entry( Closure dOrds6kH ) {
        var sats6kI = new Updatable < Closure > ( &sats6kI_Entry , dOrds6kH ) ;
        return fEqH_Entry( sats6kI );
        }
    public static Closure sats6kI_Entry( Closure dOrds6kH ) {
        return GHC.Classes.p1Ord_Entry( dOrds6kH ); }
    public static Closure fEqH_Entry( Closure dEqs6kD ) {
        var sats6kF = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6kF_Entry , dEqs6kD ) ;
        var sats6kE = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sats6kE_Entry , dEqs6kD ) ;
        return new GHC.Classes.CColEq( sats6kE , sats6kF );
        }
    public static Closure sats6kE_Entry( Closure dEqs6kD , Closure etaB2 , Closure etaB1 ) {
        return cEqEqs6kl_Entry( dEqs6kD , etaB2 , etaB1 ); }
    public static Closure sats6kF_Entry( Closure dEqs6kD , Closure etaB2 , Closure etaB1 ) {
        return cSlshEqs6kt_Entry( dEqs6kD , etaB2 , etaB1 ); }
    public static Closure cSlshEqs6kt_Entry( Closure dEqs6ku , Closure etas6kv , Closure etas6kw ) {
        var wilds6kx = etas6kv.Eval() ;
        var wilds6kx_H = wilds6kx as Example.H;
        var a1s6ky = wilds6kx_H.x0 ;
        var wilds6kz = etas6kw.Eval() ;
        var wilds6kz_H = wilds6kz as Example.H;
        var b1s6kA = wilds6kz_H.x0 ;
        var wilds6kB = GHC.Classes.eqEq_Entry( dEqs6ku ).Apply < Closure , Closure , Closure > ( a1s6ky , b1s6kA ) ;
        var  wilds6kBTags6kB = wilds6kB.Tag;
        switch ( wilds6kBTags6kB ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wilds6kB_False = wilds6kB as GHC.Types.False;
                return GHC.Types.true_DataCon.Eval();
                }
            case 2 : {
                var wilds6kB_True = wilds6kB as GHC.Types.True;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cEqEqs6kl_Entry( Closure dEqs6km , Closure dss6kn , Closure dss6ko ) {
        var wilds6kp = dss6kn.Eval() ;
        var wilds6kp_H = wilds6kp as Example.H;
        var a1s6kq = wilds6kp_H.x0 ;
        var wilds6kr = dss6ko.Eval() ;
        var wilds6kr_H = wilds6kr as Example.H;
        var b1s6ks = wilds6kr_H.x0 ;
        return GHC.Classes.eqEq_Entry( dEqs6km ).Apply < Closure , Closure , Closure > ( a1s6kq , b1s6ks );
        }
    public static Closure ccompares6kd_Entry( Closure dOrds6ke , Closure dss6kf , Closure dss6kg ) {
        var wilds6kh = dss6kf.Eval() ;
        var wilds6kh_H = wilds6kh as Example.H;
        var is6ki = wilds6kh_H.x0 ;
        var wilds6kj = dss6kg.Eval() ;
        var wilds6kj_H = wilds6kj as Example.H;
        var js6kk = wilds6kj_H.x0 ;
        return GHC.Classes.compare_Entry( dOrds6ke ).Apply < Closure , Closure , Closure > ( is6ki , js6kk );
        }
    public static Closure cidens6kb_Entry( Closure xs6kc ) {
        return xs6kc.Eval(); }
    public static Closure p1W_Entry( Closure a0 ) {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x0 ; return dictItem.Eval();
        }
    public static Closure iden_Entry( Closure a0 ) {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x1 ; return dictItem.Eval();
        }
    public static Closure root_Entry( Closure a0 ) {
        var dict = a0 as Example.CColW;
        var dictItem = dict.x2 ; return dictItem.Eval();
        }
    public sealed class O4 : Data {
        public Closure x0; 
        public O4( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 5;
        }
    public sealed class O3 : Data {
        public Closure x0; 
        public O3( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 4;
        }
    public sealed class O2 : Data {
        public Closure x0; 
        public O2( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 3;
        }
    public sealed class O1 : Data {
        public Closure x0; 
        public O1( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 2;
        }
    public sealed class O0 : Data {
        public Closure x0; 
        public O0( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 1;
        }
    public sealed class CColW : Data {
        public Closure x0; public Closure x1; public Closure x2; 
        public CColW( Closure x0,  Closure x1,  Closure x2 ) {
            this.x0 = x0; this.x1 = x1; this.x2 = x2;  }
        public override int Tag => 1;
        }
    public sealed class H : Data {
        public Closure x0; 
        public H( Closure x0 ) { this.x0 = x0;  }
        public override int Tag => 1;
        }
    public sealed class C : Data {
         public C(  ) {  } public override int Tag => 3; }
    public sealed class B : Data {
         public B(  ) {  } public override int Tag => 2; }
    public sealed class A : Data {
         public A(  ) {  } public override int Tag => 1; }
    }
