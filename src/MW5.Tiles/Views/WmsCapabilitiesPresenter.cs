using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruTile.Wms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tiles.Enums;
using MW5.Tiles.Helpers;
using MW5.Tiles.Views.Abstract;

namespace MW5.Tiles.Views
{
    /// <summary>
    /// Displays layers advertised by WMS server via GetCapabilities request.
    /// </summary>
    internal class WmsCapabilitiesPresenter 
        : ComplexPresenter<IWmsCapabilitiesView, WmsCommand, WmsCapabilitiesModel>
    {
        private readonly IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="WmsCapabilitiesPresenter"/> class.
        /// </summary>
        public WmsCapabilitiesPresenter(IWmsCapabilitiesView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        /// <summary>
        /// Runs the command.
        /// </summary>
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
                    AddProvider();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("command");
            }
        }

        /// <summary>
        /// Gets the selected server.
        /// </summary>
        private WmsServer SelectedServer
        {
            get
            {
                var server = View.Server;
                if (server == null)
                {
                    MessageService.Current.Info("No WMS server is selected");
                    return null;
                }

                return server;
            }
        }

        /// <summary>
        /// Adds selected server to the map.
        /// </summary>
        private void AddProvider()
        {
            var server = SelectedServer;
            if (server == null)
            {
                return;
            }

            var layers = View.SelectedLayers.ToList();
            if (layers.Count == 0)
            {
                MessageService.Current.Info("No layers are selected");
            }

            var provider = Model.Capabilities.CreateProvider(layers);

            var providers = _context.Map.Tiles.WmsProviders;
            providers.Add(provider);

            Debug.Print("WMS providers count: " + providers.Count);
        }

        /// <summary>
        /// Sends GetCapabilities request to the specified URL.
        /// </summary>
        private void ConnectServer()
        {
            var server = SelectedServer;
            if (server == null) return;

            View.ShowHourglass();

            Task<WmsCapabilities>.Factory.StartNew(() => BruTileHelper.GetWmsCapabilities(server.Url))
                .ContinueWith(task =>
                    {
                        try
                        {
                            Model.Capabilities = task.Result;
                            View.UpdateView();
                        }
                        catch (System.Exception ex)
                        {
                            Logger.Current.Warn("WMS server GetCapabilities request failed: {0}", ex, server.Url);
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
