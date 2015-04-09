using System;
using MW5.UI.Repository.Model;

namespace MW5.UI.Repository.UI
{
    public interface IRepositoryView
    {
        RepositoryItemCollection Items { get; }
        IRepositoryItem GetSpecialItem(RepositoryItemType type);
        IRepositoryItem SelectedItem { get; }
        event EventHandler<RepositoryEventArgs> ItemSelected;
        
    }
}
