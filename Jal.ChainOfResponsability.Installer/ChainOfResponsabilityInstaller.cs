using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Jal.ChainOfResponsability.Fluent.Impl;
using Jal.ChainOfResponsability.Fluent.Interfaces;
using Jal.ChainOfResponsability.Impl;
using Jal.ChainOfResponsability.Intefaces;

namespace Jal.ChainOfResponsability.Installer
{
    public class ChainOfResponsabilityInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IMiddlewareFactory>().ImplementedBy<MiddlewareFactory>().Named(typeof(MiddlewareFactory).FullName).LifestyleSingleton());

            container.Register(Component.For<IPipelineBuilder>().ImplementedBy<PipelineBuilder>().Named(typeof(PipelineBuilder).FullName).LifestyleSingleton());

            container.Register(Component.For<IPipeline>().ImplementedBy<Pipeline>().Named(typeof(Pipeline).FullName).LifestyleSingleton());
        }
    }
}
