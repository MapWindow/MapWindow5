using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.Model;
using MW5.UI.Controls;

namespace MW5.Plugins.TableEditor.Controls
{
    internal partial class FieldStatsGrid : StronglyTypedGrid<FieldStat>
    {
        public FieldStatsGrid()
        {
            InitializeComponent();

            Adapter.HotTracking = false;
            Adapter.ReadOnly = true;
            Adapter.AllowCurrentCell = false;
        }
    }
}
