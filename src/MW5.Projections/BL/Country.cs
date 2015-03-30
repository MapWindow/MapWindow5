using System.Collections.Generic;
using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    /// <summary>
    /// Structure to hold information about country
    /// </summary>
    public class Country : Territory, ICountry
    {
        /// <summary>
        /// A code of region, the country belong to
        /// </summary>
        public int RegionCode { get; set; }

        /// <summary>
        /// List of Geographical coordinate systems for the country
        /// </summary>
        public List<IGeographicCs> GeographicCs { get; set; }
        
        /// <summary>
        /// EPSG codes of projetcted coordinate systems for the region (references can be obtained through GCS list)
        /// </summary>
        public List<int> ProjectedCs { get; set; }
    }
}
