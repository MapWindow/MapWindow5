// -------------------------------------------------------------------------------------------
// <copyright file="ToolIdentification.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MW5.Plugins.Interfaces;
using MW5.Shared;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Finds instances of GIS tools suitable to be added to the toolbox.
    /// </summary>
    public static class ToolIdentification
    {
        /// <summary>
        /// Creates instances of all tool implementing ITool interface from the assembly.
        /// </summary>
        /// <value>stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface</value>
        public static IEnumerable<ITool> GetTools(this Assembly assembly)
        {
            var type = typeof(ITool);

            var list = assembly.GetTypes().Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

            foreach (var item in list)
            {
                ITool tool = null;

                try
                {
                    tool = Activator.CreateInstance(item) as ITool;
                }
                catch (Exception ex)
                {
                    Logger.Current.Error("Failed to create GIS tool: {0}.", ex, item.Name);
                }

                if (tool != null)
                {
                    yield return tool;
                }
            }
        }
    }
}