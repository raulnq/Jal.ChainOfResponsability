using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineUseBuilderAsync<TData> 
    {
        IPipelineRunBuilderAsync<TData> UseAsync<TMiddleware>() where TMiddleware : IMiddlewareAsync<TData>;

        IPipelineRunBuilderAsync<TData> UseAsync(Func<Context<TData>, Func<Context<TData>, Task>, Task> middleware);
    }

}
