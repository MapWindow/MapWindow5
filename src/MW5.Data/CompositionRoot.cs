using MW5.Api.Helpers;
using MW5.Data.Repository;
using MW5.Data.Views;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Shared;

namespace MW5.Data
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterView<IAddConnectionView, AddConnectionView>()
                .RegisterSingleton<IRepository, DataRepository>();

            EnumHelper.RegisterConverter(new RepositoryItemTypeConverter());
        }
    }
}
