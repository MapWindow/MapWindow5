using System;

namespace MW5.Mvp.DI
{
    public interface IApplicationController
    {
        IApplicationController RegisterView<TView, TImplementation, TModel>()
            where TImplementation : class, TView
            where TView : IView<TModel>;

        IApplicationController RegisterInstance<TArgument>(TArgument instance);

        IApplicationController RegisterInstance(Type type, object instance);

        IApplicationController RegisterService<TService, TImplementation>()
            where TImplementation : class, TService;

        IApplicationController RegisterServiceSingleton<TService, TImplementation>()
            where TImplementation : class, TService;

        void Run<TPresenter, TModel>(TModel model)
            where TPresenter : class, IPresenter<TModel> 
            where TModel : class;

        //void Run<TPresenter, TArgumnent>(TArgumnent argumnent)
        //    where TPresenter : class, IPresenter<TArgumnent>;
    }
}
