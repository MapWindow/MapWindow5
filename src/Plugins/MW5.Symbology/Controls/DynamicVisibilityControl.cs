using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Plugins.Services;
using MW5.Plugins.Symbology.Properties;
using MW5.UI.Helpers;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class DynamicVisibilityControl : UserControl
    {
        private IDynamicVisibilityTarget _target;
        private const int MaxZoomDefault = 100;
        private const int MinZoomDefault = 0;
        private const double MaxScaleDefault = 1e10;
        private const double MinScaleDefault = 1;

        public event EventHandler<EventArgs> ValueChanged;

        public DynamicVisibilityControl()
        {
            InitializeComponent();
            
            cboDynamicScaleMode.AddItemsFromEnum<DynamicVisibilityMode>();
            cboDynamicScaleMode.SetValue(DynamicVisibilityMode.Scale);

            RefreshControls();

            InitScales();

            InitZooms();

            MakeSameSize(cboMinScale, cboMinZoom);
            MakeSameSize(cboMaxScale, cboMaxZoom);
        }

        public void Initialize(IDynamicVisibilityTarget target, int currentZoom, double currentScale)
        {
            if (target == null) throw new ArgumentNullException("target");

            _target = target;
            CurrentScale = currentScale;
            CurrentZoom = currentZoom;

            ModelToUi();

            AttachListeners(cboMinScale);
            AttachListeners(cboMaxScale);
            AttachListeners(cboMinZoom);
            AttachListeners(cboMaxZoom);

            UpdatePicture();

            RefreshControls();
        }

        public bool UseDynamicVisiblity
        {
            get { return chkDynamicVisibility.Checked; }
            set { chkDynamicVisibility.Checked = value; }
        } 

        [DefaultValue(1)]
        public int CurrentZoom { get; set; }

        [DefaultValue(100)]
        public double CurrentScale { get; set; }

        public DynamicVisibilityMode Mode
        {
            get { return cboDynamicScaleMode.GetValue<DynamicVisibilityMode>(); }
            set { cboDynamicScaleMode.SetValue(value); }
        }

        public double MinScale
        {
            get
            {
                double value = 0.0;
                double.TryParse(cboMinScale.Text, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture, out value);
                return value;
            }
            set
            {
                cboMinScale.Text =  String.Format("{0:0}", Math.Floor(value));
            }
        }

        public double MaxScale
        {
            get
            {
                double value = 0.0;
                double.TryParse(cboMaxScale.Text, NumberStyles.Number, Thread.CurrentThread.CurrentUICulture,  out value);   // TODO: move to shared
                return value;
            }
            set
            {
                cboMaxScale.Text = String.Format("{0:0}", Math.Ceiling(value));
            }
        }

        public int MinZoom
        {
            get { return cboMinZoom.SelectedIndex + 1; }
            set
            {
                value = AdjustZoom(value);

                if (value >= 0 && value < cboMinZoom.Items.Count)
                {
                    cboMinZoom.SelectedIndex = value - 1;
                }
            }
        }

        public int MaxZoom
        {
            get { return cboMaxZoom.SelectedIndex + 1; }
            set
            {
                value = AdjustZoom(value);

                if (value >= 0 && value < cboMaxZoom.Items.Count)
                {
                    cboMaxZoom.SelectedIndex = value - 1;
                }
            }
        }

        private int AdjustZoom(int value)
        {
            if (value < 1)
            {
                value = 1;
            }

            if (value >= cboMinZoom.Items.Count)
            {
                value = cboMinZoom.Items.Count - 1;
            }

            return value;
        }

        public void ApplyChanges()
        {
            UiToModel();
        }

        private void InitZooms()
        {
            var zooms = Enumerable.Range(1, 25);

            foreach (var item in zooms)
            {
                cboMinZoom.Items.Add(item);
                cboMaxZoom.Items.Add(item);
            }

            cboMinZoom.SelectedIndex = 0;
            cboMaxZoom.SelectedIndex = cboMaxZoom.Items.Count - 1;
        }

        private void InitScales()
        {
            int[] scales = {
                100,
                1000,
                5000,
                10000,
                25000,
                50000,
                100000,
                250000,
                500000,
                1000000,
                5000000,
                1000000,
            };

            foreach (var item in scales)
            {
                cboMinScale.Items.Add(item);
                cboMaxScale.Items.Add(item);
            }

            cboMinScale.SelectedIndex = 0;
            cboMaxScale.SelectedIndex = cboMaxScale.Items.Count - 1;
        }

        private void AttachListeners(ComboBoxAdv combo)
        {
            combo.SelectedIndexChanged += (s, e) =>
            {
                UpdatePicture();
                FireValueChanged();
            };
            combo.TextChanged += (s, e) =>
            {
                UpdatePicture();
                FireValueChanged();
            };
        }

        private void UpdatePicture()
        {
            bool visible = false;
            if (Mode == DynamicVisibilityMode.Scale)
            {
                visible = CurrentScale >= MinScale && CurrentScale <= MaxScale;
            }
            else
            {
                visible = CurrentZoom >= MinZoom && CurrentZoom <= MaxZoom;
            }

            pictureBox1.Image = visible ? Resources.img_show24 : Resources.img_hide24;
        }

        private void MakeSameSize(Control source, Control target)
        {
            target.Left = source.Left;
            target.Top = source.Top;
            target.Width = source.Width;
            target.Dock = source.Dock;
        }

        private void chkDynamicVisibility_CheckedChanged(object sender, EventArgs e)
        {
            RefreshControls();
        }

        private void cboDynamicScaleMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshControls();
            UpdatePicture();
        }

        private void RefreshControls()
        {
            var mode = cboDynamicScaleMode.GetValue<DynamicVisibilityMode>();

            cboMaxScale.Visible = mode == DynamicVisibilityMode.Scale;
            cboMinScale.Visible = mode == DynamicVisibilityMode.Scale;
            cboMinZoom.Visible = mode == DynamicVisibilityMode.Zoom;
            cboMaxZoom.Visible = mode == DynamicVisibilityMode.Zoom;

            panel1.Enabled = chkDynamicVisibility.Checked;

            if (mode == DynamicVisibilityMode.Scale)
            {
                lblCurrent.Text = "Current scale: " + (int)CurrentScale;
            }
            else
            {
                lblCurrent.Text = "Current zoom: " + CurrentZoom;
            }
        }

        private void btnSetMinScale_Click(object sender, EventArgs e)
        {
            if (Mode == DynamicVisibilityMode.Zoom)
            {
                MinZoom = CurrentZoom;
            }
            else
            {
                MinScale = CurrentScale;
            }
        }

        private void btnSetMaxScale_Click(object sender, EventArgs e)
        {
            if (Mode == DynamicVisibilityMode.Zoom)
            {
                MaxZoom = CurrentZoom;
            }
            else
            {
                MaxScale = CurrentScale;
            }
        }

        private void ModelToUi()
        {
            MinZoom = _target.MinVisibleZoom;
            MaxZoom = _target.MaxVisibleZoom;
            MinScale = _target.MinVisibleScale;
            MaxScale = _target.MaxVisibleScale;
            chkDynamicVisibility.Checked = _target.DynamicVisibility;
            bool useScale = (_target.MinVisibleZoom == MinZoomDefault && MaxZoom == _target.MaxVisibleZoom);
            cboDynamicScaleMode.SetValue(useScale ? DynamicVisibilityMode.Scale : DynamicVisibilityMode.Zoom);
        }

        private void UiToModel()
        {
            bool useScale = Mode == DynamicVisibilityMode.Scale;

            _target.MinVisibleScale = useScale ? MinScale : MinScaleDefault;
            _target.MaxVisibleScale = useScale ? MaxScale : MaxScaleDefault;

            _target.MinVisibleZoom = useScale ? MinZoomDefault : MinZoom;
            _target.MaxVisibleZoom = useScale ? MaxZoomDefault : MaxZoom;

            _target.DynamicVisibility = chkDynamicVisibility.Checked;
        }

        private void FireValueChanged()
        {
            var handler = ValueChanged;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
