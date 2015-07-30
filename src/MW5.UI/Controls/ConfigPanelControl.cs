using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Syncfusion.Drawing;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public partial class ConfigPanelControl : GradientPanel
    {
        private GradientLabel _gradientLabel1;

        public ConfigPanelControl()
        {
            InitializeComponent();

            AddLabel();

            BorderStyle = BorderStyle.None;
        }

        private void AddLabel()
        {
            _gradientLabel1 = new GradientLabel
            {
                Dock = DockStyle.Top,
                BackgroundColor = new BrushInfo(GradientStyle.None, Color.WhiteSmoke, Color.WhiteSmoke),
                BorderAppearance = BorderStyle.None,
                BorderSides = Border3DSide.Bottom,
                BorderColor = Color.Gainsboro,
                Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Bold, GraphicsUnit.Point, 204),
                ForeColor = SystemColors.ControlDarkDark,
                TextAlign = ContentAlignment.MiddleCenter
            };

            Controls.Add(_gradientLabel1);
        }

        public string HeaderText
        {
            get { return _gradientLabel1.Text; }
            set { _gradientLabel1.Text = value; }
        }

        public void ShowCaptionOnly()
        {
            Height = _gradientLabel1.Height;
        }
    }
}
