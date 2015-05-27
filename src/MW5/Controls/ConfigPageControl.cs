using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Shared;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Controls
{
    public partial class ConfigPageControl : UserControl
    {
        public ConfigPageControl()
        {
            InitializeComponent();

            
        }

        public GradientPanel Panel
        {
            get { return gradientPanel1; }
        }

        public Image Icon
        {
            get { return pictureBox1.Image; }
            set { pictureBox1.Image = value; }
        }

        public string Description
        {
            get { return lblDescription.Text; }
            set { lblDescription.Text = value; }
        }

        public Control ConfigPage
        {
            get { return panelContent.Controls.Count > 0 ? panelContent.Controls[0] : null; }
            set
            {
                panelContent.Controls.Clear();
                if (value != null)
                {
                    panelContent.Height = value.Height;
                    panelContent.Controls.Add(value);
                }

                panelContent.Width = Width - 20;
            }
        }

        public void HandleMouseWheel(MouseEventArgs e)
        {
            OnMouseWheel(e);
        }
    }
}
