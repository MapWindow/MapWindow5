using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Tools.Views.Controls
{
    public partial class ParameterControlBase : UserControl
    {
        public event EventHandler<EventArgs> ValueChanged;

        public ParameterControlBase()
        {
            InitializeComponent();
        }

        protected void FireValueChanged()
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }

        public IParameterControl AsBase
        {
            get { return this as IParameterControl; }
        }
    }
}
