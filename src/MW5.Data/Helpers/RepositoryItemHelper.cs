// -------------------------------------------------------------------------------------------
// <copyright file="RepositoryItemHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Text;
using MW5.Api.Static;
using MW5.Data.Enums;
using MW5.Data.Repository;
using MW5.Plugins.Model;
using MW5.Shared;

namespace MW5.Data.Helpers
{
    /// <summary>
    /// Extension methods for IRepositoryItem.
    /// </summary>
    public static class RepositoryItemHelper
    {
        /// <summary>
        /// Gets the description of the item to be displayed in the UI.
        /// </summary>
        public static string GetDescription(this IRepositoryItem item)
        {
            switch (item.Type)
            {
                case RepositoryItemType.TmsSource:
                    var tmsItem = item as ITmsItem;
                    return GetDescription(tmsItem);
                case RepositoryItemType.Image:
                case RepositoryItemType.Vector:
                    var fileItem = item as IFileItem;
                    if (fileItem != null)
                    {
                        return GetDescription(fileItem.Filename);
                    }
                    break;
                case RepositoryItemType.DatabaseLayer:
                    var layerItem = item as IDatabaseLayerItem;
                    return GetDescription(layerItem);
            }

            return string.Empty;
        }

        private static string GetDescription(ITmsItem tms)
        {
            if (tms == null || tms.Provider == null) return string.Empty;

            var provider = tms.Provider;

            var sb = new StringBuilder();
            sb.AppendLine("Url: " + provider.Url);
            sb.AppendLine("Projection: " + provider.Projection);

            if (!string.IsNullOrWhiteSpace(provider.Description))
            {
                sb.AppendLine("Description: " + provider.Description);
            }

            var bounds = provider.Bounds;
            sb.AppendFormat("Latitude: {0} to {1}" + Environment.NewLine, bounds.MinY, bounds.MaxY);
            sb.AppendFormat("Longitude: {0} to {1}" + Environment.NewLine, bounds.MinX, bounds.MaxX);

            return sb.ToString();
        }

        private static string GetDescription(IDatabaseLayerItem item)
        {
            if (item == null)
            {
                return string.Empty;
            }

            var s = "Geometry type: " + item.GeometryType.EnumToString() + Environment.NewLine;
            s += "Number of features: " + item.NumFeatures + Environment.NewLine;
            s += "Projection: " + item.Projection.ExportToProj4();
            return s;
        }

        private static string GetDescription(string filename)
        {
            using (var ds = GeoSource.Open(filename))
            {
                if (ds != null)
                {
                    return ds.ToolTipText;
                }
            }

            return string.Empty;
        }
    }
}