using System;
using MW5.Api.Enums;

namespace MW5.Api.Helpers
{
    public static class UnitConversionHelper
    {
        private static double GetAreaConversionFactor(AreaUnits units)
        {
            // TODO: perhaps move it to ocx
            switch (units)
            {
                case AreaUnits.SquareFeet:
                    return 0.09290304;        // 0.3048 ^ 2
                case AreaUnits.SquareYards:
                    return 0.83612736;        // 0.9144 ^ 2;
                case AreaUnits.SquareMeters:
                    return 1.0;
                case AreaUnits.SquareMiles:
                    return 2589988.110336;    //1609.344 ^ 2;
                case AreaUnits.SquareKilometers:
                    return 1000000.0;
                case AreaUnits.Hectares:
                    return 10000.0;
                case AreaUnits.Acres:
                    return 4046.856;
                default:
                    throw new ArgumentOutOfRangeException("units");
            }
        }

        public static double Convert(AreaUnits from, AreaUnits to, double value)
        {
            if (from == to)
            {
                return value;
            }

            value *= GetAreaConversionFactor(from);
            value /= GetAreaConversionFactor(to);

            return value;
        }

        public static double Convert(LengthUnits from, LengthUnits to, double value)
        {
            if (from == to)
            {
                return value;
            }

            GeodesicUtils.ConvertDistance(from, to, ref value);

            return value;
        }
    }
}
