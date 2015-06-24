using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.UI.Controls;

namespace MW5.Plugins.Symbology.Helpers
{
    public static class VectorInfoHelper
    {
        public static NodeData GetFeatureSetInfo(IFeatureSet featureSet)
        {
            var ext = featureSet.Envelope;
            string type = featureSet.GeometryType.ToString();

            var root = new NodeData("Vector layer");

            root.AddSubItem("Type", type);
            root.AddSubItem("Number of features", featureSet.NumFeatures);
            root.AddSubItem("Selected", featureSet.NumSelected);
            root.AddSubItem("Source", featureSet.Filename);
            root.AddSubItem("Bounds X", String.Format("{0:F2}", ext.MaxX) + " to " + String.Format("{0:F2}", ext.MaxX));
            root.AddSubItem("Bounds Y", String.Format("{0:F2}", ext.MinY) + " to " + String.Format("{0:F2}", ext.MaxY));
            root.AddSubItem("Projection", featureSet.Projection.ExportToProj4());

            return root;
        }

        public static NodeData GetVectorLayerInfo(IVectorLayer ogr)
        {
            if (ogr == null)
            {
                return new NodeData("Datasource type", "ESRI Shapefile");
            }

            var root = new NodeData("OGR datasource");
            root.AddSubItem("Datasource type", "OGR layer");
            root.AddSubItem("Driver name", ogr.DriverName);
            root.AddSubItem("Connection string", ogr.ConnectionString);
            root.AddSubItem("Layer type", ogr.SourceType.ToString());
            root.AddSubItem("Name or query", ogr.SourceQuery);
            root.AddSubItem("Supports editing", ogr.get_SupportsEditing(SaveType.SaveAll).ToString());
            root.AddSubItem("Dynamic loading", ogr.DynamicLoading.ToString());

            return root;
        }
    }
}
