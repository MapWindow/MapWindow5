using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tools.Model.Layers;
using MW5.Tools.Tools.Geoprocessing.VectorGeometryTools;

namespace MW5.Tools.Views.Custom
{
    public class RandomPointsPresenter: BasePresenter<IRandomPointsView, ToolViewModel>
    {
        private readonly IAppContext _context;

        public RandomPointsPresenter(IAppContext context, IRandomPointsView view)
            : base(view)
        {
            if (context == null) throw new ArgumentNullException("context");
            _context = context;
        }

        public override bool ViewOkClicked()
        {
            var tool = Model.Tool as RandomPointsTool;
            if (tool == null) throw new InvalidCastException("RandomPointsTool was expected");

            tool.NumPoints = View.NumPoints;
            tool.InputLayer = new LayerInfo(View.Input);
            tool.OutputLayer = new Model.OutputLayerInfo() { Name = View.OutputName, MemoryLayer = true, AddToMap = true };

            var task = Model.CreateTask();

            _context.Tasks.AddTask(task);

            task.RunAsync();

            return true;
        }
    }
}
