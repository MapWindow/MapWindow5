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
using MW5.Plugins.Printing.Model;
using MW5.Plugins.Printing.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Helpers;

namespace MW5.Plugins.Printing.Views
{
    internal partial class TemplateView : TemplateViewBase, ITemplateView
    {
        private readonly IAppContext _context;
        private static int _selectedTab;

        public TemplateView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();

            InitControls();

            AttachHandlers();

            tabControlAdv1.SelectedIndex = _selectedTab;

            FormClosed += (s, e) => _selectedTab = tabControlAdv1.SelectedIndex;

            UpdateAreaControls();
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

        public event Action FitToPage;

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

            // TODO: perhaps would be better to call fit to page automatically
            string scale = "1:" + AppConfig.Instance.PrintingScale;
            if (!cboScale.SetValue(scale))
            {
                cboScale.SetValue("1:25000");
            }

            cboFormat.SetValue(AppConfig.Instance.PrintingPaperFormat);

            LoadTemplates();
        }

        private void LoadTemplates()
        {
            string path = ConfigPathHelper.GetLayoutPath();
            Model.LoadTemplates(path);
            templateGrid1.DataSource = Model.Templates;
            templateGrid1.Adapter.SelectFirstRecord();
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public string PaperFormat
        {
            get { return cboFormat.Text; }
        }

        public LayoutTemplate Template
        {
            get
            {
                if (tabControlAdv1.SelectedTab == tabTemplates)
                {
                    return templateGrid1.Adapter.SelectedItem;
                }

                return null;
            }
        }

        public bool IsNewLayout
        {
            get { return tabControlAdv1.SelectedTab == tabNewLayout; }
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
            btnFitToPage.Click += (s, e) => Invoke(FitToPage);
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

        public void PopulateScales(int customScale = 0)
        {
            var list = new[] { 100, 500, 1000, 5000, 10000, 25000, 50000, 100000, 250000, 500000, 1000000, customScale };

            cboScale.Items.Clear();

            foreach (var scale in list)
            {
                if (scale >= 1)
                {
                    cboScale.Items.Add("1:" + scale);
                }
            }

            if (customScale != 0)
            {
                cboScale.SelectedIndex = cboScale.Items.Count - 1;
            }
        }

        private void OnTabChanged(object sender, EventArgs e)
        {
            UpdateAreaControls();
        }

        private void UpdateAreaControls()
        {
            var tab = tabControlAdv1.SelectedTab;
            tab.Controls.Add(cboArea);
            tab.Controls.Add(lblMapArea);
            tab.Controls.Add(lblArea);
        }
    }

    internal class TemplateViewBase : MapWindowView<TemplateModel>
    {
    }
}