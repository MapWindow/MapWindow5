using System;

namespace MW5.Mvp.DI
{
    public interface IApplicationContainer
    {
        IApplicationContainer RegisterView<TView, TImplementation>()
            where TImplementation : class, TView
            where TView : class, IView;

        IApplicationContainer RegisterInstance(Type type, object instance);

        IApplicationContainer RegisterService<TService, TImplementation>()
            where TService: class
            where TImplementation : class, TService;

        IApplicationContainer RegisterServiceSingleton<TService, TImplementation>()
            where TService: class
            where TImplementation : class, TService;

        void Run<TPresenter, TArgument>(TArgument arg)
            where TPresenter : class, IPresenter<TArgument>;

        void Run<TPresenter>() where TPresenter : class, IPresenter;

        //void Run<TPresenter, TModel>(TModel model)
        //    where TPresenter : class, IPresenter<TModel>
        //    where TModel : class;
    }
}
