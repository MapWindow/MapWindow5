using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MW5.Api.Legend.Renderer
{
    public class SymbologyRendererBase
    {
        protected readonly LegendControl Legend;
        private readonly Color _boxLineColor;

        public SymbologyRendererBase(LegendControl legend)
        {
            if (legend == null) throw new ArgumentNullException("legend");
            Legend = legend;

            _boxLineColor = Color.Gray;
        }

        protected Color BoxLineColor
        {
            get { return _boxLineColor; }
        }

        internal Image GetIcon(LegendIcon icon)
        {
            return Legend.Icons.GetIcon(icon);
        }

        public Rectangle ClientRectangle
        {
            get { return Legend.ClientRectangle; }
        }

        public Font Font
        {
            get { return Legend.InternalFont; }
        }

        public int GetSymbologyTop(Rectangle bounds)
        {
            return bounds.Top + Constants.ItemHeight + Constants.VerticalPad;
        }

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

                DrawText(g, text, rect, font, Legend.ForeColor);
            }

            top += Constants.CsItemHeight + Constants.VerticalPad;
        }


        /// <summary>
        /// The draw text.
        /// </summary>
        protected void DrawText(Graphics g, string text, Rectangle rect, Font font)
        {
            DrawText(g, text, rect, font, Color.Black);
        }


        /// <summary>
        /// Drawing a rectangle with fil.
        /// </summary>
        protected void DrawRectangle(Graphics g, Rectangle rect, Color lineColor, Color backColor)
        {
            var pen = new Pen(backColor);
            g.FillRectangle(pen.Brush, rect);

            pen = new Pen(lineColor);
            g.DrawRectangle(pen, rect);
        }

        /// <summary>
        /// Draws picture in the legend. Picture can be either an image or an icon
        /// </summary>
        protected void DrawPicture(Graphics g, int picLeft, int picTop, int picWidth, int picHeight, object picture)
        {
            if (picture == null)
            {
                return;
            }

            var oldSm = g.SmoothingMode;
            g.SmoothingMode = SmoothingMode.HighQuality;

            var rect = new Rectangle(picLeft, picTop, picWidth, picHeight);

            var icon = picture as Icon;

            if (icon != null)
            {
                g.DrawIcon(icon, rect);
            }
            else
            {
                // try casting it to an Image
                Image img = null;
                try
                {
                    img = (Image)picture;
                }
                catch (InvalidCastException)
                {
                }

                if (img != null)
                {
                    g.DrawImage(img, rect);
                }
                else
                {
                    MapWinGIS.Image mwImg = null;
                    try
                    {
                        mwImg = (MapWinGIS.Image)picture;
                    }
                    catch (InvalidCastException)
                    {
                    }

                    if (mwImg != null)
                    {
                        try
                        {
                            img = Image.FromHbitmap(new IntPtr(mwImg.Picture.Handle));
                            g.DrawImage(img, rect);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
            }

            g.SmoothingMode = oldSm;
        }

        /// <summary>
        /// Expansion box with plus or minus sign
        /// </summary>
        protected void DrawExpansionBox(Graphics g, int itemTop, int itemLeft, bool expanded)
        {
            var pen = new Pen(_boxLineColor, 1);

            var rect = new Rectangle(itemLeft, itemTop, Constants.ExpandBoxSize, Constants.ExpandBoxSize);

            // draw the border
            DrawRectangle(g, rect, _boxLineColor, Color.White);

            var midX = (int)(rect.Left + (.5 * rect.Width));
            var midY = (int)(rect.Top + (.5 * rect.Height));

            if (!expanded)
            {
                // draw a + sign, indicating that there is more to be seen
                // draw the vertical part
                g.DrawLine(pen, midX, itemTop + 2, midX, itemTop + Constants.ExpandBoxSize - 2);

                // draw the horizontal part
                g.DrawLine(pen, itemLeft + 2, midY, itemLeft + Constants.ExpandBoxSize - 2, midY);
            }
            else
            {
                // draw a - sign
                g.DrawLine(pen, itemLeft + 2, midY, itemLeft + Constants.ExpandBoxSize - 2, midY);
            }
        }
    }
}
