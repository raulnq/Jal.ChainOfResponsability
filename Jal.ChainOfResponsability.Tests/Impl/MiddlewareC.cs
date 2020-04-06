using Jal.ChainOfResponsability.Tests.Model;
using System;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class MiddlewareC : IMiddleware<Data>
    {
        public static string Start = $"Start {typeof(MiddlewareC).Name}";
        public static string End = $"End {typeof(MiddlewareC).Name}";
        public void Execute(Context<Data> context, Action<Context<Data>> next)
        {
            context.Data.Steps.Add(Start);
            context.Data.Steps.Add(End);
        }
    }
}
