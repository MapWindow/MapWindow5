using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using BL.Aggregator;
using BaseComponents.BaseClasses.Forms;
using BaseComponents.InterFaces.Forms;
//using BaseComponents.InterFaces.Plugins;

namespace BL.PluginManager
{
    public class PluginCompositionHelper
    {
        [ImportMany]
        public System.Lazy<IPlugin, IDictionary<string, object>>[] MapWinPlugins { get; set; }

        public List<string> ActivePlugins { get; set; }

        /// <summary>
        /// Assembles the plugins 
        /// </summary>
        public void AssemblePlugins()
        {
            try
            {
                //Creating an instance of aggregate catalog. It aggregates other catalogs
                var aggregateCatalog = new AggregateCatalog();

                //Build the directory path where the parts will be available
                /*
                var directoryPath =
                    string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                .Split('\\').Reverse().Skip(3).Reverse().Aggregate((a, b) => a + "\\" + b)
                                , "\\", "Plugins");
                */
                var directoryPath = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "Plugins");

                //Load parts from the available dlls in the specified path using the directory catalog
                var directoryCatalog = new DirectoryCatalog(directoryPath, "*.dll");

                //Add to the aggregate catalog
                aggregateCatalog.Catalogs.Add(directoryCatalog);

                //Create the composition container
                var container = new CompositionContainer(aggregateCatalog);

                // Composable parts are created here i.e. the Import and Export components assembles here
                container.ComposeParts(this);

            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder sb = new StringBuilder();
                foreach (Exception exSub in ex.LoaderExceptions)
                {
                    sb.AppendLine(exSub.Message);
                    if (exSub is FileNotFoundException)
                    {
                        FileNotFoundException exFileNotFound = exSub as FileNotFoundException;
                        if (!string.IsNullOrEmpty(exFileNotFound.FusionLog))
                        {
                            sb.AppendLine("Fusion Log:");
                            sb.AppendLine(exFileNotFound.FusionLog);
                        }
                    }
                    sb.AppendLine();
                }
                string errorMessage = sb.ToString();

                //Display or log the error based on your application.
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string TestPath()
        {
            var directoryPath =
                    string.Concat(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                                .Split('\\').Reverse().Skip(3).Reverse().Aggregate((a, b) => a + "\\" + b)
                                , "\\", "Plugins");
            return directoryPath;
        }

        public List<string> AvailablePlugins()
        {
            List<string> Plugins = new List<string>();
            if (MapWinPlugins != null)
            {
                foreach (var mapWinPlugin in MapWinPlugins)
                {
                    string pluginName = mapWinPlugin.Metadata["PluginName"].ToString();

                    Plugins.Add(pluginName);
                }
            }

            return Plugins;
        }

        public void CreatePlugin(string pluginName, Aggregate aggregator)
        {
            foreach (var mapWinPlugin in MapWinPlugins)
            {
                if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
                {
                    mapWinPlugin.Value.StartUp(aggregator);

                    if(ActivePlugins == null)
                    {
                        ActivePlugins = new List<string>();
                    }

                    ActivePlugins.Add(pluginName);

                    //if (mapWinPlugin.Value is IPlugin2)
                    //{
                    //    IPlugin2 plugin = mapWinPlugin.Value as IPlugin2;
                    //    plugin.StartUp(mainForm);
                    //}
                    //else
                    //{
                    //    MessageBox.Show("is van type 1");
                    //}
                }
            }
        }

        public void PluginMenuClicked(string pluginName, string menuItem)
        {
            foreach (var mapWinPlugin in MapWinPlugins)
            {
                if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
                {
                    if (mapWinPlugin.Value is IPlugin2)
                    {
                        IPlugin2 plugin = mapWinPlugin.Value as IPlugin2;
       
                        plugin.MenuButtonClicked(menuItem);
      
                    }
                }
            }
        }

        public void PluginToolClicked(string pluginName, string toolItem)
        {
            //foreach (var mapWinPlugin in MapWinPlugins)
            //{
            //    if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
            //    {
            //        mapWinPlugin.Value.ToolButtonClicked(toolItem);
            //    }
            //}

            PluginToolClicked(pluginName, toolItem, null);
        }

        public void PluginToolClicked(string pluginName, string toolItem, object[] args)
        {
            foreach (var mapWinPlugin in MapWinPlugins)
            {
                if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
                {
                    mapWinPlugin.Value.ToolButtonClicked(toolItem, args);
                }
            }
        }

        public void UnloadPlugin(string pluginName)
        {
            foreach (var mapWinPlugin in MapWinPlugins)
            {
                if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
                {
                    mapWinPlugin.Value.Unload();

                }
            }
        }
    }
}
