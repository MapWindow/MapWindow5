using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Views.Abstract;

namespace MW5.Views
{
    internal class SetScalePresenter: BasePresenter<ISetScaleView>
    {
        private readonly IAppContext _context;

        public SetScalePresenter(ISetScaleView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        private bool Validate(out double scale)
        {
            if (!double.TryParse(View.NewScale, out scale))
            {
                MessageService.Current.Info("Invalid scale.");
                return false;
            }

            if (scale <= 0)
            {
                MessageService.Current.Info("Scale must be positive.");
                return false;
            }

            return true;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            double scale;
            if (!Validate(out scale))
            {
                return false;
            }

            _context.Map.CurrentScale = scale;
            return true;
        }
    }
}
