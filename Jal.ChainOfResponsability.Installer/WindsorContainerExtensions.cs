using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Jal.ChainOfResponsability.Installer
{
    public static class WindsorContainerExtensions
    {
        public static void RegisterMiddlewareForChain<TImplementation, TData>(this IWindsorContainer container)
            where TImplementation : IMiddleware<TData>
        {
            container.Register(Component.For<IMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());
        }

        public static void RegisterAsyncMiddlewareForChain<TImplementation, TData>(this IWindsorContainer container)
            where TImplementation : IAsyncMiddleware<TData>
        {
            container.Register(Component.For<IAsyncMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());
        }
    }
}
