using Jal.ChainOfResponsability.Tests.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class AsyncMiddlewareC : IAsyncMiddleware<Data>
    {
        public static string Start = $"Start {typeof(AsyncMiddlewareC).Name}";
        public static string End = $"End {typeof(AsyncMiddlewareC).Name}";
        public Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
        {
            context.Data.Steps.Add(Start);
            context.Data.Steps.Add(End);
            return Task.CompletedTask;
        }
    }
}
