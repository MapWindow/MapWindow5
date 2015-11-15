using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Model;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlRepository
    {
        public XmlRepository(IRepository repository)
        {
            if (repository == null) throw new ArgumentNullException("repository");

            Folders = repository.Folders.ToList();
            Connections = repository.Connections.ToList();
            WmsServers = repository.WmsServers.ToList();
            TmsProviders = repository.TmsProviders.ToList();
        }

        [DataMember]
        public List<string> Folders { get; set; }

        [DataMember]
        public List<DatabaseConnection> Connections { get; set; }

        [DataMember]
        public List<WmsServer> WmsServers { get; set; }

        [DataMember]
        public List<TmsProvider> TmsProviders { get; set; }
    }
}
