using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.Plugins.Services;

namespace MW5.Helpers
{
    public static class MapInitializer
    {
        public static void Initialize(this IMap map)
        {
            map.GrabProjectionFromData = true;
            map.MapCursor = MapCursor.ZoomIn;
            map.InertiaOnPanning = AutoToggle.Auto;
            map.ShowRedrawTime = false;
            map.Identifier.Mode = IdentifierMode.SingleLayer;
            map.Identifier.HotTracking = true;
            map.GeometryEditor.HighlightVertices = LayerSelectionMode.NoLayer;
            map.GeometryEditor.SnapBehavior = LayerSelectionMode.NoLayer;
            map.Identifier.HotTracking = false;
            map.ResizeBehavior = ResizeBehavior.KeepScale;
            map.Measuring.UndoButton = UndoShortcut.CtrlZ;
            map.ShowCoordinatesFormat = AngleFormat.Seconds;
        }

        public static void InitMapConfig()
        {
            MapConfig.ZoomToFirstLayer = true;
            MapConfig.AllowLayersWithoutProjections = true;
            MapConfig.AllowProjectionMismatch = false;
            MapConfig.ReprojectLayersOnAdding = false;
            MapConfig.OgrLayerForceUpdateMode = true;
            MapConfig.LoadSymbologyOnAddLayer = true;
            
            // It can be overridden in Grid.OpenAsImage,
            // but not proxy tricks by default
            MapConfig.GridProxyMode = GridProxyMode.NoProxy;    
        }

        public static void ApplyConfig(this IMuteMap map, IConfigService configService)
        {
            var config = configService.Config;
            MapConfig.LoadSymbologyOnAddLayer = config.LoadSymbology;

            map.ShowRedrawTime = config.ShowRedrawTime;
            map.ZoomBar.Visible = config.ShowZoombar;
            map.ScalebarVisible = config.ShowScalebar;

            map.ShowCoordinates = config.ShowCoordinates ? config.CoordinatesDisplay : CoordinatesDisplay.None;
            map.ShowCoordinatesFormat = config.CoordinateAngleFormat;

            map.InertiaOnPanning = config.InnertiaOnPanning;
            map.AnimationOnZooming = config.AnimationOnZooming;
            map.ZoomBoxStyle = config.ZoomBoxStyle;
            map.ResizeBehavior = config.ResizeBehavior;
            map.ZoomBar.Verbosity = config.ZoomBarVerbosity;
            map.ScalebarUnits = config.ScalebarUnits;
            map.ZoomBehavior = config.ZoomBehavior;

            map.BackgroundColor = config.MapBackgroundColor;

            ApplyMouseWheelDirection(map, config.MouseWheelDirection);
        }

        private static void ApplyMouseWheelDirection(this IMuteMap map, MouseWheelDirection direction)
        {
            switch (direction)
            {
                case MouseWheelDirection.Forward:
                    map.MouseWheelSpeed = 0.5;
                    break;
                case MouseWheelDirection.Reverse:
                    map.MouseWheelSpeed = 2.0;
                    break;
                case MouseWheelDirection.None:
                    map.MouseWheelSpeed = 1.0;
                    break;
            }
        }
    }
}
