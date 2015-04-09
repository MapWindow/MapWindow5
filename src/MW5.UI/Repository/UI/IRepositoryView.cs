using System;
using MW5.UI.Repository.Model;

namespace MW5.UI.Repository.UI
{
    public interface IRepositoryView
    {
        RepositoryItemCollection Items { get; }
        IFolderItem CreateFolder(string path, bool root);
        IRepositoryItem CreateItem(RepositoryItemType type);
        IVectorItem CreateVector(string filename);
        IRepositoryItem GetSpecialItem(RepositoryItemType type);
        IRepositoryItem SelectedItem { get; }
        event EventHandler<RepositoryEventArgs> ItemSelected;
    }
}
