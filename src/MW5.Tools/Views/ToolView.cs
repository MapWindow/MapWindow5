// -------------------------------------------------------------------------------------------
// <copyright file="ToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MW5.Api.Concrete;
using MW5.Plugins.Concrete;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Controls.Parameters;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Properties;
using MW5.Tools.Services;
using MW5.Tools.Views.Abstract;
using MW5.UI.Forms;
using MW5.UI.Style;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool view.
    /// </summary>
    public partial class ToolView : GisToolViewBase, IToolView
    {
        private readonly IAppContext _context;
        protected readonly ParameterControlGenerator _generator;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolView"/> class.
        /// </summary>
        public ToolView(IAppContext context, ParameterControlGenerator controlGenerator)
        {
            if (context == null) throw new ArgumentNullException("context");
            if (controlGenerator == null) throw new ArgumentNullException("controlGenerator");

            _context = context;
            _generator = controlGenerator;

            InitializeComponent();

            panelOptional.Controls.Clear();

            panelRequired.Controls.Clear();
        }

        public override ViewStyle Style
        {
            get 
            { 
                return new ViewStyle()
                {
                    Modal = true,
                    Sizable = true,
                }; 
            }
        }

        /// <summary>
        /// Gets the ok button.
        /// </summary>
        public ButtonBase OkButton
        {
            get { return btnRun; }
        }

        public bool RunInBackground
        {
            get { return chkBackground.Checked; }
        }

        /// <summary>
        /// Generates controls for parameters.
        /// </summary>
        public virtual void GenerateControls()
        {
            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                throw new ApplicationException(
                    "Tool must support IParameterized tool interface for automatic UI generation.");
            }

            var parameters = tool.Parameters.Where(p => !p.SkipUIGeneration).ToList();
            var subList = parameters.Where(p => string.IsNullOrWhiteSpace(p.SectionName)).ToList();

            if (Model.BatchMode)
            {
                GenerateBatchMode(subList);
            }
            else
            {
                GenerateSingleMode(subList);
            }

            GenerateSections(parameters);

            _generator.EventManager.ApplyConfig(tool.Configuration);

            tool.Parameters.SetControlDefaults();

            superToolTip1.AddTooltips(parameters);

            RefreshView();
        }

        private void RefreshView()
        {
            panelRequired.AddVerticalPadding();
            panelOptional.AddVerticalPadding();

            HideOptionalTab();
        }

        /// <summary>
        /// Generates sections for parameters with section name attribute.
        /// </summary>
        private void GenerateSections(List<BaseParameter> parameters)
        {
            var list = parameters.Where(p => !string.IsNullOrWhiteSpace(p.SectionName)).ToList();

            if (list.Count == 0)
            {
                return;
            }

            var names = list.Select(p => p.SectionName).Distinct().OrderByDescending(s => s);

            foreach (var name in names) 
            {
                string s = name;
                _generator.GenerateIntoPanel(panelOptional, name, parameters.Where(p => p.SectionName == s));
            }
        }

        /// <summary>
        /// Generates sections for single input mode.
        /// </summary>
        private void GenerateSingleMode(List<BaseParameter> parameters)
        {
            _generator.GenerateIntoPanel(panelRequired, "Output", FilterSingle(parameters, ParameterGroup.Output));

            _generator.GenerateIntoPanel(panelRequired, "Input", FilterSingle(parameters, ParameterGroup.Input));

            _generator.GenerateIntoPanel(panelOptional, "Optional", FilterSingle(parameters, ParameterGroup.Optional));
        }

        /// <summary>
        /// Generates sections for batch input mode.
        /// </summary>
        private void GenerateBatchMode(List<BaseParameter> parameters)
        {
            _generator.GenerateIntoPanel(panelRequired, "Output", FilterBatch(parameters, ParameterGroup.Output), true);

            _generator.GenerateIntoPanel(panelRequired, "Input", FilterBatch(parameters, ParameterGroup.Input), true);

            _generator.GenerateIntoPanel(panelOptional, "Optional", FilterBatch(parameters, ParameterGroup.Optional), true);

            _generator.GenerateIntoPanel(panelOptional, "Required", FilterBatch(parameters, ParameterGroup.Required), true);

            tabRequired.Text = "Input";

            tabOptional.Text = "Parameters";
        }

        protected virtual IEnumerable<BaseParameter> FilterSingle(List<BaseParameter> parameters, ParameterGroup group)
        {
            switch (group)
            {
                case ParameterGroup.Input:
                    return parameters.Where(p => p.IsInput && p.Required);
                case ParameterGroup.Output:
                    return parameters.Where(p => !p.IsInput);
                case ParameterGroup.Required:
                    break;
                case ParameterGroup.Optional:
                    return parameters.Where(p => p.IsInput && !p.Required);
            }

            return new List<BaseParameter>();
        }

        protected virtual IEnumerable<BaseParameter> FilterBatch(List<BaseParameter> parameters, ParameterGroup group)
        {
            switch (group)
            {
                case ParameterGroup.Input:
                    return parameters.Where(p => p is IInputParameter);
                case ParameterGroup.Output:
                    return parameters.Where(p => !p.IsInput);
                case ParameterGroup.Required:
                    return parameters.Where(p => p.IsInput && !(p is IInputParameter) && p.Required);
                case ParameterGroup.Optional:
                    return parameters.Where(p => p.IsInput && !(p is IInputParameter) && !p.Required);
            }

            return new List<BaseParameter>();
        }

        private void HideOptionalTab()
        {
            if (panelOptional.Controls.Count == 0)
            {
                tabControlAdv1.TabPages.Remove(tabOptional);
            }
        }

        public virtual void Initialize()
        {
            Text = Model.Tool.Name;

            chkBackground.Visible = !Model.BatchMode;
            chkBackground.Checked = AppConfig.Instance.TaskRunInBackground;

            if (Model.BatchMode)
            {
                superToolTip1.SetToolTip(btnRun, null);
            }

            if (DebugHelper.LoadToolDocumentation)
            {
                LoadDocumentation();
            }
        }

        private async void LoadDocumentation()
        {
            var tool = Model.Tool;

            // PM: Changes to load a HTML page and all its linked files like images, js-files and css-files.
            var uri = await tool.GetDocumentationUri();

            // user has closed the dialog when we were searching
            if (IsDisposed)
            {
                return;
            }

            if (uri != null)
            {
                webBrowser1.Url = uri;
            }
            else
            {
                webBrowser1.DocumentText = tool.GetMissingNotice();
            }
        }

        public override void BeforeClose()
        {
            AppConfig.Instance.TaskRunInBackground = chkBackground.Checked;
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            Model.Tool.CleanUp();

            Close();
        }
    }

    public class GisToolViewBase : MapWindowView<ToolViewModel>
    {
    }
}