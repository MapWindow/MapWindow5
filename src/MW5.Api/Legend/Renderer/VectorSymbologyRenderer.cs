// -------------------------------------------------------------------------------------------
// <copyright file="VectorSymbologyRenderer.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using MapWinGIS;

namespace MW5.Api.Legend.Renderer
{
    /// <summary>
    /// Renders symbology preview in the expansion section below the layer.
    /// </summary>
    internal class VectorSymbologyRenderer : SymbologyRendererBase
    {
        private const string ChartsCaption = "Charts";
        private Rectangle _bounds;
        private Graphics _graphics;
        private bool _isSnapshot;
        private LegendLayer _layer;
        private Shapefile _sf;

        public VectorSymbologyRenderer(LegendControlBase legend)
            : base(legend)
        {
        }

        /// <summary>
        /// Draws color scheme (categories) for the shapefile layer
        /// </summary>
        public void Render(Graphics g, LegendLayer layer, Rectangle bounds, bool isSnapshot)
        {
            if (g == null) throw new ArgumentNullException("g");
            if (layer == null) throw new ArgumentNullException("layer");

            if (!layer.IsVector)
            {
                return;
            }

            var sf = layer.AxMap.get_Shapefile(layer.Handle);
            if (sf == null)
            {
                return;
            }

            _bounds = bounds;
            _graphics = g;
            _layer = layer;
            _sf = sf;
            _isSnapshot = isSnapshot;

            RenderCore();
        }

        private void AdjustCategoryTextTop(ShapeDrawingOptions options, ref int top)
        {
            const int targetHeight = Constants.CsItemHeight + 2;
            var categoryHeight = _layer.GetCategoryHeight(options);
            if (categoryHeight > targetHeight)
            {
                top += (categoryHeight - targetHeight) / 2;
            }
        }

        private void DrawCategoriesCaption(ref int top)
        {
            var caption = _layer.SymbologyCaption;
            if (string.IsNullOrWhiteSpace(caption))
            {
                caption = "Categories";
            }

            DrawCategoriesCaption(_graphics, _bounds, ref top, caption, Font);
        }

        /// <summary>
        /// Draws the charts.
        /// </summary>
        private void DrawCharts(int top)
        {
            if (_sf.Charts.Count == 0 || _sf.Charts.NumFields == 0 || !_sf.Charts.Visible)
            {
                return;
            }

            var left = _bounds.Left + Constants.TextLeftPad;

            RenderChartCaption(left, ref top);

            RenderChartPreview(ref top);

            RenderChartFields(left, top);
        }

        private void RenderChartCaption(int left, ref int top)
        {
            var caption = _sf.Charts.Caption;
            if (caption == string.Empty)
            {
                caption = ChartsCaption;
            }

            var rect = new Rectangle(
                left,
                top,
                _bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);

            DrawText(_graphics, caption, rect, Font, Legend.ForeColor);
            top += Constants.CsItemHeight + Constants.VerticalPad;
            _layer.Elements.Add(LayerElementType.Charts, rect);
        }

        private void RenderChartPreview(ref int top)
        {
            var hdc = _graphics.GetHdc();
            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(Legend.BackColor));

            var left = _bounds.Left + Constants.TextLeftPad;
            _sf.Charts.DrawChart(hdc, left, top, true, backColor);

            _layer.Elements.Add(LayerElementType.Charts, new Rectangle(left, top, _sf.Charts.IconWidth, _sf.Charts.IconHeight));

            top += _sf.Charts.IconHeight + Constants.VerticalPad;
            _graphics.ReleaseHdc(hdc);
        }

        private void RenderChartFields(int left, int top)
        {
            var color = ColorTranslator.FromOle(Convert.ToInt32(_sf.Charts.LineColor));
            var pen = new Pen(color);

            for (var i = 0; i < _sf.Charts.NumFields; i++)
            {
                var rect = new Rectangle(left, top, Constants.IconWidth, Constants.IconHeight);
                color = ColorTranslator.FromOle(Convert.ToInt32(_sf.Charts.Field[i].Color));
                var brush = new SolidBrush(color);
                _graphics.FillRectangle(brush, rect);
                _graphics.DrawRectangle(pen, rect);

                _layer.Elements.Add(LayerElementType.ChartField, rect, i);

                rect = new Rectangle(
                    left + Constants.IconWidth + 5,
                    top,
                    _bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                    Constants.TextHeight);
                var name = _sf.Charts.Field[i].Name;
                DrawText(_graphics, name, rect, Font, Color.Black);

                _layer.Elements.Add(LayerElementType.ChartFieldName, rect);

                top += Constants.CsItemHeight + Constants.VerticalPad;
            }
        }

        /// <summary>
        /// Draws the shapefile categories.
        /// </summary>
        private void DrawShapefileCategories(int top, bool isSnapshot, int maxWidth)
        {
            if (_sf.Categories.Count == 0)
            {
                return;
            }

            DrawCategoriesCaption(ref top);

            // figure out if we can clip any of the categories at the top
            var i = 0;
            var categories = _sf.Categories;
            var numCategories = _sf.Categories.Count;

            if (top < ClientRectangle.Top && isSnapshot == false)
            {
                while (i < numCategories)
                {
                    // for point categories height can be different
                    top += _layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                    if (top < ClientRectangle.Top)
                    {
                        i++;
                    }
                    else
                    {
                        top -= _layer.GetCategoryHeight(categories.Item[i].DrawingOptions);

                        // this category should be drawn
                        break;
                    }
                }
            }

            // we shall draw symbology first and text second
            // symbology is drawn from ocx, so it's better to draw all categories at once
            // avoiding additional GetHDC calls
            var topTemp = top;
            var startIndex = i;

            var hdc = _graphics.GetHdc();

            for (; i < categories.Count; i++)
            {
                var options = categories.Item[i].DrawingOptions;

                DrawShapefileCategorySymbology(hdc, topTemp, options, i, true);

                topTemp += _layer.GetCategoryHeight(options);
                if (topTemp >= ClientRectangle.Bottom && !isSnapshot)
                {
                    // stop drawing in case there are not visible
                    break;
                }
            }

            _graphics.ReleaseHdc(hdc);

            // now when hdc is released, GDI+ can be used for the text
            i = startIndex;
            for (; i < categories.Count; i++)
            {
                var ct = categories.Item[i];
                var options = ct.DrawingOptions;

                var tempTop = top;
                AdjustCategoryTextTop(options, ref tempTop);

                int checkBoxLeft = _bounds.Left + Constants.TextLeftPad;
                int checkboxTop = tempTop + Constants.CheckboxTopOffset();

                DrawCheckBox(_graphics, checkboxTop, checkBoxLeft, ct.DrawingOptions.Visible, false);

                var checkBoxBounds = GetCheckBoxBounds(checkBoxLeft, checkboxTop);
                _layer.Elements.Add(LayerElementType.CategoryCheckbox, checkBoxBounds, i);

                DrawShapefileCategoryText(tempTop, ct.Name, maxWidth, true);

                top += _layer.GetCategoryHeight(options);
                if (top >= ClientRectangle.Bottom && isSnapshot == false)
                {
                    // stop drawing in case there are not visible
                    break;
                }
            }
        }

        /// <summary>
        /// Draws shapefile category. It's assumed here that GetHDC and ReleaseHDC calls are made by caller.
        /// </summary>
        private void DrawShapefileCategorySymbology(IntPtr hdc, int top, ShapeDrawingOptions options, int categoryIndex, bool hasCheckbox)
        {
            var categoryHeight = _layer.GetCategoryHeight(options);
            var categoryWidth = _layer.GetCategoryWidth(options);

            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(Legend.BackColor));

            var left = _bounds.Left + Constants.TextLeftPad;

            if (hasCheckbox)
            {
                left += Constants.CategoryCheckboxWidthWithPadding();
            }

            if (categoryWidth != Constants.IconWidth)
            {
                left -= (categoryWidth - Constants.IconWidth) / 2;
            }

            switch (_layer.Type)
            {
                case LegendLayerType.PointShapefile:
                    options.DrawPoint(hdc, left, top, categoryWidth + 1, categoryHeight + 1, backColor);
                    break;
                case LegendLayerType.LineShapefile:
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
                    break;
                case LegendLayerType.PolygonShapefile:
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
                    break;
            }

            _layer.Elements.Add(LayerElementType.ColorBox, new Rectangle(left, top, categoryWidth, categoryHeight), categoryIndex);
        }

        /// <summary>
        /// Draw the text for the shapefile category
        /// </summary>
        private void DrawShapefileCategoryText(int top, string name, int maxWidth, bool hasCheckbox)
        {
            const int padding = 5;

            var left = _bounds.Left + Constants.TextLeftPad;
            left += (Constants.IconWidth / 2) + (maxWidth / 2) + padding;

            if (hasCheckbox)
            {
                left += Constants.CategoryCheckboxWidthWithPadding();
            }

            var rect = new Rectangle(
                left,
                top,
                _bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);

            DrawText(_graphics, name, rect, Font, Legend.ForeColor);
        }

        private void RenderCore()
        {
            var maxWidth = Constants.IconWidth;
            if (_layer.Type == LegendLayerType.PointShapefile)
            {
                maxWidth = _layer.get_MaxIconWidth(_sf);
            }

            var top = GetSymbologyTop(_bounds);
            var height = _layer.GetCategoryHeight(_sf.DefaultDrawingOptions) + Constants.VerticalPad;

            if (top + height > Legend.ClientRectangle.Top)
            {
                var hdc = _graphics.GetHdc();
                DrawShapefileCategorySymbology(hdc, top, _sf.DefaultDrawingOptions, -1, false);
                _graphics.ReleaseHdc(hdc);
            }

            top += height;

            DrawShapefileCategories(top, _isSnapshot, maxWidth);

            DrawCharts(top);
        }
    }
}