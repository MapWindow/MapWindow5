using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Menu
{
    internal static class MenuKeys
    {
        public const string Labels = "sy_Labels";
        public const string Charts = "sy_Charts";
        public const string QueryBuilder = "sy_QueryBuilder";
        public const string Categories = "sy_Categories";
        public const string LabelMover = "sy_LabelMover";

        public static string LayerProperties
        {
            get { return MW5.Plugins.Menu.MenuKeys.LayerProperties;  }
        }
    }
}
