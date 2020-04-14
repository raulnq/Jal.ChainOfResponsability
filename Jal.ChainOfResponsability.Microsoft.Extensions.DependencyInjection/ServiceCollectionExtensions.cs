using Jal.Locator.Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddChainOfResponsability(this IServiceCollection servicecollection, Action<IMiddlewareBuilder> action = null)
        {
            servicecollection.AddServiceLocator();

            servicecollection.TryAddSingleton<IPipeline, Pipeline>();

            servicecollection.TryAddSingleton<IPipelineBuilder, PipelineBuilder>();

            servicecollection.TryAddSingleton<IMiddlewareFactory, MiddlewareFactory>();

            if (action != null)
            {
                action(new MiddlewareBuilder(servicecollection));
            }

            return servicecollection;
        }
    }
}
