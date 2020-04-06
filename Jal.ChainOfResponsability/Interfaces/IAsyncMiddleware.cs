using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public interface IAsyncMiddleware<T>
    {
        Task ExecuteAsync(Context<T> context, Func<Context<T>,Task> next);
    }
}
