using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;

namespace MW5.Plugins.Concrete
{
    /// <summary>
    /// A consumer of plugin events for the main application. Isn't added to the list of plugins.
    /// </summary>
    public class MainPlugin: BasePlugin
    {
        public MainPlugin()
        {
            Identity = PluginIdentity.Default;
        }

        public override void Initialize(IAppContext context)
        {
            
        }

        public override void Terminate()
        {
            
        }

        public override void RegisterServices(IApplicationContainer container)
        {

        }
    }
}
