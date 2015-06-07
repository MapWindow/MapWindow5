using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MW5.UI.Properties;
using Syncfusion.Windows.Forms.Tools;

namespace MW5.UI.Controls
{
    public class WatermarkTextbox : TextBoxExt
    {
        private const int IconSize = 24;
        private string _cue;

        public WatermarkTextbox()
        {
            MouseDown += OnMouseDown;
        }

        public bool ShowClearButton
        {
            get { return FarImage != null; }
            set { FarImage = value ? Resources.img_clear_textbox : null; }
        }

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

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            if (ShowClearButton && FarImage != null && e.X > Width - IconSize)
            {
                Text = string.Empty;
            }
        }

        // PInvoke
        [DllImport("user32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, string lp);
    }
}
