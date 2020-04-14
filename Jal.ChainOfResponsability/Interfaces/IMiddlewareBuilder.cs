namespace Jal.ChainOfResponsability
{
    public interface IMiddlewareBuilder
    {
        IMiddlewareBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>;

        IMiddlewareBuilder AddAsyncMiddleware<TImplementation, TData>()
            where TImplementation : class, IAsyncMiddleware<TData>;
    }
}
