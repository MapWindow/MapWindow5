using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BruTile.Wms;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Tiles.Views.Abstract
{
    internal interface IWmsCapabilitiesView : IComplexView<WmsCapabilitiesModel>
    {
        WmsServer Server { get; }

        void ShowHourglass();

        void HideHourglass();

        IEnumerable<Layer> SelectedLayers { get; }

        event Action LayerDoubleClicked;
    }
}
