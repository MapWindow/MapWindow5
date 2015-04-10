using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class DockPanelEventArgs: EventArgs
    {
        public DockPanelEventArgs(IDockPanel panel, string key)
        {
            if (panel == null) throw new ArgumentNullException("panel");
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException("key");

            Panel = panel;
            Key = key;
        }

        public IDockPanel Panel { get; private set; }
        public string Key { get; private set; }
    }
}
