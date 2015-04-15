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

        public AddFieldPresenter(IAddFieldView view) : base(view)
        {
            if (view == null) throw new ArgumentNullException("view");

            _view = view;
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
            if (!Model.ValidateField(View.FieldName, out msg))
            {
                MessageService.Current.Info(msg);
                return false;
            }

            Model.Fields.Add(Field);
            return true;
        }

        public override void Initialize()
        {
            Model.CheckEditMode(true);
        }
    }
}
