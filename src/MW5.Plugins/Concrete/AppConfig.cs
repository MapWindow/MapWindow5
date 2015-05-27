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
            InnertiaOnPanning = AutoToggle.Auto;
            AnimationOnZooming = AutoToggle.Auto;
            ResizeBehavior = ResizeBehavior.KeepScale;
            ScalebarUnits = ScalebarUnits.GoogleStyle;
            ZoomBarVerbosity = ZoomBarVerbosity.Full;
            ZoomBoxStyle = ZoomBoxStyle.Blue;
            ShowWelcomeDialog = true;
            CreateSpatialIndexOnOpening = true;
            NeverShowSpatialIndexDialog = false;
            SymbolobyStorage = SymbologyStorage.Project;
            ShowCoordinates = true;
            CoordinateDisplay = CoordinatesDisplay.Auto;
            CoordinateAngleFormat = AngleFormat.Seconds;
            CoordinatePrecision = 3;
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
        public CoordinatesDisplay CoordinateDisplay { get; set; }

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
        public bool NeverShowProjectionDialog { get; set; }

        [DataMember]
        public bool ProjectionShowWarnings { get; set; }

        [DataMember]
        public bool ProjectionShowLoadingReport { get; set; }

        [DataMember]
        public bool NeverShowPyramidDialog { get; set; }

        [DataMember]
        public bool NeverShowSpatialIndexDialog { get; set; }

        [DataMember]
        public bool CreatePyramidsOnOpening { get; set; }

        [DataMember]
        public bool CreateSpatialIndexOnOpening { get; set; }

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
