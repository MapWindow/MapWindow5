using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI
{
    internal class StatusBar: IStatusBar
    {
        private readonly StatusStripEx _statusBar;
        private ToolStripItem _progressMessage;
        private ToolStripProgressBar _progressBar;

        private class MenuKeys
        {
            public const string ProgressMessage = "statusProgressMessage";
            public const string ProgressBar = "statusProgressBar";
        }

        internal StatusBar(object statusBar)
        {
            _statusBar = statusBar as StatusStripEx;
            if (_statusBar == null) throw new ArgumentNullException("statusBar");

            _progressMessage = FindItem(MenuKeys.ProgressMessage);
            _progressBar = FindItem(MenuKeys.ProgressBar) as ToolStripProgressBar;

            if (_progressBar == null || _progressMessage == null)
            {
                throw new NullReferenceException("Failed to find default status bar items.");
            }
        }

        public void ShowProgress(string message, int percent)
        {
            _progressMessage.Text = message;
            _progressBar.Value = percent;
            if (!_progressMessage.Visible)
            {
                _progressMessage.Visible = true;
                _progressBar.Visible = true;
                _statusBar.Refresh();
            }
        }

        public void HideProgress()
        {
            _progressMessage.Visible = false;
            _progressBar.Visible = false;
        }

        private ToolStripItem FindItem(string itemName)
        {
            foreach (var item in _statusBar.Items)
            {
                var label = item as ToolStripItem;
                if (label != null)
                {
                    if (label.Name == itemName)
                    {
                        return label;
                    }
                }
            }
            return null;
        }
    }
}
