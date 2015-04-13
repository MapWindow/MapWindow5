using System;
using System.Diagnostics;
using System.IO;
using MapWinGIS;
using MW5.Api.Enums;
using MW5.Shared;
using MW5.Shared.Log;

namespace MW5.Api.Helpers
{
    public static class ShapefileHelper
    {
        public static string ErrorMessage(this Shapefile sf)
        {
            return sf.ErrorMsg[sf.LastErrorCode];
        }

        public static GeometryType GetGeometryType(string filename)
        {
            try
            {
                using (var stream = new FileStream(filename, FileMode.Open))
                {
                    using (var reader = new BinaryReader(stream))
                    {
                        stream.Position = 32;
                        int val = reader.ReadInt32();
                        var shpType = (ShpfileType) val;
                        return GeometryHelper.ShapeType2GeometryType(shpType);
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to read file", ex);
            }

            return GeometryType.None;
        }
    }
}