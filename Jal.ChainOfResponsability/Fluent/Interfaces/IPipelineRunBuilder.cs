namespace Jal.ChainOfResponsability
{
    public interface IPipelineRunBuilder<TData> : IPipelineUseBuilder<TData>
    {
        void Run(TData data);
    }

}
