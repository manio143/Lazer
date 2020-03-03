namespace Lazer.Runtime
{
    [System.Serializable]
    public class ImpossibleException : System.Exception
    {
        public ImpossibleException() { }
        public ImpossibleException(string message) : base(message) { }
        public ImpossibleException(string message, System.Exception inner) : base(message, inner) { }
    }
}
