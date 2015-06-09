using System;

namespace MW5.Plugins.TableEditor.Views.Services
{
    /// <summary>The class using units of measurement</summary>
    public class MapUnitsService
    {
        #region Methods

        /// <summary>Calculate the conversion factor.</summary>
        /// <returns>The conversion factor.</returns>
        private double CalcConversionFactor()
        {
            try
            {
                // First we're going to determin the conversion factor from the mapUnits to meters
                // Second we're going to determin the conversion factor from the calcUnits to meters
                // Thirth the overall conversion factor is (conversion factor mapUnits) / (conversion factor calcUnits)
                var decDegException =
                    new Exception(
                        "Conversion To/From Decimal Degrees requires the use of 'FromDecimalDegrees' function or 'ToDecimalDegrees' function");
                double mapUnits, calculatesUnits;

                // Step 1: convert to mapUnits to meters:
                switch (MapUnits)
                {
                    case AreaUnits.Centimeters:
                        mapUnits = ConversionFactorsSqUnits.CentimetersToMeters;
                        break;
                    case AreaUnits.DecimalDegrees:
                        mapUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case AreaUnits.Feet:
                        mapUnits = ConversionFactorsSqUnits.FeetToMeters;
                        break;
                    case AreaUnits.Inches:
                        mapUnits = ConversionFactorsSqUnits.InchesToMeters;
                        break;
                    case AreaUnits.Kilometers:
                        mapUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case AreaUnits.Miles:
                        mapUnits = ConversionFactorsSqUnits.MilesToMeters;
                        break;
                    case AreaUnits.Millimeters:
                        mapUnits = ConversionFactorsSqUnits.MillimeterToMeters;
                        break;
                    case AreaUnits.Yards:
                        mapUnits = ConversionFactorsSqUnits.YardsToMeters;
                        break;
                    case AreaUnits.Acres:
                        mapUnits = ConversionFactorsSqUnits.AcresToMeters;

                        // When using acres feet are more likely to be wanted for perimeter, thanks to Jack for pointing this out.
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            mapUnits = ConversionFactorsSqUnits.FeetToMeters;
                        }

                        break;
                    case AreaUnits.Hectares:
                        mapUnits = ConversionFactorsSqUnits.HectaresToMeters;
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            mapUnits = ConversionFactorsSqUnits.MetersToMeters;
                        }

                        break;
                    default:
                        mapUnits = 1;
                        break;
                }

                if (MeasurementType == MeasurementTypes.Area
                    && !(MapUnits == AreaUnits.Acres || MapUnits == AreaUnits.Hectares))
                {
                    mapUnits *= mapUnits; // Squared
                }

                // Step 2: convert to calcUnits to meters:
                switch (CalculatedUnits)
                {
                    case AreaUnits.Centimeters:
                        calculatesUnits = ConversionFactorsSqUnits.CentimetersToMeters;
                        break;
                    case AreaUnits.DecimalDegrees:
                        throw decDegException;
                    case AreaUnits.Feet:
                        calculatesUnits = ConversionFactorsSqUnits.FeetToMeters;
                        break;
                    case AreaUnits.Inches:
                        calculatesUnits = ConversionFactorsSqUnits.InchesToMeters;
                        break;
                    case AreaUnits.Kilometers:
                        calculatesUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case AreaUnits.Miles:
                        calculatesUnits = ConversionFactorsSqUnits.MilesToMeters;
                        break;
                    case AreaUnits.Millimeters:
                        calculatesUnits = ConversionFactorsSqUnits.MillimeterToMeters;
                        break;
                    case AreaUnits.Yards:
                        calculatesUnits = ConversionFactorsSqUnits.YardsToMeters;
                        break;
                    case AreaUnits.Acres:
                        calculatesUnits = ConversionFactorsSqUnits.AcresToMeters;
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            calculatesUnits = ConversionFactorsSqUnits.FeetToMeters;
                        }

                        break;
                    case AreaUnits.Hectares:
                        calculatesUnits = ConversionFactorsSqUnits.HectaresToMeters;
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            calculatesUnits = ConversionFactorsSqUnits.MetersToMeters;
                        }

                        break;
                    default:
                        calculatesUnits = 1;
                        break;
                }

                if (MeasurementType == MeasurementTypes.Area
                    && !(CalculatedUnits == AreaUnits.Acres || CalculatedUnits == AreaUnits.Hectares))
                {
                    calculatesUnits *= calculatesUnits; // Squared
                }

                return mapUnits/calculatesUnits;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in convertUnits: \n" + ex);
            }
        }

        #endregion

        #region Conversion coefficients

        /// <summary>The conversion factors</summary>
        private struct ConversionFactorsSqUnits
        {
            /// <summary>Km to meters</summary>
            public const double KilometersToMeters = 1000;

            /// <summary>Cm to meters</summary>
            public const double CentimetersToMeters = 0.01;

            /// <summary>Mm to meters</summary>
            public const double MillimeterToMeters = 0.001;

            /// <summary>Miles to meters</summary>
            public const double MilesToMeters = 1609.344;

            /// <summary>Yards to meters</summary>
            public const double YardsToMeters = 0.9144;

            /// <summary>Feed to meters</summary>
            public const double FeetToMeters = 0.3048;

            /// <summary>Inches to meters</summary>
            public const double InchesToMeters = 0.0254;

            /// <summary>Acres to meters</summary>
            public const double AcresToMeters = 4046.856;

            /// <summary>Hectares to meters</summary>
            public const double HectaresToMeters = 10000;

            /// <summary>Meters to meters</summary>
            public const double MetersToMeters = 1;
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets MeasurementType.</summary>
        public MeasurementTypes MeasurementType { get; set; }

        /// <summary>Gets or sets CalculatedUnits.</summary>
        public AreaUnits CalculatedUnits { get; set; }

        /// <summary>Gets or sets MapUnits.</summary>
        public AreaUnits MapUnits { get; set; }

        #endregion

        #region Public Methods

        /// <summary>Converts the units.</summary>
        /// <param name="orgMeasurement">The original measurement.</param>
        /// <returns>The convert units.</returns>
        public double ConvertUnits(double orgMeasurement)
        {
            try
            {
                if (MapUnits == AreaUnits.Unknown || CalculatedUnits == AreaUnits.Unknown)
                {
                    throw new Exception("Incorrect use of convertUnits.\n Units must be set before calling");
                }

                if (MapUnits == CalculatedUnits)
                {
                    return orgMeasurement;
                }

                // Recalculate the measurement using the conversionfactor:
                return orgMeasurement*CalcConversionFactor();
            }
            catch (Exception ex)
            {
                throw new Exception("Error in convertUnits: \n" + ex);
            }
        }

        /// <summary>Gets the units from the proj4 string</summary>
        /// <param name="prj4">The prj4 string</param>
        /// <returns>The unit</returns>
        public AreaUnits GetUnitsFromProj4(string prj4)
        {
            try
            {
                // Try to detect the unit from the proj4 string;
                if (string.IsNullOrEmpty(prj4))
                {
                    throw new Exception("No projection provided.\n Do this first using the GIS Tools.");
                }

                if (prj4.ToLower().Contains("+units="))
                {
                    var components =
                        prj4.ToLower().Substring(prj4.ToLower().IndexOf("+units=")).Split(Convert.ToChar(32));
                    var unitPart = components[0].Split(Convert.ToChar(61));
                    if (unitPart.Length > 1 && unitPart[0] == "+units")
                    {
                        if (unitPart[1] == "m")
                        {
                            return AreaUnits.Meters;
                        }

                        if (unitPart[1] == "us-ft")
                        {
                            return AreaUnits.Feet;
                        }
                    }
                }
                else
                {
                    // Is it latlong?
                    if (prj4.ToLower().Contains("longlat") || prj4.ToLower().Contains("latlong"))
                    {
                        return AreaUnits.DecimalDegrees;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUnitsFromProj4: \n" + ex);
            }

            return AreaUnits.Meters;
        }

        /// <summary>The string to uom.</summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The unit</returns>
        public AreaUnits StringToUom(string text)
        {
            try
            {
                var tmp = text.Replace(" Squared", string.Empty);

                switch (tmp)
                {
                    case "Centimeters":
                        return AreaUnits.Centimeters;
                    case "DecimalDegrees":
                        return AreaUnits.DecimalDegrees;
                    case "Feet":
                        return AreaUnits.Feet;
                    case "Inches":
                        return AreaUnits.Inches;
                    case "Kilometers":
                        return AreaUnits.Kilometers;
                    case "Meters":
                        return AreaUnits.Meters;
                    case "Miles":
                        return AreaUnits.Miles;
                    case "Millimeters":
                        return AreaUnits.Millimeters;
                    case "Yards":
                        return AreaUnits.Yards;
                    case "Hectares":
                        return AreaUnits.Hectares;
                    case "Acres":
                        return AreaUnits.Acres;
                    default:
                        return AreaUnits.Meters;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in stringToUOM: \n" + ex);
            }
        }

        #endregion
    }
}