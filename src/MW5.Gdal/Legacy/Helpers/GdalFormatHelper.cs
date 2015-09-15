using System;
using System.Collections.Generic;
using System.IO;
using MW5.Api.Static;
using MW5.Gdal.Model;

namespace MW5.Gdal.Legacy.Helpers
{
    internal static class GdalFormatHelper
    {
        /// <summary>
        /// Parses --formats and --format into a class
        /// </summary>
        public static List<GdalInfoFormat> GetGdalFormats()
        {
            var list = new List<GdalInfoFormat>();

            // First get all formats
            var gdalFormats = GdalUtils.Instance.GdalInfo("", "--formats");

            using (var reader = new StringReader(gdalFormats))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    if (line.StartsWith("Supported Formats"))
                    {
                        continue;
                    }

                    var step1 = Array.ConvertAll(line.Split(':'), p => p.Trim());

                    var step2 = Array.ConvertAll(step1[0].Split(' '), p => p.Trim());
                    if (string.IsNullOrEmpty(step2[0]))
                    {
                        continue;
                    }

                    var step3 = step2[1].Replace("(", string.Empty).Replace(")", string.Empty);

                    var format = new GdalInfoFormat { ShortName = step2[0], LongName = step1[1], ReadWrite = step3 };

                    // Get format details:
                    var param = "--format " + format.ShortName;
                    var result = GdalUtils.Instance.GdalInfo(string.Empty, param);

                    if (result != null)
                    {
                        using (var secondReader = new StringReader(result))
                        {
                            while ((line = secondReader.ReadLine()) != null)
                            {
                                var step4 = Array.ConvertAll(line.Split(':'), p => p.Trim());

                                switch (step4[0])
                                {
                                    case "Extension":
                                        format.Extension = step4[1];
                                        break;
                                    case "Help Topic":
                                        format.Help = step4[1];
                                        break;
                                }
                            }
                        }

                        // Add to the list
                        list.Add(format);
                    }
                }
            }

            return list;
        }
    }
}
