using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Data.Repository
{
    internal class DatabaseItemMetadata: IItemMetadata
    {
        public DatabaseItemMetadata(DatabaseConnection connection)
        {
            Connection = connection;
        }

        public DatabaseConnection Connection { get; set; }
    }
}
