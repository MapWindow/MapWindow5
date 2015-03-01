using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MW5.Mvp;
using MW5.Mvp.DI;

namespace MW5.DI.Unity
{
    public class UnityApplicationContainer: IApplicationContainer
    {
        private UnityContainer _container = new UnityContainer();
           
        public IApplicationContainer RegisterView<TView, TImplementation>() 
             where TView : class, IView where TImplementation : class, TView
        {
            _container.RegisterType<TView, TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterInstance(Type type, object instance)
        {
            _container.RegisterInstance(type, instance);
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.RegisterType<TService, TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterServiceSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.RegisterType<TService, TImplementation>(new ContainerControlledLifetimeManager());
            return this;
        }

        public void Run<TPresenter, TArgument>(TArgument arg) where TPresenter : class, IPresenter<TArgument>
        {
            if (_container.IsRegistered<TPresenter>())
            {
                _container.RegisterType<TPresenter>();
            }

            var p = _container.Resolve<TPresenter>();
            p.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (_container.IsRegistered<TPresenter>())
            {
                _container.RegisterType<TPresenter>();
            }

            var p = _container.Resolve<TPresenter>();
            p.Run();
        }
    }
}
