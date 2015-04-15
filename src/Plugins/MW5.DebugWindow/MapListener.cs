// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The map listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MW5.Plugins.Events;

namespace MW5.Plugins.DebugWindow
{
    #region

    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.IO;

    using MW5.Api.Events;
    using MW5.Api.Interfaces;
    using MW5.Api.Legend.Abstract;
    using MW5.Api.Legend.Events;
    using MW5.Plugins.Concrete;
    using MW5.Plugins.Interfaces;

    #endregion

    /// <summary>
    ///     The map listener.
    /// </summary>
    public class MapListener
    {
        #region Fields

        /// <summary>
        ///     The context of the application, holding the menu, layers, project, etc.
        /// </summary>
        private readonly IAppContext _context;

        /// <summary>
        ///     The _sample dock window.
        /// </summary>
        private readonly DebugWindow _debugWindow;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MapListener"/> class.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        /// <param name="plugin">
        /// The plugin.
        /// </param>
        /// <param name="debugWindow">
        /// Reference to the sample dock window
        /// </param>
        public MapListener(IAppContext context, DebugWindowPlugin plugin, DebugWindow debugWindow)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            if (debugWindow == null)
            {
                throw new ArgumentNullException("debugWindow");
            }

            // Save local references:
            _context = context;
            _debugWindow = debugWindow;

            // As show case:
            Debug.WriteLine("Number of loaded layers; " + _context.Layers.Count);

            // Create event handlers:
            plugin.BeforeRemoveLayer += this.PluginOnBeforeRemoveLayer;
            plugin.ChooseLayer += this.PluginOnChooseLayer;
            plugin.ExtentsChanged += this.PluginOnExtentsChanged;
            plugin.FileDropped += this.PluginOnFileDropped;
            plugin.GridOpened += this.PluginOnGridOpened;
            plugin.LayerAdded += this.PluginOnLayerAdded;
            plugin.LayerProjectionIsEmpty += this.PluginOnLayerProjectionIsEmpty;
            plugin.LayerRemoved += this.PluginOnLayerRemoved;
            plugin.LayerSelected += this.PluginOnLayerSelected;
            plugin.MapCursorChanged += this.PluginOnMapCursorChanged;
            plugin.ProjectionMismatch += this.PluginOnProjectionMismatch;
            plugin.SelectionChanged += this.PluginOnSelectionChanged;
            plugin.ShapeHighlighted += this.PluginOnShapeHighlighted;
            plugin.ShapeIdentified += this.PluginOnShapeIdentified;
            plugin.TilesLoaded += this.PluginOnTilesLoaded;
            plugin.ViewUpdating += this.PluginOnViewUpdating;
            plugin.LogEntryAdded += PluginOnLogEntryAdded;
        }

        #endregion

        #region Methods

        private void PluginOnLogEntryAdded(object sender, Shared.Log.LogEventArgs e)
        {
            _debugWindow.Write(e.Entry.TimeStamp.ToLongTimeString(), e.Entry.ToString());
        }

        /// <summary>
        /// On before remove layer.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnBeforeRemoveLayer(object sender, LayerRemoveEventArgs e)
        {
            _debugWindow.Write(
                "MapListener.PluginOnBeforeRemoveLayer", 
                e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// On choose layer.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnChooseLayer(IMuteMap map, ChooseLayerEventArgs e)
        {
            if (e.LayerHandle == -1)
            {
                return;
            }

            _debugWindow.Write(
                "MapListener.PluginOnChooseLayer", 
                "Selected layer name: " + Path.GetFileName(_context.Layers.ItemByHandle(e.LayerHandle).Filename));
        }

        /// <summary>
        /// The extents changed event handler
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The event arguments
        /// </param>
        private void PluginOnExtentsChanged(IMuteMap map, EventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnExtentsChanged", map.Extents.ToString());
        }

        /// <summary>
        /// On file dropped.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnFileDropped(IMuteMap map, FileDroppedEventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnFileDropped", e.Filename);
        }

        /// <summary>
        /// On grid opened.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnGridOpened(IMuteMap map, GridOpenedEventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnGridOpened", e.GridFilename);
        }

        /// <summary>
        /// On layer added.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnLayerAdded(IMuteLegend legend, LayerEventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnLayerAdded", e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// On layer projection is empty.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnLayerProjectionIsEmpty(IMuteMap map, LayerProjectionIsEmptyEventArgs e)
        {
            _debugWindow.Write(
                "MapListener.PluginOnLayerProjectionIsEmpty", 
                e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// On layer removed.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnLayerRemoved(IMuteMap map, LayerRemovedEventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnLayerRemoved", e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// The layer selected event handler
        /// </summary>
        /// <param name="legend">
        /// The legend.
        /// </param>
        /// <param name="e">
        /// The layer event arguments
        /// </param>
        private void PluginOnLayerSelected(IMuteLegend legend, LayerEventArgs e)
        {
            if (e.LayerHandle == -1)
            {
                return;
            }

            _debugWindow.Write(
                "MapListener.PluginOnLayerSelected", 
                "Selected layer: " + _context.Layers.ItemByHandle(e.LayerHandle).Filename);
        }

        /// <summary>
        /// On map cursor changed.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnMapCursorChanged(IMuteMap map, EventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnMapCursorChanged", string.Empty);
        }

        /// <summary>
        /// On projection mismatch.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnProjectionMismatch(IMuteMap map, ProjectionMismatchEventArgs e)
        {
            _debugWindow.Write(
                "MapListener.PluginOnProjectionMismatch", 
                e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// On selection changed.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnSelectionChanged(IMuteMap map, SelectionChangedEventArgs e)
        {
            _debugWindow.Write(
                "MapListener.PluginOnSelectionChanged", 
                e.LayerHandle.ToString(CultureInfo.InvariantCulture));
        }

        /// <summary>
        /// On shape highlighted.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnShapeHighlighted(IMuteMap map, ShapeHightlightedEventArgs e)
        {
            _debugWindow.Write(
                "MapListener.PluginOnShapeHighlighted", 
                string.Format("layerHandle: {0}, shapeIndex: {1}", e.LayerHandle, e.ShapeIndex));
        }

        /// <summary>
        /// On shape identified.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnShapeIdentified(IMuteMap map, ShapeIdentifiedEventArgs e)
        {
            var msg = string.Format(
                "layerHandle: {0}, shapeIndex: {1}, PointX: {2}, PointY: {3}",
                e.LayerHandle,
                e.ShapeIndex,
                e.PointX,
                e.PointY);
            _debugWindow.Write("MapListener.PluginOnShapeIdentified", msg);
        }

        /// <summary>
        /// On tiles loaded.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnTilesLoaded(IMuteMap map, TilesLoadedEventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnTilesLoaded", string.Empty);
        }

        /// <summary>
        /// On view updating.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnViewUpdating(object sender, EventArgs e)
        {
            _debugWindow.Write("MapListener.PluginOnViewUpdating", string.Empty);
        }

        #endregion
    }
}