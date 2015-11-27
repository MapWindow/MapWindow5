using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.UI.Forms;
using MW5.Views.Abstract;

namespace MW5.Views
{
    internal partial class SetScaleView : MapWindowView, ISetScaleView
    {
        private static bool _snapToZoomLevels = false;
        private readonly IMuteMap _map;

        public SetScaleView(IMuteMap map)
        {
            if (map == null) throw new ArgumentNullException("map");
            _map = map;

            InitializeComponent();

            InitControls();

            FormClosed += (s, e) => _snapToZoomLevels = chkSnap.Checked;
        }

        private void InitControls()
        {
            txtScale.Text = _map.CurrentScale.ToString("f2");

            var scales = new[]
                               {
                                   100, 
                                   500, 
                                   1000, 
                                   5000, 
                                   10000, 
                                   25000, 
                                   50000, 
                                   100000, 
                                   250000, 
                                   500000, 
                                   1000000, 
                                   2500000, 
                                   5000000, 
                                   10000000, 
                                   25000000, 
                                   50000000,
                                   100000000, 
                                   250000000, 
                                   500000000
                               };

            cboScale.DataSource = scales;

            SetInitialScale(scales);

            chkSnap.Checked = _snapToZoomLevels;
        }

        private void SetInitialScale(int[] scales)
        {
            double scale = _map.CurrentScale;

            for (int i = 0; i < scales.Length; i++)
            {
                if (scale <= scales[i])
                {
                    cboScale.SelectedIndex = i;
                    break;
                }
            }

            if (cboScale.SelectedItem == null && cboScale.Items.Count > 0)
            {
                cboScale.SelectedItem = cboScale.Items[cboScale.Items.Count - 1];
            }
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public string NewScale
        {
            get { return cboScale.Text; }
        }

        public bool SnapToZoomLevel
        {
            get { return chkSnap.Checked; }
        }
    }
}
