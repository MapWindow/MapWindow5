using System;

namespace MW5.Plugins.Events
{
    public class MenuItemEventArgs: EventArgs
    {
        private string _itemKey;

        public MenuItemEventArgs(string itemKey)
        {
            _itemKey = itemKey ?? string.Empty;
        }

        public string ItemKey
        {
            get { return _itemKey; }
        }
    }
}
