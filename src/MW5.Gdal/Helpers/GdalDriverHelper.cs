using System;
using System.Collections.Generic;
using System.Linq;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Helpers;
using MW5.Shared;
using MW5.Tools.Model.Parameters;

namespace MW5.Gdal.Helpers
{
    /// <summary>
    /// Extension methods for GDAL datasource driver.
    /// </summary>
    internal static class GdalDriverHelper
    {
        public const string SameAsInputDataType = "<same as input>";

        /// <summary>
        /// Gets list of data types supported by driver according to metadata.
        /// </summary>
        public static IEnumerable<string> GetCreationDataTypes(this DatasourceDriver driver)
        {
            string s = driver.get_Metadata(GdalDriverMetadata.CreationDataTypes);

            IList<string> result;

            if (string.IsNullOrWhiteSpace(s))
            {
                result = GdalHelper.GetRasterDataTypes();
            }
            else
            {
                result = s.Split(new[] { ' ' }).ToList();
            }

            result.Insert(0, SameAsInputDataType);

            return result;
        }

        /// <summary>
        /// Gets list of options to be displayed in a separate main section.
        /// </summary>
        public static IEnumerable<string> GetMainOptions(this DatasourceDriver driver)
        {
            switch (driver.Name.ToLower())
            {
                case GdalFormats.GTiff:
                    // can be specified in app config if needed
                    return new[] { "COMPRESS", "JPEG_QUALITY", "ZLEVEL" };
                default:
                    return new List<string>();
            }
        }

        /// <summary>
        /// Generates the parameters for particular driver.
        /// </summary>
        public static IEnumerable<BaseParameter> GenerateCreationOptions(this DatasourceDriver driver)
        {
            string options = driver.get_Metadata(GdalDriverMetadata.CreationOptionList);
            if (string.IsNullOrWhiteSpace(options))
            {
                return new List<BaseParameter>();
            }

            var list = DriverMetadata.ParseOptionList(options).ToList();

            var result = new List<BaseParameter>();

            var exclude = new[] { "boolean", "string-select" };

            result.AddRange(Generate(list.Where(o => o.Type.ToLower() == "boolean")));

            result.AddRange(Generate(list.Where(o => !exclude.Contains(o.Type.ToLower()))));

            result.AddRange(Generate(list.Where(o => o.Type.ToLower() == "string-select")));

            foreach (var p in result)
            {
                p.Name = p.DisplayName;
            }

            return result;
        }

        /// <summary>
        /// Generates the parameters for particular driver.
        /// </summary>
        private static IEnumerable<BaseParameter> Generate(IEnumerable<DriverOption> list)
        {
            foreach (var option in list.OrderByDescending(o => o.Name))
            {
                switch (option.Type.ToLower())
                {
                    case "boolean":
                        {
                            var p = new BooleanParameter()
                            {
                                Description = option.Description,
                                DisplayName = option.Name
                            };

                            bool val;
                            if (Boolean.TryParse(option.DefaultValue, out val))
                            {
                                p.DefaultValue = val;
                            }

                            yield return p;
                        }
                        break;
                    case "string":
                    case "int":
                    case "float":
                        {
                            // Use string parameters for ints and floats or Syncfusion's control will force
                            // some default value on us even if there is none.
                            var p = new StringParameter()
                            {
                                Description = option.Description,
                                DisplayName = option.Name,
                                DefaultValue = option.DefaultValue
                            };

                            yield return p;
                        }
                        break;
                    case "string-select":
                        {
                            var p = new OptionsParameter()
                            {
                                Description = option.Description,
                                DisplayName = option.Name,
                                DefaultValue = option.DefaultValue
                            };

                            var options = option.Values.ToList();
                            options.Insert(0, string.Empty);
                            p.Options = options;

                            yield return p;
                        }
                        break;
                    default:
                        Logger.Current.Warn("Unknown type for GDAL creation option : " + option.Type +
                                            ". Failed to generate UI control.");
                        continue;
                }
            }
        }
    }
}
