using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Data.Repository
{
    public class ServerItemMetadata: IItemMetadata
    {
        public ServerItemMetadata(GeoDatabaseType databaseType)
        {
            DatabaseType = databaseType;
        }
        
        public GeoDatabaseType DatabaseType { get; private set; }
    }
}
