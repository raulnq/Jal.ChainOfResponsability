using System;
using System.Threading.Tasks;
using Jal.ChainOfResponsability.Fluent.Interfaces;
using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using Jal.Locator.LightInject.Installer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LightInject;
using Jal.ChainOfResponsability.LightInject.Installer;

namespace Jal.ChainOfResponsability.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var container = new ServiceContainer();
            container.RegisterFrom<ServiceLocatorCompositionRoot>();
            container.RegisterFrom<ChainOfResponsabilityCompositionRoot>();
            container.Register<IMiddleware<Data>, MiddlewareB>(new PerContainerLifetime());
            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();
            var data = new Data();
            pipeline.For<Data>().Use((c, next) => {
                next(c);
            }).Use<MiddlewareB>().Run(data);
        }

        [TestMethod]
        public async Task TestMethod2()
        {
            var container = new ServiceContainer();
            container.RegisterFrom<ServiceLocatorCompositionRoot>();
            container.RegisterFrom<ChainOfResponsabilityCompositionRoot>();
            container.Register<IMiddlewareAsync<Data>, MiddlewareD>(new PerContainerLifetime());
            IPipelineBuilder pipeline = container.GetInstance<IPipelineBuilder>();
            var data = new Data();
            await pipeline.ForAsync<Data>().UseAsync(async (c, next)=> {
                await next(c);
            }).UseAsync<MiddlewareD>().RunAsync(data);

            
        }
    }

    public class Data
    {

    }

    public class MiddlewareA : IMiddleware<Data>
    {
        public void Execute(Context<Data> context, Action<Context<Data>> next)
        {

        }
    }

    public class MiddlewareB : IMiddleware<Data>
    {
        public void Execute(Context<Data> context, Action<Context<Data>> next)
        {
           
        }
    }

    public class MiddlewareC : IMiddlewareAsync<Data>
    {
        public async Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
        {
            await Task.FromResult<int>(0);
        }
    }

    public class MiddlewareD : IMiddlewareAsync<Data>
    {
        public async Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
        {
            await Task.FromResult<int>(0);
        }
    }
}
