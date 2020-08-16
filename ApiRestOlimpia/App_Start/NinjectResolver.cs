
using Ninject;
using Ninject.Extensions.ChildKernel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;
using OlimpiaBusiness.Interfaces.Exercise1;
using OlimpiaBusiness.Implementation.Exercise1;
using OlimpiaBusiness.Interfaces.Exercise2;
using OlimpiaBusiness.Implementation.Exercise2;

namespace ApiRestOlimpia.App_Start
{
    public class NinjectResolver: IDependencyResolver
    {
        private IKernel kernel;

        public NinjectResolver() : this(new StandardKernel())
        {

        }

        public NinjectResolver(IKernel ninjectKernel, bool scope = false)
        {
            kernel = ninjectKernel;
            if (!scope)
            {
                AddBindings(kernel);
            }
        }

        private void AddBindings(IKernel kernel)
        {
            kernel.Bind(typeof(IInvoice)).To(typeof(Invoice)).InSingletonScope();
            kernel.Bind(typeof(IDigit)).To(typeof(Digit)).InSingletonScope();
            kernel.Bind(typeof(IFile)).To(typeof(File)).InSingletonScope();
        }

        private IKernel AddRequestBindings(IKernel kernel)
        {
            // Servicios de Aplicacion
            return kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectResolver(AddRequestBindings(new ChildKernel(kernel)), true);
        }

        public void Dispose()
        {
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

    }
}