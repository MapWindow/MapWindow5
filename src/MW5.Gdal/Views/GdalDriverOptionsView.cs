using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Gdal.Helpers;
using MW5.Gdal.Model;
using MW5.Gdal.Properties;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;
using MW5.UI.Style;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Gdal.Views
{
    /// <summary>
    /// UI for GDAL command line tool which support creation options for the selected driver.
    /// </summary>
    public partial class GdalDriverOptionsView : GdalView, IGdalDriverOptionsView
    {
        private TabPageAdv _tabDriver;
        private readonly IStyleService _styleService;
        private IEnumerable<BaseParameter> _driverOptions;

        public GdalDriverOptionsView(IAppContext context, ParameterControlGenerator controlGenerator, IStyleService styleService)
            : base(context, controlGenerator)
        {
            if (styleService == null) throw new ArgumentNullException("styleService");
            _styleService = styleService;

            InitializeComponent();
        }

        public override void Initialize()
        {
            if (GdalTool.SupportDriverCreationOptions)
            {
                _tabDriver = tabControlAdv1.AddTab("Driver", Resources.img_driver24);
            }

            base.Initialize();
        }

        protected override void OnDriverChanged(DatasourceDriver driver)
        {
            base.OnDriverChanged(driver);

            if (GdalTool.SupportDriverCreationOptions)
            {
                GenerateDriverOptions(driver, _tabDriver);
            }
        }

        /// <summary>
        /// Copies options from UI to the parameters.
        /// </summary>
        protected override void UpdateMainCmdOptions()
        {
            base.UpdateMainCmdOptions();

            var tool = Model.Tool as GdalTool;
            if (tool != null)
            {
                tool.DriverOptions = GetDriverOptions();
            }
        }

        /// <summary>
        /// Get options specified on the driver page.
        /// </summary>
        private string GetDriverOptions()
        {
            if (_driverOptions == null)
            {
                return string.Empty;
            }

            var sb = new StringBuilder();
            foreach (var p in _driverOptions)
            {
                if (p.Value != null && !p.IsEmpty && !Equals(p.Value, p.DefaultValue))
                {
                    // TODO: for OGR2OGR there is another key
                    sb.AppendFormat(" -co {0}={1} ", p.Name, p.Value);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Generates control for creation options exposed by selected GDAL driver.
        /// </summary>
        private void GenerateDriverOptions(DatasourceDriver driver, TabPageAdv tab)
        {
            var panel = tab.GetPanel();

            panel.Controls.Clear();

            _driverOptions = driver.GenerateCreationOptions().ToList();

            driver.RestoreConfig(DriverParameters);

            GenerateDriverControls(panel, driver);

            tab.TabVisible = panel.Controls.Count > 0;

            superToolTip1.AddTooltips(_driverOptions);
        }

        /// <summary>
        /// Generates controls for driver options.
        /// </summary>
        private void GenerateDriverControls(Panel panel, DatasourceDriver driver)
        {
            var options = driver.GetMainOptions().ToList();

            if (options.Any())
            {
                // options in 2 different section for drivers like GTiff
                var parameters = _driverOptions.Where(o => !options.Contains(o.Name));
                _generator.GenerateIntoPanel(panel, driver.Name + " Other Options", parameters);

                parameters = _driverOptions.Where(o => options.Contains(o.Name));
                _generator.GenerateIntoPanel(panel, driver.Name + " Main Options", parameters);
            }
            else
            {
                // one section for all the others
                _generator.GenerateIntoPanel(panel, driver.Name + " Options", _driverOptions);
            }

            _driverOptions.SetControlDefaults();

            panel.AddVerticalPadding();

            _styleService.ApplyStyle(panel);
        }

        /// <summary>
        /// Gets list of parameters for driver creation options.
        /// </summary>
        public IEnumerable<BaseParameter> DriverParameters
        {
            get { return _driverOptions; }
        }
    }
}
