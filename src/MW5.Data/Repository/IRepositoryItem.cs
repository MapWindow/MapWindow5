using MW5.Data.Enums;

namespace MW5.Data.Repository
{
    public interface IRepositoryItem
    {
        RepositoryItemType Type { get; }
        RepositoryItemCollection SubItems { get; }
        object GetInternalObject();
        void Expand();
        void Refresh();
        bool Loaded { get; }
        IRepositoryItem Parent { get; }
    }
}
