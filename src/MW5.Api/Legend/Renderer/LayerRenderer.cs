using System;
using System.Drawing;
using AxMapWinGIS;
using MapWinGIS;
using MW5.Api.Legend.Events;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;

namespace MW5.Api.Legend.Renderer
{
    /// <summary>
    /// Draws a single layer in the legend.
    /// </summary>
    public class LayerRenderer: SymbologyRendererBase
    {
        protected readonly Font BoldFont;

        public LayerRenderer(LegendControlBase legend) 
            : base(legend)
        {
            BoldFont = new Font("Arial", 8, FontStyle.Bold);
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
            var textSize = DrawLayerCaption(g, lyr, bounds, isSnapshot);

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
            else
            {
                var renderer = new RasterSymbologyRenderer(Legend);
                renderer.Render(g, lyr, bounds, isSnapshot);
            }
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
             bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent -
             Constants.ExpandBoxLeftPad,
             bounds.Height - lyr.Top);

            if (lyr.Expanded && lyr.ExpansionBoxCustomRenderFunction != null)
            {
                var args = new LayerPaintEventArgs(lyr.Handle, customRect, g);
                Legend.FireEvent(this, lyr.ExpansionBoxCustomRenderFunction, args);
            }

            if (bounds.Width > 17 && isSnapshot == false)
            {
                var rect = new Rectangle(
                    bounds.Left,
                    bounds.Top,
                    bounds.Width - Constants.ItemRightPad,
                    bounds.Height);

                DrawExpansionBox(
                    g,
                    rect.Top + Constants.ExpandBoxTopPad,
                    rect.Left + Constants.ExpandBoxLeftPad,
                    lyr.Expanded);
            }
        }

        /// <summary>
        /// Gets position of text relative to the layer bounds.
        /// </summary>
        private Point GetTextLocation(Rectangle bounds, bool isSnapshot)
        {
            int curLeft = isSnapshot ? bounds.Left + Constants.CheckLeftPad : bounds.Left + Constants.TextLeftPad;
            int curTop = bounds.Top + Constants.TextTopPad;
            return new Point(curLeft, curTop);
        }

        /// <summary>
        /// Draws background of the layer caption when layer is selected.
        /// </summary>
        private void DrawLayerCaptionBackground(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
        {
            int curLeft = bounds.Left;
            int curTop = bounds.Top;

            if (!isSnapshot)
            {
                int curWidth = bounds.Width - Constants.ItemRightPad;
                const int curHeight = Constants.ItemHeight;
                var rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                if (lyr.Handle == Legend.SelectedLayerHandle && bounds.Width > 25 &&
                    (curTop + rect.Height > 0 || curTop < Legend.ClientRectangle.Height))
                {
                    DrawRectangle(g, rect, BoxLineColor, Legend.SelectionColor);
                    var el = new LayerElement(LayerElementType.ExpansionBox, rect);
                    lyr.Elements.Add(el);
                }
            }
            else
            {
                int curWidth = bounds.Width - 1;
                int curHeight = lyr.ExpandedHeight - 1;
                var rect = new Rectangle(curLeft, curTop, curWidth, curHeight);

                DrawRectangle(g, rect, BoxLineColor, Color.White);
            }
        }

        /// <summary>
        /// Draws the layer caption.
        /// </summary>
        private SizeF DrawLayerCaption(Graphics g, LegendLayer lyr, Rectangle bounds, bool isSnapshot)
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

            int curWidth = bounds.Width - Constants.TextRightPad - 27;
            const int curHeight = Constants.TextHeight;

            var rect = new Rectangle(point.X, point.Y, curWidth, curHeight);
            DrawText(g, text, rect, Legend.Font, Legend.ForeColor);

            var el = new LayerElement(LayerElementType.Name, rect, text);
            lyr.Elements.Add(el);

            return textSize;
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

            int curTop = bounds.Top + Constants.CheckTopPad;
            int curLeft = bounds.Left + Constants.CheckLeftPad;

           var visible = lyr.LayerVisibleAtCurrentScale && lyr.Visible;

            // draw a grey background if the layer is in dynamic visibility mode.
            DrawCheckBox(g, curTop, curLeft, visible, lyr.DynamicVisibility);

            var el = new LayerElement(LayerElementType.CheckBox, new Rectangle(curLeft, curTop, Constants.CheckBoxSize, Constants.CheckBoxSize));
            lyr.Elements.Add(el);
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
            var left = bounds.Right - 36;
            Image icon;

            var ogrLayer = lyr.VectorSource;
            if (ogrLayer != null)
            {
                icon = GetIcon(LegendIcon.Database);
                DrawPicture(g, left, textLocation.Y, Constants.IconSize, Constants.IconSize, icon);
            }
            else if (lyr.Icon != null)
            {
                DrawPicture(g, left, textLocation.Y, Constants.IconSize, Constants.IconSize, lyr.Icon);
            }
            else if (lyr.Type == LegendLayerType.Image)
            {
                icon = GetIcon(LegendIcon.Image);
                DrawPicture(g, left, top, Constants.IconSize, Constants.IconSize, icon);
            }
            else if (lyr.Type == LegendLayerType.Grid)
            {
                icon = GetIcon(LegendIcon.Grid);
                DrawPicture(g, left, top, Constants.IconSize, Constants.IconSize, icon);
            }
            else
            {
                // drawing shapefile symbology preview, but only in case the layer is collapsed
                if (!lyr.Expanded)
                {
                    lyr.SmallIconWasDrawn = true;

                    // drawing category symbol
                    var hdc = g.GetHdc();
                    var clr = (lyr.Handle == Legend.SelectedLayerHandle && bounds.Width > 25)
                        ? Legend.SelectionColor
                        : Legend.BackColor;
                    var backColor = Convert.ToUInt32(ColorTranslator.ToOle(clr));

                    var sf = Legend.AxMap.get_GetObject(lyr.Handle) as Shapefile;

                    if (sf != null)
                    {
                        if (lyr.Type == LegendLayerType.PointShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawPoint(
                                hdc,
                                left,
                                top,
                                Constants.IconSize,
                                Constants.IconSize,
                                backColor);
                        }
                        else if (lyr.Type == LegendLayerType.LineShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawLine(
                                hdc,
                                left,
                                top,
                                Constants.IconSize - 1,
                                Constants.IconSize - 1,
                                false,
                                Constants.IconSize,
                                Constants.IconSize,
                                backColor);
                        }
                        else if (lyr.Type == LegendLayerType.PolygonShapefile)
                        {
                            sf.DefaultDrawingOptions.DrawRectangle(
                                hdc,
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
                }
            }

            var map = Legend.AxMap;

            // labels link
            if (bounds.Width > 60 && bounds.Right - textLocation.X - 62 > textSize.Width)
            {
                var sf = map.get_Shapefile(lyr.Handle);
                if (sf != null)
                {
                    var top2 = bounds.Top + Constants.IconTopPad;
                    var left2 = bounds.Right - 56;

                    var scale = map.CurrentScale;
                    var labelsVisible = sf.Labels.Count > 0 && sf.Labels.Visible &&
                                        sf.Labels.Expression.Trim() != string.Empty;
                    labelsVisible &= scale >= sf.Labels.MinVisibleScale && scale <= sf.Labels.MaxVisibleScale;

                    var icon2 = GetIcon(labelsVisible ? LegendIcon.ActiveLabel : LegendIcon.DimmedLabel);
                    DrawPicture(g, left2, top2, Constants.IconSize, Constants.IconSize, icon2);
                }
            }

            // editing icon
            if (bounds.Width > 60 && bounds.Right - textLocation.X - 82 > textSize.Width)
            {
                var sf = map.get_Shapefile(lyr.Handle);
                if (sf != null && sf.InteractiveEditing)
                {
                    var top2 = bounds.Top + Constants.IconTopPad;
                    var left2 = bounds.Right - 76;
                    DrawPicture(
                        g,
                        left2,
                        top2,
                        Constants.IconSize,
                        Constants.IconSize,
                        GetIcon(LegendIcon.Editing));
                }
            }
        }

        /// <summary>
        /// The draw check box.
        /// </summary>
        protected void DrawCheckBox(Graphics g, int itemTop, int itemLeft, bool drawCheck, bool drawGrayBackground)
        {
            LegendIcon icon;
            if (drawCheck)
            {
                icon = drawGrayBackground ? LegendIcon.CheckedBoxGray : LegendIcon.CheckedBox;
            }
            else
            {
                icon = drawGrayBackground ? LegendIcon.UnCheckedBoxGray : LegendIcon.UnCheckedBox;
            }

            var image = GetIcon(icon);
            DrawPicture(g, itemLeft, itemTop, Constants.CheckBoxSize, Constants.CheckBoxSize, image);
        }
    }
}
