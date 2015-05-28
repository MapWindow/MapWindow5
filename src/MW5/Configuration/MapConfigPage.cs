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

        public MapConfigPage(IConfigService configService)
        {
            if (configService == null) throw new ArgumentNullException("configService");

            _configService = configService;

            InitializeComponent();

            InitControls();

            Initialize();
        }

        private void InitControls()
        {
            cboAnimationOnZooming.AddItemsFromEnum<AutoToggle>();
            cboInertiaOnPanning.AddItemsFromEnum<AutoToggle>();
            cboMapResizeBehavior.AddItemsFromEnum<ResizeBehavior>();
            
            cboZoomBoxStyle.AddItemsFromEnum<ZoomBoxStyle>();
            cboZoomBehavior.AddItemsFromEnum<ZoomBehavior>();
            cboMouseWheelDirection.AddItemsFromEnum<MouseWheelDirection>();
            
        }

        private void Initialize()
        {
            var config = _configService.Config;
            
            cboAnimationOnZooming.SetValue(config.AnimationOnZooming);
            cboMapResizeBehavior.SetValue(config.ResizeBehavior);
           
            cboZoomBoxStyle.SetValue(config.ZoomBoxStyle);
            cboInertiaOnPanning.SetValue(config.InnertiaOnPanning);
            cboZoomBehavior.SetValue(config.ZoomBehavior);
            cboMouseWheelDirection.SetValue(config.MouseWheelDirection);
            

            clpBackground.Color = config.MapBackgroundColor;
        }

        public string PageName
        {
            get { return "Map"; }
        }

        public void Save()
        {
            var config = _configService.Config;


            config.AnimationOnZooming = cboAnimationOnZooming.GetValue<AutoToggle>();
            config.ResizeBehavior = cboMapResizeBehavior.GetValue<ResizeBehavior>();
            
            config.ZoomBoxStyle = cboZoomBoxStyle.GetValue<ZoomBoxStyle>();
            config.InnertiaOnPanning = cboInertiaOnPanning.GetValue<AutoToggle>();
            config.ZoomBehavior = cboZoomBehavior.GetValue<ZoomBehavior>();
            config.MouseWheelDirection = cboMouseWheelDirection.GetValue<MouseWheelDirection>();

            config.MapBackgroundColor = clpBackground.Color;
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
