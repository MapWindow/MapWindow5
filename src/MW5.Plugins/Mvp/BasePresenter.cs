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
            View.BeforeClose();

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
    /// <typeparam name="TModel">The type of the argument.</typeparam>
    public abstract class BasePresenter<TView, TModel> : BasePresenter<TView>, IPresenter<TModel>
        where TView : IView<TModel>
    {
        protected TModel _model;

        protected BasePresenter( TView view): base(view)
        {
            
        }

        public TModel Model
        {
            get { return _model; }
        }

        public bool Run(TModel argument, IWin32Window parent = null)
        {
            Init(argument);
            View.ShowView(parent);
            return Success;
        }

        public virtual void Initialize()
        {
            
        }

        private void Init(TModel model)
        {
            if (model == null) return;

            _model = model;
            View.InitInternal(model);
            (View as IView<TModel>).Initialize();
            Initialize();
        }
    }
}
