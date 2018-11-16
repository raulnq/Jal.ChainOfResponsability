using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Fluent.Interfaces
{
    public interface IPipelineRunBuilderAsync<TData> : IPipelineUseBuilderAsync<TData>
    {
        Task RunAsync(TData data);
    }

}
