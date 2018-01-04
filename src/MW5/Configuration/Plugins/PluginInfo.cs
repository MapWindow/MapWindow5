using System;
using MW5.Plugins.Concrete;

namespace MW5.Configuration.Plugins
{
    public class PluginInfo
    {
        private readonly BasePlugin _plugin;

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

        public bool LoadOnStartup
        {
            get { return _plugin.Identity.LoadOnStartup; }
        }

        internal BasePlugin BasePlugin
        {
            get { return _plugin; }
        }
    }
}
