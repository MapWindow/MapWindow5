using System.Drawing;
using System.Windows.Forms;

namespace MW5.Shared
{
    public class OleImageHelper : AxHost
    {
        public OleImageHelper():
            base("59EE46BA-677D-4d20-BF10-8D8067CB8B33")
        {
            
        }
        public OleImageHelper(string clsid) : base(clsid)
        {
        }

        public OleImageHelper(string clsid, int flags) : base(clsid, flags)
        {
        }

        public new Image GetPictureFromIPicture(object picture)
        {
            
            return AxHost.GetPictureFromIPicture(picture);
        }

        public new object GetIPictureFromPicture(Image image)
        {
            return AxHost.GetIPictureFromPicture(image);
        }
    }
}
