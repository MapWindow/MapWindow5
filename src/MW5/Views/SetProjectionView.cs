using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.UI;
using MW5.UI.Forms;
using MW5.Views.Abstract;
using Syncfusion.Windows.Forms;

namespace MW5.Views
{
    public partial class SetProjectionView : MapWindowView, ISetProjectionView
    {
        public enum ProjectionType
        {
            Empty = 0,
            Default = 1,
            Custom = 2,
            None = 3,
        }

        public SetProjectionView()
        {
            InitializeComponent();

            cboWellKnown.Items.Add("WGS 84 (decimal degrees)");
            cboWellKnown.Items.Add("Google Mercator");
            cboWellKnown.SelectedIndex = 0;
            
            UpdateView();

            optDefinition.CheckChanged += (s, e) => UpdateView();
            optEmpty.CheckChanged += (s, e) => UpdateView();
            optWellKnown.CheckChanged += (s, e) => UpdateView();
        }

        public string CustomProjection
        {
            get { return txtDefinition.Text; }
        }

        public int DefaultProjectionIndex
        {
            get { return cboWellKnown.SelectedIndex; }
        }

        public ProjectionType Projection
        {
            get
            {
                if (optEmpty.Checked)
                {
                    return ProjectionType.Empty;
                }
                if (optDefinition.Checked)
                {
                    return ProjectionType.Custom;
                }
                if (optWellKnown.Checked)
                {
                    return ProjectionType.Default;
                }
                return ProjectionType.None;
            }
        }

        public override void UpdateView()
        {
            cboWellKnown.Enabled = optWellKnown.Checked;
            txtDefinition.Enabled = optDefinition.Checked;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public void Initialize(object param)
        {
            
        }
    }
}
