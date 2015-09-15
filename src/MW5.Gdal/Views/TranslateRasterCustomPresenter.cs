using System;
using System.IO;
using MW5.Gdal.Tools;
using MW5.Gdal.Views.Abstract;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Tools.Model;
using MW5.Tools.Views;

namespace MW5.Gdal.Views
{
    public class TranslateRasterCustomPresenter: BasePresenter<ITranslateRasterCustomView, ToolViewModel>
    {
        public TranslateRasterCustomPresenter(ITranslateRasterCustomView view)
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

            var tool = Model.Tool as TranslateRasterCustomTool;
            if (tool == null) throw new InvalidCastException("TranslateRasterTool was expected.");

            tool.Options = View.Options;
            tool.InputFilename = View.InputFilename;

            tool.Output = new OutputLayerInfo()
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
