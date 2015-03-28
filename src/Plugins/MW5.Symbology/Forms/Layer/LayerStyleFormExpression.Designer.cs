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
using MW5.Plugins.Symbology.Forms.Categories;

namespace MW5.Plugins.Symbology.Forms.Layer
{
    partial class LayerStyleForm
    {
        /// <summary>
        /// Building layer visibility expression
        /// </summary>
        private void btnLayerExpression_Click(object sender, EventArgs e)
        {
            string s = txtLayerExpression.Text;
            var layer = _context.Layers.ItemByHandle(_layer.Handle);
            using (var form = new QueryBuilderForm(layer, s, false)) 
            {
                if (_context.View.ShowChildView(form, this))
                {
                    txtLayerExpression.Text = form.Tag.ToString();
                    _shapefile.VisibilityExpression = txtLayerExpression.Text;
                    RedrawMap();
                }
            }
        }

        /// <summary>
        /// Clears the layer expression
        /// </summary>
        private void btnClearLayerExpression_Click(object sender, EventArgs e)
        {
            txtLayerExpression.Clear();
            _shapefile.VisibilityExpression = "";
            RedrawMap();
        }
    }
}
