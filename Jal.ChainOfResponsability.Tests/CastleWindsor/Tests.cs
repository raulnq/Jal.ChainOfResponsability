using System;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Jal.ChainOfResponsability.LightInject.Installer;
using Castle.Windsor;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Jal.Locator.CastleWindsor;
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

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddServiceLocator();

            container.AddChainOfResponsability(c=>
            {
                c.AddMiddlewareForChain<MiddlewareA, Data>();

                c.AddMiddlewareForChain<MiddlewareB, Data>();

                c.AddMiddlewareForChain<MiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            tests.Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddServiceLocator();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            tests.Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddServiceLocator();

            container.AddChainOfResponsability(c =>
            {
                c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareC, Data>();
            });

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            await tests.RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddServiceLocator();

            container.AddChainOfResponsability();

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            await tests.RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithCancellationToken_ShouldBeThrowException()
        {
            var tests = new TestCases();

            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.AddServiceLocator();

            container.AddChainOfResponsability(c =>
            {
                c.AddAsyncMiddlewareForChain<AsyncMiddlewareD, Data>();

                c.AddAsyncMiddlewareForChain<AsyncMiddlewareE, Data>();
            });

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            await tests.RunAsync_WithCancellationToken_ShouldBeThrowException(pipeline);
        }
    }
}
