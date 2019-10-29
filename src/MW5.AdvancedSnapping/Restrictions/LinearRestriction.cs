using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{

    public class LinearRestriction : DrawableRestriction
    {
        #region Properties
        public override RestrictionType Type => RestrictionType.Linear;

        private ICoordinate _anchor;
        public override ICoordinate Anchor {
            get => _anchor;
            set
            {
                _anchor = value;
                UpdateConstant();
            }
        }

        private double _factor = 0;
        public override double Factor {
            get => _factor;
            set
            {
                _factor = value;
                UpdateConstant();
            }
        }

        private double _constant = 0;
        public virtual double Constant { get => _constant;  }

        private double _offset = 0;
        public virtual double Offset { get => _offset;  }
        #endregion

        #region Get methods
        public double GetYCoordinate(double x)
        {
            return Constant + Factor * x;
        }

        public double GetXCoordinate(double y)
        {
            return (y - Constant) / Factor;
        }

        public override IEnumerable<ICoordinate> GetIntersections(IRestriction other)
        {
            if (other is LinearRestriction linRestr)
                return new[] { GetIntersection(linRestr) };
            if (other is CircularRestriction circRestr)
                return circRestr.GetIntersections(this);
            else
                return Enumerable.Empty<ICoordinate>();
        }

        public ICoordinate GetIntersection(LinearRestriction other)
        {
            if (other == null)
                return null;

            if (double.IsInfinity(Factor) && !double.IsInfinity(other.Factor))
                return new Coordinate(Anchor.X, other.GetYCoordinate(Anchor.X));

            if (double.IsInfinity(Factor) && !double.IsInfinity(other.Factor))
                return new Coordinate(other.Anchor.X, GetYCoordinate(other.Anchor.X));

            if (other.Factor == Factor || double.IsInfinity(Factor) && double.IsInfinity(other.Factor))
                return null;

            var x = (other.Constant - Constant) / (Factor - other.Factor);
            return new Coordinate(x, GetYCoordinate(x));
        }
        #endregion

        #region Construction & initialization
        public LinearRestriction(ICoordinate anchor, double factor, int handle) : base(handle)
        {
            Anchor = anchor;
            Factor = factor;
        }
        #endregion

        #region Methods
        public virtual double GetOffsetDistance(ICoordinate offsetAnchor, double tolerance = double.Epsilon)
        {
            var parallelRestriction = new LinearRestriction(offsetAnchor, Factor, Handle);
            var normalRestriction = new LinearRestriction(Anchor, -1 / Factor, Handle);
            var newAnchor = parallelRestriction.GetIntersection(normalRestriction);

            var distance = Anchor.Distance(newAnchor);
            if (distance < tolerance)
                distance = 0.0;

            IEnumerable<ICoordinate> offsets = GetNewAnchorsAtDistance(distance);
            if (Math.Abs(newAnchor.X - offsets.First().X) <= tolerance && Math.Abs(newAnchor.Y - offsets.First().Y) <= tolerance)
                return distance;
            else
                return -distance;
        }

        private IEnumerable<ICoordinate> GetNewAnchorsAtDistance(double distance)
        {
            // To calculate the new anchor point:
            var normalSlope = -1.0 / Factor;
            var offsetRestriction = new LinearRestriction(Anchor, normalSlope, Handle);
            var circularRestriction = new CircularRestriction(Anchor, distance, Handle);
            var offsets = offsetRestriction.GetIntersections(circularRestriction);
            return offsets;
        }

        public virtual void OffsetByDistance(double distance)
        {
            var delta = distance - _offset;
            var offsets = GetNewAnchorsAtDistance(delta);
            if (delta > 0)
                Anchor = offsets.First();
            else
                Anchor = offsets.Last();
            _offset = distance;
        }

        public override ICoordinate GetSnapPoint(ICoordinate original)
        {
            var normalSlope = -1.0 / Factor;
            return GetIntersection(new LinearRestriction(original, normalSlope, this.Handle));
        }

        public override void DrawGuideline(IMap map)
        {
            double x1 = 0, y1 = 0, x2 = 0, y2 = 0;
            double extraD = Math.Max(map.Extents.Width / 100.0, map.Extents.Height / 100.0);
            // If a vertical line, set X to anchor & Y to extents (slightly enlarged)
            if (double.IsInfinity(Factor))
            {
                x1 = Anchor.X;
                y1 = map.Extents.MinY - extraD;

                x2 = Anchor.X;
                y2 = map.Extents.MaxY + extraD;
            }
            else // calculate y-coordinate using extents (slightly enlarged)
            {
                x1 = map.Extents.MinX - extraD;
                y1 = GetYCoordinate(x1);

                x2 = map.Extents.MaxX + extraD;
                y2 = GetYCoordinate(x2);
            }
            map.Drawing.DrawLine(DrawingHandle, x1, y1, x2, y2, GuidelineWidth, GuidelineColor);

        }

        /// <summary>
        /// Recalculates constant of the line equation
        /// </summary>
        private void UpdateConstant()
        {
            _constant = _anchor.Y - _anchor.X * Factor;
        }

        #endregion
    }
}
