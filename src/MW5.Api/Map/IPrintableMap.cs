using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Events;
using MW5.Api.Interfaces;

namespace MW5.Api.Map
{
    public interface IPrintableMap
    {
        ILayerCollection<ILayer> Layers { get; }
        LengthUnits MapUnits { get; set; }
        ISpatialReference Projection { get; set; }
        IEnvelope Extents { get; }
        bool ScalebarVisible { get; set; }
        void Lock();
        bool Unlock();
        bool SnapShotToDC2(IntPtr hDC, IEnvelope extents, int width, float offsetX, float offsetY, float clipX, float clipY, float clipWidth, float clipHeight);
        bool LoadTilesForSnapshot(IEnvelope extents, int width, string key);
        TileManager Tiles { get; }
        event EventHandler<TilesLoadedEventArgs> TilesLoaded;
        void SetTileProvider(int providerId);
    }
}
