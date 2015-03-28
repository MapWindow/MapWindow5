using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MW5.Plugins.Mvp;

namespace MW5.DI.Castle
{
    public class WindsorCastleContainer: IApplicationContainer
    {
        private WindsorContainer _container = new WindsorContainer();
        
        public IApplicationContainer RegisterView<TView, TImplementation>() 
            where TView : class, IView 
            where TImplementation : class, TView
        {
            _container.Register(Component.For<TView>().ImplementedBy<TImplementation>().LifestyleTransient());
            return this;
        }

        public IApplicationContainer RegisterInstance(Type type, object instance)
        {
            _container.Register(Component.For(type).Instance(instance).LifestyleSingleton());
            return this;
        }

        public IApplicationContainer RegisterInstance<TService>(object instance) 
            where TService : class 
        {
            _container.Register(Component.For<TService>().Instance(instance as TService).LifestyleSingleton());
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.Register(Component.For<TService>().ImplementedBy<TImplementation>().LifestyleTransient());
            return this;
        }

        public TService GetInstance<TService>() where TService : class
        {
            // TODO: is there a way to check if component is registered
            // http ://docs.castleproject.org/Windsor.Conditional-component-registration.ashx
            _container.Register(Component.For<TService>().LifestyleTransient().OnlyNewServices());
            return _container.Resolve<TService>();
        }

        public IApplicationContainer RegisterSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.Register(Component.For<TService>().ImplementedBy<TImplementation>().LifestyleSingleton());
            return this;
        }

        public bool Run<TPresenter, TArgument>(TArgument arg, IWin32Window parent = null) 
            where TPresenter : class, IPresenter<TArgument>
        {
            var presenter = GetInstance<TPresenter>();
            return presenter.Run(arg, parent);
        }

        public bool Run<TPresenter>(IWin32Window parent = null) 
            where TPresenter : class, IPresenter
        {
            var presenter = GetInstance<TPresenter>();
            return presenter.Run(parent);
        }

        public TService Resolve<TService>() 
            where TService : class
        {
            return _container.Resolve<TService>();
        }

        public TService GetSingleton<TService>() 
            where TService : class
        {
            _container.Register(Component.For<TService>().OnlyNewServices());
            return _container.Resolve<TService>();
        }
    }
}
