// This code was borrowed from: http://www.csharp-examples.net/inputbox-class/

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Legacy
{
    public class InputBoxHelper
    {
        /// <summary>
        ///  Displays dialog to receive text input from the user
        /// </summary>
        /// <param name="title"></param>
        /// <param name="promptText"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static DialogResult Show(string title, string promptText, ref string value)
        {
            return Show(title, promptText, ref value, null);
        }

        /// <summary>
        /// Displays dialog to receive text input from the user
        /// </summary>
        public static DialogResult Show(string title, string promptText, ref string value, InputBoxValidation validation)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;
            form.ShowInTaskbar = false;
            if (validation != null)
            {
                // the following code is associated with close event
                form.FormClosing += delegate(object sender, FormClosingEventArgs e)
                {
                    if (form.DialogResult == DialogResult.OK)
                    {
                        string errorText = validation(textBox.Text);
                        if (e.Cancel == (errorText != ""))
                        {
                            MessageBox.Show(form, errorText, "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            textBox.Focus();
                        }
                    }
                };
            }

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }
    }

    public delegate string InputBoxValidation(string errorMessage);
}