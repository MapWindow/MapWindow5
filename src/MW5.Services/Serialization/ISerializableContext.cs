using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Services.Serialization
{
    public interface ISerializableContext: IAppContext
    {
        IPluginManager PluginManager { get; }
    }
}
