using System;
using System.Drawing;
using MW5.Api.Interfaces;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend
{
    public interface ILegendControl
    {
        /// <summary>
        /// Gets or Sets the MapWinGIS.Map associated with this legend control
        /// Note: This property must be set before manipulating layers
        /// </summary>
        IMapControl Map { set; }

        /// <summary>
        /// Toggles the layer preview visiblity in the legend
        /// </summary>
        /// <returns></returns>
        bool ShowLabels { get; set; }

        /// <summary>
        /// Gets the Menu for manipulating Groups
        /// </summary>
        Groups Groups { get; }

        /// <summary>
        /// Gets the Menu for manipulating Layers (without respect to groups)
        /// </summary>
        LegendLayerCollection Layers { get; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        Color SelectedColor { get; set; }

        /// <summary>
        /// Gets or Sets the background color of the selected layer within the legend
        /// </summary>
        bool ShowGroupFolders { get; set; }

        /// <summary>
        /// Gets or Sets the Selected layer within the legend
        /// </summary>
        int SelectedLayer { get; set; }

        /// <summary>
        /// Gets whether or not the legend is locked.  See Lock() function for description
        /// </summary>
        bool Locked { get; }

        /// <summary>
        /// The get layer.
        /// </summary>
        /// <param name="layerHandle"> The layer handle. </param>
        /// <returns> The <see cref="LegendLayer"/>. </returns>
        LegendLayer GetLayer(int layerHandle);

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
        Group FindClickedGroup(Point point, out bool inCheckbox, out bool inExpandbox);

        /// <summary>
        /// Locates the layer that was clicked on in the legend, based on the coordinate within the legend (0,0) being top left of legend)
        /// </summary>
        /// <param name="point"> The point inside of the legend that was clicked. </param>
        /// <param name="inCheckBox"> (by reference/out) Indicates whether a layer visibilty check box was clicked. </param>
        /// <param name="inExpansionBox"> (by reference/out) Indicates whether the expand box next to a layer was clicked. </param>
        /// <returns> Returns the group that was clicked on or null/nothing. </returns>
        LegendLayer FindClickedLayer(Point point, out bool inCheckBox, out bool inExpansionBox);

        /// <summary>
        /// </summary>
        /// <param name="point"> The point. </param>
        /// <param name="element"> The Element. </param>
        LegendLayer FindClickedLayer(Point point, ref ClickedElement element);

        /// <summary>
        /// The full redraw.
        /// </summary>
        void FullRedraw();

        /// <summary>
        /// The redraw legend and map.
        /// </summary>
        void RedrawLegendAndMap();

        /// <summary>
        /// The layer properties changed.
        /// </summary>
        event EventHandler<LayerEventArgs> LayerPropertiesChanged;

        /// <summary>
        /// Layer Double Click Event
        /// </summary>
        event EventHandler<LayerEventArgs> LayerDoubleClick;

        /// <summary>
        /// Layer Mouse Down Click Event
        /// </summary>
        event EventHandler<LayerMouseEventArgs> LayerMouseDown;

        /// <summary>
        /// Layer Mouse Up Event
        /// </summary>
        event EventHandler<LayerMouseEventArgs> LayerMouseUp;

        /// <summary>
        /// Group Double Click Event
        /// </summary>
        event EventHandler<GroupEventArgs> GroupDoubleClick;

        /// <summary>
        /// Group Mouse Down Event
        /// </summary>
        event EventHandler<GroupMouseEventArgs> GroupMouseDown;

        /// <summary>
        /// Group Mouse Up Event
        /// </summary>
        event EventHandler<GroupMouseEventArgs> GroupMouseUp;

        /// <summary>
        /// LegendControl was clicked event (not on Group, nor on Layer)
        /// </summary>
        event EventHandler<LegendClickEventArgs> LegendClick;

        /// <summary>
        /// Selected Layer changed event
        /// </summary>
        event EventHandler<LayerEventArgs> LayerSelected;

        /// <summary>
        /// Added Layer event
        /// </summary>
        event EventHandler<LayerEventArgs> LayerAdded;

        /// <summary>
        /// Removed Layer event
        /// </summary>
        event EventHandler<LayerEventArgs> LayerRemoved;

        /// <summary>
        /// Position of a layer has changed event
        /// </summary>
        event EventHandler<PositionChangedEventArgs> LayerPositionChanged;

        /// <summary>
        /// Position of a group has changed event
        /// </summary>
        event EventHandler<PositionChangedEventArgs> GroupPositionChanged;

        /// <summary>
        /// A Group has been added
        /// </summary>
        event EventHandler<GroupEventArgs> GroupAdded;

        /// <summary>
        /// A Group has been removed
        /// </summary>
        event EventHandler<GroupEventArgs> GroupRemoved;

        /// <summary>
        /// The visibility of a layer has changed event
        /// </summary>
        event EventHandler<LayerCancelEventArgs> LayerVisibleChanged;

        /// <summary>
        /// Fires when the Group checkbox is clicked
        /// </summary>
        event EventHandler<GroupEventArgs> GroupCheckboxClicked;

        /// <summary>
        /// Fires when the Expanded property of a group changes.
        /// </summary>
        event EventHandler<GroupEventArgs> GroupExpandedChanged;

        /// <summary>
        /// Fires when the layer checkbox is clicked
        /// </summary>
        event EventHandler<LayerEventArgs> LayerCheckboxClicked;

        /// <summary>
        /// Fires when layer colorbox is clicked
        /// </summary>
        event EventHandler<LayerEventArgs> LayerColorboxClicked;

        /// <summary>
        /// Fires when one of the shapefile categories is clicked
        /// </summary>
        event EventHandler<LayerCategoryEventArgs> LayerCategoryClicked;

        /// <summary>
        /// Fires when charts icon is clicked
        /// </summary>
        event EventHandler<LayerMouseEventArgs> LayerChartClicked;

        /// <summary>
        /// Fires when one of chart fields is clicked
        /// </summary>
        event EventHandler<ChartFieldClickedEventArgs> LayerChartFieldClicked;

        /// <summary>
        /// Fired when labels icon for the layer is clicked
        /// </summary>
        event EventHandler<LayerEventArgs> LayerLabelsClicked;

        /// <summary>
        /// Assigns all layers outside group to a new group. This allows normal functioning of the legend after map deserialization.
        /// </summary>
        /// <param name="groupName"> The group Name. </param>
        int AssignOrphanLayersToNewGroup(string groupName);
    }
}