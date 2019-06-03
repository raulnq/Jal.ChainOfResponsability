using Jal.ChainOfResponsability.Intefaces;
using Jal.ChainOfResponsability.Model;
using System;
using System.Threading.Tasks;

namespace Jal.ChainOfResponsability.Impl
{
    public class Pipeline : IPipeline
    {
        private readonly IMiddlewareFactory _factory;

        public Pipeline(IMiddlewareFactory factory)
        {
            _factory = factory;
        }

        public void Execute<T>(MiddlewareMetadata<T>[] middlewaremetadata, T data)
        {
            var context = new Context<T>()
            {
                Index = 0, Middlewaremetadata = middlewaremetadata, Data = data
            };

            GetNext<T>().Invoke(context);
        }

        public Task ExecuteAsync<T>(MiddlewareMetadata<T>[] middlewaremetadata, T data)
        {
            var context = new Context<T>()
            {
                Index = 0,
                Middlewaremetadata = middlewaremetadata,
                Data = data
            };

            return GetNextAsync<T>().Invoke(context);
        }

        private Func<Context<T>, Task> GetNextAsync<T>()
        {
            return c=>
            {
                if (c.Index < c.Middlewaremetadata.Length)
                {
                    var metadata = c.Middlewaremetadata[c.Index];
                    c.Index++;
                    if (metadata.IsStronglyTyped())
                    {
                        var middleware = default(IMiddlewareAsync<T>);

                        if (metadata.IsNamed())
                        {
                            middleware = _factory.Create<IMiddlewareAsync<T>>(metadata.Name);
                        }
                        else
                        {
                            middleware = _factory.Create<IMiddlewareAsync<T>>(metadata.StronglyTypedMiddleware);
                        }

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
                if (c.Index < c.Middlewaremetadata.Length)
                {
                    var metadata = c.Middlewaremetadata[c.Index];
                    c.Index++;

                    if (metadata.IsStronglyTyped())
                    {

                        var middleware = default(IMiddleware<T>);

                        if(metadata.IsNamed())
                        {
                            middleware = _factory.Create<IMiddleware<T>>(metadata.Name);
                        }
                        else
                        {
                            middleware = _factory.Create<IMiddleware<T>>(metadata.StronglyTypedMiddleware);
                        }

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
