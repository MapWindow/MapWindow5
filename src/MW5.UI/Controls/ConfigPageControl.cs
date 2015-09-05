using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
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
                    var page = value as IConfigPage;
                    if (page != null && page.VariableHeight)
                    {
                        panelContent.Height = gradientPanel1.Height - lblDescription.Height - 10;
                    }
                    else
                    {
                        panelContent.Height = value.Height;
                    }

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
