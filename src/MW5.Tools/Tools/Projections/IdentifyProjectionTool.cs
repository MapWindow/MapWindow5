// -------------------------------------------------------------------------------------------
// <copyright file="IdentifyProjectionTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Projections.Forms;
using MW5.Shared;
using MW5.Tools.Model;

namespace MW5.Tools.Tools.Projections
{
    [CustomLayout]
    [GisTool("Projections", groupDescription: "Tools to work with coordinate systems and projections.")]
    public class IdentifyProjectionTool : ToolBase
    {
        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Identify projection";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Identifies projection as one of the well known from the projection string provided by user.";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run()
        {
            using (var form = new IdentifyProjectionForm(_context))
            {
                return _context.View.ShowChildView(form);
            }
        }
    }
}
