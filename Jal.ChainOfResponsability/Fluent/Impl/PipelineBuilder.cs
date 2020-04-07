using System;
using System.Collections.Generic;
using System.Threading;
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

        private List<AsyncMiddlewareConfiguration<TData>> _asyncmetadata;

        public PipelineBuilder(IPipeline pipeline)
        {
            _pipeline = pipeline;

            _metadata = new List<MiddlewareConfiguration<TData>>();

            _asyncmetadata = new List<AsyncMiddlewareConfiguration<TData>>();
        }

        public void Run(TData data)
        {
            _pipeline.Execute<TData>(_metadata.ToArray(), data);
        }

        public Task RunAsync(TData data, CancellationToken token = default(CancellationToken))
        {
            return _pipeline.ExecuteAsync<TData>(_asyncmetadata.ToArray(), data, token);
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

        public IAsyncPipelineRunBuilder<TData> UseAsync(Func<AsyncContext<TData>, Func<AsyncContext<TData>, Task>, Task> middleware)
        {
            _asyncmetadata.Add(new AsyncMiddlewareConfiguration<TData>() { AsyncMiddleware = middleware });

            return this;
        }

        public IAsyncPipelineRunBuilder<TData> UseAsync<TMiddleware>() where TMiddleware : IAsyncMiddleware<TData>
        {
            _asyncmetadata.Add(new AsyncMiddlewareConfiguration<TData>() { StronglyTypedMiddleware = typeof(TMiddleware)});

            return this;
        }

        public IAsyncPipelineRunBuilder<TData> UseAsync(Type middlewaretype)
        {
            _asyncmetadata.Add(new AsyncMiddlewareConfiguration<TData>() { StronglyTypedMiddleware = middlewaretype});

            return this;
        }
    }
}
