using Microsoft.Extensions.DependencyInjection;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public class ChainOfResponsabilityBuilder : IChainOfResponsabilityBuilder
    {
        private readonly IServiceCollection _servicecollection;
        public ChainOfResponsabilityBuilder(IServiceCollection servicecollection)
        {
            _servicecollection = servicecollection;
        }

        public IChainOfResponsabilityBuilder AddAsyncMiddleware<TImplementation, TData>()
             where TImplementation : class, IAsyncMiddleware<TData>
        {
            _servicecollection.AddSingleton<IAsyncMiddleware<TData>, TImplementation>();

            return this;
        }

        public IChainOfResponsabilityBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>
        {
            _servicecollection.AddSingleton<IMiddleware<TData>, TImplementation>();

            return this;
        }
    }
}
