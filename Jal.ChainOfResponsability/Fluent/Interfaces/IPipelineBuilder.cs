namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineBuilder
    {
        IPipelineUseBuilder<TData> For<TData>();

        IPipelineUseBuilderAsync<TData> ForAsync<TData>();
    }

}
