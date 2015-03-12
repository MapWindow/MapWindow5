using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins;
using MW5.Plugins.Interfaces;

namespace MW5.Services.Serialization
{
    public interface ISerializableContext: IAppContext
    {
        PluginManager PluginManager { get; }
    }
}
