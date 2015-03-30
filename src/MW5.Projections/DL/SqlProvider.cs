using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.DL
{

#if SQL_SERVER

    using System.Data.SqlClient;

    /// <summary>
    /// Sql provider for shapefile converter
    /// </summary>
    public class SqlProvider : IDataProvider
    {
        public DbConnection CreateConnection()
        {
            return new SqlConnection();
        }
        public DbCommand CreateCommand()
        {
            return new SqlCommand();
        }
        public DbParameter CreateParameter()
        {
            return new SqlParameter();
        }
        public DbDataAdapter CreateDataAdapter()
        {
            return new SqlDataAdapter();
        }
        public DbParameter CreateBinaryParameter()
        {
            SqlParameter param = new SqlParameter();
            param.SqlDbType = SqlDbType.VarBinary;
            return param;
        }
        public string GetBinaryTypeName()
        {
            return "varbinary(max)";
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
