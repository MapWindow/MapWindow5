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
        public const string UnknownPassword = "xxxxxx";

        public string GetConnection(bool noPassword = false)
        {
            if (IgnoreParams)
            {
                // TODO: how to hide the password here?
                return RawConnection;
            }

            return BuildConnection(noPassword);
        }

        public abstract string BuildConnection(bool noPassword = false);

        public abstract GeoDatabaseType DatabaseType { get; }

        public string RawConnection { get; set; }
        
        public bool IgnoreParams { get; set; }

        public abstract string Name { get; }

        public abstract bool Validate();
    }
}
