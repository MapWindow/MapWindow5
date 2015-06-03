using System.Drawing;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class MenuIcon: IMenuIcon
    {
        private readonly Image _image;
        private readonly bool _useNativeSize;

        public MenuIcon(Image image, bool useNativeSize)
        {
            _image = image;
            _useNativeSize = useNativeSize;
        }

        public MenuIcon(Image image)
        {
            _image = image;
        }

        public bool UseNativeSize
        {
            get { return _useNativeSize; }
        }

        public Image Image
        {
            get
            {
                return _image;
            }
        }

        public static void AssignIcon(IMenuItem menuItem, Bitmap icon)
        {
            if (menuItem != null && icon != null)
            {
                menuItem.Icon = new MenuIcon(icon);
            }
        }
    }
}
