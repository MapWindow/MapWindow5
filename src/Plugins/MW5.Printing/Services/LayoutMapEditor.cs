// -------------------------------------------------------------------------------------------
// <copyright file="LayoutMapEditor.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using MW5.Plugins.Printing.Controls.Layout;
using MW5.Plugins.Printing.Model.Elements;

namespace MW5.Plugins.Printing.Services
{
    /// <summary>
    /// Layout Map Editor is a UIType Editor that allows selecting a new map
    /// </summary>
    public class LayoutMapEditor : UITypeEditor
    {
        private IWindowsFormsEditorService _dialogProvider;

        /// <summary>
        /// Ensures that we can widen the drop-down without having to close the drop down,
        /// widen the control, and re-open it again.
        /// </summary>
        public override bool IsDropDownResizable
        {
            get { return false; }
        }

        /// <summary>
        /// Edits a value based on some user input which is collected from a character control.
        /// </summary>
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            _dialogProvider = provider.GetService(typeof(IWindowsFormsEditorService)) as IWindowsFormsEditorService;

            var scaleBar = context.Instance as LayoutScaleBar;
            var legend = context.Instance as LayoutLegend;

            LayoutControl lc = null;

            if (scaleBar != null && scaleBar.LayoutControl != null)
            {
                lc = scaleBar.LayoutControl;
            }
            else if (legend != null && legend.LayoutControl != null)
            {
                lc = legend.LayoutControl;
            }

            var lb = new ListBox();
            if (lc != null)
            {
                foreach (var le in lc.LayoutElements.FindAll(o => (o is LayoutMap)))
                {
                    lb.Items.Add(le);
                }

                lb.SelectedItem = value;
            }
            else
            {
                return null;
            }

            lb.SelectedValueChanged += LbSelectedValueChanged;

            if (_dialogProvider != null)
            {
                _dialogProvider.DropDownControl(lb);
            }

            return lb.SelectedItem;
        }

        /// <summary>
        /// Gets the UITypeEditorEditStyle, which in this case is drop down.
        /// </summary>
        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.DropDown;
        }

        private void LbSelectedValueChanged(object sender, EventArgs e)
        {
            _dialogProvider.CloseDropDown();
        }
    }
}