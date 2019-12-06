using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Legend;
using MW5.Api.Legend.Abstract;
using MW5.Attributes.Views;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Controls.ImageCombo;
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

            if (type == GeometryType.None)
                type = layer.VectorSource.ActiveGeometryType;

            if (type == GeometryType.Point || type == GeometryType.MultiPoint)
            {
                form = new PointsForm(context, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polyline)
            {
                form = new LinesForm(context, layer, options, applyDisabled);
            }
            else if (type == GeometryType.Polygon)
            {
                form = new PolygonForm(context, layer, options, applyDisabled);
            }
            return form;
        }

        /// <summary>
        /// Shows dialog to edit default style for vector layer. If visualization categories exists
        /// the new values will be applied to them as well.
        /// </summary>
        public static bool ShowDefaultStyleDialog(this IAppContext context, int layerHandle, bool applyDisabled, IWin32Window parent)
        {
            if (context == null) throw new ArgumentNullException("context");

            var layer = context.Layers.ItemByHandle(layerHandle);

            if (layer == null || layer.FeatureSet == null)
            {
                throw new ApplicationException("Invalid layer handle.");
            }

            var style = layer.FeatureSet.Style;

            using (var form = context.GetSymbologyForm(layer.Handle, style, applyDisabled))
            {
                if (form == null)
                    return false;
                form.Text = "Default Layer Style";

                if (context.View.ShowChildView(form, parent))
                {
                    return true;
                }
            }

            return false;
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
            var layer = context.Legend.Layers.Current;
            if (layer != null)
            {
                var model = new QueryBuilderModel(layer, "");
                context.Container.Run<QueryBuilderPresenter, QueryBuilderModel>(model);
            }
        }

        internal static bool ShowExpressionBuilder(IAppContext context, ILayer layer, IWin32Window parent, ref string expression, TableValueType outputType)
        {
            var model = new ExpressionBuilderModel(layer, expression, outputType);
            bool result = context.Container.Run<ExpressionBuilderPresenter, ExpressionBuilderModel>(model, parent);

            if (result)
                expression = model.Expression;

            return result;
        }

        internal static bool ShowQueryBuilder(IAppContext context, ILayer layer, IWin32Window parent, ref string expression, bool selectionMode)
        {
            var model = new QueryBuilderModel(layer, expression, false);
            bool result = context.Container.Run<QueryBuilderPresenter, QueryBuilderModel>(model, parent);
            
            if (result)
            {
                expression = model.Expression;
            }

            return result;
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
                    context.Container.Run<VectorStylePresenter, ILegendLayer>(layer);
                    return true;
                case LayerType.Image:
                case LayerType.Grid:
                    context.Container.Run<RasterStylePresenter, ILegendLayer>(layer);
                    return true;
                case LayerType.WmsLayer:
                    context.Container.Run<WmsStylePresenter, ILegendLayer>(layer);
                    return true;
            }

            return false;
        }

        internal static void EditColorSchemes(IAppContext context, SchemeTarget target, IWin32Window parent)
        {
            using (var form = new ColorSchemesForm(context, ColorSchemeProvider.GetList(target)))
            {
                context.View.ShowChildView(form, parent);
            }
        }
    }
}
