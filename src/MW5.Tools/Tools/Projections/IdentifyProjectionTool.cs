using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Projections.UI.Forms;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Properties;

namespace MW5.Tools.Tools.Projections
{
    [GisTool(GroupKeys.Projections)]
    public class IdentifyProjectionTool: IGisTool
    {
        private IAppContext _context;

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public string Name
        {
            get { return "Identify projection";  }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public string Description
        {
            get { return "Identifies projection as one of the well known from the projection string provided by user."; }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public bool Run()
        {
            using (var form = new IdentifyProjectionForm(_context))
            {
                return _context.View.ShowChildView(form);
            }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public PluginIdentity PluginIdentity
        {
            get { return PluginIdentity.Default; }
        }

        /// <summary>
        /// Initializes the tool.
        /// </summary>
        public void Initialize(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }
    }
}
