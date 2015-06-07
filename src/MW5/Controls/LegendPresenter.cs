using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Helpers;
using MW5.Services.Serialization;
using MW5.Views;

namespace MW5.Controls
{
    public class LegendPresenter: CommandDispatcher<LegendDockPanel, LegendCommand>
    {
        private readonly IAppContext _context;
        private readonly ILayerService _layerService;
        private readonly IBroadcasterService _broadcaster;
        private readonly LegendDockPanel _legendDockPanel;

        public LegendPresenter(IAppContext context, ILayerService layerService, IBroadcasterService broadcaster, 
                               LegendDockPanel legendDockPanel)
             : base(legendDockPanel)
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
                case LegendCommand.AddGroup:
                    Legend.Groups.Add();
                    break;
                case LegendCommand.AddLayer:
                    {
                        int groupHandle = _legendDockPanel.SelectedGroupHandle;
                        if (_layerService.AddLayer(DataSourceType.All) && groupHandle != -1)
                        {
                            int layerHandle = _layerService.LastLayerHandle;
                            Legend.Layers.MoveLayer(layerHandle, groupHandle);
                        }
                        break;
                    }
                case LegendCommand.GroupProperties:
                    {
                        int groupHandle = _legendDockPanel.SelectedGroupHandle;
                        var group = Legend.Groups.ItemByHandle(groupHandle);
                        if (group != null)
                        {
                            if (_context.Container.Run<LegendGroupPresenter, ILegendGroup>(group))
                            {
                                Legend.Redraw();
                            }
                        }
                        break;
                    }
                case LegendCommand.ZoomToGroup:
                    {
                        var group = Legend.Groups.ItemByHandle(_legendDockPanel.SelectedGroupHandle);
                        if (group != null)
                        {
                            var box = group.Envelope;
                            _context.Map.ZoomToExtents(box);
                        }
                        break;
                    }
                case LegendCommand.RemoveGroup:
                    {
                        var group = Legend.Groups.ItemByHandle(_legendDockPanel.SelectedGroupHandle);
                        if (group != null)
                        {
                            if (MessageService.Current.Ask("Do you want to remove group: " + group.Text + "?"))
                            {
                                Legend.Groups.Remove(group.Handle);
                            }
                        }
                        break;
                    }
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
                    {
                        //_layerService.SaveStyle();
                        var layer = Legend.Layers.Current;
                        LayerSerializationHelper.SaveSettings(layer);
                        break;
                    }
                case LegendCommand.LoadStyle:
                    {
                        //_layerService.LoadStyle();
                        var layer = Legend.Layers.Current;
                        LayerSerializationHelper.LoadSettings(layer, _broadcaster, false);
                        _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                    }
                    break;
                case LegendCommand.OpenFileLocation:
                    {
                        var layer = Legend.Layers.Current;
                        if (layer != null && File.Exists(layer.Filename))
                        {
                            Shared.PathHelper.OpenFolderWithExplorer(layer.Filename);
                        }
                        else
                        {
                            MessageService.Current.Warn("Failed to find file for the layer.");
                        }
                        break;
                    }
            }
        }
    }
}
