using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Projections.UI.Forms;

namespace MW5.Plugins.Toolbox
{
    public class ToolboxListener
    {
        private readonly IAppContext _context;

        public ToolboxListener(IAppContext context, ToolboxPlugin plugin)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (plugin == null) throw new ArgumentNullException("plugin");
            _context = context;

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
            }
        }

    }
}
