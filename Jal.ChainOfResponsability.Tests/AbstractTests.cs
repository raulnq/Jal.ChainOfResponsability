using System.Threading.Tasks;
using Jal.ChainOfResponsability.Tests.Impl;
using Jal.ChainOfResponsability.Tests.Model;
using Shouldly;

namespace Jal.ChainOfResponsability.Tests
{
    public class TestCases
    {
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted(IPipelineBuilder pipeline)
        {
            var data = new Data();

            pipeline.For<Data>().Use<MiddlewareA>().Use<MiddlewareB>().Use<MiddlewareC>().Run(data);

            data.Steps[0].ShouldBe(MiddlewareA.Start);

            data.Steps[1].ShouldBe(MiddlewareB.Start);

            data.Steps[2].ShouldBe(MiddlewareC.Start);

            data.Steps[3].ShouldBe(MiddlewareC.End);

            data.Steps[4].ShouldBe(MiddlewareB.End);

            data.Steps[5].ShouldBe(MiddlewareA.End);
        }

        public void Run_WithAnonymousMiddleware_ShouldBeExecuted(IPipelineBuilder pipeline)
        {
            var data = new Data();

            pipeline.For<Data>()
            .Use((c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous A");
                next(c);
                c.Data.Steps.Add("End Anonymous A");
            })
            .Use((c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous B");
                next(c);
                c.Data.Steps.Add("End Anonymous B");
            })
            .Use((c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous C");
                c.Data.Steps.Add("End Anonymous C");
            })
            .Run(data);

            data.Steps[0].ShouldBe("Start Anonymous A");

            data.Steps[1].ShouldBe("Start Anonymous B");

            data.Steps[2].ShouldBe("Start Anonymous C");

            data.Steps[3].ShouldBe("End Anonymous C");

            data.Steps[4].ShouldBe("End Anonymous B");

            data.Steps[5].ShouldBe("End Anonymous A");
        }

        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(IPipelineBuilder pipeline)
        {
            var data = new Data();

            await pipeline.ForAsync<Data>().UseAsync<AsyncMiddlewareA>().UseAsync<AsyncMiddlewareB>().UseAsync<AsyncMiddlewareC>().RunAsync(data);

            data.Steps[0].ShouldBe(AsyncMiddlewareA.Start);

            data.Steps[1].ShouldBe(AsyncMiddlewareB.Start);

            data.Steps[2].ShouldBe(AsyncMiddlewareC.Start);

            data.Steps[3].ShouldBe(AsyncMiddlewareC.End);

            data.Steps[4].ShouldBe(AsyncMiddlewareB.End);

            data.Steps[5].ShouldBe(AsyncMiddlewareA.End);
        }

        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(IPipelineBuilder pipeline)
        {
            var data = new Data();

            await pipeline.ForAsync<Data>()
            .UseAsync(async (c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous A");
                await next(c);
                c.Data.Steps.Add("End Anonymous A");
            })
            .UseAsync(async (c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous B");
                await next(c);
                c.Data.Steps.Add("End Anonymous B");
            })
            .UseAsync((c, next) =>
            {
                c.Data.Steps.Add("Start Anonymous C");
                c.Data.Steps.Add("End Anonymous C");
                return Task.CompletedTask;
            })
            .RunAsync(data);

            data.Steps[0].ShouldBe("Start Anonymous A");

            data.Steps[1].ShouldBe("Start Anonymous B");

            data.Steps[2].ShouldBe("Start Anonymous C");

            data.Steps[3].ShouldBe("End Anonymous C");

            data.Steps[4].ShouldBe("End Anonymous B");

            data.Steps[5].ShouldBe("End Anonymous A");
        }
    }
}
