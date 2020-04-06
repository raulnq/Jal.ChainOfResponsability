using LightInject;

namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public static class ServiceContainerExtension
    {
        public static void RegisterMiddlewareForChain<TImplementation, TData>(this IServiceContainer container) where TImplementation : IMiddleware<TData>
        {
            container.Register<IMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());
        }

        public static void RegisterAsyncMiddlewareForChain<TImplementation, TData>(this IServiceContainer container) where TImplementation : IAsyncMiddleware<TData>
        {
            container.Register<IAsyncMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());
        }
    }
}

