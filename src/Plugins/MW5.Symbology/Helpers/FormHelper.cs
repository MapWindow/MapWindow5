using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Abstract;
using MW5.Attributes.Forms;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Forms;
using MW5.Plugins.Symbology.Views;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class FormHelper
    {
        /// <summary>
        /// Displays symbology form of the appropriate type
        /// </summary>
        public static Form GetSymbologyForm(this IAppContext context, int layerHandle, IGeometryStyle options, bool applyDisabled)
        {
            Form form = null;
            var layer = context.Legend.Layers.ItemByHandle(layerHandle);

            var fs = layer.FeatureSet;
            if (fs == null)
            {
                return null;
            }

            var type = fs.GeometryType;

            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                form = new PointsForm(context.Legend, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polyline)
            {
                form = new LinesForm(context.Legend, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polygon)
            {
                form = new PolygonForm(context.Legend, layer, options, applyDisabled);
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

            using (var form = new CategoriesForm(context, context.Map.Layers.Current))
            {
                context.View.ShowChildView(form);
            }
        }

        internal static void ShowQueryBuilder(IAppContext context)
        {
            var fs = context.Map.SelectedFeatureSet;
            if (fs == null)
            {
                return;
            }

            using (var form = new QueryBuilderForm(context.Map.Layers.Current, string.Empty, false))
            {
                context.View.ShowChildView(form);
            }
        }

        internal static void ShowLabels(IAppContext context)
        {
            var layer = context.Legend.SelectedLayer;
            if (layer == null) return;
            
            using (var form = new LabelStyleForm(context, layer))
            {
                context.View.ShowChildView(form);
            }
        }

        internal static void ShowCharts(IAppContext context)
        {
            var layer = context.Legend.SelectedLayer;
            if (layer == null) return;

            using (var form = new ChartStyleForm(context, layer))
            {
                context.View.ShowChildView(form);
            }
        }

        internal static bool ShowLayerProperties(IAppContext context)
        {
            var layer = context.Legend.SelectedLayer;
            if (layer == null) return false;

            switch (layer.LayerType)
            {
                case LayerType.Shapefile:
                case LayerType.VectorLayer:
                    using (var form = new VectorStyleForm(context, layer))
                    {
                        context.View.ShowChildView(form);
                        return true;
                    }
                case LayerType.Image:
                case LayerType.Grid:
                    context.Container.Run<RasterStylePresenter, ILegendLayer>(layer);
                    return true;
            }

            return false;
        }
    }
}
