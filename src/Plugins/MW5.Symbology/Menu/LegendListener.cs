using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms;
using MW5.Plugins.Symbology.Forms.Charts;
using MW5.Plugins.Symbology.Forms.Labels;
using MW5.Plugins.Symbology.Forms.Layer;
using MW5.Plugins.Symbology.Helpers;

namespace MW5.Plugins.Symbology.Menu
{
    public class LegendListener
    {
        private readonly IAppContext _context;
        private readonly SymbologyPlugin _plugin;

        public LegendListener(IAppContext context, SymbologyPlugin plugin)
        {
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;
            _plugin = plugin;

            _plugin.LayerDoubleClicked += LayerDoubleClicked;
            _plugin.LayerStyleClicked += LayerStyleClicked;
            _plugin.LayerLabelsClicked += LayerLabelsClicked;
            _plugin.LayerDiagramsClicked += LayerDiagramsClicked;
        }

        private void LayerDiagramsClicked(IMuteLegend legend, Api.Legend.Events.LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                var layer = legend.Map.Layers.ItemByHandle(e.LayerHandle);
                using (var form = new ChartStyleForm(_context, layer))
                {
                    if (_context.View.ShowDialog(form) == DialogResult.OK)
                    {
                        // do something
                    }
                }
            }
        }

        private void LayerLabelsClicked(IMuteLegend legend, Api.Legend.Events.LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                var layer = legend.Map.Layers.ItemByHandle(e.LayerHandle);
                using (var form = new LabelStyleForm(legend, layer))
                {
                    if (_context.View.ShowDialog(form) == DialogResult.OK)
                    {
                        // do something
                    }
                }
            }
        }

        private void LayerStyleClicked(IMuteLegend legend, Api.Legend.Events.LayerEventArgs e)
        {
            var fs = legend.Map.GetFeatureSet(e.LayerHandle);
            if (fs != null)
            {
                using (var form = legend.GetSymbologyForm(e.LayerHandle, fs.GeometryType, fs.Style, false))
                {
                    if (_context.View.ShowDialog(form) == DialogResult.OK)
                    {
                        // do something
                    }    
                }
            }
        }

        private void LayerDoubleClicked(IMuteLegend legend, Api.Legend.Events.LayerEventArgs e)
        {
            using (var form = new LayerStyleForm(_context, e.LayerHandle))
            {
                if (_context.View.ShowDialog(form) == DialogResult.OK)
                {
                    // do something
                }
            }
        }
    }
}
