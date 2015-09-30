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
using MW5.Shared;

namespace MW5.Data.Views
{
    public class AddConnectionPresenter: BasePresenter<IAddConnectionView, AddConnectionModel>
    {
        private readonly IFileDialogService _fileDialog;
        private readonly PostGisConnection _postGis = new PostGisConnection();

        public AddConnectionPresenter(IAddConnectionView view, IFileDialogService fileDialog) : base(view)
        {
            if (fileDialog == null) throw new ArgumentNullException("fileDialog");
            _fileDialog = fileDialog;

            view.Init(_postGis);

            view.TestConnection += TestConnection;

            view.ConnectionChanged += OnConnectionChanged;
        }

        public DatabaseConnection Connection
        {
            get
            {
                var param = View.GetConnection();
                return new DatabaseConnection(View.DatabaseType, param.Name, param.GetConnection());
            }
        }

        public override bool ViewOkClicked()
        {
            var param = View.GetConnection();
            if (param == null)
            {
                MessageService.Current.Info("Failed to retrieve connection parameters");
                return false;
            }

            return param.Validate();
        }

        private void OnConnectionChanged()
        {
            var cn = View.GetConnection();
            var cs = cn.BuildConnection();
            View.SetRawConnection(cs);
        }

        private void TestConnection()
        {
            var info = View.GetConnection();
            if (!info.Validate())
            {
                return;
            }

            string cs = info.GetConnection();

            bool result;
            using (var ds = new VectorDatasource())
            {
                result = ds.Open(cs);
                if (!result)
                {
                    MessageService.Current.Warn("Failed to open connection: " + ds.GdalLastErrorMsg);
                }
                else
                {
                    MessageService.Current.Info("Connected successfully");
                }
            }

            Logger.Current.Info("Testing connection: {0}\n{1}", cs, result ? "Success": "Failure");
        }
    }
}
