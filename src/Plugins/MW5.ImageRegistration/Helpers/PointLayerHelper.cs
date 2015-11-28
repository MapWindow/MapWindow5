using System.Drawing;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.ImageRegistration.Helpers
{
    internal static class PointLayerHelper
    {
        /// <summary>
        /// Creates a shapefile with points
        /// </summary>
        public static IFeatureSet CreatePointLayer()
        {
            var fs = new FeatureSet(GeometryType.Point) { Volatile = true };

            fs.Fields.Add("Number", AttributeType.Integer, 10, 10);

            var sdo = fs.Style;

            var marker = sdo.Marker;
            marker.Type = MarkerType.Vector;
            marker.Size = 24;
            marker.SetVectorMarker(VectorMarker.Cross);
            marker.VectorMarkerSideRatio = 1.0f / 12.0f;
            marker.Rotation = 45.0f;

            sdo.Fill.Color = Color.Red;
            sdo.Line.Visible = false;

            var labelStyle = fs.Labels.Style;
            labelStyle.FontSize = 16;
            labelStyle.FontColor = Color.Red;
            labelStyle.FontBold = true;

            fs.Labels.VerticalPosition = VerticalPosition.AboveAllLayers;
            fs.Labels.AvoidCollisions = false;

            var ct = fs.Categories.Add("hidden");
            ct.Style.Visible = false;

            fs.CollisionMode = CollisionMode.AllowCollisions;

            return fs;
        }
    }
}
