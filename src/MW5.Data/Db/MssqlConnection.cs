// -------------------------------------------------------------------------------------------
// <copyright file="MssqlConnection.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Plugins.Enums;

namespace MW5.Data.Db
{
    internal class MssqlConnection : ConnectionBase
    {
        public MssqlConnection()
        {
            WindowsAuthentication = true;
        }

        public string Database { get; set; }

        public override GeoDatabaseType DatabaseType
        {
            get { return GeoDatabaseType.MsSql; }
        }

        public override string Name
        {
            get { return Database; }
        }

        public string Password { get; set; }

        public string Server { get; set; }

        public string UserName { get; set; }

        public bool WindowsAuthentication { get; set; }

        public override string BuildConnection(bool noPassword = false)
        {
            var s = string.Format("MSSQL:server={0};database={1}", Server, Database);

            if (WindowsAuthentication)
            {
                s += ";trusted_connection=yes";
            }
            else
            {
                // CORE-131: s += string.Format(";user={0};password={1}", UserName, noPassword ? UnknownPassword : Password);
                s += string.Format(";trusted_connection=no;uid={0};pwd={1}", UserName, noPassword ? UnknownPassword : Password);
            }

            return s;
        }

        public override bool Validate()
        {
            // TODO: implement

            return true;
        }
    }
}