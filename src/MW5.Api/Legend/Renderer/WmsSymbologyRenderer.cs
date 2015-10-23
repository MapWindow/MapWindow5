using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Legend.Renderer
{
    /// <summary>
    /// Renders symbology preview for WMS layer.
    /// </summary>
    internal class WmsSymbologyRenderer : SymbologyRendererBase
    {
        public WmsSymbologyRenderer(LegendControlBase legend)
            : base(legend)
        {

        }

        /// <summary>
        /// Draws the raster symbology.
        /// </summary>
        public void Render(Graphics g, LegendLayer layer, Rectangle bounds, bool isSnapshot)
        {
            var top = GetSymbologyTop(bounds);

            DrawCategoriesCaption(g, bounds, ref top, "WMS", Font);
        }
    }
}
