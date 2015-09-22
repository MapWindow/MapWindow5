using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;

namespace MW5.Plugins.Helpers
{
    /// <summary>
    /// Helper methods to work with area and length units.
    /// </summary>
    public static class UnitsHelper
    {
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
    }
}
