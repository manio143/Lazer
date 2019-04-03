module Algorithms

open System.Linq
open FSharpx.Collections
open System

let elemEq eq x l =
    List.tryFind (eq x) l |> Option.isSome

let topoSortP eq f l =
    let (alive,dead,undead) = (1,2,3)
    let n = List.length l
    let graphL = l |> List.mapi (fun i a -> let (lbl, deps) = f a in (i, (lbl, deps, a))) |> Array.ofList
    let state = Array.init n (fun _ -> alive)
    let order = ref []
    let neighbours = graphL |> Array.map (fun (_,(_,deps,_)) -> graphL |> Array.filter (fun (_,(lblT,_,_)) -> elemEq eq lblT deps) |> Array.map (fun (i,_) -> i))
    let rec visit i =
        if state.[i] = dead || state.[i] = undead then
            ()
        else
            state.[i] <- undead
            for j in neighbours.[i] do
                visit j
            state.[i] <- dead
            order := i :: !order
    for i in [0..n-1] do
        visit i
    !order |> List.map (fun i -> snd graphL.[i])
    |> List.rev

let topoSortGroup eq order =
    let mutuallyRecursive (l1, ds1, a1) (l2, ds2, a2) =
        elemEq eq l1 ds2 && elemEq eq l2 ds1
    let rec group l acc (g : 'a list) =
        match l with
        | h::t -> if g.Any(fun gg -> mutuallyRecursive h gg) then
                    group t acc (h::g)
                  else
                    if List.isEmpty g then
                        group t acc [h]
                    else
                        group t (List.rev g::acc) [h]
        | [] -> List.rev (List.rev g::acc)
    if List.isEmpty order then
        []
    else
        group order [] []
    
let topoSort eq f l = 
    topoSortP eq f l |> topoSortGroup eq
    |> List.map (fun x -> List.map (fun (_,_,a) -> a) x)

let rec mapSeen f l seen acc =
    match l with
    | h :: t -> mapSeen f t (h::seen) (f h seen :: acc)
    | [] -> List.rev acc
    

let rec foldr1 f l =
    match l with
    | [x] -> x
    | h::t -> f h (foldr1 f t)
let rec foldl1 f l = List.fold f (List.head l) (List.tail l)

let rec zipWith f a b =
    match a, b with
    | ha::ta, hb::tb -> f ha hb :: zipWith f ta tb
    | [], _ -> []
    | _, [] -> []

let inline map f (x: ^T when ^T : (member Map : (^a -> ^b) -> ^U)) =
    (^T : (member Map : (^a -> ^b) -> ^U) (x,f))
