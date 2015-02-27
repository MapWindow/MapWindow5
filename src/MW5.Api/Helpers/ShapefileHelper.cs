using MapWinGIS;

namespace MW5.Api.Helpers
{
    public static class ShapefileHelper
    {
        public static string ErrorMessage(this Shapefile sf)
        {
            return sf.ErrorMsg[sf.LastErrorCode];
        }
    }
}