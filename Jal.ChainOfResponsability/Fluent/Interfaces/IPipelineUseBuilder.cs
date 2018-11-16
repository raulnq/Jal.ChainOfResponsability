using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;

namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineUseBuilder<TData>
    {
        IPipelineRunBuilder<TData> Use<TMiddleware>() where TMiddleware: IMiddleware<TData>;

        IPipelineRunBuilder<TData> Use(Action<Context<TData>, Action<Context<TData>>> middleware);
    }

}
