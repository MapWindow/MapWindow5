using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class AddFieldPresenter: BasePresenter<IAddFieldView, IAttributeTable>
    {
        private readonly IAddFieldView _view;
        private readonly IMessageService _messageService;
        private IAttributeTable _table;

        public AddFieldPresenter(IAddFieldView view, IMessageService messageService) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");
            if (messageService == null) throw new ArgumentNullException("messageService");

            _view = view;
            _messageService = messageService;
        }

        private FeatureField Field
        {
            get
            {
                var fld = new FeatureField
                {
                    Name = _view.FieldName,
                    Type = _view.FieldType,
                    Width = _view.FieldWidth,
                    Precision = _view.FieldPrecision
                };
                return fld;
            }
        }

        public override bool ViewOkClicked()
        {
            string msg;
            if (!_table.ValidateField(View.FieldName, out msg))
            {
                _messageService.Info(msg);
                return false;
            }
            
            _table.Fields.Add(Field);
            return true;
        }

        public override void Init(IAttributeTable table)
        {
            table.CheckEditMode(true);
            _table = table;
        }
    }
}
