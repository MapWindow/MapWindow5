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
            plugin.LayerAdded += this.PluginOnLayerAdded;
            plugin.LayerRemoved += this.PluginOnLayerRemoved;
            plugin.LayerSelected += this.PluginOnLayerSelected;
            plugin.MapCursorChanged += this.PluginOnMapCursorChanged;
            plugin.SelectionChanged += this.PluginOnSelectionChanged;
            plugin.ShapeIdentified += this.PluginOnShapeIdentified;
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

            string filename = _context.Layers.ItemByHandle(e.LayerHandle).Filename;
            if (File.Exists(filename))
            {
                filename = Path.GetFileName(filename);
            }

            _debugWindow.Write(
                "MapListener.PluginOnChooseLayer", 
                "Selected layer name: " + filename);
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
        /// On layer removed.
        /// </summary>
        /// <param name="map">
        /// The map.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void PluginOnLayerRemoved(IMuteLegend map, LayerEventArgs e)
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