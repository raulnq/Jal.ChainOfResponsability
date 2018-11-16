using Jal.ChainOfResponsability.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Intefaces
{
    public interface IMiddlewareAsync<T>
    {
        Task ExecuteAsync(Context<T> context, Func<Context<T>,Task> next);
    }
}
