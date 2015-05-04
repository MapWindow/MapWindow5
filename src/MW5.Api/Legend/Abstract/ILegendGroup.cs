using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Api.Legend.Abstract
{
    public interface ILegendGroup
    {
        /// <summary>
        /// A string that a developer can use to hold misc. information about this group
        /// </summary>
        string Tag { get; set; }

        /// <summary>
        /// Gets the Handle (a unique identifier) to this group
        /// </summary>
        int Handle { get; }

        /// <summary>
        /// Gets or sets the locked property, which prevents the user from changing the visual state 
        /// except layer by layer
        /// </summary>
        bool StateLocked { get; set; }

        /// <summary>
        /// Gets or sets the Text that appears in the legend for this group
        /// </summary>
        string Text { get; set; }

        /// <summary>
        /// Gets or sets the icon that appears next to this group in the legend.
        /// Setting this value to null(nothing) removes the icon from the legend
        /// </summary>
        object Icon { get; set; }

        /// <summary>
        /// Gets or sets whether or not the group is expanded.  This shows or hides the 
        /// layers within this group
        /// </summary>
        bool Expanded { get; set; }

        /// <summary>
        /// Gets or sets the visibility of the layers within this group.
        /// Note: When reading this property, it returns true if any layer is visible within
        /// this group
        /// </summary>
        bool LayersVisible { get; set; }

        /// <summary>
        /// List of All Layers contained within this group
        /// </summary>
        IReadOnlyList<ILegendLayer> Layers { get; }

        /// <summary>
        /// Gets or Sets the Visibility State for this group (Note: Set cannot be PartiallyVisible)
        /// </summary>
        Visibility Visible { get; set; }

        /// <summary>
        /// Gets legend at the specified position within group.
        /// </summary>
        ILegendLayer this[int layerPosition] { get; }

        /// <summary>
        /// Returns a snapshot image of this group
        /// </summary>
        /// <param name="imgWidth">Width in pixels of the returned image (height is determined by the number of layers in the group)</param>
        /// <returns>Bitmap of the group and sublayers (expanded)</returns>
        Bitmap Snapshot(int imgWidth);

        void AddLayer(ILegendLayer layer);

        void InsertLayer(int position, ILegendLayer layer);

        IEnvelope Envelope { get; }
    }
}
