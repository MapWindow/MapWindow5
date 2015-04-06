using System;
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// A wrapper for DI container. Can be represented by one of the implementations:
    /// Ninject, Castle, Unity, etc.
    /// </summary>
    public interface IApplicationContainer
    {
        /// <summary>
        /// Registeres particular concrete service with transient lifetime.
        /// </summary>
        IApplicationContainer RegisterService<TService>()
            where TService : class;

        /// <summary>
        /// Registeres particular concrete service with singleton lifetime.
        /// </summary>
        IApplicationContainer RegisterSingleton<TService>()
            where TService : class;
        
        /// <summary>
        /// Bounds an interface to particular implementation. Lifetime is transient, i.e. each time a new instance will be injected.
        /// </summary>
        IApplicationContainer RegisterService<TService, TImplementation>()
            where TService: class
            where TImplementation : class, TService;

        /// <summary>
        /// Bounds an interface to particular implementation. Lifetime is singleton (aka container controlled), 
        /// i.e. instance will be created on the first injection and then will be used for all the subsequent ones.
        /// </summary>
        IApplicationContainer RegisterSingleton<TService, TImplementation>()
            where TService: class
            where TImplementation : class, TService;

        /// <summary>
        /// Bounds specified type to a particular instance. Obviously lifetime is singleton, i.e. this particular
        /// instance will be used on all subsequent injections
        /// </summary>
        IApplicationContainer RegisterInstance(Type type, object instance);

        /// <summary>
        /// Bounds specified type to a particular instance. Obviously lifetime is singleton, i.e. this particular
        /// instance will be used on all subsequent injections
        /// </summary>
        IApplicationContainer RegisterInstance<TService>(object instance)
            where TService : class;

        /// <summary>
        /// Gets an instance of particular type. Registeres this type with transient life time if needed.
        /// </summary>
        TService GetInstance<TService>()
            where TService : class;

        /// <summary>
        /// A shortcut for RegisterSingleton and Resolve. Also won't try to register a single for the second type 
        /// if it's already registered.
        /// </summary>
        TService GetSingleton<TService>() where TService : class;

        /// <summary>
        /// Returns instance of particular type. The type must be registered with the container before the call.
        /// </summary>
        TService Resolve<TService>() where TService : class;

        /// <summary>
        /// RegisterService overload with constraint specific to IView (for the time being only a syntax sugar).
        /// </summary>
        IApplicationContainer RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : class, IView;

        /// <summary>
        /// Runs presenter (registeres presenter type, creates instance of presenter, injects instance of IView in constructor, calls IView.ShowView).
        /// </summary>
        bool Run<TPresenter>(IWin32Window parent = null) where TPresenter : class, IPresenter;

        /// <summary>
        /// Runs presenter with an argument parameter. Registeres presenter type if it's not registered.
        /// </summary>
        bool Run<TPresenter, TArgument>(TArgument arg, IWin32Window parent = null)
          where TPresenter : class, IPresenter<TArgument>;
    }
}
