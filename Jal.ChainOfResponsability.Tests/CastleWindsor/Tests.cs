using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jal.ChainOfResponsability.LightInject.Installer;
using Castle.Windsor;
using Jal.ChainOfResponsability.Installer;
using Jal.ChainOfResponsability.Tests.Impl;
using Jal.ChainOfResponsability.Tests.Model;

namespace Jal.ChainOfResponsability.Tests.CastleWindsor
{
    [TestClass]
    public class Tests
    {  
        [TestMethod]
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.AddChainOfResponsability(c=>
            {
                c.AddMiddleware<MiddlewareA, Data>();

                c.AddMiddleware<MiddlewareB, Data>();

                c.AddMiddleware<MiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.GetChainOfResponsability();

            tests.Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.GetChainOfResponsability();

            tests.Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.AddChainOfResponsability(c =>
            {
                c.AddAsyncMiddleware<AsyncMiddlewareA, Data>();

                c.AddAsyncMiddleware<AsyncMiddlewareB, Data>();

                c.AddAsyncMiddleware<AsyncMiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.GetChainOfResponsability();

            await tests.RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.GetChainOfResponsability();

            await tests.RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithCancellationToken_ShouldBeThrowException()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.AddChainOfResponsability(c =>
            {
                c.AddAsyncMiddleware<AsyncMiddlewareD, Data>();

                c.AddAsyncMiddleware<AsyncMiddlewareE, Data>();
            });

            IPipelineBuilder pipeline = container.GetChainOfResponsability();

            await tests.RunAsync_WithCancellationToken_ShouldBeThrowException(pipeline);
        }
    }
}
