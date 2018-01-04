using System.Reflection;
using System.Windows.Forms;

namespace MW5.Views
{
    public partial class SplashView : Form
    {
        private static SplashView _instance;

        public static SplashView Instance
        {
            get { return _instance ?? (_instance = new SplashView()); }
        }    

        public SplashView()
        {
            InitializeComponent();

            ShowVersion();
        }

        private void ShowVersion()
        {
            lblVersion.Text = Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }

        public void ShowStatus(string message)
        {
            lblStatus.Text = message + "...";
            lblStatus.Refresh();
        }
    }
}
