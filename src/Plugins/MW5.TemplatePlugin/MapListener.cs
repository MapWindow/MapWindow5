// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MapListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The map listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Plugins.TemplatePlugin
{
    #region

    using System;
    using System.Diagnostics;

    using MW5.Api.Events;
    using MW5.Api.Interfaces;
    using MW5.Plugins.Interfaces;

    #endregion

    /// <summary>
    /// The map listener.
    /// </summary>
    public class MapListener
    {
        #region Fields

        /// <summary>
        ///     The context of the application, holding the menu, layers, project, etc.
        /// </summary>
        private readonly IAppContext _context;

        private readonly SampleDockWindow _sampleDockWindow;

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
        /// <param name="sampleDockWindow">Reference to the sample dock window</param>
        public MapListener(IAppContext context, TemplatePlugin plugin, SampleDockWindow sampleDockWindow)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            if (sampleDockWindow == null)
            {
                throw new ArgumentNullException("sampleDockWindow");
            }

            // Save local references:
            _context = context;
            _sampleDockWindow = sampleDockWindow;

            // As show case:
            Debug.WriteLine("Number of loaded layers; " + _context.Layers.Count);
            _sampleDockWindow.DebugTextbox.Text = "Debug mode";

            // Create event handlers:
            plugin.ExtentsChanged += this.PluginOnExtentsChanged;
            plugin.ChooseLayer += this.PluginOnChooseLayer;
        }

        private void PluginOnChooseLayer(IMuteMap map, ChooseLayerEventArgs e)
        {
            _sampleDockWindow.DebugTextbox.AppendText("New layer handle: " + e.LayerHandle);
            _sampleDockWindow.DebugTextbox.AppendText(
                "Layer file name: " + System.IO.Path.GetFileName(_context.Layers.ItemByHandle(e.LayerHandle).Filename)
                + Environment.NewLine);
        }

        #endregion

        #region Methods

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
            Debug.Print("Extents changed: " + map.Extents);
            _sampleDockWindow.DebugTextbox.AppendText("Extents changed: " + map.Extents + Environment.NewLine);
        }

        #endregion
    }
}