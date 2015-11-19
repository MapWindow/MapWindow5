using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Model;

namespace MW5.Data.Repository
{
    public interface IGroupItem: IExpandableItem
    {
        RepositoryGroup Group { get; }
    }
}
