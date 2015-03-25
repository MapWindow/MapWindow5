using System;
using System.Data;
using System.Windows.Forms;
using MW5.Plugins.TableEditor.BO;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for adding a new field
    /// </summary>
    public partial class NewFieldForm : Form
    {
        /// <summary>The datatable with shapedata</summary>
        private readonly DataTable _dt;

        /// <summary>Initializes a new instance of the frmNewField class</summary>
        /// <param name = "dataTable">The datatable.</param>
        public NewFieldForm(DataTable dataTable)
        {
            InitializeComponent();
            _dt = dataTable;
        }

        /// <summary>Add the new field</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            var errorMessage = string.Empty;

            if (!ShapeData.IsNameValid(txtFieldName.Text, _dt, ref errorMessage))
            {
                MessageBox.Show(errorMessage);
                DialogResult = DialogResult.Cancel;
                return;
            }

            ShapeData.AddDataColumn(_dt, txtFieldName.Text, cmbFieldType.Text
                , fldPrecision.Value.ToString(), Convert.ToInt32(fldWidth.Value));
            DialogResult = DialogResult.OK;
        }

        /// <summary>Enable the control Precision if fieldtype 'double' is selected</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void cmbFieldType_SelectedIndexChanged(object sender, EventArgs e)
        {
            fldPrecision.Enabled = cmbFieldType.Text == "Double";
            lblPrecision.Enabled = cmbFieldType.Text == "Double";
        }
    }
}