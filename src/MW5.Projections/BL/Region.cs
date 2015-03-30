using System.Collections.Generic;
using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    /// <summary>
    /// Structure to hold information about region
    /// </summary>
    public class Region : IRegion
    {
        public Region()
        {
            Countries = new List<ICountry>();
        }

        /// <summary>
        /// The name of the region
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The code of the region
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The code of the parent region
        /// </summary>
        public int ParentCode { get; set; }

        /// <summary>
        /// The list of countries belonging to the region
        /// </summary>
        public List<ICountry> Countries { get; set; }
    }
}
