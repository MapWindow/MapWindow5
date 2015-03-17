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

    #endregion

    /// <summary>
    /// The menu listener.
    /// </summary>
    public class MenuListener
    {
        #region Fields

        /// <summary>
        /// The message service.
        /// </summary>
        private readonly IMessageService _messageService;

        /// <summary>
        /// The application context.
        /// </summary>
        private IAppContext _context;

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
        public MenuListener(IAppContext context, TemplatePlugin plugin, IMessageService messageService)
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

            // Save to local properties:
            _context = context;
            _messageService = messageService;

            // Create event handlers:
            plugin.ItemClicked += Plugin_ItemClicked;
        }

        #endregion

        #region Methods

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
                case MenuKeys.ShowPluginDialog:
                    // Clicked on the toolbar button
                    _messageService.Info("Hello from Template plugin");
                    break;
            }
        }

        #endregion
    }
}