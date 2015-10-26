// -------------------------------------------------------------------------------------------
// <copyright file="ConversionUtils.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Enums;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class ConversionUtils
    {
        /// <summary>
        /// Gets the conversion factor which defines a number of inches in a given length unit.
        /// </summary>
        public static double GetConversionFactor(this LengthUnits units)
        {
            switch (units)
            {
                case LengthUnits.DecimalDegrees:
                    return 4366141.73;
                case LengthUnits.Milimeters:
                    return 0.0393700787;
                case LengthUnits.Centimeters:
                    return 0.393700787;
                case LengthUnits.Inches:
                    return 1;
                case LengthUnits.Feet:
                    return 12;
                case LengthUnits.Yards:
                    return 36;
                case LengthUnits.Meters:
                    return 39.3700787;
                case LengthUnits.Miles:
                    return 63360;
                case LengthUnits.Kilometers:
                    return 39370.0787;
                default:
                    throw new ArgumentOutOfRangeException("units");
            }
        }
    }
}