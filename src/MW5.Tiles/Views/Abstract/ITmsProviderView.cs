using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Model;
using MW5.Plugins.Mvp;

namespace MW5.Tiles.Views.Abstract
{
    public interface ITmsProviderView: IView<TmsProvider>
    {
        int Id { get; }
        string Url { get; }
        string ProviderName { get; }
        TileProjection Projection { get; }
        int MinZoom { get; }
        int MaxZoom { get; }
        bool UseBounds { get; }
        double MinLat { get; }
        double MaxLat { get; }
        double MinLng { get; }
        double MaxLng { get; }
        string Description { get; }
        event Action ChooseProjection;
    }
}
