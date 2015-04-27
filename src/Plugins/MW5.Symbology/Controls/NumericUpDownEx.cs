
using System.ComponentModel;
using System.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Controls
{
    internal partial class NumericUpDownEx : NumericUpDownExt
    {
        /// <summary>
        /// Creates new instance of the NumericUpDownExt class
        /// </summary>
        public NumericUpDownEx()
        {
            InitializeComponent();
        }

        public NumericUpDownEx(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// Setting the value of NumericUpDown control. The range of input value is checked
        /// </summary>
        public void SetValue(double value)
        {
            if (value <= (double)Minimum) Value = Minimum;
            else if (value >= (double)Maximum) Value = Maximum;
            else Value = (decimal)value;
        }
    }
}
