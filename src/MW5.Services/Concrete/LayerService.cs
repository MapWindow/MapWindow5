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
        private readonly IMessageService _messageService;
        private readonly IBroadcasterService _broadcasterService;

        public LayerService(IAppContext context, IFileDialogService fileDialogService, IMessageService messageService,
            IBroadcasterService broadcasterService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (fileDialogService == null) throw new ArgumentNullException("fileDialogService");
            if (messageService == null) throw new ArgumentNullException("messageService");
            if (broadcasterService == null) throw new ArgumentNullException("broadcasterService");

            _context = context;
            _fileDialogService = fileDialogService;
            _messageService = messageService;
            _broadcasterService = broadcasterService;
        }

        public bool RemoveSelectedLayer()
        {
            int layerHandle = _context.Legend.SelectedLayer;
            if (layerHandle == -1)
            {
                _messageService.Info("No selected layer to remove.");
                return false;
            }

            var args = new LayerRemoveEventArgs(layerHandle);
            _broadcasterService.BroadcastEvent(p => p.BeforeRemoveLayer_, _context.Legend, args);
            if (args.Cancel)
            {
                return false;
            }

            var layer = _context.Map.Layers.ItemByHandle(layerHandle);
            if (_messageService.Ask(string.Format("Do you want to remove the layer: {0}?", layer.Name)))
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

            _context.Map.Lock();

            bool result = false;
            foreach (var name in filenames)
            {
                if (AddLayersFromFilename(name))
                {
                    result = true;      // currently at least one should be success to return success
                }
            }

            _context.Map.Unlock();

            _context.Legend.Redraw();

            return result;
        }

        public bool AddLayersFromFilename(string filename)
        {
            _context.Map.Lock();

            bool result = AddLayersFromFilenameCore(filename);

            _context.Map.Unlock();

            _context.Legend.Redraw();

            return result;
        }

        private bool AddLayersFromFilenameCore(string filename)
        {
            try
            {
                var ds = GeoSourceManager.Open(filename);

                if (ds == null)
                {
                    _messageService.Warn(string.Format("Failed to open datasource: {0} \n {1}", filename, GeoSourceManager.LastError));
                    return false;
                }

                int addedCount = 0;
                foreach (var layer in LayerSourceHelper.GetLayers(ds))
                {
                    int layerHandle = _context.Map.Layers.Add(layer);
                    if (layerHandle != -1)
                    {
                        addedCount++;
                    }
                }

                return addedCount > 0;  // currently at least one should be success to return success
            }
            catch (Exception ex)
            {
                _messageService.Warn(string.Format("There was a problem opening layer: {0}. \n Details: {1}", filename, ex.Message));
                return false;
            }
        }

        /// <summary>
        /// Toggles interactive editing state for vector layer.
        /// </summary>
        /// TODO: perhaps better to allow setting state explicitly as parameter
        public void ToggleVectorLayerEditing()
        {
            int handle = _context.Legend.SelectedLayer;
            var fs = _context.Layers.GetFeatureSet(handle);
            var ogrLayer = _context.Layers.GetVectorLayer(handle);

            if (fs != null)
            {
                if (fs.InteractiveEditing)
                {
                    SaveLayerChanges(handle);
                }
                else
                {
                    if (ogrLayer != null)
                    {
                        if (ogrLayer.DynamicLoading)
                        {
                            _messageService.Info("Editing of dynamically loaded OGR layers isn't allowed.");
                            return;
                        }
                        if (!ogrLayer.get_SupportsEditing(SaveType.SaveAll))
                        {
                            _messageService.Info("OGR layer doesn't support editing: " + ogrLayer.LastError);
                            return;
                        }
                    }
                    fs.InteractiveEditing = true;
                }

                _context.Legend.Redraw(LegendRedraw.LegendAndMap);
            }
        }

        /// <summary>
        /// Saves changes for the layer with specified handle.
        /// </summary>
        /// <param name="layerHandle">Handle of the layer.</param>
        /// <returns>True on success.</returns>
        public bool SaveLayerChanges(int layerHandle)
        {
            string layerName = _context.Layers.ItemByHandle(layerHandle).Name;

            string prompt = string.Format("Save changes for the layer: {0}?", layerName);
            var result = _messageService.AskWithCancel(prompt);
            switch (result)
            {
                case DialogResult.Yes:
                case DialogResult.No:
                    var sf = _context.Layers.GetFeatureSet(layerHandle);
                    var ogrLayer = _context.Layers.GetVectorLayer(layerHandle);

                    bool save = result == DialogResult.Yes;
                    bool success = false;

                    if (ogrLayer != null)
                    {
                        int savedCount;
                        SaveResult saveResult = ogrLayer.SaveChanges(out savedCount);
                        success = saveResult == SaveResult.AllSaved || saveResult == SaveResult.NoChanges;
                        string msg = string.Format("{0}: {1}; features: {2}", EnumHelper.EnumToString(saveResult), ogrLayer.Name, savedCount);
                        _messageService.Info(msg);
                    }
                    else
                    {
                        success = sf.StopEditingShapes(save, true);
                    }

                    if (success)
                    {
                        sf.InteractiveEditing = false;
                        _context.Map.GeometryEditor.Clear();
                        _context.Map.History.ClearForLayer(layerHandle);
                    }
                    _context.Map.Redraw();
                    return true;
                case DialogResult.Cancel:
                default:
                    return false;
            }
        }

        public void CreateLayer()
        {
            var view = _context.Container.GetSingleton<CreateLayerPresenter>();
            if (view.Run())
            {
                var fs = new FeatureSet(view.GeometryType, view.ZValueType);
                fs.Projection.CopyFrom(_context.Map.GeoProjection);
                fs.SaveAs(view.Filename);
                fs.InteractiveEditing = true;
                _context.Layers.Add(fs);
            }
        }

        public void ZoomToSelected()
        {
            int handle = _context.Legend.SelectedLayer;
            _context.Map.ZoomToSelected(handle);
        }

        public void ClearSelection()
        {
            var fs = _context.Map.Layers.SelectedLayer.FeatureSet;
            if (fs != null)
            {
                fs.ClearSelection();
                _context.Map.Redraw();
            }
        }
    }
}
