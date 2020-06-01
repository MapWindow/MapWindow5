using MW5.Api.Interfaces;
using System;

namespace MW5.Plugins.AdvancedSnapping.Restrictions
{
    public class BearingRestriction : LinearRestriction
    {
        #region Private fields

        #endregion

        #region Properties
        public double Bearing
        {
            get => ConvertFactorToBearing(Factor);
            set => Factor = ConvertBearingToFactor(value);
        }

        private static double ConvertFactorToBearing(double value)
        {
            if (double.IsInfinity(value))
                return 0;
            else
            {
                var angle = Math.Atan(value);
                return (Math.PI / 2.0) - angle;
            }
        }

        private static double ConvertBearingToFactor(double value)
        {
            value = value % (Math.PI * 2); // get rid of overshoots
            var angle = (Math.PI / 2.0) - value; // convert to cartesian angle
            if (Math.Abs(angle - Math.PI / 2.0) < double.Epsilon)
                return double.PositiveInfinity;
            else
                return Math.Tan(angle);
        }
        #endregion

        #region Construction & initialization
        public BearingRestriction(ICoordinate anchor, double bearing, int handle) : base(anchor, ConvertBearingToFactor(bearing), handle)
        {

            Anchor = anchor;
            Bearing = bearing;

        }

        internal void RefreshGuideline()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
