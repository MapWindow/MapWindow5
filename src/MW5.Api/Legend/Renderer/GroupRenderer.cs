using System.Drawing;
using System.Linq;

namespace MW5.Api.Legend.Renderer
{
    /// <summary>
    /// Renders a single group in the legend.
    /// </summary>
    public class GroupRenderer: LayerRenderer
    {
        public GroupRenderer(LegendControlBase legend) : base(legend) 
        {
        }

        /// <summary>
        /// Draws a group onto a give graphics object (surface)
        /// </summary>
        /// <param name="g"> Graphics object with which to draw </param>
        /// <param name="grp"> Group to be drawn </param>
        /// <param name="bounds"> Clipping boundaries for this group </param>
        /// <param name="isSnapshot"> Drawing is handled in special way if this is a Snapshot </param>
        internal protected void DrawGroup(Graphics g, LegendGroup grp, Rectangle bounds, bool isSnapshot)
        {
            int curLeft,
                curWidth,
                curTop = bounds.Top,
                curHeight;

            Rectangle rect;

            var drawCheck = false;

            // Color BoxBackColor = Color.White;
            var drawGrayCheckbox = false;
            grp.Top = bounds.Top;

            if (grp.Visible == Visibility.AllVisible || grp.Visible == Visibility.PartiallyVisible)
            {
                drawCheck = true;
            }

            // draw the border if the group is the one that contains the selected layer and
            // the group is collapsed
            if (grp.Handle == Legend.SelectedGroupHandle && grp.Expanded == false && isSnapshot == false)
            {
                rect = new Rectangle(
                    Constants.GrpIndent,
                    curTop,
                    bounds.Width - Constants.GrpIndent - Constants.ItemRightPad,
                    Constants.ItemHeight);
                DrawRectangle(g, rect, BoxLineColor, Legend.SelectionColor);
            }

            // draw the +- box if there are sub items
            if (grp.Layers.Any() && isSnapshot == false)
            {
                DrawExpansionBox(
                    g,
                    bounds.Top + Constants.ExpandBoxTopPad,
                    Constants.GrpIndent + Constants.ExpandBoxLeftPad,
                    grp.Expanded);
            }

            if (grp.Visible == Visibility.PartiallyVisible)
            {
                drawGrayCheckbox = true;
            }

            if (Legend.DrawLines && !isSnapshot && grp.Expanded && grp.Layers.Any())
            {
                var endY = grp.Top + Constants.ItemHeight;

                var blackPen = new Pen(BoxLineColor);
                g.DrawLine(
                    blackPen,
                    Constants.VertLineIndent,
                    bounds.Top + Constants.VertLineGrpTopOffset,
                    Constants.VertLineIndent,
                    endY);
            }

            if (bounds.Width > 35 && isSnapshot == false)
            {
                if (!grp.StateLocked)
                {
                    curLeft = Constants.GrpIndent + Constants.CheckLeftPad;
                    DrawCheckBox(
                        g,
                        bounds.Top + Constants.CheckTopPad,
                        curLeft,
                        drawCheck,
                        drawGrayCheckbox);
                }
            }

            if (grp.Icon != null && bounds.Width > 55)
            {
                // draw the icon
                DrawPicture(
                    g,
                    bounds.Right - Constants.IconRightPad,
                    curTop + Constants.IconTopPad,
                    Constants.IconSize,
                    Constants.IconSize,
                    grp.Icon);

                // set the boundaries for text so that the text and icon don't overlap
                curLeft = isSnapshot ? Constants.GrpIndent : Constants.GrpIndent + Constants.TextLeftPad;

                curTop = bounds.Top + Constants.TextTopPad;
                curWidth = bounds.Width - curLeft - Constants.TextRightPad;
                curHeight = Constants.TextHeight;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);
            }
            else
            {
                // Bitmap bmp = MWLite.Symbology.Properties.Resources.folder_open;
                // DrawPicture(DrawTool, bounds.Right - Constants.ICON_RIGHT_PAD, CurTop + Constants.ICON_TOP_PAD, Constants.ICON_SIZE, Constants.ICON_SIZE, bmp);
                if (isSnapshot)
                {
                    curLeft = Constants.GrpIndent;
                }
                else
                {
                    curLeft = Constants.GrpIndent + Constants.TextLeftPad;
                }

                curTop = bounds.Top + Constants.TextTopPad;
                curWidth = bounds.Width - curLeft - Constants.TextRightPadNoIcon;
                curHeight = Constants.TextHeight;
                rect = new Rectangle(curLeft, curTop, curWidth, curHeight);
            }

            // group icon
            if (Legend.ShowGroupIcons)
            {
                const int size = 16;
                Bitmap bmp = GetIcon(grp.Expanded ? LegendIcon.FolderOpened : LegendIcon.Folder) as Bitmap;
                rect.Offset(0, -2);
                DrawPicture(g, rect.Left, rect.Top, size, size, bmp);
                rect = new Rectangle(rect.X + size + 3, rect.Y + 2, rect.Width - size, rect.Height);
            }

            // group name
            if (grp.Handle == Legend.SelectedGroupHandle && !isSnapshot)
            {
                DrawText(g, grp.Text, rect, BoldFont);
            }
            else
            {
                DrawText(g, grp.Text, rect, Legend.Font);
            }

            // set up the boundaries for drawing list items
            curTop = bounds.Top + Constants.ItemHeight;

            if (!grp.Expanded && !isSnapshot) return;

            var itemCount = grp.Layers.Count();
            var newLeft = bounds.X + Constants.ListItemIndent;
            var newWidth = bounds.Width - newLeft;
            rect = new Rectangle(newLeft, curTop, newWidth, bounds.Height - curTop);

            // now draw each of the subitems
            for (var i = itemCount - 1; i >= 0; i--)
            {
                var lyr = grp.LayersList[i];
                lyr.ScheduleHeightRecalc();

                if (lyr.HideFromLegend)
                {
                    continue;
                }

                // clipping
                if (rect.Top + lyr.Height < Legend.ClientRectangle.Top && isSnapshot == false)
                {
                    // update the rectangle for the next layer
                    rect.Y += lyr.Height;
                    rect.Height -= lyr.Height;

                    // Skip drawing this layer and move onto the next one
                    continue;
                }

                DrawLayer(g, lyr, rect, isSnapshot);

                DrawLayerLines(isSnapshot, g, grp, lyr, i, ref rect);

                // set up the rectangle for the next layer
                rect.Y += lyr.Height;
                rect.Height -= lyr.Height;

                if (rect.Top >= Legend.ClientRectangle.Bottom && !isSnapshot)
                {
                    break;
                }
            }
        }

        private void DrawLayerLines(bool isSnapshot, Graphics g, LegendGroup grp, LegendLayer lyr, int i, ref Rectangle rect)
        {
            if (isSnapshot || !Legend.DrawLines)
            {
                return;
            }

            var pen = new Pen(BoxLineColor);

            // draw sub-item vertical line
            if (i != 0 && !grp.Layers[i - 1].HideFromLegend)
            {
                // not the last visible layer
                g.DrawLine(
                    pen,
                    Constants.VertLineIndent,
                    lyr.Top,
                    Constants.VertLineIndent,
                    lyr.Top + lyr.Height + Constants.ItemPad);
            }
            else
            {
                // only draw down to box, not down to next item in list(since there is no next item)
                g.DrawLine(
                    pen,
                    Constants.VertLineIndent,
                    lyr.Top,
                    Constants.VertLineIndent,
                    (int)(lyr.Top + (.5 * Constants.ItemHeight)));
            }

            // draw Horizontal line over to the Vertical Sub-lyr line
            int curTop = (int)(rect.Top + (.5 * Constants.ItemHeight));

            g.DrawLine(
                pen,
                Constants.VertLineIndent,
                curTop,
                rect.Left + Constants.ExpandBoxLeftPad - 3,
                curTop);
        }
    }
}
