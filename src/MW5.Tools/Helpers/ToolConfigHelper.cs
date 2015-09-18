// -------------------------------------------------------------------------------------------
// <copyright file="ToolConfigHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Model;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Extension method to save and restore configuration of the tool.
    /// </summary>
    internal static class ToolConfigHelper
    {
        /// <summary>
        /// Restores last used parameters of the tool from the disk based config file.
        /// </summary>
        public static void RestoreConfig(this IGisTool tool)
        {
            string filename = tool.GetConfigPath();

            if (!File.Exists(filename))
            {
                return;
            }

            try
            {
                // TODO: will be better to use XMLReader / Writer directly and not DataContractSerializer
                string xml = File.ReadAllText(filename);
                var toolNew = xml.Deserialize(tool.GetType(), null) as IParametrizedTool;

                CopyConfigFrom(toolNew, tool as IParametrizedTool);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to deserialize tool settings.", ex);
            }
        }

        /// <summary>
        /// Saves configuration of the tool.
        /// </summary>
        public static void SaveConfig(this IGisTool tool)
        {
            if (!(tool is IXmlSerializable))
            {
                Logger.Current.Warn(
                    "Saving of configuration is supported only for tools implementing IXmlSerializable interface.");
                return;
            }

            try
            {
                string xml = tool.Serialize(new[] { tool.GetType() }, false);

                string filename = tool.GetConfigPath();

                PathHelper.CreateFolder(filename);

                File.WriteAllText(filename, xml);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to serialize tool settings.", ex);
            }
        }

        /// <summary>
        /// Copies values of serializable parameters from source tool instance to the target.
        /// </summary>
        private static void CopyConfigFrom(IParametrizedTool source, IParametrizedTool target)
        {
            foreach (var p in source.Parameters)
            {
                if (p.Serializable)
                {
                    var targetParameter = target.Parameters.FirstOrDefault(pp => pp.Name == p.Name);
                    if (targetParameter != null)
                    {
                        targetParameter.PreviousValue = p.PreviousValue;
                    }
                }
            }
        }

        /// <summary>
        /// Gets path of the file with configuration information for the tool.
        /// </summary>
        private static string GetConfigPath(this IGisTool tool)
        {
            return ConfigPathHelper.GetToolsConfigPath() + tool.Name + ".xml";
        }
    }
}