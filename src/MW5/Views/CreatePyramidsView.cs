using System;
using System.Windows.Forms;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.Api.Static;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class CreatePyramidsView : CreatePyramidsViewBase, ICreatePyramidsView
    {
        public CreatePyramidsView()
        {
            InitializeComponent();

            cboInterpolation.AddItemsFromEnum<RasterOverviewSampling>();
            cboCompression.AddItemsFromEnum<TiffCompression>();

            cboCompression.SetValue(MapConfig.CompressOverviews);
            cboInterpolation.SetValue(RasterOverviewSampling.Nearest);
        }

        public void Initialize()
        {
            
        }

        public ButtonBase OkButton
        {
            get { return null; }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Yes;
            Invoke(ButtonClicked);
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Invoke(ButtonClicked);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Invoke(ButtonClicked);
        }

        public event Action ButtonClicked;

        public TiffCompression Compression
        {
            get { return cboCompression.GetValue<TiffCompression>(); }
        }

        public RasterOverviewSampling Sampling
        {
            get { return cboInterpolation.GetValue<RasterOverviewSampling>(); }
        }

        public bool DontShowAgain
        {
            get { return chkDontShow.Checked; }
        }
    }

    public class CreatePyramidsViewBase : MapWindowView<IRasterSource> { }
}
