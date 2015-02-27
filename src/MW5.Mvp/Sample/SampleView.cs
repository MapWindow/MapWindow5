using System.Windows.Forms;

namespace MW5.Mvp.Sample
{
    public partial class SampleView : Form, ISampleView
    {
        public SampleView()
        {
            InitializeComponent();
        }

        public void ShowView()
        {
            Application.Run(this);
        }

        public ToolStripItemCollection[] Menus
        {
            get { return new [] { toolStrip1.Items}; }
        }

        public void UpdateView(SampleViewModel model)
        {
            textBox1.Text = model.Name;
            MessageBox.Show("Updating view.");
        }
    }
}
