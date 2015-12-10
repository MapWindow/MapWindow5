using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Concrete
{
    [DataContract]
    public class DatabaseConnection
    {
        private string _secureConnection;

        public DatabaseConnection(GeoDatabaseType databaseType, string name, string connection, string secureConnection)
        {
            DatabaseType = databaseType;
            Name = name;
            ConnectionString = connection;
            _secureConnection = secureConnection;
        }

        [DataMember]
        public GeoDatabaseType DatabaseType { get; private set; }
        
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public string SecureConnection { get; private set; }
        
        public string GetUIConnection()
        {
            if (string.IsNullOrWhiteSpace(_secureConnection))
            {
                // it's mostly temporary to display something for existing connections
                return ConnectionString;
            }
            return _secureConnection;
        }

        [DataMember]
        public string ConnectionString { get; private set; }

        public IEnumerable<string> GetSchemas()
        {
            using (var source = new VectorDatasource())
            {
                if (source.Open(ConnectionString))
                {
                    foreach (var s in source.GetShemas())
                    {
                        yield return s;
                    }
                }
            }
        }

        public override string ToString()
        {
            return DatabaseType + ": " + Name;
        }
    }
}
