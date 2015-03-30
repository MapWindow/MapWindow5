namespace MW5.Projections.BL
{
    /// <summary>
    /// Holds coordinates of bounding box for selected coordinate system
    /// </summary>
    public struct BoundingBox
    {
        /// <summary>
        /// Minimal value by X axis
        /// </summary>
        public double xMin;

        /// <summary>
        /// Maximum value by X axis
        /// </summary>
        public double xMax;

        /// <summary>
        /// Minimal value by Y axis
        /// </summary>
        public double yMin;

        /// <summary>
        /// Maximumm value by Y axis
        /// </summary>
        public double yMax;

        /// <summary>
        /// Creates a new instance of BoundingBox class with specified bounds
        /// </summary>
        public BoundingBox(double minX, double maxX, double minY, double maxY)
        {
            xMin = minX;
            yMin = minY;
            xMax = maxX;
            yMax = maxY;
        }
    }
}
