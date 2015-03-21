using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MW5.Plugins.Symbology.Forms.Categories
{
    /// <summary>
    /// A class for items with realIndex property
    /// </summary>
    internal class ComboItem
    {
        private readonly string _text;
        private readonly int _realIndex;

        public ComboItem(string text, int realIndex)
        {
            _text = text;
            _realIndex = realIndex;
        }
        public override string ToString()
        {
            return _text;
        }
        public string Text
        {
            get { return _text; }
        }
        public int RealIndex
        {
            get { return _realIndex; }
        }
    }

}
