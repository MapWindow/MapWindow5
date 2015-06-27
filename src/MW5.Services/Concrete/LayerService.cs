using System;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Events;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections;
using MW5.Projections.Services.Abstract;
using MW5.Shared;

namespace MW5.Services.Concrete
{
    public class LayerService: ILayerService
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly IBroadcasterService _broadcaster;
        private readonly IProjectionMismatchService _mismatchTester;
        private int _lastLayerHandle;
        private bool _withinBatch;

        public LayerService(IAppContext context, IFileDialogService fileDialogService, 
            IBroadcasterService broadcaster, IProjectionMismatchService mismatchTester)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");

            _context = context;
            _fileDialogService = fileDialogService;
            _broadcaster = broadcaster;
            _mismatchTester = mismatchTester;
        }

        public bool RemoveSelectedLayer()
        {
            int layerHandle = _context.Legend.SelectedLayerHandle;
            if (layerHandle == -1)
            {
                MessageService.Current.Info("No selected layer to remove.");
                return false;
            }

            return RemoveLayerCore(layerHandle, false);
        }

        private bool RemoveLayerCore(int layerHandle, bool silent)
        {
            var layer = _context.Map.GetLayer(layerHandle);

            if (!silent)
            {
                if (!MessageService.Current.Ask(string.Format("Do you want to remove the layer: {0}?", layer.Name)))
                {
                    return false;
                }
            }

            var args = new LayerRemoveEventArgs(layerHandle);
            _broadcaster.BroadcastEvent(p => p.BeforeRemoveLayer_, _context.Legend, args);
            if (args.Cancel)
            {
                return false;
            }
                
            _context.Map.Layers.Remove(layerHandle);
            return true;
        }

        public bool RemoveLayer(LayerIdentity identity)
        {
            var layers = _context.Map.Layers.Where(l => l.Identity == identity);
            BeginBatch();

            bool result = false;
            foreach (var l in layers)
            {
                if (!RemoveLayerCore(l.Handle, true))
                {
                    result = false;
                    break;
                }
                result = true;
            }

            EndBatch();
            return result;
        }

        public bool AddLayer(DataSourceType layerType)
        {
            string[] filenames;
            if (!_fileDialogService.OpenFiles(layerType, out filenames))
            {
                return false;
            }

            BeginBatch();
            
            bool result = false;

            try
            {
                foreach (var name in filenames)
                {
                    if (AddLayersFromFilename(name))
                    {
                        result = true; // currently at least one should be success to return success
                    }
                }
            }
            finally
            {
                EndBatch();
            }

            return result;
        }

        public bool AddLayersFromFilename(string filename)
        {
            bool batch = _withinBatch;
            if (!batch)
            {
                BeginBatch();
            }

            bool result = AddLayersFromFilenameCore(filename);

            if (!batch)
            {
                EndBatch();
            }

            return result;
        }

        public bool AddLayerIdentity(LayerIdentity identity)
        {
            if (identity == null)
            {
                return false;
            }

            switch (identity.IdentityType)
            {
                case LayerIdentityType.File:
                    return AddLayersFromFilenameCore(identity.Filename);
                case LayerIdentityType.OgrDatasource:
                    return AddDatabaseLayer(identity.Connection, identity.Query, identity.GeometryType);
                default:
                    Logger.Current.Warn("Unexpected layer identity");
                    return false;
            }
        }

        public bool AddDatabaseLayer(string connection, string layerName, GeometryType multiGeometryType = GeometryType.None)
        {
            var layer = new VectorLayer();
            if (layer.Open(connection, layerName))
            {
                if (multiGeometryType != GeometryType.None)
                {
                    layer.ActiveGeometryType = multiGeometryType;
                }

                int layerHandle = _context.Map.Layers.Add(layer);
                if (layerHandle != -1)
                {
                    _lastLayerHandle = layerHandle;
                }

                return true;
            }

            return false;
        }

        private bool AddLayersFromFilenameCore(string filename)
        {
            try
            {
                var ds = GeoSource.Open(filename);

                if (ds == null)
                {
                    MessageService.Current.Warn(string.Format("Failed to open datasource: {0} \n {1}", filename, GeoSource.LastError));
                    return false;
                }

                return AddDatasource(ds);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn(string.Format("There was a problem opening layer: {0}. \n Details: {1}", filename, ex.Message));
                return false;
            }
        }

        private bool AddDatasource(IDatasource ds)
        {
            int addedCount = 0;

            var layers = _context.Map.Layers;
            foreach (var layer in LayerSourceHelper.GetLayers(ds))
            {
                // projection mistmatch testing
                bool abort;
                var newLayer = TestProjectionMismatch(layer, out abort);

                if (newLayer == null)
                {
                    continue;
                }

                if (abort)
                {
                    return false;
                }

                // ask plugins if they don't object
                var args = new DatasourceCancelEventArgs(newLayer);
                _broadcaster.BroadcastEvent(p => p.BeforeLayerAdded_, _context.Map, args);

                if (args.Cancel)
                {
                    return false;
                }

                int layerHandle = layers.Add(newLayer);
                if (layerHandle != -1)
                {
                    addedCount++;
                    _lastLayerHandle = layerHandle;
                }
            }

            return addedCount > 0;  // currently at least one should be success to return success
        }


        /// <summary>
        /// Tests if datasources projection matches map projection. Performs reprojection is needed or
        /// substitues original datasources with reprojected version created earlier.
        /// </summary>
        private ILayerSource TestProjectionMismatch(ILayerSource layer, out bool abort)
        {
            abort = false;

            ILayerSource newLayer;
            var result = _mismatchTester.TestLayer(layer, out newLayer);

            switch (result)
            {
                case TestingResult.Ok:
                    newLayer = layer;
                    break;
                case TestingResult.Substituted:
                    // do nothing; user new layer
                    break;
                case TestingResult.SkipFile:
                case TestingResult.Error:
                    return null;
                case TestingResult.CancelOperation:
                    abort = true;
                    return null;
            }

            return newLayer;
        }

        public void ZoomToSelected()
        {
            int handle = _context.Legend.SelectedLayerHandle;
            _context.Map.ZoomToSelected(handle);
        }

        public void ClearSelection()
        {
            var fs = _context.Map.Layers.Current.FeatureSet;
            if (fs != null)
            {
                fs.ClearSelection();
                _context.Map.Redraw();
            }
        }

        public int LastLayerHandle
        {
            get { return _lastLayerHandle; }
        }

        public void BeginBatch()
        {
            _withinBatch = true;
            _context.Map.Lock();
        }

        public void EndBatch()
        {
            _withinBatch = false;
            _context.Map.Unlock();
            _context.Legend.Redraw();
        }

        public void SaveStyle()
        {
            int layerHandle = _context.Legend.SelectedLayerHandle;
            if (layerHandle == -1)
            {
                MessageService.Current.Info("No layer is selected");
            }

            bool result = _context.Map.Layers.Current.SaveOptions("", true, "");
            MessageService.Current.Info(result ? "Layer options are saved." : "Failed to save layer options.");
        }

        public void LoadStyle()
        {
            int layerHandle = _context.Legend.SelectedLayerHandle;
            if (layerHandle == -1)
            {
                MessageService.Current.Info("No layer is selected");
            }
            
            string description = "";
            bool result = _context.Map.Layers.Current.LoadOptions("", ref description);
            if (result)
            {
                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                MessageService.Current.Info("Options are loaded successfully.");
            }
            else
            {
                string msg = "No options are loaded: " + _context.Map.LastError;
                var layer = _context.Map.GetLayer(layerHandle).VectorSource;
                if (layer != null)
                {
                    msg += Environment.NewLine + "Last GDAL error message: " + layer.GdalLastErrorMsg;
                }
                MessageService.Current.Info(msg);
            }
        }
    }
}
