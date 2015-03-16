using System.Collections.Generic;
using System.Linq;
using MW5.Plugins;
using MW5.Plugins.Concrete;

namespace MW5.Configuration
{
    internal class PluginProvider
    {
        private readonly PluginManager _manager;
        private readonly AppConfig _config;

        public PluginProvider(AppConfig config, PluginManager manager)
        {
            _manager = manager;
            _config = config;
        }

        public IEnumerable<PluginInfo> List
        {
            get {
                return _manager.AllPlugins.Select(p => new PluginInfo(p, false)).ToList();
            }
        }
    }
}
