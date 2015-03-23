namespace MW5.Plugins.Symbology.Controls
{
    /// <summary>
    /// A class for items with realIndex property
    /// </summary>
    internal class RealIndexComboItem
    {
        private readonly string _text;
        private readonly int _realIndex;

        public RealIndexComboItem(string text, int realIndex)
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
