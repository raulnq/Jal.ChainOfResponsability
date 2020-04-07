using System.Threading;

namespace Jal.ChainOfResponsability
{
    public class AsyncContext<T> : Context
    {
        public T Data { get; set; }

        public CancellationToken CancellationToken { get; set; }

        public AsyncMiddlewareConfiguration<T>[] Configuration { get; set; }
    }
}
