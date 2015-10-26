using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces
{
    public interface IToolbarCollection: IToolbarCollectionBase
    {
        IToolbar MapToolbar { get; }

        IToolbar FileToolbar { get; }
    }
}
