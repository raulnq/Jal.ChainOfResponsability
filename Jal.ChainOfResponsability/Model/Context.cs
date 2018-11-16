namespace Jal.ChainOfResponsability.Model
{
    public class Context
    {
        public int Index { get; set; }
    }

    public class Context<T> : Context
    {
        public T Data { get; set; }

        public MiddlewareMetadata<T>[] Middlewaremetadata { get; set; }
    }
}
