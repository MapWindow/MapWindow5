using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Mvp;
using Ninject;
using Ninject.Planning.Bindings.Resolvers;

namespace MW5.DI.Ninject
{
    public class NinjectContainer: IApplicationContainer
    {
        private readonly IKernel _kernel = null;

        public NinjectContainer()
        {
            // overriding default behavior: auto registering concrete types
            // http ://stackoverflow.com/questions/14565380/disable-implicit-binding-injection-of-non-explicitly-bound-classes-in-ninject-2
            _kernel = new StandardKernel();
            _kernel.Components.RemoveAll<IMissingBindingResolver>();
            _kernel.Components.Add<IMissingBindingResolver, DefaultValueBindingResolver>();
        }

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

        public IApplicationContainer RegisterService<TService>() where TService : class
        {
            _kernel.Bind<TService>().ToSelf();
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

        /// <summary>
        /// Gets an instance of particular type. Registers this type with transient life time if needed.
        /// </summary>
        public object GetInstance(Type type)
        {
            var o = _kernel.CanResolve(type);
            if (o == null)
            {
                _kernel.Bind(new[] { type }).ToSelf();
            }

            return _kernel.Get(type);
        }

        public IApplicationContainer RegisterSingleton<TService>() where TService : class
        {
            _kernel.Bind<TService>().ToSelf().InSingletonScope();
            return this;
        }

        public IApplicationContainer RegisterSingleton<TService, TImplementation>() 
            where TService: class
            where TImplementation : class, TService
        {
            _kernel.Bind<TService>().To<TImplementation>().InSingletonScope();
            return this;
        }

        public bool Run<TPresenter, TArgumnent>(TArgumnent arg, IWin32Window parent = null) where TPresenter : class, IPresenter<TArgumnent>
        {
            var presenter = GetInstance<TPresenter>();
            return presenter.Run(arg, parent);
        }

        public bool Run<TPresenter>(IWin32Window parent = null) where TPresenter : class, IPresenter
        {
            var presenter = GetInstance<TPresenter>();
            return presenter.Run(parent);
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
