using Ninject;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ArtUp.WebApi.IoC
{
    public class NinjectDependencyResolver: IDependencyResolver
    {
        private readonly IKernel _kernel;

        public NinjectDependencyResolver()
        {
            _kernel = new StandardKernel(new DependencyModule());
        }
        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }

    }
}