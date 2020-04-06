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
    public class Tests : AbstractTests
    {  
        [TestMethod]
        public void Run_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(new ServiceLocatorInstaller());

            container.Install(new ChainOfResponsabilityInstaller());

            container.RegisterMiddlewareForChain<MiddlewareA, Data>();

            container.RegisterMiddlewareForChain<MiddlewareB, Data>();

            container.RegisterMiddlewareForChain<MiddlewareC, Data>();

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            Run_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public void Run_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(new ServiceLocatorInstaller());

            container.Install(new ChainOfResponsabilityInstaller());

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            Run_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted()
        {
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(new ServiceLocatorInstaller());

            container.Install(new ChainOfResponsabilityInstaller());

            container.RegisterAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

            container.RegisterAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();

            container.RegisterAsyncMiddlewareForChain<AsyncMiddlewareC, Data>();

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            await RunAsync_WithStrongTypedMiddleware_ShouldBeExecuted(pipeline);
        }

        [TestMethod]
        public async Task RunAsync_WithAnonymousMiddleware_ShouldBeExecuted()
        {
            var container = new WindsorContainer();

            container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

            container.Install(new ServiceLocatorInstaller());

            container.Install(new ChainOfResponsabilityInstaller());

            IPipelineBuilder pipeline = container.Resolve<IPipelineBuilder>();

            await RunAsync_WithAnonymousMiddleware_ShouldBeExecuted(pipeline);
        }
    }
}
