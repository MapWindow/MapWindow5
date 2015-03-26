using System;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
         where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public void Run(bool dialog = true)
        {
            View.ShowView(dialog);
        }
    }

    /// <summary>
    /// Base presenter with argument without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    public abstract class BasePresener<TView, TArg> : IPresenter<TArg>
        where TView : IView
    {
        protected TView View { get; private set; }

        protected BasePresener( TView view)
        {
            View = view;
        }

        public abstract void Run(TArg argument, bool dialog = true);
    }
    

}
