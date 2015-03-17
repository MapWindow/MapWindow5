// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MenuGenerator.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The menu generator.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace MW5.Plugins.TemplatePlugin.Menu
{
    #region

    using MW5.Plugins.Concrete;
    using MW5.Plugins.Interfaces;

    #endregion

    /// <summary>
    /// The menu generator.
    /// </summary>
    public class MenuGenerator
    {
        #region Fields

        /// <summary>
        /// The menu commands.
        /// </summary>
        private readonly MenuCommands _commands;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MenuGenerator"/> class.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        /// <param name="plugin">
        /// The plugin.
        /// </param>
        public MenuGenerator(IAppContext context, TemplatePlugin plugin)
        {
            _commands = new MenuCommands(plugin.Identity);

            // Create the toolbar:
            InitToolbar(context, plugin.Identity);

            // TODO: Create new top-level menu:
            InitMenu(context, plugin.Identity);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Initialize the new menu.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        /// <param name="identity">
        /// The plug-in identity.
        /// </param>
        private void InitMenu(IAppContext context, PluginIdentity identity)
        {
            var menu = context.Menu.Items.AddDropDown("Template", "_", identity);
            menu.SubItems.AddButton("Info", MenuKeys.ShowPluginDialog, identity);
        }

        /// <summary>
        /// Initialize the toolbar.
        /// </summary>
        /// <param name="context">
        /// The application context.
        /// </param>
        /// <param name="identity">
        /// The plug-in identity.
        /// </param>
        private void InitToolbar(IAppContext context, PluginIdentity identity)
        {
            // Create a new toolbar
            var bar = context.Toolbars.Add("Template Plugin toolbar", identity);
            bar.DockState = ToolbarDockState.Top;

            // Add toolbar buttons, use MenuKeys to identify the buttons and add the command in MenuCommands:
            _commands.AddToMenu(bar.Items, MenuKeys.ShowPluginDialog);
        }

        #endregion
    }
}