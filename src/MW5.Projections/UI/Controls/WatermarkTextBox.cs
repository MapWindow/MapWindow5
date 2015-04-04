using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.Projections.UI.Controls
{
    public class WatermarkTextbox : TextBoxExt
    {
        private string _cue;

        [Localizable(true)]
        public string Cue
        {
            get { return _cue; }
            set 
            { 
                _cue = value; 
                UpdateCue(); 
            }
        }

        private void UpdateCue()
        {
            if (IsHandleCreated && _cue != null)
            {
                SendMessage(Handle, 0x1501, (IntPtr)1, _cue);
            }
        }

        protected override void OnHandleCreated(EventArgs e)
        {
            base.OnHandleCreated(e);
            UpdateCue();
        }

        // PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
}
