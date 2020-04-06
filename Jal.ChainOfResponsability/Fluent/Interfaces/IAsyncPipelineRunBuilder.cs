using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public interface IAsyncPipelineRunBuilder<TData> : IAsyncPipelineUseBuilder<TData>
    {
        Task RunAsync(TData data);
    }

}
