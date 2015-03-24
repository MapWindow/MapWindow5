using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Api.Concrete
{
    public class CustomCursor : CompareByValueBase, IEquatable<CustomCursor>
    {
        // Creating cursors from bitmaps http ://tech.pro/tutorial/732/csharp-tutorial-how-to-use-custom-cursors
        // Loading from resource file: http ://stackoverflow.com/questions/6897274/c-how-to-load-cursor-from-resource-file
        private Guid _guid;
        private readonly Cursor _cursor;

        public CustomCursor(Guid guid, Cursor cursor)
        {
            _guid = guid;
            _cursor = cursor;
        }

        public CustomCursor(Guid guid, Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            _guid = guid;
            _cursor = CreateCursor(bmp, xHotSpot, yHotSpot);
        }

        public Guid Guid
        {
            get { return _guid; }
        }

        public Cursor Cursor
        {
            get { return _cursor; }
        }

        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);

        private static Cursor CreateCursor(Bitmap bmp, int xHotSpot, int yHotSpot)
        {
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            tmp.fIcon = false;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);
        }

        public bool Equals(CustomCursor other)
        {
            return other.Guid == Guid;
        }

        public override bool Equals(object obj)
        {
            return Guid == ((CustomCursor) obj).Guid;
        }

        public override int GetHashCode()
        {
            return Guid.GetHashCode();
        }
    }
}
