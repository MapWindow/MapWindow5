using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Data.Repository
{
    public interface IDatabaseItem: IRepositoryItem
    {
        DatabaseConnection Connection { get; }
    }
}
