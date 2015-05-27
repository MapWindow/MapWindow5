using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Services.Config;

namespace MW5.Controls
{
    public partial class ConfigPageHeader : UserControl
    {
        public ConfigPageHeader()
        {
            InitializeComponent();
        }

        public Image Icon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public IConfigPage Page
        {
            get { return panel2.Controls.Count > 0 ? panel2.Controls[0] as IConfigPage : null; }
            set
            {
                panel2.Controls.Clear();
                var control = value as Control;
                if (control != null)
                {
                    panel2.Controls.Add(control);
                }
            }
        }

        public string Description
        {
            get { return label1.Text; }
            set { label1.Text = value; }
        }
    }
}
