// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolboxListener.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   The toolbox listener.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace MW5.Plugins.Toolbox
{
    using System;

    using MW5.Plugins.Events;
    using MW5.Plugins.Interfaces;
    using MW5.Plugins.Services;
    using MW5.Projections.UI.Forms;
    using MW5.Tools.Model;
    using MW5.Tools.Tools.Database;
    using MW5.Tools.Tools.Geoprocessing.VectorGeometryTools;
    using MW5.Tools.Views;

    /// <summary>
    /// The toolbox listener.
    /// </summary>
    public class ToolboxListener
    {
        #region Fields

        private readonly IAppContext _context;

        private readonly IGeoDatabaseService _databaseService;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolboxListener"/> class.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="plugin">The plugin.</param>
        /// <param name="databaseService">The database service.</param>
        public ToolboxListener(IAppContext context, ToolboxPlugin plugin, IGeoDatabaseService databaseService)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            if (plugin == null)
            {
                throw new ArgumentNullException("plugin");
            }

            if (databaseService == null)
            {
                throw new ArgumentNullException("databaseService");
            }

            _context = context;
            _databaseService = databaseService;

            plugin.ToolboxToolClicked += this.Plugin_ToolboxToolClicked;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Handles the ToolboxToolClicked event of the Plugin control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="ToolboxToolEventArgs"/> instance containing the event data.</param>
        private void Plugin_ToolboxToolClicked(object sender, ToolboxToolEventArgs e)
        {
            switch (e.Tool.Key)
            {
                case ToolKeys.IdentitfyProjection:
                    using (var form = new IdentifyProjectionForm(_context))
                    {
                        _context.View.ShowChildView(form);
                    }

                    break;
                case ToolKeys.ImportLayerInGeodatabase:
                    _context.Container.Run<GisToolPresenter, GisToolBase>(new ImportLayerTool());
                    break;
                case ToolKeys.RandomPoints:
                    _context.Container.Run<GisToolPresenter, GisToolBase>(new RandomPoints());
                    break;
                default:
                    var msg = "No handler was found for the specified key: " + e.Tool.Key;
                    MessageService.Current.Info(msg);
                    break;
            }
        }

        #endregion
    }
}