using System;
using System.Windows.Forms;
using MW5.Plugins.Services;
using MW5.UI.Forms;

namespace MW5.Plugins.Symbology.Forms
{
    public partial class AddOptionsForm : MapWindowForm
    {
        /// <summary>
        /// Creates a new instance of the frmAddOptions class
        /// </summary>
        public AddOptionsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Prvents user from typing undesired characters
        /// </summary>
        private void txtName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(Char.IsNumber(e.KeyChar) || Char.IsLetter(e.KeyChar) || 
                  Char.IsWhiteSpace(e.KeyChar) || e.KeyChar == (char)Keys.Back))
            {
                e.KeyChar = (char)Keys.Cancel;
            }
        }

        /// <summary>
        /// Checks the name entered by user
        /// </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() == "")
            {
                MessageService.Current.Info("The name can't be empty");
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
}
