using System.Windows.Forms;

namespace MW5.Api.Helpers
{
    public static class MouseEventHelper
    {
        private const int MK_LBUTTON = 0x0001;
        private const int MK_RBUTTON = 0x0002;
        private const int MK_SHIFT = 0x0004;
        private const int MK_CONTROL = 0x0008;
        private const int MK_MBUTTON = 0x0010;
        private const int MK_XBUTTON1 = 0x0020;
        private const int MK_XBUTTON2 = 0x0040;

        public static MouseButtons ParseMouseButton(short button)
        {
            switch (button)
            {
                case MK_LBUTTON:
                    return MouseButtons.Left;
                case MK_RBUTTON:
                    return MouseButtons.Right;
                case MK_MBUTTON:
                    return MouseButtons.Middle;
                case MK_XBUTTON1:
                    return MouseButtons.XButton1;
                case MK_XBUTTON2:
                    return MouseButtons.XButton2;
            }
            return MouseButtons.None;
        }
    }
}
