using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;

namespace MW5.Data.Repository
{
    public interface IExpandableItem: IRepositoryItem
    {
        bool ExpandedOnce { get; }
    }
}
