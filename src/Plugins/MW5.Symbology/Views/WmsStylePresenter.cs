using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Symbology.Views.Abstract;
using MW5.Projections.Helpers;

namespace MW5.Plugins.Symbology.Views
{
    internal class WmsStylePresenter: ComplexPresenter<IWmsStyleView, WmsStyleCommand, ILegendLayer>
    {
        private readonly IAppContext _context;

        public WmsStylePresenter(IWmsStyleView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return ApplyChanges();
        }

        public override void RunCommand(WmsStyleCommand command)
        {
            switch (command)
            {
                case WmsStyleCommand.Projection:
                    _context.ShowProjectionProperties(Model.Projection, View as IWin32Window);
                    break;
                case WmsStyleCommand.Apply:
                    ApplyChanges();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        private bool ApplyChanges()
        {
            if (!View.ValidateInput())
            {
                return false;
            }

            View.ApplyChanges();
            return true;
        }
    }
}
