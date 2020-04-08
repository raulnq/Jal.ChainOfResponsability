using Jal.Locator.LightInject;
using LightInject;
using System;
using System.Linq;

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
            container.AddServiceLocator();

            if (container.AvailableServices.All(x => x.ServiceType != typeof(IPipeline)))
            {
                container.Register<IPipeline, Pipeline>(new PerContainerLifetime());
            }

            if (container.AvailableServices.All(x => x.ServiceType != typeof(IPipelineBuilder)))
            {
                container.Register<IPipelineBuilder, PipelineBuilder>(new PerContainerLifetime());
            }

            if (container.AvailableServices.All(x => x.ServiceType != typeof(IMiddlewareFactory)))
            {
                container.Register<IMiddlewareFactory, MiddlewareFactory>(new PerContainerLifetime());
            }
            
            if (action != null)
            {
                action(container);
            }
        }
    }
}

