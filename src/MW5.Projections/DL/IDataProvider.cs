using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Projections.DL
{
    /// <summary>
    /// Custom provider interface
    /// </summary>
    public interface IDataProvider
    {
        /// <summary>
        /// Returns connection object for specified provider. No setting of properties is expected.
        /// </summary>
        DbConnection CreateConnection();

        /// <summary>
        /// Returns connection object for specified provider. Sets the connection string based on the specified db name.
        /// </summary>
        DbConnection CreateConnection(string dbName);

        /// <summary>
        /// Returns command object for specified provider. No setting of properties is expected.
        /// </summary>
        DbCommand CreateCommand();

        /// <summary>
        /// Returns parameter for simple types: string, integer, double. No setting of properties is expected.
        /// </summary>
        DbParameter CreateParameter();

        /// <summary>
        /// Creates long binary parameter for geometry field. The type of parameter should be set according to provider.
        /// </summary>
        DbParameter CreateBinaryParameter();

        /// <summary>
        /// Returns data adapter object for specified provider. No setting of properties is expected.
        /// </summary>
        DbDataAdapter CreateDataAdapter();

        /// <summary>
        /// Name of the BLOB data type to use in SQL to store geometry
        /// </summary>
        string GetBinaryTypeName();

        /// <summary>
        /// Provides the name of the interger data type for SQL exression
        /// </summary>
        string GetIntergerTypeName();

        /// <summary>
        /// Provides the name of the double data type for SQL exression
        /// </summary>
        string GetDoubleTypeName();

        /// <summary>
        /// Provides the name of the string data type for SQL exression
        /// </summary>
        string GetStringTypeName(out bool fixedLength);

        /// <summary>
        /// Creates default connection string for specified database
        /// </summary>
        string CreateConnectionString(string dbName);
    }
}
