using Jal.ChainOfResponsability.Fluent.Impl;
using Jal.ChainOfResponsability.Fluent.Interfaces;
using Jal.ChainOfResponsability.Impl;
using Jal.ChainOfResponsability.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChainOfResponsability(this IServiceCollection servicecollection)
        {
            servicecollection.AddSingleton<IPipeline, Pipeline>();

            servicecollection.AddSingleton<IPipelineBuilder, PipelineBuilder>();

            servicecollection.AddSingleton<IMiddlewareFactory, MiddlewareFactory>();

            return servicecollection;
        }
    }
}
