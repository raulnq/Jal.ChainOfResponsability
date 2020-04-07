using Jal.ChainOfResponsability.Tests.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class AsyncMiddlewareD : IAsyncMiddleware<Data>
    {
        public async Task ExecuteAsync(AsyncContext<Data> context, Func<AsyncContext<Data>, Task> next)
        {
            await Task.Delay(2000);

            await next(context);
        }
    }
}
