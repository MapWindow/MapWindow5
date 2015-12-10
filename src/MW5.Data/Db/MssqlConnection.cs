using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Data.Db
{
    internal class MssqlConnection: ConnectionBase
    {
        public MssqlConnection()
        {
            WindowsAuthentication = true;
        }

        public string Server { get; set; }

        public string Database { get; set; }

        public bool WindowsAuthentication { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public override string BuildConnection(bool noPassword = false)
        {
            string s = string.Format("MSSQL:server={0};database={1}", Server, Database);

            if (WindowsAuthentication)
            {
                s += ";trusted_connection=yes";
            }
            else
            {
                s += string.Format(";user={0};password={1}", UserName, noPassword ? UnknownPassword : Password);
            }

            return s;
        }

        public override GeoDatabaseType DatabaseType
        {
            get { return GeoDatabaseType.MsSql; }
        }

        public override string Name
        {
            get { return Database; }
        }

        public override bool Validate()
        {
            // TODO: implement
            
            return true;
        }
    }
}
