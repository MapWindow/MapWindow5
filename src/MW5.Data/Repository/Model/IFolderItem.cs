namespace MW5.Data.Repository.Model
{
    public interface IFolderItem : IRepositoryItem
    {
        string GetPath();
        bool Loaded { get; }
        bool Root { get; }
        void Refresh();
    }
}
