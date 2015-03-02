using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Abstract;
using MW5.Mvp;
using MW5.Plugins.Interfaces;
using MW5.Presenters;
using Syncfusion.Windows.Forms;

namespace MW5.Views
{
    public partial class SetProjectionView : MetroForm, ISetProjectionView
    {
        private readonly IMainView _owner;

        public enum ProjectionType
        {
            Empty = 0,
            Default = 1,
            Custom = 2,
            None = 3,
        }

        public event Action OkClicked;

        public SetProjectionView(IMainView owner)
        {
            _owner = owner;
            InitializeComponent();

            cboWellKnown.Items.Add("WGS 84 (decimal degrees)");
            cboWellKnown.Items.Add("Google Mercator");
            cboWellKnown.SelectedIndex = 0;
            
            UpdateView();

            optDefinition.CheckChanged += (s, e) => UpdateView();
            optEmpty.CheckChanged += (s, e) => UpdateView();
            optWellKnown.CheckChanged += (s, e) => UpdateView();

            btnOk.Click += (s, e) => Invoke(OkClicked);
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

        public void ShowView()
        {
            ShowDialog(_owner as IWin32Window);
        }

        public void UpdateView()
        {
            cboWellKnown.Enabled = optWellKnown.Checked;
            txtDefinition.Enabled = optDefinition.Checked;
        }

        private void Invoke(Action action)
        {
            if (action != null)
            {
                action();
            }
        }
    }
}
