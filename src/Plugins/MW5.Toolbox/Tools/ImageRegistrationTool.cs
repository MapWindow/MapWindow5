using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Toolbox.Views;
using MW5.Shared;
using MW5.Tools.Model;

namespace MW5.Plugins.Toolbox.Tools
{
    [CustomLayout]
    [GisTool(GroupKeys.Raster)]
    public class ImageRegistrationTool : ToolBase
    {
        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Image registration"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Allows to interactively match points of an image and known locations on the " +
                         "map and calculate affine transformation coefficients to set location of an image."; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentityHelper.GetIdentity(typeof(ToolboxPlugin)); }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run()
        {
            var model = new ImageRegistrationModel();
            return _context.Container.Run<ImageRegistrationPresenter, ImageRegistrationModel>(model);
        }
    }
}
