using System;

namespace MW5.Mvp.DI
{
    public class ApplicationController: IApplicationController
    {
        private readonly IContainer _container;

        public ApplicationController(IContainer container)
        {
            _container = container;
            _container.RegisterInstance<IApplicationController>(this);
        }

        public IApplicationController RegisterView<TView, TImplementation, TModel>() where TView : IView<TModel> where TImplementation : class, TView
        {
            _container.Register<TView, TImplementation>();
            return this;
        }

        public IApplicationController RegisterInstance<TArgument>(TArgument instance)
        {
            _container.RegisterInstance(instance);
            return this;
        }

        public IApplicationController RegisterInstance(Type type, object instance)
        {
            _container.RegisterInstance(type, instance);
            return this;
        }

        public IApplicationController RegisterService<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.Register<TService, TImplementation>();
            return this;
        }

        public IApplicationController RegisterServiceSingleton<TService, TImplementation>() where TImplementation : class, TService
        {
            _container.RegisterSingleton<TService, TImplementation>();
            return this;
        }

        public void Run<TPresenter, TModel>(TModel model) where TPresenter : class, IPresenter<TModel> where TModel : class
        {
            if (!_container.IsRegistered<TPresenter>())
            {
                _container.Register<TPresenter>();
            }

            var presenter = _container.Resolve<TPresenter>();
            presenter.Run(model);
        }

        public TService Resolve<TService>() where TService: class
        {
            return _container.Resolve<TService>();
        }
    }
}
