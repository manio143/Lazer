{-# LANGUAGE BangPatterns #-}
module Example where

fib :: Int -> Int -> Int -> Int
fib !a !b n = if n <= 0 then a else 
                let next = a + b in fib b next (n-1)
fibonacci = fib 0 1
fib5 = fibonacci 5

inf :: [Int]
inf = 1 : map (+1) inf
