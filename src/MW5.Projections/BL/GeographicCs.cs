using System.Collections;
using System.Collections.Generic;
using MW5.Plugins;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    /// <summary>
    /// Structure to hold information about GCS
    /// </summary>
    public class GeographicCs : CoordinateSystem, IGeographicCs
    {
        private Hashtable _dctProjections = null;

        public GeographicCs()
        {
            Projections = new List<IProjectedCs>();
        }

        /// <summary>
        /// List of projections for geographical coordinate system
        /// </summary>
        public List<IProjectedCs> Projections { get; set; }

        /// <summary>
        /// The type of geogrphical coordinate system
        /// </summary>
        public GeographicalCsType Type { get; set; }

        /// <summary>
        /// The code area from EPSG database
        /// </summary>
        public int AreaCode { get; set; }

        /// <summary>
        /// The code of region coordinate system belongs to (for regional systems only)
        /// </summary>
        public int RegionCode { get; set; }

        /// <summary>
        /// Fast search for projection by it's code (hashtable)
        /// </summary>
        /// <param name="pcsCode"></param>
        public ProjectedCs ProjectionByCode(int pcsCode)
        {
            if (_dctProjections == null)
            {
                _dctProjections = new Hashtable();
                foreach (IProjectedCs pcs in Projections)
                {
                    _dctProjections.Add(pcs.Code, pcs);
                }
            }

            if (_dctProjections.ContainsKey(pcsCode))
            {
                return (ProjectedCs) _dctProjections[pcsCode];
            }

            return null;
        }
    }
}
