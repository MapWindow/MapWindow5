using System;
using System.Collections;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class ComboParameterControl : ParameterControlBase
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

        public void SetOptions(object options)
        {
            comboBoxAdv1.DataSource = options;
        }

        public override object GetValue()
        {
            return comboBoxAdv1.SelectedItem;
        }

        /// <summary>
        /// Sets the value.
        /// </summary>
        public override void SetValue(object value)
        {
            // TODO: implement
        }

        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public override string Caption
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
