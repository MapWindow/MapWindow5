using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Static;
using MW5.Data.Enums;
using MW5.Data.Views.Abstract;
using MW5.Plugins.Mvp;

namespace MW5.Data.Views
{
    public class GdalInfoPresenter: BasePresenter<IGdalInfoView, GdalInfoModel>
    {
        public GdalInfoPresenter(IGdalInfoView view)
            : base(view)
        {
        }

        protected override void Initialize()
        {
            string description = string.Empty;

            var item = Model.Datasource;
            if (item.Type == RepositoryItemType.Image)
            {
                description = GdalUtils.Instance.GdalInfo(item.Filename, "");
            }
            else if (item.Type == RepositoryItemType.Vector)
            {
                description = GdalUtils.Instance.OgrInfo(item.Filename, "", "");
            }

            View.SetDescription(description);
        }
        /// <summary>
        /// A handler for the IView.OkButton.Click event. 
        /// If the method returns true, View will be closed and presenter.ReturnValue set to true.
        /// If the method return false, no actions are taken, so View.Close, presenter.ReturnValue
        /// should be called / set manually.
        /// </summary>
        public override bool ViewOkClicked()
        {
            return true;
        }
    }
}
