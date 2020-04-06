namespace Jal.ChainOfResponsability
{
    public interface IPipelineBuilder
    {
        IPipelineUseBuilder<TData> For<TData>();

        IAsyncPipelineUseBuilder<TData> ForAsync<TData>();
    }

}
