using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Tiles.Model;

namespace MW5.Tiles.Views.Abstract
{
    internal interface IProvidersView: IComplexView<TmsProviderList>
    {
        TmsProvider SelectedProvider { get; }
    }
}
