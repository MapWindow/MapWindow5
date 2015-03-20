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
            LoadLastProject = true;
            LastProjectPath = "";
        }

        [DataMember]
        public bool LoadSymbology { get; set; }

        [DataMember]
        public bool LoadLastProject { get; set; }

        [DataMember]
        public string LastProjectPath { get; set; }
    }
}
