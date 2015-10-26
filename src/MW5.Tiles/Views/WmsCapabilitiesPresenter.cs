// -------------------------------------------------------------------------------------------
// <copyright file="WmsCapabilitiesPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BruTile.Wms;
using MW5.Api.Legend;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tiles.Enums;
using MW5.Tiles.Helpers;
using MW5.Tiles.Views.Abstract;
using Exception = System.Exception;

namespace MW5.Tiles.Views
{
    /// <summary>
    /// Displays layers advertised by WMS server via GetCapabilities request.
    /// </summary>
    internal class WmsCapabilitiesPresenter : ComplexPresenter<IWmsCapabilitiesView, WmsCommand, WmsCapabilitiesModel>
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
            view.SelectedServerChanged += () =>
                {
                    if (!LoadCachedCapabilities(View.Server))
                    {
                        DisplayServerCapabilities(null);
                    }
                };
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
                            View.UpdateServer(server);
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
                                View.UpdateServer(server);
                                LoadCachedCapabilities(server);
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
                            View.UpdateServer(Model.Repository.WmsServers.FirstOrDefault());
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
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return true;
        }

        /// <summary>
        /// Is called after Presenter.Model is set. Should be overridden to provide any model specific initialization.
        /// </summary>
        protected override void Initialize()
        {
            var servers = Model.Repository.WmsServers.ToList();

            var server = servers.FirstOrDefault(s => s.Url.EqualsIgnoreCase(AppConfig.Instance.WmsLastServer)) ?? servers.FirstOrDefault();

            if (server != null)
            {
                View.Server = server;
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

            var provider = Model.Capabilities.CreateWmsLayer(layers, server.Url, _context.Map.Projection);
            if (provider == null) return;

            provider.Name = provider.Layers;

            _layerService.AddDatasource(provider);

             AdjustLayerPosition();

            _context.Legend.Redraw(LegendRedraw.LegendAndMap);
        }

        /// <summary>
        /// Places WMS layer above data layers.
        /// </summary>
        private void AdjustLayerPosition()
        {
            int layerHandle = _layerService.LastLayerHandle;
            if (layerHandle == -1) return;

            var group = _context.Legend.Groups.GroupByLayerHandle(layerHandle);
            if (group != null)
            {
                var beforeLayer = _context.Legend.Layers.FirstOrDefault(l => l.LayerType != Api.Enums.LayerType.WmsLayer);
                if (beforeLayer != null)
                {
                    _context.Legend.Layers.MoveLayer(layerHandle, group.Handle, beforeLayer.Position);    
                }
            }
        }

        /// <summary>
        /// Sends GetCapabilities request to the specified URL.
        /// </summary>
        private void ConnectServer()
        {
            var server = SelectedServer;
            if (server == null) return;

            if (LoadCachedCapabilities(server))
            {
                return;
            }

            View.ShowHourglass();

            Task<Stream>.Factory.StartNew(() => BruTileHelper.GetWmsCapabilitiesStream(server.Url))
                .ContinueWith(ProcessWmsCapabilitiesResults, TaskScheduler.FromCurrentSynchronizationContext());
        }

        /// <summary>
        /// Displays capabilities (list of layers for the server).
        /// </summary>
        private void DisplayServerCapabilities(WmsCapabilities capabilities)
        {
            var server = View.Server;
            if (server != null)
            {
                Model.Capabilities = capabilities;
                View.UpdateCapabilities();
                AppConfig.Instance.WmsLastServer = server.Url;
            }
        }

        /// <summary>
        /// Loads and displayes the cached capabilities for the server.
        /// </summary>
        private bool LoadCachedCapabilities(WmsServer server)
        {
            var capabilities = WmsCapabilitiesCache.Load(server.Url);
            if (capabilities != null)
            {
                DisplayServerCapabilities(capabilities);
                return true;
            }

            return false;
        }

        /// <summary>
        /// Displayes and cached the results of GetCapabilities request.
        /// </summary>
        private void ProcessWmsCapabilitiesResults(Task<Stream> task)
        {
            var server = SelectedServer;

            string msg = "WMS server GetCapabilities request failed: " + Environment.NewLine;

            try
            {
                using (var stream = task.Result)
                {
                    WmsCapabilities capabilities;

                    if (WmsCapabilitiesCache.Save(server.Url, stream))
                    {
                        // ConnectStream returned by WebResponse doesn't support seek operation,
                        // so we can't read it twice, therefore on successful saving to the disk 
                        // we are rereading it from file
                        capabilities = WmsCapabilitiesCache.Load(server.Url);
                    }
                    else
                    {
                        capabilities = new WmsCapabilities(stream);
                    }

                    DisplayServerCapabilities(capabilities);
                }
            }
            catch (AggregateException ex)
            {
                MessageService.Current.Warn(msg + ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn(msg + server.Name, ex);
            }
            finally
            {
                View.HideHourglass();
            }
        }
    }
}