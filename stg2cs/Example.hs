{-# LANGUAGE BangPatterns, MagicHash #-}
module Example where

import Prelude
import GHC.Prim
import qualified Data.List
import Control.DeepSeq

map' :: (a -> b) -> [a] -> [b]
map' f [] = []
map' f (h:t) = f h : map' f t

take' :: Int -> [a] -> [a]
take' 0 = \_ -> []
take' n = \l -> case l of
                    [] -> []
                    (h:t) -> h : take' (n-1) t

inc :: Int -> Int
inc = (+) 1

inc' :: [Int] -> [Int]
inc' = map' (\x -> inc x)

inf' = 1 : inc' inf'

gcd' :: Int -> Int -> Int
gcd' 0 b = b
gcd' a 0 = a
gcd' a b | a > b = gcd' (a - b) b
         | True  = gcd' a (b - a)

fiba :: Int -> Int -> Int -> Int
fiba !a !b n = if n <= 0 then a else 
                let next = a + b in fiba b next (n-1)
fibt = fiba 0 1
fibs = map' fibt inf'

sum' :: [Int] -> Int
sum' [] = 0
sum' (x:xs) = x + sum' xs

suma :: [Int] -> Int -> Int
suma [] !a = a
suma (x:xs) !a = suma xs (x+a)

facc2 :: Int -> Int
facc2 n = facc + 1
    where facc = if n <= 1 then 1 else n * facc2 (n-1)

foldl' f x0 [] = x0
foldl' f x0 (x:xs) = foldl' f (f x0 x) xs

sumfold :: [Int] -> Int
sumfold = foldl' (+) 0

sumFromTo :: Int -> Int -> Int
sumFromTo from to = go from to 0
    where go !f !t !n | f > t = n
                      | otherwise = go (f+1) t (n+f)

pi_ :: [Integer]
pi_ = g 1 180 60 2
    where
       g q r t i = 
           let u = 3*(3*i+1)*(3*i+2)
               y = div(q*(27*i-12)+5*r)(5*t)
           in y : g (10*q*i*(2*i-1)) (10*u*(q*(5*i-2)+r-y*t)) (t*u) (i+1)

data O = O0 Int | O1 Int | O2 Int | O3 Int | O4 Int

extractO :: O -> Int
extractO o =
    case o of
    O0 o0 -> o0
    O1 o1 -> o1
    O2 o2 -> o2
    O3 o3 -> o3
    O4 o4 -> o4

wd = Data.List.words

o1 prod = prod 1
so1 = o1 O1

(~$?) () = 1

pp :: a -> IO Int
pp _ = return 1

sum1_ :: IO Int
sum2_ :: IO Int
sum1_ = let x = (sum' (take' 100000 inf')) in x `deepseq` return x
sum2_ = let x = (sum' [1..100000]) in x `deepseq` return x

test text m = do
    print text
    x <- m
    print x

main = do
    test "sum1" sum1_
    test "sum2" sum2_

class Eq a => W a where
    iden :: a -> a
    root :: a

instance W Int where
    iden x = x
    root = 1

data H a = H a
    deriving Eq

instance Ord a => Ord (H a) where
    compare (H i) (H j) = compare i j

wt :: W a => () -> a
wt () = iden root

data Letter = A | B | C

letterChar A = 'a'
letterChar B = 'b'
letterChar C = 'c'

