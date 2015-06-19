// -------------------------------------------------------------------------------------------
// <copyright file="FieldPropertiesModel.cs" company="MapWindow OSS Team - www.mapwindow.org">
//  MapWindow OSS Team - 2015
// </copyright>
// -------------------------------------------------------------------------------------------

using System;
using MW5.Api.Concrete;
using MW5.Api.Interfaces;

namespace MW5.Plugins.TableEditor.Views
{
    internal class FieldPropertiesModel
    {
        public FieldPropertiesModel(IAttributeTable table, IAttributeField field, bool addField)
        {
            if (table == null) throw new ArgumentNullException("table");

            if (field == null)
            {
                field = new AttributeField();
            }

            Field = field;
            AddField = addField;
            Table = table;
        }

        public bool AddField { get; private set; }

        public bool AllowEditing
        {
            get { return Table.EditMode; }
        }

        public IAttributeField Field { get; private set; }

        public IAttributeTable Table { get; private set; }
    }
}