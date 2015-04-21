using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Plugins.Mvp
{
    /// <summary>
    /// Base presenter with command enumeration.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    public abstract class ComplexPresenter<TView, TCommand> : CommandDispatcher<TView, TCommand>, IPresenter
        where TCommand : struct, IConvertible
        where TView : IView, IMenuProvider
    {
        protected ComplexPresenter(TView view)
            : base(view)
        {
            View.OkClicked += OnViewOkClickedCore;
            if (View.OkButton != null)
            {
                View.OkButton.Click += (s, e) => OnViewOkClickedCore();
            }
        }

        public bool Success { get; protected set; }

        public bool Run(IWin32Window parent = null)
        {
            View.ShowView(parent);
            return Success;
        }

        private void OnViewOkClickedCore()
        {
            if (ViewOkClicked())
            {
                View.Close();
                Success = true;
            }
        }

        public abstract bool ViewOkClicked();

        public IWin32Window ViewHandle
        {
            get { return View as IWin32Window; }
        }
    }

    /// <summary>
    /// Base presenter with command enumeration and argument.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TCommand">The type of the command.</typeparam>
    /// <typeparam name="TModel">The type of the argument.</typeparam>
    public abstract class ComplexPresenter<TView, TCommand, TModel> : ComplexPresenter<TView, TCommand>, IPresenter<TModel>
        where TCommand : struct, IConvertible
        where TView : IView<TModel>, IMenuProvider
    {
        protected TModel _model;

        protected ComplexPresenter(TView view)
            : base(view)
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

        public abstract void Initialize();

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
