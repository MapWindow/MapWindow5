using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.UI
{
    /// <summary>
    /// Stored in the tag of menu item
    /// </summary>
    internal class MenuItemMetadata
    {
        private readonly PluginIdentity _identity;
        private readonly string _key;

        public MenuItemMetadata(PluginIdentity identity, string key)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;
            _key = key;
        }

        public PluginIdentity PluginIdentity
        {
            get { return _identity; }
        }

        public object Tag { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Key
        {
            get { return _key; }
        }
    }
}
