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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.UI;

namespace MW5.Plugins.Symbology.Forms.Options
{
    public partial class Options2Form : MapWindowForm
    {
        private readonly List<RadioButton> _list;
        
        /// <summary>
        /// Creates new instance of frmOptions2 class
        /// </summary>
        /// <param name="options">list of options to display</param>
        /// <param name="text">text prompt</param>
        /// <param name="caption">window caption</param>
        public Options2Form(List<string> options, string text, string caption)
        {
            InitializeComponent();
            Text = caption;
            lblText.Text = text;

            if (options == null)
            {
                throw new ArgumentNullException("options");
            }

            _list = new List<RadioButton>();
            for (int i = 0; i < options.Count; i++)
            {
                RadioButton button = new RadioButton();
                _list.Add(button);
                button.Parent = groupBox1;
                button.Left = 20;
                button.Top = 15 + 23 * i;   //43
                button.Text = options[i];
                button.AutoSize = true;
            }

            Height = 140 + 23 * options.Count;
        }

        /// <summary>
        /// Shows the form and returns the index selected options
        /// </summary>
        /// <param name="selectedIndex">The index that will be selected by default</param>
        /// <param name="parent">Parent window.</param>
        public int ShowDialogCustom(int selectedIndex, IWin32Window parent)
        {
            if (selectedIndex >= 0 && selectedIndex < _list.Count)
            {
                _list[selectedIndex].Checked = true;
            }

            // TODO: use application context
            if (ShowDialog(parent) == DialogResult.OK)
            {
                for (int i = 0; i < _list.Count; i++)
                {
                    if (_list[i].Checked)
                    {
                        return i;
                    }
                }
            }
            return -1;
        }
    }
}

