using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.UI.Controls
{
    public partial class SectionControl : UserControl
    {
        public SectionControl()
        {
            InitializeComponent();
        }

        public string Caption
        {
            get { return label1.Text;  }
            set { label1.Text = value;  }
        }
    }
}
