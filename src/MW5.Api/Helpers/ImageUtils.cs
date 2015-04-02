using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MW5.Helpers
{
    public class ImageUtils : AxHost
    {
        public ImageUtils():
            base("59EE46BA-677D-4d20-BF10-8D8067CB8B33")
        {
            
        }
        public ImageUtils(string clsid) : base(clsid)
        {
        }

        public ImageUtils(string clsid, int flags) : base(clsid, flags)
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
