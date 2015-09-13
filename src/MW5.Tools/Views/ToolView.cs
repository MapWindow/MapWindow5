// -------------------------------------------------------------------------------------------
// <copyright file="ToolView.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
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

            var parameters = tool.Parameters.ToList();

            if (Model.BatchMode)
            {
                GenerateBatchMode(parameters);
            }
            else
            {
                GenerateSingleMode(parameters);
            }

            panelRequired.AddVerticalPadding();
            panelOptional.AddVerticalPadding();

            _generator.EventManager.Bind(tool.Configuration);

            tool.Parameters.SetDefaultsToControls();

            HideOptionalTab();

            AddToolTips(tool.Parameters);
        }

        private void GenerateSingleMode(List<BaseParameter> parameters)
        {
            _generator.Generate(panelRequired, "Output", FilterSingle(parameters, ParameterGroup.Output));

            _generator.Generate(panelRequired, "Input", FilterSingle(parameters, ParameterGroup.Input));

            _generator.Generate(panelOptional, "Optional", FilterSingle(parameters, ParameterGroup.Optional));
        }

        private void GenerateBatchMode(List<BaseParameter> parameters)
        {
            _generator.Generate(panelRequired, "Output", FilterBatch(parameters, ParameterGroup.Output), true);

            _generator.Generate(panelRequired, "Input", FilterBatch(parameters, ParameterGroup.Input), true);

            _generator.Generate(panelOptional, "Optional", FilterBatch(parameters, ParameterGroup.Optional), true);

            _generator.Generate(panelOptional, "Required", FilterBatch(parameters, ParameterGroup.Required), true);

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
                    return parameters.Where(p => p is IBatchInputParameter);
                case ParameterGroup.Output:
                    return parameters.Where(p => !p.IsInput);
                case ParameterGroup.Required:
                    return parameters.Where(p => p.IsInput && !(p is IBatchInputParameter) && p.Required);
                case ParameterGroup.Optional:
                    return parameters.Where(p => p.IsInput && !(p is IBatchInputParameter) && !p.Required);
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
            chkBackground.Visible = !Model.BatchMode;
            chkBackground.Checked =  AppConfig.Instance.TaskRunInBackground;

            var tool = Model.Tool;

            Text = tool.Name;

            webBrowser1.DocumentText = tool.LoadManual();

            if (Model.BatchMode)
            {
                superToolTip1.SetToolTip(btnRun, null);
            }
        }

        private void AddToolTips(IEnumerable<BaseParameter> parameters)
        {
            var panels = new[] { panelOptional, panelRequired };

            foreach (var panel in panels)
            {
                superToolTip1.AddTooltips(panel, parameters);
            }
        }

        public override void BeforeClose()
        {
            AppConfig.Instance.TaskRunInBackground = chkBackground.Checked;
        }

        private void OnCloseClick(object sender, EventArgs e)
        {
            Close();
        }
    }

    public class GisToolViewBase : MapWindowView<ToolViewModel>
    {
    }
}