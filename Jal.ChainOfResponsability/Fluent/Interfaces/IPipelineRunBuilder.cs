namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineRunBuilder<TData> : IPipelineUseBuilder<TData>
    {
        void Run(TData data);
    }

}
