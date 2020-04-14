using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jal.ChainOfResponsability.Tests.Impl;
using Jal.ChainOfResponsability.Tests.Model;
using Microsoft.Extensions.DependencyInjection;
using Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection;

namespace Jal.ChainOfResponsability.Tests.Microsoft.Extensions.DependencyInjection
{
    [TestClass]
    public class Tests
    {  
        [TestMethod]
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddChainOfResponsability(c=>
            {
                c.AddMiddleware<MiddlewareA, Data>();

                c.AddMiddleware<MiddlewareB, Data>();

                c.AddMiddleware<MiddlewareC, Data>();
            });

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetChainOfResponsability();

            tests.Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddChainOfResponsability();

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetChainOfResponsability();

            tests.Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddChainOfResponsability(c=>
            {
                c.AddAsyncMiddleware<AsyncMiddlewareA, Data>();

                c.AddAsyncMiddleware<AsyncMiddlewareB, Data>();

                c.AddAsyncMiddleware<AsyncMiddlewareC, Data>();
            });

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetChainOfResponsability();

            await tests.RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddChainOfResponsability();

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetChainOfResponsability();

            await tests.RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }
    }
}
