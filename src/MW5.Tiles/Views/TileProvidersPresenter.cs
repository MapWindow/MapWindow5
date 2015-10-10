using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tiles.Enums;
using MW5.Tiles.Model;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    internal class TileProvidersPresenter : ComplexPresenter<IProvidersView, ProviderCommand, TmsProviderList>
    {
        private readonly IAppContext _context;

        public TileProvidersPresenter(IProvidersView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override void RunCommand(ProviderCommand command)
        {
            switch (command)
            {
                case ProviderCommand.Add:
                    var provider = new TmsProvider();
                    _context.Container.Run<TmsProviderPresenter, TmsProvider>(provider);
                    break;
                case ProviderCommand.Remove:
                    if (View.SelectedProvider != null)
                    {
                        if (MessageService.Current.Ask("Remove the selected provider?"))
                        {
                            // TODO: implement
                        }
                    }
                    break;
                case ProviderCommand.Clear:
                    break;
                case ProviderCommand.Edit:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
