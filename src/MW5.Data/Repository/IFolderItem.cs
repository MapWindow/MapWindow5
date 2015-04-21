namespace MW5.Data.Repository
{
    public interface IFolderItem : IExpandableItem
    {
        string GetPath();
        bool Root { get; }
    }
}
