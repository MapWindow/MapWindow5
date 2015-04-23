using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Data.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.UI.Forms;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Tools.Database;
using MW5.Tools.Views;

namespace MW5.Plugins.Toolbox
{
    public class ToolboxListener
    {
        private readonly IAppContext _context;
        private readonly IGeoDatabaseService _databaseService;

        public ToolboxListener(IAppContext context, ToolboxPlugin plugin, IGeoDatabaseService databaseService)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            if (databaseService == null) throw new ArgumentNullException("databaseService");

            _context = context;
            _databaseService = databaseService;

            plugin.ToolboxToolClicked += plugin_ToolboxToolClicked;
        }

        private void plugin_ToolboxToolClicked(object sender, ToolboxToolEventArgs e)
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
                default:
                    string msg = "No handler was found for the specified key: " + e.Tool.Key;
                    MessageService.Current.Info(msg);
                    break;
            }
        }
    }
}
