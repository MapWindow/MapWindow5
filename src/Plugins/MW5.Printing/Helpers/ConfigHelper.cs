// -------------------------------------------------------------------------------------------
// <copyright file="ConfigHelper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing.Printing;
using MW5.Api.Enums;
using MW5.Plugins.Concrete;
using MW5.Plugins.Printing.Enums;

namespace MW5.Plugins.Printing.Helpers
{
    internal static class ConfigHelper
    {
        public static int GetDecimalDigitsForUnits()
        {
            var units = GetUnits();

            switch (units)
            {
                case LayoutUnit.Inch:
                    return 2;
                case LayoutUnit.Millimeter:
                    return 0;
            }

            return 1;
        }

        public static void GetMargins(
            PageSettings ps,
            out double left,
            out double right,
            out double top,
            out double bottom)
        {
            double ratio = GetUnitsConversionRatio(GetUnits());

            var margins = ps.Margins;

            left = margins.Left * ratio;
            right = margins.Right * ratio;
            top = margins.Top * ratio;
            bottom = margins.Bottom * ratio;
        }

        public static string GetUnitShortString()
        {
            var units = GetUnits();

            switch (units)
            {
                case LayoutUnit.Inch:
                    return "in";
                case LayoutUnit.Millimeter:
                    return "mm";
                default:
                    return "nd";
            }
        }

        public static LayoutUnit GetUnits()
        {
            try
            {
                return (LayoutUnit)AppConfig.Instance.PrintingUnits;
            }
            catch
            {
                return default(LayoutUnit);
            }
        }

        public static double GetUnitsConversionRatio(bool fractionalInches = true)
        {
            return GetUnitsConversionRatio(GetUnits(), fractionalInches);
        }

        public static void SaveMargins(PageSettings ps, double left, double right, double top, double bottom)
        {
            double ratio = 1.0 / GetUnitsConversionRatio(GetUnits());

            ps.Margins.Left = Convert.ToInt32(left * ratio);
            ps.Margins.Right = Convert.ToInt32(right * ratio);
            ps.Margins.Top = Convert.ToInt32(top * ratio);
            ps.Margins.Bottom = Convert.ToInt32(bottom * ratio);
        }

        private static double GetUnitsConversionRatio(LayoutUnit units, bool fractionalInches = true)
        {
            // original units are 1/100 of an inch
            switch (units)
            {
                case LayoutUnit.Inch:
                    return fractionalInches ? 0.01f : 1.0f;
                case LayoutUnit.Millimeter:
                    return 1.0 / (LengthUnits.Milimeters.GetConversionFactor() * 100.0);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}