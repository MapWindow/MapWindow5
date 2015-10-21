using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BruTile.Wms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
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
        private readonly ILayerService _layerService;

        /// <summary>
        /// Initializes a new instance of the <see cref="WmsCapabilitiesPresenter"/> class.
        /// </summary>
        public WmsCapabilitiesPresenter(IWmsCapabilitiesView view, IAppContext context, ILayerService layerService)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            _context = context;
            _layerService = layerService;

            view.LayerDoubleClicked += () => RunCommand(WmsCommand.Add);
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
                    {
                        var server = new WmsServer();
                        if (_context.Container.Run<WmsServerPresenter, WmsServer>(server))
                        {
                            Model.Repository.AddWmsServer(server);
                            View.UpdateView();
                            View.Server = server;
                        }
                    }
                    break;
                case WmsCommand.Edit:
                    {
                        var server = View.Server;
                        if (server != null)
                        {
                            if (_context.Container.Run<WmsServerPresenter, WmsServer>(server))
                            {
                                Model.Repository.UpdateWmsServer(server);
                                View.UpdateView();
                                View.Server = server;
                            }
                        }
                    }
                    break;
                case WmsCommand.Delete:
                    if (View.Server != null)
                    {
                        string msg = "Do you want to remove the selected WMS server from the list: " + View.Server.Name + "?";
                        if (MessageService.Current.Ask(msg))
                        {
                            Model.Repository.RemoveWmsServer(View.Server);
                            View.UpdateView();
                        }
                    }
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

            var provider = Model.Capabilities.CreateProvider(layers, server.Url);
            provider.Name = provider.Layers;

            _layerService.AddDatasource(provider);

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
        }

        /// <summary>
        /// Sends GetCapabilities request to the specified URL.
        /// </summary>
        private void ConnectServer()
        {
            var server = SelectedServer;
            if (server == null) return;

            var capabilities = WmsCapabilitiesCache.Load(server.Name);
            if (capabilities != null)
            {
                Model.Capabilities = capabilities;
                View.UpdateView();
                return;
            }

            View.ShowHourglass();

            Task<Stream>.Factory
                .StartNew(() => BruTileHelper.GetWmsCapabilitiesStream(server.Url))
                .ContinueWith(ProcessWmsCapabilitiesResults, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Displayes and cached the results of GetCapabilities request.
        /// </summary>
        private void ProcessWmsCapabilitiesResults(Task<Stream> task)
        {
            var server = SelectedServer;

            try
            {
                using (var stream = task.Result)
                {
                    if (WmsCapabilitiesCache.Save(server.Name, stream))
                    {
                        // ConnectStream returned by WebResponse doesn't support seek operation,
                        // so we can't read it twice, therefore on successful saving to the disk 
                        // we are rereading it from file
                        Model.Capabilities = WmsCapabilitiesCache.Load(server.Name);
                    }
                    else
                    {
                        Model.Capabilities = new WmsCapabilities(stream);
                    }

                    View.UpdateView();
                }
            }
            catch (System.Exception ex)
            {
                Logger.Current.Warn("WMS server GetCapabilities request failed: {0}", ex, server.Url);
            }
            finally
            {
                View.HideHourglass();
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
