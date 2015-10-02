using System;
using MW5.Plugins.Concrete;

namespace MW5.UI.Menu
{
    /// <summary>
    /// Stored in the tag of menu item
    /// </summary>
    internal class MenuItemMetadata
    {
        private readonly PluginIdentity _identity;
        private readonly string _key;

        public MenuItemMetadata(PluginIdentity identity, string key, bool dropDown = false)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;
            _key = key;
            DropDown = dropDown;
        }

        public PluginIdentity PluginIdentity
        {
            get { return _identity; }
        }

        public object Tag { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }
        
        public bool BeginGroup { get; set; }

        public bool DropDown { get; private set; }

        public string Key
        {
            get { return _key; }
        }
    }
}
