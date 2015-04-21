using System;
using MW5.Data.Views;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Services;

namespace MW5.Data.Services
{
    public class GeoDatabaseService: IGeoDatabaseService
    {
        private readonly IAppContext _context;

        public GeoDatabaseService(IAppContext context)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public void ImportLayer()
        {
            var connection = PromtUserForConnection();
            if (connection != null)
            {
                
            }
        }

        public DatabaseConnection PromtUserForConnection(GeoDatabaseType? databaseType = null)
        {
            var p = _context.Container.GetInstance<AddConnectionPresenter>();

            AddConnectionModel model = null;
            if (databaseType.HasValue)
            {
                model = new AddConnectionModel(databaseType.Value);
            }

            if (p.Run(model))
            {
                return p.Connection;
            }

            return null;
        }
    }
}
