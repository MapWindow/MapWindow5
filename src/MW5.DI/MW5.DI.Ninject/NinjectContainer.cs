using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Mvp;
using MW5.Plugins.Mvp;
using Ninject;

namespace MW5.DI.Ninject
{
    public class NinjectContainer: IApplicationContainer
    {
        private IKernel _kernel = new StandardKernel();
        
        public IApplicationContainer RegisterView<TView, TImplementation>() 
            where TView : class, IView where TImplementation : class, TView
        {
            _kernel.Bind<TView>().To<TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterInstance(Type type, object instance)
        {
            _kernel.Bind(type).ToConstant(instance);
            return this;
        }

        public IApplicationContainer RegisterInstance<TService>(object instance) 
            where TService : class 
        {
            _kernel.Bind<TService>().ToConstant<TService>(instance as TService);
            return this;
        }

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _kernel.Bind<TService>().To<TImplementation>();
            return this;
        }

        public TService GetInstance<TService>() where TService : class
        {
            if (!_kernel.CanResolve<TService>())
            {
                _kernel.Bind<TService>().ToSelf();
            }

            return _kernel.Get<TService>();
        }

        public IApplicationContainer RegisterSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _kernel.Bind<TService>().To<TImplementation>().InSingletonScope();
            return this;
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent arg) where TPresenter : class, IPresenter<TArgumnent>
        {
            var presenter = GetInstance<TPresenter>();
            presenter.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            var presenter = GetInstance<TPresenter>();
            presenter.Run();
        }

        public TService Resolve<TService>() where TService : class
        {
            return _kernel.Get<TService>();
        }

        public TService GetSingleton<TService>() where TService : class
        {
            if (!_kernel.CanResolve<TService>())
            {
                _kernel.Bind<TService>().ToSelf().InSingletonScope();
            }
            return _kernel.Get<TService>();
        }
    }
}
