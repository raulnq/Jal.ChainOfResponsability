using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability
{
    public class Pipeline : IPipeline
    {
        private readonly IMiddlewareFactory _factory;

        public Pipeline(IMiddlewareFactory factory)
        {
            _factory = factory;
        }

        public void Execute<T>(MiddlewareConfiguration<T>[] middlewaremetadata, T data)
        {
            var context = new Context<T>()
            {
                Index = 0, Configuration = middlewaremetadata, Data = data
            };

            GetNext<T>().Invoke(context);
        }

        public Task ExecuteAsync<T>(MiddlewareConfiguration<T>[] middlewaremetadata, T data)
        {
            var context = new Context<T>()
            {
                Index = 0,
                Configuration = middlewaremetadata,
                Data = data
            };

            return GetNextAsync<T>().Invoke(context);
        }

        private Func<Context<T>, Task> GetNextAsync<T>()
        {
            return c=>
            {
                if (c.Index < c.Configuration.Length)
                {
                    var metadata = c.Configuration[c.Index];
                    c.Index++;
                    if (metadata.IsStronglyTyped())
                    {
                        var middleware = default(IAsyncMiddleware<T>);

                        middleware = _factory.Create<IAsyncMiddleware<T>>(metadata.StronglyTypedMiddleware);

                        return middleware.ExecuteAsync(c, GetNextAsync<T>());
                    }
                    else
                    {
                        return metadata.AsyncMiddleware(c, GetNextAsync<T>());
                    }
                }
                else
                {
                    throw new Exception("There is no more middlewares to execute");
                }
            };
         }

        private Action<Context<T>> GetNext<T>()
        {
            return (c) =>
            {
                if (c.Index < c.Configuration.Length)
                {
                    var metadata = c.Configuration[c.Index];
                    c.Index++;

                    if (metadata.IsStronglyTyped())
                    {

                        var middleware = default(IMiddleware<T>);

                        middleware = _factory.Create<IMiddleware<T>>(metadata.StronglyTypedMiddleware);

                        middleware.Execute(c, GetNext<T>());
                    }
                    else
                    {
                        metadata.Middleware(c, GetNext<T>());
                    }   
                }
                else
                {
                    throw new Exception("There is no more middlewares to execute");
                }
            };
        }
    }

}
