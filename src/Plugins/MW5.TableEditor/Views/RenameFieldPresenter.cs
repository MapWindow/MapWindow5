using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class RenameFieldPresenter : BasePresenter<IRenameFieldView, IAttributeTable>
    {
        private readonly IMessageService _messageService;
        private IAttributeTable _table;

        public RenameFieldPresenter(IRenameFieldView view, IMessageService messageService) : base(view)
        {
            if (messageService == null) throw new ArgumentNullException("messageService");
            _messageService = messageService;
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
            string msg = string.Empty;

            if (!Validate(ref msg))
            {
                _messageService.Info(msg);
                return false;
            }

            _table.Fields[View.FieldIndex].Name = View.NewName;
            return true;
        }

        private bool Validate(ref string message)
        {
            if (View.FieldIndex == -1)
            {
                message = "No field is selected.";
                return false;
            }

            string newName = View.NewName;
            if (newName == string.Empty)
            {
                message = "Please enter a name.";
                return false;
            }

            if (newName.Length > 10)
            {
                message = "Max fieldlength is 10.";
                return false;
            }

            if (_table.Fields.Any(f => f.Name.ToLower() == newName))
            {
                message = "Fieldname already exists or has been previously added/removed in this session. Apply or cancel your changes and try again.";
                return false;
            }

            return true;
        }
    }
}
