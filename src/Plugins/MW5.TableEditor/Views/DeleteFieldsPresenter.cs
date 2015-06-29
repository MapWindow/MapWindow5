using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;

namespace MW5.Plugins.TableEditor.Views
{
    public class DeleteFieldsPresenter: BasePresenter<IDeleteFieldsView, IAttributeTable>
    {
        public DeleteFieldsPresenter(IDeleteFieldsView view) : base(view)
        {
        }

        public override bool ViewOkClicked()
        {
            var list = View.FieldsToRemove.OrderByDescending(i => i);

            if (!list.Any())
            {
                MessageService.Current.Info("No fields are selected.");
                return false;
            }

            if (MessageService.Current.Ask("Fields will be removed: " + list.Count() + "." + Environment.NewLine + "Continue?"))
            {
                foreach (var i in list)
                {
                    Model.Fields.Remove(i);
                }

                return true;
            }

            return false;
        }

        public override void Initialize()
        {
            
        }
    }
}
