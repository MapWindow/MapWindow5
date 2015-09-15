using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Practices.Unity;
using MW5.Plugins.Mvp;

namespace MW5.DI.Unity
{
    public class UnityApplicationContainer: IApplicationContainer
    {
        private readonly UnityContainer _container = new UnityContainer();
           
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

        public IApplicationContainer RegisterService<TService>() where TService : class
        {
            _container.RegisterType<TService>();
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

        /// <summary>
        /// Gets an instance of particular type. Registers this type with transient life time if needed.
        /// </summary>
        public object GetInstance(Type type)
        {
            if (!_container.IsRegistered(type))
            {
                _container.RegisterType(type);
            }
            return _container.Resolve(type);
        }

        public IApplicationContainer RegisterSingleton<TService>() where TService : class
        {
            _container.RegisterType<TService>(new ContainerControlledLifetimeManager());
            return this;
        }

        public IApplicationContainer RegisterSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.RegisterType<TService, TImplementation>(new ContainerControlledLifetimeManager());
            return this;
        }

        public bool Run<TPresenter, TArgument>(TArgument arg, IWin32Window parent = null) where TPresenter : class, IPresenter<TArgument>
        {
            var p = GetInstance<TPresenter>();
            return p.Run(arg);
        }

        public bool Run<TPresenter>(IWin32Window parent = null) where TPresenter : class, IPresenter
        {
            var p = GetInstance<TPresenter>();
            return p.Run();
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
