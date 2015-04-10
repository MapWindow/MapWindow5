namespace MW5.Data.Repository
{
    public interface IFolderItem : IRepositoryItem
    {
        string GetPath();
        bool Root { get; }
    }
}
