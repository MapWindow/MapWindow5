using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// Represents a list of groups at a certain level of the GIS toolbox.
    /// </summary>
    public interface IToolboxGroups : IEnumerable<IToolboxGroup>
    {
        int Count { get; }
        bool Remove(IToolboxGroup item);
        bool Contains(IToolboxGroup item);
        void Clear();
        IToolboxGroup Add(string name, string description, PluginIdentity identity);
        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
