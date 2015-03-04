using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Services;

namespace MW5.Plugins
{
    public class PluginManager
    {
        private const string PLUGIN_DIRECTORY = "Plugins";

        [ImportMany] 
        private IEnumerable<Lazy<IPlugin, IPluginMetadata>> _allPlugins;     // found by MEF

        private readonly HashSet<string> _names = new HashSet<string>();
        //private Dictionary<string, Lazy<IPlugin, IPluginMetadata>> _plugins;     // currently active

        private readonly PluginBroadcaster _broadcaster;

        public PluginManager()
        {
            _broadcaster = new PluginBroadcaster(this);
        }

        public IEnumerable<BasePlugin> Plugins
        {
            get
            {
                var list = _allPlugins.Where(p => _names.Contains(p.Metadata.Name))
                            .Select(p => p.Value)
                            .OfType<BasePlugin>()
                            .ToList();
                return list;
            }
        }

        public PluginBroadcaster Broadcaster
        {
            get { return _broadcaster; }
        }

        /// <summary>
        /// Searches plugins in plugins folder with MEF.
        /// </summary>
        public void AssemblePlugins()
        {
            try
            {
                var aggregateCatalog = new AggregateCatalog();

                aggregateCatalog.Catalogs.Add(GetPluginCatalog());

                var container = new CompositionContainer(aggregateCatalog);

                container.ComposeParts(this);

            }
            catch (ReflectionTypeLoadException ex)
            {
                ErrorService.Report(ex);
            }
        }

        private DirectoryCatalog GetPluginCatalog()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

            path = Path.Combine(path, PLUGIN_DIRECTORY);

            return new DirectoryCatalog(path, "*.dll");
        }

        // TODO: remove; only temporary
        public void Initialize(IAppContext context)
        {
            _names.Clear();

            foreach (var plugin in _allPlugins)
            {
                plugin.Value.Initialize(context);
                _names.Add(plugin.Metadata.Name);
            }
        }

        public void Initialize(IEnumerable<string> activePlugins, IAppContext context)
        {
            _names.Clear();
            
            var dict = activePlugins.ToDictionary(item => item, item => item);
            foreach (var plugin in _allPlugins)
            {
                if (dict.ContainsKey(plugin.Metadata.Name))
                {
                    plugin.Value.Initialize(context);
                    _names.Add(plugin.Metadata.Name);
                }
            }
        }

        public void LoadPlugin(string pluginName, IAppContext context)
        {
            if (!_names.Contains(pluginName))
            {
                var plugin = _allPlugins.FirstOrDefault(p => p.Metadata.Name == pluginName);
                if (plugin != null)
                {
                    plugin.Value.Initialize(context);
                }

                _names.Add(pluginName);
            }
        }

        // TODO: remove all items that plugin has added during unloading
        public void UnloadPlugin(string pluginName)
        {
            var plugin = _allPlugins.FirstOrDefault(p => p.Metadata.Name == pluginName);
            if (plugin != null)
            {
                plugin.Value.Terminate();
            }
            _names.Remove(pluginName);
        }

        public bool PluginActive(string pluginName)
        {
            return _names.Contains(pluginName);
        }

        //public List<string> AvailablePlugins()
        //{
        //    List<string> Plugins = new List<string>();
        //    if (this.Plugins != null)
        //    {
        //        foreach (var mapWinPlugin in this.Plugins)
        //        {
        //            string pluginName = mapWinPlugin.Metadata["PluginName"].ToString();

        //            Plugins.Add(pluginName);
        //        }
        //    }

        //    return Plugins;
        //}

        //public void CreatePlugin(string pluginName, Aggregate aggregator)
        //{
        //    foreach (var mapWinPlugin in Plugins)
        //    {
        //        if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
        //        {
        //            mapWinPlugin.Value.StartUp(aggregator);

        //            if (ActivePlugins == null)
        //            {
        //                ActivePlugins = new List<string>();
        //            }

        //            ActivePlugins.Add(pluginName);

        //            //if (mapWinPlugin.Value is IPlugin2)
        //            //{
        //            //    IPlugin2 plugin = mapWinPlugin.Value as IPlugin2;
        //            //    plugin.StartUp(mainForm);
        //            //}
        //            //else
        //            //{
        //            //    MessageBox.Show("is van type 1");
        //            //}
        //        }
        //    }
        //}

        //public void PluginMenuClicked(string pluginName, string menuItem)
        //{
        //    foreach (var mapWinPlugin in Plugins)
        //    {
        //        if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
        //        {
        //            if (mapWinPlugin.Value is IPlugin2)
        //            {
        //                IPlugin2 plugin = mapWinPlugin.Value as IPlugin2;

        //                plugin.MenuButtonClicked(menuItem);

        //            }
        //        }
        //    }
        //}

        //public void PluginToolClicked(string pluginName, string toolItem)
        //{
        //    //foreach (var mapWinPlugin in Plugins)
        //    //{
        //    //    if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
        //    //    {
        //    //        mapWinPlugin.Value.ToolButtonClicked(toolItem);
        //    //    }
        //    //}

        //    PluginToolClicked(pluginName, toolItem, null);
        //}

        //public void PluginToolClicked(string pluginName, string toolItem, object[] args)
        //{
        //    foreach (var mapWinPlugin in Plugins)
        //    {
        //        if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
        //        {
        //            mapWinPlugin.Value.ToolButtonClicked(toolItem, args);
        //        }
        //    }
        //}

        //public void UnloadPlugin(string pluginName)
        //{
        //    foreach (var mapWinPlugin in Plugins)
        //    {
        //        if ((string)mapWinPlugin.Metadata["PluginName"] == pluginName)
        //        {
        //            mapWinPlugin.Value.Unload();

        //        }
        //    }
        //}
    }
}
