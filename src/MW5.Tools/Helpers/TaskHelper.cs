// -------------------------------------------------------------------------------------------
// <copyright file="TaskHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension methods for tasks.
    /// </summary>
    internal static class TaskHelper
    {
        /// <summary>
        /// Gets long description of the task including execution time and parameters.
        /// </summary>
        public static IEnumerable<string> GetDescription(this IGisTask task)
        {
            var tool = task.Tool as IParametrizedTool;

            yield return Environment.NewLine;
            yield return "Status: " + task.Status.EnumToString();
            yield return "Started at: " + task.StartTime.ToLongTimeString();

            if (task.IsFinished)
            {
                yield return "Finished at: " + task.FinishTime.ToLongTimeString();
                yield return "Execution time: " + task.ExecutionTime;
            }

            var gdalTool = tool as IGdalTool;
            if (gdalTool != null && gdalTool.OverrideOptions)
            {
                yield return string.Empty;
                yield return "Options: " + gdalTool.EffectiveOptions;

                foreach (var p in tool.Parameters.Where(p => p is FilenameParameter || p is OutputLayerParameter))
                {
                    yield return p.ToString();
                }

                yield break;
            }

            if (tool.Parameters.Any())
            {
                yield return string.Empty;

                foreach (var p in tool.Parameters.Where(p => !p.IsEmpty && p.Value != p.DefaultValue))
                {
                    yield return p.ToString();
                }
            }
        }

        /// <summary>
        /// Gets icon to display current task status.
        /// </summary>
        /// <exception cref="System.ArgumentOutOfRangeException"></exception>
        public static TaskIcons GetStatusIcon(this IGisTask task)
        {
            switch (task.Status)
            {
                case GisTaskStatus.NotStarted:
                    return TaskIcons.NotStarted;
                case GisTaskStatus.Running:
                    return TaskIcons.InProgress;
                case GisTaskStatus.Success:
                    return TaskIcons.Success;
                case GisTaskStatus.Failed:
                    return TaskIcons.Error;
                case GisTaskStatus.Cancelled:
                    return TaskIcons.Cancel;
                case GisTaskStatus.Paused:
                    return TaskIcons.Pause;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}