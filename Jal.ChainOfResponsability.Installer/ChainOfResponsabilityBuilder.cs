using Castle.MicroKernel.Registration;
using Castle.Windsor;

namespace Jal.ChainOfResponsability.Installer
{
    public class ChainOfResponsabilityBuilder : IChainOfResponsabilityBuilder
    {
        private readonly IWindsorContainer _container;
        public ChainOfResponsabilityBuilder(IWindsorContainer container)
        {
            _container = container;
        }

        public IChainOfResponsabilityBuilder AddAsyncMiddleware<TImplementation, TData>()
             where TImplementation : class, IAsyncMiddleware<TData>
        {
            _container.Register(Component.For<IAsyncMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());

            return this;
        }

        public IChainOfResponsabilityBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>
        {
            _container.Register(Component.For<IMiddleware<TData>>().ImplementedBy<TImplementation>().Named(typeof(TImplementation).FullName).LifestyleSingleton());

            return this;
        }
    }
}
