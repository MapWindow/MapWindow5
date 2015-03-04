using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbarCollection : IEnumerable<IToolbar>
    {
        /// <summary>
        /// Adds a new toolbar
        /// </summary>
        /// <param name="name">The name o the toolbar</param>
        /// <returns>True on success.</returns>
        IToolbar Add(string name);
        
        void Remove(int toolbarIndex);

        IToolbar this[int toolbarIndex] { get; }
    }
}
