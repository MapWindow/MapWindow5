using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class DeleteFieldsPresenter: BasePresenter<IDeleteFieldsView, IFeatureSet>
    {
        private IFeatureSet _featureSet;

        public DeleteFieldsPresenter(IDeleteFieldsView view) : base(view)
        {
            view.OkClicked += ViewOkClicked;
        }

        private void ViewOkClicked()
        {
            var list = View.FieldsToRemove.OrderByDescending(i => i);

            foreach (var i in list)   
            {
                _featureSet.Fields.Remove(i);
            }

            _success = true;
            View.Close();
        }

        public override bool Run(IFeatureSet fs, bool modal = true)
        {
            if (fs == null) throw new ArgumentNullException("fs");

            if (!fs.EditingTable)
            {
                throw new InvalidOperationException("Table in edit mode is expected.");
            }

            _featureSet = fs;

            View.Table = fs.Table;
            View.ShowView(modal);

            return _success;
        }
    }
}
