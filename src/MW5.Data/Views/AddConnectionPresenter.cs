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

        public override bool ViewOkClicked()
        {
            var connection = View.GetConnection();
            if (connection == null)
            {
                MessageService.Current.Info("Failed to retrieve connection parameters");
                return false;
            }

            if (!connection.Validate())
            {
                return false;
            }

            Model.Connection = new DatabaseConnection(View.DatabaseType, 
                                                     connection.Name, 
                                                     connection.GetConnection(),
                                                     connection.GetConnection(true));

            return true;
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
            string errorMessage = string.Empty;

            View.StartWait();

            Task<bool>.Factory.StartNew(() => TestConnectionCore(cs, ref errorMessage)).ContinueWith(t =>
                {
                    View.StopWait();

                    if (!t.Result)
                    {
                        MessageService.Current.Warn("Failed to open connection.");
                    }
                    else
                    {
                        MessageService.Current.Info("Connected successfully");
                    }

                    Logger.Current.Info("Testing connection: {0}\n{1}", cs, t.Result ? "Success" : "Failure");

                }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        private bool TestConnectionCore(string cs, ref string errorMessage)
        {
            using (var ds = new VectorDatasource())
            {
                bool result = ds.Open(cs);
                if (!result)
                {
                    errorMessage = ds.GdalLastErrorMsg;
                }

                return result;
            }
        }
    }
}
