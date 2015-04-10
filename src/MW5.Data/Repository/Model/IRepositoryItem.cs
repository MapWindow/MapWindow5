namespace MW5.Data.Repository.Model
{
    public interface IRepositoryItem
    {
        RepositoryItemType Type { get; }
        RepositoryItemCollection SubItems { get; }
        object GetInternalObject();
        void Expand();
    }
}
