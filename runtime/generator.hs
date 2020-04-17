{-
    A script for generating runtime classes.
    Used for Apply methods, PAP, Fun, Updatable and SingleEntry instances.
    And CLR functions...
-}
import Data.List

methodCount = 6
fvsCount = 11

templateApp modifier fbody n = 
    "public " ++
    modifier ++
    " R Apply<" ++
    (intercalate ", " $ genAppArgs n) ++
    ", R>(" ++
    (intercalate ", " $ formalArgs n) ++
    ")" ++ fbody n

genAppArgs n = map (\i -> "A"++show i) [1..n]
genFunArgs n = map (\i -> "F"++show i) [0..n-1]
formalArgs n = map (\i -> "A"++show i++" a"++show i) [1..n]
constrArgs n = map (\i -> "F"++show i++" x"++show i) [0..n-1]
actualArgs n = map (\i -> "a"++show i) [1..n]
fieldArgs n = map (\i -> "x"++show i) [0..n-1]

abstractDefinitions = render methodCount $ templateApp "abstract" (const ";")
dataDefinitions = render methodCount $ templateApp "override" (const $ "\n\t => "++exception)
    where
        exception = "throw new NotSupportedException($\"Cannot apply a value ({GetType()})\");"
computationDefinitions = render methodCount $ templateApp "override" evalAndCall
    where
        evalAndCall n = 
            "\n\t => this.Eval().Apply<" ++
            (intercalate ", " $ genAppArgs n) ++
            ", R>(" ++
            (intercalate ", " $ actualArgs n) ++
            ");"
papDefinitions x = render methodCount $ templateApp "override" evalAndCall
    where
        evalAndCall n = 
            if n + x <= methodCount then
                "\n\t => f.Apply<" ++
                (intercalate ", " $ genFunArgs x ++ genAppArgs n) ++
                ", R>(" ++
                (intercalate ", " $ fieldArgs x ++ actualArgs n) ++
                ");"
            else "\n\t => throw new NotSupportedException(\"Application exceeds runtime argument limit.\");"
functionDefinitions = 
    (render methodCount $ templateAppImpl "abstract" (const ";")) ++
    "\n\n"++
    (render methodCount $ templateApp "override" apply)
    where
        apply n =
            "\n{\n"++
            (if n > 1 then "\tClosure h;\n" else "")++
            "\tswitch (this.Arity) {\n"++
            (concatMap renderCases [1..n]) ++
            renderDefault ++
            "\t}\n}"
            where
                renderCases i =
                    ind ++
                    "case " ++ show i ++ ":\n"++
                    (if i < n then 
                        renderH i ++
                        renderApply i
                    else
                        renderApplyImpl)
                renderApplyImpl =
                    ind ++ ind ++
                    "return this.ApplyImpl<"++
                    (intercalate ", " $ genAppArgs n) ++ ", R>("++
                    (intercalate ", " $ actualArgs n) ++ ");\n"
                renderApply d =
                    ind ++ ind ++
                    "return h.Apply<"++
                    (intercalate ", " $ drop d $ genAppArgs n) ++ ", R>("++
                    (intercalate ", " $ drop d $ actualArgs n) ++ ");\n"
                renderH d =
                    ind ++ ind ++
                    "h = this.ApplyImpl<"++
                    (intercalate ", " $ take d $ genAppArgs n) ++ ", Closure>("++
                    (intercalate ", " $ take d $ actualArgs n) ++ ");\n"
                renderDefault =
                    ind ++
                    "default: return (R)(object)new PAP<"++
                    (intercalate ", " $ genAppArgs n) ++ ">(this, "++
                    (intercalate ", " $ actualArgs n) ++ ");\n"
                ind = "\t\t"

render n f = intercalate "\n" $ map f [1..n]

clrTailCall n = 
    "[CompilerIntrinsic]\n"++
    "public static unsafe extern U TailCallIndirectGeneric<"++
    (concatMap (++", ") $ genAppArgs n)++
    "U>("++
    (concatMap (++", ") $ formalArgs n)++
    "void* funPtr);\n"

clrLdftn n =
    "[CompilerIntrinsic]\n"++
    "public static unsafe extern void* LoadFunctionPointer<"++
    (concatMap (++", ") $ genAppArgs n)++
    "U>(Func<"++
    (concatMap (++", ") $ genAppArgs n)++
    "U> f);\n"

templateAppImpl modifier fbody n = 
    "public " ++
    modifier ++
    " R ApplyImpl<" ++
    (intercalate ", " $ genAppArgs n) ++
    ", R>(" ++
    (intercalate ", " $ formalArgs n) ++
    ")" ++ fbody n

templateTail visibility name fbody = 
    visibility ++ " override " ++
    "Closure "++name++"()"
    ++ fbody

cleanup n = "protected override void Cleanup() {\n"++(concatMap assignDefault [0..n-1])++"}\n"
    where assignDefault i = "\tx"++show i++" = default;\n"

funDefinitions x = render methodCount $ templateAppImpl "override" (tailCallArgs x)
tailCallArgs x n = 
    "\n\t => CLR.TailCallIndirectGeneric<" ++
    (intercalate ", " $ genFunArgs x ++ genAppArgs n) ++
    ", R>(" ++
    (intercalate ", " $ fieldArgs x ++ actualArgs n) ++
    ", f);"

updatableDefinitions x = templateTail "protected" "Compute" (tailCall x)
singleEntryDefinitions x = templateTail "public" "Eval" (tailCall x)
tailCall x = 
    "\n\t => CLR.TailCallIndirectGeneric<" ++
    (concatMap (++", ") $ genFunArgs x ) ++
    "Closure>(" ++
    (concatMap (++", ") $ fieldArgs x ) ++
    "f);\n"

declField x = "\tpublic F"++show x++" x"++show x++";\n"
asgnField x = "\tthis.x"++show x++" = x"++show x++";\n"
templateClass name parent ctor body x =
    "public unsafe class "++
    name++
    (if x == 0 then "" else "<"++ (intercalate ", " $ genFunArgs x) ++ ">") ++
    parent++
    "\n{\n" ++
    (concatMap declField [0..x-1]) ++
    ctor name x ++
    body ++
    "\n}\n"

mkCtor additionalArgs baseCall additionalBody name x =
    "public "++name++"("++
    additionalArgs++
    (intercalate ", " $ constrArgs x) ++
    ")"++baseCall++" {\n" ++
    additionalBody ++
    (concatMap asgnField [0..x-1]) ++
    "}\n"

funClass x = templateClass "Fun" par (mkCtor adargs bcall adbod) bod x
    where
        adargs = "int arity, void* f" ++ (if x > 0 then ", " else "")
        par = if x == 0 then " : Function" else " : Fun "
        bcall = if x == 0 then "" else " : base(arity, f)"
        adbod = if x == 0 then "\tthis.arity = arity;\n\tthis.f = f;\n" else ""
        bod = addFlds ++ funDefinitions x
        addFlds =
            if x == 0 then
                "\tprotected int arity;\n\tpublic override int Arity => arity;\n" ++
                "\tprotected void* f;\n"
            else ""

updatableClass x = templateClass "Updatable" par (mkCtor adargs bcall adbod) bod x
    where
        adargs = "void* f" ++ (if x > 0 then ", " else "")
        par = if x == 0 then " : Thunk" else " : Updatable "
        bcall = if x == 0 then "" else " : base(f)"
        adbod = if x == 0 then "\tthis.f = f;\n" else ""
        bod = addFlds ++ updatableDefinitions x ++ (if x == 0 then "" else cleanup x)
        addFlds =
            if x == 0 then
                "\tprotected void* f;\n"
            else ""
singleEntryClass x = templateClass "SingleEntry" par (mkCtor adargs bcall adbod) bod x
    where
        adargs = "void* f" ++ (if x > 0 then ", " else "")
        par = if x == 0 then " : Computation" else " : SingleEntry "
        bcall = if x == 0 then "" else " : base(f)"
        adbod = if x == 0 then "\tthis.f = f;\n" else ""
        bod = addFlds ++ singleEntryDefinitions x
        addFlds =
            if x == 0 then
                "\tprotected void* f;\n"
            else ""

papClass x | x > 0 = templateClass "PAP" par (mkCtor adargs bcall "") bod x
    where
        adargs = "Function f, "
        par = " : PAP "
        bcall = " : base(f)"
        bod = papDefinitions x

printAll =
    "/* Closure */\n"++
    abstractDefinitions ++
    "\n\n/* Computation */\n"++
    computationDefinitions ++
    "\n\n/* Data */\n"++
    dataDefinitions ++
    "\n\n/* Function */\n"++
    functionDefinitions ++
    "\n\n/* Fun */\n"++
    (intercalate "\n" $ map funClass [0..fvsCount])++
    "\n\n/* Updatable */\n"++
    (intercalate "\n" $ map updatableClass [0..fvsCount])++
    "\n\n/* SingleEntry */\n"++
    (intercalate "\n" $ map singleEntryClass [0..fvsCount])++
    "\n\n/* PAP */\n"++
    (intercalate "\n" $ map papClass [1..fvsCount]) ++
    "\n\n/* CLR tail calli */\n"++
    (intercalate "\n" $ map clrTailCall [0..fvsCount+methodCount]) ++
    "\n\n/* CLR ldftn */\n"++
    (intercalate "\n" $ map clrLdftn [0..fvsCount+methodCount])


main = putStrLn printAll
