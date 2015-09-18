// -------------------------------------------------------------------------------------------
// <copyright file="BatchExecutionHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Methods to create separate instances of the tool for batch execution. Handles resolving and validation 
    /// of output template name.
    /// </summary>
    internal static class BatchExecutionHelper
    {
        /// <summary>
        /// Generates a new instance of tool for each input file. Works in batch mode only.
        /// </summary>
        public static IEnumerable<IGisTool> GenerateBatchTools(this IParametrizedTool tool, IAppContext context)
        {
            var inputParameter = tool.GetSingleInputParameter();

            if (!inputParameter.HasBatchInputs)
            {
                MessageService.Current.Info("No inputs are selected.");
                return null;
            }

            IEnumerable<IGisTool> tools = null;

            var layers = inputParameter.BatchInputs as IEnumerable<IDatasourceInput>;
            if (layers != null)
            {
                // inputs may be represented by IDatasourceInput
                tools = layers.Select(l => tool.CloneWithInput(l, l.Name, context) as IGisTool).ToList();
            }
            else
            {
                // inputs may be represented or filename
                var filenames = inputParameter.BatchInputs as IEnumerable<string>;
                if (filenames != null)
                {
                    tools = filenames.Select(l => tool.CloneWithInput(l, l, context) as IGisTool).ToList();
                }
            }

            if (!ValidateOutputNames(tools.Select(t => t as IParametrizedTool)))
            {
                return null;
            }

            return tools;
        }

        /// <summary>
        /// Creates sequentially linked tasks for a list of tools.
        /// </summary>
        public static IEnumerable<IGisTask> CreateSequentialTasks(IEnumerable<IGisTool> tools)
        {
            IGisTask lastTask = null;

            foreach (var t in tools.Reverse())
            {
                var task = new GisTask(t) { NextTask = lastTask };

                lastTask = task;

                yield return task;
            }
        }

        /// <summary>
        /// Clones the tool, copies values of all parameters and assigns selected datasource to the input parameter.
        /// </summary>
        private static IParametrizedTool CloneWithInput(this IParametrizedTool tool, object input, string filename, IAppContext context)
        {
            var newTool = tool.Clone(context);

            // assigning input datasource
            var p = newTool.GetSingleInputParameter() as BaseParameter;
            p.SetToolValue(input);

            // resolving output filename based on template
            foreach (var output in newTool.Parameters.OfType<IOutputParameter>())
            {
                output.ResolveTemplateName(filename);
            }

            return newTool;
        }

        /// <summary>
        /// Checks that all output datasource will have unique name.
        /// </summary>
        private static bool ValidateOutputNames(IEnumerable<IParametrizedTool> tools)
        {
            bool duplicates = false;

            tools = tools.ToList();

            var names = tools.SelectMany(t => t.Parameters.OfType<OutputNameParameter>()).Select(p => p.Value).ToList();
            if (names.Count() != names.Distinct().Count())
            {
                duplicates = true;
            }

            var outputs = tools.ToList().SelectMany(t => t.Parameters.OfType<OutputLayerParameter>());
            var list = outputs.Select(o => o.GetValue().Filename).ToList();

            if (list.Count() != list.Distinct().Count())
            {
                duplicates = true;
            }

            if (duplicates)
            {
                MessageService.Current.Info(
                    "Duplicate names for output layers. Try to include {input} varaible in the name template, e.g. '{input}_result.shp'");
                return false;
            }

            return true;
        }
    }
}