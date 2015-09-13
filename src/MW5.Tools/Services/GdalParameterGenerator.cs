using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Shared;
using MW5.Tools.Model.Parameters;

namespace MW5.Tools.Services
{
    internal static class GdalParameterGenerator
    {
        public static IEnumerable<BaseParameter> GenerateCreationOptions(this DatasourceDriver driver)
        {
            string options = driver.get_Metadata(Api.Enums.GdalDriverMetadata.CreationOptionList);
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
