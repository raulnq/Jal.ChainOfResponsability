﻿using Jal.Locator;
using System;

namespace Jal.ChainOfResponsability
{
    public class MiddlewareFactory : IMiddlewareFactory
    {
        private readonly IServiceLocator _serviceLocator;

        public MiddlewareFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public TMiddleware Create<TMiddleware>(Type type) where TMiddleware : class
        {
            try
            {
                return _serviceLocator.Resolve<TMiddleware>(type.FullName);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error during the middleware {typeof(TMiddleware).FullName} creation using the Type {type.FullName}", ex);
            }
        }

        public TMiddleware Create<TMiddleware>(string middlewarename) where TMiddleware : class
        {
            try
            {
                return _serviceLocator.Resolve<TMiddleware>(middlewarename);
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Error during the middleware {typeof(TMiddleware).FullName} creation using the name {middlewarename}", ex);
            }
        }
    }

}
