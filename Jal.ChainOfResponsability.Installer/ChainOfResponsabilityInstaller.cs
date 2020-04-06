using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using System;

namespace Jal.ChainOfResponsability.Installer
{
    public class ChainOfResponsabilityInstaller : IWindsorInstaller
    {
        private readonly Action<IWindsorContainer> _action;

        public ChainOfResponsabilityInstaller(Action<IWindsorContainer> action = null)
        {
            _action = action;
        }

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMiddlewareFactory>().ImplementedBy<MiddlewareFactory>().Named(typeof(MiddlewareFactory).FullName).LifestyleSingleton());

            container.Register(Component.For<IPipelineBuilder>().ImplementedBy<PipelineBuilder>().Named(typeof(PipelineBuilder).FullName).LifestyleSingleton());

            container.Register(Component.For<IPipeline>().ImplementedBy<Pipeline>().Named(typeof(Pipeline).FullName).LifestyleSingleton());

            if (_action != null)
            {
                _action(container);
            }
        }
    }
}
