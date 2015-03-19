using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;

namespace MW5.Services.Serialization
{
    [DataContract]
    public class XmlConfig
    {
        [DataMember]
        public AppSettings Settings { get; set; }

        [DataMember]
        public List<XmlPlugin> ApplicationPlugins { get; set; }
    }
}
