using System.Diagnostics;
using System.Windows.Forms;

namespace MW5.Mvp.Sample
{
    public enum SampleCommand
    {
        OpenLayer = 0,
    }

    public interface ISampleView : IView<SampleViewModel>
    {

    }

    public class SampleViewModel
    {
        public string Name { get; set; }
    }

    public class SamplePresenter : BasePresenter<ISampleView, SampleCommand, SampleViewModel>
    {
        private readonly ISampleView _view;

        public SamplePresenter(ISampleView view)
            : base(view)
        {
            _view = view;
        }

        protected override void CommandNotFound(ToolStripItem item)
        {
            Debug.Print("Command not found");
        }

        public override void RunCommand(SampleCommand command)
        {
            switch (command)
            {
                case SampleCommand.OpenLayer:
                    MessageBox.Show("Open layer clicked");
                    UpdateView();
                    break;
            }
        }
    }
}
