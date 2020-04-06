using Jal.ChainOfResponsability.Tests.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class AsyncMiddlewareA : IAsyncMiddleware<Data>
    {
        public static string Start = $"Start {typeof(AsyncMiddlewareA).Name}";
        public static string End = $"End {typeof(AsyncMiddlewareA).Name}";
        public async Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
        {
            context.Data.Steps.Add(Start);
            await next(context);
            context.Data.Steps.Add(End);
        }
    }
}
