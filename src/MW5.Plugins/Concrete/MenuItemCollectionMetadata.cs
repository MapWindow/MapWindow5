using MW5.Plugins.Interfaces;

namespace MW5.Plugins.Concrete
{
    internal class MenuItemCollectionMetadata
    {
        public IMenuItem InsertBefore { get; set; }
        public bool AlignRight { get; set; }
    }
}
