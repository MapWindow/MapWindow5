using System;
using System.ComponentModel;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
        where TView: IView
    {
        protected TView View { get; private set; }

        public bool Success { get; protected set;}

        protected BasePresenter(TView view)
        {
            View = view;
            View.OkClicked += OnViewOkClicked;
        }

        private void OnViewOkClicked()
        {
            if (ViewOkClicked())
            {
                View.Close();
                Success = true;
            }
        }

        public bool Run(bool modal = true)
        {
            View.ShowView(modal);
            return Success;
        }

        public abstract bool ViewOkClicked();
    }

    /// <summary>
    /// Base presenter with argument without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TArg">The type of the argument.</typeparam>
    public abstract class BasePresenter<TView, TArg> : BasePresenter<TView>, IPresenter<TArg>
        where TView : IView
    {
        protected BasePresenter( TView view): base(view)
        {
            
        }

        public bool Run(TArg argument, bool modal = true)
        {
            Init(argument);
            View.ShowView(modal);
            return Success;
        }

        public abstract void Init(TArg arg);
    }
}
