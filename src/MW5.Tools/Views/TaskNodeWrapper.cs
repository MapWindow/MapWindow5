// -------------------------------------------------------------------------------------------
// <copyright file="TaskNodeWrapper.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using MW5.Shared;
using MW5.Tools.Controls;
using MW5.Tools.Helpers;
using Syncfusion.Windows.Forms.Tools;
using Action = System.Action;

namespace MW5.Tools.Views
{
    /// <summary>
    /// Wrapps treeview nodes associated with a single task, allows to update them without rebuilding the whole tree.
    /// </summary>
    internal class TaskNodeWrapper
    {
        private readonly IGisTask _task;
        private TreeNodeAdv _node;
        private ProgressBar _progress;

        public TaskNodeWrapper(IGisTask task)
        {
            if (task == null) throw new ArgumentNullException("task");
            _task = task;

            GenerateNode();
        }

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

        public void UpdateStatus()
        {
            _node.Text = _task.Name;

            CreateBarProgress();

            UpdateStatusIcon();

            if (Task.IsFinished)
            {
                HideProgress();
            }
        }

        private void AddProgressHandlers()
        {
            _task.Progress.ProgressChanged += (s, e) =>
                {
                    Action action = () => { _progress.Value = e.Percent; };
                    _progress.SafeInvoke(action);
                };

            _task.Progress.Hide += (s, e) => _progress.SafeInvoke(HideProgress);
        }

        private void CreateBarProgress()
        {
            if (!_task.IsFinished && _progress == null)
            {
                var ctrl = new ProgressBarWrapper();
                _node.CustomControl = ctrl;
                _progress = ctrl.ProgressBar;
            }
        }

        private void GenerateNode()
        {
            _node = new TreeNodeAdv(_task.Name) { Tag = this };

            CreateBarProgress();

            AddProgressHandlers();

            UpdateStatus();
        }

        private void HideProgress()
        {
            // CustomControl.Visible = false property doesn't work,
            // have to set custom control to null instead
            _node.CustomControl = null;
        }

        private void UpdateStatusIcon()
        {
            var iconIndex = (int)_task.GetStatusIcon();
            _node.LeftImageIndices = new[] { iconIndex };
        }
    }
}