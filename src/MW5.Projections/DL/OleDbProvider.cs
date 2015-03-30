using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.DL
{
    /// <summary>
    /// OleDb provider for shapefile converter
    /// </summary>
    public class OleDbProvider : IDataProvider
    {
        public DbConnection CreateConnection()
        {
            return new OleDbConnection();
        }
        public DbCommand CreateCommand()
        {
            return new OleDbCommand();
        }
        public DbParameter CreateParameter()
        {
            return new OleDbParameter();
        }
        public DbDataAdapter CreateDataAdapter()
        {
            return new OleDbDataAdapter();
        }
        public DbParameter CreateBinaryParameter()
        {
            OleDbParameter param = new OleDbParameter();
            param.OleDbType = OleDbType.LongVarBinary;
            return param;
        }
        public string GetBinaryTypeName()
        {
            return "longbinary";
        }
        public string GetIntergerTypeName()
        {
            return "integer";
        }
        public string GetDoubleTypeName()
        {
            return "double";
        }
        public string GetStringTypeName(out bool fixedLength)
        {
            fixedLength = true;
            return "char";
        }
        public string CreateConnectionString(string dbName)
        {
            return "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + dbName + ";User Id=admin;Password=;";
        }
        public DbConnection CreateConnection(string dbName)
        {
            DbConnection conn = this.CreateConnection();
            conn.ConnectionString = this.CreateConnectionString(dbName);
            return conn;
        }
    }
}
