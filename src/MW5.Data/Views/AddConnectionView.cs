using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MW5.Data.Db;
using MW5.Data.Enums;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Enums;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.UI.Forms;

namespace MW5.Data.Views
{
    public partial class AddConnectionView : MapWindowView, IAddConnectionView
    {
        public AddConnectionView(IAppContext context)
            : base(context.View)
        {
            InitializeComponent();

            btnTestConnection.Click += (s, e) => Invoke(TestConnection);
        }

        public GeoDatabaseType DatabaseType
        {
            get
            {
                switch (tabControlAdv1.SelectedIndex)
                {
                    case 0:
                        return GeoDatabaseType.PostGis;
                    case 1:
                        return GeoDatabaseType.MsSql;
                    case 2:
                        return GeoDatabaseType.Oracle;
                }

                throw new IndexOutOfRangeException("tabControlAdv1.SelectedIndex");
            }

            set
            {
                switch (value)
                {
                    case GeoDatabaseType.PostGis:
                        tabControlAdv1.SelectedIndex = 0;
                        break;
                    case GeoDatabaseType.Oracle:
                        tabControlAdv1.SelectedIndex = 2;
                        break;
                    case GeoDatabaseType.MsSql:
                        tabControlAdv1.SelectedIndex = 3;
                        break;
                }
            }
        }

        public void UpdateView()
        {
            
        }

        public ButtonBase OkButton
        {
            get { return btnOk; }
        }

        public void Init(PostGisConnectionParams param)
        {
            txtHost.Text = param.Host;
            txtPort.Text = param.Port.ToString();
            txtDatabase.Text = param.Database;
            txtUserName.Text = param.UserName;
            txtPassword.Text = param.Password;
        }

        public PostGisConnectionParams GetPostGisParams()
        {
            return new PostGisConnectionParams()
            {
                Host = txtHost.Text,
                PortString = txtPort.Text,
                Database = txtDatabase.Text,
                UserName = txtUserName.Text,
                Password = txtPassword.Text
            };
        }

        public event Action TestConnection;
    }
}
