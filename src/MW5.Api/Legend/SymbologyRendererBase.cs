using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend
{
    internal class SymbologyRendererBase
    {
        protected readonly LegendControl _legend;

        public SymbologyRendererBase(LegendControl legend)
        {
            if (legend == null) throw new ArgumentNullException("legend");
            _legend = legend;
        }

        public Rectangle ClientRectangle
        {
            get { return _legend.ClientRectangle; }
        }

        public Font Font
        {
            get { return _legend.InternalFont; }
        }

        public int GetSymbologyTop(Rectangle bounds)
        {
            return bounds.Top + Constants.ItemHeight + Constants.VerticalPad;
        }

        /// <summary>
        /// The draw text.
        /// </summary>
        protected void DrawText(Graphics g, string text, Rectangle rect, Font font, Color penColor)
        {
            var pen = new Pen(penColor);
            g.DrawString(text, font, pen.Brush, rect);
        }

        /// <summary>
        /// Draws the categories caption.
        /// </summary>
        protected void DrawCategoriesCaption(Graphics g, Rectangle bounds, ref int top, string text, Font font)
        {
            var left = bounds.Left + Constants.TextLeftPad;
            if (top + Constants.TextHeight >= 0)
            {
                var rect = new Rectangle(
                    left,
                    top,
                    bounds.Width - Constants.TextRightPadNoIcon - Constants.CsTextLeftIndent,
                    Constants.TextHeight);

                DrawText(g, text, rect, font, _legend.ForeColor);
            }

            top += Constants.CsItemHeight + Constants.VerticalPad;
        }
    }
}
