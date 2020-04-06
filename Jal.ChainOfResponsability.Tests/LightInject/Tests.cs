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
    public class Tests : AbstractTests
    {  
        [TestMethod]
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<ServiceLocatorCompositionRoot>();

            container.RegisterChainOfResponsability(c=>
            {
                c.RegisterMiddlewareForChain<MiddlewareA, Data>();

                c.RegisterMiddlewareForChain<MiddlewareB, Data>();

                c.RegisterMiddlewareForChain<MiddlewareC, Data>();
            });



            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<ServiceLocatorCompositionRoot>();

            container.RegisterChainOfResponsability();

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<ServiceLocatorCompositionRoot>();

            container.RegisterChainOfResponsability(c =>
            {
                c.RegisterAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

                c.RegisterAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();

                c.RegisterAsyncMiddlewareForChain<AsyncMiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            await RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var container = new ServiceContainer();

            container.RegisterFrom<ServiceLocatorCompositionRoot>();

            container.RegisterChainOfResponsability();

            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();

            await RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }
    }
}
