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
using System.Windows.Forms;
using MW5.Plugins.Symbology.Controls;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    #region Usings

    

    #endregion

    public partial class AddCategoriesForm : Form
    {
        internal AddCategoriesForm( bool labels)
        {
            InitializeComponent();

            //icbColors.ColorSchemes = _plugin.LayerColors;

            icbColors.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            if (icbColors.Items.Count >= 0)
            {
                icbColors.SelectedIndex = 0;
            }
        }

        /// <summary>
        /// Toggles between graduated and random color scheme
        /// </summary>
        private void chkRandom_CheckedChanged(object sender, EventArgs e)
        {
            int index = icbColors.SelectedIndex;
            if (chkRandom.Checked)
            {
                icbColors.ComboStyle = ImageComboStyle.ColorSchemeRandom;
            }
            else
            {
                icbColors.ComboStyle = ImageComboStyle.ColorSchemeGraduated;
            }

            if (index >= 0 && index < icbColors.Items.Count)
            {
                icbColors.SelectedIndex = index;
            }
        }
    }
}
