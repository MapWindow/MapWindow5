using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Helpers;

namespace MW5.Controls
{
    public class LegendPresenter: CommandDispatcher<LegendDockPanel, LegendCommand>
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;
        private readonly IBroadcasterService _broadcaster;
        private readonly LegendDockPanel _legendDockPanel;

        public LegendPresenter(IAppContext context, ILayerService layerService, IBroadcasterService broadcaster, 
                               LegendDockPanel legendDockPanel):
            base(legendDockPanel)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (layerService == null) throw new ArgumentNullException("layerService");
            if (broadcaster == null) throw new ArgumentNullException("broadcaster");
            if (legendDockPanel == null) throw new ArgumentNullException("legendDockPanel");

            _context = context;
            _layerService = layerService;
            _broadcaster = broadcaster;
            _legendDockPanel = legendDockPanel;
        }

        public IMuteLegend Legend
        {
            get { return _legendDockPanel.Legend; }
        }

        public override void RunCommand(LegendCommand command)
        {
            switch (command)
            {
                case LegendCommand.ZoomToLayer:
                    _context.Map.ZoomToLayer(_context.Legend.SelectedLayerHandle);
                    break;
                case LegendCommand.RemoveLayer:
                    _layerService.RemoveSelectedLayer();
                    break;
                case LegendCommand.Properties:
                    _broadcaster.BroadcastEvent(p => p.LayerDoubleClicked_, Legend,
                        new LayerEventArgs(Legend.SelectedLayerHandle));
                    break;
                case LegendCommand.SaveStyle:
                    _layerService.SaveStyle();
                    break;
                case LegendCommand.LoadStyle:
                    _layerService.LoadStyle();
                    break;
                case LegendCommand.OpenFileLocation:
                    var layer = Legend.Layers.Current;
                    if (layer != null && File.Exists(layer.Filename))
                    {
                        string path = Path.GetDirectoryName(layer.Filename);
                        Shared.PathHelper.OpenFolderWithExplorer(path);
                    }
                    else
                    {
                        MessageService.Current.Warn("Failed to find file for the layer.");
                    }
                    break;
            }
        }

        protected override void CommandNotFound(string itemName)
        {
            MessageService.Current.Info("No handler is found for command with key: " + itemName);
        }
    }
}
