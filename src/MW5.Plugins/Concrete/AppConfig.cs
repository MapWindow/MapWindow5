using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using MW5.Api.Enums;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Concrete
{
    [DataContract(Name="Settings")]
    public class AppConfig
    {
        private List<string> _recentProjects;
        private List<int> _favoriteProjections;
        private CoordinatesDisplay _coordinatesDisplay;

        public static AppConfig Instance { get; internal set; }

        public AppConfig()
        {
            SetDefaults();
        }

        private void SetDefaults()
        {
            LoadSymbology = true;
            LoadLastProject = true;
            LastProjectPath = "";
            ShowRedrawTime = false;
            ShowPyramidDialog = false;
            CreatePyramidsOnOpening = true;
            ShowValuesOnMouseMove = true;
            PyramidCompression = TiffCompression.Auto;
            PyramidSampling = RasterOverviewSampling.Nearest;
            FavoriteProjections = new List<int>();
            InnertiaOnPanning = AutoToggle.Auto;
            AnimationOnZooming = AutoToggle.Auto;
            ResizeBehavior = ResizeBehavior.KeepScale;
            ScalebarUnits = ScalebarUnits.GoogleStyle;
            ZoomBarVerbosity = ZoomBarVerbosity.Full;
            ZoomBoxStyle = ZoomBoxStyle.Blue;
            ShowWelcomeDialog = true;
            CreateSpatialIndexOnOpening = true;
            ShowSpatialIndexDialog = false;
            SymbolobyStorage = SymbologyStorage.Project;
            ShowCoordinates = true;
            CoordinatesDisplay = CoordinatesDisplay.Auto;
            CoordinateAngleFormat = AngleFormat.Seconds;
            CoordinatePrecision = 3;
            SpatialIndexFeatureCount = 10000;
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            SetDefaults();
        }

        [DataMember]
        public bool ShowWelcomeDialog { get; set; }

        [DataMember]
        public SymbologyStorage SymbolobyStorage { get; set; }

        [DataMember]
        public AutoToggle AnimationOnZooming { get; set; }

        [DataMember]
        public ResizeBehavior ResizeBehavior { get; set; }

        [DataMember]
        public ScalebarUnits ScalebarUnits { get; set; }

        [DataMember]
        public ZoomBarVerbosity ZoomBarVerbosity { get; set; }
        
        [DataMember]
        public ZoomBoxStyle ZoomBoxStyle { get; set; }

        [DataMember]
        public AutoToggle InnertiaOnPanning { get; set; }

        [DataMember]
        public ZoomBehavior ZoomBehavior { get; set; }

        [DataMember]
        public MouseWheelDirection MouseWheelDirection { get; set; }

        [DataMember]
        public Color MapBackgroundColor { get; set; }

        [DataMember]
        public bool ShowValuesOnMouseMove { get; set; }

        [DataMember]
        public bool ShowRedrawTime { get; set; }

        [DataMember]
        public bool ShowScalebar { get; set; }

        [DataMember]
        public bool ShowZoombar { get; set; }

        [DataMember]
        public bool ShowCoordinates { get; set; }

        [DataMember]
        public CoordinatesDisplay CoordinatesDisplay
        {
            get
            {
                return _coordinatesDisplay == CoordinatesDisplay.None ? CoordinatesDisplay.Auto : _coordinatesDisplay;
            }
            set 
            {
                _coordinatesDisplay = value == CoordinatesDisplay.None ? CoordinatesDisplay.Auto : value;
            }
        }

        [DataMember]
        public AngleFormat CoordinateAngleFormat { get; set; }

        [DataMember]
        public int CoordinatePrecision { get; set; }

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
        public bool ShowProjectionDialog { get; set; }

        [DataMember]
        public bool ProjectionShowWarnings { get; set; }

        [DataMember]
        public bool ProjectionShowLoadingReport { get; set; }

        [DataMember]
        public bool ShowPyramidDialog { get; set; }

        [DataMember]
        public bool ShowSpatialIndexDialog { get; set; }

        [DataMember]
        public bool CreatePyramidsOnOpening { get; set; }

        [DataMember]
        public bool CreateSpatialIndexOnOpening { get; set; }

        [DataMember]
        public TiffCompression PyramidCompression { get; set; }

        [DataMember]
        public RasterOverviewSampling PyramidSampling { get; set; }

        public int SpatialIndexFeatureCount { get; set; }

        [DataMember]
        public List<string> RecentProjects
        {
            get { return _recentProjects ?? (_recentProjects = new List<string>()); }
            set { _recentProjects = value; }
        }

        public void AddRecentProject(string path)
        {
            path = path.ToLower();

            if (RecentProjects.Contains(path))
            {
                RecentProjects.Remove(path);
            }

            RecentProjects.Add(path);

            if (RecentProjects.Count > 3)
            {
                RecentProjects.RemoveAt(0);
            }
        }

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
