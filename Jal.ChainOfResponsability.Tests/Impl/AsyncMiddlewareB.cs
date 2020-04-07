using Jal.ChainOfResponsability.Tests.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class AsyncMiddlewareB : IAsyncMiddleware<Data>
    {
        public static string Start = $"Start {typeof(AsyncMiddlewareB).Name}";
        public static string End = $"End {typeof(AsyncMiddlewareB).Name}";
        public async Task ExecuteAsync(AsyncContext<Data> context, Func<AsyncContext<Data>, Task> next)
        {
            context.Data.Steps.Add(Start);
            await next(context);
            context.Data.Steps.Add(End);
        }
    }
}
