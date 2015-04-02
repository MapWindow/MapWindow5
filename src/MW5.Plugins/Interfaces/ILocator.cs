using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Api.Interfaces;

namespace MW5.Plugins.Interfaces
{
    public interface ILocator
    {
        void RestorePicture(System.Drawing.Image image, double dx, double dy, double xllCenter, double yllCenter);
        UserControl View { get; }
        IImageSource Picture { get; }
        void Clear();
        void Update(PreviewExtents updateExtents);
        bool Empty { get; }
    }
}
