using System.Collections.Generic;
using System.Windows.Forms;
using MW5.Plugins.Interfaces;

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

        public IEnumerable<IToolbar> Toolbars
        {
            get { return null; }
        }

        public void UpdateView()
        {
            throw new System.NotImplementedException();
        }
    }
}
