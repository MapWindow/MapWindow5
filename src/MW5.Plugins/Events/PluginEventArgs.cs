using System;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Events
{
    public class PluginEventArgs: EventArgs
    {
        private readonly PluginIdentity _identity;

        public PluginEventArgs(PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;
        }

        public PluginIdentity Identity
        {
            get { return _identity; }
        }
    }
}
