using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.DL
{
    /// <summary>
    /// SQLite provider for shapefile conveter
    /// </summary>
    public class SqliteProvider : IDataProvider
    {
        public DbConnection CreateConnection()
        {
            return new SQLiteConnection();
        }
        public DbCommand CreateCommand()
        {
            return new SQLiteCommand();
        }
        public DbParameter CreateParameter()
        {
            return new SQLiteParameter();
        }
        public DbParameter CreateBinaryParameter()
        {
            SQLiteParameter param = new SQLiteParameter {DbType = DbType.Object};
            return param;
        }
        public DbDataAdapter CreateDataAdapter()
        {
            return new SQLiteDataAdapter();
        }
        public string GetBinaryTypeName()
        {
            return "BLOB";
        }
        public string GetIntergerTypeName()
        {
            return "INTEGER";
        }
        public string GetDoubleTypeName()
        {
            return "REAL";
        }
        public string GetStringTypeName(out bool fixedLength)
        {
            fixedLength = false;
            return "TEXT";
        }
        public string CreateConnectionString(string dbName)
        {
            return "Data Source = " + dbName + "; Version = 3;";
        }
        public DbConnection CreateConnection(string dbName)
        {
            DbConnection conn = this.CreateConnection();
            conn.ConnectionString = this.CreateConnectionString(dbName);
            return conn;
        }
    }
}
