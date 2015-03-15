using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.UI.Helpers;

namespace MW5.Services.Helpers
{
    public static class EnumConverters
    {
        public static void Init()
        {
            // TODO: perphaps register all implementation automatically via reflection
            EnumHelper.RegisterConverter(new GeometryTypeConverter());
            EnumHelper.RegisterConverter(new SaveResultConverter());
            EnumHelper.RegisterConverter(new TileProviderConverter());
        }
    }

    public class TileProviderConverter : IEnumConverter<TileProvider>
    {
        public string GetString(TileProvider enumeration)
        {
            switch (enumeration)
            {
                case TileProvider.None:
                    return "None";
                case TileProvider.OpenStreetMap:
                    return "OpenStreetMap";
                case TileProvider.OpenCycleMap:
                    return "OpenCycleMap";
                case TileProvider.OpenTransportMap:
                    return "OpenTransportMap";
                case TileProvider.BingMaps:
                    return "Bing Maps";
                case TileProvider.BingSatellite:
                    return "Bing Satellite";
                case TileProvider.BingHybrid:
                    return "Bing Hybrid";
                case TileProvider.GoogleMaps:
                    return "Google Map";
                case TileProvider.GoogleSatellite:
                    return "Google Satellite";
                case TileProvider.GoogleHybrid:
                    return "Google Hybrid";
                case TileProvider.GoogleTerrain:
                    return "Google Terrain";
                case TileProvider.HereMaps:
                    return "Here Maps";
                case TileProvider.HereSatellite:
                    return "Here Satellite";
                case TileProvider.HereHybrid:
                    return "Here Hybrid";
                case TileProvider.HereTerrain:
                    return "Here Terrain";
                case TileProvider.Rosreestr:
                    return "Rosreestr";
                case TileProvider.OpenHumanitarianMap:
                    return "OpenHumanitarianMap";
                case TileProvider.MapQuestAerial:
                    return "MapQuest Aerial";
                case TileProvider.ProviderCustom:
                    return "Custom Provider";
            }
            return "Not defined";
        }
    }

    public class GeometryTypeConverter : IEnumConverter<GeometryType>
    {
        public string GetString(GeometryType enumeration)
        {
            switch (enumeration)
            {
                case GeometryType.Point:
                    return "Point";
                case GeometryType.Polyline:
                    return "Polyline";
                case GeometryType.Polygon:
                    return "Polygon";
                case GeometryType.MultiPoint:
                    return "Multipoint";
            }
            return "Not defined";
        }
    }

    public class SaveResultConverter : IEnumConverter<SaveResult>
    {
        public string GetString(SaveResult enumeration)
        {
            switch (enumeration)
            {
                case SaveResult.NoChanges:
                    return "OGR layer has no changes";
                case SaveResult.AllSaved:
                    return "All changes saved";
                case SaveResult.SomeSaved:
                    return "Some changes saved";
                case SaveResult.NoneSaved:
                    return "Changes aren't saved";
            }
            return "";
        }
    }
}
