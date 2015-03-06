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
