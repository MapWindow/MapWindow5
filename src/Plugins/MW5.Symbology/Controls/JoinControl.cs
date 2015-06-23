// -------------------------------------------------------------------------------------------
// <copyright file="JoinControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class JoinControl : UserControl
    {
        private IAppContext _context;
        private IAttributeTable _table;

        public event Action JoinsChanged;

        public JoinControl()
        {
            InitializeComponent();
            joinsGrid1.WrapWithPanel = false;
            joinsGrid1.JoinDoubleClicked += EditJoin;
        }

        private FieldJoin SelectedJoin
        {
            get { return joinsGrid1.Adapter.SelectedItem; }
        }

        public void Initialize(IAppContext context, IAttributeTable table)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (table == null) throw new ArgumentNullException("table");
            _table = table;
            _context = context;

            UpdateView();
        }

        private void RefreshControls()
        {
            bool hasSelection = joinsGrid1.Adapter.SelectedItem != null;
            toolEdit.Enabled = hasSelection;
            toolStop.Enabled = hasSelection;
            toolStopAll.Enabled = _table.Joins.Any();
        }

        private void UpdateView()
        {
            var list = _table.Joins.ToList();
            joinsGrid1.DataSource = list;
            joinsGrid1.Adapter.SelectLastRow();
            joinsGrid1.SelectedRecordsChanged += (s, e) => RefreshControls();

            RefreshControls();
        }

        private void toolAdd_Click(object sender, EventArgs e)
        {
            if (JoinHelper.AddJoin(_context, _table))
            {
                UpdateView();
                FireJoinsChanged();
            }
        }

        private void toolEdit_Click(object sender, EventArgs e)
        {
            EditJoin();
        }

        private void EditJoin()
        {
            if (JoinHelper.EditJoin(_context, _table, SelectedJoin))
            {
                UpdateView();
                FireJoinsChanged();
            }
        }

        private void toolStopAll_Click(object sender, EventArgs e)
        {
            if (JoinHelper.StopAllJoins(_table))
            {
                UpdateView();
                FireJoinsChanged();
            }
        }

        private void toolStop_Click(object sender, EventArgs e)
        {
            if (JoinHelper.StopJoin(_table, SelectedJoin))
            {
                UpdateView();
                FireJoinsChanged();
            }
        }

        private void FireJoinsChanged()
        {
            var handler = JoinsChanged;
            if (handler != null)
            {
                handler();
            }
        }
    }
}