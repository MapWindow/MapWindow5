using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class DockPanelCancelEventArgs: DockPanelEventArgs, ICancellableEvent
    {
        public DockPanelCancelEventArgs(IDockPanel panel, string key) : base(panel, key)
        {
        }

        public bool Cancel { get; set; }
    }
}
