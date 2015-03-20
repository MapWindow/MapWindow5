using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Symbology.Forms.Symbology;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Displays symbology form of the appropriate type
        /// </summary>
        public static Form GetSymbologyForm(this IMuteLegend legend, int layerHandle, GeometryType type, IGeometryStyle options, bool applyDisabled)
        {
            Form form = null;
            var layer = legend.Layers.ItemByHandle(layerHandle);

            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                form = new PointsForm(legend, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polyline)
            {
                form = new LinesForm(legend, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polygon)
            {
                form = new PolygonForm(legend, layer, options, applyDisabled);
            }
            return form;
        }
    }
}
