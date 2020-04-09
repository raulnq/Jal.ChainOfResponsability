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
    public async Task ExecuteAsync(AsyncContext<Data> context, Func<AsyncContext<Data>, Task> next)
    {
        return next(context);
    }
}
public class AsyncMiddlewareB : IAsyncMiddleware<Data>
{
    public Task ExecuteAsync(AsyncContext<Data> context, Func<AsyncContext<Data>, Task> next)
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

```csharp
var container = new WindsorContainer();

container.AddChainOfResponsability(c =>
{
    c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();
});

var pipeline = container.GetChainOfResponsability();
``` 
### LightInject [![NuGet](https://img.shields.io/nuget/v/Jal.ChainOfResponsability.LightInject.Installer.svg)](https://www.nuget.org/packages/Jal.ChainOfResponsability.LightInject.Installer)

```csharp
var container = new ServiceContainer();

container.AddChainOfResponsability(c=>
{
    c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();
});

var pipeline = container.GetChainOfResponsability();
``` 

### Microsoft.Extensions.DependencyInjection [![NuGet](https://img.shields.io/nuget/v/Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection.svg)](https://www.nuget.org/packages/Jal.ChainOfResponsability.Microsoft.Extensions.DependencyInjection)

```csharp
var container = new ServiceCollection();

container.AddChainOfResponsability(c=>
{
    c.AddAsyncMiddlewareForChain<AsyncMiddlewareA, Data>();

    c.AddAsyncMiddlewareForChain<AsyncMiddlewareB, Data>();
});

var provider = container.BuildServiceProvider();

var pipeline = provider.GetChainOfResponsability();
``` 
