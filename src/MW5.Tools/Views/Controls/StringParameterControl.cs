using System;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class StringParameterControl : ParameterControlBase, IParameterControl
    {
        public StringParameterControl()
        {
            InitializeComponent();
            buttonAdv1.Visible = false;
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

        public object GetValue()
        {
            return textBoxExt1.Text;
        }
    }
}
