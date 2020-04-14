using Microsoft.Extensions.DependencyInjection;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public class MiddlewareBuilder : IMiddlewareBuilder
    {
        private readonly IServiceCollection _servicecollection;
        public MiddlewareBuilder(IServiceCollection servicecollection)
        {
            _servicecollection = servicecollection;
        }

        public IMiddlewareBuilder AddAsyncMiddleware<TImplementation, TData>()
             where TImplementation : class, IAsyncMiddleware<TData>
        {
            _servicecollection.AddSingleton<IAsyncMiddleware<TData>, TImplementation>();

            return this;
        }

        public IMiddlewareBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>
        {
            _servicecollection.AddSingleton<IMiddleware<TData>, TImplementation>();

            return this;
        }
    }
}
