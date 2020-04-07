using Jal.ChainOfResponsability.Tests.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class AsyncMiddlewareE : IAsyncMiddleware<Data>
    {
        public Task ExecuteAsync(AsyncContext<Data> context, Func<AsyncContext<Data>, Task> next)
        {
            context.CancellationToken.ThrowIfCancellationRequested();

            return Task.CompletedTask;
        }
    }
}
