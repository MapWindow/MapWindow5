using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Data.Db
{
    public abstract class ConnectionBase: IConnectionParams
    {
        public string GetConnection()
        {
            if (IgnoreParams)
            {
                return RawConnection;
            }

            return BuildConnection();
        }

        public abstract string BuildConnection();

        public abstract GeoDatabaseType DatabaseType { get; }

        public string RawConnection { get; set; }
        
        public bool IgnoreParams { get; set; }

        public abstract string Name { get; }

        public abstract bool Validate();
    }
}
