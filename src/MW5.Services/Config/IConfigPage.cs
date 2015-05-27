using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Enums;

namespace MW5.Services.Config
{
    public interface IConfigPage
    {
        string PageName { get; }
        void Save();
        Bitmap Icon { get; }
        bool PluginPage { get; }
        object Tag { get; set; }
        ConfigPageType PageTypeType { get; }
        string Description { get; }
    }
}
