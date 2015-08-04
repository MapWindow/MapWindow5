using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Tools.Model;
using MW5.Tools.Properties;
using MW5.UI.Forms;

namespace MW5.Tools.Views
{
    /// <summary>
    /// Displays log messages and progress of tool execution.
    /// </summary>
    internal partial class TaskLogView : ToolLogViewBase, ITaskLogView
    {
        public TaskLogView()
        {
            InitializeComponent();

            FormClosed += OnFormClosed;

            btnCancel.Click += (s,e) => Invoke(Cancel);

            Shown += OnViewShown;
        }

        private void OnViewShown(object sender, EventArgs e)
        {
            textBoxExt1.BorderStyle = BorderStyle.None;
        }

        public event Action Cancel;

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            DetachProgressHandlers();

            Model.StatusChanged -= OnTaskStatusChanged;
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            UpdateView();

            AttachProgressHandlers();

            Model.StatusChanged += OnTaskStatusChanged;
        }

        private void OnTaskStatusChanged(object sender, EventArgs e)
        {
            this.SafeInvoke(UpdateView);
        }

        public override void UpdateView()
        {
            UpdateDialogCaption();

            if (Model.Status != GisTaskStatus.Running)
            {
                btnClose.Text = "Close";
                panelProgress.Visible = false;
                panelResults.Visible = true;
                UpdateFinishedTaskStatus();
            }
            else
            {
                btnClose.Text = "Background";
            }
        }

        private void UpdateFinishedTaskStatus()
        {
            lblExecutionTime.Text = "Execution time: " + Model.ExecutionTime;

            switch (Model.Status)
            {
                case GisTaskStatus.Success:
                    lblStatus.Text = "Tool execution has finished successfully.";
                    pictureBox1.Image = Resources.img_success32;
                    break;
                case GisTaskStatus.Failed:
                    lblStatus.Text = "Tool execution has failed.";
                    pictureBox1.Image = Resources.img_error32;
                    break;
                case GisTaskStatus.Cancelled:
                    lblStatus.Text = "Tool execution was cancelled.";
                    pictureBox1.Image = Resources.img_cancel32;
                    break;
            }
        }

        private void UpdateDialogCaption()
        {
            string msg = Model.IsFinished ? "Finished" : "Running";
            Text = msg + ": " + Model.Tool.Name;
        }

        private void DetachProgressHandlers()
        {
            var progress = Model.Tool.Progress;
            progress.ProgressChanged -= OnProgressChanged;
            progress.Hide -= OnProgressHide;
        }

        private void AttachProgressHandlers()
        {
            var progress = Model.Tool.Progress;
            progress.ProgressChanged += OnProgressChanged;
            progress.Hide += OnProgressHide;
        }

        public override ViewStyle Style
        {
            get { return new ViewStyle() { Modal = true, Sizable = true, }; }
        }

        public ButtonBase OkButton
        {
            get { return btnClose; }
        }

        private void OnProgressHide(object sender, EventArgs e)
        {
            if (!Visible)
            {
                return;
            }

            Action action = () => { panelProgress.Visible = false; };

            progressBar1.SafeInvoke(action);
        }

        private void OnProgressChanged(object sender, ProgressEventArgs e)
        {
            if (!Visible)
            {
                return;
            }

            Action action = () =>
                {
                    if (e.Percent >= 0 && e.Percent <= 100)
                    {
                        progressBar1.Value = e.Percent;
                    }
                };

            progressBar1.SafeInvoke(action);
        }
    }

    public class ToolLogViewBase : MapWindowView<IGisTask> { }
}
