using LightInject;
using System;

namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public static class ServiceContainerExtension
    {
        public static void AddMiddlewareForChain<TImplementation, TData>(this IServiceContainer container) where TImplementation : IMiddleware<TData>
        {
            container.Register<IMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());
        }

        public static void AddAsyncMiddlewareForChain<TImplementation, TData>(this IServiceContainer container) where TImplementation : IAsyncMiddleware<TData>
        {
            container.Register<IAsyncMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());
        }

        public static void AddChainOfResponsability(this IServiceContainer container, Action<IServiceContainer> action = null)
        {
            container.Register<IPipeline, Pipeline>(new PerContainerLifetime());

            container.Register<IPipelineBuilder, PipelineBuilder>(new PerContainerLifetime());

            container.Register<IMiddlewareFactory, MiddlewareFactory>(new PerContainerLifetime());

            if (action != null)
            {
                action(container);
            }
        }
    }
}

