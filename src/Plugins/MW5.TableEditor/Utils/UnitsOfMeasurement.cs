using System;

namespace MW5.Plugins.TableEditor.utils
{

    #region

    #endregion

    /// <summary>The class using units of measurement</summary>
    public class UnitsOfMeasurement
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
                    case UnitOfArea.Centimeters:
                        mapUnits = ConversionFactorsSqUnits.CentimetersToMeters;
                        break;
                    case UnitOfArea.DecimalDegrees:
                        mapUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case UnitOfArea.Feet:
                        mapUnits = ConversionFactorsSqUnits.FeetToMeters;
                        break;
                    case UnitOfArea.Inches:
                        mapUnits = ConversionFactorsSqUnits.InchesToMeters;
                        break;
                    case UnitOfArea.Kilometers:
                        mapUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case UnitOfArea.Miles:
                        mapUnits = ConversionFactorsSqUnits.MilesToMeters;
                        break;
                    case UnitOfArea.Millimeters:
                        mapUnits = ConversionFactorsSqUnits.MillimeterToMeters;
                        break;
                    case UnitOfArea.Yards:
                        mapUnits = ConversionFactorsSqUnits.YardsToMeters;
                        break;
                    case UnitOfArea.Acres:
                        mapUnits = ConversionFactorsSqUnits.AcresToMeters;

                        // When using acres feet are more likely to be wanted for perimeter, thanks to Jack for pointing this out.
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            mapUnits = ConversionFactorsSqUnits.FeetToMeters;
                        }

                        break;
                    case UnitOfArea.Hectares:
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
                    && !(MapUnits == UnitOfArea.Acres || MapUnits == UnitOfArea.Hectares))
                {
                    mapUnits *= mapUnits; // Squared
                }

                // Step 2: convert to calcUnits to meters:
                switch (CalculatedUnits)
                {
                    case UnitOfArea.Centimeters:
                        calculatesUnits = ConversionFactorsSqUnits.CentimetersToMeters;
                        break;
                    case UnitOfArea.DecimalDegrees:
                        throw decDegException;
                    case UnitOfArea.Feet:
                        calculatesUnits = ConversionFactorsSqUnits.FeetToMeters;
                        break;
                    case UnitOfArea.Inches:
                        calculatesUnits = ConversionFactorsSqUnits.InchesToMeters;
                        break;
                    case UnitOfArea.Kilometers:
                        calculatesUnits = ConversionFactorsSqUnits.KilometersToMeters;
                        break;
                    case UnitOfArea.Miles:
                        calculatesUnits = ConversionFactorsSqUnits.MilesToMeters;
                        break;
                    case UnitOfArea.Millimeters:
                        calculatesUnits = ConversionFactorsSqUnits.MillimeterToMeters;
                        break;
                    case UnitOfArea.Yards:
                        calculatesUnits = ConversionFactorsSqUnits.YardsToMeters;
                        break;
                    case UnitOfArea.Acres:
                        calculatesUnits = ConversionFactorsSqUnits.AcresToMeters;
                        if (MeasurementType != MeasurementTypes.Area)
                        {
                            calculatesUnits = ConversionFactorsSqUnits.FeetToMeters;
                        }

                        break;
                    case UnitOfArea.Hectares:
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
                    && !(CalculatedUnits == UnitOfArea.Acres || CalculatedUnits == UnitOfArea.Hectares))
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

        #region enums

        /// <summary>The unit of area.</summary>
        /// <remarks>This should be in the MW core</remarks>
        public enum UnitOfArea
        {
            /// <summary>The decimal degrees.</summary>
            DecimalDegrees,

            /// <summary>The millimeters.</summary>
            Millimeters,

            /// <summary>The centimeters.</summary>
            Centimeters,

            /// <summary>The inches.</summary>
            Inches,

            /// <summary>The feet.</summary>
            Feet,

            /// <summary>The yards.</summary>
            Yards,

            /// <summary>The meters.</summary>
            Meters,

            /// <summary>The miles.</summary>
            Miles,

            /// <summary>The kilometers.</summary>
            Kilometers,

            /// <summary>The hectares.</summary>
            Hectares,

            /// <summary>The acres.</summary>
            Acres,

            /// <summary>The unknown unit</summary>
            Unknown
        }

        /// <summary>
        /// The measurement types.
        /// </summary>
        /// <remarks>This should be in the MW core</remarks>
        public enum MeasurementTypes
        {
            /// <summary>The area.</summary>
            Area,

            /// <summary>The perimeter.</summary>
            Perimeter,

            /// <summary>The length.</summary>
            Length
        }

        #endregion

        #region Public Properties

        /// <summary>Gets or sets MeasurementType.</summary>
        public MeasurementTypes MeasurementType { get; set; }

        /// <summary>Gets or sets CalculatedUnits.</summary>
        public UnitOfArea CalculatedUnits { get; set; }

        /// <summary>Gets or sets MapUnits.</summary>
        public UnitOfArea MapUnits { get; set; }

        #endregion

        #region Public Methods

        /// <summary>Converts the units.</summary>
        /// <param name="orgMeasurement">The original measurement.</param>
        /// <returns>The convert units.</returns>
        public double ConvertUnits(double orgMeasurement)
        {
            try
            {
                if (MapUnits == UnitOfArea.Unknown || CalculatedUnits == UnitOfArea.Unknown)
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
        public UnitOfArea GetUnitsFromProj4(string prj4)
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
                            return UnitOfArea.Meters;
                        }

                        if (unitPart[1] == "us-ft")
                        {
                            return UnitOfArea.Feet;
                        }
                    }
                }
                else
                {
                    // Is it latlong?
                    if (prj4.ToLower().Contains("longlat") || prj4.ToLower().Contains("latlong"))
                    {
                        return UnitOfArea.DecimalDegrees;
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error in GetUnitsFromProj4: \n" + ex);
            }

            return UnitOfArea.Meters;
        }

        /// <summary>The string to uom.</summary>
        /// <param name="text">The string to convert.</param>
        /// <returns>The unit</returns>
        public UnitOfArea StringToUom(string text)
        {
            try
            {
                var tmp = text.Replace(" Squared", string.Empty);

                switch (tmp)
                {
                    case "Centimeters":
                        return UnitOfArea.Centimeters;
                    case "DecimalDegrees":
                        return UnitOfArea.DecimalDegrees;
                    case "Feet":
                        return UnitOfArea.Feet;
                    case "Inches":
                        return UnitOfArea.Inches;
                    case "Kilometers":
                        return UnitOfArea.Kilometers;
                    case "Meters":
                        return UnitOfArea.Meters;
                    case "Miles":
                        return UnitOfArea.Miles;
                    case "Millimeters":
                        return UnitOfArea.Millimeters;
                    case "Yards":
                        return UnitOfArea.Yards;
                    case "Hectares":
                        return UnitOfArea.Hectares;
                    case "Acres":
                        return UnitOfArea.Acres;
                    default:
                        return UnitOfArea.Meters;
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