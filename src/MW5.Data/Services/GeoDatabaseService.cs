using System;
using MW5.Data.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;
using MW5.Shared;

namespace MW5.Data.Services
{
    public class GeoDatabaseService: IGeoDatabaseService
    {
        private readonly IAppContext _context;

        public GeoDatabaseService(IAppContext context)
        {
            Logger.Current.Trace("In GeoDatabaseService");
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public void ImportLayer()
        {
            Logger.Current.Trace("In GeoDatabaseService.ImportLayer()");
            _context.Container.Run<ImportLayerPresenter>();
        }

        public DatabaseConnection PromptUserForConnection(GeoDatabaseType? databaseType = null)
        {
            Logger.Current.Trace("In GeoDatabaseService.PromptUserForConnection()");
            var p = _context.Container.GetInstance<AddConnectionPresenter>();

            var model = new AddConnectionModel(databaseType);

            return p.Run(model) ? model.Connection : null;
        }
    }
}
