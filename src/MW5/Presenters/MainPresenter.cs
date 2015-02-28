using System.Diagnostics;
using System.Windows.Forms;
using MW5.Mvp;
using MW5.Services.Abstract;

namespace MW5.Presenters
{
    public enum MainCommand
    {
        Open = 0,
    }

    public interface IMainView : IView
    {

    }

    public class MainPresenter : BasePresenter<IMainView, MainCommand>
    {
        private readonly IMainView _view;
        private readonly ILayerService _layerService;

        public MainPresenter(IMainView view, ILayerService layerService)
            : base(view)
        {
            _view = view;
            _layerService = layerService;
        }

        public override void RunCommand(MainCommand command)
        {
            switch (command)
            {
                case MainCommand.Open:
                    _layerService.AddLayer(LayerType.All);
                    break;
            }
        }

        protected override void CommandNotFound(ToolStripItem item)
        {
            Debug.Print("Command not found");
        }
    }
}
