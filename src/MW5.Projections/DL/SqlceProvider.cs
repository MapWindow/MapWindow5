using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.DL
{

#if SQL_SERVER_CE
    using System.Data.SqlServerCe;

    /// <summary>
    /// Imlementation of IDataProvider interface for SQL Server compact edition
    /// </summary>
    public class SqlCeProvider : MapWindow.Data.IDataProvider
    {
        public DbParameter CreateBinaryParameter()
        {
            SqlCeParameter param = new SqlCeParameter();
            param.SqlDbType = SqlDbType.VarBinary;
            return param;
        }
        public DbCommand CreateCommand()
        {
            return new SqlCeCommand();
        }
        public DbConnection CreateConnection()
        {
            return new SqlCeConnection();
        }
        public DbDataAdapter CreateDataAdapter()
        {
            return new SqlCeDataAdapter();
        }
        public DbParameter CreateParameter()
        {
            return new SqlCeParameter();
        }
        public string GetBinaryTypeName()
        {
            return "image";
        }
        public string GetIntergerTypeName()
        {
            return "integer";
        }
        public string GetDoubleTypeName()
        {
            return "float";
        }
        public string GetStringTypeName(out bool fixedLength)
        {
            fixedLength = true;
            return "nvarchar";
        }
        public string CreateConnectionString(string dbName)
        {
            return "Data Source=" + dbName + ";Persist Security Info=False;";
        }
    }

#endif

}
