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
using MW5.Api.Legend.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Controls;

namespace MW5.Controls
{
    public partial class LegendDockPanel : DockPanelControlBase, IMenuProvider
    {
        private readonly IAppContext _context;

        public LegendDockPanel(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
            InitializeComponent();

            legendControl1.LayerMouseUp += LegendLayerMouseUp;
            legendControl1.GroupMouseUp += LegendGroupMouseUp;
            legendControl1.LegendClick += OnLegendClick;
        }

        public event KeyEventHandler LegendKeyDown
        {
            add { legendControl1.KeyDown += value; }
            remove { legendControl1.KeyDown -= value; }
        }

        public int SelectedGroupHandle { get; private set; }

        public IMuteLegend Legend
        {
            get { return legendControl1; }
        }

        private void LegendGroupMouseUp(object sender, GroupMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                SelectedGroupHandle = e.GroupHandle;
                var pnt = PointToClient(Cursor.Position);
                contextMenuGroup.Show(this, pnt);
            }
        }

        private void LegendLayerMouseUp(object sender, LayerMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                Legend.SelectedLayerHandle = e.LayerHandle;

                var group = Legend.Groups.GroupByLayerHandle(e.LayerHandle);
                if (group != null)
                {
                    SelectedGroupHandle = group.Handle;
                }

                var pnt = PointToClient(Cursor.Position);
                contextMenuLayer.Show(this, pnt);
            }
        }

        private void OnLegendClick(object sender, LegendClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var pnt = PointToClient(Cursor.Position);
                contextMenuGroup.Show(this, pnt);
            }
        }

        public IEnumerable<ToolStripItemCollection> ToolStrips
        {
            get 
            {
                yield return contextMenuLayer.Items;
                yield return contextMenuGroup.Items;
            }
        }

        public IEnumerable<Control> Buttons
        {
            get { yield break; }
        }

        private void OnContextMenuLayerOpening(object sender, CancelEventArgs e)
        {
            var layer = _context.Layers.Current;
            if (layer != null)
            {
                toolLabels.Enabled = layer.IsVector;
                toolTableEditor.Enabled = layer.IsVector;
            }
        }
    }
}
