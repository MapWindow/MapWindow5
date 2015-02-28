using System;
using System.ComponentModel;
using LightInject;
using MW5.Mvp;
using MW5.Mvp.DI;

namespace MW5.DI.LightInject
{
    public class LightInjectContainer: IApplicationContainer
    {
        private readonly ServiceContainer _container = new ServiceContainer();

        public LightInjectContainer()
        {
            _container.RegisterInstance<IApplicationContainer>(this);
        }

        public IApplicationContainer RegisterView<TView, TImplementation>()
            where TView : class, IView
            where TImplementation : class, TView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterInstance<TArgument>(TArgument instance)
        {
            _container.RegisterInstance(instance);
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
            _container.Register<TService, TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterServiceSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>(new PerContainerLifetime());
            return this;
        }

        public void Run<TPresenter, TArgs>(TArgs arg) where TPresenter : class, IPresenter<TArgs>
        {
            if (!IsRegistered<TPresenter>())
            {
                _container.Register<TPresenter>();
            }

            var presenter = _container.GetInstance<TPresenter>();
            presenter.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!IsRegistered<TPresenter>())
            {
                _container.Register<TPresenter>();
            }

            var presenter = _container.GetInstance<TPresenter>();
            presenter.Run();
        }

        public TService Resolve<TService>() where TService : class
        {
            return _container.GetInstance<TService>();
        }

        private bool IsRegistered<TService>()
        {
            return _container.CanGetInstance(typeof(TService), string.Empty);
        }
    }
}