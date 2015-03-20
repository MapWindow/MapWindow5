// ********************************************************************************************************
// <copyright file="MWLite.Symbology.cs" company="MapWindow.org">
// Copyright (c) MapWindow.org. All rights reserved.
// </copyright>
// The contents of this file are subject to the Mozilla Public License Version 1.1 (the "License"); 
// you may not use this file except in compliance with the License. You may obtain a copy of the License at 
// http:// Www.mozilla.org/MPL/ 
// Software distributed under the License is distributed on an "AS IS" basis, WITHOUT WARRANTY OF 
// ANY KIND, either express or implied. See the License for the specificlanguage governing rights and 
// limitations under the License. 
// 
// The Initial Developer of this version of the Original Code is Sergei Leschinski
// 
// Contributor(s): (Open source contributors should list themselves and their modifications here). 
// Change Log: 
// Date            Changed By      Notes
// ********************************************************************************************************

using System.Collections.Generic;
using System.Windows.Forms;

namespace MW5.Plugins.Symbology.Forms.Utilities
{
    public partial class frmOptions2 : Form
    {
        List<RadioButton> _list = null;
        
        /// <summary>
        /// Creates new instance of frmOptions2 class
        /// </summary>
        /// <param name="options">list of options to display</param>
        /// <param name="text">text prompt</param>
        /// <param name="caption">window caption</param>
        public frmOptions2(List<string> options, string text, string caption)
        {
            InitializeComponent();
            this.Text = caption;
            lblText.Text = text;

            if (options == null)
            {
                // TODO: raise error
                return;
            }

            _list = new List<RadioButton>();
            for (int i = 0; i < options.Count; i++)
            {
                RadioButton button = new RadioButton();
                _list.Add(button);
                button.Parent = this.groupBox1;
                button.Left = 20;
                button.Top = 15 + 23 * i;   //43
                button.Text = options[i];
                button.AutoSize = true;
            }

            this.Height = 140 + 23 * options.Count;
        }

        /// <summary>
        /// Shows the form and returns the index selected options
        /// </summary>
        /// <param name="SelectedIndex">The index that will be selected by default</param>
        /// <returns></returns>
        public int ShowDialogCustom(int selectedIndex)
        {
            if (selectedIndex >= 0 && selectedIndex < _list.Count)
                _list[selectedIndex].Checked = true;
            
            if (this.ShowDialog() == DialogResult.OK)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    if (_list[i].Checked)
                        return i;
                }
                return -1;
            }
            else
                return -1;
        }
    }
}
