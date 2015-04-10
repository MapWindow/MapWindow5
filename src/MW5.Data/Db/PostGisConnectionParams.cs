using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Data.Db
{
    public class PostGisConnectionParams
    {
        public string Host { get; set; }
        public string PortString { get; set; }
        public int Port { get; set; }
        public string Database { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public PostGisConnectionParams()
        {
            SetDefaults();
        }

        public void SetDefaults()
        {
            Database = "";
            Password = "";
            Port = 5432;
            UserName = "postgres";
            Host = "127.0.0.1";
        }

        public string GetPostGisConnection()
        {
            string cs = "PG:host={0} port={1} dbname={2} user={3} password={4}";
            return string.Format(cs, Host, Port, Database, UserName, Password);
        }

        public bool ParsePort()
        {
            int port;
            if (Int32.TryParse(PortString, out port))
            {
                Port = port;
                return true;
            }

            return false;
        }
    }
}
