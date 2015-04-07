using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    /// <summary>
    /// A wrapper for the list of tools
    /// </summary>
    public interface IToolCollection : IEnumerable<IGisTool>
    {
        void Clear();
        bool Contains(IGisTool item);
        int Count { get; }
        bool Remove(IGisTool item);
        void Add(IGisTool item);
        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
