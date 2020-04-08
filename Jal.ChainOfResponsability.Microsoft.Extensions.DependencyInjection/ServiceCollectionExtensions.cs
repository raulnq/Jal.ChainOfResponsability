using Jal.Locator.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChainOfResponsability(this IServiceCollection servicecollection, Action<IServiceCollection> action = null)
        {
            servicecollection.AddServiceLocator();

            servicecollection.TryAddSingleton<IPipeline, Pipeline>();

            servicecollection.TryAddSingleton<IPipelineBuilder, PipelineBuilder>();

            servicecollection.TryAddSingleton<IMiddlewareFactory, MiddlewareFactory>();

            if (action != null)
            {
                action(servicecollection);
            }

            return servicecollection;
        }

        public static IServiceCollection AddMiddlewareForChain<TImplementation, TData>(this IServiceCollection container) where TImplementation : class, IMiddleware<TData>
        {
            return container.AddSingleton<IMiddleware<TData>, TImplementation>();
        }

        public static IServiceCollection AddAsyncMiddlewareForChain<TImplementation, TData>(this IServiceCollection container) where TImplementation : class, IAsyncMiddleware<TData>
        {
            return container.AddSingleton<IAsyncMiddleware<TData>, TImplementation>();
        }
    }
}
