// -------------------------------------------------------------------------------------------
// <copyright file="FieldPropertiesPresenter.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using MW5.Api.Interfaces;
using MW5.Attributes.Helpers;
using MW5.Plugins.Mvp;
using MW5.Plugins.Services;
using MW5.Plugins.TableEditor.Helpers;
using MW5.Plugins.TableEditor.Views.Abstract;
using MW5.Shared;

namespace MW5.Plugins.TableEditor.Views
{
    internal class FieldPropertiesPresenter : BasePresenter<IFieldPropertiesView, FieldPropertiesModel>
    {
        public FieldPropertiesPresenter(IFieldPropertiesView view)
            : base(view)
        {
        }

        private bool Validate(IAttributeField field)
        {
            string errorMessage;

            bool nameChanged = Model.AddField || Model.AllowEditing && field.Name.ContainsIgnoreCase(Model.Field.Name);

            if (nameChanged && !Model.Table.ValidateFieldName(field.Name, out errorMessage))
            {
                MessageService.Current.Info(errorMessage);
                return false;
            }

            return true;
        }

        public override bool ViewOkClicked()
        {
            var fld = View.NewField;

            if (!Validate(fld))
            {
                return false;
            }

            if (Model.AddField)
            {
                Model.Table.Fields.Add(fld);
            }
            else
            {
                Model.Field.Name = fld.Name;
                Model.Field.Visible = fld.Visible;
                Model.Field.Alias = fld.Alias;
            }

            return true;
        }
    }
}