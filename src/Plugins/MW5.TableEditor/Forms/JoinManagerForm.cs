using System;
using System.Data;
using System.Windows.Forms;
using MapWinGIS;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    /// The frm join manager.
    /// </summary>
    public partial class JoinManagerForm : MapWindowForm
    {
        #region Constructors and Destructors

        /// <summary>
        /// Initializes a new instance of the <see cref="JoinManagerForm"/> class. 
        /// Creates a new instance of the frmJoinManager class
        /// </summary>
        /// <param name="dt"> The dt. </param>
        /// <param name="tbl"> The tbl. </param>
        public JoinManagerForm(DataTable dt, Table tbl)
        {
            InitializeComponent();
            _table = tbl;
            _dt = dt;
            UpdateList();
        }

        #endregion

        #region Constants and Fields

        /// <summary>
        /// The dt.
        /// </summary>
        private readonly DataTable _dt;

        /// <summary>
        /// The table.
        /// </summary>
        private readonly Table _table;

        #endregion

        #region Methods

        /// <summary>
        /// Opens form to edit selected join
        /// </summary>
        private void EditJoin()
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show(@"Select a datasource", @"Table editor", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                var index = listView1.SelectedIndices[0];
                var filename = _table.get_JoinFilename(index);
                if (filename.ToLower().EndsWith(".dbf"))
                {
                    var form = new JoinNativeForm(_dt, _table, filename, index);
                    form.ShowDialog(this);
                    UpdateList();
                }
                else
                {
                    MessageBox.Show(
                        @"Editing unavailable for this data source", @"Table editor", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }

        /// <summary>
        /// Updates state of the buttons after user actions
        /// </summary>
        private void UpdateControls()
        {
            btnStop.Enabled = listView1.SelectedItems.Count != 0;
            btnEditJoin.Enabled = listView1.SelectedItems.Count != 0;
            btnStopAll.Enabled = listView1.Items.Count > 0;
        }

        /// <summary>
        /// Fills the listview with joins
        /// </summary>
        private void UpdateList()
        {
            listView1.Items.Clear();
            for (var i = 0; i < _table.JoinCount; i++)
            {
                var item = listView1.Items.Add(_table.get_JoinFilename(i));
                item.SubItems.Add(_table.get_JoinFromField(i));
                item.SubItems.Add(_table.get_JoinToField(i));
                item.Selected = true;
            }

            if (listView1.Items.Count > 0)
            {
                listView1.Items[0].Selected = true;
            }

            UpdateControls();
        }

        /// <summary>
        /// Opens form to edit selected join
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnEditJoinClick(object sender, EventArgs e)
        {
            EditJoin();
        }

        /// <summary>
        /// Opens form to create a new join
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnJoinClick(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter =
                    @"Dbf tables (*.dbf)|*.dbf|Excel workbooks (*.xls, *.xlsx)|*.xls;*.xlsx|CSV files (*.csv)|*.csv",
                FilterIndex = 0
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                if (dialog.FileName.ToLower().EndsWith(".dbf"))
                {
                    var form = new JoinNativeForm(_dt, _table, dialog.FileName, -1);
                    form.ShowDialog(this);
                }
                else
                {
                    var form = new JoinExcelForm(_dt, _table, dialog.FileName, -1);
                    form.ShowDialog(this);
                }

                UpdateList();
            }
        }

        /// <summary>
        /// Stops all join operations
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnStopAllClick(object sender, EventArgs e)
        {
            _table.StopAllJoins();
            MessageBox.Show(@"All joins are stopped", @"Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            UpdateList();
        }

        /// <summary>
        /// Stops the selected join
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void BtnStopClick(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 1)
            {
                MessageBox.Show(@"Select a datasource", @"Table editor", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                var index = listView1.SelectedIndices[0];
                var name = _table.get_JoinFilename(index);
                if (_table.StopJoin(index))
                {
                    MessageBox.Show(@"Join is stopped: " + name, @"Table editor", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }

                UpdateList();
            }
        }

        /// <summary>
        /// Opens editing form
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ListView1MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var info = listView1.HitTest(e.Location);
            if (info.Item != null)
            {
                EditJoin();
            }
        }

        /// <summary>
        /// Updates buttons
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void ListView1SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateControls();
        }

        #endregion
    }
}