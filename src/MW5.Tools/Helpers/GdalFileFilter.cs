using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Tools.Model;

namespace MW5.Tools.Helpers
{
    internal static class GdalFileFilter
    {
        /// <summary>To hold the gdalinfo formats</summary>
        private static List<GdalInfoFormat> gdalInfoFormatList;

        /// <summary>The input filter based on the gdal formats</summary>
        private static string inputFilter;

        /// <summary>The output filter based on the gdal formats</summary>
        private static string outputFilter;

        /// <summary>The input filter based on the ogr formats</summary>
        private static string inputFilterVector;

        /// <summary>The output filter based on the ogr formats</summary>
        private static string outputFilterVector;

        /// <summary>
        /// Gets GdalInfoFormatList.
        /// </summary>
        public static List<GdalInfoFormat> GdalInfoFormatList
        {
            get
            {
                return gdalInfoFormatList ?? (gdalInfoFormatList = GdalFormatHelper.GetGdalFormats());
            }
        }

        /// <summary>
        /// Gets InputFilter.
        /// </summary>
        internal static string Input
        {
            get { return inputFilter ?? (inputFilter = GetInputFilter()); }
        }

        /// <summary>
        /// Gets OutputFilter.
        /// </summary>
        public static string Output
        {
            get { return outputFilter ?? (outputFilter = GetOutputFilter()); }
        }
        
        /// <summary>Create the output filter based on the parsed gdal formats</summary>
        /// <returns>The filter</returns>
        private static string GetOutputFilter()
        {
            var filter = new StringBuilder();

            foreach (var gdalInfoFormat in GdalInfoFormatList.Where(gdalInfoFormat => !string.IsNullOrEmpty(gdalInfoFormat.Extension) 
                                        && gdalInfoFormat.ReadWrite.StartsWith("rw")))
            {
                // Sometimes the long name already shows the extension. No need to do it twice:
                if (gdalInfoFormat.LongName.EndsWith(string.Format(".{0})", gdalInfoFormat.Extension)))
                {
                    filter.AppendFormat("{0}|*.{1}|", gdalInfoFormat.LongName, gdalInfoFormat.Extension);
                }
                else
                {
                    filter.AppendFormat("{0} (*.{1})|*.{1}|", gdalInfoFormat.LongName, gdalInfoFormat.Extension);
                }
            }

            // Remove last |
            return filter.ToString().TrimEnd('|');
        }

        /// <summary>Create the input filter based on the parsed gdal formats</summary>
        /// <returns>The filter</returns>
        private static string GetInputFilter()
        {
            var filter = new StringBuilder("All files (*.*)|*.*");

            foreach (var gdalInfoFormat in GdalInfoFormatList.Where(gdalInfoFormat =>
            !string.IsNullOrEmpty(gdalInfoFormat.Extension)))
            {
                // Sometimes the long name already shows the extension. No need to do it twice:
                if (gdalInfoFormat.LongName.EndsWith(string.Format(".{0})", gdalInfoFormat.Extension)))
                {
                    filter.AppendFormat("|{0}|*.{1}", gdalInfoFormat.LongName, gdalInfoFormat.Extension);
                }
                else
                {
                    filter.AppendFormat("|{0} (*.{1})|*.{1}", gdalInfoFormat.LongName, gdalInfoFormat.Extension);
                }
            }

            // "GeoTiff (*.tif)|*.tif|All files|*.*"
            return filter.ToString();
        }

        /// <summary>Get the shortname based on the output filter to select the correct output item</summary>
        /// <param name="filterIndex">The filter index</param>
        /// <returns>The shortname</returns>
        public static string GetShortNameFromOutputFilter(int filterIndex)
        {
            // Get the cached output filter:
            var filter = Output;

            // Split the filter into an array:
            var filters = filter.Split('|');

            // Get selected filter, each filter has 2 '|':
            var selectedFilter = filters[(filterIndex - 1) * 2];
            var tmp = selectedFilter.Split('(');
            selectedFilter = tmp[0].Trim();

            // Get shortname based on longname:
            var shortname = string.Empty;
            foreach (var gdalInfoFormat in
              GdalInfoFormatList.Where(gdalInfoFormat => gdalInfoFormat.LongName.StartsWith(selectedFilter)))
            {
                shortname = gdalInfoFormat.ShortName;
                break;
            }

            return shortname;
        }
    }
}
