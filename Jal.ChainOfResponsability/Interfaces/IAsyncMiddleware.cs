using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public interface IAsyncMiddleware<T>
    {
        Task ExecuteAsync(AsyncContext<T> context, Func<AsyncContext<T>,Task> next);
    }
}
