using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Core.Interfaces;
using MW5.Plugins;

namespace MW5.GuiTest
{
    public class AppContext: IAppContext
    {
        public IMapControl Map
        {
            get { return null; }
        }
    }
}
