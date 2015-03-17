// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The menu listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MW5.Plugins.TemplatePlugin.Menu
{
    #region

    using System;

    using MW5.Plugins.Concrete;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Services;
    using MW5.Plugins.TemplatePlugin.Properties;

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
        private const string DOCKPANELKEY = "TemplatePluginDockPanel";

        #endregion

        #region Fields

        /// <summary>
        ///     The application context.
        /// </summary>
        private readonly IAppContext _context;

        /// <summary>
        ///     The message service.
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        ///     A user control as a sample for a dockable window.
        /// </summary>
        private readonly SampleDockWindow _sampleDockWindow;

        /// <summary>
        /// The _plugin.
        /// </summary>
        private readonly TemplatePlugin _plugin;

        /// <summary>
        /// To track if the dockable window is already loaded or not.
        /// </summary>
        private bool _alreadyLoaded;

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
        /// <param name="messageService">
        /// The message service.
        /// </param>
        /// <param name="sampleDockWindow">
        /// The sample dock wi
        /// </param>
        public MenuListener(IAppContext context, TemplatePlugin plugin, IMessageService messageService, SampleDockWindow sampleDockWindow)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            if (messageService == null)
            {
                throw new ArgumentNullException("messageService");
            }

            if (sampleDockWindow == null)
            {
                throw new ArgumentNullException("sampleDockWindow");
            }

            // Save to local properties:
            _context = context;
            _messageService = messageService;
            _sampleDockWindow = sampleDockWindow;
            _plugin = plugin;

            // Create event handlers:
            plugin.ItemClicked += Plugin_ItemClicked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Create a dockable window.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        private void CreateDockWindow(IAppContext context)
        {
            // Check if already loaded,  don't load again
            if (_alreadyLoaded)
            {
                return;
            }

            var panels = context.DockPanels;

            panels.Lock();
            var panel = panels.Add(_sampleDockWindow, DOCKPANELKEY, _plugin.Identity);
            panel.Caption = "Template dock window";
            panel.SetIcon(Resources.ico_template);

            var preview = panels.Preview;
            if (preview != null)
            {
                panel.DockTo(preview, DockPanelState.Tabbed, 150);
            }

            panels.Unlock();

            // Make sure this panel isn't loaded multiple times:
            _alreadyLoaded = true;
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
        private void Plugin_ItemClicked(object sender, MenuItemEventArgs e)
        {
            switch (e.ItemKey)
            {
                case MenuKeys.ShowDockableWindow:
                    // Clicked on the toolbar button
                    _messageService.Info("Hello from Template plugin");
                    this.CreateDockWindow(_context);
                    break;
            }
        }

        #endregion
    }
}