using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    /// <summary>
    /// Structure to hold information about PCS
    /// </summary>
    public class ProjectedCs : CoordinateSystem, IProjectedCs
    {
        /// <summary>
        /// EPSG code of source geographic coordinate system
        /// </summary>
        public int SourceCode { get; set; }

        /// <summary>
        /// The type of projection (custom clasification for particular systems)
        /// </summary>
        public string ProjectionType { get; set; }

        /// <summary>
        /// Units of measure
        /// </summary>
        public int Units { get; set; }

        /// <summary>
        /// Marks local projection, that should be shown under country node only
        /// </summary>
        public bool Local { get; set; }
    }
}
