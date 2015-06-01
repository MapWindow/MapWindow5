using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.UI.Forms;

namespace MW5.Listeners
{
    internal class LegendListener
    {
        private readonly IBroadcasterService _broadcaster;
        private readonly ILayerService _layerService;
        private readonly IAppContext _context;
        private readonly ILegend _legend;

        public LegendListener(IAppContext context, IBroadcasterService broadcaster, ILayerService layerService)
        {
            _context = context;
            _broadcaster = broadcaster;
            _layerService = layerService;
            
            if (_broadcaster == null || _context == null || layerService == null)
            {
                throw new NullReferenceException("Failed to initialize map listener.");
            }

            _legend = _context.Legend as ILegend;
            if (_legend == null)
            {
                throw new NullReferenceException("Legend reference is null.");
            }

            RegisterEvents();
        }

        private void RegisterEvents()
        {
            _legend.GroupAdded += LegendGroupAdded;
            _legend.GroupDoubleClick += LegendGroupDoubleClick;
            _legend.GroupRemoved += LegendGroupRemoved;

            _legend.LayerAdded += LegendLayerAdded;
            _legend.LayerSelected += LayerSelected;
            _legend.LayerDoubleClick += LayerDoubleClick;
            _legend.LayerStyleClicked += LayerStyleClicked;
            _legend.LayerLabelsClicked += LayerLabelsClicked;
            _legend.LayerDiagramsClicked += _legend_LayerDiagramsClicked;
            _legend.LayerCategoryClicked += LayerCategoryClicked;
            _legend.LayerRemoved += LegendLayerRemoved;
            _legend.LayerVisibleChanged += LegendLayerVisibleChanged;
        }

        private void LegendGroupAdded(object sender, GroupEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.GroupAdded_, sender as IMuteLegend, e);
        }

        private void LegendGroupDoubleClick(object sender, GroupEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.GroupDoubleClick_, sender as IMuteLegend, e);
        }

        private void LegendGroupRemoved(object sender, GroupEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.GroupRemoved_, sender as IMuteLegend, e);
        }

        private void LegendLayerVisibleChanged(object sender, LayerCancelEventArgs e)
        {
            var layer = _context.Legend.Layers.ItemByHandle(e.LayerHandle);
            if (layer == null || !layer.DynamicVisibility)
            {
                return;
            }

            if (layer.Visible && !layer.LayerVisibleAtCurrentScale)
            {
                e.Cancel = true;

                bool visible = true;
                if (AppConfig.Instance.DisplayDynamicVisibilityWarnings)
                {
                    visible = MessageService.Current.Ask("Dynamic visibility is enabled for this layer. " + Environment.NewLine +
                                                         "Do you want to disable it and show this layer?");
                }

                if (visible)
                {
                    layer.DynamicVisibility = false;
                    layer.Visible = true;
                    _context.Legend.Redraw(LegendRedraw.LegendAndMap);
                }
            }
        }

        private void LegendLayerRemoved(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerRemoved_, sender as IMuteLegend, e);
        }

        private void LegendLayerAdded(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerAdded_, sender as IMuteLegend, e);
        }

        private void LayerCategoryClicked(object sender, LayerCategoryEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerCategoryClicked_, sender as IMuteLegend, e);
        }

        private void _legend_LayerDiagramsClicked(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerDiagramsClicked_, sender as IMuteLegend, e);
        }

        private void LayerLabelsClicked(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerLabelsClicked_, sender as IMuteLegend, e);
        }

        private void LayerStyleClicked(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerStyleClicked_, sender as IMuteLegend, e);
        }

        private void LayerDoubleClick(object sender, LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerDoubleClicked_, sender as IMuteLegend, e);
        }

        private void LayerSelected(object sender, LayerEventArgs e)
        {
            _context.View.Update();

            _broadcaster.BroadcastEvent(p => p.LayerSelected_, sender as IMuteLegend, e);
        }
    }
}
