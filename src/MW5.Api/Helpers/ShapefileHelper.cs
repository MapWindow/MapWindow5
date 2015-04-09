using System;
using System.Diagnostics;
using System.IO;
using MapWinGIS;

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
                Debug.Print("Failed to read file: " + ex.Message);   // TODO: log it
            }

            return GeometryType.None;
        }
    }
}