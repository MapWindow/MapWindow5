// -------------------------------------------------------------------------------------------
// <copyright file="LayerRenderer.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Api.Legend.Events;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace MW5.Api.Legend.Renderer
{
    /// <summary>
    /// Draws a single layer in the legend.
    /// </summary>
    public class LayerRenderer : SymbologyRendererBase
    {
        public LayerRenderer(LegendControlBase legend)
            : base(legend)
        {
        }

        public Font BoldFont
        {
            get { return new Font(Legend.Font, FontStyle.Bold); }
        }

        /// <summary>
        /// Draws a layer onto a given graphics surface
        /// </summary>
        /// <param name="g"> Graphics surface (object) onto which the give layer should be drawn </param>
        /// <param name="lyr"> Layer object to be drawn </param>
        /// <param name="bounds"> Rectangle oulining the allowable draw area </param>
        /// <param name="isSnapshot"> Drawing is done differently when it is a snapshot we are takeing of this layer </param>
        public void DrawLayer(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            lyr.SmallIconWasDrawn = false;
            lyr.Top = bounds.Top;
            lyr.Elements.Clear();

            // drawing background
            DrawLayerCaptionBackground(g, lyr, bounds, isSnapshot);

            // drawing checkbox
            DrawLayerCheckBox(g, lyr, bounds, isSnapshot);

            // drawing text
            var textSize = DrawLayerName(g, lyr, bounds, isSnapshot);

            // icons to the right of the layer name
            DrawLayerIcon(g, lyr, bounds, textSize, isSnapshot);

            // ----------------------------------------------------------
            // Drawing expansion box
            // ----------------------------------------------------------
            DrawLayerExpansionBox(g, lyr, bounds, isSnapshot);

            // ----------------------------------------------------------
            //   Symbology below the layer name
            // ----------------------------------------------------------
            if ((!isSnapshot && !lyr.Expanded) || bounds.Width <= 47)
            {
                return;
            }

            if (lyr.IsVector)
            {
                var renderer = new VectorSymbologyRenderer(Legend);
                renderer.Render(g, lyr, bounds, isSnapshot);
            }
            else if (lyr.LayerType == Enums.LayerType.WmsLayer)
            {
                var renderer = new WmsSymbologyRenderer(Legend);
                renderer.Render(g, lyr, bounds, isSnapshot);
            }
            else
            {
                var renderer = new RasterSymbologyRenderer(Legend);
                renderer.Render(g, lyr, bounds, isSnapshot);
            }
        }

        /// <summary>
        /// Draws background of the layer caption when layer is selected.
        /// </summary>
        private void DrawLayerCaptionBackground(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            var curLeft = bounds.Left;
            var curTop = bounds.Top;

            if (!isSnapshot)
            {
                var curWidth = bounds.Width - Constants.ItemRightPad;
                const int curHeight = Constants.ItemHeight;
                var rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                if (lyr.Handle == Legend.SelectedLayerHandle && bounds.Width > 25
                    && (curTop + rect.Height > 0 || curTop < Legend.ClientRectangle.Height))
                {
                    DrawRectangle(g, rect, BoxLineColor, Legend.SelectionColor);
                }
            }
            else
            {
                var curWidth = bounds.Width - 1;
                var curHeight = lyr.ExpandedHeight - 1;
                var rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                DrawRectangle(g, rect, BoxLineColor, Color.White);
            }
        }

        /// <summary>
        /// Draws the checkbox for specified layer.
        /// </summary>
        private void DrawLayerCheckBox(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            if (bounds.Width < 55 || isSnapshot)
            {
                return;
            }

            var curTop = bounds.Top + Constants.CheckTopPad;
            var curLeft = bounds.Left + Constants.CheckLeftPad;

            var visible = lyr.LayerVisibleAtCurrentScale && lyr.Visible;

            // draw a grey background if the layer is in dynamic visibility mode.
            DrawCheckBox(g, curTop, curLeft, visible, lyr.DynamicVisibility);

            var rect = new Rectangle(curLeft, curTop, Constants.CheckBoxSize, Constants.CheckBoxSize);

            lyr.Elements.Add(LayerElementType.CheckBox, rect);
        }

        /// <summary>
        /// Dras plus minus/sign for the layer and optionally call custom rendering function to display symbology.
        /// </summary>
        /// <param name="g">The g.</param>
        /// <param name="lyr">The lyr.</param>
        /// <param name="bounds">The bounds.</param>
        /// <param name="isSnapshot">if set to <c>true</c> [is snapshot].</param>
        private void DrawLayerExpansionBox(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            var customRect = new Rectangle(
                bounds.Left + Constants.CheckLeftPad,
                lyr.Top + Constants.ItemHeight + Constants.ExpandBoxTopPad,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent - Constants.ExpandBoxLeftPad,
                bounds.Height - lyr.Top);

            if (lyr.Expanded && lyr.ExpansionBoxCustomRenderFunction != null)
            {
                var args = new LayerPaintEventArgs(lyr.Handle, customRect, g);
                Legend.FireEvent(this, lyr.ExpansionBoxCustomRenderFunction, args);
            }

            if (bounds.Width > 17 && isSnapshot == false)
            {
                var rect = new Rectangle(bounds.Left, bounds.Top, bounds.Width - Constants.ItemRightPad, bounds.Height);

                DrawExpansionBox(
                    g,
                    rect.Top + Constants.ExpandBoxTopPad,
                    rect.Left + Constants.ExpandBoxLeftPad,
                    lyr.Expanded);

                var box = GetExpansionBoxBounds(rect.Top + Constants.ExpandBoxTopPad, rect.Left + Constants.ExpandBoxLeftPad);
                lyr.Elements.Add(LayerElementType.ExpansionBox, box);
            }
        }

        private int GetIconRightOffset(LegendThumbnailType type)
        {
            switch (type)
            {
                case LegendThumbnailType.Labels:
                    return 56;
                case LegendThumbnailType.Editing:
                    return 76;
                case LegendThumbnailType.Symbology:
                default:
                    return 36;
            }
        }

        private int GetTextRightOffset(LegendLayer layer)
        {
            if (layer.IsVector && layer.FeatureSet.InteractiveEditing)
            {
                return GetIconRightOffset(LegendThumbnailType.Editing);
            }

            return GetIconRightOffset(LegendThumbnailType.Labels);
        }

        /// <summary>
        /// Draws layer icon to the right of the name.
        /// </summary>
        private void DrawLayerIcon(Graphics g, LegendLayer lyr, Rectangle bounds, SizeF textSize, bool isSnapshot)
        {
            var textLocation = GetTextLocation(bounds, isSnapshot);

            if (bounds.Width <= 60 || bounds.Right - textLocation.X - 41 <= textSize.Width)
            {
                return;
            }

            // -5 (offset)
            var top = bounds.Top + Constants.IconTopPad;
            var left = bounds.Right - GetIconRightOffset(LegendThumbnailType.Symbology);
            Image icon;

            if (lyr.LayerType == LayerType.VectorLayer)
            {
                icon = GetIcon(LegendIcon.Database);
                DrawPicture(g, left, textLocation.Y, Constants.IconSize, Constants.IconSize, icon);
            }
            else if (lyr.LegendLayerType == LegendLayerType.WmsLayer)
            {
                icon = GetIcon(LegendIcon.WmsLayer);
                DrawPicture(g, left, textLocation.Y, Constants.IconSize, Constants.IconSize, icon);
            }
            else if (lyr.Icon != null)
            {
                DrawPicture(g, left, textLocation.Y, Constants.IconSize, Constants.IconSize, lyr.Icon);
            }
            else if (lyr.LegendLayerType == LegendLayerType.Image)
            {
                icon = GetIcon(LegendIcon.Image);
                DrawPicture(g, left, top, Constants.IconSize, Constants.IconSize, icon);
            }
            else if (lyr.LegendLayerType == LegendLayerType.Grid)
            {
                icon = GetIcon(LegendIcon.Grid);
                DrawPicture(g, left, top, Constants.IconSize, Constants.IconSize, icon);
            }
            else
            {
                DrawSmallColorBox(g, lyr, bounds, top, left);
            }

            var map = Legend.AxMap;

            // labels link
            if (bounds.Width > 60 && bounds.Right - textLocation.X - 62 > textSize.Width)
            {
                var sf = map.get_Shapefile(lyr.Handle);
                if (sf != null)
                {
                    var top2 = bounds.Top + Constants.IconTopPad;
                    var left2 = bounds.Right - GetIconRightOffset(LegendThumbnailType.Labels);

                    var scale = map.CurrentScale;
                    var labelsVisible = sf.Labels.Count > 0 && sf.Labels.Visible
                                        && sf.Labels.Expression.Trim() != string.Empty;
                    labelsVisible &= scale >= sf.Labels.MinVisibleScale && scale <= sf.Labels.MaxVisibleScale;

                    var icon2 = GetIcon(labelsVisible ? LegendIcon.ActiveLabel : LegendIcon.DimmedLabel);
                    DrawPicture(g, left2, top2, Constants.IconSize, Constants.IconSize, icon2);

                    lyr.Elements.Add(
                        LayerElementType.Label,
                        new Rectangle(left2, top2, Constants.IconSize, Constants.IconSize));
                }
            }

            // editing icon
            if (bounds.Width > 60 && bounds.Right - textLocation.X - 82 > textSize.Width)
            {
                var sf = map.get_Shapefile(lyr.Handle);
                if (sf != null && sf.InteractiveEditing)
                {
                    var top2 = bounds.Top + Constants.IconTopPad;
                    var left2 = bounds.Right - GetIconRightOffset(LegendThumbnailType.Editing);
                    DrawPicture(g, left2, top2, Constants.IconSize, Constants.IconSize, GetIcon(LegendIcon.Editing));
                }
            }
        }

        /// <summary>
        /// Color box to the right of the layer name when the layer is collapsed.
        /// </summary>
        private void DrawSmallColorBox(Graphics g, LegendLayer lyr, Rectangle bounds, int top, int left)
        {
            if (lyr.Expanded) return;

            lyr.SmallIconWasDrawn = true;

            // drawing category symbol
            var hdc = g.GetHdc();
            var hdcInt = hdc.ToInt32();
            var clr = (lyr.Handle == Legend.SelectedLayerHandle && bounds.Width > 25)
                          ? Legend.SelectionColor
                          : Legend.BackColor;

            var backColor = Convert.ToUInt32(ColorTranslator.ToOle(clr));

            var sf = Legend.AxMap.get_GetObject(lyr.Handle) as Shapefile;

            if (sf != null)
            {
                if (lyr.LegendLayerType == LegendLayerType.PointShapefile)
                {
                    sf.DefaultDrawingOptions.DrawPoint(
                        hdcInt,
                        left,
                        top,
                        Constants.IconSize,
                        Constants.IconSize,
                        backColor);
                }
                else if (lyr.LegendLayerType == LegendLayerType.LineShapefile)
                {
                    sf.DefaultDrawingOptions.DrawLine(
                        hdcInt,
                        left,
                        top,
                        Constants.IconSize - 1,
                        Constants.IconSize - 1,
                        false,
                        Constants.IconSize,
                        Constants.IconSize,
                        backColor);
                }
                else if (lyr.LegendLayerType == LegendLayerType.PolygonShapefile)
                {
                    sf.DefaultDrawingOptions.DrawRectangle(
                        hdcInt,
                        left,
                        top,
                        Constants.IconSize - 1,
                        Constants.IconSize - 1,
                        false,
                        Constants.IconSize,
                        Constants.IconSize,
                        backColor);
                }
            }

            g.ReleaseHdc(hdc);

            lyr.Elements.Add(
                LayerElementType.ColorBox,
                new Rectangle(left, top, Constants.IconSize, Constants.IconSize));
        }

        /// <summary>
        /// Draws the layer caption.
        /// </summary>
        private SizeF DrawLayerName(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            var textSize = new SizeF(0.0f, 0.0f);

            if (bounds.Width <= 60)
            {
                return textSize;
            }

            // draw text
            var text = Legend.AxMap.get_LayerName(lyr.Handle);
            textSize = g.MeasureString(text, Legend.Font);

            var point = GetTextLocation(bounds, isSnapshot);

            var curWidth = bounds.Width - GetTextRightOffset(lyr) - Constants.TextLeftPad - Constants.TextEditingRightPad;

            var rect = new Rectangle(point.X, point.Y, curWidth, Constants.TextHeight);
            DrawText(g, text, rect, Legend.Font, Legend.ForeColor);

            lyr.Elements.Add(LayerElementType.Name, rect);

            return textSize;
        }

        /// <summary>
        /// Gets position of text relative to the layer bounds.
        /// </summary>
        private Point GetTextLocation(Rectangle bounds, bool isSnapshot)
        {
            var curLeft = isSnapshot ? bounds.Left + Constants.CheckLeftPad : bounds.Left + Constants.TextLeftPad;
            var curTop = bounds.Top + Constants.TextTopPad;
            return new Point(curLeft, curTop);
        }
    }
}