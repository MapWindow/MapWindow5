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
        public MapListener(IAppContext context, TemplatePlugin plugin)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            // Save local references:
            _context = context;

            // As show case:
            Debug.WriteLine("Number of loaded layers; " + _context.Layers.Count);

            // Create event handlers:
            plugin.ExtentsChanged += this.PluginExtentsChanged;
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
        private void PluginExtentsChanged(IMuteMap map, EventArgs e)
        {
            Debug.Print("Extents changed: " + map.Extents);
        }

        #endregion
    }
}