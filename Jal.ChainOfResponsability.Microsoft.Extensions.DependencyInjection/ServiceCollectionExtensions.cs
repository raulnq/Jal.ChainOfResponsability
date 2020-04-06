using Microsoft.Extensions.DependencyInjection;

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
