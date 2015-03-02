using System.Diagnostics;
using System.Windows.Forms;

namespace MW5.Mvp.Sample
{
    public enum SampleCommand
    {
        OpenLayer = 0,
    }

    public interface ISampleView : IComplexView
    {

    }

    public class SampleViewModel
    {
        public string Name { get; set; }
    }

    public class SamplePresenter : CommandPresenter<ISampleView, SampleCommand>
    {
        private readonly ISampleView _view;

        public SamplePresenter(ISampleView view)
            : base(view)
        {
            _view = view;
        }

        protected override void CommandNotFound(string itemName)
        {
            Debug.Print("Command not found: " + itemName);
        }

        public override void RunCommand(SampleCommand command)
        {
            switch (command)
            {
                case SampleCommand.OpenLayer:
                    MessageBox.Show("Open layer clicked");
                    break;
            }
        }
    }
}
