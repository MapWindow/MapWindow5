using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Helpers;

namespace MW5.Views
{
    public partial class PluginTestForm : Form
    {
        public PluginTestForm()
        {
            InitializeComponent();

            InitMap();

            //AppContext.Init(_mapControl1);
        }

        private void InitMap()
        {
            _mapControl1.Tiles.set_IsCaching(CacheType.Disk, true);
            _mapControl1.Projection = MapProjection.GoogleMercator;
            _mapControl1.KnownExtents = KnownExtents.Germany;
        }
    }
}
