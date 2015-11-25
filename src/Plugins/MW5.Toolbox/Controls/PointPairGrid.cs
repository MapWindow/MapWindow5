using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Toolbox.Model;
using MW5.UI.Controls;

namespace MW5.Plugins.Toolbox.Controls
{
    internal partial class PointPairGrid : StronglyTypedGrid<PointPair>
    {
        public PointPairGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = false;
            Adapter.AllowCurrentCell = false;
        }

        protected override void UpdateColumns()
        {
            // do nothing
            Adapter.HideColumns();

            Adapter.ShowColumn(p => p.Selected);
            Adapter.ShowColumn(p => p.Index);
            Adapter.ShowColumn(p => p.X1);
            Adapter.ShowColumn(p => p.Y1);
            Adapter.ShowColumn(p => p.X2);
            Adapter.ShowColumn(p => p.Y2);
            Adapter.ShowColumn(p => p.DeviationString);
        }
    }
}
