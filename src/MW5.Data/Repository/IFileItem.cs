namespace MW5.Data.Repository
{
    public interface IFileItem : IRepositoryItem
    {
        string Filename { get; }
        IFolderItem Folder { get; }
        bool AddedToMap { get; set; }
    }
}
