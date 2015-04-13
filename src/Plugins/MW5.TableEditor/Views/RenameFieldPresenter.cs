using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class RenameFieldPresenter : BasePresenter<IRenameFieldView, IAttributeTable>
    {
        private IAttributeTable _table;

        public RenameFieldPresenter(IRenameFieldView view) : base(view)
        {

        }

        public override void Init(IAttributeTable table)
        {
            if (table == null) throw new ArgumentNullException("table");

            if (!table.EditMode)
            {
                throw new InvalidOperationException("Table in edit mode is expected.");
            }

            _table = table;

            View.Init(table);
        }

        public override bool ViewOkClicked()
        {
            string msg;

            if (!Validate(out msg))
            {
                MessageService.Current.Info(msg);
                return false;
            }

            _table.Fields[View.FieldIndex].Name = View.NewName;
            return true;
        }

        private bool Validate(out string message)
        {
            if (View.FieldIndex == -1)
            {
                message = "No field is selected.";
                return false;
            }

            return _table.ValidateField(View.NewName, out message);
        }
    }
}
