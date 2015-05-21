using System.Collections.Generic;
using System.Xml.Serialization;

namespace MW5.Services.Serialization.Legacy
{
   [XmlRoot("Mapwin")]
   public class MapWin4Project
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }

        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }

        [XmlAttribute(AttributeName = "version")]
        public string Version { get; set; }

        [XmlElement(ElementName = "MapWinGIS")]
        public MapWinGIS MapwinGis { get; set; }

        [XmlElement(ElementName = "MapWindow4")]
        public MapWindow4 MapWindow { get; set; }

        public class MapWindow4
        {
            [XmlAttribute(AttributeName = "ConfigurationPath")]
            public string ConfigurationPath { get; set; }

            [XmlAttribute(AttributeName = "ProjectProjection")]
            public string ProjectProjection { get; set; }

            [XmlAttribute(AttributeName = "MapUnits")]
            public string MapUnits { get; set; }

            [XmlAttribute(AttributeName = "StatusBarAlternateCoordsNumDecimals")]
            public string StatusBarAlternateCoordsNumDecimals { get; set; }

            [XmlAttribute(AttributeName = "StatusBarCoordsNumDecimals")]
            public string StatusBarCoordsNumDecimals { get; set; }

            [XmlAttribute(AttributeName = "StatusBarAlternateCoordsUseCommas")]
            public string StatusBarAlternateCoordsUseCommas { get; set; }


            [XmlAttribute(AttributeName = "StatusBarCoordsUseCommas")]
            public string StatusBarCoordsUseCommas { get; set; }

            [XmlAttribute(AttributeName = "ShowFloatingScaleBar")]
            public string ShowFloatingScaleBar { get; set; }

            [XmlAttribute(AttributeName = "FloatingScaleBarPosition")]
            public string FloatingScaleBarPosition { get; set; }

            [XmlAttribute(AttributeName = "FloatingScaleBarUnit")]
            public string FloatingScaleBarUnit { get; set; }

            [XmlAttribute(AttributeName = "FloatingScaleBarForecolor")]
            public string FloatingScaleBarForecolor { get; set; }

            [XmlAttribute(AttributeName = "FloatingScaleBarBackcolor")]
            public string FloatingScaleBarBackcolor { get; set; }

            [XmlAttribute(AttributeName = "MapResizeBehavior")]
            public string MapResizeBehavior { get; set; }

            [XmlAttribute(AttributeName = "ShowStatusBarCoords_Projected")]
            public string ShowStatusBarCoords_Projected { get; set; }

            [XmlAttribute(AttributeName = "ShowStatusBarCoords_Alternate")]
            public string ShowStatusBarCoords_Alternate { get; set; }


            [XmlAttribute(AttributeName = "SaveShapeSettings")]
            public string SaveShapeSettings { get; set; }

            [XmlAttribute(AttributeName = "ViewBackColor_UseDefault")]
            public string ViewBackColor_UseDefault { get; set; }

            [XmlAttribute(AttributeName = "ViewBackColor")]
            public string ViewBackColor { get; set; }

            [XmlAttribute(AttributeName = "ProjectProjectionWKT")]
            public string ProjectProjectionWKT { get; set; }

            [XmlArray]
            [XmlArrayItem(ElementName = "Plugin")]
            public List<Plugin> Plugins { get; set; }

            [XmlElement(ElementName = "ApplicationPlugins")]
            public ApplicationPlugins ApplicationPlugins { get; set; }

            [XmlElement(ElementName = "Bookmarks")]
            public string Bookmark { get; set; }

            [XmlElement(ElementName = "PreviewMap")]
            public Previewmap PreviewMap { get; set; }

            [XmlElement(ElementName = "Image")]
            public ImageType Image { get; set; }

            [XmlArray]
            [XmlArrayItem(ElementName = "Group")]
            public List<Group> Groups { get; set; }

            [XmlArray]
            [XmlArrayItem(ElementName = "Layer")]
            public List<LayerMapWin4> Layers { get; set; }
        }

        public class LayerMapWin4
        {
            [XmlAttribute(AttributeName = "Name")]
            public string Name { get; set; }

            [XmlAttribute(AttributeName = "Tag")]
            public string Tag { get; set; }

            [XmlAttribute(AttributeName = "Expanded")]
            public string Expanded { get; set; }

            [XmlAttribute(AttributeName = "Handle")]
            public string Handle { get; set; }

            [XmlAttribute(AttributeName = "PositionInGroup")]
            public string PositionInGroup { get; set; }

            [XmlAttribute(AttributeName = "GroupIndex")]
            public string GroupIndex { get; set; }

            [XmlAttribute(AttributeName = "GroupName")]
            public string GroupName { get; set; }
        }

        public class Group
        {
            [XmlAttribute(AttributeName = "Name")]
            public string Name { get; set; }

            [XmlAttribute(AttributeName = "Expanded")]
            public string Expanded { get; set; }

            [XmlAttribute(AttributeName = "Position")]
            public string Position { get; set; }

            [XmlElement(ElementName = "Image")]
            public ImageType Image { get; set; }
        }

        public class ImageType
        {
            [XmlAttribute(AttributeName = "Type")]
            public string Type { get; set; }

            [XmlText]
            public string Value { get; set; }
        }

        public class Previewmap
        {
            [XmlAttribute(AttributeName = "dx")]
            public string dx { get; set; }

            [XmlAttribute(AttributeName = "dy")]
            public string dy { get; set; }

            [XmlAttribute(AttributeName = "xllcenter")]
            public string xllcenter { get; set; }

            [XmlAttribute(AttributeName = "yllcenter")]
            public string yllcenter { get; set; }

            [XmlElement(ElementName = "Image")]
            public ImageType Image { get; set; }

        }


        public class ApplicationPlugins
        {
            [XmlAttribute(AttributeName = "PluginDir")]
            public string PluginDir { get; set; }

            [XmlElement(ElementName = "Plugin")]
            public List<Plugin> Plugins { get; set; }
        }

        public class Plugin
        {
            [XmlAttribute(AttributeName = "SettingsString")]
            public string SettingsString { get; set; }

            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }

        }
        public class MapWinGIS
        {
            [XmlAttribute(AttributeName = "OcxVersion")]
            public string OcxVersion { get; set; }

            [XmlAttribute(AttributeName = "FileType")]
            public string FileType { get; set; }

            [XmlAttribute(AttributeName = "FileVersion")]
            public string FileVersion { get; set; }

            [XmlElement(ElementName = "MapState")]
            public MapState Mapstate { get; set; }

            [XmlArray]
            [XmlArrayItem(ElementName = "Layer")]
            public List<Layer> Layers { get; set; }

        }

        public class Layer
        {
            [XmlAttribute(AttributeName = "LayerType")]
            public string LayerType { get; set; }

            [XmlAttribute(AttributeName = "LayerName")]
            public string LayerName { get; set; }

            [XmlAttribute(AttributeName = "LayerVisible")]
            public string LayerVisible { get; set; }

            [XmlAttribute(AttributeName = "LayerKey")]
            public string LayerKey { get; set; }

            [XmlAttribute(AttributeName = "DynamicVisibility")]
            public string DynamicVisibility { get; set; }

            [XmlAttribute(AttributeName = "MinVisibleScale")]
            public string MinVisibleScale { get; set; }

            [XmlAttribute(AttributeName = "MaxVisibleScale")]
            public string MaxVisibleScale { get; set; }

            [XmlAttribute(AttributeName = "Filename")]
            public string Filename { get; set; }

            [XmlElement(ElementName = "ImageClass")]
            public ImageClass Image { get; set; }

            [XmlElement(ElementName = "ShapefileClass")]
            public ShapefileClass ShapeFile { get; set; }
        }

        public class ShapefileClass
        {
            [XmlElement(ElementName = "DefaultDrawingOptions")]
            public DefaultDrawingOptions DefaultDrawing { get; set; }

            [XmlElement(ElementName = "ShapefileCategoriesClass")]
            public ShapefileCategoriesClass ShapefileCategories { get; set; }

            [XmlElement(ElementName = "LabelsClass")]
            public LabelsClass Labels { get; set; }

            [XmlElement(ElementName = "ChartsClass")]
            public ChartClass Chart { get; set; }
        }

        public class ChartClass
        {
            [XmlAttribute(AttributeName = "ValuesFontName")]
            public string ValuesFontName { get; set; }

            [XmlAttribute(AttributeName = "Visible")]
            public string Visible { get; set; }
        }

        public class LabelsClass
        {
            [XmlAttribute(AttributeName = "Alignment")]
            public string Alignment { get; set; }

            [XmlAttribute(AttributeName = "FontColor")]
            public string FontColor { get; set; }

            [XmlAttribute(AttributeName = "FontName")]
            public string FontName { get; set; }

            [XmlAttribute(AttributeName = "HaloColor")]
            public string HaloColor { get; set; }



            [XmlAttribute(AttributeName = "HaloVisible")]
            public string HaloVisible { get; set; }

            [XmlAttribute(AttributeName = "OffsetY")]
            public string OffsetY { get; set; }

            [XmlAttribute(AttributeName = "ShadowVisible")]
            public string ShadowVisible { get; set; }

            [XmlAttribute(AttributeName = "FrameBackColor")]
            public string FrameBackColor { get; set; }

            [XmlAttribute(AttributeName = "FrameBackColor2")]
            public string FrameBackColor2 { get; set; }

            [XmlAttribute(AttributeName = "FrameGradientMode")]
            public string FrameGradientMode { get; set; }

            [XmlAttribute(AttributeName = "FrameVisible")]
            public string FrameVisible { get; set; }

            [XmlAttribute(AttributeName = "Generated")]
            public string Generated { get; set; }

            [XmlAttribute(AttributeName = "MaxVisibleScale")]
            public string MaxVisibleScale { get; set; }

            [XmlAttribute(AttributeName = "AutoOffset")]
            public string AutoOffset { get; set; }

            [XmlAttribute(AttributeName = "DynamicVisibility")]
            public string DynamicVisibility { get; set; }

            [XmlAttribute(AttributeName = "AvoidCollisions")]
            public string AvoidCollisions { get; set; }

            [XmlAttribute(AttributeName = "Positioning")]
            public string Positioning { get; set; }

            [XmlAttribute(AttributeName = "Expression")]
            public string Expression { get; set; }
        }

        public class ShapefileCategoriesClass
        {

        }

        public class DefaultDrawingOptions
        {
            [XmlAttribute(AttributeName = "FillBgColor")]
            public string FillBgColor { get; set; }

            [XmlAttribute(AttributeName = "FillBgTransparent")]
            public string FillBgTransparent { get; set; }

            [XmlAttribute(AttributeName = "FillColor")]
            public string FillColor { get; set; }

            [XmlAttribute(AttributeName = "FontName")]
            public string FontName { get; set; }

            [XmlAttribute(AttributeName = "FillColor2")]
            public string FillColor2 { get; set; }

            [XmlAttribute(AttributeName = "FillGradientBounds")]
            public string FillGradientBounds { get; set; }

            [XmlAttribute(AttributeName = "FillGradientType")]
            public string FillGradientType { get; set; }

            [XmlAttribute(AttributeName = "FillVisible")]
            public string FillVisible { get; set; }

            [XmlAttribute(AttributeName = "FillHatchStyle")]
            public string FillHatchStyle { get; set; }

            [XmlAttribute(AttributeName = "FillTransparency")]
            public string FillTransparency { get; set; }

            [XmlAttribute(AttributeName = "FillType")]
            public string FillType { get; set; }

            [XmlAttribute(AttributeName = "LineColor")]
            public string LineColor { get; set; }

            [XmlAttribute(AttributeName = "PointCharcter")]
            public string PointCharcter { get; set; }

            [XmlAttribute(AttributeName = "PointNumSides")]
            public string PointNumSides { get; set; }

            [XmlAttribute(AttributeName = "PointShapeRatio")]
            public string PointShapeRatio { get; set; }

            [XmlAttribute(AttributeName = "PointShapeType")]
            public string PointShapeType { get; set; }

            [XmlAttribute(AttributeName = "PointSize")]
            public string PointSize { get; set; }

            [XmlAttribute(AttributeName = "PointSymbolType")]
            public string PointSymbolType { get; set; }

            [XmlAttribute(AttributeName = "ScaleX")]
            public string ScaleX { get; set; }

            [XmlAttribute(AttributeName = "ScaleY")]
            public string ScaleY { get; set; }

            [XmlElement(ElementName = "LinePatternClass")]
            public LinePatternClass LinePattern { get; set; }
        }

        public class LinePatternClass
        {
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }

            [XmlAttribute(AttributeName = "Transparency")]
            public string Transparency { get; set; }

            [XmlArray]
            [XmlArrayItem(ElementName = "LineSegmentClass")]
            public List<LineSegmentClass> LineSegments { get; set; }
        }

        public class LineSegmentClass
        {
            [XmlAttribute(AttributeName = "LineType")]
            public string LineType { get; set; }

            [XmlAttribute(AttributeName = "Color")]
            public string Color { get; set; }

            [XmlAttribute(AttributeName = "MarkerOutlineColor")]
            public string MarkerOutlineColor { get; set; }

            [XmlAttribute(AttributeName = "LineWidth")]
            public string LineWidth { get; set; }

            [XmlAttribute(AttributeName = "MarkerSize")]
            public string MarkerSize { get; set; }

            [XmlAttribute(AttributeName = "MarkerInterval")]
            public string MarkerInterval { get; set; }

            [XmlAttribute(AttributeName = "MarkerOffset")]
            public string MarkerOffset { get; set; }

            [XmlAttribute(AttributeName = "LineStyle")]
            public string LineStyle { get; set; }

            [XmlAttribute(AttributeName = "Marker")]
            public string Marker { get; set; }

            [XmlAttribute(AttributeName = "MarkerOrientation")]
            public string MarkerOrientation { get; set; }

            [XmlAttribute(AttributeName = "MarkerFlipFirst")]
            public string MarkerFlipFirst { get; set; }
        }

        public class ImageClass
        {
            [XmlAttribute(AttributeName = "Key")]
            public string Key { get; set; }

            [XmlAttribute(AttributeName = "SetToGrey")]
            public string SetToGrey { get; set; }

            [XmlAttribute(AttributeName = "TransparencyColor")]
            public string TransparencyColor { get; set; }

            [XmlAttribute(AttributeName = "TransparencyColor2")]
            public string TransparencyColor2 { get; set; }

            [XmlAttribute(AttributeName = "UseTransparencyColor")]
            public string UseTransparencyColor { get; set; }

            [XmlAttribute(AttributeName = "TransparencyPercent")]
            public string TransparencyPercent { get; set; }

            [XmlAttribute(AttributeName = "DownsamplingMode")]
            public string DownsamplingMode { get; set; }

            [XmlAttribute(AttributeName = "UpsamplingMode")]
            public string UpsamplingMode { get; set; }

            [XmlElement(ElementName = "LabelsClass")]
            public LabelClass Label { get; set; }
        }

        public class LabelClass
        {
            [XmlAttribute(AttributeName = "Generated")]
            public string Generated { get; set; }

            [XmlAttribute(AttributeName = "AutoOffset")]
            public string AutoOffset { get; set; }

            [XmlAttribute(AttributeName = "AvoidCollisions")]
            public string AvoidCollisions { get; set; }
        }

        public class MapState
        {
            [XmlAttribute(AttributeName = "SendMouseMove")]
            public string SendMouseMove { get; set; }

            [XmlAttribute(AttributeName = "SendMouseDown")]
            public string SendMouseDown { get; set; }

            [XmlAttribute(AttributeName = "SendMouseUp")]
            public string SendMouseUp { get; set; }

            [XmlAttribute(AttributeName = "SendSelectBoxFinal")]
            public string SendSelectBoxFinal { get; set; }

            [XmlAttribute(AttributeName = "CursorMode")]
            public string CursorMode { get; set; }

            [XmlAttribute(AttributeName = "TrapRightMouseDown")]
            public string TrapRightMouseDown { get; set; }

            [XmlAttribute(AttributeName = "ExtentsLeft")]
            public string ExtentsLeft { get; set; }

            [XmlAttribute(AttributeName = "ExtentsRight")]
            public string ExtentsRight { get; set; }

            [XmlAttribute(AttributeName = "ExtentsBottom")]
            public string ExtentsBottom { get; set; }

            [XmlAttribute(AttributeName = "ExtentsTop")]
            public string ExtentsTop { get; set; }

            [XmlAttribute(AttributeName = "ExtentsPad")]
            public string ExtentsPad { get; set; }
        }
    }
}
