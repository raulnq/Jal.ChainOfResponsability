using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jal.ChainOfResponsability.Tests.Impl;
using Jal.ChainOfResponsability.Tests.Model;
using Microsoft.Extensions.DependencyInjection;
using Jal.Locator.Microsoft.Extensions.DependencyInjection;
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

            container.AddServiceLocator();

            container.AddChainOfResponsability(c=>
            {
                c.AddMiddlewareForChain<MiddlewareA, Data>();

                c.AddMiddlewareForChain<MiddlewareB, Data>();

                c.AddMiddlewareForChain<MiddlewareC, Data>();
            });

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetService<IPipelineBuilder>();

            tests.Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddServiceLocator();

            container.AddChainOfResponsability();

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetService<IPipelineBuilder>();

            tests.Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddServiceLocator();

            container.AddChainOfResponsability(c=>
            {
                c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareC, Data>();
            });

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetService<IPipelineBuilder>();

            await tests.RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceCollection();

            container.AddServiceLocator();

            container.AddChainOfResponsability();

            var provider = container.BuildServiceProvider();

            IPipelineBuilder pipeline = provider.GetService<IPipelineBuilder>();

            await tests.RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }
    }
}
