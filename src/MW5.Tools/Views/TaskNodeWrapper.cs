// -------------------------------------------------------------------------------------------
// <copyright file="TaskNodeWrapper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Controls;
using MW5.Tools.Enums;
using MW5.Tools.Helpers;
using MW5.Tools.Model;
using MW5.Tools.Model.Parameters;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Tools.Views
{
    /// <summary>
    /// Wrapps treeview nodes associated with a single task, allows to update them without rebuilding the whole tree.
    /// </summary>
    [HasRegions]
    internal class TaskNodeWrapper
    {
        private readonly IGisTask _task;
        private TreeNodeAdv _node;
        private TreeNodeAdv _nodeExecution;
        private ProgressBar _progress;

        #region Constructors

        public TaskNodeWrapper(IGisTask task)
        {
            if (task == null) throw new ArgumentNullException("task");
            _task = task;

            GenerateNodes();
        }

        #endregion

        #region Properties

        public TreeNodeAdv Node
        {
            get { return _node; }
        }

        public ProgressBar Progress
        {
            get { return _progress; }
        }

        public IGisTask Task
        {
            get { return _task; }
        }

        #endregion

        #region Public Methods

        public void UpdateStatus()
        {
            _node.Text = _task.Tool.Name + " [" + _task.Status + "]";
            
            UpdateExecutionNode();

            UpdateStatusIcon();

            if (Task.IsFinished)
            {
                HideProgress();
            }
        }

        #endregion

        #region Methods

        private void AddExecutionNode()
        {
            _nodeExecution = new TreeNodeAdv("Execution") { LeftImageIndices = new[] { (int)TaskIcons.Execution } };

            UpdateExecutionNode();

            _node.Nodes.Add(_nodeExecution);
        }

        private void AddToolParameters(TreeNodeAdv nodeTask, GisTool tool, bool output)
        {
            var iconIndex = new[] { (int)(output ? TaskIcons.Result : TaskIcons.Input) };
            var nodeParameters = new TreeNodeAdv(output ? "Output" : "Input") { LeftImageIndices = iconIndex };

            foreach (var p in tool.Parameters)
            {
                bool outputParameter = p is OutputLayerParameter;
                if (outputParameter != output)
                {
                    continue;
                }

                // TODO: use multiline description
                var node = new TreeNodeAdv(p.ToString());
                nodeParameters.Nodes.Add(node);
            }

            nodeTask.Nodes.Add(nodeParameters);
        }

        private void GenerateNodes()
        {
            _node = new TreeNodeAdv(_task.Tool.Name) { Tag = this };
            _node.Height += 5;

            if (!_task.IsFinished)
            {
                var ctrl = new ProgressBarWrapper();
                _node.CustomControl = ctrl;
                _progress = ctrl.ProgressBar;
            }

            AddToolParameters();

            AddProgressHandlers();

            AddExecutionNode();

            AddErrors();

            UpdateStatus();
        }

        private void AddToolParameters()
        {
            var tool = _task.Tool as GisTool;
            if (tool != null)
            {
                AddToolParameters(_node, tool, false);

                AddToolParameters(_node, tool, true);
            }
        }

        private void AddProgressHandlers()
        {
            _task.TaskProgress.ProgressChanged += (s, e) =>
                {
                    Action action = () => { _progress.Value = e.Percent; };
                    _progress.SafeInvoke(action);
                };

            _task.TaskProgress.Hide += (s, e) => _progress.SafeInvoke(HideProgress);
        }

        private void HideProgress()
        {
            // CustomControl.Visible = false property doesn't work,
            // have to set custom control to null instead
            _node.CustomControl = null;
        }

        private void AddErrors()
        {
            //bool hasErrors = false;
            //if (hasErrors)
            //{
            //    var nodeErrors = new TreeNodeAdv("Errors") { LeftImageIndices = new[] { (int)TaskIcons.Log } };
            //    nodeTask.Nodes.Add(nodeErrors);
            //}
        }

        private void UpdateStatusIcon()
        {
            var iconIndex = (int)_task.GetStatusIcon();
            _node.LeftImageIndices = new[] { iconIndex };
        }

        private void UpdateExecutionNode()
        {
            _nodeExecution.Nodes.Clear();

            var list = new List<string> { "Started at: " + _task.StartTime.ToLongTimeString() };

            if (_task.IsFinished)
            {
                list.Add("Finished at: " + _task.FinishTime.ToLongTimeString());
                list.Add("Execution time: " + _task.ExecutionTime);
            }

            foreach (var s in list)
            {
                _nodeExecution.Nodes.Add(new TreeNodeAdv(s));
            }
        }

        #endregion
    }
}