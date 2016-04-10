// -------------------------------------------------------------------------------------------
// <copyright file="MapInitializer.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2016
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Map;
using MW5.Api.Static;
using MW5.Data.Helpers;
using MW5.Plugins.Concrete;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Helpers
{
    public static class MapInitializer
    {
        public static void ApplyConfig(this IMuteMap map, IConfigService configService)
        {
            ApplyConfig(map, configService.Config);
        }

        public static void ApplyConfig(this IMuteMap map, AppConfig config)
        {
            Logger.Current.Trace("Start MapInitializer.ApplyConfig()");
            var mapControl = map as MapControl;
            if (mapControl != null)
            {
                mapControl.ExpandLayersOnAdding = config.LegendExpandLayersOnAdding;
            }

            MapConfig.LoadSymbologyOnAddLayer = config.LoadSymbology;
            MapConfig.ImageDownsamplingMode = config.RasterDownsamplingMode;
            MapConfig.ImageUpsamplingMode = config.RasterUpsamplingMode;

            MapConfig.GridFavorGreyscale = config.GridFavorGreyscale;
            MapConfig.DefaultColorSchemeForGrids = config.GridDefaultColorScheme;
            MapConfig.RandomColorSchemeForGrids = config.GridRandomColorScheme;
            MapConfig.GridUseHistogram = config.GridUseHistogram;
            MapConfig.BingApiKey = config.BingApiKey;
            MapConfig.WmsDiskCaching = config.WmsDiskCaching;
            MapConfig.MouseTolerance = config.MouseTolerance;
            MapConfig.OgrLayerMaxFeatureCount = config.OgrMaxFeatureCount;
            MapConfig.OgrShareDatasources = config.OgrShareConnection;

            map.ShowRedrawTime = config.ShowRedrawTime;
            map.ZoomBar.Visible = config.ShowZoombar;
            map.ScalebarVisible = config.ShowScalebar;

            map.ShowCoordinates = config.ShowCoordinates ? config.CoordinatesDisplay : CoordinatesDisplay.None;
            map.ShowCoordinatesFormat = config.CoordinateAngleFormat;

            map.ReuseTileBuffer = config.ReuseTileBuffer;
            map.InertiaOnPanning = config.InnertiaOnPanning;
            map.AnimationOnZooming = config.AnimationOnZooming;
            map.ZoomBoxStyle = config.ZoomBoxStyle;
            map.ResizeBehavior = config.ResizeBehavior;
            map.ZoomBar.Verbosity = config.ZoomBarVerbosity;
            map.ScalebarUnits = config.ScalebarUnits;
            map.ZoomBehavior = config.ZoomBehavior;

            map.Identifier.Mode = config.IdentifierMode;

            map.BackgroundColor = config.MapBackgroundColor;

            UpdateMeasuringSettings(map.Measuring.Options, config);

            UpdateShapeEditorSettings(map.GeometryEditor, config);

            ApplyMouseWheelDirection(map, config.MouseWheelDirection);

            var tiles = map.Tiles;

            tiles.GridLinesVisible = DebugHelper.DrawTilesGrid;

            ApplyTilesSettings(tiles, config);

            ApplyTilesProxy(tiles, config);
            Logger.Current.Trace("End MapInitializer.ApplyConfig()");
        }

        public static void Initialize(this IMap map)
        {
            map.GrabProjectionFromData = true;
            map.MapCursor = MapCursor.ZoomIn;
            map.InertiaOnPanning = AutoToggle.Auto;
            map.ShowRedrawTime = false;
            map.Identifier.Mode = IdentifierMode.CurrentLayer;
            map.Identifier.HotTracking = true;
            map.GeometryEditor.HighlightVertices = LayerSelectionMode.NoLayer;
            map.GeometryEditor.SnapBehavior = LayerSelectionMode.NoLayer;
            map.Identifier.HotTracking = false;
            map.ResizeBehavior = ResizeBehavior.KeepScale;
            map.Measuring.UndoButton = UndoShortcut.CtrlZ;
            map.ShowCoordinatesFormat = AngleFormat.Seconds;
            map.ExtentHistory = 200;
        }

        public static void InitMapConfig()
        {
            Logger.Current.Trace("Start InitMapConfig");
            MapConfig.ZoomToFirstLayer = true;
            MapConfig.AllowLayersWithoutProjections = true;
            MapConfig.OverrideLocalCallback = true;

            // mismatch test logic is on the client side, so ocx must not interfere with it
            MapConfig.AllowProjectionMismatch = true;
            MapConfig.ReprojectLayersOnAdding = false;
            MapConfig.OgrLayerForceUpdateMode = true;
            MapConfig.LoadSymbologyOnAddLayer = true;
            MapConfig.CacheDbfRecords = false;
            MapConfig.CallbackVerbosity = CallbackVerbosity.Limited;

            // It can be overridden in Grid.OpenAsImage,
            // but not proxy tricks by default
            MapConfig.GridProxyMode = GridProxyMode.NoProxy;
            Logger.Current.Trace("End InitMapConfig");
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
                // case MouseWheelDirection.None:
                default:
                    map.MouseWheelSpeed = 1.0;
                    break;
            }
        }

        private static void ApplyTilesProxy(this TileManager tiles, AppConfig config)
        {
            if (config.TilesUseProxy)
            {
                if (config.TilesAutoDetectProxy)
                {
                    tiles.AutodetectProxy();
                }
                else
                {
                    var parts = config.TilesProxyAddress.Split(':');
                    if (parts.Length == 2)
                    {
                        int port;
                        if (int.TryParse(parts[1], out port))
                        {
                            tiles.SetProxy(parts[0], port);
                        }
                    }
                }

                tiles.SetProxyAuthentication(config.TilesProxyUserName, config.TilesProxyPassword, string.Empty);
            }
            else
            {
                tiles.SetProxy(string.Empty, 80);
                tiles.ClearProxyAuthorization();
            }
        }

        private static void ApplyTilesSettings(this TileManager tiles, AppConfig config)
        {
            tiles.set_MaxCacheSize(CacheType.Disk, config.TilesMaxDiskSize);
            tiles.set_MaxCacheSize(CacheType.Ram, config.TilesMaxRamSize);
            tiles.DiskCacheFilename = config.TilesDatabase;
            tiles.set_IsCaching(CacheType.Disk, config.TilesUseDiskCache);
            tiles.set_IsCaching(CacheType.Ram, config.TilesUseRamCache);

            TileCacheHelper.InitDatabase(config.TilesDatabase, config.TilesMaxDiskAge);
        }

        private static void UpdateMeasuringSettings(IMeasuringSettings measuring, AppConfig config)
        {
            measuring.AngleFormat = config.MeasuringAngleFormat;
            measuring.AnglePrecision = config.MeasuringAnglePrecision;
            measuring.AreaPrecision = config.MeasuringAreaPrecision;
            measuring.AreaUnits = config.MeasuringAreaUnits;
            measuring.BearingType = config.MeasuringBearingType;
            measuring.FillColor = config.MeasuringFillColor;
            measuring.FillTransparency = config.MeasuringFillTransparency;
            measuring.LengthPrecision = config.MeasuringLengthPrecision;
            measuring.LengthUnits = config.MeasuringLengthUnits;
            measuring.LineColor = config.MeasuringLineColor;
            measuring.LineStyle = config.MeasuringLineStyle;
            measuring.LineWidth = config.MeasuringLineWidth;
            measuring.PointLabelsVisible = config.MeasuringPointLabelsVisible;
            measuring.PointsVisible = config.MeasuringPointsVisible;
            measuring.ShowBearing = config.MeasuringShowBearing;
            measuring.ShowLength = config.MeasuringShowLength;
            measuring.ShowTotalLength = config.MeasuringShowTotalLength;
        }

        private static void UpdateShapeEditorSettings(IGeometryEditor editor, AppConfig config)
        {
            Logger.Current.Trace("Start UpdateShapeEditorSettings");
            var settings = editor.Settings;

            editor.ShowArea = config.ShapeEditorShowArea;

            settings.PointLabelsVisible = config.ShapeEditorShowLabels;
            settings.ShowBearing = config.ShapeEditorShowBearing;
            settings.BearingType = config.ShapeEditorBearingType;
            settings.AnglePrecision = config.ShapeEditorBearingPrecision;
            settings.AngleFormat = config.ShapeEditorAngleFormat;
            settings.ShowLength = config.ShapeEditorShowLength;
            settings.AreaUnits = config.ShapeEditorUnits == LengthDisplay.Metric
                                     ? AreaDisplay.Metric
                                     : AreaDisplay.American;
            settings.LengthUnits = config.ShapeEditorUnits == LengthDisplay.Metric
                                       ? LengthDisplay.Metric
                                       : LengthDisplay.American;
            settings.LengthPrecision = config.ShapeEditorUnitPrecision;
            settings.AreaPrecision = config.ShapeEditorUnitPrecision;
            Logger.Current.Trace("End UpdateShapeEditorSettings");
        }
    }
}