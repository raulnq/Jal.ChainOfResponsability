using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
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

        public IAsyncPipelineUseBuilder<TData> ForAsync<TData>()
        {
            return new PipelineBuilder<TData>(_pipeline);
        }
    }

    public class PipelineBuilder<TData> : IPipelineUseBuilder<TData>, IPipelineRunBuilder<TData>, IAsyncPipelineRunBuilder<TData>, IAsyncPipelineUseBuilder<TData>
    {
        private IPipeline _pipeline;

        private List<MiddlewareConfiguration<TData>> _metadata;

        public PipelineBuilder(IPipeline pipeline)
        {
            _pipeline = pipeline;

            _metadata = new List<MiddlewareConfiguration<TData>>();
        }

        public void Run(TData data)
        {
            _pipeline.Execute<TData>(_metadata.ToArray(), data);
        }

        public Task RunAsync(TData data)
        {
            return _pipeline.ExecuteAsync<TData>(_metadata.ToArray(), data);
        }

        public IPipelineRunBuilder<TData> Use<TMiddleware>() where TMiddleware : IMiddleware<TData>
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { StronglyTypedMiddleware = typeof(TMiddleware)});

            return this;
        }

        public IPipelineRunBuilder<TData> Use(Action<Context<TData>, Action<Context<TData>>> middleware)
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { Middleware = middleware });

            return this;
        }

        public IPipelineRunBuilder<TData> Use(Type middlewaretype)
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { StronglyTypedMiddleware = middlewaretype });

            return this;
        }

        public IAsyncPipelineRunBuilder<TData> UseAsync(Func<Context<TData>, Func<Context<TData>, Task>, Task> middleware)
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { AsyncMiddleware = middleware });

            return this;
        }

        public IAsyncPipelineRunBuilder<TData> UseAsync<TMiddleware>() where TMiddleware : IAsyncMiddleware<TData>
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { StronglyTypedMiddleware = typeof(TMiddleware)});

            return this;
        }

        public IAsyncPipelineRunBuilder<TData> UseAsync(Type middlewaretype)
        {
            _metadata.Add(new MiddlewareConfiguration<TData>() { StronglyTypedMiddleware = middlewaretype});

            return this;
        }
    }
}
