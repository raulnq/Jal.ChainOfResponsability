using System;

namespace Jal.ChainOfResponsability
{
    public interface IMiddlewareFactory
    {
        TMiddleware Create<TMiddleware>(Type type) where TMiddleware : class;

        TMiddleware Create<TMiddleware>(string middlewarename) where TMiddleware : class;
    }
}
