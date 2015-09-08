// -------------------------------------------------------------------------------------------
// <copyright file="ToolPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using MW5.Plugins.Helpers;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Shared;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Layers;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Model.Parameters.Layers;
using MW5.Tools.Views.Abstract;

namespace MW5.Tools.Views
{
    /// <summary>
    /// The gis tool presenter.
    /// </summary>
    public class ToolPresenter : BasePresenter<IToolView, ToolViewModel>
    {
        private readonly IAppContext _context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ToolPresenter"/> class.
        /// </summary>
        public ToolPresenter(IToolView view, IAppContext context)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        protected override void Initialize()
        {
            // old values will be set to BaseParameter.PreviousValue
            Model.Tool.RestoreConfig();

            View.GenerateControls();
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event.
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        /// <returns></returns>
        public override bool ViewOkClicked()
        {
            Model.Tool.SaveConfig();

            if (Model.BatchMode)
            {
                return RunBatch();
            }

            if (Control.ModifierKeys == Keys.Control)
            {
                if (RunSingle())
                {
                    MessageService.Current.Info("Task execution has started. You can now run another task now.");
                }

                return false;
            }
            
            return RunSingleAndClose();
        }

        /// <summary>
        /// Creates and runs task for a single input datasource. Keeps the dialog open.
        /// </summary>
        /// <returns></returns>
        private bool RunSingle()
        {
            // we need a copy of tool here, since we don't want to share the instance
            // between different running tasks
            var newTool = (Model.Tool as IParametrizedTool).Clone(_context) as IGisTool;

            if (!Validate(newTool))
            {
                return false;
            }

            RunBatchTask(newTool);

            return true;
        }

        /// <summary>
        /// Creates and runs task for a single input datasource. Closes dialog after it.
        /// </summary>
        private bool RunSingleAndClose()
        {
            if (!Validate(Model.Tool))
            {
                return false;
            }

            IGisTask task = Model.CreateTask();

            if (View.RunInBackground)
            {
                // no progress / log dialog will be shown, so start tracking at once
                _context.Tasks.Add(task);
            }

            task.RunAsync();

            // on success a log window will be opened immediately
            ReturnValue = !View.RunInBackground;

            View.Close();

            return false;
        }

        /// <summary>
        /// Validates parameters and detaches controls from them on the success.
        /// </summary>
        private bool Validate(IGisTool tool)
        {
            if (!tool.Validate())
            {
                return false;
            }

            var pt = tool as IParametrizedTool;
            if (pt != null)
            {
                pt.Parameters.DetachControls();
            }

            return true;
        }

        /// <summary>
        /// Checks that all output datasource will have unique name.
        /// </summary>
        private bool ValidateOutputNames(IEnumerable<IParametrizedTool> tools)
        {
            var outputs = tools.ToList().SelectMany(t => t.Parameters.OfType<OutputLayerParameter>());
            var list = outputs.Select(o => o.GetValue().Filename).ToList();

            if (list.Count() != list.Distinct().Count())
            {
                MessageService.Current.Info(
                    "Duplicate names for output layers. Try to include {input} varaible in the name template, e.g. '{input}_result.shp'");
                return false;
            }

            return true;
        }

        /// <summary>
        /// Creates and runs separated tasks for a number of input datasources.
        /// </summary>
        private bool RunBatch()
        {
            var tool = Model.Tool as IParametrizedTool;
            if (tool == null)
            {
                throw new InvalidCastException("GIS tool implementing IParametrizedTool interface is expected");
            }

            var tools = GenerateBatchTools(tool);
            if (tools == null)
            {
                return false;
            }

            foreach (var newTool in tools)
            {
                RunBatchTask(newTool);
            }

            ReturnValue = false;

            View.Close();

            return false;
        }

        /// <summary>
        /// Generates a new instance of tool for each input file. Word in batch mode only.
        /// </summary>
        private IEnumerable<IGisTool> GenerateBatchTools(IParametrizedTool tool)
        {
            var input = tool.GetBatchModeInputParameter();

            var layers = input.BatchModeList.ToList();
            if (!layers.Any())
            {
                MessageService.Current.Info("No input layers are selected.");
            }

            var tools = layers.Select(l => tool.CloneWithInput(l, _context) as IGisTool).ToList();

            if (!ValidateOutputNames(tools.Select(t => t as IParametrizedTool)))
            {
                return null;
            }

            if (!tools.All(Validate))
            {
                return null;
            }

            return tools;
        }

        /// <summary>
        /// Creates and starts task for one of the batch inputs.
        /// </summary>
        private void RunBatchTask(IGisTool tool)
        {
            var task = new GisTask(tool);

            _context.Tasks.Add(task);
            
            task.RunAsync();
        }
    }
}