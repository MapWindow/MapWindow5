using System;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Forms.Utilities
{
    public partial class frmAddOptions : Form
    {
        /// <summary>
        /// Creates a new instance of the frmAddOptions class
        /// </summary>
        public frmAddOptions()
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
                MessageBox.Show("The name can't be empty", "Enter name", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
