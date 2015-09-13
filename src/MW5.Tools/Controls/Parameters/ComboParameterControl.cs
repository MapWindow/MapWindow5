using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;

namespace MW5.Tools.Controls.Parameters
{
    public partial class ComboParameterControl : ParameterControlBase
    {
        public ComboParameterControl()
        {
            InitializeComponent();
            comboBoxAdv1.SelectedValueChanged += comboBoxAdv1_SelectedValueChanged;
        }

        void comboBoxAdv1_SelectedValueChanged(object sender, EventArgs e)
        {
            FireValueChanged();
        }

        public void SetOptions(object options)
        {
            // comboBoxAdv.DataSource raises SelectedIndex changed event twice on first assignment
            // presumably because of a _bug, so let's put some extra lines here, rather than
            // hunting for bugs afterwards
            //comboBoxAdv1.DataSource = options;
            comboBoxAdv1.Items.Clear();

            var list = options as IList;

            if (list == null)
            {
                return;
            }

            foreach (var item in list)
            {
                comboBoxAdv1.Items.Add(item);
            }

            if (comboBoxAdv1.Items.Count > 0)
            {
                comboBoxAdv1.SelectedIndex = 0;
            }
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
            foreach (var item in comboBoxAdv1.Items)
            {
                if (item == value || Equals(item.ToString(), value))
                {
                    comboBoxAdv1.SelectedItem = item;
                    return;
                }
            }
        }

        public override TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        /// <summary>
        /// Gets control to display tooltip for.
        /// </summary>
        public override Control ToolTipControl
        {
            get { return comboBoxAdv1; }
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
