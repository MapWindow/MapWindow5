using System;
using System.ComponentModel;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
         where TView : IView
    {
        protected bool _success;

        protected TView View { get; private set; }

        protected BasePresenter(TView view)
        {
            View = view;
        }

        public bool Run(bool modal = true)
        {
            View.ShowView(modal);
            return _success;
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
        protected bool _success;

        protected TView View { get; private set; }

        protected BasePresener( TView view)
        {
            View = view;
        }

        public abstract bool Run(TArg argument, bool modal = true);
    }
    

}
