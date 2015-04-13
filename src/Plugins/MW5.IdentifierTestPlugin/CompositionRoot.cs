using MW5.Plugins.Mvp;
using MW5.Shared;

namespace MW5.Plugins.IdentifierTestPlugin
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            EnumHelper.RegisterConverter(new IdentifierModeConverter());
        }
    }
}
