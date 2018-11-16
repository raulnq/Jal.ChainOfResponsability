using Jal.ChainOfResponsability.Fluent.Impl;
using Jal.ChainOfResponsability.Fluent.Interfaces;
using Jal.ChainOfResponsability.Impl;
using Jal.ChainOfResponsability.Intefaces;
using LightInject;


namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public class ChainOfResponsabilityCompositionRoot : ICompositionRoot
    {
        public void Compose(IServiceRegistry serviceRegistry)
        {
            serviceRegistry.Register<IPipeline, Pipeline>(new PerContainerLifetime());
            serviceRegistry.Register<IPipelineBuilder, PipelineBuilder>(new PerContainerLifetime());
            serviceRegistry.Register<IMiddlewareFactory, MiddlewareFactory>(new PerContainerLifetime());
        }
    }
}

