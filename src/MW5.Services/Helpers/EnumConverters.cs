using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Shared;

namespace MW5.Services.Helpers
{
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

    public class InterpolationTypeConverter : IEnumConverter<InterpolationType>
    {
        public string GetString(InterpolationType value)
        {
            switch (value)
            {
                case InterpolationType.Bilinear:
                    return "Bilinear";
                case InterpolationType.Bicubic:
                    return "Bicubic";
                case InterpolationType.None:
                    return "None";
                case InterpolationType.HighQualityBilinear:
                    return "High quality bilinear";
                case InterpolationType.HighQualityBicubic:
                    return "High quality bicubic";
            }
            return "";
        }
    }

    public class RasterOverviewTypeConverter: IEnumConverter<RasterOverviewType>
    {
        public string GetString(RasterOverviewType value)
        {
            switch (value)
            {
                case RasterOverviewType.External:
                    return "External file";
                case RasterOverviewType.Internal:
                    return "Internal";
            }
            return "";
        }
    }

    public class RasterOverviewSamplingConverter: IEnumConverter<RasterOverviewSampling>
    {
        public string GetString(RasterOverviewSampling value)
        {
            switch (value)
            {
                case RasterOverviewSampling.None:
                    return "None";
                case RasterOverviewSampling.Nearest:
                    return "Nearest neighbour";
                case RasterOverviewSampling.Gauss:
                    return "Gauss";
                case RasterOverviewSampling.Bicubic:
                    return "Bicubic";
                case RasterOverviewSampling.Average:
                    return "Average";
            }
            return "";
        }
    }

    public class DynamicVisiblityModeConverter : IEnumConverter<DynamicVisibilityMode>
    {
        public string GetString(DynamicVisibilityMode value)
        {
            switch (value)
            {
                case DynamicVisibilityMode.Scale:
                    return "Map scales";
                case DynamicVisibilityMode.Zoom:
                    return "Zoom levels";
            }
            return "";
        }
    }

    public class AreaUnitsConverter : IEnumConverter<AreaUnits>
    {
        public string GetString(AreaUnits value)
        {
            switch (value)
            {
                case AreaUnits.SquareFeet:
                    return "Square feet";
                case AreaUnits.SquareYards:
                    return "Square yards";
                case AreaUnits.SquareMeters:
                    return "Square meters";
                case AreaUnits.SquareMiles:
                    return "Square miles";
                case AreaUnits.SquareKilometers:
                    return "Square kilometers";
                case AreaUnits.Hectares:
                    return "Hectars";
                case AreaUnits.Acres:
                    return "Acreas";
            }

            return string.Empty;
        }
    }
}
