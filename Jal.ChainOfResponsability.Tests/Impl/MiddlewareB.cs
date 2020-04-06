using Jal.ChainOfResponsability.Tests.Model;
using System;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class MiddlewareB : IMiddleware<Data>
    {
        public static string Start = $"Start {typeof(MiddlewareB).Name}";
        public static string End = $"End {typeof(MiddlewareB).Name}";
        public void Execute(Context<Data> context, Action<Context<Data>> next)
        {
            context.Data.Steps.Add(Start);
            next(context);
            context.Data.Steps.Add(End);
        }
    }
}
