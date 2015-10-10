using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruTile.Wms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tiles.Enums;
using MW5.Tiles.Helpers;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    internal class WmsCapabilitiesPresenter 
        : ComplexPresenter<IWmsCapabilitiesView, WmsCommand, WmsCapabilitiesModel>
    {
        public WmsCapabilitiesPresenter(IWmsCapabilitiesView view)
            : base(view)
        {
        }

        public override void RunCommand(WmsCommand command)
        {
            switch (command)
            {
                case WmsCommand.Connect:
                    ConnectServer();
                    break;
                case WmsCommand.Create:
                    break;
                case WmsCommand.Edit:
                    break;
                case WmsCommand.Delete:
                    break;
                case WmsCommand.Add:
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        /// <summary>
        /// Sends GetCapabilities request to the specified URL.
        /// </summary>
        private void ConnectServer()
        {
            string url = View.ServerUrl;
            if (string.IsNullOrWhiteSpace(url))
            {
                MessageService.Current.Info("No WMS server is selected");
                return;
            }

            View.ShowHourglass();

            Task<WmsCapabilities>.Factory.StartNew(() => BruTileHelper.GetWmsCapabilities(url))
                .ContinueWith(task =>
                    {
                        try
                        {
                            Model.Capabilities = task.Result;
                            View.UpdateView();
                        }
                        catch (System.Exception ex)
                        {
                            Logger.Current.Warn("WMS server GetCapabilities request failed: {0}", ex, url);
                        }
                        finally
                        {
                            View.HideHourglass();
                        }
                    }, TaskScheduler.FromCurrentSynchronizationContext());
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
