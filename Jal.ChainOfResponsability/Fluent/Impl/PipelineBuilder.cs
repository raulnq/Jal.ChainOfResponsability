using Jal.ChainOfResponsability.Fluent.Interfaces;
using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Fluent.Impl
{
    public class PipelineBuilder : IPipelineBuilder
    {
        private readonly IPipeline _pipeline;

        public PipelineBuilder(IPipeline pipeline)
        {
            _pipeline = pipeline;
        }

        public IPipelineUseBuilder<TData> For<TData>()
        {
            return new PipelineBuilder<TData>(_pipeline);
        }

        public IPipelineUseBuilderAsync<TData> ForAsync<TData>()
        {
            return new PipelineBuilder<TData>(_pipeline);
        }
    }

    public class PipelineBuilder<TData> : IPipelineUseBuilder<TData>, IPipelineRunBuilder<TData>, IPipelineRunBuilderAsync<TData>, IPipelineUseBuilderAsync<TData>
    {
        private IPipeline _pipeline;

        private List<MiddlewareMetadata<TData>> _metadata;

        public PipelineBuilder(IPipeline pipeline)
        {
            _pipeline = pipeline;

            _metadata = new List<MiddlewareMetadata<TData>>();
        }

        public void Run(TData data)
        {
            _pipeline.Execute<TData>(_metadata.ToArray(), data);
        }

        public async Task RunAsync(TData data)
        {
            await _pipeline.ExecuteAsync<TData>(_metadata.ToArray(), data);
        }

        public IPipelineRunBuilder<TData> Use<TMiddleware>() where TMiddleware : IMiddleware<TData>
        {
            _metadata.Add(new MiddlewareMetadata<TData>() { StronglyTypedMiddleware = typeof(TMiddleware) });

            return this;
        }

        public IPipelineRunBuilder<TData> Use(Action<Context<TData>, Action<Context<TData>>> middleware)
        {
            _metadata.Add(new MiddlewareMetadata<TData>() { Middleware = middleware });

            return this;
        }

        public IPipelineRunBuilderAsync<TData> UseAsync(Func<Context<TData>, Func<Context<TData>, Task>, Task> middleware)
        {
            _metadata.Add(new MiddlewareMetadata<TData>() { AsyncMiddleware = middleware });

            return this;
        }

        public IPipelineRunBuilderAsync<TData> UseAsync<TMiddleware>() where TMiddleware : IMiddlewareAsync<TData>
        {
            _metadata.Add(new MiddlewareMetadata<TData>() { StronglyTypedMiddleware = typeof(TMiddleware) });

            return this;
        }
    }
}
