using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Data.Db;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;

namespace MW5.Data.Views
{
    public class AddConnectionModel
    {
        public AddConnectionModel(GeoDatabaseType? databaseType)
        {
            DatabaseType = databaseType;
        }

        public GeoDatabaseType? DatabaseType { get; set; }

        /// <summary>
        /// Gets or sets the resulting connection selected by user.
        /// </summary>
        public DatabaseConnection Connection { get; set; }
    }
}
