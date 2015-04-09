using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.UI.Repository.Model
{
    public interface IRepositoryItem
    {
        RepositoryItemType Type { get; }
        RepositoryItemCollection SubItems { get; }
        object GetInternalObject();
        void Expand();
    }
}
