using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace MW5.Api.Legend.Renderer
{
    public class SymbologyRendererBase
    {
        protected readonly LegendControlBase Legend;
        private readonly Color _boxLineColor;

        public SymbologyRendererBase(LegendControlBase legend)
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
            get { return Legend.Font; }
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

        protected Rectangle GetExpansionBoxBounds(int top, int left)
        {
            return new Rectangle(left, top, Constants.ExpandBoxSize, Constants.ExpandBoxSize);
        }

        /// <summary>
        /// Expansion box with plus or minus sign
        /// </summary>
        protected void DrawExpansionBox(Graphics g, int itemTop, int itemLeft, bool expanded)
        {
            var rect = GetExpansionBoxBounds(itemTop, itemLeft);

            var points = new Point[3];
            if (!expanded)
            {
                points[0] = new Point(Convert.ToInt32(rect.Left + (.5 * rect.Width)), rect.Bottom);
                points[1] = new Point(Convert.ToInt32(rect.Left + (.5 * rect.Width)), rect.Top);
                points[2] = new Point(rect.Right, Convert.ToInt32(rect.Top + (.5 * rect.Height)));
            }
            else
            {
                points[0] = new Point(rect.Left, rect.Bottom);
                points[1] = new Point(rect.Right - 1, rect.Bottom);
                points[2] = new Point(rect.Right - 1, rect.Top + 1);
            }

            g.FillPolygon(Brushes.Black, points);
        }

        protected Rectangle GetCheckBoxBounds(int top, int left)
        {
            return new Rectangle(top, left, Constants.CheckBoxSize, Constants.CheckBoxSize);
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
