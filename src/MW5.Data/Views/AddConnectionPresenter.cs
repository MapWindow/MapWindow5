using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Static;
using MW5.Data.Db;
using MW5.Data.Enums;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Concrete;
using MW5.Plugins.Enums;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;

namespace MW5.Data.Views
{
    public class AddConnectionPresenter: BasePresenter<IAddConnectionView>
    {
        private readonly PostGisConnectionParams _postGisParams = new PostGisConnectionParams();

        public AddConnectionPresenter(IAddConnectionView view) : base(view)
        {
            view.Init(_postGisParams);

            view.TestConnection += TestConnection;
        }

        public DatabaseConnection Connection
        {
            get
            {
                var param = View.GetPostGisParams();
                return new DatabaseConnection(View.DatabaseType, param.Database, param.GetPostGisConnection());
            }
        }

        public override bool ViewOkClicked()
        {
            var param = View.GetPostGisParams();

            return ValidateInput(param);
        }

        private bool ValidateInput(PostGisConnectionParams param)
        {
            if (string.IsNullOrWhiteSpace(param.Host))
            {
                MessageService.Current.Warn("No host name is provided.");
                return false;
            }

            int port;
            if (!Int32.TryParse(param.PortString, out port))
            {
                MessageService.Current.Warn("Port must be an integer number.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(param.UserName))
            {
                MessageService.Current.Warn("No user name is provided.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(param.Database))
            {
                MessageService.Current.Warn("No database name is provided.");
                return false;
            }

            return true;
        }

        private void TestConnection()
        {
            if (View.DatabaseType != GeoDatabaseType.PostGis)
            {
                MessageService.Current.Info("Not implemented");
                return;
            }

            var param = View.GetPostGisParams();

            if (!ValidateInput(param))
            {
                return;
            }

            string cs = param.GetPostGisConnection();

            using (var ds = new VectorDatasource())
            {
                if (!ds.Open(cs))
                {
                    MessageService.Current.Warn("Failed to open connection: " + ds.GdalLastErrorMsg);
                }
                else
                {
                    MessageService.Current.Info("Connected successfully");
                }
            }
        }
    }
}
