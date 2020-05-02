namespace Lazer.Runtime
{
    /**
        This ImpossibleException is used for the purpose of suppressing
        compiler errors in saturated pattern matching.
     */
    [System.Serializable]
    public class ImpossibleException : System.Exception
    {
        public ImpossibleException() { }
        public ImpossibleException(string message) : base(message) { }
        public ImpossibleException(string expectedType, string actualType)
            : base($"The impossible happend!\nExpected: {expectedType}\nActual  : {actualType}") { }
    }

    /**
        This ClosureException is used for raising and catching
        Haskell exceptions.
     */
    [System.Serializable]
    public class ClosureException : System.Exception
    {
        public Closure Exception { get; set; }
    }
}
