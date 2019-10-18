using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace WebApplication1.Dependency
{
    internal sealed class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;
        public WindsorDependencyResolver(IWindsorContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            _container = container;
        }
        public object GetService(Type serviceType)
        {
            return _container.Kernel.HasComponent(serviceType) ? _container.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _container.ResolveAll(serviceType).Cast<object>().ToArray();
        }

        public IDependencyScope BeginScope()
        {
            return new WindsorDependencyScope(_container);
        }

        public void Dispose()
        {
        }

     
    }
}