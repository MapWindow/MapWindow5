using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tools.Tools.Gdal;
using MW5.Tools.Views.Gdal.Abstract;

namespace MW5.Tools.Views.Gdal
{
    public class GdalTranslatePresenter: BasePresenter<IGdalTranslateView, ToolViewModel>
    {
        public GdalTranslatePresenter(IGdalTranslateView view)
            : base(view)
        {
        }

        private bool Validate()
        {
            if (string.IsNullOrWhiteSpace(View.InputFilename))
            {
                MessageService.Current.Info(@"Please select an input file first.");
                return false;
            }

            if (!File.Exists(View.InputFilename))
            {
                MessageService.Current.Info(@"The input file does not exists!");
                return false;
            }

            if (string.IsNullOrWhiteSpace(View.OutputFilename))
            {
                MessageService.Current.Info(@"Please select an output file first!");
                return false;
            }

            if (File.Exists(View.OutputFilename))
            {
                try
                {
                    File.Delete(View.OutputFilename);
                }
                catch (Exception)
                {
                    MessageService.Current.Info(@"Could not delete output file. Is it still open?");
                    return false;
                }
            }

            if (string.IsNullOrWhiteSpace(View.OutputFormat))
            {
                MessageService.Current.Info(@"Please select an output format first!");
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            if (!Validate())
            {
                return false;
            }

            var tool = Model.Tool as GdalTranslateTool;
            if (tool == null) throw new InvalidCastException("RandomPointsTool was expected");

            tool.Options = View.Options;
            tool.InputFilename = View.InputFilename;

            tool.Output = new Model.OutputLayerInfo()
                              {
                                  Filename = View.OutputFilename,
                                  AddToMap = View.AddToMap,
                                  MemoryLayer = false,
                              };

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
