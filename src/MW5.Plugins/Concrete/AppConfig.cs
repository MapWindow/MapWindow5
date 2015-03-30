using System.Collections.Generic;
using System.Runtime.Serialization;

namespace MW5.Plugins.Concrete
{
    [DataContract(Name="Settings")]
    public class AppConfig
    {
        public AppConfig()
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

        [DataMember]
        public ProjectionMismatchBehavior ProjectionMismatchBehavior { get; set; }

        [DataMember]
        public ProjectionAbsenceBehavior ProjectionAbsenceBehavior { get; set; }

        [DataMember]
        public bool NeverShowProjectionDialog { get; set; }

        /// <summary>
        /// List of EPSG codes for favorite projections
        /// </summary>
        [DataMember]
        public List<int> FavoriteProjections { get; set; }
    }
}
