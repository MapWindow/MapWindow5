using MW5.Api.Concrete;

namespace MW5.Data.Repository
{
    public interface IFileItem : ILayerItem
    {
        string Filename { get; }
        IFolderItem Folder { get; }
    }
}
