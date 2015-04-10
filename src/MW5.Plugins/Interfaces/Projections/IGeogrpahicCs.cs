using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface IGeographicCs : ICoordinateSystem
    {
        /// <summary>
        /// List of projections for geographical coordinate system
        /// </summary>
        List<IProjectedCs> Projections { get; set; }

        /// <summary>
        /// The type of geogrphical coordinate system
        /// </summary>
        GeographicalCsType Type { get; set; }

        /// <summary>
        /// The code area from EPSG database
        /// </summary>
        int AreaCode { get; set; }

        /// <summary>
        /// The code of region coordinate system belongs to (for regional systems only)
        /// </summary>
        int RegionCode { get; set; }
    }
}
