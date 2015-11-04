// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Envelope.cs" company="MapWindow OSS Team - www.mapwindow.org">
//   MapWindow OSS Team - 2015
// </copyright>
// <summary>
//   Defines the Envelope type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using MapWinGIS;
using MW5.Api.Helpers;
using MW5.Api.Interfaces;
using MW5.Shared;

namespace MW5.Api.Concrete
{
    /// <summary>
    /// Defines a rectangular region of the coordinate plane. 
    /// It is often used to represent the bounding box of a Geometry, e.g. the minimum and maximum x and y values of the Coordinates.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1305:FieldNamesMustNotUseHungarianNotation", Justification = "Reviewed. Suppression is OK here.")]
    public class Envelope : IEnvelope, IXmlSerializable
    {
        private readonly Extents _extents;

        public Envelope()
        {
            _extents = new Extents(); // initialized with zeroes
        }

        public Envelope(double xMin, double xMax, double yMin, double yMax)
        {
            _extents = new Extents();
            _extents.SetBounds(xMin, yMin, 0.0, xMax, yMax, 0.0);
        }

        internal Envelope(Extents extents)
        {
            _extents = extents;
        }

        /// <summary>
        /// Returns the difference between the maximum and minimum y values.
        /// </summary>
        public double Height
        {
            get { return MaxY - MinY; }
        }

        /// <summary>
        /// Returns the difference between the maximum and minimum x values.
        /// </summary>
        public double Width
        {
            get { return MaxX - MinX; }
        }

        /// <summary>
        /// Returns the Envelopes minimum x-value.
        /// </summary>
        public double MinX
        {
            get { return _extents.xMin; }
        }

        /// <summary>
        /// Returns the Envelopes minimum y-value.
        /// </summary>
        public double MinY
        {
            get { return _extents.yMin; }
        }

        /// <summary>
        /// Returns the Envelopes minimum z-value.
        /// </summary>
        public double MinZ
        {
            get { return _extents.zMin; }
        }

        /// <summary>
        /// Returns the Envelopes minimum m-value.
        /// </summary>
        public double MinM
        {
            get { return _extents.mMin; }
        }

        /// <summary>
        /// Returns the Envelopes maximum x-value.
        /// </summary>
        public double MaxX
        {
            get { return _extents.xMax; }
        }

        /// <summary>
        /// Returns the Envelopes maximum y-value.
        /// </summary>
        public double MaxY
        {
            get { return _extents.yMax; }
        }

        /// <summary>
        /// Returns the Envelopes maximum z-value.
        /// </summary>
        public double MaxZ
        {
            get { return _extents.zMax; }
        }

        /// <summary>
        /// Returns the Envelopes maximum m-value.
        /// </summary>
        public double MaxM
        {
            get { return _extents.mMax; }
        }

        public object InternalObject
        {
            get { return _extents; }
        }

        /// <summary>
        /// Returns no error, it's not defined in ocx
        /// </summary>
        public string LastError
        {
            get { return ErrorHelper.NO_ERROR; } // it's not defined in ocx
        }

        /// <summary>
        /// Alwasy returns ""
        /// </summary>
        public string Tag
        {
            get { throw new NotSupportedException(); }
            set { throw new NotSupportedException(); }
        }

        /// <summary>
        /// Gets the center of the envelope
        /// </summary>
        public ICoordinate Center
        {
            get { return new Coordinate(MinX + (Width / 2), MinY + (Height / 2)); }
        }

        public void SetBounds(double xMin, double xMax, double yMin, double yMax)
        {
            _extents.SetBounds(xMin, yMin, 0.0, xMax, yMax, 0.0);
        }

        public void SetBounds(ICoordinate center, double width, double height)
        {
            SetBounds(center.X - width / 2.0, center.X + width / 2.0, center.Y - height / 2.0, center.Y + height / 2.0);
        }

        public Rectangle ToRectangle()
        {
            return new Rectangle((int)MinX, (int)MinY, (int)(MaxX - MinX), (int)(MaxY - MinY));
        }

        /// <summary>
        /// Moves the envelope by the specified offset
        /// </summary>
        /// <param name="dx">The x offset.</param>
        /// <param name="dy">The y offset.</param>
        /// <returns>A new envelope</returns>
        public IEnvelope Move(double dx, double dy)
        {
            double xMin, xMax, yMin, yMax, zMin, zMax;
            _extents.GetBounds(out xMin, out yMin, out zMin, out xMax, out yMax, out zMax);
            return new Envelope(xMin + dx, xMax + dx, yMin + dy, yMax + dy);
        }

        /// <summary>
        /// Adjusts the envelope by the specified ratio.
        /// </summary>
        /// <param name="xyRatio">The xy ratio.</param>
        /// <returns>A new envelope</returns>
        public IEnvelope Adjust(double xyRatio)
        {
            double ratio = Width / Height;

            if (Math.Abs(ratio - xyRatio) < 10e-8)
            {
                return new Envelope(MinX, MaxX, MinY, MaxY);
            }

            if (ratio > xyRatio)
            {
                double height = Width / xyRatio;
                return new Envelope(MinX, MaxX, Center.Y - (height / 2), Center.Y + (height / 2));
            }

            double width = Height * xyRatio;
            return new Envelope(Center.X - (width / 2), Center.X + (width / 2), MinY, MaxY);
        }

        /// <summary>
        /// Checks if the envelopes are equal
        /// </summary>
        /// <param name="env">The envelope to check with</param>
        /// <param name="threshold">The maximum difference between the two envelopes.</param>
        /// <returns></returns>
        public bool EqualsTo(IEnvelope env, double threshold = 0.001)
        {
            if (env == null)
            {
                return false;
            }

            if (Math.Abs(env.MinX - MinX) > threshold)
            {
                return false;
            }

            if (Math.Abs(env.MaxX - MaxX) > threshold)
            {
                return false;
            }

            if (Math.Abs(env.MinY - MinY) > threshold)
            {
                return false;
            }

            if (Math.Abs(env.MaxY - MaxY) > threshold)
            {
                return false;
            }

            if (Math.Abs(env.Width - Width) > threshold)
            {
                return false;
            }

            return !(Math.Abs(env.Height - Height) > threshold);
        }

        /// <summary>
        /// Is the Point the within the envelope
        /// </summary>
        /// <param name="x">The x coordinate</param>
        /// <param name="y">The y coordinate</param>
        /// <returns></returns>
        public bool PointWithin(double x, double y)
        {
            return x >= MinX && x <= MaxX && y >= MinY && y <= MaxY;
        }

        /// <summary>
        /// Inflates the envelope by the specified offset
        /// </summary>
        /// <param name="dx">The x offset.</param>
        /// <param name="dy">The y offset.</param>
        /// <returns></returns>
        public IEnvelope Inflate(double dx, double dy)
        {
            return new Envelope(MinX - (dx / 2), MaxX + (dx / 2), MinY - (dy / 2), MaxY + (dy / 2));
        }

        /// <summary>
        /// Unions with the specified envelope
        /// </summary>
        /// <param name="env">The envelope</param>
        public void Union(IEnvelope env)
        {
            if (env == null)
            {
                return;
            }

            SetBounds(Math.Min(env.MinX, MinX), Math.Max(env.MaxX, MaxX), Math.Min(env.MinY, MinY), Math.Max(env.MaxY, MaxY));
        }

        public void MoveCenterTo(double xCenter, double yCenter)
        {
            double w = Width;
            double h = Height;

            SetBounds(xCenter - w / 2.0, xCenter + w / 2.0, yCenter - h / 2.0, yCenter + h / 2.0);
        }

        public IEnvelope Clone()
        {
            return new Envelope(MinX, MaxX, MinY, MaxY);
        }

        /// <summary>
        /// ConvertS to a geometry.
        /// </summary>
        public IGeometry ToGeometry()
        {
            var shape = _extents.ToShape();
            return shape != null ? new Geometry(shape) : null;
        }

        public override string ToString()
        {
            return _extents.ToDebugString();
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            double minX, minY, maxX, maxY;

            if (reader.GetAttribute("MinX").ParseDoubleInvariant(out minX) &&
                reader.GetAttribute("MinY").ParseDoubleInvariant(out minY) &&
                reader.GetAttribute("MaxX").ParseDoubleInvariant(out maxX) &&
                reader.GetAttribute("MaxY").ParseDoubleInvariant(out maxY))
            {
                SetBounds(minX, maxX, minY, maxY);
            }
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("MinX", MinX.ToInvariantString());
            writer.WriteAttributeString("MinY", MinY.ToInvariantString());
            writer.WriteAttributeString("MaxX", MaxX.ToInvariantString());
            writer.WriteAttributeString("MaxY", MaxY.ToInvariantString());
        }
    }
}