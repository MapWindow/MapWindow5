using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Api.Helpers
{
    public static class GdalHelper
    {
        /// <summary>
        /// Gets the list of supported GDAL raster data types.
        /// </summary>
        public static IList<string> GetRasterDataTypes()
        {
            return new List<string>()
            {
                "Byte",
                "Int16",
                "UInt16",
                "UInt32",
                "Int32",
                "Float32",
                "Float64",
                "CInt16",
                "CInt32",
                "CFloat32",
                "CFloat64"
            };
        }
    }
}
