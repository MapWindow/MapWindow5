using System.Collections.Generic;
using System.Runtime.Serialization;
using MW5.Api.Enums;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Concrete
{
    [DataContract(Name="Settings")]
    public class AppConfig
    {
        private List<int> _favoriteProjections;

        public AppConfig()
        {
            LoadSymbology = true;
            LoadLastProject = true;
            LastProjectPath = "";
            ShowRedrawTime = false;
            NeverShowPyramidDialog = false;
            CreatePyramidsOnOpening = true;
            ShowValuesOnMouseMove = true;
            PyramidCompression = TiffCompression.Auto;
            PyramidSampling = RasterOverviewSampling.Nearest;
            FavoriteProjections = new List<int>();
        }

        [DataMember]
        public bool ShowValuesOnMouseMove { get; set; }

        [DataMember]
        public bool ShowRedrawTime { get; set; }

        [DataMember]
        public bool LoadSymbology { get; set; }

        [DataMember]
        public bool LoadLastProject { get; set; }

        [DataMember]
        public string LastProjectPath { get; set; }

        [DataMember]
        public ProjectionMismatch ProjectionMismatch { get; set; }

        [DataMember]
        public ProjectionAbsence ProjectionAbsence { get; set; }

        [DataMember]
        public bool NeverShowProjectionDialog { get; set; }

        [DataMember]
        public bool ProjectionShowWarnings { get; set; }

        [DataMember]
        public bool ProjectionShowLoadingReport { get; set; }

        [DataMember]
        public bool NeverShowPyramidDialog { get; set; }

        [DataMember]
        public bool CreatePyramidsOnOpening { get; set; }

        [DataMember]
        public TiffCompression PyramidCompression { get; set; }

        [DataMember]
        public RasterOverviewSampling PyramidSampling { get; set; }

        /// <summary>
        /// List of EPSG codes for favorite projections
        /// </summary>
        [DataMember]
        public List<int> FavoriteProjections 
        {
            get { return _favoriteProjections ?? (_favoriteProjections = new List<int>()); }
            set { _favoriteProjections = value; }
        }
    }
}
