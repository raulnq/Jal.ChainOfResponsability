using Jal.Locator.LightInject;
using LightInject;
using System;
using System.Linq;

namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public static class ServiceContainerExtension
    {
        public static IPipelineBuilder GetChainOfResponsability(this IServiceContainer container)
        {
            return container.GetInstance<IPipelineBuilder>();
        }

        public static void AddChainOfResponsability(this IServiceContainer container, Action<IChainOfResponsabilityBuilder> action = null)
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
                action(new ChainOfResponsabilityBuilder(container));
            }
        }
    }
}

