using Castle.MicroKernel.Registration;
using Castle.Windsor;
using System;

namespace Jal.ChainOfResponsability.Installer
{
    public static class WindsorContainerExtensions
    {
        public static void AddMiddlewareForChain<TImplementation, TData>(this IWindsorContainer container)
            where TImplementation : IMiddleware<TData>
        {
            container.Register(Component.For<IMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());
        }

        public static void AddAsyncMiddlewareForChain<TImplementation, TData>(this IWindsorContainer container)
            where TImplementation : IAsyncMiddleware<TData>
        {
            container.Register(Component.For<IAsyncMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());
        }

        public static void AddChainOfResponsability(this IWindsorContainer container, Action<IWindsorContainer> action = null)
        {
            container.Install(new ChainOfResponsabilityInstaller(action));
        }
    }
}
