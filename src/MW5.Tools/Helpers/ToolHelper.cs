// -------------------------------------------------------------------------------------------
// <copyright file="ToolHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using MW5.Plugins.Interfaces;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension methods for general pur
    /// </summary>
    internal static class ToolHelper
    {
        /// <summary>
        /// Clones the tool, copies values of all parameters.
        /// </summary>
        internal static IParametrizedTool Clone(this IParametrizedTool tool, IAppContext context)
        {
            var newTool = tool.Parameters.Clone();

            newTool.Initialize(context);

            return newTool;
        }

        /// <summary>
        /// Gets input parameter. Makes sure that there is exactly one input parameter.
        /// </summary>
        /// <exception cref="System.ApplicationException">
        /// No input layer parameters are found.
        /// or
        /// More than one input layer parameters are found.
        /// </exception>
        internal static IInputParameter GetSingleInputParameter(this IParametrizedTool tool)
        {
            var list = tool.Parameters.OfType<IInputParameter>().ToList();

            if (!list.Any())
            {
                throw new ApplicationException("No input layer parameters are found.");
            }

            if (list.Count > 1)
            {
                throw new ApplicationException("More than one input layer parameters are found.");
            }

            return list.First();
        }
    }
}