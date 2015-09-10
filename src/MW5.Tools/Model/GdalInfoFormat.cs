using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Model
{
      /// <summary>
      /// Represents GDAL format options.
      /// </summary>
      public class GdalInfoFormat
      {
        /// <summary>
        /// Gets or sets ShortName.
        /// </summary>
        public string ShortName { get; set; }

        /// <summary>
        /// Gets or sets LongName.
        /// </summary>
        public string LongName { get; set; }

        /// <summary>
        /// Gets or sets Extension.
        /// </summary>
        public string Extension { get; set; }

        /// <summary>
        /// Gets or sets ReadWrite.
        /// </summary>
        public string ReadWrite { get; set; }

        /// <summary>
        /// Gets or sets Help.
        /// </summary>
        public string Help { get; set; }

        /// <summary>To string</summary>
        /// <returns>The formatted string</returns>
        public override string ToString()
        {
          return string.Format(
            "Shortname: {0} Longname: {1} Extension: {2} ReadWrite: {3} Help: {4}",
            ShortName,
            LongName, 
            Extension, 
            ReadWrite, 
            Help);
        }
    }
}
