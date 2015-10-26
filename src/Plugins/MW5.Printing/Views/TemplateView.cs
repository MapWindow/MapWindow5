// -------------------------------------------------------------------------------------------
// <copyright file="TemplateView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Api.Interfaces;
using MW5.Plugins.Concrete;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Printing.Enums;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Printing.Views
{
    internal partial class TemplateView : TemplateViewBase, ITemplateView
    {
        private readonly IAppContext _context;

        public TemplateView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            InitControls();

            tabControlAdv1.SelectedIndex = 1;

            AttachHandlers();
        }

        private PrintArea PrintArea
        {
            get { return cboArea.GetValue<PrintArea>(); }
        }

        public Orientation Orientation
        {
            get { return cboOrientation.GetValue<Orientation>(); }
        }

        public event Action LayoutSizeChanged;

        public IEnvelope MapExtents
        {
            get
            {
                if (Model.Extents != null)
                {
                    return Model.Extents;
                }

                switch (PrintArea)
                {
                    case PrintArea.WholeMap:
                        return _context.Map.MaxExtents;
                    case PrintArea.CurrentScreen:
                        return _context.Map.Extents;
                    case PrintArea.Selection:
                        return Model.Extents;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public int MapScale
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(cboScale.Text))
                {
                    string s = cboScale.Text.Substring(2);

                    int val;
                    if (Int32.TryParse(s, out val))
                    {
                        return val;
                    }
                }

                return 0;
            }
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            cboArea.SetValue(Model.PrintArea);
            cboOrientation.SetValue(AppConfig.Instance.PrintingOrientation);

            string scale = "1:" + AppConfig.Instance.PrintingScale;
            cboScale.SetValue(scale);

            cboFormat.SetValue(AppConfig.Instance.PrintingPaperFormat);
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public string PaperFormat
        {
            get { return cboFormat.Text; }
        }

        public string TemplateName
        {
            get
            {
                if (tabControlAdv1.SelectedTab == tabMultiPage)
                {
                    return cboTemplate.Text;
                }

                // TODO: return single page template as well
                return string.Empty;
            }
        }

        public override void UpdateView()
        {
            base.UpdateView();

            if (Model.PageCountX > 0 && Model.PageCountY > 0)
            {
                lblPages.Text = string.Format("Pages: {0} × {1}", Model.PageCountX, Model.PageCountY);
            }
            else
            {
                lblPages.Text = "Pages: n/d";
            }

            lblWarning.Visible = !Model.Valid;
        }

        private void AttachHandlers()
        {
            cboArea.SelectedIndexChanged += (s, e) => Invoke(LayoutSizeChanged);
            cboFormat.SelectedIndexChanged += (s, e) => Invoke(LayoutSizeChanged);
            cboOrientation.SelectedIndexChanged += (s, e) => Invoke(LayoutSizeChanged);
            cboScale.SelectedIndexChanged += (s, e) => Invoke(LayoutSizeChanged);
        }

        private void InitControls()
        {
            // TODO: display selection when it was selected
            var areas = new List<PrintArea> { PrintArea.WholeMap, PrintArea.CurrentScreen, };

            cboArea.AddItemsFromEnum(areas);

            cboOrientation.AddItemsFromEnum<Orientation>();
            cboFormat.AddItemsFromEnum<PaperFormat>();
            PopulateScales();
        }

        private void OnAreaChanged(object sender, EventArgs e)
        {
            var ext = MapExtents;

            var units = _context.Map.MapUnits;

            lblArea.Text = string.Format("{0} × {1}", UnitsHelper.FormatDistance(units, ext.MaxX - ext.MinX),
                UnitsHelper.FormatDistance(units, ext.MaxY - ext.MinY));
        }

        private void PopulateScales()
        {
            var list = new[] { 100, 500, 1000, 5000, 10000, 25000, 50000, 100000, 250000, 500000, 1000000 };

            cboScale.Items.Clear();

            foreach (var scale in list)
            {
                cboScale.Items.Add("1:" + scale);
            }
        }
    }

    internal class TemplateViewBase : MapWindowView<TemplateModel>
    {
    }
}