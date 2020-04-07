using System.Threading;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public interface IPipeline
    {
        void Execute<T>(MiddlewareConfiguration<T>[] configuration, T data);

        Task ExecuteAsync<T>(AsyncMiddlewareConfiguration<T>[] configuration, T data, CancellationToken token=default(CancellationToken));
    }
}
