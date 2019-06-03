using System;

namespace Jal.ChainOfResponsability.Intefaces
{
    public interface IMiddlewareFactory
    {
        TMiddleware Create<TMiddleware>(Type type) where TMiddleware : class;

        TMiddleware Create<TMiddleware>(string middlewarename) where TMiddleware : class;
    }
}
