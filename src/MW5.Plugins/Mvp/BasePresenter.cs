// -------------------------------------------------------------------------------------------
// <copyright file="BasePresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    public abstract class BasePresenter<TView> : IPresenter
        where TView : IView
    {
        protected BasePresenter(TView view)
        {
            View = view;
            View.OkClicked += OnViewOkClicked;

            if (View.OkButton != null)
            {
                View.OkButton.Click += (s, e) => OnViewOkClicked();
            }
        }

        /// <summary>
        /// Gets the view associated with presenter.
        /// </summary>
        public TView View { get; private set; }

        /// <summary>
        /// Gets or sets the boolean value returned by Presenter.Run method.
        /// </summary>
        public bool ReturnValue { get; protected set; }

        /// <summary>
        /// Runs the presenter by displaying the view associated with it.
        /// </summary>
        public bool Run(IWin32Window parent = null)
        {
            View.ShowView(parent);

            OnClosed();

            if (View.Style.Modal)
            {
                var form = View as Form;
                if (form != null)
                {
                    // Some of the Syncfusion controls (TabControlAdv for example) attaches handlers 
                    // to the static events of other classes. This effectively prevents garbage collection 
                    // unless Dispose is called on the form explictily. So this call is a really necessity.
                    form.Dispose();
                }
            }

            return ReturnValue;
        }

        /// <summary>
        /// Called after the view was closed and presenter is about to return control flow to the external code.
        /// </summary>
        protected virtual void OnClosed() { }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public abstract bool ViewOkClicked();

        /// <summary>
        /// Gets the handler of the underlying window for the view.
        /// </summary>
        public IWin32Window ViewHandle
        {
            get { return View as IWin32Window; }
        }

        private void OnViewOkClicked()
        {
            View.BeforeClose();

            if (ViewOkClicked())
            {
                View.Close();
                ReturnValue = true;
            }
        }
    }

    /// <summary>
    /// Base presenter with argument without command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TModel">The type of the argument.</typeparam>
    public abstract class BasePresenter<TView, TModel> : BasePresenter<TView>, IPresenter<TModel>
        where TView : IView<TModel> 
        where TModel : class
    {
        private TModel _model;

        protected BasePresenter(TView view)
            : base(view)
        {
        }

        /// <summary>
        /// Gets the view model object shared by presenter and view.
        /// </summary>
        public TModel Model
        {
            get { return _model; }
        }

        /// <summary>
        /// Runs the presenter by displaying the view associated with it.
        /// </summary>
        public bool Run(TModel argument, IWin32Window parent = null)
        {
            Init(argument);

            return Run(parent);
        }

        /// <summary>
        /// Is called after Presenter.Model is set. Should be overridden to provide any model specific initialization.
        /// </summary>
        protected virtual void Initialize()
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