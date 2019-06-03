using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Model
{
    public class MiddlewareMetadata
    {
        public Type StronglyTypedMiddleware { get; set; }

        public string Name { get; set; }
    }

    public class MiddlewareMetadata<T> : MiddlewareMetadata
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

        public bool IsNamed()
        {
            if (!string.IsNullOrWhiteSpace(Name))
            {
                return true;
            }
            return false;
        }
    }
}
