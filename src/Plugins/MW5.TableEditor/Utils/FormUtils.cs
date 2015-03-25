// ********************************************************************************************************
// <copyright file="FormUtils.cs" company="TopX Geo-ICT">
//     Copyright (c) 2012 TopX Geo-ICT. All rights reserved.
// </copyright>
// ********************************************************************************************************
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version is Jeen de Vegt.
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date           Changed By      Notes
// 29 March 2012  Jeen de Vegt    Inital coding
// ********************************************************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;

namespace MW5.Plugins.TableEditor.utils
{
    /// <summary>
    ///  Class with form utils
    /// </summary>
    public class FormUtils
    {
        /// <summary>Shows an inputbox</summary>
        /// <param name = "title">The title.</param>
        /// <param name = "promptText">The promptText</param>
        /// <param name = "value">The value entered in the inputbox by ref</param>
        /// <returns>The dialogresult</returns> 
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            form.TopMost = true;

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

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

        /// <summary>Shows an replacebox</summary>
        /// <param name = "search">The string to search for, by ref.</param>
        /// <param name = "replace">The replace value, by ref </param>
        /// <returns>The dialogresult</returns> 
        public static DialogResult ReplaceBox(ref string search, ref string replace)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Label lblReplace = new Label();
            TextBox txtReplace = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = "Replace";
            label.Text = "Search:";
            textBox.Text = search;
            lblReplace.Text = "Replace:";
            txtReplace.Text = replace;
            form.TopMost = true;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            lblReplace.SetBounds(9, 70, 372, 13);
            txtReplace.SetBounds(12, 86, 372, 20);
            buttonOk.SetBounds(228, 120, 75, 23);
            buttonCancel.SetBounds(309, 120, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            txtReplace.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 157);
            form.Controls.AddRange(new Control[] { label, textBox, lblReplace, txtReplace, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            search = textBox.Text;
            replace = txtReplace.Text;
            return dialogResult;
        }

        /// <summary>Shows an messagebox as the topmost</summary>
        /// <param name = "message">The message to show.</param>
        /// <param name = "title">The title</param>
        /// <param name = "buttons">The buttons to show</param>
        /// <returns>The dialogresult</returns> 
        public static DialogResult TopMostMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            Form topmostForm = new Form();

            topmostForm.Size = new System.Drawing.Size(1, 1);
            topmostForm.StartPosition = FormStartPosition.Manual;
            System.Drawing.Rectangle rect = SystemInformation.VirtualScreen;
            topmostForm.Location = new System.Drawing.Point(rect.Bottom + 10, rect.Right + 10);
            topmostForm.Show();
            topmostForm.Focus();
            topmostForm.BringToFront();
            topmostForm.TopMost = true;

            DialogResult result = MessageBox.Show(topmostForm, message, title, buttons);
            topmostForm.Dispose(); 

            return result;
        }

        /// <summary>Shows an messagebox as the topmost</summary>
        /// <param name = "message">The message to show.</param>
        /// <returns>The dialogresult</returns> 
        public static DialogResult TopMostMessageBox(string message)
        {
            return TopMostMessageBox(message, string.Empty, MessageBoxButtons.OK);
        }

        /// <summary>Shows an messagebox as the topmost</summary>
        /// <param name = "message">The message to show.</param>
        /// <param name = "title">The title</param>
        /// <returns>The dialogresult</returns> 
        public static DialogResult TopMostMessageBox(string message, string title)
        {
            return TopMostMessageBox(message, title, MessageBoxButtons.OK);
        }
    }
}
