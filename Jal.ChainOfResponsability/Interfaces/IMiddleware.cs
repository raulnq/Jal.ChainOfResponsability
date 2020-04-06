using System;

namespace Jal.ChainOfResponsability
{
    public interface IMiddleware<T>
    {
        void Execute(Context<T> context, Action<Context<T>> next);
    }
}
