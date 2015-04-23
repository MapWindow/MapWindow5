using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class ComboParameterControl : ParameterControlBase, IParameterControl
    {
        public ComboParameterControl()
        {
            InitializeComponent();
            comboBoxAdv1.SelectedIndexChanged += comboBoxAdv1_SelectedIndexChanged;
        }

        private void comboBoxAdv1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FireValueChanged();
        }

        public void SetOptions<T>(IEnumerable<T> options)
        {
            comboBoxAdv1.DataSource = options;
        }

        public object GetValue()
        {
            return comboBoxAdv1.SelectedItem;
        }

        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public string Caption
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }

        public bool ButtonVisible
        {
            get { return buttonAdv1.Visible; }
            set { buttonAdv1.Visible = value; }
        }
    }
}
