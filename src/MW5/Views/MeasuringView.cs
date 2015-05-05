using System;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Api.Enums;
using MW5.Api.Interfaces;
using MW5.UI.Forms;
using MW5.UI.Helpers;
using MW5.Views.Abstract;

namespace MW5.Views
{
    public partial class MeasuringView : MeasuringViewBase, IMeasuringView
    {
        private static int _selectedTab = -1;

        public MeasuringView()
        {
            InitializeComponent();

            tabControlAdv1.SelectedIndex = _selectedTab;

            FormClosed += (s, e) => _selectedTab = tabControlAdv1.SelectedIndex;
        }

        public void Initialize()
        {
            ModelToUi();
        }

        private void ModelToUi()
        {
            cboAngleFormat.AddItemsFromEnum<AngleFormat>();
            cboBearingType.AddItemsFromEnum<BearingType>();
            cboLengthUnits.AddItemsFromEnum<LengthDisplay>();
            cboAreaUnits.AddItemsFromEnum<AreaDisplay>();

            cboAngleFormat.SetValue(Model.AngleFormat);
            cboBearingType.SetValue(Model.BearingType);
            cboLengthUnits.SetValue(Model.LengthUnits);
            cboAreaUnits.SetValue(Model.AreaUnits);

            chkShowBearing.Checked = Model.ShowBearing;
            chkShowLength.Checked = Model.ShowLength;
            chkShowTotalLength.Checked = Model.ShowTotalLength;

            udLengthPrecision.Value = Model.LengthPrecision;
            udBearingPrecision.Value = Model.AnglePrecision;
            udAreaPrecision.Value = Model.AreaPrecision;

            chkShowPoints.Checked = Model.PointsVisible;
            chkShowPointLabels.Checked = Model.PointLabelsVisible;

            clpFillColor.Color = Model.FillColor;
            clpLineColor.Color = Model.LineColor;

            cboLineStyle.SelectedIndex = (int)Model.LineStyle;
            cboLineWidth.SelectedIndex = (int)(Model.LineWidth - 1);

            fillTransparency.Value = Model.FillTransparency;
        }

        public void UiToModel()
        {
            Model.ShowBearing = chkShowBearing.Checked;
            Model.ShowLength = chkShowLength.Checked;
            Model.ShowTotalLength = chkShowTotalLength.Checked;

            Model.AngleFormat = cboAngleFormat.GetValue<AngleFormat>();
            Model.BearingType = cboBearingType.GetValue<BearingType>();
            Model.LengthUnits = cboLengthUnits.GetValue<LengthDisplay>();
            Model.AreaUnits = cboAreaUnits.GetValue<AreaDisplay>();

            Model.LengthPrecision = (int)udLengthPrecision.Value;
            Model.AnglePrecision = (int)udBearingPrecision.Value;
            Model.AreaPrecision = (int)udAreaPrecision.Value;

            Model.PointsVisible = chkShowPoints.Checked;
            Model.PointLabelsVisible = chkShowPointLabels.Checked;

            Model.FillColor = clpFillColor.Color;
            Model.LineColor = clpLineColor.Color;
            Model.FillTransparency = fillTransparency.Value;

            Model.LineWidth = cboLineWidth.SelectedIndex + 1;
            Model.LineStyle = (DashStyle)cboLineStyle.SelectedIndex;
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }
    }
    
    public class MeasuringViewBase : MapWindowView<IMeasuringSettings> {};
}
