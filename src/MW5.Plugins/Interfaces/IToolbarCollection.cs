using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbarCollection : IEnumerable<IToolbar>
    {
        IToolbar Add(string name, PluginIdentity identity);
        
        void Remove(int toolbarIndex);

        IToolbar this[int toolbarIndex] { get; }

        IMenuItem FindItem(string key);
    }
}
