using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms.Categories;
using MW5.Plugins.Symbology.Forms.Style;
using MW5.Plugins.Symbology.Forms.Utilities;

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

        internal static void ShowCategories(IAppContext context)
        {
            var fs = context.Map.SelectedFeatureSet;
            if (fs == null)
            {
                return;
            }

            using (var form = new CategoriesForm(context, context.Map.Layers.SelectedLayer))
            {
                if (context.View.ShowDialog(form) == DialogResult.OK)
                {

                }
            }
        }

        internal static void ShowQueryBuilder(IAppContext context)
        {
            var fs = context.Map.SelectedFeatureSet;
            if (fs == null)
            {
                return;
            }

            using (var form = new QueryBuilderForm(context.Map.Layers.SelectedLayer, string.Empty, false))
            {
                if (context.View.ShowDialog(form) == DialogResult.OK)
                {

                }
            }
        }
    }
}
