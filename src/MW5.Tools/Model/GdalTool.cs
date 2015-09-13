// -------------------------------------------------------------------------------------------
// <copyright file="GdalTool.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System.Linq;
using MW5.Plugins.Concrete;
using MW5.Tools.Model.Parameters;
using MW5.Tools.Views.Gdal;

namespace MW5.Tools.Model
{
    public abstract class GdalTool : GisTool, IGdalTool
    {
        private bool DisplayOptionsDialog { get; set; }

        public abstract string AdditionalOptions { get; set; }

        public StringParameter AdditionalOptionsParameter
        {
            get { return Parameters.FirstOrDefault(p => p.Name == "AdditionalOptions") as StringParameter; }
        }

        public abstract string GetOptions(bool mainOnly = false);

        public bool ShowOptionsDialog()
        {
            AppConfig.Instance.ToolShowGdalOptionsDialog = DisplayOptionsDialog;

            // display a dialog to enable the editing of options
            if (DisplayOptionsDialog)
            {
                var model = new GdalOptionsModel(GetOptions(true), AdditionalOptions) { Caption = Name };
                if (Context.Container.Run<GdalOptionsPresenter, GdalOptionsModel>(model))
                {
                    AdditionalOptions = model.AdditionalOptions;
                    return true;
                }

                return false;
            }

            return true;
        }

        protected override bool BeforeRun()
        {
            return ShowOptionsDialog();
        }
    }
}