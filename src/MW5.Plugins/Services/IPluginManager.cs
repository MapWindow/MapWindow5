using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Services
{
    public interface IPluginManager
    {
        event EventHandler<PluginEventArgs> PluginUnloaded;

        /// <summary>
        /// Gets list of all plugins both active and not.
        /// </summary>
        IEnumerable<BasePlugin> AllPlugins { get; }

        /// <summary>
        /// Gets list of application plugins, i.e. those that are loaded on application start.
        /// </summary>
        IEnumerable<BasePlugin> ApplicationPlugins { get; }

        /// <summary>
        /// Gets list of all custom plugins, i.e. those that aren't loaded by default on application start.
        /// </summary>
        IEnumerable<BasePlugin> CustomPlugins { get; }

        /// <summary>
        /// Gets list of only active plugins.
        /// </summary>
        IEnumerable<BasePlugin> ActivePlugins { get; }

        /// <summary>
        /// Gets list of all active plugins + a plugin events listener of the main app.
        /// </summary>
        IEnumerable<BasePlugin> ListeningPlugins { get; }

        /// <summary>
        /// Validates the list of plugins loaded by MEF.
        /// </summary>
        void ValidatePlugins();

        /// <summary>
        /// Searches plugins in plugins folder with MEF.
        /// </summary>
        void AssemblePlugins();

        /// <summary>
        /// Loads a single plugin.
        /// </summary>
        /// <param name="identity">Plugin identity.</param>
        /// <param name="settings">Plugin settings.</param>
        /// <param name="context">Application context.</param>
        void LoadPlugin(PluginIdentity identity, IDictionary<string, string> settings, IAppContext context);

        void LoadPlugin(string PluginName, Guid pluginGuid, IDictionary<string, string> settings, IAppContext context);

        /// <summary>
        /// Unloads single plugin and removes associated menus & toolbars
        /// </summary>
        /// <param name="identity">Plugin identity.</param>
        /// <param name="context">Application context.</param>
        /// <exception cref="System.ApplicationException">Plugin which requested for unloading isn't present in the list.</exception>
        void UnloadPlugin(PluginIdentity identity, IAppContext context);

        bool PluginActive(PluginIdentity identity);

        void RestoreApplicationPlugins(IEnumerable<Guid> plugins, IAppContext context, Action<PluginIdentity> pluginLoadingCallback = null);
    }
}
