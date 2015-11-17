using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.Concrete
{
    /// <summary>
    /// Helps to avoid passing the same data twice for the same menu item added 
    /// to the main menu and toolbar.
    /// </summary>
    public class MenuCommand
    {
        private readonly string _key;
        private readonly string _text;
        private readonly Bitmap _icon;
        private readonly string _description;

        public MenuCommand(string text, string key, Bitmap icon) 
            : this(text, key, icon, string.Empty, null, Keys.None)
        {
        }

        public MenuCommand(string text, string key, Bitmap icon, string description, PluginIdentity identity = null, 
                Keys shortcutKeys = Keys.None)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");

            if (string.IsNullOrWhiteSpace(text))
            {
                text = string.Empty;
            }

            _key = key;
            _text = text;
            _icon = icon;
            _description = description;
            PluginIdentity = identity;
            ShortcutKeys = shortcutKeys;
        }


        public string Description
        {
            get { return _description; }
        }

        public string Key
        {
            get { return _key; }
        }

        public Bitmap Icon
        {
            get { return _icon; }
        }

        public string Text
        {
            get { return _text; }
        }

        public Keys ShortcutKeys { get; set; }

        public PluginIdentity PluginIdentity { get; internal set; }
    }
}
