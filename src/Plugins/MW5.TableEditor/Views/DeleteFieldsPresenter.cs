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
        }

        public override bool ViewOkClicked()
        {
            var list = View.FieldsToRemove.OrderByDescending(i => i);

            foreach (var i in list)
            {
                _featureSet.Fields.Remove(i);
            }

            return true;
        }

        public override void Init(IFeatureSet fs)
        {
            if (fs == null) throw new ArgumentNullException("fs");

            if (!fs.EditingTable) throw new InvalidOperationException("Table in edit mode is expected.");

            _featureSet = fs;

            View.Table = fs.Table;
        }
    }
}
