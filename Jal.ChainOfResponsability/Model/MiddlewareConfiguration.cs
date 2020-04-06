using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public class MiddlewareConfiguration
    {
        public Type StronglyTypedMiddleware { get; set; }
    }

    public class MiddlewareConfiguration<T> : MiddlewareConfiguration
    {
        public Func<Context<T>, bool> When { get; set; }

        public Action<Context<T>, Action<Context<T>>> Middleware { get; set; }

        public Func<Context<T>, Func<Context<T>, Task>, Task> AsyncMiddleware { get; set; }

        public bool IsStronglyTyped()
        {
            if (StronglyTypedMiddleware != null)
            {
                return true;
            }
            return false;
        }
    }
}
