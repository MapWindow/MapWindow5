using System;
using System.Diagnostics;
using System.Windows.Forms;
using MW5.Services.Helpers;
using MW5.Shared;
using MW5.UI.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Views
{
    public partial class ErrorView : MapWindowForm
    {
        private readonly Exception _exception;
        private const string ReportIssueUrl = "http://mapwindow5.codeplex.com/workitem/list/basic";

        public ErrorView(Exception ex, bool needClose)
        {
            InitializeComponent();

            _exception = ex;

            treeViewAdv1.HScroll = false;
            treeViewAdv1.AutoScrolling = ScrollBars.Vertical;
            treeViewAdv1.HideSelection = false;

            ShowMessage(needClose);

            ShowError(ex);
        }

        private void ShowMessage(bool needClose)
        {
            string s = "Unhandled exception has occured in your application. ";

            if (needClose)
            {
                s += "There is no way to recover from it. Application will be closed.";
            }

            s += " Please report the issue at " + ReportIssueUrl + ".";

            lblMessage.Text = s;

            btnContinue.Visible = !needClose;
        }

        private void ShowError(Exception ex)
        {
            if (ex == null)
            {
                textBoxExt1.Text = "No information about the error was provided.";
                return;
            }

            var node = new TreeNodeAdv
            {
                Text = "Details", 
                Expanded = true
            };

            treeViewAdv1.Nodes.Add(node);

            AddExceptionNodesToTree(ex, node);

            if (node.Nodes.Count > 0)
            {
                treeViewAdv1.SelectedNode = node.Nodes[0];
            }
        }

        private void AddExceptionNodesToTree(Exception ex, TreeNodeAdv parent)
        {
            var node = new TreeNodeAdv
            {
                Text = ex.Message, 
                MultiLine = true, 
                Tag = ex, 
                Expanded = true
            };

            parent.Nodes.Add(node);

            if (ex.InnerException != null)
            {
                AddExceptionNodesToTree(ex.InnerException, parent);
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_exception.ExceptionToString());

            try
            {
                Process.Start(ReportIssueUrl);
            }
            catch (Exception ex)
            {
                Logger.Current.Warn("Failed to open URL: " + ReportIssueUrl, ex);
            }
        }

        private void treeViewAdv1_AfterSelect(object sender, EventArgs e)
        {
            var node = treeViewAdv1.SelectedNode;
            if (node != null)
            {
                var ex = node.Tag as Exception;
                if (ex != null)
                {
                    textBoxExt1.Text = ex.StackTrace;
                }
            }
        }
    }
}
