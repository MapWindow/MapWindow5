using System;
using MW5.Plugins.Concrete;

namespace MW5.Configuration
{
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

        internal string Description
        {
            get { return _plugin.Description; }
        }
    }
}
