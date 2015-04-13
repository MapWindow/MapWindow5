using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mef;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Plugins
{
    internal class PluginManager : IPluginManager
    {
        private const string PluginDirectory = "Plugins";

        private readonly IApplicationContainer _container;

        [ImportMany] 
        #pragma warning disable 649
        private IEnumerable<Lazy<IPlugin, IPluginMetadata>> _mefPlugins;     // found by MEF
        #pragma warning restore 649

        private List<BasePlugin> _plugins = new List<BasePlugin>();      // all valid plugins

        private readonly HashSet<PluginIdentity> _active = new HashSet<PluginIdentity>();

        public event EventHandler<PluginEventArgs> PluginUnloaded;

        // TODO: move this to the broadcaster
        public event EventHandler<MenuItemEventArgs> MenuItemClicked;
        public event EventHandler<MenuItemEventArgs> StatusItemClicked;

        public event EventHandler<MenuItemEventArgs> PluginItemClicked;

        private static IPluginManager _instance;
        public static IPluginManager Instance
        {
            get { return _instance; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        public PluginManager(IApplicationContainer container)
        {
            if (container == null) throw new ArgumentNullException("container");

            _container = container;
            _instance = this;
        }

        /// <summary>
        /// Gets list of all plugins both active and not.
        /// </summary>
        public IEnumerable<BasePlugin> AllPlugins
        {
            get { return _plugins; }
        }

        public IEnumerable<BasePlugin> ApplicationPlugins
        {
            get { return _plugins.Where(p => p.IsApplicationPlugin); }
        }

        public IEnumerable<BasePlugin> CustomPlugins
        {
            get { return _plugins.Where(p => !p.IsApplicationPlugin); }
        }

        /// <summary>
        /// Gets list of only active plugins.
        /// </summary>
        public IEnumerable<BasePlugin> ActivePlugins
        {
            get
            {
                // TODO: cache it each time the list of plugins changes to spare the time on search for each event
                return _plugins.Where(p => _active.Contains(p.Identity)).ToList();
            }
        }

        /// <summary>
        /// Validates the list of plugins loaded by MEF.
        /// </summary>
        public void ValidatePlugins()
        {
            _plugins.Clear();

            var dict = new Dictionary<Guid, BasePlugin>();

            foreach (var item in _mefPlugins)
            {
                var p = item.Value as BasePlugin;
                if (p == null)
                {
                    Logger.Current.Warn("Invalid plugin type: plugin must inherit from BasePlugin type.");
                    continue;
                }

                if (item.Metadata.Empty)
                {
                    try
                    {
                        var info = p.GetType().GetAssemblyInfo();
                        var attr = p.GetType().Assembly.GetAttribute<GuidAttribute>();
                        Guid guid = new Guid(attr.Value);
                        p.Identity = new PluginIdentity(info.ProductName, info.CompanyName, guid);
                    }
                    catch(Exception ex)
                    {
                        throw new ApplicationException("Failed to load plugin identity from assembly.", ex);
                    }
                }
                else
                {
                    p.Identity = new PluginIdentity(item.Metadata.Name, item.Metadata.Author, new Guid(item.Metadata.Guid));
                }

                // TODO: make sure that application plugins will have priority if duplicate GUIDs are found
                if (dict.ContainsKey(p.Identity.Guid))
                {
                    var p2 = dict[p.Identity.Guid];
                    string msg = string.Format("Plugins have duplicate GUIDs: {0} {1}", p, p2);
                    throw new ApplicationException(msg);
                }
                
                dict.Add(p.Identity.Guid, p);

                _container.RegisterInstance(p.GetType(), p);

                _plugins.Add(p);
            }
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

                ValidatePlugins();
            }
            catch (ReflectionTypeLoadException ex)
            {
                Logger.Current.Error("Failed to initialize plugin manager", ex);
            }
        }

        /// <summary>
        /// Gets the plugin catalog, i.e. directory to look for plugins and filename mask.
        /// </summary>
        private DirectoryCatalog GetPluginCatalog()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

            path = Path.Combine(path, PluginDirectory);

            return new DirectoryCatalog(path, "*.dll");
        }

        /// <summary>
        /// Loads a single plugin.
        /// </summary>
        /// <param name="identity">Plugin identity.</param>
        /// <param name="context">Application context.</param>
        public void LoadPlugin(PluginIdentity identity, IAppContext context)
        {
            LoadPlugin(identity.Guid, context);
        }

        public void LoadPlugin(Guid pluginGuid, IAppContext context)
        {
            if (_active.Select(p => p.Guid).Contains(pluginGuid))
            {
                return;     // it's already loaded
            }

            var plugin = _plugins.FirstOrDefault(p => p.Identity.Guid == pluginGuid);
            if (plugin == null)
            {
                throw new ApplicationException("Plugin which requested for loading isn't present in the list.");
            }

            try
            {
                plugin.DoRegisterServices(context.Container);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to register services for plugin: " + plugin.Identity + Environment.NewLine + ex.Message);
                return;
            }

            try
            {
                plugin.Initialize(context);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to load plugin: " + plugin.Identity + Environment.NewLine + ex.Message);
                return;
            }

            _active.Add(plugin.Identity);
        }

        /// <summary>
        /// Unloads single plugin and removes associated menus & toolbars
        /// </summary>
        /// <param name="identity">Plugin identity.</param>
        /// <param name="context">Application context.</param>
        /// <exception cref="System.ApplicationException">Plugin which requested for unloading isn't present in the list.</exception>
        public void UnloadPlugin(PluginIdentity identity, IAppContext context)
        {
            var plugin = _plugins.FirstOrDefault(p => p.Identity == identity);
            if (plugin == null)
            {
                throw new ApplicationException("Plugin which requested for unloading isn't present in the list.");
            }

            plugin.Terminate();
            _active.Remove(identity);

            FirePluginUnloaded(identity);
        }

        public bool PluginActive(PluginIdentity identity)
        {
            return _active.Contains(identity);
        }

        public void FireItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = MenuItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    var handler = PluginItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                    
                }
            }
        }

        public void FireStatusItemClicked(object sender, MenuItemEventArgs args)
        {
            var item = sender as IMenuItem;
            if (item != null)
            {
                if (item.PluginIdentity == PluginIdentity.Default)
                {
                    var handler = StatusItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }
                }
                else
                {
                    var handler = PluginItemClicked;
                    if (handler != null)
                    {
                        handler.Invoke(sender, args);
                    }

                }
            }
        }

        private void FirePluginUnloaded(PluginIdentity identity)
        {
            var handler = PluginUnloaded;
            if (handler != null)
            {
                handler.Invoke(this, new PluginEventArgs(identity));
            }
        }
    }
}
