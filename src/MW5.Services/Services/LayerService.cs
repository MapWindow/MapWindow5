using System;
using System.Windows.Forms;
using MW5.Api.Helpers;
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

        public void AddLayer(LayerType layerType)
        {
            string[] filenames;
            if (!_fileDialogService.OpenFiles(layerType, _context.MainWindow, out filenames))
            {
                return;
            }

            _context.Map.LockWindow(true);

            foreach (var name in filenames)
            {
                AddLayersFromFilename(name);
            }

            _context.Map.ZoomToMaxExtents();
            _context.Map.LockWindow(false);

            _context.Legend.AssignOrphanLayersToNewGroup("Data layers");
            _context.Legend.FullRedraw();
        }

        private void AddLayersFromFilename(string filename)
        {
            try
            {
                var ds = GeoSourceManager.Open(filename);

                if (ds == null)
                {
                    _messageService.Warn(string.Format("Failed to open datasource: {0} \n {1}", filename, GeoSourceManager.LastError));
                    return;
                }

                foreach (var layer in LayerSourceHelper.GetLayers(ds))
                {
                    _context.Map.Layers.Add(layer);
                }
            }
            catch (Exception ex)
            {
                _messageService.Warn(string.Format("There was a problem opening layer: {0}. \n Details: {1}", filename, ex.Message));
            }
        }
    }
}
