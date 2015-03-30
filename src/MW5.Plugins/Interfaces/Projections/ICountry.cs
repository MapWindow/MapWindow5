using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface ICountry: ITerritory
    {
        /// <summary>
        /// A code of region, the country belong to
        /// </summary>
        int RegionCode { get; set; }

        /// <summary>
        /// List of Geographical coordinate systems for the country
        /// </summary>
        List<IGeographicCs> GeographicCs { get; }

        /// <summary>
        /// EPSG codes of projetcted coordinate systems for the region (references can be obtained through GCS list)
        /// </summary>
        List<int> ProjectedCs { get; }
    }
}
