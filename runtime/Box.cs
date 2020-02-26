namespace Lazer.Runtime
{
    /**
        Generic container for unlifted values (structs).
     */
    public sealed class Box<T> : Closure where T : struct
    {
        public T value;
        public Box(T value) => this.value = value;
        public override Closure Eval(StgContext ctx) => this;
        public static implicit operator T(Box<T> b) => b.value;
        public static implicit operator Box<T>(T t) => new Box<T>(t);
    }
}