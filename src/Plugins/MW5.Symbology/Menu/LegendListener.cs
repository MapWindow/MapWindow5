using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Api.Legend.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms;
using MW5.Plugins.Symbology.Forms.Layer;
using MW5.Plugins.Symbology.Forms.Style;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Services;
using MW5.Plugins.Symbology.Views;
using MW5.Plugins.Symbology.Views.Abstract;

namespace MW5.Plugins.Symbology.Menu
{
    public class LegendListener
    {
        private readonly IAppContext _context;
        private readonly SymbologyMetadataService _metadataService;

        public LegendListener(IAppContext context, SymbologyPlugin plugin, SymbologyMetadataService metadataService)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;
            _metadataService = metadataService;

            plugin.LayerDoubleClicked += LayerDoubleClicked;
            plugin.LayerStyleClicked += LayerStyleClicked;
            plugin.LayerLabelsClicked += LayerLabelsClicked;
            plugin.LayerDiagramsClicked += LayerDiagramsClicked;
            plugin.LayerCategoryClicked += LayerCategoryClicked;
            plugin.LayerAdded += LegendLayerAdded;
        }

        private void LegendLayerAdded(IMuteLegend legend, LayerEventArgs e)
        {
            SymbologyPlugin.AttachMetadata(e.LayerHandle);
        }

        private void LayerCategoryClicked(IMuteLegend legend, LayerCategoryEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                var ct = fs.Categories[e.CategoryIndex];
                if (ct != null)
                {
                    using (var form = _context.GetSymbologyForm(e.LayerHandle, ct.Style, false))
                    {
                        _context.View.ShowChildView(form);
                    }
                    e.Handled = true;
                }
            }
        }

        private void LayerDiagramsClicked(IMuteLegend legend, LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                var layer = legend.Map.Layers.ItemByHandle(e.LayerHandle);
                using (var form = new ChartStyleForm(_context, layer))
                {
                    _context.View.ShowChildView(form);
                }
                e.Handled = true;
            }
        }

        private void LayerLabelsClicked(IMuteLegend legend, LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                var layer = legend.Map.Layers.ItemByHandle(e.LayerHandle);
                using (var form = new LabelStyleForm(_context, layer))
                {
                    _context.View.ShowChildView(form);
                }
                e.Handled = true;
            }
        }

        private void LayerStyleClicked(IMuteLegend legend, LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                using (var form = _context.GetSymbologyForm(e.LayerHandle, fs.Style, false))
                {
                    _context.View.ShowChildView(form);  
                }
                e.Handled = true;
            }
        }

        private void LayerDoubleClicked(IMuteLegend legend, LayerEventArgs e)
        {
            var layer = legend.Map.GetLayer(e.LayerHandle);
            switch (layer.LayerType)
            {
                case LayerType.Shapefile:
                case LayerType.VectorLayer:
                    using (var form = new LayerStyleForm(_context, layer))
                    {
                        _context.View.ShowChildView(form);
                        e.Handled = true;
                    }
                    break;
                case LayerType.Image:
                case LayerType.Grid:
                    _context.Container.Run<RasterStylePresenter, ILayer>(layer);
                    e.Handled = true;
                    break;
            }
        }
    }
}
