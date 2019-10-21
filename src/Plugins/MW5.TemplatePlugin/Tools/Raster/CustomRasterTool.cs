// -------------------------------------------------------------------------------------------
// <copyright file="CustomRasterTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Plugins.TemplatePlugin.Tools.Raster
{
    [GisTool("Raster", groupDescription: GroupKeys.TemplateRasterDesc, icon: ToolIcon.Hammer, parentGroupKey: GroupKeys.TemplateGroup)]
    public class CustomRasterTool : GisTool
    {
        [Input("Input value", 0)]
        public int Value { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name => "Custom tool from Template plugin";

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description => "Custom tool added from Template plugin";

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentityHelper.GetIdentity(typeof(InitPlugin));

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            Log.Info("Custom tool is running");
            return true;
        }

        /// <summary>
        /// A method called after the main IGisTool.Run method is successfully finished.
        /// Is executed on the UI thread. Typically used to save output datasources.
        /// Default implementation automatically handles values assigned to OutputLayerInfo.Result.
        /// </summary>
        /// <returns></returns>
        public override bool AfterRun()
        {
            Log.Info("Custom tool was executed successfully");
            return true;
        }
    }
}
