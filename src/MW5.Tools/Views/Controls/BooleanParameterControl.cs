using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class BooleanParameterControl : ParameterControlBase, IParameterControl
    {
        public BooleanParameterControl()
        {
            InitializeComponent();
            ButtonVisible = false;
        }

        public TableLayoutPanel GetTable()
        {
            return tableLayoutPanel1;
        }

        public string Caption
        {
            get { return checkBoxAdv1.Text; }
            set { checkBoxAdv1.Text = value; }
        }

        public object GetValue()
        {
            return checkBoxAdv1.Checked;
        }

        public bool ButtonVisible
        {
            get { return false; }
            set { ; }
        }
    }
}
