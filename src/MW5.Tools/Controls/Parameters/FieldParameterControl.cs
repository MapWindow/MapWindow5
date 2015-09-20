// -------------------------------------------------------------------------------------------
// <copyright file="FieldParameterControl.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Tools.Controls.Parameters.Interfaces;
using MW5.Tools.Model.Layers;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents control for the field name selection. Must be bound to particular LayerParameterControl.
    /// </summary>
    internal partial class FieldParameterControl : ParameterControlBase, IInputListener
    {
        public FieldParameterControl()
        {
            InitializeComponent();

            btnOpen.Visible = false;
        }

        /// <summary>
        /// Gets or sets control caption.
        /// </summary>
        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return comboBoxAdv1; }
        }

        /// <summary>
        /// Gets the value.
        /// </summary>
        /// <returns>
        /// Value type that must match the type of parameter the control was generated for.
        /// </returns>
        public override object GetValue()
        {
            var fld = comboBoxAdv1.SelectedItem as AttributeField;
            int fieldIndex = fld != null ? fld.Index : -1;
            return fieldIndex;
        }

        /// <summary>
        /// Called when selected layer is changed.
        /// </summary>
        public void OnLayerChanged(IDatasourceInput input)
        {
            var vector = input as IVectorInput;
            if (vector != null)
            {
                RebuildFieldList(vector.Datasource);
            }
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        /// <param name="value">Value type must match the type of parameter the control was generated for.</param>
        public override void SetValue(object value)
        {
            // do nothing
        }

        /// <summary>
        /// Rebuilds the field list.
        /// </summary>
        private void RebuildFieldList(IFeatureSet fs)
        {
            comboBoxAdv1.Items.Clear();

            if (fs != null)
            {
                foreach (var fld in fs.Fields)
                {
                    comboBoxAdv1.Items.Add(fld);
                }
            }

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
        }
    }
}