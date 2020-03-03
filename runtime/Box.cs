namespace Lazer.Runtime
{
    /**
        Generic container for unlifted values (structs).
     */
    public sealed class Box<T> : Data where T : struct
    {
        public T x0;
        public Box(T value) => this.x0 = value;
        public static implicit operator T(Box<T> b) => b.x0;
        public static implicit operator Box<T>(T t) => new Box<T>(t);
    }
}