// -------------------------------------------------------------------------------------------
// <copyright file="TranslateRasterView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MW5.Gdal.Helpers;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Views;
using MW5.UI.Forms;

namespace MW5.Gdal.Views
{
    public partial class TranslateRasterCustomView : GdalTranslateViewBase, ITranslateRasterCustomView
    {
        private readonly IAppContext _context;

        public TranslateRasterCustomView(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;

            InitializeComponent();
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            // Get possible gdal formats:
            var gdalFormats = GdalFormatHelper.GetGdalFormats();

            // Fill output format listbox:
            var selectedIndex = 0;
            foreach (
                var gdalInfoFormat in gdalFormats.Where(gdalInfoFormat => gdalInfoFormat.ReadWrite.StartsWith("rw")))
            {
                OutputFormatListbox.Items.Add(gdalInfoFormat.ShortName);

                // Make GTiff the selected item
                if (gdalInfoFormat.ShortName == "GTiff")
                {
                    selectedIndex = OutputFormatListbox.Items.Count - 1;
                }
            }

            OutputFormatListbox.SelectedIndex = selectedIndex;
        }

        public ButtonBase OkButton
        {
            get { return btnRun; }
        }

        /// <summary>
        /// The button click event
        /// </summary>
        private void EditButtonClick(object sender, EventArgs e)
        {
            CommandTextbox.ReadOnly = false;
        }

        private string GetBaseDirectory()
        {
            string baseDir = string.Empty;

            //if (!string.IsNullOrEmpty(_context.Project.Filename))
            //{
            //    baseDir = Path.GetDirectoryName(_context.Project.Filename);
            //}

            return baseDir;
        }

        /// <summary>
        /// The button click event
        /// </summary>
        private void InputFileSelectButtonClick(object sender, EventArgs e)
        {
            var filter = GdalFileFilter.Input;
            var newFilename = string.Empty;

            // TODO: extract
            using (var ofd = new OpenFileDialog
                                 {
                                     Filter = filter,
                                     FilterIndex = 0,
                                     CheckFileExists = true,
                                     AutoUpgradeEnabled = true,
                                     Title = @"Select input raster",
                                     InitialDirectory = GetBaseDirectory(),
                                     SupportMultiDottedExtensions = true
                                 })
            {
                if (newFilename != string.Empty)
                {
                    ofd.FileName = newFilename;
                }

                if (ofd.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                // Add filename:
                InputfileTextbox.Text = ofd.FileName;
            }
        }

        /// <summary>
        /// The track scroll event
        /// </summary>
        private void JpegQualityScroll(object sender, EventArgs e)
        {
            JpegQualityLabel.Text = JpegQuality.Value.ToString();
        }

        /// <summary>
        /// The button click event
        /// </summary>
        private void OutputfileSelectButtonClick(object sender, EventArgs e)
        {
            var filter = GdalFileFilter.Output;
            var newFilename = string.Empty;

            // TODO: extract
            using (var sfd = new SaveFileDialog
                                 {
                                     Filter = filter,
                                     FilterIndex = 0,
                                     AutoUpgradeEnabled = true,
                                     Title = @"The output raster",
                                     CheckPathExists = true,
                                     InitialDirectory = GetBaseDirectory(),
                                     OverwritePrompt = true,
                                     SupportMultiDottedExtensions = true
                                 })
            {
                if (newFilename != string.Empty)
                {
                    sfd.FileName = newFilename;
                }

                if (sfd.ShowDialog(this) == DialogResult.Cancel)
                {
                    return;
                }

                // Add filename:
                OutputfileTextbox.Text = sfd.FileName;

                // Select correct item of ouput format listbox:
                SelectOutputFormatListbox(sfd.FilterIndex);
            }
        }

        /// <summary>
        /// Select an item in the output format listbox
        /// </summary>
        private void SelectOutputFormatListbox(int filterIndex)
        {
            var shortname = GdalFileFilter.GetShortNameFromOutputFilter(filterIndex);

            foreach (var item in OutputFormatListbox.Items.Cast<object>().Where(item => item.ToString() == shortname))
            {
                OutputFormatListbox.SelectedItem = item;
                break;
            }
        }

        /// <summary>Select event of the tab control</summary>
        private void TabControl1Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (e.TabPage == tabPage2)
            {
                webBrowser1.DocumentText = Model.Tool.LoadManual();
            }
        }

        /// <summary>The event</summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>     
        private void UpdateCommandTextbox(object sender, EventArgs e)
        {
            GdalToolHelper.UpdateCommandTextbox(CommandTextbox, OptionsGroupbox.Controls);
        }

        /// <summary>The event</summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event args</param>     
        private void UpdateCommandTextbox(object sender, MouseEventArgs e)
        {
            GdalToolHelper.UpdateCommandTextbox(CommandTextbox, OptionsGroupbox.Controls);
        }

        /// <summary>
        /// The track scroll event
        /// </summary>
        private void ZlevelScroll(object sender, EventArgs e)
        {
            ZlevelLabel.Text = Zlevel.Value.ToString(CultureInfo.InvariantCulture);
        }

        public string InputFilename
        {
            get { return InputfileTextbox.Text; }
        }

        public string OutputFilename
        {
            get { return OutputfileTextbox.Text; }
        }

        public string Options
        {
            get
            {
                GdalToolHelper.UpdateCommandTextbox(CommandTextbox, OptionsGroupbox.Controls);
                return CommandTextbox.Text;
            }
        }

        public string OutputFormat
        {
            get
            {
                var item = OutputFormatListbox.SelectedItem;
                return item != null ? item.ToString() : string.Empty;
            }
        }

        public bool AddToMap
        {
            get { return chkAddToMap.Checked; }
        }
    }

    public class GdalTranslateViewBase : MapWindowView<ToolViewModel>
    {
    }
}