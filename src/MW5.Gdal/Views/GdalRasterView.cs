using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Gdal.Helpers;
using MW5.Gdal.Model;
using MW5.Gdal.Properties;
using MW5.Gdal.Tools;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Services;
using MW5.Tools.Views;
using MW5.UI.Controls;
using MW5.UI.Style;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Gdal.Views
{
    public class GdalRasterView: ToolView, IGdalRasterView
    {
        private StringParameterControl _cmdOptions;
        private readonly TabPageAdv _tabDriver;
        private readonly TabPageAdv _tabCmdLine;
        private readonly IStyleService _styleService;
        private IEnumerable<BaseParameter> _driverOptions;
        private bool _controlsGenerated = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolView"/> class.
        /// </summary>
        public GdalRasterView(IAppContext context, ParameterControlGenerator controlGenerator, IStyleService styleService)
            : base(context, controlGenerator)
        {
            if (styleService == null) throw new ArgumentNullException("styleService");
            _styleService = styleService;
            _generator.EventManager.ControlValueChanged += OnControlValueChanged;

            _tabDriver = tabControlAdv1.AddTab("Driver", Resources.img_driver24);
            _tabCmdLine = tabControlAdv1.AddTab("Cmd Line", Resources.img_console24);
        }

        /// <summary>
        /// Generates controls for parameters.
        /// </summary>
        public override void GenerateControls()
        {
            base.GenerateControls();
            
            PopulateCommandLinePage();

            _controlsGenerated = true;

            UpdateCmdOptions();
        }

        /// <summary>
        /// Adds controls to command line page.
        /// </summary>
        private void PopulateCommandLinePage()
        {
            _cmdOptions = new StringParameterControl(true) { Caption = "Main options (read only)", Dock = DockStyle.Top, ReadOnly = true };
            var section = new ConfigPanelControl { HeaderText = "Command line options",  Dock = DockStyle.Top };
            section.ShowCaptionOnly();

            var panel = _tabCmdLine.GetPanel();

            GenerateOptionsControl();

            panel.Controls.Add(_cmdOptions);
            panel.Controls.Add(section);

            panel.AddVerticalPadding();
        }

        private void GenerateOptionsControl()
        {
            var tool = Model.Tool as IGdalTool;
            if (tool != null)
            {
                var p = tool.AdditionalOptionsParameter;

                _generator.GenerateControls(new[] { tool.AdditionalOptionsParameter }, false);

                _tabCmdLine.GetPanel().Controls.Add(p.Control);
            }
        }

        /// <summary>
        /// Handles changes of value of any of the contols.
        /// </summary>
        private void OnControlValueChanged(object sender, ParameterControlEventArgs e)
        {
            if (e.Value is DatasourceDriver)
            {
                OnDriverChanged(e.Value as DatasourceDriver);
            }

            UpdateCmdOptions();
        }

        /// <summary>
        /// Updates list of cmd options. Should be call when value of any other control changes.
        /// </summary>
        private void UpdateCmdOptions()
        {
            if (!_controlsGenerated)
            {
                return;
            }

            var tool = Model.Tool as GdalRasterTool;
            if (tool == null)
            {
                return;
            }

            tool.DriverOptions = GetDriverOptions();

            tool.Parameters.Apply();

            _cmdOptions.SetValue(tool.GetOptions(true));
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
                    sb.AppendFormat(" -co {0}={1} ", p.Name, p.Value);
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// Updates other controls after driver is changed.
        /// </summary>
        private void OnDriverChanged(DatasourceDriver driver)
        {
            // display driver options
            GenerateDriverOptions(driver, _tabDriver);

            // update output name
            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                return;
            }

            UpdateOutputFilename(tool, driver);

            // updating list of datatypes
            UpdateDataTypes(driver);
        }

        private void UpdateDataTypes(DatasourceDriver driver)
        {
            var tool = Model.Tool as GisTool;
            if (tool == null)
            {
                return;
            }

            var p = tool.FindParameter<GdalRasterTool, string>(t => t.OutputType) as OptionsParameter;
            if (p == null)
            {
                return;
            }

            var ctrl = p.Control as ComboParameterControl;
            if (ctrl != null)
            {
                var types = driver.GetCreationDataTypes();
                ctrl.SetOptions(types);
            }
        }

        /// <summary>
        /// Updates output extension when active driver changes.
        /// </summary>
        private void UpdateOutputFilename(IParametrizedTool tool, DatasourceDriver driver)
        {
            var input = tool.GetBatchInputParameter() as FilenameParameter;
            if (input == null)
            {
                return;
            }

            foreach (var p in tool.Parameters.OfType<OutputLayerParameter>())
            {
                var ctrl = p.Control as IOuputputParameterControl;
                if (ctrl != null)
                {
                    string ext = driver.Extension;
                    if (string.IsNullOrWhiteSpace(ext))
                    {
                        // sometimes there is no extension in the driver metadata
                        ext = "???";
                    }

                    ctrl.SetExtension(ext);
                }
            }
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

            foreach (var p in _driverOptions.Where(p => p.DefaultValue != null))
            {
                p.Control.SetValue(p.DefaultValue);
            }

            panel.AddVerticalPadding();

            _styleService.ApplyStyle(panel);

            tab.TabVisible = panel.Controls.Count > 0;

            superToolTip1.AddTooltips(panel, _driverOptions);
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
        }

        public IEnumerable<BaseParameter> DriverParameters
        {
            get { return _driverOptions; }
        }
    }
}
