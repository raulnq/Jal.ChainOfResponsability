using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public interface IAsyncPipelineUseBuilder<TData> 
    {
        IAsyncPipelineRunBuilder<TData> UseAsync<TMiddleware>() where TMiddleware : IAsyncMiddleware<TData>;

        IAsyncPipelineRunBuilder<TData> UseAsync(Type middlewaretype);

        IAsyncPipelineRunBuilder<TData> UseAsync(Func<AsyncContext<TData>, Func<AsyncContext<TData>, Task>, Task> middleware);
    }

}
