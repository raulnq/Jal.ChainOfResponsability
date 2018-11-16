using Jal.ChainOfResponsability.Model;
using System;

namespace Jal.ChainOfResponsability.Intefaces
{
    public interface IMiddleware<T>
    {
        void Execute(Context<T> context, Action<Context<T>> next);
    }
}
