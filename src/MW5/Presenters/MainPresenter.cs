using System.Diagnostics;
using System.Windows.Forms;
using MW5.Mvp;

namespace MW5.Presenters
{
    public enum MainCommand
    {
        OpenLayer = 0,
    }

    public interface IMainView : IView<MainViewModel>
    {

    }

    public class MainViewModel
    {
        public string Name { get; set; }
    }

    public class MainPresenter : BasePresenter<IMainView, MainCommand, MainViewModel>
    {
        private readonly IMainView _view;

        public MainPresenter(IMainView view)
            : base(view)
        {
            _view = view;
        }

        public override void RunCommand(MainCommand command)
        {
            switch (command)
            {
                case MainCommand.OpenLayer:
                    Debug.Print("Open layer clicked");
                    UpdateView();
                    break;
            }
        }

        protected override void CommandNotFound(ToolStripItem item)
        {
            Debug.Print("Command not found");
        }
    }
}
