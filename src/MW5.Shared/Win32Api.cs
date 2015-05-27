using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace MW5.Shared
{
    public static class Win32Api
    {
        private struct POINTAPI
        {
            public int x;
            public int y;
        }

        [DllImport("user32.dll")]
        private static extern void GetCursorPos(ref POINTAPI lpPoint);

        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.Winapi)]
        internal static extern IntPtr GetFocus();

        public static System.Drawing.Point GetCursorLocation()
        {
            POINTAPI pnt = new POINTAPI();
            GetCursorPos(ref pnt);
            return new System.Drawing.Point(pnt.x, pnt.y);
        }

        public static Control GetFocusedControl()
        {
            IntPtr focusedHandle = GetFocus();
            return focusedHandle != IntPtr.Zero ? Control.FromHandle(focusedHandle) : null;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point pt);

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);
    }
}
