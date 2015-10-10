using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tiles.Views.Abstract
{
    internal interface IWmsCapabilitiesView : IComplexView<WmsCapabilitiesModel>
    {
        string ServerUrl { get; }

        void ShowHourglass();

        void HideHourglass();
    }
}
