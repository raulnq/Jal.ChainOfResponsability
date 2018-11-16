using Jal.ChainOfResponsability.Model;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Intefaces
{
    public interface IPipeline
    {
        void Execute<T>(MiddlewareMetadata<T>[] metadata, T data);

        Task ExecuteAsync<T>(MiddlewareMetadata<T>[] metadata, T data);
    }
}
