using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Helpers;
using MW5.Api.Legend;
using MW5.Api.Static;
using MW5.Plugins;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Services.Serialization;
using MW5.Services.Views;
using MW5.UI.Helpers;

namespace MW5.Services.Concrete
{
    public class LayerService: ILayerService
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly IBroadcasterService _broadcasterService;
        private int _lastLayerHandle;
        private bool _withinBatch;

        public LayerService(IAppContext context, IFileDialogService fileDialogService, IBroadcasterService broadcasterService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (broadcasterService == null) throw new ArgumentNullException("broadcasterService");

            _context = context;
            _fileDialogService = fileDialogService;
            _broadcasterService = broadcasterService;
        }

        public bool RemoveSelectedLayer()
        {
            int layerHandle = _context.Legend.SelectedLayerHandle;
            if (layerHandle == -1)
            {
                MessageService.Current.Info("No selected layer to remove.");
                return false;
            }

            var args = new LayerRemoveEventArgs(layerHandle);
            _broadcasterService.BroadcastEvent(p => p.BeforeRemoveLayer_, _context.Legend, args);
            if (args.Cancel)
            {
                return false;
            }

            var layer = _context.Map.Layers.ItemByHandle(layerHandle);
            if (MessageService.Current.Ask(string.Format("Do you want to remove the layer: {0}?", layer.Name)))
            {
                _context.Map.Layers.Remove(layerHandle);
                return true;
            }
            return false;
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

        private bool AddLayersFromFilenameCore(string filename)
        {
            try
            {
                var ds = GeoSourceManager.Open(filename);

                if (ds == null)
                {
                    MessageService.Current.Warn(string.Format("Failed to open datasource: {0} \n {1}", filename, GeoSourceManager.LastError));
                    return false;
                }

                int addedCount = 0;
                foreach (var layer in LayerSourceHelper.GetLayers(ds))
                {
                    int layerHandle = _context.Map.Layers.Add(layer);
                    if (layerHandle != -1)
                    {
                        addedCount++;
                        _lastLayerHandle = layerHandle;
                    }
                }

                return addedCount > 0;  // currently at least one should be success to return success
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn(string.Format("There was a problem opening layer: {0}. \n Details: {1}", filename, ex.Message));
                return false;
            }
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
    }
}
