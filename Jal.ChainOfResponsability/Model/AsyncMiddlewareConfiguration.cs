using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public class AsyncMiddlewareConfiguration<T> : MiddlewareConfiguration
    {
        public Func<AsyncContext<T>, Func<AsyncContext<T>, Task>, Task> AsyncMiddleware { get; set; }
    }
}
