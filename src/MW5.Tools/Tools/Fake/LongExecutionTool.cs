// -------------------------------------------------------------------------------------------
// <copyright file="LongExecutionTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015-2019
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using MW5.Tools.Views.Custom;

namespace MW5.Tools.Tools.Fake
{
#if DEBUG

    [GisTool("Testing", groupDescription: "Fake tools to test the framework itself.", icon: ToolIcon.ToolDefault, presenter: typeof(LongExecutionPresenter))]

#endif

    [CustomLayout]
    public class LongExecutionTool : GisTool
    {
        [Input("Seconds per step (100 steps)", 0), DefaultValue(0.1), Range(0.1, 5.0)]
        public double SecondsPerStep { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name => "Long task";

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description => "Fakes the execution of the long task";

        public override bool SupportsCancel => true;

        /// <summary>
        /// Gets the identity of plugin that created this tool.
        /// </summary>
        public override PluginIdentity PluginIdentity => PluginIdentity.Default;

        public override bool Run(ITaskHandle task)
        {
            var span = TimeSpan.FromSeconds(SecondsPerStep);

            Log.Info(Name + ": start");

            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(span);

                var val = i;

                task.CheckPauseAndCancel();

                task.Progress.Update("Running...", val);

                Log.Info("Running: " + i);
            }

            task.Progress.Clear();

            Log.Info(Name + ": end");

            return true;   // depends on the run in background check
        }
    }
}
