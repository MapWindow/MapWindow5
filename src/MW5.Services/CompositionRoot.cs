using MW5.Plugins.Log;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Services.Concrete;
using MW5.Services.Serialization;
using MW5.Services.Views;
using MW5.Services.Views.Abstract;
using MW5.Shared.Log;

namespace MW5.Services
{
    internal static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterService<IFileDialogService, FileDialogService>()
                .RegisterService<IMessageService, MessageService>()
                .RegisterSingleton<ILayerService, LayerService>()
                .RegisterSingleton<ILoggingService, LoggingService>()
                .RegisterSingleton<IProjectService, ProjectService>()
                .RegisterService<ICreateLayerView, CreateLayerView>()
                .RegisterService<ImageSerializationService>()
                .RegisterSingleton<ITempFileService, TempFileService>()
                .RegisterSingleton<IConfigService, ConfigService>()
                .RegisterSingleton<IProjectLoader, ProjectLoader>();

        }
    }
}
