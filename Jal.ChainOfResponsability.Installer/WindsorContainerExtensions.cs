using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace Jal.ChainOfResponsability.Installer
{
    public static class WindsorContainerExtensions
    {
        public static void AddChainOfResponsability(this IWindsorContainer container, Action<IMiddlewareBuilder> action = null)
        {
            container.Install(new ChainOfResponsabilityInstaller(action));
        }

        public static IPipelineBuilder GetChainOfResponsability(this IWindsorContainer container)
        {
            return container.Resolve<IPipelineBuilder>();
        }
    }
}
