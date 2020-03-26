{-# LANGUAGE BangPatterns #-}
module Example where

import Prelude
import System.CPUTime
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

foldl' f x0 xs = foldl_go x0 xs
    where
        foldl_go x0 [] = x0
        foldl_go x0 (x:xs) =
            let app = (f x0 x) in foldl_go app xs

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

