using LightInject;

namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public class MiddlewareBuilder : IMiddlewareBuilder
    {
        private readonly IServiceContainer _container;
        public MiddlewareBuilder(IServiceContainer container)
        {
            _container = container;
        }

        public IMiddlewareBuilder AddAsyncMiddleware<TImplementation, TData>()
             where TImplementation : class, IAsyncMiddleware<TData>
        {
            _container.Register<IAsyncMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());

            return this;
        }

        public IMiddlewareBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>
        {
            _container.Register<IMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());

            return this;
        }
    }
}

