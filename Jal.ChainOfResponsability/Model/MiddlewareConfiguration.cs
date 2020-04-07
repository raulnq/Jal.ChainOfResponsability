using System;

namespace Jal.ChainOfResponsability
{
    public class MiddlewareConfiguration
    {
        public Type StronglyTypedMiddleware { get; set; }

        public bool IsStronglyTyped()
        {
            if (StronglyTypedMiddleware != null)
            {
                return true;
            }
            return false;
        }
    }

    public class MiddlewareConfiguration<T> : MiddlewareConfiguration
    {
        public Action<Context<T>, Action<Context<T>>> Middleware { get; set; }
    }
}
