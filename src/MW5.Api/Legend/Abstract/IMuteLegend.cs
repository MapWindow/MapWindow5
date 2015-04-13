using System;
using System.Drawing;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend.Abstract
{
    public interface IMuteLegend
    {
        /// <summary>
        /// Gets or Sets the MapWinGIS.Map associated with this legend control
        /// Note: This property must be set before manipulating layers
        /// </summary>
        IMuteMap Map { get; set; }

        /// <summary>
        /// Gets the Menu for manipulating Groups
        /// </summary>
        ILegendGroups Groups { get; }

        /// <summary>
        /// Gets the Menu for manipulating Layers (without respect to groups)
        /// </summary>
        LayerCollection<ILegendLayer> Layers { get; }

        /// <summary>
        /// Toggles the label preview visiblity in the legend
        /// </summary>
        bool ShowLabels { get; set; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        bool ShowGroupIcons { get; set; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        Color SelectionColor { get; set; }

        /// <summary>
        /// Gets whether or not the legend is locked.  See Lock() function for description
        /// </summary>
        bool Locked { get; }

        /// <summary>
        /// Locks the LegendControl, stopping it from redrawing until it is unlocked.
        /// Use this as a way of adding multiple layers without redrawing between each layer being added.
        /// Make sure to Unlock the LegendControl when done.
        /// </summary>
        void Lock();

        /// <summary>
        /// Unlocks the legend.  See Lock() function for description
        /// </summary>
        void Unlock();

        /// <summary>
        /// Locates the group that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point"> The point inside of the legend that was clicked. </param>
        /// <param name="inCheckbox"> (by reference/out) Indicates whether a group visibilty check box was clicked. </param>
        /// <param name="inExpandbox"> (by reference/out) Indicates whether the expand box next to a group was clicked. </param>
        /// <returns> Returns the group that was clicked on or null/nothing. </returns>
        LegendGroup FindClickedGroup(Point point, out bool inCheckbox, out bool inExpandbox);

        /// <summary>
        /// Locates the layer that was clicked on in the legend.
        /// </summary>
        /// <param name="point"> The point. </param>
        /// <param name="element"> The Element. </param>
        /// <returns> The group that was clicked on or null/nothing. </returns>
        LegendLayer FindClickedLayer(Point point, ref ClickedElement element);

        /// <summary>
        /// Runs redraw of the legend if it's not locked and optionally redraw of the map.
        /// </summary>
        void Redraw(LegendRedraw redrawType = LegendRedraw.LegendOnly);

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <returns>Bitmap if successful, null (nothing) otherwise</returns>
        Bitmap Snapshot();

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="imgWidth"> Width in pixels of the desired Snapshot </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        Bitmap Snapshot(int imgWidth);

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="visibleLayersOnly">
        /// Only visible layers used in Snapshot?
        /// </param>
        /// <returns>
        /// Bitmap if successful, null (nothing) otherwise
        /// </returns>
        Bitmap Snapshot(bool visibleLayersOnly);

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="useFont"> Which font to use for legend text? </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        Bitmap Snapshot(bool visibleLayersOnly, Font useFont);

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth">  Width of the image. </param>
        /// <param name="useFont">  Which font to use for legend text? </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        Bitmap Snapshot(bool visibleLayersOnly, int imgWidth, Font useFont);

        /// <summary>
        /// Gets a snapshot of all layers within the legend with specified font and width.
        /// </summary>
        /// <param name="visibleLayersOnly">  Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth"> Width of the image. </param>
        /// <param name="useFont"> Which font to use for legend text? </param>
        /// <param name="foreColor"> The fore Color. </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        Bitmap Snapshot(bool visibleLayersOnly, int imgWidth, Font useFont, Color foreColor);

        /// <summary>
        /// Gets a snapshot of all layers within the legend
        /// </summary>
        /// <param name="visibleLayersOnly"> Only visible layers used in Snapshot? </param>
        /// <param name="imgWidth"> Width in pixels of the desired Snapshot </param>
        /// <returns> Bitmap if successful, null (nothing) otherwise </returns>
        Bitmap Snapshot(bool visibleLayersOnly, int imgWidth);

        /// <summary>
        /// Gets the selected layer within a legend or null if none is selected.
        /// </summary>
        int SelectedLayerHandle { get; set; }

        /// <summary>
        /// Gets the selected layer within a legend or null if none is selected.
        /// </summary>
        ILegendLayer SelectedLayer { get; set; }
    }
}