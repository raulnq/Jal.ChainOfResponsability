using Microsoft.Extensions.DependencyInjection;
using System;

namespace Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection
{
    public static class ServiceProviderExtensions
    {
        public static IPipelineBuilder GetChainOfResponsability(this IServiceProvider provider)
        {
            return provider.GetService<IPipelineBuilder>();
        }
    }
}
