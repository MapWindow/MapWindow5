using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;

namespace MW5.Plugins.TemplatePlugin
{
    [GisTool(GroupKeys.Fake)]
    public class CustomGisTool: GisTool
    {
        [Input("Input value", 0)]
        public int Value { get; set; }

        /// <summary>
        /// The name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Custom tool from Template plugin"; }
        }

        /// <summary>
        /// Description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Custom tool added from Template plugin"; }
        }

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity
        {
            get { return PluginIdentityHelper.GetIdentity(typeof(InitPlugin)); }
        }

        /// <summary>
        /// Runs the tool.
        /// </summary>
        public override bool Run(ITaskHandle task)
        {
            Log.Info("Custom tool is running");
            return true;
        }

        public override bool AfterRun()
        {
            Log.Info("Custom tool was executed successfully");
            return true;
        }
    }
}
