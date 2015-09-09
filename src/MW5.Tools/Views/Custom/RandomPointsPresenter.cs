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
using MW5.Tools.Views.Custom.Abstract;

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
            tool.InputLayer = new DatasourceInput(View.Input);
            tool.OutputLayer = new Model.OutputLayerInfo() { Filename = View.OutputName, MemoryLayer = true, AddToMap = true };

            if (!tool.Validate())
            {
                return false;
            }

            var task = Model.CreateTask();

            task.RunAsync();

            return true;
        }
    }
}
