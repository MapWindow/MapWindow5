using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Symbology.Helpers;
using MW5.UI.Helpers;

namespace MW5.Plugins.Symbology.Controls
{
    public partial class RgbBandControl : UserControl
    {
        private IRasterSource _raster;

        public RgbBandControl()
        {
            InitializeComponent();
        }

        public void Initialize(IRasterSource raster)
        {
            if (raster == null) throw new ArgumentNullException("raster");
            _raster = raster;

            InitComboBoxes();
        }

        public int RedBandIndex
        {
            get { return cboRed.SelectedIndex; }            
        }

        public int GreenBandIndex
        {
            get { return cboGreen.SelectedIndex; }
        }

        public int BlueBandIndex
        {
            get { return cboBlue.SelectedIndex; }
        }

        public void ApplyChanges()
        {
            _raster.RedBandIndex = cboRed.SelectedIndex + 1;
            _raster.GreenBandIndex = cboGreen.SelectedIndex + 1;
            _raster.BlueBandIndex = cboBlue.SelectedIndex + 1;
            _raster.UseRgbBandMapping = true;
        }

        private void InitComboBoxes()
        {
            cboRed.AddRasterBands(_raster);
            cboRed.SetSelectedIndexSafe(_raster.RedBandIndex - 1);

            cboGreen.AddRasterBands(_raster);
            cboGreen.SetSelectedIndexSafe(_raster.GreenBandIndex - 1);

            cboBlue.AddRasterBands(_raster);
            cboBlue.SetSelectedIndexSafe(_raster.BlueBandIndex - 1);
        }
    }
}
