// -------------------------------------------------------------------------------------------
// <copyright file="TemplateToolsGroup.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Plugins.TemplatePlugin.Tools
{
    [GisTool(GroupKeys.TemplateGroup, groupName: "Template", groupDescription: "To show how groups in the toolbox work", icon: ToolIcon.Hammer, onlyGroup: true)]
    public class TemplateToolsGroup : GisTool
    {
        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description => "Not used, but mandatory";

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name => "Not used, but mandatory";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentityHelper.GetIdentity(typeof(InitPlugin));

        /// <summary>
        /// Provide execution logic for the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            return true;
        }
    }
}