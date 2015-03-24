using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Api.Plugins;

namespace MW5.Api.Legend.Abstract
{
    public interface ILegendLayer: ILayer
    {
        /// <summary>
        /// Gets the unique identifier of the layer. Used internal during project serialization.
        /// </summary>
        Guid Guid { get; set; }
        
        /// <summary>
        /// Gets or sets the icon that appears next to this layer in the legend.
        /// Setting this value to null(nothing) removes the icon from the legend
        /// and sets it back to the default icon.
        /// </summary>
        object Icon { get; set; }

        /// <summary>
        /// Gets or sets whether or not the Layer is expanded.  This shows or hides the
        /// layer's Color Scheme (if one exists).
        /// </summary>
        bool Expanded { get; set; }

        /// <summary>
        /// Indicates whether to skip over the layer when drawing the legend.
        /// </summary>
        bool HideFromLegend { get; set; }

        /// <summary>
        /// If you wish to display a caption (e.g. "Region") above the legend items for the layer. Set "" to disable.
        /// </summary>
        string ColorSchemeCaption { get; set; }

        /// <summary>
        /// Returns custom object for specified key
        /// </summary>
        T GetCustomObject<T>(object key) where T : LayerMetadataBase;

        /// <summary>
        /// Sets custom object associated with layer
        /// </summary>
        void SetCustomObject<T>(T obj, object key) where T : LayerMetadataBase;

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        Bitmap Snapshot();

        /// <summary>
        /// Gets a snapshot (bitmap) of the layer
        /// </summary>
        /// <param name="imgWidth">Desired width in pixels of the snapshot</param>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        Bitmap Snapshot(int imgWidth);
    }
}
