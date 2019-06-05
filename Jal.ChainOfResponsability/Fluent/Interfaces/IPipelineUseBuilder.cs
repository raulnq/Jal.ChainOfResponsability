using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;

namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineUseBuilder<TData>
    {
        IPipelineRunBuilder<TData> Use<TMiddleware>() where TMiddleware: IMiddleware<TData>;

        IPipelineRunBuilder<TData> Use(Type middlewaretype);

        IPipelineRunBuilder<TData> Use<TMiddleware>(string middlewarename) where TMiddleware : IMiddleware<TData>;

        IPipelineRunBuilder<TData> Use(Type middlewaretype, string middlewarename);

        IPipelineRunBuilder<TData> Use(Action<Context<TData>, Action<Context<TData>>> middleware);
    }

}
