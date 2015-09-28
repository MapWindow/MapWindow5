using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Interfaces.Projections
{
    public interface ICoordinateSystem : ITerritory
    {
        /// <summary>
        /// A string describing the scope from EPSG database, typically names of countries
        /// </summary>
        string Scope { get; }

        /// <summary>
        /// Text description of the area coordinate system applies to
        /// </summary>
        string AreaName { get; }

        /// <summary>
        /// Remarks on coordinate system
        /// </summary>
        string Remarks { get; }

        /// <summary>
        /// Proj4 string for the coordinate system
        /// </summary>
        string Proj4 { get; }

        /// <summary>
        /// List of alternative proj4 formulations of the given projection
        /// </summary>
        List<string> Dialects { get; }

        /// <summary>
        /// Gets the extents where coordinate system is applicable (decimal degrees)
        /// </summary>
        IEnvelope Extents { get; }

        /// <summary>
        /// Returns true if token should be filtered by particular token entered by user
        /// </summary>
        bool Filter(string token);

        /// <summary>
        /// Gets or sets ESRI name of the projected obtained by using SpatialReference.ExportToEsri.
        /// </summary>
        string EsriName { get; set; }
    }
}
