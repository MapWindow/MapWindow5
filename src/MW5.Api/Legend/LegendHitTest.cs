using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MapWinGIS;
using Point = System.Drawing.Point;

namespace MW5.Api.Legend
{
    public class LegendHitTest
    {
        private readonly LegendControlBase _legend;

        public LegendHitTest(LegendControlBase legend)
        {
            if (legend == null) throw new ArgumentNullException("legend");
            _legend = legend;
        }


        /// <summary>
        /// Locates the group that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point"> The point inside of the legend that was clicked. </param>
        /// <param name="inCheckbox"> (by reference/out) Indicates whether a group visibilty check box was clicked. </param>
        /// <param name="inExpandbox"> (by reference/out) Indicates whether the expand box next to a group was clicked. </param>
        /// <returns> Returns the group that was clicked on or null/nothing. </returns>
        public LegendGroup FindClickedGroup(Point point, out bool inCheckbox, out bool inExpandbox)
        {
            // finds the group that was clicked, i.e. heading of group, not subitems
            inExpandbox = false;
            inCheckbox = false;

            var groups = _legend.Groups as LegendGroups;
            if (groups == null)
            {
                return null;
            }

            var groupCount = groups.Count;

            for (var i = 0; i < groupCount; i++)
            {
                var grp = groups.GetGroupInternal(i);

                // set group header bounds
                var curLeft = Constants.GrpIndent;
                var curWidth = _legend.Width - Constants.GrpIndent - Constants.ItemRightPad;
                var curTop = grp.Top;
                var curHeight = Constants.ItemHeight;
                var bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                if (bounds.Contains(point))
                {
                    // we are in the group heading
                    // now check to see if the click was in the expansion box
                    // +- a little to make the hot spot a little more precise
                    curLeft = Constants.GrpIndent + Constants.ExpandBoxLeftPad + 1;
                    curWidth = Constants.ExpandBoxSize - 1;
                    curTop = grp.Top + Constants.ExpandBoxTopPad + 1;
                    curHeight = Constants.ExpandBoxSize - 1;
                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                    if (bounds.Contains(point))
                    {
                        // we are in the bounds for the expansion box
                        // but only if there is an expansion box visible
                        if (grp.Layers.Count > 0)
                        {
                            inExpandbox = true;
                        }
                    }
                    else
                    {
                        // now check to see if in the check box
                        curLeft = Constants.GrpIndent + Constants.CheckLeftPad + 1;
                        curWidth = Constants.CheckBoxSize - 1;
                        curTop = grp.Top + Constants.CheckTopPad + 1;
                        curHeight = Constants.CheckBoxSize - 1;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                        if (bounds.Contains(point))
                        {
                            inCheckbox = true;
                        }
                    }

                    return grp;
                }
            }

            return null; // if we get to this point, no group item found
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        public LegendLayer FindClickedLayer(Point point, out bool inCheckBox, out bool inExpansionBox)
        {
            var element = new ClickedElement();
            var lyr = FindClickedLayer(point, ref element);
            inCheckBox = element.CheckBox;
            inExpansionBox = element.ExpansionBox;
            return lyr;
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend.
        /// </summary>
        public LegendLayer FindClickedLayer(Point point, ref ClickedElement element)
        {
            var groups = _legend.Groups as LegendGroups;
            if (groups == null)
            {
                return null;
            }

            var groupCount = groups.Count;

            element.Nullify();

            for (var i = 0; i < groupCount; i++)
            {
                var grp = groups.GetGroupInternal(i);

                if (grp.Expanded == false)
                {
                    continue;
                }

                var layerCount = grp.Layers.Count;

                for (var j = 0; j < layerCount; j++)
                {
                    var lyr = grp.LayersInternal[j];

                    // see if we are inside the current Layer
                    var curLeft = Constants.ListItemIndent;
                    var curTop = lyr.Top;
                    var curWidth = _legend.Width - curLeft - Constants.ItemRightPad;
                    var curHeight = lyr.Height;
                    var bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                    // TODO: use layer.Elements instead recalculation of all bounds
                    if (bounds.Contains(point))
                    {
                        // we are inside the Layer boundaries,
                        // but we need to narrow down the search
                        element.GroupIndex = i;

                        // check to see if in the check box
                        curLeft = Constants.ListItemIndent + Constants.CheckLeftPad + 1;
                        curTop = lyr.Top + Constants.CheckTopPad + 1;
                        curWidth = Constants.CheckBoxSize - 1;
                        curHeight = Constants.CheckBoxSize - 1;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                        if (bounds.Contains(point))
                        {
                            // we are in the check box
                            element.CheckBox = true;
                            return lyr;
                        }

                        // check to see if we are in the expansion box for this item
                        curLeft = Constants.ListItemIndent + Constants.ExpandBoxLeftPad + 1;
                        curTop = lyr.Top + Constants.ExpandBoxTopPad + 1;
                        curWidth = Constants.ExpandBoxSize;
                        curHeight = Constants.ExpandBoxSize;
                        bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                        if (bounds.Contains(point))
                        {
                            // We are in the Expansion box
                            element.ExpansionBox = true;
                            return lyr;
                        }

                        if (lyr.IsRaster)
                        {
                            foreach (var item in lyr.Elements)
                            {
                                if (item.ElementType == LayerElementType.RasterColorInterval && item.PointWithin(point))
                                {
                                    element.ColorBox = true;
                                    element.CategoryIndex = -1;
                                    return lyr;
                                }
                            }

                            return lyr;
                        }

                        if (!lyr.Expanded && lyr.IsVector && lyr.SmallIconWasDrawn)
                        {
                            curHeight = Constants.IconSize;
                            curWidth = Constants.IconSize;
                            curTop = lyr.Top + Constants.IconTopPad;
                            curLeft = _legend.Width - 36;
                            if (_legend.VScrollBar.Visible)
                            {
                                curLeft -= _legend.VScrollBar.Width;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                            if (bounds.Contains(point))
                            {
                                element.ColorBox = true;
                                return lyr;
                            }
                        }

                        // layer icon (to the right from the caption)
                        if (lyr.IsVector)
                        {
                            curHeight = Constants.IconSize;
                            curWidth = Constants.IconSize;
                            curTop = lyr.Top + Constants.IconTopPad;
                            curLeft = _legend.Width - 56;
                            if (_legend.VScrollBar.Visible)
                            {
                                curLeft -= _legend.VScrollBar.Width;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);
                            if (bounds.Contains(point))
                            {
                                element.LabelsIcon = true;
                                return lyr;
                            }
                        }

                        // check to see if we are in the default color box
                        var sf = _legend.AxMap.get_GetObject(lyr.Handle) as Shapefile;

                        if (sf != null)
                        {
                            curHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                            curWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                            curTop = lyr.Top + Constants.ItemHeight + 2;
                            curLeft = Constants.ListItemIndent + Constants.TextLeftPad;
                            if (curWidth != Constants.IconWidth)
                            {
                                curLeft -= (curWidth - Constants.IconWidth) / 2;
                            }

                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                            if (bounds.Contains(point))
                            {
                                element.ColorBox = true;
                                return lyr;
                            }

                            // check to sse if we are in the label
                            curHeight = lyr.GetCategoryHeight(sf.DefaultDrawingOptions);
                            curWidth = lyr.GetCategoryWidth(sf.DefaultDrawingOptions);
                            curTop = lyr.Top + Constants.ItemHeight + 2;
                            var maxWidth = lyr.get_MaxIconWidth(sf);
                            curLeft = bounds.Left + Constants.TextLeftPad + maxWidth + 5;
                            bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                            if (bounds.Contains(point))
                            {
                                element.Label = true;
                                return lyr;
                            }

                            // categories
                            curLeft = Constants.ListItemIndent + Constants.TextLeftPad;
                            curTop = lyr.Top + Constants.ItemHeight + 2; // name
                            curTop += curHeight + 2; // default symbology

                            if (sf.Categories.Count > 0)
                            {
                                curTop += Constants.CsItemHeight + 2; // categories caption

                                for (var cat = 0; cat < sf.Categories.Count; cat++)
                                {
                                    var options = sf.Categories.Item[cat].DrawingOptions;
                                    curWidth = lyr.GetCategoryWidth(options);
                                    curHeight = lyr.GetCategoryHeight(options);
                                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                    curTop += curHeight;

                                    if (bounds.Contains(point))
                                    {
                                        element.ColorBox = true;
                                        element.CategoryIndex = cat;
                                        return lyr;
                                    }
                                }
                            }

                            if (sf.Charts.NumFields > 0 && sf.Charts.Count > 0)
                            {
                                curTop += Constants.CsItemHeight + 2; // charts caption
                                curWidth = sf.Charts.IconWidth;
                                curHeight = sf.Charts.IconHeight;
                                bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                if (bounds.Contains(point))
                                {
                                    element.Charts = true;
                                    return lyr;
                                }

                                curTop += curHeight + 2;
                                curHeight = Constants.IconHeight;
                                curWidth = Constants.IconWidth;

                                for (var fld = 0; fld < sf.Charts.NumFields; fld++)
                                {
                                    bounds = new Rectangle(curLeft, curTop, curWidth, curHeight);

                                    if (bounds.Contains(point))
                                    {
                                        element.Charts = true;
                                        element.ChartFieldIndex = fld;

                                        // MessageBox.Show("Field selected: " + fld.ToString());
                                        return lyr;
                                    }

                                    curTop += Constants.CsItemHeight + 2;
                                }
                            }
                        }

                        // nothing was hit
                        return lyr;
                    }
                }
            }

            return null;
        }
    }
}
