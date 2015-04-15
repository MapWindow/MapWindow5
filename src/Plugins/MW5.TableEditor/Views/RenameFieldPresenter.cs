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
        public RenameFieldPresenter(IRenameFieldView view) : base(view)
        {

        }

        public override void Initialize()
        {
            if (!Model.EditMode)
            {
                throw new InvalidOperationException("Table in edit mode is expected.");
            }
        }

        public override bool ViewOkClicked()
        {
            string msg;

            if (!Validate(out msg))
            {
                MessageService.Current.Info(msg);
                return false;
            }

            _model.Fields[View.FieldIndex].Name = View.NewName;
            return true;
        }

        private bool Validate(out string message)
        {
            if (View.FieldIndex == -1)
            {
                message = "No field is selected.";
                return false;
            }

            return _model.ValidateField(View.NewName, out message);
        }
    }
}
