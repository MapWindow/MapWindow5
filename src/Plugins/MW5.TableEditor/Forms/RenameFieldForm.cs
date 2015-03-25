using System;
using System.Data;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for renaming a field
    /// </summary>
    public partial class RenameFieldForm : Form
    {
        /// <summary>The datatable with shape-data</summary> 
        private readonly DataTable dt;

        /// <summary>Initializes a new instance of the frmRenameField class</summary>
        /// <param name = "dataTable">The datatable.</param>
        public RenameFieldForm(DataTable dataTable)
        {
            InitializeComponent();

            dt = dataTable;

            var names = ShapeData.GetVisibleFieldNames(dt);
            cmbField.Items.AddRange(names);
        }

        /// <summary>Enable the OK-button if a field is selected</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void cmbField_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = true;
        }

        /// <summary>Change the fieldname</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            var errorMessage = string.Empty;

            // Check if name is valid
            if (!ShapeData.IsNameValid(txtNewName.Text, dt, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
            }
            else
            {
                dt.Columns[cmbField.SelectedIndex + 1].ColumnName = txtNewName.Text;
                DialogResult = DialogResult.OK;
            }
        }
    }
}