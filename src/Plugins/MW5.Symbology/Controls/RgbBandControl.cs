using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Enums;
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

        public int AlphaBandIndex
        {
            get { return cboAlpha.SelectedIndex; }
        }

        public void ApplyChanges()
        {
            _raster.RedBandIndex = cboRed.SelectedIndex;
            _raster.GreenBandIndex = cboGreen.SelectedIndex;
            _raster.BlueBandIndex = cboBlue.SelectedIndex;
            _raster.AlphaBandIndex = cboAlpha.SelectedIndex;

            _raster.UseRgbBandMapping = true;
        }

        private void InitComboBoxes()
        {
            cboRed.AddRasterBands(_raster, true);
            cboRed.SetSelectedIndexSafe(_raster.RedBandIndex);

            cboGreen.AddRasterBands(_raster, true);
            cboGreen.SetSelectedIndexSafe(_raster.GreenBandIndex);

            cboBlue.AddRasterBands(_raster, true);
            cboBlue.SetSelectedIndexSafe(_raster.BlueBandIndex);

            cboAlpha.AddRasterBands(_raster, true);
            cboAlpha.SetSelectedIndexSafe(_raster.AlphaBandIndex);
        }

        private void btnDefaultMapping_Click(object sender, EventArgs e)
        {
            ClearMapping();
            
            foreach (var band in _raster.Bands)
            {
                switch (band.ColorInterpretation)
                {
                    case ColorInterpretation.RedBand:
                        cboRed.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.GreenBand:
                        cboGreen.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.BlueBand:
                        cboBlue.SetSelectedIndexSafe(band.Index);
                        break;
                    case ColorInterpretation.AlphaBand:
                        cboAlpha.SetSelectedIndexSafe(band.Index);
                        break;
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearMapping();
        }

        private void ClearMapping()
        {
            cboRed.SetSelectedIndexSafe(0);
            cboGreen.SetSelectedIndexSafe(0);
            cboBlue.SetSelectedIndexSafe(0);
            cboAlpha.SetSelectedIndexSafe(0);
        }

        public bool HasMapping()
        {
            return cboRed.SelectedIndex != 0 || cboBlue.SelectedIndex != 0 || cboGreen.SelectedIndex != 0;
        }
    }
}
