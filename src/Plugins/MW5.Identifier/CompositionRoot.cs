using MW5.Plugins.Identifier.Enums;
using MW5.Plugins.Identifier.Views;
using MW5.Plugins.Mvp;
using MW5.Shared;

namespace MW5.Plugins.Identifier
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            EnumHelper.RegisterConverter(new IdentifierModeConverter());

            container.RegisterService<IIdentifierView, IdentifierDockPanel>()
            .RegisterSingleton<IdentifierPresenter>();
        }
    }
}
