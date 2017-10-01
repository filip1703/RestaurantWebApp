using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;
using System.Web.Mvc;
using ProjektRestauracja.Domain.Abstract;
using ProjektRestauracja.Domain.Concrete;
using ProjektRestauracja.Domain.Entities;
using ProjektRestauracja.WebUI.Infrastructure.Abstract;

namespace ProjektRestauracja.WebUI.Infrastructure.Concrete {
    public class NinjectDependencyResolver : IDependencyResolver {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam) {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(Type serviceType) {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType) {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings() {
            kernel.Bind(typeof(IGenericRepository<>)).To(typeof(GenericRepository<>));
            kernel.Bind<IAuthProvider>().To<FormsAuthProvider>();
        }
    }
}