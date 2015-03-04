using System;
using System.Windows.Forms;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Static;
using MW5.Plugins.Interfaces;
using MW5.Services.Abstract;

namespace MW5.Services
{
    public class LayerService: ILayerService
    {
        private readonly IAppContext _context;
        private readonly IFileDialogService _fileDialogService;
        private readonly IMessageService _messageService;

        public LayerService(IAppContext context, IFileDialogService fileDialogService, IMessageService messageService)
        {
            _context = context;
            _fileDialogService = fileDialogService;
            _messageService = messageService;
        }

        public bool RemoveSelectedLayer()
        {
            int layerHandle = _context.Legend.SelectedLayer;
            if (layerHandle == -1)
            {
                _messageService.Info("No selected layer to remove.");
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

        public bool AddLayer(LayerType layerType)
        {
            string[] filenames;
            if (!_fileDialogService.OpenFiles(layerType, _context.MainWindow, out filenames))
            {
                return false;
            }

            _context.Map.LockWindow(true);

            bool result = false;
            foreach (var name in filenames)
            {
                if (AddLayersFromFilename(name))
                {
                    result = true;      // currently at least one should be success to return success
                }
            }

            _context.Map.LockWindow(false);

            _context.Legend.Redraw();

            return result;
        }

        public bool AddLayersFromFilename(string filename)
        {
            _context.Map.LockWindow(true);

            bool result = AddLayersFromFilenameCore(filename);

            _context.Map.LockWindow(false);

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
    }
}
