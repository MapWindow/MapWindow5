using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Enums;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Properties;

namespace MW5.Tools.Controls.Parameters
{
    /// <summary>
    /// Represents combobox with a list of layers and a button to open datasource from disk.
    /// </summary>
    internal partial class FieldParameterControl : ParameterControlBase
    {
        public FieldParameterControl()
        {
            InitializeComponent();
            
            btnOpen.Visible = false;
        }

        public override object GetValue()
        {
            var fld = comboBoxAdv1.SelectedItem as AttributeField;
            int fieldIndex = fld != null ? fld.Index : -1;
            return fieldIndex;
        }

        public override void SetValue(object value)
        {
            // do nothing
        }

        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public void OnLayerChanged(IDatasourceInput input)
        {
            var vector = input as IVectorInput;
            if (vector != null)
            {
                RebuildFieldList(vector.Datasource);
            }
        }

        public override string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

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
