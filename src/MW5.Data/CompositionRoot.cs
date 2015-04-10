using MW5.Api.Helpers;
using MW5.Data.Repository;
using MW5.Data.Repository.UI;
using MW5.Plugins.Mvp;
using MW5.Shared;
using MW5.UI.SyncfusionStyle;

namespace MW5.Data
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterSingleton<RepositoryDockPanel>()
                .RegisterSingleton<RepositoryPresenter>();
            
            EnumHelper.RegisterConverter(new RepositoryItemTypeConverter());
        }
    }
}
