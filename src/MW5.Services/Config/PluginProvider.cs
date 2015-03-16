using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Concrete;

namespace MW5.Services.Config
{
    internal class PluginProvider
    {
        private readonly PluginManager _manager;
        private readonly AppConfig _config;

        public PluginProvider(PluginManager manager, AppConfig config)
        {
            _manager = manager;
            _config = config;
        }

        public IEnumerable<PluginInfo> List
        {
            get {
                return _manager.AllPlugins.Select(p => new PluginInfo(p, false));
            }
        }

        public class PluginInfo
        {
            private BasePlugin _plugin;

            public PluginInfo(BasePlugin plugin, bool selected)
            {
                if (plugin == null) throw new ArgumentNullException("plugin");
                _plugin = plugin;
                Selected = selected;
            }

            public bool Selected { get; set; }

            public string Name
            {
                get { return _plugin.Identity.Name; }
            }

            public string Author
            {
                get { return _plugin.Identity.Author; }
            }
        }
    }
}
