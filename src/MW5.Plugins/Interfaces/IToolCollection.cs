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
    public interface IToolCollection : IEnumerable<IToolBoxToolItem>
    {
        void Clear();
        int Count { get; }
        bool Remove(ITool item);
        void Add(ITool item);
        void RemoveItemsForPlugin(PluginIdentity identity);
    }
}
