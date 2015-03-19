using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MW5.Plugins.Concrete
{
    [DataContract(Name="Settings")]
    public class AppSettings
    {
        public AppSettings()
        {
            LoadSymbology = true;
        }

        [DataMember]
        public bool LoadSymbology { get; set; }
        
        public List<BasePlugin> Plugins;
    }
}
