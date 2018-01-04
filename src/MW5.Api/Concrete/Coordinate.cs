using System;
using System.Globalization;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// The Coordinate class, Point class in MWGIS
    /// </summary>
    /// <seealso cref="MW5.Api.Interfaces.ICoordinate" />
    public class Coordinate : ICoordinate
    {
        private readonly Point _point;

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        public Coordinate(double x, double y)
        {
            _point = new Point {x = x, y = y};
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Coordinate"/> class.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="z">The z.</param>
        public Coordinate(double x, double y, double z)
        {
            _point = new Point { x = x, y = y, Z = z};
        }

        internal Coordinate(Point point)
        {
            _point = point;
        }

        /// <summary>
        /// Gets the x.
        /// </summary>
        /// <value>
        /// The x.
        /// </value>
        /// <remarks>
        /// Use Geometry.MovePoint to set the X and Y
        /// </remarks>
        public double X
        {
            get { return _point.x; }
        }

        /// <summary>
        /// Gets the y.
        /// </summary>
        /// <value>
        /// The y.
        /// </value>
        /// <remarks>Use Geometry.MovePoint to set the X and Y</remarks>
        public double Y
        {
            get { return _point.y; }
        }

        /// <summary>
        /// Gets the z.
        /// </summary>
        /// <value>
        /// The z.
        /// </value>
        /// <remarks>Use Geometry.SetZ to set the Z</remarks>
        public double Z
        {
            get { return _point.Z; }
        }

        /// <summary>
        /// Gets the m.
        /// </summary>
        /// <value>
        /// The m.
        /// </value>
        /// <remarks>Use Geometry.SetM to set the M</remarks>
        public double M
        {
            get { return _point.M; }
        }

        /// <summary>
        /// Clones this instance.
        /// </summary>
        /// <returns></returns>
        public ICoordinate Clone()
        {
            return new Coordinate(_point.Clone());
        }

        /// <summary>
        /// Gets the internal point object. Use only in specific circumstances.
        /// Normally it is not recommended to use the internal object directly.
        /// </summary>
        /// <value>
        /// The internal point object.
        /// </value>
        public object InternalObject
        {
            get { return _point; }
        }

        /// <summary>
        /// Gets the last error.
        /// </summary>
        /// <value>
        /// The last error.
        /// </value>
        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; }   // it's not defined in ocx
        }

        /// <summary>
        /// Not supported
        /// </summary>
        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        public override string ToString()
        {
            var str = "X: " + _point.x.ToString(CultureInfo.InvariantCulture) + " Y: " + _point.y.ToString(CultureInfo.InvariantCulture);
            return str;
        }
    }
}