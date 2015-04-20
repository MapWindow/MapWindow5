using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Renders symbology preview in the expansion section below the layer.
    /// </summary>
    internal class VectorSymbologyRenderer: SymbologyRendererBase
    {
        private const string ChartsCaption = "Charts";
        private const string CategoriesCaption = "Categories";

        public VectorSymbologyRenderer(LegendControl legend)
            : base(legend)
        {
        }

        /// <summary>
        /// Draws color scheme (categories) for the shapefile layer
        /// </summary>
        public void Render(Graphics g, LegendLayer layer, Rectangle bounds, bool isSnapshot)
        {
            if (!layer.IsVector)
            {
                return;
            }

            var sf = layer.AxMap.get_Shapefile(layer.Handle);
            if (sf == null)
            {
                return;
            }

            var maxWidth = Constants.IconWidth;
            if (layer.Type == LegendLayerType.PointShapefile)
            {
                maxWidth = layer.get_MaxIconWidth(sf);
            }

            var top = GetSymbologyTop(bounds);
            var height = layer.GetCategoryHeight(sf.DefaultDrawingOptions) + Constants.VerticalPad;

            if (top + height > _legend.ClientRectangle.Top)
            {
                DrawShapefileCategory(
                    g,
                    sf.DefaultDrawingOptions,
                    layer,
                    bounds,
                    top,
                    string.Empty,
                    maxWidth);
            }

            top += height;

            DrawShapefileCategories(g, layer, sf, bounds, top, isSnapshot, maxWidth);

            DrawCharts(g, layer, sf, bounds, top);
        }

        /// <summary>
        /// Draws the shapefile categories.
        /// </summary>
        private void DrawShapefileCategories(Graphics g, LegendLayer layer, Shapefile sf, Rectangle bounds, int top, bool isSnapshot, int maxWidth)
        {
            if (sf.Categories.Count == 0)
            {
                return;
            }

            var caption = layer.SymbologyCaption;

            DrawCategoriesCaption(g, bounds, ref top, caption, Font);

            // figure out if we can clip any of the categories at the top
            var i = 0;
            var categories = sf.Categories;
            var numCategories = sf.Categories.Count;
            if (top < ClientRectangle.Top && isSnapshot == false)
            {
                while (i < numCategories)
                {
                    // for point categories height can be different
                    top += layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                    if (top < ClientRectangle.Top)
                    {
                        i++;
                    }
                    else
                    {
                        top -= layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                        // this category should be drawn
                        break;
                    }
                }
            }

            // we shall draw symbology first and text second
            // symbology is drawn from ocx, so it's better to draw all categories at once
            // avoiding additional GetHDC calls
            var hdc = g.GetHdc();
            var topTemp = top;
            var startIndex = i;
            for (; i < categories.Count; i++)
            {
                var cat = categories.Item[i];
                var options = cat.DrawingOptions;

                DrawShapefileCategorySymbology(g, options, layer, bounds, topTemp, maxWidth, i, hdc);

                topTemp += layer.GetCategoryHeight(options);
                if (topTemp >= ClientRectangle.Bottom && isSnapshot == false)
                {
                    // stop drawing in case there are not visible
                    break;
                }
            }

            g.ReleaseHdc(hdc);

            // now when hdc is released, GDI+ can be used for the text
            i = startIndex;
            for (; i < categories.Count; i++)
            {
                var cat = categories.Item[i];
                var options = cat.DrawingOptions;

                DrawShapefileCategoryText(g, options, layer, bounds, top, cat.Name, maxWidth);

                top += layer.GetCategoryHeight(options);
                if (top >= ClientRectangle.Bottom && isSnapshot == false)
                {
                    // stop drawing in case there are not visible
                    break;
                }
            }
        }

        /// <summary>
        /// Draws the charts.
        /// </summary>
        private void DrawCharts(Graphics g, LegendLayer layer, Shapefile sf, Rectangle bounds, int top)
        {
            if (sf.Charts.Count == 0 || sf.Charts.NumFields == 0 || !sf.Charts.Visible)
            {
                return;
            }

            // charts caption
            var caption = sf.Charts.Caption;
            if (caption == string.Empty)
            {
                caption = ChartsCaption;
            }

            var left = bounds.Left + Constants.TextLeftPad;
            var rect = new Rectangle(
                left,
                top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);
            DrawText(g, caption, rect, Font, _legend.ForeColor);
            top += Constants.CsItemHeight + Constants.VerticalPad;

            // storing bounds
            var el = new LayerElement(LayerElementType.Charts, rect);
            layer.Elements.Add(el);

            // preview
            var hdc = g.GetHdc();
            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(_legend.BackColor));

            left = bounds.Left + Constants.TextLeftPad;
            sf.Charts.DrawChart(hdc, left, top, true, backColor);
            top += sf.Charts.IconHeight + Constants.VerticalPad;
            g.ReleaseHdc(hdc);

            // storing bounds
            el = new LayerElement(LayerElementType.ChartField, rect);
            layer.Elements.Add(el);

            // fields
            var color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.LineColor));
            var pen = new Pen(color);

            for (var i = 0; i < sf.Charts.NumFields; i++)
            {
                rect = new Rectangle(left, top, Constants.IconWidth, Constants.IconHeight);
                color = ColorTranslator.FromOle(Convert.ToInt32(sf.Charts.Field[i].Color));
                var brush = new SolidBrush(color);
                g.FillRectangle(brush, rect);
                g.DrawRectangle(pen, rect);

                // storing bounds
                el = new LayerElement(LayerElementType.ChartField, rect, i);
                layer.Elements.Add(el);

                rect = new Rectangle(
                    left + Constants.IconWidth + 5,
                    top,
                    bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                    Constants.TextHeight);
                var name = sf.Charts.Field[i].Name;
                DrawText(g, name, rect, Font, Color.Black);

                // storing bounds
                el = new LayerElement(LayerElementType.ChartFieldName, rect, name, i);
                layer.Elements.Add(el);

                top += Constants.CsItemHeight + Constants.VerticalPad;
            }
        }

        /// <summary>
        /// Draws shapefile category in specified location
        /// </summary>
        private void DrawShapefileCategory(
            Graphics g,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            string name,
            int maxWidth)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            var categoryWidth = layer.GetCategoryWidth(options);

            // drawing category symbol
            var hdc = g.GetHdc();
            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(_legend.BackColor));

            var left = bounds.Left + Constants.TextLeftPad;
            if (categoryWidth != Constants.IconWidth)
            {
                left -= (categoryWidth - Constants.IconWidth) / 2;
            }

            if (layer.Type == LegendLayerType.PointShapefile)
            {
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            }
            else if (layer.Type == LegendLayerType.LineShapefile)
            {
                options.DrawLine(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }
            else if (layer.Type == LegendLayerType.PolygonShapefile)
            {
                options.DrawRectangle(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }

            g.ReleaseHdc(hdc);

            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight) / 2;
            }

            // drawing category name
            left = bounds.Left + Constants.TextLeftPad + (Constants.IconWidth / 2) + (maxWidth / 2) + 5;

            var rect = new Rectangle(
                left,
                top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);

            DrawText(g, name, rect, Font, Color.Black);
        }

        /// <summary>
        /// Draws shapefile category. It's assumed here that GetHDC and ReleaseHDC calls are made by caller
        /// </summary>
        private void DrawShapefileCategorySymbology(
            Graphics g,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            int maxWidth,
            int index,
            IntPtr hdc)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            var categoryWidth = layer.GetCategoryWidth(options);

            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(_legend.BackColor));

            var left = bounds.Left + Constants.TextLeftPad;
            if (categoryWidth != Constants.IconWidth)
            {
                left -= (categoryWidth - Constants.IconWidth) / 2;
            }

            if (layer.Type == LegendLayerType.PointShapefile)
            {
                options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
            }
            else if (layer.Type == LegendLayerType.LineShapefile)
            {
                options.DrawLine(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }
            else if (layer.Type == LegendLayerType.PolygonShapefile)
            {
                options.DrawRectangle(
                    hdc,
                    left,
                    top,
                    categoryWidth - 1,
                    Constants.IconHeight - 1,
                    false,
                    categoryWidth,
                    categoryHeight,
                    backColor);
            }

            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight) / 2;
            }
        }

        /// <summary>
        /// Draw the text for the shapefile category
        /// </summary>
        private void DrawShapefileCategoryText(
            Graphics g,
            ShapeDrawingOptions options,
            LegendLayer layer,
            Rectangle bounds,
            int top,
            string name,
            int maxWidth)
        {
            var categoryHeight = layer.GetCategoryHeight(options);
            if (categoryHeight > Constants.CsItemHeight)
            {
                top += (categoryHeight - Constants.CsItemHeight) / 2;
            }

            // drawing category name
            var left = bounds.Left + Constants.TextLeftPad + (Constants.IconWidth / 2) + (maxWidth / 2) + 5;

            var rect = new Rectangle(
                left,
                top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);

            DrawText(g, name, rect, Font, _legend.ForeColor);
        }
    }
}
