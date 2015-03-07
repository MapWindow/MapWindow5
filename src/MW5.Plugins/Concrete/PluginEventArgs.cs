using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Concrete
{
    public class PluginEventArgs: EventArgs
    {
        private readonly PluginIdentity _identity;

        public PluginEventArgs(PluginIdentity identity)
        {
            if (identity == null) throw new ArgumentNullException("identity");
            _identity = identity;
        }

        public PluginIdentity Identity { get; private set; }
    }
}
