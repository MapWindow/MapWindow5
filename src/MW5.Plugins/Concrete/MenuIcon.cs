using System.Drawing;
using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    public class MenuIcon: IMenuIcon
    {
        private readonly Icon _icon;
        private readonly Image _image;

        public MenuIcon(Image image)
        {
            _image = image;
        }

        public MenuIcon(Icon icon)
        {
            _icon = icon;
        }

        public Image Image
        {
            get
            {
                return _image;
            }
        }
    }
}
