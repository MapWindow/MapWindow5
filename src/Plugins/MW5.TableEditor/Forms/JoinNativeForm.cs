
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
        private Table table = null;
        private Table tableNew = null;
        private string filename = "";
        private int joinIndex = -1;

        private class FieldWrapper
        {
            public Field field;
            public FieldWrapper(Field field)
            {
                this.field = field;
            }
            public override String ToString()
            {
                return this.field.Name;
            }
        }

        /// <summary>
        /// Creates a new instance of the frmNativeJoin class
        /// </summary>
        public JoinNativeForm(DataTable dt, Table tbl, string filename, int joinIndex)
        {
            InitializeComponent();
            this.dt = dt;
            this.table = tbl;
            this.filename = filename;
            this.joinIndex = joinIndex;
            this.FillCombo(this.cboCurrent, table, false);

            this.tableNew = new Table();
            if (tableNew.Open(filename, null))
            {
                this.FillCombo(this.cboExternal, this.tableNew, true);
                this.FillList(this.listView1.Items, tableNew, false);
                this.updateMatchingRowCount();
            }
            else
            {
                MessageBox.Show("Failed to open dbf table: " + tbl.get_ErrorMsg(tbl.LastErrorCode));
            }

            if (this.joinIndex != -1)
            {
                this.ShowJoinOptions();     // we are editing join
            }
        }

        /// <summary>
        /// Displays fields acting in the join being edited
        /// </summary>
        private void ShowJoinOptions()
        {
            string f1 = table.get_JoinToField(this.joinIndex);
            string f2 = table.get_JoinFromField(this.joinIndex);
            foreach (object f in cboCurrent.Items)
            {
                if ((f as FieldWrapper).field.Name == f1)
                    cboCurrent.SelectedItem = f;
            }
            foreach (object f in cboExternal.Items)
            {
                if ((f as FieldWrapper).field.Name == f2)
                    cboExternal.SelectedItem = f;
            }
            for (int i = 0; i < table.NumFields; i++)
            {
                if (table.get_FieldJoinIndex(i) == this.joinIndex)
                {
                    ListViewItem item = this.listView1.FindItemWithText(table.get_Field(i).Name);
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
                for (int i = 0; i < tbl.NumFields; i++)
                {
                    FieldWrapper wr = cboCurrent.SelectedItem as FieldWrapper;
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
            this.FillList(combo.Items, table, filter);
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
            FieldWrapper wrapper = cboCurrent.SelectedItem as FieldWrapper;
            if (wrapper != null)
            {
                this.FillCombo(this.cboExternal, this.tableNew, true);
            }
        }

        /// <summary>
        /// Checks/unchecks fields for copying in join operation
        /// </summary>
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (ListViewItem item in this.listView1.Items)
                item.Checked = chkAll.Checked;
        }

        /// <summary>
        /// Updates the number of matching rows
        /// </summary>
        private void cboExternal_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.updateMatchingRowCount();
        }

        /// <summary>
        /// Displays the number of matching rows for a chosen pair of fields
        /// </summary>
        private void updateMatchingRowCount()
        {
            FieldWrapper fld1 = cboCurrent.SelectedItem as FieldWrapper;
            FieldWrapper fld2 = cboExternal.SelectedItem as FieldWrapper;

            int count1, count2;
            if (!this.table.TryJoin(this.tableNew, fld1.ToString(), fld2.ToString(), out count1, out count2))
            {
                count1 = count2 = 0;
                //MessageBox.Show("Failed to join: " + this.table.get_ErrorMsg(this.table.LastErrorCode));
            }

            this.lblMatch.Text = "Matching rows: " + count1;
            this.lblMatchJoin.Text = "Matching rows: " + count2;
        }

        /// <summary>
        /// Performs the join operation and updates the datasource for data grid
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.listView1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Select columns to include in the table", "Table editor", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                FieldWrapper fld1 = cboCurrent.SelectedItem as FieldWrapper;
                FieldWrapper fld2 = cboExternal.SelectedItem as FieldWrapper;

                List<String> list = new List<string>();
                foreach (ListViewItem item in this.listView1.CheckedItems)
                {
                    list.Add(item.Text);
                }

                if (fld1 == null || fld2 == null)
                {
                    MessageBox.Show("No key field for join is selected");
                }
                else
                {
                    if (this.joinIndex != -1)
                    {
                        table.StopJoin(this.joinIndex);
                    }
                    
                    bool result = this.table.Join3(this.tableNew, fld1.ToString(), fld2.ToString(), this.filename, "", list.ToArray());
                    MessageBox.Show(result ? "Joining is successful" : "Joining has failed");
                    this.DialogResult = result ? DialogResult.OK : DialogResult.Cancel;
                }
            }
        }
    }
}
