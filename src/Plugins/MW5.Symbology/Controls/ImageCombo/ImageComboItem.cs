using System.Drawing;

namespace MW5.Plugins.Symbology.Controls.ImageCombo
{
    /// <summary>
    /// An item of ImageComboBox
    /// </summary>
    public class ImageComboItem : object
    {
        // forecolor: transparent = inherit
        private Color _forecolor = Color.FromKnownColor(KnownColor.Transparent);
        private int _imageindex = -1;
        private string _text;

        /// <summary>
        /// Constructor
        /// </summary>
        public ImageComboItem()
        {
            Tag = null;
            Mark = false;
        }

        public ImageComboItem(string text)
        {
            Tag = null;
            Mark = false;
            _text = text;
        }

        public ImageComboItem(string text, int imageIndex)
        {
            Tag = null;
            Mark = false;
            _text = text;
            _imageindex = imageIndex;
        }

        public ImageComboItem(string text, int imageIndex, bool mark)
        {
            Tag = null;
            _text = text;
            _imageindex = imageIndex;
            Mark = mark;
        }

        public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor)
        {
            Tag = null;
            _text = text;
            _imageindex = imageIndex;
            Mark = mark;
            _forecolor = foreColor;
        }

        public ImageComboItem(string text, int imageIndex, bool mark, Color foreColor, object tag)
        {
            _text = text;
            _imageindex = imageIndex;
            Mark = mark;
            _forecolor = foreColor;
            Tag = tag;
        }

        /// <summary>
        /// Gets or sets fore color
        /// </summary>
        public Color ForeColor
        {
            get { return _forecolor; }
            set { _forecolor = value; }
        }

        /// <summary>
        /// Index of image for the item
        /// </summary>
        public int ImageIndex
        {
            get { return _imageindex; }
            set { _imageindex = value; }
        }

        /// <summary>
        /// Marks the itme in bold font
        /// </summary>
        public bool Mark { get; set; }

        /// <summary>
        /// Gets a sets an object to describe an itme
        /// </summary>
        public object Tag { get; set; }

        /// <summary>
        /// Gets or sets the text of the item
        /// </summary>
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        /// <summary>
        ///  Returns text property of the item
        /// </summary>
        public override string ToString()
        {
            return _text;
        }
    }
}
