// -------------------------------------------------------------------------------------------
// <copyright file="PluginManager.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
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

        private readonly HashSet<PluginIdentity> _active = new HashSet<PluginIdentity>();

        private readonly IApplicationContainer _container;

        private readonly List<BasePlugin> _plugins = new List<BasePlugin>(); // all valid plugins

        private readonly MainPlugin _mainPlugin;

        [ImportMany]
#pragma warning disable 649
            private IEnumerable<Lazy<IPlugin, IPluginMetadata>> _mefPlugins; // found by MEF
#pragma warning restore 649

        /// <summary>
        /// Initializes a new instance of the <see cref="PluginManager"/> class.
        /// </summary>
        public PluginManager(IApplicationContainer container, MainPlugin mainPlugin)
        {
            Logger.Current.Trace("In PluginManager");
            if (container == null) throw new ArgumentNullException("container");
            if (mainPlugin == null) throw new ArgumentNullException("mainPlugin");

            _container = container;
            _mainPlugin = mainPlugin;
        }

        public event EventHandler<PluginEventArgs> PluginUnloaded;

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

        public IEnumerable<BasePlugin> ListeningPlugins
        {
            get { return (new[] { _mainPlugin }).Concat(_plugins.Where(p => _active.Contains(p.Identity))); }
        }

        /// <summary>
        /// Validates the list of plugins loaded by MEF.
        /// </summary>
        public void ValidatePlugins()
        {
            _plugins.Clear();

            var dict = new Dictionary<Guid, BasePlugin>();

            if (_mefPlugins == null)
            {
                return;
            }

            foreach (var item in _mefPlugins)
            {
                var p = item.Value as BasePlugin;
                if (p == null)
                {
                    Logger.Current.Warn("Invalid plugin type: plugin must inherit from BasePlugin type.");
                    continue;
                }

                try
                {
                    p.Identity = PluginIdentityHelper.GetIdentity(p.GetType(), item.Metadata);
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Failed to load plugin identity from assembly.", ex);
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

#if DEBUG
            // I didn't caught anything by this check so far;
            // Perhaps better just to check for particular assemblies in Plugins folder
            // and display warning if they are present
            CheckDuplicatedAssemblies();
#endif
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
            catch (Exception ex)
            {
                Logger.Current.Error("Failed to initialize plugin manager", ex);
            }
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
                return; // it's already loaded
            }

            var plugin = _plugins.FirstOrDefault(p => p.Identity.Guid == pluginGuid);
            if (plugin == null)
            {
                // throw new ApplicationException("Plugin which requested for loading isn't present in the list.");
                MessageService.Current.Warn("Plugin which requested for loading isn't present in the list.");
                return;
            }

            try
            {
                plugin.DoRegisterServices(context.Container);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to register services for plugin: " + plugin.Identity +
                                            Environment.NewLine + ex.Message);
                return;
            }

            try
            {
                plugin.Initialize(context);
            }
            catch (Exception ex)
            {
                MessageService.Current.Warn("Failed to load plugin: " + plugin.Identity + Environment.NewLine +
                                            ex.Message);
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

        public void RestoreApplicationPlugins(IEnumerable<Guid> plugins, IAppContext context)
        {
            var dict = new HashSet<Guid>(plugins);

            foreach (var p in AllPlugins)
            {
                // bool active = dict.Contains(p.Identity.Guid);
                var active = p.Identity.LoadOnStartup || dict.Contains(p.Identity.Guid); 
                p.SetApplicationPlugin(active);

                if (active && !PluginActive(p.Identity))
                {
                    LoadPlugin(p.Identity, context);
                }
            }
        }

        public bool PluginActive(PluginIdentity identity)
        {
            return _active.Contains(identity);
        }

        /// <summary>
        /// Checks if the same assembly was loaded from different locations in the app domain.
        /// Most likely from Plugins folder if "Copy local" flag wasn't turned off.
        /// </summary>
        private void CheckDuplicatedAssemblies()
        {
            var list = LoadedAssemblyChecker.GetConflictingAssemblies();
            foreach (var info in list)
            {
                string s = string.Format("Detected multiple load of assembly {0} from ", info.Key);

                foreach (string location in info.Value)
                {
                    s += string.Format("\t{0}", location);
                }

                Logger.Current.Warn(s);
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

        /// <summary>
        /// Gets the plugin catalog, i.e. directory to look for plugins and filename mask.
        /// </summary>
        private DirectoryCatalog GetPluginCatalog()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "";

            path = Path.Combine(path, PluginDirectory);
            string l_errMessage = "";
            try
            {
                DirectoryCatalog l_return = new DirectoryCatalog(path, "*.dll");
                // If all plugins were loaded without exception this call will be harmless
                // If not an exception will be thrown
                var list = l_return.Parts.ToList(); 
                return l_return;
            }
            catch (Exception ex)
            {
                if(ex is System.Reflection.ReflectionTypeLoadException)
                {
                    var typeLoadException = ex as ReflectionTypeLoadException;
                    var loaderExceptions = typeLoadException.LoaderExceptions;
                    foreach(Exception exp in loaderExceptions)
                    {
                        l_errMessage += exp.Message + "\n";
                        l_errMessage += "Check for missing dependencies and/or remove the offending plugin.  Until this error is resolved no plugins can be loaded.";
                    }
                }
                if(l_errMessage == "")
                {
                    l_errMessage = ex.Message;
                }
                //This ensures a message is displayed to user/analyst
                //currently calling code does not handle exception.
                MessageService.Current.Warn(l_errMessage);
                Exception ex2 = new Exception(l_errMessage);
                throw ex2;
            }
        }
    }
}