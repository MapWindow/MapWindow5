using System;
using System.ComponentModel;
using System.Windows.Forms;

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
            if (View.OkButton != null)
            {
                View.OkButton.Click += (s, e) => OnViewOkClicked();
            }
        }

        private void OnViewOkClicked()
        {
            if (ViewOkClicked())
            {
                View.Close();
                Success = true;
            }
        }

        public bool Run(IWin32Window parent = null)
        {
            View.ShowView(parent);
            return Success;
        }

        public abstract bool ViewOkClicked();

        public IWin32Window ViewHandle
        {
            get { return View as IWin32Window; }
        }
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

        public bool Run(TArg argument, IWin32Window parent = null)
        {
            Init(argument);
            View.ShowView(parent);
            return Success;
        }

        public abstract void Init(TArg arg);
    }
}
