using Lazer.Runtime;

public unsafe static class Example {
    internal static string lvl = "sum1" ;
    internal static string lvl = "sum2" ;
    internal static string tc_C = "'C" ;
    internal static string tc_B = "'B" ;
    internal static string tc_A = "'A" ;
    internal static string tcLetter = "Letter" ;
    internal static string tc_H = "'H" ;
    internal static string tcH = "H" ;
    internal static string tc_CColW = "'C:W" ;
    internal static string tcW = "W" ;
    internal static string tc_O4 = "'O4" ;
    internal static string tc_O3 = "'O3" ;
    internal static string tc_O2 = "'O2" ;
    internal static string tc_O1 = "'O1" ;
    internal static string tc_O0 = "'O0" ;
    internal static string tcO = "O" ;
    internal static string trModule = "Example" ;
    internal static string trModule = "main" ;
    public static Function o4_DataCon ;
    
    public static Function o3_DataCon ;
    
    public static Function o2_DataCon ;
    
    public static Function o1_DataCon ;
    
    public static Function o0_DataCon ;
    
    public static Function cColW_DataCon ;
    
    public static Function h_DataCon ;
    
    public static Thunk pi_ ;
    
    internal static Function wg ;
    
    public static Function gcd_ ;
    
    internal static Function wgcd_ ;
    
    public static Thunk fibs ;
    
    public static Function fibt ;
    
    public static Function fiba ;
    
    internal static Function wfiba ;
    
    public static Function sumFromTo ;
    
    internal static Function go ;
    
    internal static Function wgo ;
    
    public static Function main ;
    
    internal static Function main ;
    
    internal static Thunk lvl ;
    
    internal static Thunk lvl ;
    
    public static Function sum1_ ;
    
    internal static Function sum1_ ;
    
    internal static Thunk x ;
    
    internal static Thunk inf_ ;
    
    public static Function inc_ ;
    
    public static Function inc ;
    
    public static Function sum2_ ;
    
    internal static Function sum2_ ;
    
    internal static Thunk x ;
    
    public static Function sum_ ;
    
    internal static Function wsum_ ;
    
    public static Function suma ;
    
    internal static Function wsuma ;
    
    public static Function facc2 ;
    
    internal static Function wfacc2 ;
    
    public static Function sumfold ;
    
    public static Function take_ ;
    
    internal static Function wtake_ ;
    
    public static Function pp ;
    
    internal static Function pp ;
    
    public static Function letterChar ;
    
    public static Function wt ;
    
    public static Function test ;
    
    internal static Function test ;
    
    public static Function tildDollQMark ;
    
    public static Function o1 ;
    
    public static Function wd ;
    
    public static Function extractO ;
    
    public static Function foldl_ ;
    
    public static Function suma_ ;
    
    public static Function map_ ;
    
    public static Function fOrdH ;
    
    internal static Function cmin ;
    
    internal static Function cmax ;
    
    internal static Function cLtEq ;
    
    internal static Function cGt ;
    
    internal static Function cGtEq ;
    
    internal static Function cLt ;
    
    internal static Function cp1Ord ;
    
    public static Function fEqH ;
    
    internal static Function cSlshEq ;
    
    internal static Function cEqEq ;
    
    internal static Function ccompare ;
    
    internal static Function ciden ;
    
    internal static GHC.Types.IHash croot ;
    internal static GHC.Integer.Type.SHash cycleA ;
    internal static GHC.Integer.Type.SHash cycleB ;
    public static GHC.Types.Cons cycleA ;
    public static GHC.Types.Cons cycleB ;
    public static Example.O1 so1 ;
    internal static GHC.Types.CHash lvl ;
    internal static GHC.Types.CHash lvl ;
    internal static GHC.Types.CHash lvl ;
    public static Example.CColW fWInt ;
    internal static GHC.Types.IHash sumfold ;
    public static GHC.Types.Cons inf_ ;
    internal static GHC.Types.Cons lvl ;
    internal static GHC.Types.Cons lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
    internal static GHC.Integer.Type.SHash lvl ;
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
        wg = new Fun4 < Closure , Closure , Closure , Closure , (Closure x0 , Closure x1) > ( &wg_Entry   ) ;
        
        gcd_ = new Fun2 < Closure , Closure , Closure > ( &gcd__Entry   ) ;
        
        wgcd_ = new Fun2 < long , long , long > ( &wgcd__Entry   ) ; 
        fibs = new Updatable  ( &fibs_Entry   ) ; 
        fibt = new Fun1 < Closure , Closure > ( &fibt_Entry   ) ; 
        fiba = new Fun3 < Closure , Closure , Closure , Closure > ( &fiba_Entry   ) ;
        
        wfiba = new Fun3 < long , long , long , long > ( &wfiba_Entry   ) ;
        
        sumFromTo = new Fun2 < Closure , Closure , Closure > ( &sumFromTo_Entry   ) ;
        
        go = new Fun3 < Closure , Closure , Closure , Closure > ( &go_Entry   ) ;
        
        wgo = new Fun3 < long , long , long , long > ( &wgo_Entry   ) ; 
        main = new Fun1 < GHC.Prim.Void , Closure > ( &main_Entry   ) ; 
        main = new Fun1 < GHC.Prim.Void , Closure > ( &main_Entry   ) ; 
        lvl = new Updatable  ( &lvl_Entry   ) ; 
        lvl = new Updatable  ( &lvl_Entry   ) ; 
        sum1_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum1__Entry   ) ; 
        sum1_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum1__Entry   ) ; 
        x = new Updatable  ( &x_Entry   ) ; 
        inf_ = new Updatable  ( &inf__Entry   ) ; 
        inc_ = new Fun1 < Closure , Closure > ( &inc__Entry   ) ; 
        inc = new Fun1 < Closure , Closure > ( &inc_Entry   ) ; 
        sum2_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum2__Entry   ) ; 
        sum2_ = new Fun1 < GHC.Prim.Void , Closure > ( &sum2__Entry   ) ; 
        x = new Updatable  ( &x_Entry   ) ; 
        sum_ = new Fun1 < Closure , Closure > ( &sum__Entry   ) ; 
        wsum_ = new Fun1 < Closure , long > ( &wsum__Entry   ) ; 
        suma = new Fun2 < Closure , Closure , Closure > ( &suma_Entry   ) ;
        
        wsuma = new Fun2 < Closure , long , long > ( &wsuma_Entry   ) ; 
        facc2 = new Fun1 < Closure , Closure > ( &facc2_Entry   ) ; 
        wfacc2 = new Fun1 < long , long > ( &wfacc2_Entry   ) ; 
        sumfold = new Fun1 < Closure , Closure > ( &sumfold_Entry   ) ; 
        take_ = new Fun2 < Closure , Closure , Closure > ( &take__Entry   ) ;
        
        wtake_ = new Fun2 < long , Closure , Closure > ( &wtake__Entry   ) ;
        
        pp = new Fun2 < Closure , GHC.Prim.Void , Closure > ( &pp_Entry   ) ;
        
        pp = new Fun2 < Closure , GHC.Prim.Void , Closure > ( &pp_Entry   ) ;
        
        letterChar = new Fun1 < Closure , Closure > ( &letterChar_Entry   ) ;
        
        wt = new Fun2 < Closure , Closure , Closure > ( &wt_Entry   ) ; 
        test = new Fun5 < Closure , Closure , Closure , Closure , GHC.Prim.Void , Closure > ( &test_Entry   ) ;
        
        test = new Fun5 < Closure , Closure , Closure , Closure , GHC.Prim.Void , Closure > ( &test_Entry   ) ;
        
        tildDollQMark = new Fun2 < Closure , Closure , Closure > ( &tildDollQMark_Entry   ) ;
        
        o1 = new Fun2 < Closure , Closure , Closure > ( &o1_Entry   ) ; 
        wd = new Fun1 < Closure , Closure > ( &wd_Entry   ) ; 
        extractO = new Fun1 < Closure , Closure > ( &extractO_Entry   ) ; 
        foldl_ = new Fun3 < Closure , Closure , Closure , Closure > ( &foldl__Entry   ) ;
        
        suma_ = new Fun2 < Closure , Closure , Closure > ( &suma__Entry   ) ;
        
        map_ = new Fun2 < Closure , Closure , Closure > ( &map__Entry   ) ;
        
        fOrdH = new Fun1 < Closure , Closure > ( &fOrdH_Entry   ) ; 
        cmin = new Fun3 < Closure , Closure , Closure , Closure > ( &cmin_Entry   ) ;
        
        cmax = new Fun3 < Closure , Closure , Closure , Closure > ( &cmax_Entry   ) ;
        
        cLtEq = new Fun3 < Closure , Closure , Closure , Closure > ( &cLtEq_Entry   ) ;
        
        cGt = new Fun3 < Closure , Closure , Closure , Closure > ( &cGt_Entry   ) ;
        
        cGtEq = new Fun3 < Closure , Closure , Closure , Closure > ( &cGtEq_Entry   ) ;
        
        cLt = new Fun3 < Closure , Closure , Closure , Closure > ( &cLt_Entry   ) ;
        
        cp1Ord = new Fun1 < Closure , Closure > ( &cp1Ord_Entry   ) ; 
        fEqH = new Fun1 < Closure , Closure > ( &fEqH_Entry   ) ; 
        cSlshEq = new Fun3 < Closure , Closure , Closure , Closure > ( &cSlshEq_Entry   ) ;
        
        cEqEq = new Fun3 < Closure , Closure , Closure , Closure > ( &cEqEq_Entry   ) ;
        
        ccompare = new Fun3 < Closure , Closure , Closure , Closure > ( &ccompare_Entry   ) ;
        
        ciden = new Fun1 < Closure , Closure > ( &ciden_Entry   ) ; 
        c_DataCon = new Example.C(  ) ;
        b_DataCon = new Example.B(  ) ;
        a_DataCon = new Example.A(  ) ;
        lvl = new GHC.Integer.Type.SHash( 60 ) ;
        lvl = new GHC.Integer.Type.SHash( 180 ) ;
        lvl = new GHC.Integer.Type.SHash( 27 ) ;
        lvl = new GHC.Integer.Type.SHash( 12 ) ;
        lvl = new GHC.Integer.Type.SHash( 3 ) ;
        lvl = new GHC.Integer.Type.SHash( 10 ) ;
        lvl = new GHC.Integer.Type.SHash( 5 ) ;
        lvl = new GHC.Integer.Type.SHash( 2 ) ;
        lvl = new GHC.Types.Cons( GHC.Show.fShowPrOComPrC3 , lvl ) ;
        lvl = new GHC.Types.Cons( GHC.Show.fShowPrOComPrC3 , lvl ) ;
        inf_ = new GHC.Types.Cons( null , inf_ ) ;
        sumfold = new GHC.Types.IHash( 0 ) ;
        fWInt = new Example.CColW( GHC.Classes.fEqInt , ciden , null ) ;
        lvl = new GHC.Types.CHash( 'c' ) ;
        lvl = new GHC.Types.CHash( 'b' ) ;
        lvl = new GHC.Types.CHash( 'a' ) ;
        so1 = new Example.O1( null ) ;
        cycleB = new GHC.Types.Cons( null , null ) ;
        cycleA = new GHC.Types.Cons( null , null ) ;
        cycleB = new GHC.Integer.Type.SHash( 0 ) ;
        cycleA = new GHC.Integer.Type.SHash( 1 ) ;
        croot = new GHC.Types.IHash( 1 ) ;
        cycleA.x0 = cycleA ;
        cycleA.x1 = Example.cycleB ;
        cycleB.x0 = cycleB ;
        cycleB.x1 = Example.cycleA ;
        so1.x0 = croot ; fWInt.x2 = croot ; inf_.x0 = croot ; 
        p1W = new Fun1 < Closure , Closure > ( &p1W_Entry   ) ; 
        iden = new Fun2 < Closure , Closure > ( &iden_Entry   ) ; 
        root = new Fun1 < Closure , Closure > ( &root_Entry   ) ; 
        }
    public static Closure o4_DataCon_Entry( Closure eta ) {
        return new Example.O4( eta ); }
    public static Closure o3_DataCon_Entry( Closure eta ) {
        return new Example.O3( eta ); }
    public static Closure o2_DataCon_Entry( Closure eta ) {
        return new Example.O2( eta ); }
    public static Closure o1_DataCon_Entry( Closure eta ) {
        return new Example.O1( eta ); }
    public static Closure o0_DataCon_Entry( Closure eta ) {
        return new Example.O0( eta ); }
    public static Closure cColW_DataCon_Entry( Closure eta , Closure eta , Closure eta ) {
        return new Example.CColW( eta , eta , eta ); }
    public static Closure h_DataCon_Entry( Closure eta ) {
        return new Example.H( eta ); }
    public static Closure pi__Entry(  ) {
        var ww = wg_Entry( cycleA , lvl , lvl , lvl ) ;
        var ww_RawTuple = ww ;
        var ww = ww_RawTuple.x0 ;
        var ww = ww_RawTuple.x1 ; return new GHC.Types.Cons( ww , ww );
        }
    public static (Closure x0 , Closure x1) wg_Entry( Closure w , Closure w , Closure w , Closure w ) {
        var y_Free = ( w , w , w , w ) ;
        var y = new Updatable < (Closure x0 , Closure x1 , Closure x2 , Closure x3) > ( &y_Entry , y_Free ) ;
        var sat_Free = ( w , w , w , w , y ) ;
        var sat = new Updatable < (Closure x0 , Closure x1 , Closure x2 , Closure x3 , Closure x4) > ( &sat_Entry , sat_Free ) ;
        return ( y , sat );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1 , Closure x2 , Closure x3 , Closure x4) sat_Free ) {
        var w = sat_Free.x0 ;
        var w = sat_Free.x1 ;
        var w = sat_Free.x2 ;
        var w = sat_Free.x3 ;
        var y = sat_Free.x4 ;
        var u = new Updatable < Closure > ( &u_Entry , w ) ;
        var sat = new Updatable < Closure > ( &sat_Entry , w ) ;
        var sat_Free = ( w , u ) ;
        var sat = new Updatable < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
        var sat_Free = new GHC.Prim.PrOHashComComComComComHashPrC( w , w , w , w , y , u ) ;
        var sat = new Updatable < (Closure x0 , Closure x1 , Closure x2 , Closure x3 , Closure x4 , Closure x5) > ( &sat_Entry , sat_Free ) ;
        var sat_Free = ( w , w ) ;
        var sat = new Updatable < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
        var ww = wg_Entry( sat , sat , sat , sat ) ;
        var ww_RawTuple = ww ;
        var ww = ww_RawTuple.x0 ;
        var ww = ww_RawTuple.x1 ; return new GHC.Types.Cons( ww , ww );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var w = sat_Free.x0 ;
        var w = sat_Free.x1 ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var sat = GHC.Integer.Type.minusInteger_Entry( sat , cycleA ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( sat , w ) ;
        return GHC.Integer.Type.timesInteger_Entry( sat , sat );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1 , Closure x2 , Closure x3 , Closure x4 , Closure x5) sat_Free ) {
        var w = sat_Free.x0 ;
        var w = sat_Free.x1 ;
        var w = sat_Free.x2 ;
        var w = sat_Free.x3 ;
        var y = sat_Free.x4 ;
        var u = sat_Free.x5 ;
        var sat = GHC.Integer.Type.timesInteger_Entry( y , w ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var sat = GHC.Integer.Type.minusInteger_Entry( sat , lvl ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( w , sat ) ;
        var sat = GHC.Integer.Type.plusInteger_Entry( sat , w ) ;
        var sat = GHC.Integer.Type.minusInteger_Entry( sat , sat ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , u ) ;
        return GHC.Integer.Type.timesInteger_Entry( sat , sat );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var w = sat_Free.x0 ;
        var u = sat_Free.x1 ;
        return GHC.Integer.Type.timesInteger_Entry( w , u );
        }
    public static Closure sat_Entry(in Closure w ) {
        return GHC.Integer.Type.plusInteger_Entry( w , cycleA ); }
    public static Closure u_Entry(in Closure w ) {
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var sat = GHC.Integer.Type.plusInteger_Entry( sat , lvl ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var sat = GHC.Integer.Type.plusInteger_Entry( sat , cycleA ) ;
        var sat = GHC.Integer.Type.timesInteger_Entry( lvl , sat ) ;
        return GHC.Integer.Type.timesInteger_Entry( sat , sat );
        }
    public static Closure y_Entry(in (Closure x0 , Closure x1 , Closure x2 , Closure x3) y_Free ) {
        var w = y_Free.x0 ;
        var w = y_Free.x1 ;
        var w = y_Free.x2 ;
        var w = y_Free.x3 ;
        var ds1 = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
        var wild = GHC.Integer.Type.eqIntegerHash_Entry( ds1 , cycleB ) ;
        switch ( wild ) {
            default: {
                var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
                var sat = GHC.Integer.Type.timesInteger_Entry( lvl , w ) ;
                var sat = GHC.Integer.Type.minusInteger_Entry( sat , lvl ) ;
                var sat = GHC.Integer.Type.timesInteger_Entry( w , sat ) ;
                var sat = GHC.Integer.Type.plusInteger_Entry( sat , sat ) ;
                return GHC.Integer.Type.divInteger_Entry( sat , ds1 );
                }
            case 1 : { return GHC.Real.divZeroError.Eval(); }
            }
        }
    public static Closure gcd__Entry( Closure w , Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wgcd__Entry( ww , ww ) ; return new GHC.Types.IHash( ww );
        }
    public static long wgcd__Entry( long ww , long ww ) {
        var ds = ww ;
        switch ( ds ) {
            default: {
                var ds = ww ;
                switch ( ds ) {
                    default: {
                        var lwild = ( ds > ds ) ? 1 : 0 ;
                        switch ( lwild ) {
                            default: { var sat = ds - ds ; return wgcd__Entry( ds , sat ); }
                            case 1 : { var sat = ds - ds ; return wgcd__Entry( sat , ds ); }
                            }
                        }
                    case 0 : { return ds ; }
                    }
                }
            case 0 : { return ww ; }
            }
        }
    public static Closure fibs_Entry(  ) {
        return map__Entry( Example.fibt , Example.inf_ ); }
    public static Closure fibt_Entry( Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wfiba_Entry( 0 , 1 , ww ) ;
        return new GHC.Types.IHash( ww );
        }
    public static Closure fiba_Entry( Closure w , Closure w , Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wfiba_Entry( ww , ww , ww ) ;
        return new GHC.Types.IHash( ww );
        }
    public static long wfiba_Entry( long ww , long ww , long ww ) {
        var lwild = ( ww <= 0 ) ? 1 : 0 ;
        switch ( lwild ) {
            default: {
                var sat = ww - 1 ;
                var sat = ww + ww ; return wfiba_Entry( ww , sat , sat );
                }
            case 1 : { return ww ; }
            }
        }
    public static Closure sumFromTo_Entry( Closure from , Closure to ) {
        var ww = from.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = to.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wgo_Entry( ww , ww , 0 ) ;
        return new GHC.Types.IHash( ww );
        }
    public static Closure go_Entry( Closure w , Closure w , Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wgo_Entry( ww , ww , ww ) ;
        return new GHC.Types.IHash( ww );
        }
    public static long wgo_Entry( long ww , long ww , long ww ) {
        var lwild = ( ww > ww ) ? 1 : 0 ;
        switch ( lwild ) {
            default: {
                var sat = ww + ww ;
                var sat = ww + 1 ; return wgo_Entry( sat , ww , sat );
                }
            case 1 : { return ww ; }
            }
        }
    public static Closure main_Entry( GHC.Prim.Void @void ) {
        return main_Entry( GHC.Prim.voidHash ); }
    public static Closure main_Entry( GHC.Prim.Void @void ) {
        var ds1 = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , lvl , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1 = ds1 ;
        var ds1 = x.Eval() ;
        var ds1_IHash = ds1 as GHC.Types.IHash;
        var ipv = ds1_IHash.x0 ;
        var sat = new SingleEntry < long > ( &sat_Entry , ipv ) ;
        var ds1 = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sat , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1 = ds1 ;
        var ds1 = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , lvl , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1 = ds1 ;
        var ds1 = x.Eval() ;
        var ds1_IHash = ds1 as GHC.Types.IHash;
        var ipv = ds1_IHash.x0 ;
        var sat = new SingleEntry < long > ( &sat_Entry , ipv ) ;
        return GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sat , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash );
        }
    public static Closure sat_Entry(in long ipv ) {
        var ww4 = GHC.Show.wshowSignedInt_Entry( 0 , ipv , GHC.Types.nil_DataCon ) ;
        var ww4_RawTuple = ww4 ;
        var ww5 = ww4_RawTuple.x0 ;
        var ww6 = ww4_RawTuple.x1 ; return new GHC.Types.Cons( ww5 , ww6 );
        }
    public static Closure sat_Entry(in long ipv ) {
        var ww4 = GHC.Show.wshowSignedInt_Entry( 0 , ipv , GHC.Types.nil_DataCon ) ;
        var ww4_RawTuple = ww4 ;
        var ww5 = ww4_RawTuple.x0 ;
        var ww6 = ww4_RawTuple.x1 ; return new GHC.Types.Cons( ww5 , ww6 );
        }
    public static Closure lvl_Entry(  ) {
        var sat = GHC.CString.unpackCStringHash_Entry( lvl ) ;
        return GHC.Show.showLitString_Entry( sat ).Apply < Closure , Closure > ( GHC.Show.fShowBrOBrC1 );
        }
    public static Closure lvl_Entry(  ) {
        var sat = GHC.CString.unpackCStringHash_Entry( lvl ) ;
        return GHC.Show.showLitString_Entry( sat ).Apply < Closure , Closure > ( GHC.Show.fShowBrOBrC1 );
        }
    public static Closure sum1__Entry( GHC.Prim.Void @void ) {
        return sum1__Entry( GHC.Prim.voidHash ); }
    public static Closure sum1__Entry( GHC.Prim.Void @void ) {
        var ds1 = x.Eval() ;
        var ds1_IHash = ds1 as GHC.Types.IHash;
        var ipv = ds1_IHash.x0 ; return ds1 ;
        }
    public static Closure x_Entry(  ) {
        var sat = wtake__Entry( 100000 , Example.inf_ ) ;
        var ww = wsum__Entry( sat ) ; return new GHC.Types.IHash( ww );
        }
    public static Closure inf__Entry(  ) {
        return map__Entry( Example.inc , Example.inf_ ); }
    public static Closure inc__Entry( Closure eta ) {
        return map__Entry( Example.inc , eta ); }
    public static Closure inc_Entry( Closure ds1 ) {
        var wild1 = ds1.Eval() ;
        var wild1_IHash = wild1 as GHC.Types.IHash;
        var y = wild1_IHash.x0 ;
        var sat = 1 + y ; return new GHC.Types.IHash( sat );
        }
    public static Closure sum2__Entry( GHC.Prim.Void @void ) {
        return sum2__Entry( GHC.Prim.voidHash ); }
    public static Closure sum2__Entry( GHC.Prim.Void @void ) {
        var ds1 = x.Eval() ;
        var ds1_IHash = ds1 as GHC.Types.IHash;
        var ipv = ds1_IHash.x0 ; return ds1 ;
        }
    public static Closure x_Entry(  ) {
        var sat = GHC.Enum.eftInt_Entry( 1 , 100000 ) ;
        var ww = wsum__Entry( sat ) ; return new GHC.Types.IHash( ww );
        }
    public static Closure sum__Entry( Closure w ) {
        var ww = wsum__Entry( w ) ; return new GHC.Types.IHash( ww ); }
    public static long wsum__Entry( Closure w ) {
        var wild = w.Eval() ;
        switch ( wild ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_Nil: { return 0 ; }
            case GHC.Types.Cons wild_Cons: {
                var x = wild_Cons.x0 ;
                var xs = wild_Cons.x1 ;
                var wild = x.Eval() ;
                var wild_IHash = wild as GHC.Types.IHash;
                var x = wild_IHash.x0 ;
                var ww = wsum__Entry( xs ) ; return x + ww ;
                }
            }
        }
    public static Closure suma_Entry( Closure w , Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wsuma_Entry( w , ww ) ; return new GHC.Types.IHash( ww );
        }
    public static long wsuma_Entry( Closure w , long ww ) {
        var wild = w.Eval() ;
        switch ( wild ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_Nil: { return ww ; }
            case GHC.Types.Cons wild_Cons: {
                var x = wild_Cons.x0 ;
                var xs = wild_Cons.x1 ;
                var wild = x.Eval() ;
                var wild_IHash = wild as GHC.Types.IHash;
                var x = wild_IHash.x0 ;
                var sat = x + ww ; return wsuma_Entry( xs , sat );
                }
            }
        }
    public static Closure facc2_Entry( Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ;
        var ww = wfacc2_Entry( ww ) ; return new GHC.Types.IHash( ww );
        }
    public static long wfacc2_Entry( long ww ) {
        var lwild = ( ww <= 1 ) ? 1 : 0 ;
        switch ( lwild ) {
            default: {
                var sat = ww - 1 ;
                var ww = wfacc2_Entry( sat ) ; var sat = ww * ww ; return sat + 1 ;
                }
            case 1 : { return 2 ; }
            }
        }
    public static Closure sumfold_Entry( Closure eta ) {
        return foldl__Entry( GHC.Num.fNumInt_DollcPlus , sumfold , eta ); }
    public static Closure take__Entry( Closure w , Closure w ) {
        var ww = w.Eval() ;
        var ww_IHash = ww as GHC.Types.IHash;
        var ww = ww_IHash.x0 ; return wtake__Entry( ww , w );
        }
    public static Closure wtake__Entry( long ww , Closure w ) {
        var ds = ww ;
        switch ( ds ) {
            default: {
                var wild = w.Eval() ;
                switch ( wild ) {
                    default: { throw new ImpossibleException(); }
                    case GHC.Types.Nil wild_Nil: {
                        return GHC.Types.nil_DataCon.Eval(); }
                    case GHC.Types.Cons wild_Cons: {
                        var h = wild_Cons.x0 ;
                        var t = wild_Cons.x1 ;
                        var sat_Free = ( ds , t ) ;
                        var sat = new Updatable < (long x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
                        return new GHC.Types.Cons( h , sat );
                        }
                    }
                }
            case 0 : { return GHC.Types.nil_DataCon.Eval(); }
            }
        }
    public static Closure sat_Entry(in (long x0 , Closure x1) sat_Free ) {
        var ds = sat_Free.x0 ;
        var t = sat_Free.x1 ;
        var sat = ds - 1 ; return wtake__Entry( sat , t );
        }
    public static Closure pp_Entry( Closure eta , GHC.Prim.Void @void ) {
        return pp_Entry( eta , GHC.Prim.voidHash ); }
    public static Closure pp_Entry( Closure ds , GHC.Prim.Void @void ) {
        return croot ; }
    public static Closure letterChar_Entry( Closure ds ) {
        var wild = ds.Eval() ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { throw new ImpossibleException(); }
            case 1 : { var wild_A = wild as Example.A; return lvl.Eval(); }
            case 2 : { var wild_B = wild as Example.B; return lvl.Eval(); }
            case 3 : { var wild_C = wild as Example.C; return lvl.Eval(); }
            }
        }
    public static Closure wt_Entry( Closure dW , Closure ds ) {
        var wild = ds.Eval() ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wild_Unit = wild as GHC.Tuple.Unit;
                var sat = new Updatable < Closure > ( &sat_Entry , dW ) ;
                return Example.iden_Entry( dW ).Apply < Closure , Closure > ( sat );
                }
            }
        }
    public static Closure sat_Entry(in Closure dW ) {
        return Example.root_Entry( dW ); }
    public static Closure test_Entry( Closure eta , Closure eta , Closure eta , Closure eta , GHC.Prim.Void @void ) {
        return test_Entry( eta , eta , eta , eta , GHC.Prim.voidHash ); }
    public static Closure test_Entry( Closure dShow , Closure dShow , Closure text , Closure m , GHC.Prim.Void @void ) {
        var sat_Free = ( dShow , text ) ;
        var sat = new SingleEntry < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
        var ds1 = GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sat , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash ) ;
        var ipv1 = ds1 ;
        var ds1 = m.Apply< GHC.Prim.Void , Closure >( GHC.Prim.voidHash ) ;
        var ipv1 = ds1 ;
        var sat_Free = ( dShow , ipv1 ) ;
        var sat = new SingleEntry < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
        return GHC.IO.Handle.Text.hPutStr__Entry( GHC.IO.Handle.FD.stdout , sat , GHC.Types.true_DataCon ).Apply < GHC.Prim.Void , Closure > ( GHC.Prim.voidHash );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var dShow = sat_Free.x0 ;
        var ipv1 = sat_Free.x1 ;
        return GHC.Show.show_Entry( dShow ).Apply < Closure , Closure > ( ipv1 );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var dShow = sat_Free.x0 ;
        var text = sat_Free.x1 ;
        return GHC.Show.show_Entry( dShow ).Apply < Closure , Closure > ( text );
        }
    public static Closure tildDollQMark_Entry( Closure dNum , Closure ds ) {
        var wild = ds.Eval() ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wild_Unit = wild as GHC.Tuple.Unit;
                return GHC.Num.fromInteger_Entry( dNum ).Apply < Closure , Closure > ( cycleA );
                }
            }
        }
    public static Closure o1_Entry( Closure dNum , Closure prod ) {
        var sat = new Updatable < Closure > ( &sat_Entry , dNum ) ;
        return prod.Apply< Closure , Closure >( sat );
        }
    public static Closure sat_Entry(in Closure dNum ) {
        return GHC.Num.fromInteger_Entry( dNum ).Apply < Closure , Closure > ( cycleA );
        }
    public static Closure wd_Entry( Closure eta ) {
        return Data.OldList.words_Entry( eta ); }
    public static Closure extractO_Entry( Closure o ) {
        var wild = o.Eval() ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wild_O0 = wild as Example.O0;
                var o0 = wild_O0.x0 ; return o0.Eval();
                }
            case 2 : {
                var wild_O1 = wild as Example.O1;
                var o1 = wild_O1.x0 ; return o1.Eval();
                }
            case 3 : {
                var wild_O2 = wild as Example.O2;
                var o2 = wild_O2.x0 ; return o2.Eval();
                }
            case 4 : {
                var wild_O3 = wild as Example.O3;
                var o3 = wild_O3.x0 ; return o3.Eval();
                }
            case 5 : {
                var wild_O4 = wild as Example.O4;
                var o4 = wild_O4.x0 ; return o4.Eval();
                }
            }
        }
    public static Closure foldl__Entry( Closure f , Closure x0 , Closure ds ) {
        var wild = ds.Eval() ;
        switch ( wild ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_Nil: { return x0.Eval(); }
            case GHC.Types.Cons wild_Cons: {
                var x = wild_Cons.x0 ;
                var xs = wild_Cons.x1 ;
                var sat_Free = ( f , x0 , x ) ;
                var sat = new Updatable < (Closure x0 , Closure x1 , Closure x2) > ( &sat_Entry , sat_Free ) ;
                return foldl__Entry( f , sat , xs );
                }
            }
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1 , Closure x2) sat_Free ) {
        var f = sat_Free.x0 ;
        var x0 = sat_Free.x1 ;
        var x = sat_Free.x2 ;
        return f.Apply< Closure , Closure , Closure >( x0 , x );
        }
    public static Closure suma__Entry( Closure l , Closure fk ) {
        var exit = new Fun1 < Closure , Closure , long , Closure > ( &exit_Entry , fk ) ;
        var wsuma_wrk_Free = ( exit , null ) ;
        var wsuma_wrk = new Fun2 < (Closure x0 , Closure x1) , (Closure x0 , Closure x1) , Closure , long , Closure > ( &wsuma_wrk_Entry , wsuma_wrk_Free ) ;
        wsuma_wrk.free.x1 = wsuma_wrk ;
        return wsuma_wrk.Apply< Closure , long , Closure >( l , 0 );
        }
    public static Closure wsuma_wrk_Entry(in (Closure x0 , Closure x1) wsuma_wrk_Free , Closure w , long ww ) {
        var exit = wsuma_wrk_Free.x0 ;
        var wsuma_wrk = wsuma_wrk_Free.x1 ;
        var wild = w.Eval() ;
        switch ( wild ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_Nil: {
                return exit.Apply< long , Closure >( ww ); }
            case GHC.Types.Cons wild_Cons: {
                var x = wild_Cons.x0 ;
                var xs = wild_Cons.x1 ;
                var wild = x.Eval() ;
                var wild_IHash = wild as GHC.Types.IHash;
                var x = wild_IHash.x0 ;
                var sat = x + ww ;
                return wsuma_wrk.Apply< Closure , long , Closure >( xs , sat );
                }
            }
        }
    public static Closure exit_Entry(in Closure fk , long ww ) {
        var sat = new GHC.Types.IHash( ww ) ;
        return fk.Apply< Closure , Closure >( sat );
        }
    public static Closure map__Entry( Closure f , Closure ds ) {
        var wild = ds.Eval() ;
        switch ( wild ) {
            default: { throw new ImpossibleException(); }
            case GHC.Types.Nil wild_Nil: {
                return GHC.Types.nil_DataCon.Eval(); }
            case GHC.Types.Cons wild_Cons: {
                var h = wild_Cons.x0 ;
                var t = wild_Cons.x1 ;
                var sat_Free = ( f , t ) ;
                var sat = new Updatable < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
                var sat_Free = ( f , h ) ;
                var sat = new Updatable < (Closure x0 , Closure x1) > ( &sat_Entry , sat_Free ) ;
                return new GHC.Types.Cons( sat , sat );
                }
            }
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var f = sat_Free.x0 ;
        var h = sat_Free.x1 ; return f.Apply< Closure , Closure >( h );
        }
    public static Closure sat_Entry(in (Closure x0 , Closure x1) sat_Free ) {
        var f = sat_Free.x0 ;
        var t = sat_Free.x1 ; return map__Entry( f , t );
        }
    public static Closure fOrdH_Entry( Closure dOrd ) {
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dOrd ) ;
        var sat = new Updatable < Closure > ( &sat_Entry , dOrd ) ;
        return new GHC.Classes.CColOrd( sat , sat , sat , sat , sat , sat , sat , sat );
        }
    public static Closure sat_Entry(in Closure dOrd ) {
        return cp1Ord_Entry( dOrd ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return ccompare_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cLt_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cLtEq_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cGt_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cGtEq_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cmax_Entry( dOrd , eta , eta ); }
    public static Closure sat_Entry(in Closure dOrd , Closure eta , Closure eta ) {
        return cmin_Entry( dOrd , eta , eta ); }
    public static Closure cmin_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return wild.Eval(); }
            case 3 : {
                var wild_GT = wild as GHC.Types.GT; return wild.Eval(); }
            }
        }
    public static Closure cmax_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return wild.Eval(); }
            case 3 : {
                var wild_GT = wild as GHC.Types.GT; return wild.Eval(); }
            }
        }
    public static Closure cLtEq_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 3 : {
                var wild_GT = wild as GHC.Types.GT;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cGt_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 3 : {
                var wild_GT = wild as GHC.Types.GT;
                return GHC.Types.true_DataCon.Eval();
                }
            }
        }
    public static Closure cGtEq_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return GHC.Types.true_DataCon.Eval(); }
            case 1 : {
                var wild_LT = wild as GHC.Types.LT;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cLt_Entry( Closure dOrd , Closure x , Closure y ) {
        var wild = x.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = y.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        var wild = GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { return GHC.Types.false_DataCon.Eval(); }
            case 1 : {
                var wild_LT = wild as GHC.Types.LT;
                return GHC.Types.true_DataCon.Eval();
                }
            }
        }
    public static Closure cp1Ord_Entry( Closure dOrd ) {
        var sat = new Updatable < Closure > ( &sat_Entry , dOrd ) ;
        return fEqH_Entry( sat );
        }
    public static Closure sat_Entry(in Closure dOrd ) {
        return GHC.Classes.p1Ord_Entry( dOrd ); }
    public static Closure fEqH_Entry( Closure dEq ) {
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dEq ) ;
        var sat = new Fun2 < Closure , Closure , Closure , Closure , Closure > ( &sat_Entry , dEq ) ;
        return new GHC.Classes.CColEq( sat , sat );
        }
    public static Closure sat_Entry(in Closure dEq , Closure eta , Closure eta ) {
        return cEqEq_Entry( dEq , eta , eta ); }
    public static Closure sat_Entry(in Closure dEq , Closure eta , Closure eta ) {
        return cSlshEq_Entry( dEq , eta , eta ); }
    public static Closure cSlshEq_Entry( Closure dEq , Closure eta , Closure eta ) {
        var wild = eta.Eval() ;
        var wild_H = wild as Example.H;
        var a1 = wild_H.x0 ;
        var wild = eta.Eval() ;
        var wild_H = wild as Example.H;
        var b1 = wild_H.x0 ;
        var wild = GHC.Classes.eqEq_Entry( dEq ).Apply < Closure , Closure , Closure > ( a1 , b1 ) ;
        var  wildTag = wild.Tag;
        switch ( wildTag ) {
            default: { throw new ImpossibleException(); }
            case 1 : {
                var wild_False = wild as GHC.Types.False;
                return GHC.Types.true_DataCon.Eval();
                }
            case 2 : {
                var wild_True = wild as GHC.Types.True;
                return GHC.Types.false_DataCon.Eval();
                }
            }
        }
    public static Closure cEqEq_Entry( Closure dEq , Closure ds , Closure ds ) {
        var wild = ds.Eval() ;
        var wild_H = wild as Example.H;
        var a1 = wild_H.x0 ;
        var wild = ds.Eval() ;
        var wild_H = wild as Example.H;
        var b1 = wild_H.x0 ;
        return GHC.Classes.eqEq_Entry( dEq ).Apply < Closure , Closure , Closure > ( a1 , b1 );
        }
    public static Closure ccompare_Entry( Closure dOrd , Closure ds , Closure ds ) {
        var wild = ds.Eval() ;
        var wild_H = wild as Example.H;
        var i = wild_H.x0 ;
        var wild = ds.Eval() ;
        var wild_H = wild as Example.H;
        var j = wild_H.x0 ;
        return GHC.Classes.compare_Entry( dOrd ).Apply < Closure , Closure , Closure > ( i , j );
        }
    public static Closure ciden_Entry( Closure x ) { return x.Eval(); }
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
