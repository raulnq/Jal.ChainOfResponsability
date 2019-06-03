using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineUseBuilderAsync<TData> 
    {
        IPipelineRunBuilderAsync<TData> UseAsync<TMiddleware>(string middlewarename = null) where TMiddleware : IMiddlewareAsync<TData>;

        IPipelineRunBuilderAsync<TData> UseAsync(Type middlewaretype, string middlewarename = null);

        IPipelineRunBuilderAsync<TData> UseAsync(Func<Context<TData>, Func<Context<TData>, Task>, Task> middleware);
    }

}
