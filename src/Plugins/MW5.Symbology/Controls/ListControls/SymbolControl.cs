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
using System.ComponentModel;
using System.Drawing;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Symbology.Controls.ListControls
{
    [ToolboxItem(true)]
    internal partial class SymbolControl : ListControl
    {
        private List<IGeometryStyle> _icons = new List<IGeometryStyle>();
        
        /// <summary>
        ///  Creates a new instance of the PointSymbolControl.
        /// </summary>
        public SymbolControl()
        {
            InitializeComponent();
           ItemCount = 17;
           CellWidth = 24;
           CellHeight = 24;

            for (int i = 0; i <ItemCount; i++)
            {
                var sdo = new GeometryStyle();
                sdo.Marker.SetVectorMarker((VectorMarker) i);
                sdo.Marker.Size = 0.8f * CellWidth;
                sdo.Fill.Color = Color.Orange;
                _icons.Add(sdo);
            }
            OnDrawItem += PointSymbolControl_OnDrawItem;
        }

        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                foreach (IGeometryStyle t in _icons)
                {
                    t.Fill.Color = value;
                }
                Redraw();
            }
        }

        /// <summary>
        /// Draws an item from the list
        /// </summary>
        void PointSymbolControl_OnDrawItem(Graphics graphics, RectangleF rect, int itemIndex, bool selected)
        {
            var sdo = _icons[itemIndex];
            sdo.DrawPoint(graphics, rect.X + 1.0f, rect.Y +1.0f, (int)rect.Width -2, (int)rect.Height -2, BackColor);
        }
    }
}
