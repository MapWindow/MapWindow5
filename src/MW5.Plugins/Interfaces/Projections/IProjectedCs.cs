using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface IProjectedCs : ICoordinateSystem
    {
        /// <summary>
        /// EPSG code of source geographic coordinate system
        /// </summary>
        int SourceCode { get; set; }

        /// <summary>
        /// The type of projection (custom clasification for particular systems)
        /// </summary>
        string ProjectionType { get; set; }

        /// <summary>
        /// Units of measure
        /// </summary>
        int Units { get; set; }

        /// <summary>
        /// Marks local projection, that should be shown under country node only
        /// </summary>
        bool Local { get; set; }
    }
}
