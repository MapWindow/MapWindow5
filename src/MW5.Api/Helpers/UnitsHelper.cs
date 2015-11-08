using System;
using MW5.Api.Enums;

namespace MW5.Api.Helpers
{
    /// <summary>
    /// Helper methods to work with area and length units.
    /// </summary>
    public static class UnitsHelper
    {
        /// <summary>
        /// Gets abbreviated name of the length units.
        /// </summary>
        public static string GetAbbreviatedName(this LengthUnits units)
        {
            switch (units)
            {
                case LengthUnits.DecimalDegrees:
                    return "deg.";
                case LengthUnits.Milimeters:
                    return "mm";
                case LengthUnits.Centimeters:
                    return "cm";
                case LengthUnits.Inches:
                    return "in";
                case LengthUnits.Feet:
                    return "ft";
                case LengthUnits.Yards:
                    return "yd";
                case LengthUnits.Meters:
                    return "m";
                case LengthUnits.Miles:
                    return "mi";
                case LengthUnits.Kilometers:
                    return "km";
                default:
                    throw new ArgumentOutOfRangeException("units");
            }
        }

        /// <summary>
        /// Gets the name of the abbreviated.
        /// </summary>
        public static string GetAbbreviatedName(AreaUnits units)
        {
            switch (units)
            {
                case AreaUnits.SquareMeters:
                    return "sq.m";
                case AreaUnits.Hectares:
                    return "ha";
                case AreaUnits.SquareKilometers:
                    return "sq.km";
                case AreaUnits.SquareFeet:
                    return "sq.ft";
                case AreaUnits.SquareYards:
                    return "sq.yd";
                case AreaUnits.Acres:
                    return "acres";
                case AreaUnits.SquareMiles:
                    return "sq.mi";
                default:
                    throw new ArgumentOutOfRangeException("units");
            }
        }

        public static string FormatDistance(LengthUnits units, double distance)
        {
            if (units == LengthUnits.Meters)
            {
                return distance > 1000.0 ? (distance / 1000.0).ToString("0.0 km") : distance.ToString("0.0 m");
            }

            // TODO: format as well
            return distance.ToString("0.0");
        }
    }
}
