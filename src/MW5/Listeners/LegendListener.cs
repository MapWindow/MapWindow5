using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

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
            _legend.LayerSelected += LayerSelected;
            _legend.LayerDoubleClick += LayerDoubleClick;
            _legend.LayerStyleClicked += LayerStyleClicked;
            _legend.LayerLabelsClicked += LayerLabelsClicked;
            _legend.LayerDiagramsClicked += _legend_LayerDiagramsClicked;
            _legend.LayerCategoryClicked += LayerCategoryClicked;
        }

        private void LayerCategoryClicked(object sender, Api.Legend.Events.LayerCategoryEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LegendLayerCategoryClicked_, sender as IMuteLegend, e);
        }

        private void _legend_LayerDiagramsClicked(object sender, Api.Legend.Events.LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LegendLayerDiagramsClicked_, sender as IMuteLegend, e);
        }

        private void LayerLabelsClicked(object sender, Api.Legend.Events.LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LegendLayerLabelsClicked_, sender as IMuteLegend, e);
        }

        private void LayerStyleClicked(object sender, Api.Legend.Events.LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LegendLayerStyleClicked_, sender as IMuteLegend, e);
        }

        private void LayerDoubleClick(object sender, Api.Legend.Events.LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LegendLayerDoubleClicked_, sender as IMuteLegend, e);
        }

        private void LayerSelected(object sender, Api.Legend.Events.LayerEventArgs e)
        {
            _broadcaster.BroadcastEvent(p => p.LayerSelected_, sender as IMuteLegend, e);
        }
    }
}
