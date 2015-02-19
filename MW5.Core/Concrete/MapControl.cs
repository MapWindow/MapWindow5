using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AxMapWinGIS;
using MW5.CoreApi.Interfaces;

namespace MW5.CoreApi.Concrete
{
    public class MapControl: IMapControl
    {
        private readonly AxMap _map;

        #region Constructor

        internal MapControl(AxMapWinGIS.AxMap map)
        {
            _map = map;
        }

        #endregion

        #region Properties

        public LayersList Layers { get; private set; }

        #endregion

        #region Static methods
        
        public static MapControl CreateInstance(Control parent, bool dockFill, out Control newMap)
        {
            if (parent == null)
            {
                throw new NullReferenceException("Parent control reference for map is null.");
            }

            var axMap = new AxMapWinGIS.AxMap();
            ((System.ComponentModel.ISupportInitialize)(axMap)).BeginInit();

            axMap.Enabled = true;
            axMap.Location = new System.Drawing.Point(10, 10);
            axMap.Size = new System.Drawing.Size(200, 200);

            parent.Controls.Add(axMap);

            ((System.ComponentModel.ISupportInitialize)(axMap)).EndInit();

            if (dockFill)
            {
                axMap.Dock = DockStyle.Fill;
            }

            newMap = axMap;

            var map = new MapControl(axMap);
            return map;
        }

        #endregion
    }
}
