using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface IRegion
    {
        /// <summary>
        /// The name of the region
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The code of the region
        /// </summary>
        int Code { get; set; }

        /// <summary>
        /// The code of the parent region
        /// </summary>
        int ParentCode { get; set; }

        /// <summary>
        /// The list of countries belonging to the region
        /// </summary>
        List<ICountry> Countries { get; set; }
    }
}
