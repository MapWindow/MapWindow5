using System;
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
        private List<Guid> _applicationPlugins;
        private CoordinatesDisplay _coordinatesDisplay;

        public static AppConfig Instance { get; internal set; }

        public AppConfig()
        {
            SetDefaults();
        }

        public void SetDefaults()
        {
            AnimationOnZooming = AutoToggle.Auto;
            CoordinateAngleFormat = AngleFormat.Seconds;
            CoordinatesDisplay = CoordinatesDisplay.Auto;
            CoordinatePrecision = 3;
            CreatePyramidsOnOpening = true;
            CreateSpatialIndexOnOpening = true;
            DisplayDynamicVisibilityWarnings = true;
            FirstRun = true;
            InnertiaOnPanning = AutoToggle.Auto;
            LastProjectPath = "";
            LoadLastProject = true;
            LoadSymbology = true;
            MapBackgroundColor = Color.White;
            MouseWheelDirection = MouseWheelDirection.Forward;
            ProjectionAbsence = ProjectionAbsence.IgnoreAbsence;
            ProjectionMismatch = ProjectionMismatch.Reproject;
            ProjectionShowLoadingReport = true;
            PyramidCompression = TiffCompression.Auto;
            PyramidSampling = RasterOverviewSampling.Nearest;
            ResizeBehavior = ResizeBehavior.KeepScale;
            ReuseTileBuffer = true;
            ScalebarUnits = ScalebarUnits.GoogleStyle;
            ShowCoordinates = true;
            ShowMenuToolTips = false;
            ShowPluginInToolTip = false;        // perhaps some kind of debug mode will be enough
            ShowProjectionDialog = true;
            ShowPyramidDialog = true;
            ShowRedrawTime = false;
            ShowScalebar = true;
            ShowSpatialIndexDialog = false;
            ShowValuesOnMouseMove = true;
            ShowWelcomeDialog = true;
            ShowZoombar = true;
            SpatialIndexFeatureCount = 10000;
            SymbolobyStorage = SymbologyStorage.Project;
            ZoomBarVerbosity = ZoomBarVerbosity.Full;
            ZoomBehavior = ZoomBehavior.UseTileLevels;
            ZoomBoxStyle = ZoomBoxStyle.Blue;
        }

        [OnDeserializing]
        private void OnDeserializing(StreamingContext context)
        {
            SetDefaults();
        }

        [DataMember]
        public AutoToggle AnimationOnZooming { get; set; }

        [DataMember]
        public List<Guid> ApplicationPlugins
        {
            get { return _applicationPlugins ?? (_applicationPlugins = DefaultApplicationPlugins); }
            set { _applicationPlugins = value; }
        }

        [DataMember]
        public AngleFormat CoordinateAngleFormat { get; set; }

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
        public int CoordinatePrecision { get; set; }

        [DataMember]
        public bool CreatePyramidsOnOpening { get; set; }

        [DataMember]
        public bool CreateSpatialIndexOnOpening { get; set; }

        [DataMember]
        public bool DisplayDynamicVisibilityWarnings { get; set; }

        /// <summary>
        /// List of EPSG codes for favorite projections
        /// </summary>
        [DataMember]
        public List<int> FavoriteProjections
        {
            get { return _favoriteProjections ?? (_favoriteProjections = new List<int>()); }
            set { _favoriteProjections = value; }
        }

        [DataMember]
        public bool FirstRun { get; set; }

        [DataMember]
        public AutoToggle InnertiaOnPanning { get; set; }

        [DataMember]
        public string LastProjectPath { get; set; }

        [DataMember]
        public bool LoadLastProject { get; set; }

        [DataMember]
        public bool LoadSymbology { get; set; }

        [DataMember]
        public Color MapBackgroundColor { get; set; }
        
        [DataMember]
        public MouseWheelDirection MouseWheelDirection { get; set; }

        [DataMember]
        public ProjectionAbsence ProjectionAbsence { get; set; }

        [DataMember]
        public ProjectionMismatch ProjectionMismatch { get; set; }

        [DataMember]
        public bool ProjectionShowLoadingReport { get; set; }

        [DataMember]
        public TiffCompression PyramidCompression { get; set; }

        [DataMember]
        public RasterOverviewSampling PyramidSampling { get; set; }

        [DataMember]
        public List<string> RecentProjects
        {
            get { return _recentProjects ?? (_recentProjects = new List<string>()); }
            set { _recentProjects = value; }
        }

        [DataMember]
        public ResizeBehavior ResizeBehavior { get; set; }

        [DataMember]
        public bool ReuseTileBuffer { get; set; }

        [DataMember]
        public ScalebarUnits ScalebarUnits { get; set; }

        [DataMember]
        public bool ShowCoordinates { get; set; }

        [DataMember]
        public bool ShowMenuToolTips { get; set; }

        [DataMember]
        public bool ShowPluginInToolTip { get; set; }

        [DataMember]
        public bool ShowProjectionDialog { get; set; }

        [DataMember]
        public bool ShowPyramidDialog { get; set; }

        [DataMember]
        public bool ShowRedrawTime { get; set; }

        [DataMember]
        public bool ShowScalebar { get; set; }

        [DataMember]
        public bool ShowSpatialIndexDialog { get; set; }

        [DataMember]
        public bool ShowValuesOnMouseMove { get; set; }

        [DataMember]
        public bool ShowWelcomeDialog { get; set; }

        [DataMember]
        public bool ShowZoombar { get; set; }

        [DataMember]
        public int SpatialIndexFeatureCount { get; set; }

        [DataMember]
        public SymbologyStorage SymbolobyStorage { get; set; }

        [DataMember]
        public ZoomBarVerbosity ZoomBarVerbosity { get; set; }

        [DataMember]
        public ZoomBehavior ZoomBehavior { get; set; }

        [DataMember]
        public ZoomBoxStyle ZoomBoxStyle { get; set; }

        public List<Guid> DefaultApplicationPlugins
        {
            get
            {
                return new List<Guid>()
                {
                    new Guid("7B9DF651-4B8B-4AA8-A4A9-C1463A35DAC7"),   // Symbology
                    new Guid("F24E7086-1762-4A7C-8403-D1169309CBC6"),   // Repository
                    new Guid("65beb2fd-eec2-461c-965e-f20a0cef2aa2"),   // Identifier
                    new Guid("894E958F-69DD-48DF-B35B-16871EC5D309"),   // Table editor
                    new Guid("70120ff9-1c6b-49a1-8949-dded8bcef499"),   // Shape editor
                    new Guid("F0CDF80F-5F74-48F6-8C8D-75F9B505EEE0"),   // Debug window
                };
            }
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
    }
}
