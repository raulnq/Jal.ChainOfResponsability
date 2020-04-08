using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jal.ChainOfResponsability.LightInject.Installer;
using Jal.ChainOfResponsability.Installer;
using Jal.ChainOfResponsability.Tests.Impl;
using Jal.ChainOfResponsability.Tests.Model;
using LightInject;
using Jal.Locator.LightInject;

namespace Jal.ChainOfResponsability.Tests.LightInject
{
    [TestClass]
    public class Tests
    {  
        [TestMethod]
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceContainer();

            container.AddChainOfResponsability(c=>
            {
                c.AddMiddlewareForChain<MiddlewareA, Data>();

                c.AddMiddlewareForChain<MiddlewareB, Data>();

                c.AddMiddlewareForChain<MiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            tests.Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceContainer();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            tests.Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceContainer();

            container.AddChainOfResponsability(c =>
            {
                c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            await tests.RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new ServiceContainer();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            await tests.RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }
    }
}
