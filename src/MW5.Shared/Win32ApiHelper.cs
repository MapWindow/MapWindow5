using System.Runtime.InteropServices;

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

        public static System.Drawing.Point GetCursorLocation()
        {
            POINTAPI pnt = new POINTAPI();
            GetCursorPos(ref pnt);
            return new System.Drawing.Point(pnt.x, pnt.y);
        }
    }
}
