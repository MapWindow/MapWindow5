using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Enums;
using MW5.Plugins.Events;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.Shared.Log;
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
        private readonly Timer _timer = new Timer();

        public TaskLogView()
        {
            InitializeComponent();

            FormClosed += OnFormClosed;

            btnCancel.Click += (s,e) => Invoke(Cancel);

            btnPause.Click += (s, e) => Invoke(Pause);

            Shown += (s, e) =>
                {
                    textBoxExt1.BorderStyle = BorderStyle.None;
                    Refresh();
                };
        }
        
        public event Action Cancel;

        public event Action Pause;

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            DetachProgressHandlers();

            Model.StatusChanged -= OnTaskStatusChanged;

            Model.Tool.Log.EntryAdded -= OnLogMessageAdded;
        }

        /// <summary>
        /// Called before view is shown. Allows to initialize UI from this.Model property.
        /// </summary>
        public void Initialize()
        {
            UpdateView();

            AttachProgressHandlers();

            Model.StatusChanged += OnTaskStatusChanged;

            DisplayExistingLogEntries();

            btnCancel.Enabled = Model.Tool.SupportsCancel;

            if (!Model.IsFinished)
            {
                StartTimer();
            }
        }

        private void DisplayExistingLogEntries()
        {
            var log = Model.Tool.Log;
            
            log.Lock();
            try
            {
                Model.Tool.Log.EntryAdded += OnLogMessageAdded;

                var sb = new StringBuilder();
                foreach (var item in log.Entries)
                {
                    sb.Append(item.ToLine());
                }

                textBoxExt1.Text = sb.ToString();
            }
            finally
            {
                log.UnLock();
            }
        }

        private void OnLogMessageAdded(object sender, LogEventArgs e)
        {
            Action action = () => textBoxExt1.AppendText(e.Entry.ToLine());
            textBoxExt1.SafeInvoke(action);
        }

        private void OnTaskStatusChanged(object sender, EventArgs e)
        {
            this.SafeInvoke(UpdateView);
        }

        public override void UpdateView()
        {
            UpdateDialogCaption();

            if (Model.IsFinished)
            {
                btnClose.Text = "Close";
                panelProgress.Visible = false;
                panelResults.Visible = true;
                UpdateFinishedTaskStatus();
                ScrollToLogEnd();
            }
            else
            {
                btnClose.Text = "Background";
                panelProgress.Visible = true;
                panelResults.Visible = false;
                UpdateRunningTask();
            }
        }

        private void ScrollToLogEnd()
        {
            textBoxExt1.SelectionStart = textBoxExt1.TextLength;
            textBoxExt1.ScrollToCaret();
        }


        private void UpdateRunningTask()
        {
            switch (Model.Status)
            {
                case GisTaskStatus.Running:
                    btnPause.Text = "Pause";
                    panelProgress.Text = "Task is running";
                    break;
                case GisTaskStatus.Paused:
                    btnPause.Text = "Resume";
                    panelProgress.Text = "Task is paused";
                    break;
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
            var progress = Model.Progress;
            progress.ProgressChanged -= OnProgressChanged;
            progress.Hide -= OnProgressHide;
        }

        private void AttachProgressHandlers()
        {
            var progress = Model.Progress;
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
                        lblPercent.Text = e.Message; // + " " + e.Percent.ToString(CultureInfo.InvariantCulture) + "%";
                        lblPercent.Invalidate();
                    }
                };

            progressBar1.SafeInvoke(action);
        }

        private void StartTimer()
        {
            _timer.Tick += (s, e) =>
            {
                lblElapsed.Text = "Elapsed: " + Model.ExecutionTime.ToString(@"hh\:mm\:ss");
                if (Model.IsFinished)
                {
                    _timer.Stop();
                }
            };
            _timer.Interval = 1000;
            _timer.Start();
        }
    }

    public class ToolLogViewBase : MapWindowView<IGisTask> { }
}
