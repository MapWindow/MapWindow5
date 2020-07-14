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

        private Constants Constants { get; }

        public LegendHitTest(LegendControlBase legend)
        {
            if (legend == null) throw new ArgumentNullException("legend");
            _legend = legend;
            Constants = new Constants(legend);
        }

        private LegendGroup GetGroup(int index)
        {
            return _legend.Groups[index] as LegendGroup;
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
                var grp = GetGroup(i);

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
            LegendElement element;
            var lyr = FindClickedLayer(point, out element);
            inCheckBox = element != null && element.Type == LayerElementType.CheckBox;
            inExpansionBox = element != null && element.Type == LayerElementType.ExpansionBox;
            return lyr;
        }

        /// <summary>
        /// Locates the layer that was clicked on in the legend.
        /// </summary>
        public LegendLayer FindClickedLayer(Point point, out LegendElement element)
        {
            element = new LegendElement(LayerElementType.None, new Rectangle());

            var groups = _legend.Groups as LegendGroups;
            if (groups == null)
            {
                return null;
            }

            var groupCount = groups.Count;

            for (var i = 0; i < groupCount; i++)
            {
                var grp = GetGroup(i);

                if (!grp.Expanded)
                {
                    continue;
                }

                var layerCount = grp.Layers.Count;

                for (var j = 0; j < layerCount; j++)
                {
                    var lyr = grp.LayersList[j];

                    element = FindClickedLayerElement(point, lyr);

                    if (element != null)
                    {
                        element.GroupIndex = i;
                        element.LayerHandle = lyr.Handle;
                        return lyr;
                    }
                }
            }

            return null;
        }

        private LegendElement FindClickedLayerElement(Point point, LegendLayer layer)
        {
            const int left = Constants.ListItemIndent;
            var top = layer.Top;
            var width = _legend.Width - left - Constants.ItemRightPad;
            var height = layer.Height;
            var bounds = new Rectangle(left, top, width, height);

            if (!bounds.Contains(point))
            {
                return null;
            }

            var elements = layer.Elements.OrderBy(el => (int)el.Type);
            return elements.FirstOrDefault(el => el.PointWithin(point));
        }
    }
}
