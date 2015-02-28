using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Mvp;
using MW5.Mvp.DI;
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

        public IApplicationContainer RegisterService<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _kernel.Bind<TService>().To<TImplementation>();
            return this;
        }

        public IApplicationContainer RegisterServiceSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _kernel.Bind<TService>().To<TImplementation>().InSingletonScope();
            return this;
        }

        public void Run<TPresenter, TArgumnent>(TArgumnent arg) where TPresenter : class, IPresenter<TArgumnent>
        {
            if (!_kernel.CanResolve<TPresenter>())
            {
                _kernel.Bind<TPresenter>().ToSelf();
            }

            var presenter = _kernel.Get<TPresenter>();
            presenter.Run(arg);
        }

        public void Run<TPresenter>() where TPresenter : class, IPresenter
        {
            if (!_kernel.CanResolve<TPresenter>())
            {
                _kernel.Bind<TPresenter>().ToSelf();
            }

            var presenter = _kernel.Get<TPresenter>();
            presenter.Run();
        }
    }
}
