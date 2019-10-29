using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{
    public class CircularRestriction : DrawableRestriction
    {
        public override RestrictionType Type => RestrictionType.Circular;

        public override ICoordinate Anchor { get; set; }
        public override double Factor { get; set; }

        #region Properties
        public double Distance
        {
            get => Factor;
            set => Factor = value;
        }
        #endregion

        #region Constructor
        public CircularRestriction(ICoordinate anchor, double distance, int handle) : base(handle)
        {
            Anchor = anchor;
            Distance = distance;
        }
        #endregion

        #region methods
        public override void DrawGuideline(IMap map)
        {
            map.Drawing.DrawCircle(Anchor.X, Anchor.Y, Factor, GuidelineColor, false, GuidelineWidth);
        }

        public override ICoordinate GetSnapPoint(ICoordinate original)
        {
            var distance = double.MaxValue;
            ICoordinate result = null;
            // Get all snap points
            foreach (var coordinate in FindIntersection(new LinearRestriction(original, Algebra.CalculateSlope(original, Anchor), Handle)))
            {
                // Get closest point:
                var d = coordinate.Distance(original);
                if (d < distance)
                {
                    distance = d;
                    result = coordinate;
                }
            }
            return result;
        }

        public IEnumerable<ICoordinate> FindIntersection(LinearRestriction restrictionA)
        {
            // Sanity check
            if (restrictionA == null)
                yield break;

            // Translate line so circle center is at origin
            var A = restrictionA.Factor;
            var B = -1.0;
            var C = (restrictionA.Anchor.Y - Anchor.Y) - restrictionA.Factor * (restrictionA.Anchor.X - Anchor.X);
            // Translate found points back the original coordinate system:
            foreach (var coordinate in Algebra.GetIntersectionForCircleAtOriginWithLines(Factor, A, B, C))
                yield return new Coordinate(coordinate.X + Anchor.X, coordinate.Y + Anchor.Y);
        }

        public IEnumerable<ICoordinate> GetIntersections(CircularRestriction restrictionA)
        {
            if (restrictionA == null)
                yield break;

            // Some things we'll need a lot:
            var distance = restrictionA.Anchor.Distance(Anchor);
            double combinedDiameters = (restrictionA.Factor + Factor);

            // 0 intersection points -- we don't treat the cases were circles overlap or if any of the radii are 0
            if (distance > combinedDiameters || distance == 0 || restrictionA.Factor == 0 || Factor == 0)
                yield break;
            // 1 intersection smack in the 'middle'
            else if (distance == combinedDiameters)
                yield return Algebra.PointBetweenPoints(restrictionA.Anchor, Anchor, restrictionA.Factor / combinedDiameters);
            // 2 intersection points
            else
            {
                // from https://math.stackexchange.com/a/1367732
                double Ax = 0.5 * (Anchor.X + restrictionA.Anchor.X);
                double Ay = 0.5 * (Anchor.Y + restrictionA.Anchor.Y);
                double Bx = 0.5 * (restrictionA.Anchor.X - Anchor.X);
                double By = 0.5 * (restrictionA.Anchor.Y - Anchor.Y);

                double avgR = (Math.Pow(Factor, 2) - Math.Pow(restrictionA.Factor, 2)) / Math.Pow(combinedDiameters, 2);
                double sqrtR = 0.5 * Math.Sqrt(2 * (Math.Pow(Factor, 2) + Math.Pow(restrictionA.Factor, 2)) / Math.Pow(combinedDiameters, 2) - Math.Pow(avgR, 2) - 1);
                yield return new Coordinate(
                    0.5 * (Ax + avgR * Bx) + sqrtR * By,
                    0.5 * (Ay + avgR * By) + sqrtR * Bx
                );
                yield return new Coordinate(
                    0.5 * (Ax + avgR * Bx) - sqrtR * By,
                    0.5 * (Ay + avgR * By) - sqrtR * Bx
                );
            }
        }

        public override IEnumerable<ICoordinate> GetIntersections(IRestriction other)
        {
            if (other is LinearRestriction linRestr)
                return FindIntersection(linRestr);
            if (other is CircularRestriction circRestr)
                return GetIntersections(circRestr);
            else
                return Enumerable.Empty<ICoordinate>();
        }

        public IEnvelope GetExtents() 
            => new Envelope(Anchor.X - Factor, Anchor.X + Factor, Anchor.Y - Factor, Anchor.Y + Factor);
        #endregion

    }
}
