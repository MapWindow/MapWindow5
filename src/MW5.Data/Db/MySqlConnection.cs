using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;

namespace MW5.Data.Db
{
    public class MySqlConnection: ConnectionBase
    {
        public string Host { get; set; }
        public string PortString { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        private int ParsePort()
        {
            int port;
            if (Int32.TryParse(PortString, out port))
            {
                return port;
            }

            return -1;
        }

        public override string BuildConnection()
        {
            int port = ParsePort();
            const string cs = "MYSQL:{0},host={1},port={2},user={3},password={4}";
            return string.Format(cs, Database, Host, port, UserName, Password);
        }

        public override GeoDatabaseType DatabaseType
        {
            get { return GeoDatabaseType.MySql; }
        }

        public override string Name
        {
            get { return Database; }
        }

        public override bool Validate()
        {
            if (IgnoreParams)
            {
                return !string.IsNullOrWhiteSpace(RawConnection);
            }

            if (string.IsNullOrWhiteSpace(Host))
            {
                MessageService.Current.Warn("No host name is provided.");
                return false;
            }

            int port;
            if (!Int32.TryParse(PortString, out port))
            {
                MessageService.Current.Warn("Port must be an integer number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(UserName))
            {
                MessageService.Current.Warn("No user name is provided.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(Database))
            {
                MessageService.Current.Warn("No database name is provided.");
                return false;
            }

            return true;
        }
    }
}
