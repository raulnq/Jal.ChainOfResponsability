using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Jal.Locator.CastleWindsor;
using System;

namespace Jal.ChainOfResponsability.Installer
{
    public class ChainOfResponsabilityInstaller : IWindsorInstaller
    {
        private readonly Action<IChainOfResponsabilityBuilder> _action;

        public ChainOfResponsabilityInstaller(Action<IChainOfResponsabilityBuilder> action = null)
        {
            _action = action;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.AddServiceLocator();

            if (!container.Kernel.HasComponent(typeof(IMiddlewareFactory)))
            {
                container.Register(Component.For<IMiddlewareFactory>().ImplementedBy<MiddlewareFactory>().Named(typeof(MiddlewareFactory).FullName).LifestyleSingleton());
            }

            if (!container.Kernel.HasComponent(typeof(IPipelineBuilder)))
            {
                container.Register(Component.For<IPipelineBuilder>().ImplementedBy<PipelineBuilder>().Named(typeof(PipelineBuilder).FullName).LifestyleSingleton());
            }

            if (!container.Kernel.HasComponent(typeof(IPipeline)))
            {
                container.Register(Component.For<IPipeline>().ImplementedBy<Pipeline>().Named(typeof(Pipeline).FullName).LifestyleSingleton());
            }

            if (_action != null)
            {
                _action(new ChainOfResponsabilityBuilder(container));
            }
        }
    }
}
