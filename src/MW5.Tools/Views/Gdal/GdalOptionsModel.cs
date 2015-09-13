using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Tools.Views.Gdal
{
    public class GdalOptionsModel
    {
        public GdalOptionsModel(string mainOptions, string additionalOptions)
        {
            MainOptions = mainOptions;
            AdditionalOptions = additionalOptions;
        }

        public string Caption { get; set; }

        public string MainOptions { get; set;}

        public string AdditionalOptions { get; set; }
    }
}
