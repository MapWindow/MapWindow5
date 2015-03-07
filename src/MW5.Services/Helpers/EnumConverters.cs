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
                    return "Open street map";
                case TileProvider.OpenCycleMap:
                    return "Open cycle map";
                case TileProvider.OpenTransportMap:
                    return "Open transport map";
                case TileProvider.BingMaps:
                    return "Bing maps";
                case TileProvider.BingSatellite:
                    return "Bing satellite";
                case TileProvider.BingHybrid:
                    return "Bing hybrid";
                case TileProvider.GoogleMaps:
                    return "Google map";
                case TileProvider.GoogleSatellite:
                    return "Google satellite";
                case TileProvider.GoogleHybrid:
                    return "Google hybrid";
                case TileProvider.GoogleTerrain:
                    return "Google terrain";
                case TileProvider.HereMaps:
                    return "Here maps";
                case TileProvider.HereSatellite:
                    return "Here satellite";
                case TileProvider.HereHybrid:
                    return "Here hybrid";
                case TileProvider.HereTerrain:
                    return "Here terrain";
                case TileProvider.Rosreestr:
                    return "Rosreestr";
                case TileProvider.OpenHumanitarianMap:
                    return "Open humanitarian map";
                case TileProvider.MapQuestAerial:
                    return "MapQuest aerial";
                case TileProvider.ProviderCustom:
                    return "Custom provider";
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
