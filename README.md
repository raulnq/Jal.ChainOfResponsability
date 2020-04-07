# Jal.ChainOfResponsability [![NuGet](https://img.shields.io/nuget/v/Jal.Factory.svg)](https://www.nuget.org/packages/Jal.Factory) 
Just another library to implement the chain of responsability pattern

## How to use?
Define your model.
```csharp
public class Data
{
    
}
```
Define your middlewares.
```csharp
public class AsyncMiddlewareA : IAsyncMiddleware<Data>
{
    public async Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
    {
        return next(context);
    }
}
public class AsyncMiddlewareB : IAsyncMiddleware<Data>
{
    public Task ExecuteAsync(Context<Data> context, Func<Context<Data>, Task> next)
    {
        return Task.CompletedTask;
    }
}
```
Setup and run the chain.
```csharp
var data = new Data();

await pipeline
.ForAsync<Data>()
.UseAsync<AsyncMiddlewareA>()
.UseAsync<AsyncMiddlewareB>()
.RunAsync(data);
```
## IPipelineBuilder interface building

### Castle Windsor [![NuGet](https://img.shields.io/nuget/v/Jal.ChainOfResponsability.Installer.svg)](https://www.nuget.org/packages/Jal.ChainOfResponsability.Installer)

The [Jal.Locator.CastleWindsor](https://www.nuget.org/packages/Jal.Locator.CastleWindsor/) library is needed.

```csharp
var container = new WindsorContainer();

container.Kernel.Resolver.AddSubResolver(new CollectionResolver(container.Kernel));

container.AddServiceLocator();

container.AddChainOfResponsability(c =>
{
    c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();
});

var pipeline = container.Resolve<IPipelineBuilder>();
``` 
### LightInject [![NuGet](https://img.shields.io/nuget/v/Jal.ChainOfResponsability.LightInject.Installer.svg)](https://www.nuget.org/packages/Jal.ChainOfResponsability.LightInject.Installer)

The [Jal.Locator.LightInject](https://www.nuget.org/packages/Jal.Locator.LightInject/) library is needed. 

```csharp
var container = new ServiceContainer();

container.AddServiceLocator();

container.AddChainOfResponsability(c=>
{
    c.AddAsyncMiddlewareForChain<MiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<MiddlewareB, Data>();
});

var pipeline = container.GetInstance<IPipelineBuilder>();
``` 

### Microsoft.Extensions.DependencyInjection [![NuGet](https://img.shields.io/nuget/v/Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection.svg)](https://www.nuget.org/packages/Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection)

The [Jal.Locator.Microsoft.Extensions.DependencyInjection](https://www.nuget.org/packages/Jal.Locator.Microsoft.Extensions.DependencyInjection/) library is needed. 

```csharp
var container = new ServiceCollection();

container.AddServiceLocator();

container.AddChainOfResponsability(c=>
{
    c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();
});

var provider = container.BuildServiceProvider();

var pipeline = provider.GetService<IPipelineBuilder>();
``` 
