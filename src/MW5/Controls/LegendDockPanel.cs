using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Legend.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Controls
{
    public partial class LegendDockPanel : UserControl, IMenuProvider
    {
        public LegendDockPanel()
        {
            InitializeComponent();

            legendControl1.LayerMouseUp += LegendLayerMouseUp;
        }

        public IMuteLegend Legend
        {
            get { return legendControl1; }
        }

        private void LegendLayerMouseUp(object sender, Api.Legend.Events.LayerMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pnt = PointToClient(Cursor.Position);
                contextMenuStripEx1.Show(this, pnt);
            }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get 
            {
                yield return contextMenuStripEx1.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        public IEnumerable<IToolbar> Toolbars
        {
            get { yield break; }
        }
    }
}
