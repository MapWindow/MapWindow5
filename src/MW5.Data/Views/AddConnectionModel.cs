using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Data.Views
{
    public class AddConnectionModel
    {
        public AddConnectionModel(GeoDatabaseType databaseType)
        {
            DatabaseType = databaseType;
        }

        public GeoDatabaseType DatabaseType { get; set; }
    }
}
