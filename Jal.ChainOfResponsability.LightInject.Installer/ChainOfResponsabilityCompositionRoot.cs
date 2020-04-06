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

