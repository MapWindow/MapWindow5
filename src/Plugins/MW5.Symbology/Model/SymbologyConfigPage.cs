// -------------------------------------------------------------------------------------------
// <copyright file="SymbologyConfigPage.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Drawing;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Symbology.Controls.ImageCombo;
using MW5.Plugins.Symbology.Helpers;
using MW5.Plugins.Symbology.Properties;
using MW5.Services.Config;
using MW5.Shared;

namespace MW5.Plugins.Symbology.Model
{
    internal partial class SymbologyConfigPage : UserControl, IConfigPage
    {
        private readonly IAppContext _context;

        public SymbologyConfigPage(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");

            _context = context;

            InitializeComponent();

            Initialize();
        }

        public string Description
        {
            get { return "Settings related to the appearance of vector and raster layers."; }
        }

        public Bitmap Icon
        {
            get { return Resources.img_palette32; }
        }

        public string PageName
        {
            get { return "Symbology"; }
        }

        public ConfigPageType PageType
        {
            get { return ConfigPageType.Symbology; }
        }

        public bool PluginPage
        {
            get { return true; }
        }

        /// <summary>
        /// Gets a value indicating whether the page height can be adjusted to fit the the parent.
        /// </summary>
        public bool VariableHeight
        {
            get { return false; }
        }

        public void Initialize()
        {
            if (icbCharts.Items.Count > 0)
            {
                icbCharts.SelectedIndex = 0;
            }

            if (icbRaster.Items.Count > 0)
            {
                icbRaster.SelectedIndex = 0;
            }

            if (icbVector.Items.Count > 1)
            {
                icbVector.SelectedIndex = 1;
            }

            txtIconPath.Text = ResourcePathHelper.GetIconsPath();
            txtTexurePath.Text = ResourcePathHelper.GetTexturesPath();

            ColorSchemeProvider.SetFirstColorScheme(SchemeTarget.Vector, Color.Gray);
        }

        public void Save()
        {
        }

        private void OnChartsSchemeClick(object sender, EventArgs e)
        {
            FormHelper.EditColorSchemes(_context, SchemeTarget.Charts, ParentForm);
        }

        private void OnOpenIconsClick(object sender, EventArgs e)
        {
            PathHelper.OpenFolderWithExplorer(txtIconPath.Text);
        }

        private void OnOpenTexturesClick(object sender, EventArgs e)
        {
            PathHelper.OpenFolderWithExplorer(txtTexurePath.Text);
        }

        private void OnRasterSchemeClick(object sender, EventArgs e)
        {
            FormHelper.EditColorSchemes(_context, SchemeTarget.Raster, ParentForm);
        }

        private void OnVectorSchemeClick(object sender, EventArgs e)
        {
            FormHelper.EditColorSchemes(_context, SchemeTarget.Vector, ParentForm);
        }
    }
}