﻿using Jal.ChainOfResponsability.Tests.Model;
using System;

namespace Jal.ChainOfResponsability.Tests.Impl
{
    public class MiddlewareA : IMiddleware<Data>
    {
        public static string Start = $"Start {typeof(MiddlewareA).Name}";
        public static string End = $"End {typeof(MiddlewareA).Name}";
        public void Execute(Context<Data> context, Action<Context<Data>> next)
        {
            context.Data.Steps.Add(Start);
            next(context);
            context.Data.Steps.Add(End);
        }
    }
}
