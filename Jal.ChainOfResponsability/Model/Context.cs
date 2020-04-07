namespace Jal.ChainOfResponsability
{
    public class Context
    {
        public int Index { get; set; }
    }

    public class Context<T> : Context
    {
        public T Data { get; set; }
        public MiddlewareConfiguration<T>[] Configuration { get; set; }
    }
}
