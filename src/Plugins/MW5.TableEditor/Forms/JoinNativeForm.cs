using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using MapWinGIS;

namespace MW5.Plugins.TableEditor.Forms
{
    public partial class JoinNativeForm : Form
    {
        private DataTable dt;
        private readonly string filename = "";
        private readonly int joinIndex = -1;
        private readonly Table table;
        private readonly Table tableNew;

        /// <summary>
        /// Creates a new instance of the frmNativeJoin class
        /// </summary>
        public JoinNativeForm(DataTable dt, Table tbl, string filename, int joinIndex)
        {
            InitializeComponent();
            this.dt = dt;
            table = tbl;
            this.filename = filename;
            this.joinIndex = joinIndex;
            FillCombo(cboCurrent, table, false);

            tableNew = new Table();
            if (tableNew.Open(filename, null))
            {
                FillCombo(cboExternal, tableNew, true);
                FillList(listView1.Items, tableNew, false);
                updateMatchingRowCount();
            }
            else
            {
                MessageBox.Show("Failed to open dbf table: " + tbl.get_ErrorMsg(tbl.LastErrorCode));
            }

            if (this.joinIndex != -1)
            {
                ShowJoinOptions(); // we are editing join
            }
        }

        /// <summary>
        /// Displays fields acting in the join being edited
        /// </summary>
        private void ShowJoinOptions()
        {
            var f1 = table.get_JoinToField(joinIndex);
            var f2 = table.get_JoinFromField(joinIndex);
            foreach (var f in cboCurrent.Items)
            {
                if ((f as FieldWrapper).field.Name == f1)
                    cboCurrent.SelectedItem = f;
            }
            foreach (var f in cboExternal.Items)
            {
                if ((f as FieldWrapper).field.Name == f2)
                    cboExternal.SelectedItem = f;
            }
            for (var i = 0; i < table.NumFields; i++)
            {
                if (table.get_FieldJoinIndex(i) == joinIndex)
                {
                    var item = listView1.FindItemWithText(table.get_Field(i).Name);
                    if (item != null)
                    {
                        item.Checked = true;
                    }
                }
            }
        }

        /// <summary>
        /// Fills combobox object collection with list of fields
        /// </summary>
        /// <param name="list"></param>
        /// <param name="table"></param>
        /// <param name="filter"></param>
        private void FillList(IList list, Table tbl, bool filter)
        {
            list.Clear();
            if (tbl != null)
            {
                for (var i = 0; i < tbl.NumFields; i++)
                {
                    var wr = cboCurrent.SelectedItem as FieldWrapper;
                    if (filter && wr != null && wr.field.Type != tbl.get_Field(i).Type)
                        continue;

                    list.Add(new FieldWrapper(tbl.get_Field(i)));
                }
            }
        }

        /// <summary>
        /// Fills combobox with list of fields
        /// </summary>
        /// <param name="combo"></param>
        /// <param name="table"></param>
        /// <param name="filter"></param>
        private void FillCombo(ComboBox combo, Table table, bool filter)
        {
            FillList(combo.Items, table, filter);
            if (combo.Items.Count > 0)
            {
                combo.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Updates list of external fiedls depending on the field type in the current list
        /// </summary>
        private void cboCurrent_SelectedIndexChanged(object sender, EventArgs e)
        {
            var wrapper = cboCurrent.SelectedItem as FieldWrapper;
            if (wrapper != null)
            {
                FillCombo(cboExternal, tableNew, true);
            }
        }

        /// <summary>
        /// Checks/unchecks fields for copying in join operation
        /// </summary>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in listView1.Items)
                item.Checked = chkAll.Checked;
        }

        /// <summary>
        /// Updates the number of matching rows
        /// </summary>
        private void cboExternal_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateMatchingRowCount();
        }

        /// <summary>
        /// Displays the number of matching rows for a chosen pair of fields
        /// </summary>
        private void updateMatchingRowCount()
        {
            var fld1 = cboCurrent.SelectedItem as FieldWrapper;
            var fld2 = cboExternal.SelectedItem as FieldWrapper;

            int count1, count2;
            if (!table.TryJoin(tableNew, fld1.ToString(), fld2.ToString(), out count1, out count2))
            {
                count1 = count2 = 0;
                //MessageBox.Show("Failed to join: " + this.table.get_ErrorMsg(this.table.LastErrorCode));
            }

            lblMatch.Text = "Matching rows: " + count1;
            lblMatchJoin.Text = "Matching rows: " + count2;
        }

        /// <summary>
        /// Performs the join operation and updates the datasource for data grid
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select columns to include in the table", "Table editor", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else
            {
                var fld1 = cboCurrent.SelectedItem as FieldWrapper;
                var fld2 = cboExternal.SelectedItem as FieldWrapper;

                var list = new List<string>();
                foreach (ListViewItem item in listView1.CheckedItems)
                {
                    list.Add(item.Text);
                }

                if (fld1 == null || fld2 == null)
                {
                    MessageBox.Show("No key field for join is selected");
                }
                else
                {
                    if (joinIndex != -1)
                    {
                        table.StopJoin(joinIndex);
                    }

                    var result = table.Join3(tableNew, fld1.ToString(), fld2.ToString(), filename, "", list.ToArray());
                    MessageBox.Show(result ? "Joining is successful" : "Joining has failed");
                    DialogResult = result ? DialogResult.OK : DialogResult.Cancel;
                }
            }
        }

        private class FieldWrapper
        {
            public readonly Field field;

            public FieldWrapper(Field field)
            {
                this.field = field;
            }

            public override String ToString()
            {
                return field.Name;
            }
        }
    }
}