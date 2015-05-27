using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Helpers;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Properties;
using MW5.Services.Config;
using MW5.Shared;
using MW5.UI.Helpers;

namespace MW5.Configuration
{
    public partial class MapConfigPage : UserControl, IConfigPage
    {
        private readonly IConfigService _configService;
        private readonly IMuteMap _map;

        public MapConfigPage(IConfigService configService, IMuteMap map)
        {
            if (configService == null) throw new ArgumentNullException("configService");
            if (map == null) throw new ArgumentNullException("map");

            _configService = configService;
            _map = map;

            InitializeComponent();

            InitControls();

            Initialize();
        }

        private void InitControls()
        {
            cboAnimationOnZooming.AddItemsFromEnum<AutoToggle>();
            cboInertiaOnPanning.AddItemsFromEnum<AutoToggle>();
            cboMapResizeBehavior.AddItemsFromEnum<ResizeBehavior>();
            cboScalebarUnits.AddItemsFromEnum<ScalebarUnits>();
            cboZoombarVerbosity.AddItemsFromEnum<ZoomBarVerbosity>();
            cboZoomBoxStyle.AddItemsFromEnum<ZoomBoxStyle>();
            cboZoomBehavior.AddItemsFromEnum<ZoomBehavior>();
            cboMouseWheelDirection.AddItemsFromEnum<MouseWheelDirection>();
            cboCoordinateDisplay.AddItemsFromEnum<CoordinatesDisplay>();
            cboAngleFormat.AddItemsFromEnum<AngleFormat>();
        }

        private void Initialize()
        {
            var config = _configService.Config;
            
            chkShowRedrawTime.Checked = config.ShowRedrawTime;
            chkShowScalebar.Checked = config.ShowScalebar;
            chkShowZoombar.Checked = config.ShowZoombar;
            chkShowCoordinates.Checked = config.ShowCoordinates;

            cboAnimationOnZooming.SetValue(config.AnimationOnZooming);
            cboMapResizeBehavior.SetValue(config.ResizeBehavior);
            cboScalebarUnits.SetValue(config.ScalebarUnits);
            cboZoombarVerbosity.SetValue(config.ZoomBarVerbosity);
            cboZoomBoxStyle.SetValue(config.ZoomBoxStyle);
            cboInertiaOnPanning.SetValue(config.InnertiaOnPanning);
            cboZoomBehavior.SetValue(config.ZoomBehavior);
            cboMouseWheelDirection.SetValue(config.MouseWheelDirection);
            cboCoordinateDisplay.SetValue(config.CoordinateDisplay);
            cboAngleFormat.SetValue(config.CoordinateAngleFormat);

            udCoordinatePrecision.SetValue(config.CoordinatePrecision);

            clpBackground.Color = config.MapBackgroundColor;
        }

        public string PageName
        {
            get { return "Map"; }
        }

        public void Save()
        {
            var config = _configService.Config;
            config.ShowRedrawTime = chkShowRedrawTime.Checked;
            config.ShowZoombar = chkShowZoombar.Checked;
            config.ShowScalebar = chkShowScalebar.Checked;
            config.ShowCoordinates = chkShowCoordinates.Checked;

            config.AnimationOnZooming = cboAnimationOnZooming.GetValue<AutoToggle>();
            config.ResizeBehavior = cboMapResizeBehavior.GetValue<ResizeBehavior>();
            config.ScalebarUnits = cboScalebarUnits.GetValue<ScalebarUnits>();
            config.ZoomBarVerbosity = cboZoombarVerbosity.GetValue<ZoomBarVerbosity>();
            config.ZoomBoxStyle = cboZoomBoxStyle.GetValue<ZoomBoxStyle>();
            config.InnertiaOnPanning = cboInertiaOnPanning.GetValue<AutoToggle>();
            config.ZoomBehavior = cboZoomBehavior.GetValue<ZoomBehavior>();
            config.MouseWheelDirection = cboMouseWheelDirection.GetValue<MouseWheelDirection>();
            config.CoordinateDisplay = cboCoordinateDisplay.GetValue<CoordinatesDisplay>();
            config.CoordinateAngleFormat = cboAngleFormat.GetValue<AngleFormat>();

            config.CoordinatePrecision = (int)udCoordinatePrecision.Value;

            config.MapBackgroundColor = clpBackground.Color;

            _map.ApplyConfig(_configService);
        }

        public Bitmap Icon
        {
            get { return Resources.img_globe32; }
        }

        public bool PluginPage
        {
            get { return false; }
        }

        public ConfigPageType PageTypeType
        {
            get { return ConfigPageType.Map; }
        }

        public string Description
        {
            get { return "Settings that change appearance, behavior and widgets shown on the map."; }
        }
    }
}
