using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Legend.Events;

namespace MW5.Api.Legend.Abstract
{
    public interface ILegendWithEvents : ILegend
    {
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
    }
}
