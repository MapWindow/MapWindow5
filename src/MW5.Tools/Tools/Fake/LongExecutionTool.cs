using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Tools.Fake
{
    [GisTool(GroupKeys.Fake)]
    public class LongExecutionTool: GisToolBase
    {
        [Input("Seconds per step (100 steps)", 0), DefaultValue(0.1), Range(0.1, 5.0)]
        public DoubleParameter SecondPerStep { get; set; }

        /// <summary>
        /// Gets name of the tool.
        /// </summary>
        public override string Name
        {
            get { return "Long task"; }
        }

        /// <summary>
        /// Gets description of the tool.
        /// </summary>
        public override string Description
        {
            get { return "Fakes the execution of the long task"; }
        }

        public override bool Run()
        {
            var span = TimeSpan.FromSeconds(SecondPerStep.Value);

            var logger = Logger.Current;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(span);

                int val = i;
                logger.Progress(string.Empty, val, "Running...");
            }

            logger.ClearProgress();

            return true;   // depends on the run in background check
        }
    }
}
