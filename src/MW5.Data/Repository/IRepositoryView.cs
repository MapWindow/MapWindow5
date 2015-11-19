using System;
using System.Collections.Generic;
using MW5.Api.Concrete;
using MW5.Data.Enums;

namespace MW5.Data.Repository
{
    public interface IRepositoryView
    {
        RepositoryItemCollection Items { get; }
        IRepositoryItem GetSpecialItem(RepositoryItemType type);
        IGroupItem GetGroup(RepositoryItemType rootType, Guid groupId);
        IRepositoryItem SelectedItem { get; }
        event EventHandler<RepositoryEventArgs> ItemSelected;
        void UpdateState(HashSet<LayerIdentity> layers);
        void UpdateState(IRepositoryItem item);
        void UpdateTmsState(int providerId);
    }
}
