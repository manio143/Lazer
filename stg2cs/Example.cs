/**
    Generated from Example.hs by stg2cs
 */
public static class Module {
    public static Thunk pi_ = new Updatable0(CLR.LoadFunctionPointer(Code.pi__Entry));
    public static S lvl_s4af = new S( 60 ) ;
    public static S lvl_s4ae = new S( 180 ) ;
    public static Function wgs49C = new Function4(CLR.LoadFunctionPointer(Code.wgs49C_Entry));
    public static S lvl_s49B = new S( 27 ) ;
    public static S lvl_s49A = new S( 12 ) ;
    public static S lvl_s49z = new S( 0 ) ;
    public static S lvl_s49y = new S( 3 ) ;
    public static S lvl_s49x = new S( 10 ) ;
    public static S lvl_s49w = new S( 5 ) ;
    public static S lvl_s49v = new S( 2 ) ;
    public static S lvl_s49u = new S( 1 ) ;
    public static Function gcd_ = new Function2(CLR.LoadFunctionPointer(Code.gcd__Entry));
    public static Function wgcd_s49e = new Function2(CLR.LoadFunctionPointer(Code.wgcd_s49e_Entry));
    public static Thunk fibs = new Updatable0(CLR.LoadFunctionPointer(Code.fibs_Entry));
    public static Function fibt = new Function1(CLR.LoadFunctionPointer(Code.fibt_Entry));
    public static Function fiba = new Function3(CLR.LoadFunctionPointer(Code.fiba_Entry));
    public static Function wfibas48Q = new Function3(CLR.LoadFunctionPointer(Code.wfibas48Q_Entry));
    public static Function sumFromTo = new Function2(CLR.LoadFunctionPointer(Code.sumFromTo_Entry));
    public static I lvl_s48H = new I( 0 ) ;
    public static Function go = new Function3(CLR.LoadFunctionPointer(Code.go_Entry));
    public static Function wgos48p = new Function3(CLR.LoadFunctionPointer(Code.wgos48p_Entry));
    public static Thunk inf__s48o = new Updatable0(CLR.LoadFunctionPointer(Code.inf__s48o_Entry));
    public static Cons inf_ = new Cons( inf__s48m , inf__s48o ) ;
    public static I inf__s48m = new I( 1 ) ;
    public static Function inc_ = new Function1(CLR.LoadFunctionPointer(Code.inc__Entry));
    public static Function inc = new Function1(CLR.LoadFunctionPointer(Code.inc_Entry));
    public static Function sum_ = new Function1(CLR.LoadFunctionPointer(Code.sum__Entry));
    public static Function wsum_s485 = new Function1(CLR.LoadFunctionPointer(Code.wsum_s485_Entry));
    public static Function suma = new Function2(CLR.LoadFunctionPointer(Code.suma_Entry));
    public static Function wsumas47Q = new Function2(CLR.LoadFunctionPointer(Code.wsumas47Q_Entry));
    public static Function facc2 = new Function1(CLR.LoadFunctionPointer(Code.facc2_Entry));
    public static Function wfacc2s47F = new Function1(CLR.LoadFunctionPointer(Code.wfacc2s47F_Entry));
    public static Function take_ = new Function2(CLR.LoadFunctionPointer(Code.take__Entry));
    public static Function wtake_s47r = new Function2(CLR.LoadFunctionPointer(Code.wtake_s47r_Entry));
    public static Module trModules47q = new Module( trModule_s47ns47n , trModule_s47ps47p ) ;
    public static TrNameS trModule_s47ps47p = new TrNameS( trModule_s47os47o ) ;
    public static string trModule_s47os47o = "Example" ;
    public static TrNameS trModule_s47ns47n = new TrNameS( trModule_s47ms47m ) ;
    public static string trModule_s47ms47m = "main" ;
    public static Function foldl_ = new Function3(CLR.LoadFunctionPointer(Code.foldl__Entry));
    public static Function map_ = new Function2(CLR.LoadFunctionPointer(Code.map__Entry));
    }
public static class Code {
    public static Closure pi__Entry(  ) {
        var re_ = wgs49C_Entry( lvl_s49u , lvl_s4ae , lvl_s4af , lvl_s49v );
        var re__(,) = re_ as (,);
        var se_ = re__(,).x0;
        var te_ = re__(,).x1; return new Cons( se_ , te_ );
        }
    public static RawTuple<Closure , Closure> wgs49C_Entry( Closure w_s49D , Closure w_s49E , Closure w_s49F , Closure w_s49G ) {
        var jd_ = Updatable.Make(CLR.LoadFunctionPointer(jd__Entry), w_s49D , w_s49E , w_s49F , w_s49G );
        var rd_ = Updatable.Make(CLR.LoadFunctionPointer(rd__Entry), w_s49D , w_s49E , w_s49F , w_s49G , jd_ );
        return new (,)( jd_ , rd_ );
        }
    public static Closure jd__Entry( Closure w_s49D , Closure w_s49E , Closure w_s49F , Closure w_s49G ) {
        var kd_ = timesInteger_Entry( lvl_s49w , w_s49F );
        var ld_ = eqInteger_Entry( kd_ , lvl_s49z );
        switch ( ld_ ) {
            default: {
                var md_ = timesInteger_Entry( lvl_s49w , w_s49E );
                var nd_ = timesInteger_Entry( lvl_s49B , w_s49G );
                var od_ = minusInteger_Entry( nd_ , lvl_s49A );
                var pd_ = timesInteger_Entry( w_s49D , od_ );
                var qd_ = plusInteger_Entry( pd_ , md_ );
                return divInteger_Entry( qd_ , kd_ );
                }
            case 1 : { return divZeroError ; }
            }
        }
    public static Closure rd__Entry( Closure w_s49D , Closure w_s49E , Closure w_s49F , Closure w_s49G , Closure jd_ ) {
        var sd_ = Updatable.Make(CLR.LoadFunctionPointer(sd__Entry), w_s49G );
        var yd_ = Updatable.Make(CLR.LoadFunctionPointer(yd__Entry), w_s49G );
        var ae_ = Updatable.Make(CLR.LoadFunctionPointer(ae__Entry), w_s49F , sd_ );
        var be_ = Updatable.Make(CLR.LoadFunctionPointer(be__Entry), w_s49D , w_s49E , w_s49F , w_s49G , jd_ , sd_ );
        var je_ = Updatable.Make(CLR.LoadFunctionPointer(je__Entry), w_s49D , w_s49G );
        var oe_ = wgs49C_Entry( je_ , be_ , ae_ , yd_ );
        var oe__(,) = oe_ as (,);
        var pe_ = oe__(,).x0;
        var qe_ = oe__(,).x1; return new Cons( pe_ , qe_ );
        }
    public static Closure sd__Entry( Closure w_s49G ) {
        var td_ = timesInteger_Entry( lvl_s49y , w_s49G );
        var ud_ = plusInteger_Entry( td_ , lvl_s49v );
        var vd_ = timesInteger_Entry( lvl_s49y , w_s49G );
        var wd_ = plusInteger_Entry( vd_ , lvl_s49u );
        var xd_ = timesInteger_Entry( lvl_s49y , wd_ );
        return timesInteger_Entry( xd_ , ud_ );
        }
    public static Closure yd__Entry( Closure w_s49G ) {
        return plusInteger_Entry( w_s49G , lvl_s49u ); }
    public static Closure ae__Entry( Closure w_s49F , Closure sd_ ) {
        return timesInteger_Entry( w_s49F , sd_ ); }
    public static Closure be__Entry( Closure w_s49D , Closure w_s49E , Closure w_s49F , Closure w_s49G , Closure jd_ , Closure sd_ ) {
        var ce_ = timesInteger_Entry( jd_ , w_s49F );
        var de_ = timesInteger_Entry( lvl_s49w , w_s49G );
        var ee_ = minusInteger_Entry( de_ , lvl_s49v );
        var fe_ = timesInteger_Entry( w_s49D , ee_ );
        var ge_ = plusInteger_Entry( fe_ , w_s49E );
        var he_ = minusInteger_Entry( ge_ , ce_ );
        var ie_ = timesInteger_Entry( lvl_s49x , sd_ );
        return timesInteger_Entry( ie_ , he_ );
        }
    public static Closure je__Entry( Closure w_s49D , Closure w_s49G ) {
        var ke_ = timesInteger_Entry( lvl_s49v , w_s49G );
        var le_ = minusInteger_Entry( ke_ , lvl_s49u );
        var me_ = timesInteger_Entry( lvl_s49x , w_s49D );
        var ne_ = timesInteger_Entry( me_ , w_s49G );
        return timesInteger_Entry( ne_ , le_ );
        }
    public static Closure gcd__Entry( Closure w_s49n , Closure w_s49o ) {
        var ed_ = w_s49n ;
        ed_ = ed_.Eval();
        var ed__I = ed_ as I;
        var fd_ = ed__I.x0;
        var gd_ = w_s49o ;
        gd_ = gd_.Eval();
        var gd__I = gd_ as I;
        var hd_ = gd__I.x0;
        var id_ = wgcd_s49e_Entry( fd_ , hd_ ); return new I( id_ );
        }
    public static long wgcd_s49e_Entry( long ww_s49f , long ww_s49g ) {
        var yc_ = ww_s49f ;
        switch ( yc_ ) {
            default: {
                var ad_ = ww_s49g ;
                switch ( ad_ ) {
                    default: {
                        var bd_ = ( yc_ > ad_ ) ? 1 : 0 ;
                        switch ( bd_ ) {
                            default: {
                                var cd_ = ad_ - yc_ ; return wgcd_s49e_Entry( yc_ , cd_ ); }
                            case 1 : {
                                var dd_ = yc_ - ad_ ; return wgcd_s49e_Entry( dd_ , ad_ ); }
                            }
                        }
                    case 0 : { return yc_ ; }
                    }
                }
            case 0 : { return ww_s49g ; }
            }
        }
    public static Closure fibs_Entry(  ) {
        return map__Entry( fibt , inf_ ); }
    public static Closure fibt_Entry( Closure w_s499 ) {
        var vc_ = w_s499 ;
        vc_ = vc_.Eval();
        var vc__I = vc_ as I;
        var wc_ = vc__I.x0;
        var xc_ = wfibas48Q_Entry( 0 , 1 , wc_ ); return new I( xc_ );
        }
    public static Closure fiba_Entry( Closure w_s48Y , Closure w_s48Z , Closure w_s490 ) {
        var oc_ = w_s48Y ;
        oc_ = oc_.Eval();
        var oc__I = oc_ as I;
        var pc_ = oc__I.x0;
        var qc_ = w_s48Z ;
        qc_ = qc_.Eval();
        var qc__I = qc_ as I;
        var rc_ = qc__I.x0;
        var sc_ = w_s490 ;
        sc_ = sc_.Eval();
        var sc__I = sc_ as I;
        var tc_ = sc__I.x0;
        var uc_ = wfibas48Q_Entry( pc_ , rc_ , tc_ );
        return new I( uc_ );
        }
    public static long wfibas48Q_Entry( long ww_s48R , long ww_s48S , long ww_s48T ) {
        var lc_ = ( ww_s48T <= 0 ) ? 1 : 0 ;
        switch ( lc_ ) {
            default: {
                var mc_ = ww_s48T - 1 ;
                var nc_ = ww_s48R + ww_s48S ;
                return wfibas48Q_Entry( ww_s48S , nc_ , mc_ );
                }
            case 1 : { return ww_s48R ; }
            }
        }
    public static Closure sumFromTo_Entry( Closure from , Closure to ) {
        var gc_ = from ;
        gc_ = gc_.Eval();
        var gc__I = gc_ as I;
        var hc_ = gc__I.x0;
        var ic_ = to ;
        ic_ = ic_.Eval();
        var ic__I = ic_ as I;
        var jc_ = ic__I.x0;
        var kc_ = wgos48p_Entry( hc_ , jc_ , 0 ); return new I( kc_ );
        }
    public static Closure go_Entry( Closure w_s48x , Closure w_s48y , Closure w_s48z ) {
        var yb_ = w_s48x ;
        yb_ = yb_.Eval();
        var yb__I = yb_ as I;
        var ac_ = yb__I.x0;
        var bc_ = w_s48y ;
        bc_ = bc_.Eval();
        var bc__I = bc_ as I;
        var cc_ = bc__I.x0;
        var dc_ = w_s48z ;
        dc_ = dc_.Eval();
        var dc__I = dc_ as I;
        var ec_ = dc__I.x0;
        var fc_ = wgos48p_Entry( ac_ , cc_ , ec_ ); return new I( fc_ );
        }
    public static long wgos48p_Entry( long ww_s48q , long ww_s48r , long ww_s48s ) {
        var vb_ = ( ww_s48q > ww_s48r ) ? 1 : 0 ;
        switch ( vb_ ) {
            default: {
                var wb_ = ww_s48s + ww_s48q ;
                var xb_ = ww_s48q + 1 ;
                return wgos48p_Entry( xb_ , ww_s48r , wb_ );
                }
            case 1 : { return ww_s48s ; }
            }
        }
    public static Closure inf__s48o_Entry(  ) {
        return map__Entry( inc , inf_ ); }
    public static Closure inc__Entry( Closure eta_B1 ) {
        return map__Entry( inc , eta_B1 ); }
    public static Closure inc_Entry( Closure ds1 ) {
        var sb_ = ds1 ;
        sb_ = sb_.Eval();
        var sb__I = sb_ as I;
        var tb_ = sb__I.x0; var ub_ = 1 + tb_ ; return new I( ub_ );
        }
    public static Closure sum__Entry( Closure w_s48e ) {
        var rb_ = wsum_s485_Entry( w_s48e ); return new I( rb_ ); }
    public static long wsum_s485_Entry( Closure w_s486 ) {
        var lb_ = w_s486 ;
        lb_ = lb_.Eval();
        switch ( lb_ ) {
            default: { throw new ImpossibleException(); }
            case Nil lb__Nil: { return 0 ; }
            case Cons lb__Cons: {
                var mb_ = lb__:.x0;
                var nb_ = lb__:.x1;
                var ob_ = mb_ ;
                ob_ = ob_.Eval();
                var ob__I = ob_ as I;
                var pb_ = ob__I.x0;
                var qb_ = wsum_s485_Entry( nb_ ); return pb_ + qb_ ;
                }
            }
        }
    public static Closure suma_Entry( Closure w_s480 , Closure w_s481 ) {
        var ib_ = w_s481 ;
        ib_ = ib_.Eval();
        var ib__I = ib_ as I;
        var jb_ = ib__I.x0;
        var kb_ = wsumas47Q_Entry( w_s480 , jb_ ); return new I( kb_ );
        }
    public static long wsumas47Q_Entry( Closure w_s47R , long ww_s47S ) {
        var cb_ = w_s47R ;
        cb_ = cb_.Eval();
        switch ( cb_ ) {
            default: { throw new ImpossibleException(); }
            case Nil cb__Nil: { return ww_s47S ; }
            case Cons cb__Cons: {
                var db_ = cb__:.x0;
                var eb_ = cb__:.x1;
                var fb_ = db_ ;
                fb_ = fb_.Eval();
                var fb__I = fb_ as I;
                var gb_ = fb__I.x0;
                var hb_ = gb_ + ww_s47S ; return wsumas47Q_Entry( eb_ , hb_ );
                }
            }
        }
    public static Closure facc2_Entry( Closure w_s47M ) {
        var y_ = w_s47M ;
        y_ = y_.Eval();
        var y__I = y_ as I;
        var z_ = y__I.x0;
        var bb_ = wfacc2s47F_Entry( z_ ); return new I( bb_ );
        }
    public static long wfacc2s47F_Entry( long ww_s47G ) {
        var u_ = ( ww_s47G <= 1 ) ? 1 : 0 ;
        switch ( u_ ) {
            default: {
                var v_ = ww_s47G - 1 ;
                var w_ = wfacc2s47F_Entry( v_ );
                var x_ = ww_s47G * w_ ; return x_ + 1 ;
                }
            case 1 : { return 2 ; }
            }
        }
    public static Closure take__Entry( Closure w_s47B , Closure w_s47C ) {
        var s_ = w_s47B ;
        s_ = s_.Eval();
        var s__I = s_ as I;
        var t_ = s__I.x0; return wtake_s47r_Entry( t_ , w_s47C );
        }
    public static Closure wtake_s47r_Entry( long ww_s47s , Closure w_s47t ) {
        var m_ = ww_s47s ;
        switch ( m_ ) {
            default: {
                var n_ = w_s47t ;
                n_ = n_.Eval();
                switch ( n_ ) {
                    default: { throw new ImpossibleException(); }
                    case Nil n__Nil: { return new Nil(  ); }
                    case Cons n__Cons: {
                        var o_ = n__:.x0;
                        var p_ = n__:.x1;
                        var q_ = Updatable.Make(CLR.LoadFunctionPointer(q__Entry), m_ , p_ );
                        return new Cons( o_ , q_ );
                        }
                    }
                }
            case 0 : { return new Nil(  ); }
            }
        }
    public static Closure q__Entry( long m_ , Closure p_ ) {
        var r_ = m_ - 1 ; return wtake_s47r_Entry( r_ , p_ ); }
    public static Closure foldl__Entry( Closure f , Closure x0 , Closure xs ) {
        var f_ = new Fun(2, CLR.LoadFunctionPointer(f__Entry), f , null );
        f_.x1 = f_ ;
        return StgApply.Apply< Closure , Closure , Closure >( f_ , x0 , xs );
        }
    public static Closure f__Entry( Closure f , Closure f_ , Closure g_ , Closure h_ ) {
        var i_ = h_ ;
        i_ = i_.Eval();
        switch ( i_ ) {
            default: { throw new ImpossibleException(); }
            case Nil i__Nil: { return g_ ; }
            case Cons i__Cons: {
                var j_ = i__:.x0;
                var k_ = i__:.x1;
                var l_ = Updatable.Make(CLR.LoadFunctionPointer(l__Entry), f , g_ , j_ );
                return StgApply.Apply< Closure , Closure , Closure >( f_ , l_ , k_ );
                }
            }
        }
    public static Closure l__Entry( Closure f , Closure g_ , Closure j_ ) {
        return StgApply.Apply< Closure , Closure , Closure >( f , g_ , j_ );
        }
    public static Closure map__Entry( Closure f , Closure ds_s475 ) {
        var a_ = ds_s475 ;
        a_ = a_.Eval();
        switch ( a_ ) {
            default: { throw new ImpossibleException(); }
            case Nil a__Nil: { return new Nil(  ); }
            case Cons a__Cons: {
                var b_ = a__:.x0;
                var c_ = a__:.x1;
                var d_ = Updatable.Make(CLR.LoadFunctionPointer(d__Entry), f , c_ );
                var e_ = Updatable.Make(CLR.LoadFunctionPointer(e__Entry), f , b_ );
                return new Cons( e_ , d_ );
                }
            }
        }
    public static Closure d__Entry( Closure f , Closure c_ ) {
        return map__Entry( f , c_ ); }
    public static Closure e__Entry( Closure f , Closure b_ ) {
        return StgApply.Apply< Closure , Closure >( f , b_ ); }
    }
