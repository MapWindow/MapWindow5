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
    public class GdalView: ToolView, IGdalView
    {
        private StringParameterControl _cmdOptions;
        private TabPageAdv _tabCmdLine;
        private bool _controlsGenerated = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolView"/> class.
        /// </summary>
        public GdalView(IAppContext context, ParameterControlGenerator controlGenerator)
            : base(context, controlGenerator)
        {
            _generator.EventManager.ControlValueChanged += OnControlValueChanged;
        }

        public IGdalTool GdalTool
        {
            get { return Model.Tool as IGdalTool; }
        }

        public override void Initialize()
        {
            base.Initialize();

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

        /// <summary>
        /// Generates controls for additional options.
        /// </summary>
        private void GenerateOptionsControl()
        {
            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                return;
            }

            var p = tool.FindParameter<IGdalTool, string>(t => t.AdditionalOptions) as StringParameter;

            _generator.GenerateControls(new[] { p }, false);

            _tabCmdLine.GetPanel().Controls.Add(p.Control);
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

            UpdateMainCmdOptions();

            var tool = Model.Tool as GdalTool;
            if (tool != null)
            {
                _cmdOptions.SetValue(tool.GetOptions(true));
            }
        }

        /// <summary>
        /// Copies options from UI to the parameters.
        /// </summary>
        protected virtual void UpdateMainCmdOptions()
        {
            var tool = Model.Tool as GdalTool;
            if (tool != null)
            {
                tool.Parameters.Apply();
            }
        }

        /// <summary>
        /// Updates other controls after driver is changed.
        /// </summary>
        protected virtual void OnDriverChanged(DatasourceDriver driver)
        {
            // overriden in derived classes
        }
    }
}
