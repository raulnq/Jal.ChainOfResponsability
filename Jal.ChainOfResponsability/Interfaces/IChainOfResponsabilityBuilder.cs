namespace Jal.ChainOfResponsability
{
    public interface IChainOfResponsabilityBuilder
    {
        IChainOfResponsabilityBuilder AddMiddleware<TImplementation, TData>()
            where TImplementation : class, IMiddleware<TData>;

        IChainOfResponsabilityBuilder AddAsyncMiddleware<TImplementation, TData>()
            where TImplementation : class, IAsyncMiddleware<TData>;
    }
}
