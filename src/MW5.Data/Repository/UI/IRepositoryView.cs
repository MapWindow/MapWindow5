using System;
using MW5.Data.Repository.Model;

namespace MW5.Data.Repository.UI
{
    public interface IRepositoryView
    {
        RepositoryItemCollection Items { get; }
        IRepositoryItem GetSpecialItem(RepositoryItemType type);
        IRepositoryItem SelectedItem { get; }
        event EventHandler<RepositoryEventArgs> ItemSelected;
        
    }
}
