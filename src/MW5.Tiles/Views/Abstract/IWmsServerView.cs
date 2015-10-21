using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Concrete;
using MW5.Plugins.Mvp;

namespace MW5.Tiles.Views.Abstract
{
    internal interface IWmsServerView: IView<WmsServer>
    {
        string ServerName { get; }

        string Url { get; }
    }
}
