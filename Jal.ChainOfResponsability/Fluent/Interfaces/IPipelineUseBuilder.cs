using System;

namespace Jal.ChainOfResponsability
{
    public interface IPipelineUseBuilder<TData>
    {
        IPipelineRunBuilder<TData> Use<TMiddleware>() where TMiddleware: IMiddleware<TData>;

        IPipelineRunBuilder<TData> Use(Type middlewaretype);

        IPipelineRunBuilder<TData> Use(Action<Context<TData>, Action<Context<TData>>> middleware);
    }

}
