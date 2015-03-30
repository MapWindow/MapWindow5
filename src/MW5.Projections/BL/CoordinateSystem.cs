using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    public class CoordinateSystem : Territory, ICoordinateSystem
    {
        /// <summary>
        /// A string describing the scope from EPSG database, typically names of countries
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// Text description of the area coordinate system applies to
        /// </summary>
        public string AreaName { get; set; }

        /// <summary>
        /// Remarks on coordinate system
        /// </summary>
        public string Remarks { get; set; }

        /// <summary>
        /// Settings name as string representation
        /// </summary>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? "not defined" : Name;
        }

        /// <summary>
        /// Proj4 string for the coordinate system
        /// </summary>
        public string Proj4 { get; set; }

        /// <summary>
        /// List of alternative proj4 formulations of the given projection
        /// </summary>
        public List<string> Dialects { get; set; }

        /// <summary>
        /// Creates a new instance of the CoordinateSystem class
        /// </summary>
        public CoordinateSystem()
        {
            Dialects = new List<string>();
        }

        /// <summary>
        /// Gets the extents where coordinate system is applicable (decimal degrees)
        /// </summary>
        public IEnvelope Extents
        {
            get
            {
                var env = new Envelope();
                env.SetBounds(Left, Right, Bottom, Top);
                return env;
            }
        }
    }
}
