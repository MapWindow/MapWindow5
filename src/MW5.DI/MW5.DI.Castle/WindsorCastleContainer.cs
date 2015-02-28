using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using MW5.Mvp;
using MW5.Mvp.DI;

namespace MW5.DI.Castle
{
    public class WindsorCastleContainer: IApplicationContainer
    {
        private WindsorContainer _container = new WindsorContainer();
        
        public IApplicationContainer RegisterView<TView, TImplementation>() 
            where TView : class, IView 
            where TImplementation : class, TView
        {
            _container.Register(Component.For<TView>().ImplementedBy<TImplementation>());
            return this;
        }

        public IApplicationContainer RegisterInstance(Type type, object instance)
        {
            _container.Register(Component.For(type).Instance(instance));
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.Register(Component.For<TService>().ImplementedBy<TImplementation>());
            return this;
        }

        public IApplicationContainer RegisterServiceSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.Register(Component.For<TService>().ImplementedBy<TImplementation>().LifestyleSingleton());
            return this;
        }

        public void Run<TPresenter, TArgument>(TArgument arg) where TPresenter : class, IPresenter<TArgument>
        {
            // TODO: is there a way to check if component is registered
            // http ://docs.castleproject.org/Windsor.Conditional-component-registration.ashx
            _container.Register(Component.For<TPresenter>().OnlyNewServices());
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            _container.Register(Component.For<TPresenter>().OnlyNewServices());
            var presenter = _container.Resolve<TPresenter>();
            presenter.Run();
        }
    }
}
