using System.Diagnostics;
using System.Windows.Forms;
using MW5.Plugins.Mvp;

namespace MW5.Mvp.Sample
{
    public class SamplePresenter : ComplexPresenter<ISampleView, SampleCommand, SampleViewModel>
    {
        private readonly ISampleView _view;

        public SamplePresenter(ISampleView view)
            : base(view)
        {
            _view = view;
        }

        public override void Initialize()
        {
            Debug.Print("Layer name passed as parameter: " + Model.Name);
        }

        public override void RunCommand(SampleCommand command)
        {
            switch (command)
            {
                case SampleCommand.TestButton:
                    MessageBox.Show("Button is clicked");
                    break;
                case SampleCommand.TestMenu:
                    MessageBox.Show("Menu is clicked");
                    break;
            }
        }

        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
