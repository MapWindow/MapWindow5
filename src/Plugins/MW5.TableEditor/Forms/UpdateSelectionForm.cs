using System;
using System.Windows.Forms;
using MW5.Api;
using MW5.Api.Enums;
using MW5.UI;
using MW5.UI.Forms;

namespace MW5.Plugins.TableEditor.Forms
{
    /// <summary>
    ///  Form-class for updating a selection
    /// </summary>
    public partial class UpdateSelectionForm : MapWindowForm
    {
        /// <summary>Initializes a new instance of the frmUpdateSelection class</summary>
        /// <param name = "numShapes">The amount of shapefile.</param>
        public UpdateSelectionForm(int numShapes)
        {
            InitializeComponent();

            lblNumOfShapes.Text = string.Format("Number of shapes = {0}", numShapes);

            FillOptions();
        }

        /// <summary>Gets the selected operation</summary>
        public SelectionOperation SelectedOption
        {
            get { return (SelectionOperation) lbOptions.SelectedIndex; }
        }

        /// <summary>Fill the operation-options in the control</summary>
        private void FillOptions()
        {
            lbOptions.Items.Add("1 - New selection");
            lbOptions.Items.Add("2 - Add to selection");
            lbOptions.Items.Add("3 - Exclude from selection");
            lbOptions.Items.Add("4 - Invert in selection");
        }

        /// <summary>Performs the operation</summary>
        /// <param name = "sender">The sender of the event.</param>
        /// <param name = "e">The arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (lbOptions.SelectedIndex == -1)
            {
                MessageBox.Show("Please select an option.");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}