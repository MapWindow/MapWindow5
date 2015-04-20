using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Api.Legend
{
    /// <summary>
    /// Renders symbology preview in the expansion section below the layer.
    /// </summary>
    internal class RasterSymbologyRenderer : SymbologyRendererBase
    {
        public RasterSymbologyRenderer(LegendControl legend)
            : base(legend)
        {

        }

        /// <summary>
        /// Draws the raster symbology.
        /// </summary>
        public void Render(Graphics g, LegendLayer layer, Rectangle bounds, bool isSnapshot)
        {
            var top = GetSymbologyTop(bounds);

            var caption = layer.SymbologyCaption;

            DrawCategoriesCaption(g, bounds, ref top, caption, Font);

            DrawCategories(g, layer, bounds, ref top);
        }

        private void DrawCategories(Graphics g, LegendLayer layer, Rectangle bounds, ref int top)
        {
            var raster = layer.ImageSource as IRasterSource;
            if (raster == null)
            {
                return;
            }

            var left = bounds.Left + Constants.TextLeftPad;

            var r = new Rectangle(left, top + 1, Constants.IconWidth, Constants.CsItemHeight - 2);

            switch (raster.RenderingType)
            {
                case RenderingType.Grid:
                    RenderColorScheme(g, bounds, ref r, raster.CustomColorScheme, true);
                    break;
                case RenderingType.Rgb:
                    RenderColorScheme(g, bounds, ref r, raster.RgbBandMapping, false);
                    break;
                case RenderingType.Grayscale:
                    RenderColorScheme(g, bounds, ref r, raster.GrayScaleColorScheme, true, true);
                    break;
            }

            top = r.Y;
        }

        /// <summary>
        /// Renders color scheme (rectangle and name for each break).
        /// </summary>
        private void RenderColorScheme(Graphics g, Rectangle bounds, ref Rectangle r, RasterColorScheme scheme, bool gradients, bool horizontal = false)
        {
            if (scheme == null) return;

            var textRect = new Rectangle(
                r.Left + Constants.IconWidth + 3,
                r.Top,
                bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                Constants.TextHeight);

            foreach (var item in scheme)
            {
                Brush brush;
                if (gradients)
                {
                    brush = new LinearGradientBrush(r, item.LowColor, item.HighColor, horizontal ? 0.0f : 90.0f);
                }
                else
                {
                    brush = new SolidBrush(item.LowColor);
                }

                g.FillRectangle(brush, r);
                g.DrawRectangle(Pens.Gray, r);

                DrawText(g, item.Caption, textRect, Font, Color.Black);

                r.Y += Constants.CsItemHeightAndPad();
                textRect.Y += Constants.CsItemHeightAndPad();
            }
        }
    }
}
