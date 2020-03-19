{-# LANGUAGE ScopedTypeVariables, RankNTypes #-}
module Main where

import System.IO
import Control.Monad.Trans
import Control.Monad.State
import DynFlags
import Outputable
import HscTypes
import CorePrep
import CoreToStg
import SimplStg
import SimplCore
import CoreSyn
import StgSyn
import TyCon
import Var
import Name (nameStableString)
import Kind
import IdInfo
import GHC
import GHC.Paths ( libdir )
import HscMain

import Convert

main :: IO ()
main = do
  --print libdir
  runGhc (Just libdir) $ do
    env <- getSession
    dflags <- getSessionDynFlags
    setSessionDynFlags $ updOptLevel 1 $ dflags { hscTarget = HscAsm }
    dflags <- getSessionDynFlags

    liftIO $ hPutStrLn stderr "Loading target Example.hs"  

    target <- guessTarget "Example.hs" Nothing
    addTarget target
    load LoadAllTargets
    depanal [] True
    modSum <- getModSummary $ mkModuleName "Example"

    pmod <- parseModule modSum      -- ModuleSummary
    tmod <- typecheckModule pmod    -- TypecheckedSource
    dmod <- desugarModule tmod      -- DesugaredModule
    let coreMod = coreModule dmod      -- CoreModule
    let mod   = ms_mod modSum
    let loc   = ms_location modSum
    let core  = mg_binds coreMod
    let tcs   = filter isDataTyCon (mg_tcs coreMod) -- see note in source code: 
    -- cg_tycons includes newtypes, for the benefit of External Core,
    -- but we don't generate any code for newtypes

    let dflags' = gopt_set dflags Opt_StgStats    --Print stats

    let env' = env {hsc_dflags = dflags'}
    guts' <- liftIO $ core2core env' coreMod
    let core' = mg_binds guts' 
    (prep, _) <- liftIO $ corePrepPgm env' mod loc core' tcs
    let (stg,_) = coreToStg dflags' mod prep
    stg_binds2 <- liftIO $ stg2stg dflags' stg
    liftIO $ putStrLn $ stg2cs dflags' stg_binds2
