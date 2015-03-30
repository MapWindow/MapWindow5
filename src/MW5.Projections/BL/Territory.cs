using MW5.Plugins.Interfaces.Projections;

namespace MW5.Projections.BL
{
    /// <summary>
    /// Base class fro coordinate systems and countries
    /// </summary>
    public class Territory : ITerritory
    {
        /// <summary>
        /// The code of territory (coordinate system , country or region)
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// The name of territory
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The left bound
        /// </summary>
        public double Left { get; set; }

        /// <summary>
        /// The right bound
        /// </summary>
        public double Right { get; set; }

        /// <summary>
        /// The top bound
        /// </summary>
        public double Top { get; set; }

        /// <summary>
        /// The bottom bound
        /// </summary>
        public double Bottom { get; set; }
        
        public bool IsActive { get; set; }   // fall within bounds

        /// <summary>
        /// Settings name as string representation
        /// </summary>
        public override string ToString()
        {
            return string.IsNullOrWhiteSpace(Name) ? "not defined" : Name;
        }
    }
}
