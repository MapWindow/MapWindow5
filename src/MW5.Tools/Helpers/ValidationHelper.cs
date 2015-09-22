using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Helpers;
using MW5.Shared;
using MW5.Tools.Enums;
using MW5.Tools.Model;

namespace MW5.Tools.Helpers
{
    /// <summary>
    /// Helper methods for shapefile validation.
    /// </summary>
    internal static class ValidationHelper
    {
        private static readonly string[] _errors = new [] {
		    "Topology Validation Error",
		    "Repeated Point",
		    "Hole lies outside shell",
		    "Holes are nested",
		    "Interior is disconnected",
		    "Ring Self-intersection",
		    "Self-intersection",
		    "Nested shells",
		    "Duplicate Rings",
		    "Too few points in geometry component",
		    "Invalid Coordinate",
		    "Ring is not closed",
            "Polygon must be clockwise",
	    };

        /// <summary>
        /// Gets info about particular error.
        /// </summary>
        public static ErrorInfo GetErrorInfo(IFeatureSet fs, int shapeIndex, string message)
        {
            string msg = string.Format("ID={0}: {1}" + Environment.NewLine, shapeIndex, message);

            return new ErrorInfo(shapeIndex, msg)
            {
                ErrorType = ParseErrorType(message),
                Location = GetErrorPoint(message)
            };
        }

        /// <summary>
        /// Parses error message returned by GEOS.
        /// </summary>
        /// <returns>Type of validation error.</returns>
        private static ValidationError ParseErrorType(string msg)
        {
            for (int i = 0; i < _errors.Length; i++)
            {
                if (msg.ContainsIgnoreCase(_errors[i]))
                {
                    return (ValidationError)i;
                }
            }

            return ValidationError.Unknown;
        }

        /// <summary>
        /// Extracts coordinates; format = message[X Y]
        /// </summary>
        private static ICoordinate GetErrorPoint(string message)
        {
            int index = message.IndexOf("[", StringComparison.Ordinal);

            if (index < 0 || index >= message.Length - 1)
            {
                return null;
            }

            string s = message.Substring(index + 1);

            if (s.Length <= 1)
            {
                return null;
            }

            s = s.Substring(0, s.Length - 1);

            string[] pair = s.Split(' ');

            if (pair.Length != 2)
            {
                return null;
            }

            double x, y;
            if (pair[0].ParseDoubleInvariant(out x) && pair[1].ParseDoubleInvariant(out y))
            {
                return new Coordinate(x, y);
            }

            return null;
        }

        /// <summary>
        /// Creates point shapefile woth errors
        /// </summary>
        public static IFeatureSet CreateErrorFeatureSet(IFeatureSet source)
        {
            var fs = new FeatureSet(GeometryType.Point);
            fs.Projection.CopyFrom(source.Projection);

            var f1 = new AttributeField()
            {
                Type = AttributeType.Integer,
                Name = "ErrorType",
                Alias = "Error type"
            };

            var f2 = new AttributeField()
            {
                Type = AttributeType.String,
                Name = "ErrorMsg",
                Width = 30,
                Alias = "Error message"
            };

            fs.Fields.Add(f1);
            fs.Fields.Add(f2);

            LoadSymbology(fs);

            return fs;
        }

        /// <summary>
        /// Loads categories for output point shapefile.
        /// </summary>
        private static bool LoadSymbology(IFeatureSet fs)
        {
            string filename = ResourcePathHelper.GetStylesPath() + "GeosValidationErrors.xml";
            if (!File.Exists(filename))
            {
                Logger.Current.Warn("Failed to find XML with symbology for error type: " + filename);
                return false;
            }

            string xml = File.ReadAllText(filename);

            return fs.Categories.Deserialize(xml);
        }
    }
}
