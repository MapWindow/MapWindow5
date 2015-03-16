using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MW5.Plugins.Concrete
{
    [DataContract(Name="Config")]
    public class AppConfig
    {
        public AppConfig()
        {
            LoadSymbology = true;
        }

        [DataMember]
        public bool LoadSymbology { get; set; }
        
        public List<BasePlugin> Plugins;
    }
}
