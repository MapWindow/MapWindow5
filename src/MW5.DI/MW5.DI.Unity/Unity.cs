using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using MW5.Plugins.Mvp;

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

        public IApplicationContainer RegisterInstance<TService>(object instance) 
            where TService : class 
        {
            _container.RegisterInstance<TService>(instance as TService);
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.RegisterType<TService, TImplementation>();
            return this;
        }

        public TService GetInstance<TService>() where TService : class
        {
            if (_container.IsRegistered<TService>())
            {
                _container.RegisterType<TService>();
            }

            return _container.Resolve<TService>();
        }

        public IApplicationContainer RegisterSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.RegisterType<TService, TImplementation>(new ContainerControlledLifetimeManager());
            return this;
        }

        public void Run<TPresenter, TArgument>(TArgument arg) where TPresenter : class, IPresenter<TArgument>
        {
            var p = GetInstance<TPresenter>();
            p.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            var p = GetInstance<TPresenter>();
            p.Run();
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.Resolve<TService>();
        }

        public TService GetSingleton<TService>() where TService : class
        {
            if (_container.IsRegistered<TService>())
            {
                _container.RegisterType<TService>(new ContainerControlledLifetimeManager());
            }
            return _container.Resolve<TService>();
        }
    }
}
