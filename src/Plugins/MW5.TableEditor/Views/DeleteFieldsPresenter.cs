using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class DeleteFieldsPresenter: BasePresenter<IDeleteFieldsView, IAttributeTable>
    {
        private IAttributeTable _table;

        public DeleteFieldsPresenter(IDeleteFieldsView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            var list = View.FieldsToRemove.OrderByDescending(i => i);

            foreach (var i in list)
            {
                _table.Fields.Remove(i);
            }

            return true;
        }

        public override void Init(IAttributeTable table)
        {
            table.CheckEditMode(true);

            _table = table;

            View.Table = table;
        }
    }
}
