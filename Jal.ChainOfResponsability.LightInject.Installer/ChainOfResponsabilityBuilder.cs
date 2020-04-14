using LightInject;

namespace Jal.ChainOfResponsability.LightInject.Installer
{
    public class ChainOfResponsabilityBuilder : IChainOfResponsabilityBuilder
    {
        private readonly IServiceContainer _container;
        public ChainOfResponsabilityBuilder(IServiceContainer container)
        {
            _container = container;
        }

        public IChainOfResponsabilityBuilder AddAsyncMiddleware<TImplementation, TData>()
             where TImplementation : class, IAsyncMiddleware<TData>
        {
            _container.Register<IAsyncMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());

            return this;
        }

        public IChainOfResponsabilityBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>
        {
            _container.Register<IMiddleware<TData>, TImplementation>(typeof(TImplementation).FullName, new PerContainerLifetime());

            return this;
        }
    }
}

