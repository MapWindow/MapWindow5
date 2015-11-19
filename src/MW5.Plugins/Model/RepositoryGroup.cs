using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Model
{
    [DataContract]
    public class RepositoryGroup
    {
        public RepositoryGroup(Guid guid, string name)
        {
            Guid = guid;
            Name = name;
        }

        [DataMember]
        public Guid Guid { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Expanded { get; set; }
    }
}
