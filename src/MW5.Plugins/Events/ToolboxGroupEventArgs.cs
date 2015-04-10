using System;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Events
{
    public class ToolboxGroupEventArgs : EventArgs
    {
        public ToolboxGroupEventArgs(IToolboxGroup group)
        {
            if (group == null) throw new ArgumentNullException("group");
            Group = group;
        }

        public IToolboxGroup Group { get; private set; }
    }
}
