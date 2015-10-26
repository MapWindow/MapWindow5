// -------------------------------------------------------------------------------------------
// <copyright file="LayoutLayerEditor.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Controls.PropertyGrid
{
    public class LayoutLayerEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _dialogProvider;

        /// <summary>
        /// Indicates if the drop down can be resized
        /// </summary>
        public override bool IsDropDownResizable
        {
            get { return true; }
        }

        /// <summary>
        /// This gets called when the value is edited
        /// </summary>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _dialogProvider = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            var layerList = new List<int>();

            var layoutLegend = context.Instance as LayoutLegend;

            if (layoutLegend == null || layoutLegend.Map == null || _dialogProvider == null)
            {
                return layerList;
            }

            var clb = new CheckedListBox { CheckOnClick = true };

            if (value != null)
            {
                var layers = layoutLegend.Legend.Layers;

                var values = (List<int>)value;

                foreach (var layer in layers.Reverse())
                {
                    clb.Items.Add(layer.Name, values.Contains(layer.Handle));
                }
            }

            _dialogProvider.DropDownControl(clb);

            for (int i = 0; i <= clb.Items.Count - 1; i++)
            {
                if (clb.GetItemChecked(i))
                {
                    layerList.Add(clb.Items.Count - 1 - i);
                }
            }
            return layerList;
        }

        /// <summary>
        /// Returns the type of UITypeEdirot this creates
        /// </summary>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }
    }
}