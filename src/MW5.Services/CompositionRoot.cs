using MW5.Plugins.Mvp;
using MW5.Services.Services;
using MW5.Services.Services.Abstract;
using MW5.Services.Views;

namespace MW5.Services
{
    public static class CompositionRoot
    {
        public static void Compose(IApplicationContainer container)
        {
            container.RegisterService<IFileDialogService, FileDialogService>()
                .RegisterService<IMessageService, MessageService>()
                .RegisterSingleton<ILayerService, LayerService>()
                .RegisterSingleton<ILoggingService, LoggingService>()
                .RegisterService<IProjectService, ProjectService>()
                .RegisterService<ICreateLayerView, CreateLayerView>();
        }
    }
}
