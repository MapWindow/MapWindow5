// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The menu listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using MW5.Plugins.Enums;
using MW5.Plugins.Events;

namespace MW5.Plugins.DebugWindow.Menu
{
    #region

    using System;

    using MW5.Plugins.Concrete;
    using MW5.Plugins.DebugWindow;
    using MW5.Plugins.DebugWindow.Properties;
    using MW5.Plugins.Interfaces;

    #endregion

    /// <summary>
    ///     The menu listener.
    /// </summary>
    public class MenuListener
    {
        #region Constants

        /// <summary>
        ///     The key to identify the dock panel
        /// </summary>
        /// <remarks>Change it to fit your plug-in</remarks>
        private const string DOCKPANELKEY = "DebugWindowDockPanel";

        #endregion

        #region Fields

        /// <summary>
        ///     The application context.
        /// </summary>
        private readonly IAppContext _context;

        /// <summary>
        ///     A user control as a sample for a dockable window.
        /// </summary>
        private readonly DebugWindow _debugWindow;

        /// <summary>
        /// The _plugin.
        /// </summary>
        private readonly DebugWindowPlugin _plugin;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuListener"/> class.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        /// <param name="plugin">
        /// The plugin.
        /// </param>
        /// <param name="debugWindow">
        /// The sample dock wi
        /// </param>
        public MenuListener(IAppContext context, DebugWindowPlugin plugin, DebugWindow debugWindow)
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

            // Save to local properties:
            _context = context;
            _debugWindow = debugWindow;
            _plugin = plugin;

            // Create event handlers:
            plugin.ItemClicked += this.PluginOnItemClicked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Add a dockable window to the panels
        /// </summary>
        private void AddDockWindowToPanels()
        {
            var panels = _context.DockPanels;
        
            // Check if the panel not already exists:
            var myPanel = panels.Find(DOCKPANELKEY);
            if (myPanel != null)
            {
                myPanel.Visible = true;
                return;
            }

            panels.Lock();
            var panel = panels.Add(_debugWindow, DOCKPANELKEY, _plugin.Identity);
            panel.Caption = "Debug window";
            panel.SetIcon(Resources.ico_bug);

            // TODO: Read configuration setting to show the window like the last time:
            panel.DockTo(DockPanelState.Bottom, 100);

            panels.Unlock();
        }

        /// <summary>
        /// The toolbar button clicked event handler
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The menu item event arguments
        /// </param>
        private void PluginOnItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.ShowDebugWindow:
                    // Clicked on the toolbar button
                    this.AddDockWindowToPanels();
                    break;
            }
        }
        #endregion
    }
}