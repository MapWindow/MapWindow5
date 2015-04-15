using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Mvp
{
    public static class AppViewFactory
    {
        public static IAppView Instance { get;  internal set; }
    }
}
