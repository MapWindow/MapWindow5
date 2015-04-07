using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        void Add(IToolboxGroup item);
    }
}
