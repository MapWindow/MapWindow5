using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Views;

namespace MW5.Tools.Helpers
{
    public static class ToolHelper
    {
        /// <summary>
        /// Gets path of the file with configuration information for the tool.
        /// </summary>
        public static string GetConfigPath(this IGisTool tool)
        {
            return ConfigPathHelper.GetToolsConfigPath() + tool.Name + ".xml";
        }

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
                string xml = File.ReadAllText(filename);
                var toolNew = xml.Deserialize(tool.GetType(), null) as IParametrizedTool;

                CopyConfigFrom(toolNew, tool);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to deserialize tool settings.", ex);
            }
        }

        /// <summary>
        /// Copies values of serializable parameters from source tool instance to the target.
        /// </summary>
        private static void CopyConfigFrom(IParametrizedTool source, IGisTool target)
        {
            foreach (var p in source.Parameters)
            {
                if (p.Serializable)
                {
                    p.ToolProperty.SetValue(target, p.ToolProperty.GetValue(source));
                }
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
        /// Clones the tool, copies values of all parameters.
        /// </summary>
        internal static IParametrizedTool Clone(this IParametrizedTool tool, IAppContext context)
        {
            var newTool = tool.Parameters.Clone();

            newTool.Initialize(context);

            return newTool;
        }

        /// <summary>
        /// Clones the tool, copies values of all parameters and assigns selected datasource to the input parameter.
        /// </summary>
        internal static IParametrizedTool CloneWithInput(this IParametrizedTool tool, ILayerInfo input, IAppContext context)
        {
            var newTool = tool.Parameters.Clone();

            newTool.Initialize(context);

            // assigning input datasource
            var p = newTool.GetBatchModeInputParameter();
            p.ToolProperty.SetValue(newTool, input);

            // resolving output filename based on template
            foreach (var output in newTool.Parameters.OfType<OutputLayerParameter>())
            {
                var info = output.GetValue();
                info.ResolveTemplateName(input.Name);
            }

            return newTool;
        }

        /// <summary>
        /// Gets input parameter for batch mode. Checks that there is a single input parameter.
        /// </summary>
        internal static LayerParameterBase GetBatchModeInputParameter(this IParametrizedTool tool)
        {
            var list = tool.Parameters.OfType<LayerParameterBase>().ToList();
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

        /// <summary>
        /// Gets MVP presenter to display UI for the tool.
        /// </summary>
        public static IPresenter<ToolViewModel> GetPresenter(this ITool tool, IAppContext context)
        {
            var attr = AttributeHelper.GetAttribute<GisToolAttribute>(tool.GetType());
            if (attr.PresenterType != null)
            {
                return context.Container.GetInstance(attr.PresenterType) as IPresenter<ToolViewModel>;
            }

            return context.Container.GetInstance<ToolPresenter>();
        }

        /// <summary>
        /// Gets the reflected tools.
        /// </summary>
        /// <value>stackoverflow.com/questions/26733/getting-all-types-that-implement-an-interface</value>
        public static IEnumerable<ITool> GetTools(this Assembly assembly)
        {
            var type = typeof(ITool);

            var list = assembly.GetTypes()
                        .Where(p => type.IsAssignableFrom(p) && p.IsClass && !p.IsAbstract);

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
